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
        Session session;
        string[][] WordCountTable;

        public Form1() {
            InitializeComponent();
            session = User.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
        }

        void GetPosts(string subreddit) {
            
            int count = 500; //number of posts to get
            postList = new List<Post>();
            string tempLastPostID = "";
            for (int i = 0; i < count; i+=100)
			{
                PostListing tempPostList2 = Sub.GetListing(session, subreddit, tempLastPostID);
                postList.AddRange(tempPostList2);
                tempLastPostID = tempPostList2.Last().Name;
			}
            

            List<Post> tempPostList = new List<Post>();
            foreach (Post item in postList) {
                if (!IsLinkOrImage(item)) { //this is a link to an external page or redd.it or to an image
                    if (this.RemoveStopWordsCheckbox.Checked)
                        item.SelfText = StemWords(item.SelfText);
                    if (this.StemWordsCheckbox.Checked)
                        item.SelfText = RemoveStopWords(item.SelfText);
                    tempPostList.Add(item);
                } else {
                    if(this.FollowLinksCheckbox.Checked && (item.Url.Contains("reddit.com") || item.Url.Contains("redd.it"))) {
                        try {
                            WebClient client = new WebClient();
                            string htmlCode = client.DownloadString(item.Url);
                        } catch {
                            //do nothing. this is to catch 404s
                        }
                    }
                }
            }
            postList = tempPostList;
            toolStripStatusLabel1.Text = "Done!";
        }

        private void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "Getting postings... Please wait";
            GetPosts(SubredditTextBox.Text.ToString());

            //GetPosts("hailcorporate");
            WordCountTable = Utilities.GenerateCountVectorTable(postList);

            PostListView.DisplayMember = "Title";
            PostListView.ValueMember = "ID";
            PostListView.DataSource = postList;
        }

        private void PostListView_SelectedIndexChanged(object sender, EventArgs e) {
            string postID = (sender as ListControl).SelectedValue.ToString();
            Post post = ((sender as ListBox).SelectedItem as Post);
            //string postID = post.
            string opText;// = ((sender as ListBox).SelectedItem as Post).SelfText;
            string previewText;

            if (IsLinkOrImage(post))
                opText = previewText = GetExternalPage(post);
            else {
                opText = previewText = post.SelfText;
                CompareNewPost(post);
            }

            PostPreview.Text = previewText;
            //opText = RemoveStopWords(opText);
            //opText = StemWords(opText);

            //ProcessedPost.Text = opText;
        }

        private string RemoveStopWords(string opText) {
            opText = WordStopper.RemoveStopWords(opText);
            opText = Regex.Replace(opText, @"[^\w\s+]", "");
            return opText;
        }

        private string StemWords(string opText) {
            Dictionary<string, int> currentPostStems = new Dictionary<string, int>();

            string[] opArr = opText.Split(null);
            string outputText = "";
            //currentPostStems = TestStemmer(new EnglishStemmer(), opArr);
            //foreach (KeyValuePair<string, int> stem in currentPostStems)
            //{
            //    outputText += "Stem: " + stem.Key + "\t\tOccurs: " + stem.Value + Environment.NewLine;
            //}
            EnglishStemmer stemmer = new EnglishStemmer();
            foreach (string word in opArr) {
                outputText += stemmer.Stem(word) + " ";
            }

            return outputText;
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
            CosineSimilarityForm spamSpottingForm = new CosineSimilarityForm();
            spamSpottingForm.WordCountTable = WordCountTable;
            spamSpottingForm.IsRemoveStopWordsChecked = RemoveStopWordsCheckbox.Checked;
            spamSpottingForm.IsStemWordsChecked = StemWordsCheckbox.Checked;
            spamSpottingForm.Show();
        }

        private void button5_Click(object sender, EventArgs e) {
            KNNForm knnform = new KNNForm(WordCountTable);
            knnform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JaccardSimilarityForm jaccardForm = new JaccardSimilarityForm();
            jaccardForm.WordCountTable = WordCountTable;
            jaccardForm.IsRemoveStopWordsChecked = RemoveStopWordsCheckbox.Checked;
            jaccardForm.IsStemWordsChecked = StemWordsCheckbox.Checked;
            jaccardForm.Show();

        }
        
    }
}
