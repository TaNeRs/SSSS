using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using com.reddit.api;
using Iveonik.Stemmers;
using System.Text.RegularExpressions;
using System.Net;

namespace SSSS {
    public partial class Form1 : Form {

        List<Post> postList;

        string[][] WordCountTable;

        public Form1() {
            InitializeComponent();

            GetPosts("hailcorporate");
            WordCountTable = Utilities.GenerateCountVectorTable(postList);
        }

        void GetPosts(string subreddit) {
            var session = User.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

            postList = Sub.GetListing(session, subreddit);
            toolStripStatusLabel1.Text = "Done!";
        }

        private void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "Getting postings... Please wait";
            GetPosts(SubredditTextBox.Text.ToString());
            PostListView.DisplayMember = "Title";
            PostListView.ValueMember = "ID";
            PostListView.DataSource = postList;
        }

        private void PostListView_SelectedIndexChanged(object sender, EventArgs e) {
            string postID = (sender as ListControl).SelectedValue.ToString();
            Post post = ((sender as ListBox).SelectedItem as Post);
            string opText;// = ((sender as ListBox).SelectedItem as Post).SelfText;
            
            if (IsLinkOrImage(post))
                opText = GetExternalPage(post);
            else {
                opText = post.SelfText;
                CompareNewPost(post);
            }
            
            PostPreview.Text = opText;
            ProcessedPost.Text = "";

            Dictionary<string, int> currentPostStems = new Dictionary<string, int>();

            opText = WordStopper.RemoveStopWords(opText);
            opText = Regex.Replace(opText, @"[^\w\s+]", "");
            string[] opArr = opText.Split(null);
            if (!IsLinkOrImage(post))
            {
                currentPostStems = TestStemmer(new EnglishStemmer(), opArr);
                foreach (KeyValuePair<string, int> stem in currentPostStems)
                {
                    ProcessedPost.Text += "Stem: " + stem.Key + "\t\tOccurs: " + stem.Value + Environment.NewLine;
                }
            }
        }

        private static Dictionary<string, int> TestStemmer(IStemmer stemmer, params string[] words)
        {
            Dictionary<string, int> currentStems = new Dictionary<string, int>();
            string stemmedWord;

            foreach (string word in words)
            {
                stemmedWord = stemmer.Stem(word);
                Console.WriteLine(word + " --> " + stemmedWord);
                if (currentStems.ContainsKey(stemmedWord))
                {
                    currentStems[stemmedWord] = currentStems[stemmedWord] + 1;
                }
                else
                {
                    currentStems.Add(stemmedWord, 1);
                }
            }

            return currentStems;
        }
        
        private bool IsLinkOrImage(Post post) {
            if(post.IsSelf)
                return false;
            return true;
        }

        private string GetExternalPage(Post post) {
            WebClient client = new WebClient();
            string htmlCode = client.DownloadString(post.Url);

            return htmlCode;
        }

        private void CompareNewPost(Post post) {
            List<Post> postList = new List<Post>();
            postList.Add(post);
            string[][] wordCountTable = Utilities.GenerateCountVectorTable(postList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrefForm pref = new PrefForm();
            pref.Show();
        }

        private void button3_Click(object sender, EventArgs e) {
            SpamSpottingForm spamSpottingForm = new SpamSpottingForm();
            spamSpottingForm.Show();
        }
        
    }
}
