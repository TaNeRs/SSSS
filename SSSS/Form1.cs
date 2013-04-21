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

namespace SSSS {
    public partial class Form1 : Form {

        List<Post> postList;

        public Form1() {
            InitializeComponent();
        }

        void GetPosts(string subreddit) {
            toolStripStatusLabel1.Text = "Getting postings... Please wait";
            var session = User.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            //var list = Sub.Get(session, subreddit);
            postList = Sub.GetListing(session, subreddit);
            toolStripStatusLabel1.Text = "Done!";
        }

        private void button1_Click(object sender, EventArgs e) {
            GetPosts(SubredditTextBox.Text.ToString());
            PostListView.DisplayMember = "Title";
            PostListView.ValueMember = "ID";
            PostListView.DataSource = postList;
        }

        private void PostListView_SelectedIndexChanged(object sender, EventArgs e) {
            string postID = (sender as ListControl).SelectedValue.ToString();
            string opText = ((sender as ListBox).SelectedItem as Post).SelfText;
            PostPreview.Text = opText;

            opText = WordStopper.RemoveStopWords(opText);
            opText = Regex.Replace(opText, @"[^\w\s+]", "");
            string[] opArr = opText.Split(null);
            TestStemmer(new EnglishStemmer(), opArr);
        }

        private static void TestStemmer(IStemmer stemmer, params string[] words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word + " --> " + stemmer.Stem(word));
            }
        }
    }
}
