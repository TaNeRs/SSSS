namespace SSSS
{
    partial class JaccardSimilarityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SubredditTextBox = new System.Windows.Forms.TextBox();
            this.PostListView = new System.Windows.Forms.ListBox();
            this.PostPreview = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.ProcessedPost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IsSpamPanel = new System.Windows.Forms.Panel();
            this.IsSpamLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPoolSize = new System.Windows.Forms.TextBox();
            this.tbxThreshold = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPrecision = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.IsSpamPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubredditTextBox
            // 
            this.SubredditTextBox.Location = new System.Drawing.Point(169, 11);
            this.SubredditTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SubredditTextBox.Name = "SubredditTextBox";
            this.SubredditTextBox.Size = new System.Drawing.Size(374, 20);
            this.SubredditTextBox.TabIndex = 0;
            this.SubredditTextBox.Text = "bitcoin";
            // 
            // PostListView
            // 
            this.PostListView.FormattingEnabled = true;
            this.PostListView.Location = new System.Drawing.Point(10, 34);
            this.PostListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PostListView.Name = "PostListView";
            this.PostListView.Size = new System.Drawing.Size(596, 160);
            this.PostListView.TabIndex = 1;
            this.PostListView.SelectedIndexChanged += new System.EventHandler(this.PostListView_SelectedIndexChanged);
            // 
            // PostPreview
            // 
            this.PostPreview.Location = new System.Drawing.Point(10, 221);
            this.PostPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PostPreview.Multiline = true;
            this.PostPreview.Name = "PostPreview";
            this.PostPreview.ReadOnly = true;
            this.PostPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PostPreview.Size = new System.Drawing.Size(596, 208);
            this.PostPreview.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(547, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 19);
            this.button1.TabIndex = 3;
            this.button1.Text = "Do it to it";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Subreddit to scan:  reddit.com/r/";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(746, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 206);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Content";
            // 
            // ProcessedPost
            // 
            this.ProcessedPost.Location = new System.Drawing.Point(10, 306);
            this.ProcessedPost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProcessedPost.Multiline = true;
            this.ProcessedPost.Name = "ProcessedPost";
            this.ProcessedPost.ReadOnly = true;
            this.ProcessedPost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProcessedPost.Size = new System.Drawing.Size(596, 125);
            this.ProcessedPost.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Processed Output";
            // 
            // IsSpamPanel
            // 
            this.IsSpamPanel.BackColor = System.Drawing.Color.Yellow;
            this.IsSpamPanel.Controls.Add(this.IsSpamLabel);
            this.IsSpamPanel.Location = new System.Drawing.Point(610, 323);
            this.IsSpamPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IsSpamPanel.Name = "IsSpamPanel";
            this.IsSpamPanel.Size = new System.Drawing.Size(128, 108);
            this.IsSpamPanel.TabIndex = 11;
            // 
            // IsSpamLabel
            // 
            this.IsSpamLabel.AutoSize = true;
            this.IsSpamLabel.Location = new System.Drawing.Point(40, 47);
            this.IsSpamLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IsSpamLabel.Name = "IsSpamLabel";
            this.IsSpamLabel.Size = new System.Drawing.Size(37, 13);
            this.IsSpamLabel.TabIndex = 0;
            this.IsSpamLabel.Text = "dunno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 306);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Is this spam?";
            // 
            // tbxPoolSize
            // 
            this.tbxPoolSize.Location = new System.Drawing.Point(691, 52);
            this.tbxPoolSize.Name = "tbxPoolSize";
            this.tbxPoolSize.Size = new System.Drawing.Size(32, 20);
            this.tbxPoolSize.TabIndex = 13;
            this.tbxPoolSize.Text = "2";
            // 
            // tbxThreshold
            // 
            this.tbxThreshold.Location = new System.Drawing.Point(691, 93);
            this.tbxThreshold.Name = "tbxThreshold";
            this.tbxThreshold.Size = new System.Drawing.Size(32, 20);
            this.tbxThreshold.TabIndex = 14;
            this.tbxThreshold.Text = "0.5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(634, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Pool Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(631, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Threshold";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(631, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Precision";
            // 
            // tbxPrecision
            // 
            this.tbxPrecision.Location = new System.Drawing.Point(691, 259);
            this.tbxPrecision.Name = "tbxPrecision";
            this.tbxPrecision.ReadOnly = true;
            this.tbxPrecision.Size = new System.Drawing.Size(32, 20);
            this.tbxPrecision.TabIndex = 17;
            // 
            // CosineSimilarityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 453);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxPrecision);
            this.Controls.Add(this.PostPreview);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxThreshold);
            this.Controls.Add(this.tbxPoolSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IsSpamPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProcessedPost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PostListView);
            this.Controls.Add(this.SubredditTextBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CosineSimilarityForm";
            this.Text = "Spitefully Spotting Spurious Spammers";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.IsSpamPanel.ResumeLayout(false);
            this.IsSpamPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SubredditTextBox;
        private System.Windows.Forms.ListBox PostListView;
        private System.Windows.Forms.TextBox PostPreview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProcessedPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel IsSpamPanel;
        private System.Windows.Forms.Label IsSpamLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPoolSize;
        private System.Windows.Forms.TextBox tbxThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxPrecision;

    }
}

