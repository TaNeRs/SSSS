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

namespace SSSS
{
    public partial class JaccardSimilarityForm : Form
    {

        List<Post> postList;
        Session session;

        public JaccardSimilarityForm()
        {
            InitializeComponent();
            session = User.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
        }

        public string[][] WordCountTable { get; set; }

        public bool IsRemoveStopWordsChecked { get; set; }
        public bool IsStemWordsChecked { get; set; }

        void GetPosts(string subreddit)
        {

            int count = 500; //number of posts to get
            postList = new List<Post>();
            for (int i = 0; i < count; i += 100)
            {
                PostListing tempPostList2 = Sub.GetListing(session, subreddit, SubSortBy.TopMonth, i.ToString());
                postList.AddRange(tempPostList2);
            }


            List<Post> tempPostList = new List<Post>();
            foreach (Post item in postList)
            {
                if (!IsLinkOrImage(item))
                {
                    if (IsRemoveStopWordsChecked)
                        item.SelfText = StemWords(item.SelfText);
                    if (IsStemWordsChecked)
                        item.SelfText = RemoveStopWords(item.SelfText);
                    tempPostList.Add(item);
                }
            }
            postList = tempPostList;
            toolStripStatusLabel1.Text = "Done!";
        }

        private string RemoveStopWords(string opText)
        {
            opText = WordStopper.RemoveStopWords(opText);
            opText = Regex.Replace(opText, @"[^\w\s+]", "");
            return opText;
        }

        private string StemWords(string opText)
        {
            Dictionary<string, int> currentPostStems = new Dictionary<string, int>();

            string[] opArr = opText.Split(null);
            string outputText = "";
            //currentPostStems = TestStemmer(new EnglishStemmer(), opArr);
            //foreach (KeyValuePair<string, int> stem in currentPostStems)
            //{
            //    outputText += "Stem: " + stem.Key + "\t\tOccurs: " + stem.Value + Environment.NewLine;
            //}
            EnglishStemmer stemmer = new EnglishStemmer();
            foreach (string word in opArr)
            {
                outputText += stemmer.Stem(word) + " ";
            }

            return outputText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Getting postings... Please wait";
            GetPosts(SubredditTextBox.Text.ToString());
            PostListView.DisplayMember = "Title";
            PostListView.ValueMember = "ID";
            PostListView.DataSource = postList;
        }

        private void PostListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string postID = (sender as ListControl).SelectedValue.ToString();
            Post post = ((sender as ListBox).SelectedItem as Post);
            string opText;// = ((sender as ListBox).SelectedItem as Post).SelfText;

            Indicator_Dunno();
            if (IsLinkOrImage(post))
                opText = GetExternalPage(post);
            else
            {
                opText = post.SelfText;
                double poolSize = 2, threshold = 0.5, du;
                Double.TryParse(tbxPoolSize.Text, out poolSize);
                Double.TryParse(tbxThreshold.Text, out threshold);

                du = Utilities.PrecisionUsingJaccardSimilarity(WordCountTable, post, poolSize, threshold);
                tbxPrecision.Text = du.ToString();

                if (du > 0.5)
                {
                    Indicator_IsSpam();
                }
                else
                {
                    Indicator_IsNotSpam();
                }
            }

            PostPreview.Text = opText;
            ProcessedPost.Text = "";

            //Dictionary<string, int> currentPostStems = new Dictionary<string, int>();

            //opText = WordStopper.RemoveStopWords(opText);
            //opText = Regex.Replace(opText, @"[^\w\s+]", "");
            //string[] opArr = opText.Split(null);
            //if (!IsLinkOrImage(post))
            //{
            //    currentPostStems = TestStemmer(new EnglishStemmer(), opArr);
            //    foreach (KeyValuePair<string, int> stem in currentPostStems)
            //    {
            //        ProcessedPost.Text += "Stem: " + stem.Key + "\t\tOccurs: " + stem.Value + Environment.NewLine;
            //    }
            //}
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

        private bool IsLinkOrImage(Post post)
        {
            if (post.IsSelf)
                return false;
            return true;
        }

        private string GetExternalPage(Post post)
        {
            WebClient client = new WebClient();
            string htmlCode = client.DownloadString(post.Url);

            return htmlCode;
        }

        private void Indicator_IsSpam()
        {
            IsSpamLabel.Text = "yep";
            IsSpamPanel.BackColor = Color.Red;
        }
        private void Indicator_IsNotSpam()
        {
            IsSpamLabel.Text = "nope";
            IsSpamPanel.BackColor = Color.Green;
        }
        private void Indicator_Dunno()
        {
            IsSpamLabel.Text = "dunno";
            IsSpamPanel.BackColor = Color.Yellow;
        }
    }
}
