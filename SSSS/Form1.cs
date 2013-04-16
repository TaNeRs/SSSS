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

        public Form1() {
            InitializeComponent();
        }

        void GetPosts(string subreddit) {
            var session = User.Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            //var list = Sub.Get(session, subreddit);
            postList = Sub.GetListing(session, subreddit);
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
    }
}
