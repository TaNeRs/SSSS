namespace SSSS {
    partial class NewKNNForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
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
            this.VisualizationPanel = new System.Windows.Forms.Panel();
            this.VisImg = new Emgu.CV.UI.ImageViewer();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.statusStrip1.SuspendLayout();
            this.VisualizationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SubredditTextBox
            // 
            this.SubredditTextBox.Location = new System.Drawing.Point(225, 14);
            this.SubredditTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubredditTextBox.Name = "SubredditTextBox";
            this.SubredditTextBox.Size = new System.Drawing.Size(497, 22);
            this.SubredditTextBox.TabIndex = 0;
            this.SubredditTextBox.Text = "bitcoin";
            // 
            // PostListView
            // 
            this.PostListView.FormattingEnabled = true;
            this.PostListView.ItemHeight = 16;
            this.PostListView.Location = new System.Drawing.Point(13, 42);
            this.PostListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostListView.Name = "PostListView";
            this.PostListView.Size = new System.Drawing.Size(793, 196);
            this.PostListView.TabIndex = 1;
            this.PostListView.SelectedIndexChanged += new System.EventHandler(this.PostListView_SelectedIndexChanged);
            // 
            // PostPreview
            // 
            this.PostPreview.Location = new System.Drawing.Point(13, 272);
            this.PostPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostPreview.Multiline = true;
            this.PostPreview.Name = "PostPreview";
            this.PostPreview.ReadOnly = true;
            this.PostPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PostPreview.Size = new System.Drawing.Size(793, 255);
            this.PostPreview.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(729, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Do it to it";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Subreddit to scan:  reddit.com/r/";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1127, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Content";
            // 
            // ProcessedPost
            // 
            this.ProcessedPost.Location = new System.Drawing.Point(13, 377);
            this.ProcessedPost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProcessedPost.Multiline = true;
            this.ProcessedPost.Name = "ProcessedPost";
            this.ProcessedPost.ReadOnly = true;
            this.ProcessedPost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProcessedPost.Size = new System.Drawing.Size(793, 153);
            this.ProcessedPost.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Processed Output";
            // 
            // VisualizationPanel
            // 
            this.VisualizationPanel.Controls.Add(this.imageBox1);
            this.VisualizationPanel.Location = new System.Drawing.Point(813, 272);
            this.VisualizationPanel.Name = "VisualizationPanel";
            this.VisualizationPanel.Size = new System.Drawing.Size(302, 229);
            this.VisualizationPanel.TabIndex = 11;
            // 
            // VisImg
            // 
            this.VisImg.AutoScroll = true;
            this.VisImg.ClientSize = new System.Drawing.Size(751, 593);
            this.VisImg.Image = null;
            this.VisImg.Location = new System.Drawing.Point(30, 30);
            this.VisImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VisImg.Name = "VisImg";
            this.VisImg.Text = "Image";
            this.VisImg.Visible = false;
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(0, 0);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(299, 229);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // NewKNNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 566);
            this.Controls.Add(this.VisualizationPanel);
            this.Controls.Add(this.PostPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProcessedPost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PostListView);
            this.Controls.Add(this.SubredditTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NewKNNForm";
            this.Text = "Spitefully Spotting Spurious Spammers";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.VisualizationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
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
        private System.Windows.Forms.Panel VisualizationPanel;
        private Emgu.CV.UI.ImageViewer VisImg;
        private Emgu.CV.UI.ImageBox imageBox1;
    }
}

