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

namespace SSSS {
    public partial class Form1 : Form {

        List<Post> postList;

        Dictionary<string, int> wordCountDict = new Dictionary<string, int>();

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

            PostPreview.Text = ((sender as ListBox).SelectedItem as Post).SelfText;

        }

        //*********************************Vincent's Test Code****************************/

        //List<Post> lst = new List<Post>();
        //lst.Add(postList[0]);
        //lst.Add(postList[12]);
        //Dictionary<string, int> wordCountDict2 = new Dictionary<string, int>();
        //Utilities.CountUpWords(lst, wordCountDict2);

        //int ct = 26;
        //foreach (KeyValuePair<string, int> itm in wordCountDict2) {
        //    if (ct > 0) {
        //        wordCountDict.Add(itm.Key, itm.Value);
        //        ct--;
        //    }
        //    else {
        //        break;
        //    }
        //}

        ////Utilities.CountUpWords(postList, wordCountDict);
        //int k = 1;
        //foreach (KeyValuePair<string, int> itm in wordCountDict) {
        //    System.Console.WriteLine("Item# " + k + " - Key: " + itm.Key + ", Value: " + itm.Value);
        //    k++;
        //}
        //List<Dictionary<string, int>> folds = Utilities.NFold(5, wordCountDict);
        //for (int i = 0; i < folds.Count; i++) {
        //    System.Console.WriteLine();
        //    System.Console.WriteLine();
        //    System.Console.WriteLine("****************************************FOLD " + (i + 1).ToString() + " STARTS HERE!!!!!");
        //    int j = 1;
        //    foreach (KeyValuePair<string, int> itm in folds[i]) {
        //        System.Console.WriteLine("Item# " + j + " - Key: " + itm.Key + ", Value: " + itm.Value);
        //        j++;
        //    }
        //}
        //wordCountDict.Clear();

        //Dictionary<string, int> train = new Dictionary<string, int>();
        //train.Add("a", 5);
        //train.Add("b", 4);
        //train.Add("c", 3);
        //train.Add("d", 3);
        //train.Add("e", 3);

        //Dictionary<string, int> test = new Dictionary<string, int>();
        //test.Add("a", 2);
        //test.Add("b", 2);
        //test.Add("e", 5);

        //double valD = Utilities.CosineSimilarity(train, test);
        //System.Console.WriteLine("Cosine Similarity: " + valD);



        //Utilities.CountUpWords((sender as ListBox).SelectedItem as Post, wordCountDict);
        //foreach (KeyValuePair<string, uint> itm in wordCountDict) {
        //    System.Console.WriteLine("Key: " + itm.Key + ", Value: " + itm.Value);
        //}
        //wordCountDict.Clear();

        //********************************Vincent's Test Code end************************/
    }
}
