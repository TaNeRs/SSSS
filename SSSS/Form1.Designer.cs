namespace SSSS {
    partial class Form1 {
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
            this.SubredditTextBox = new System.Windows.Forms.TextBox();
            this.PostListView = new System.Windows.Forms.ListBox();
            this.PostPreview = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RemoveStopWordsCheckbox = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.StemWordsCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ProcessedPost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubredditTextBox
            // 
            this.SubredditTextBox.Enabled = false;
            this.SubredditTextBox.Location = new System.Drawing.Point(107, 14);
            this.SubredditTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubredditTextBox.Name = "SubredditTextBox";
            this.SubredditTextBox.Size = new System.Drawing.Size(497, 22);
            this.SubredditTextBox.TabIndex = 0;
            this.SubredditTextBox.Text = "hailcorporate";
            // 
            // PostListView
            // 
            this.PostListView.FormattingEnabled = true;
            this.PostListView.ItemHeight = 16;
            this.PostListView.Location = new System.Drawing.Point(13, 42);
            this.PostListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostListView.Name = "PostListView";
            this.PostListView.Size = new System.Drawing.Size(793, 116);
            this.PostListView.TabIndex = 1;
            this.PostListView.SelectedIndexChanged += new System.EventHandler(this.PostListView_SelectedIndexChanged);
            // 
            // PostPreview
            // 
            this.PostPreview.Location = new System.Drawing.Point(13, 191);
            this.PostPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostPreview.Multiline = true;
            this.PostPreview.Name = "PostPreview";
            this.PostPreview.ReadOnly = true;
            this.PostPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PostPreview.Size = new System.Drawing.Size(793, 144);
            this.PostPreview.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Do it to it";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(693, 12);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Preferences";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "reddit.com/r/";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(995, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RemoveStopWordsCheckbox);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.StemWordsCheckbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(813, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 174);
            this.panel1.TabIndex = 7;
            // 
            // RemoveStopWordsCheckbox
            // 
            this.RemoveStopWordsCheckbox.AutoSize = true;
            this.RemoveStopWordsCheckbox.Location = new System.Drawing.Point(7, 84);
            this.RemoveStopWordsCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveStopWordsCheckbox.Name = "RemoveStopWordsCheckbox";
            this.RemoveStopWordsCheckbox.Size = new System.Drawing.Size(152, 21);
            this.RemoveStopWordsCheckbox.TabIndex = 3;
            this.RemoveStopWordsCheckbox.Text = "Remove Stopwords";
            this.RemoveStopWordsCheckbox.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 57);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(127, 21);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Break Hyphens";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // StemWordsCheckbox
            // 
            this.StemWordsCheckbox.AutoSize = true;
            this.StemWordsCheckbox.Location = new System.Drawing.Point(7, 30);
            this.StemWordsCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StemWordsCheckbox.Name = "StemWordsCheckbox";
            this.StemWordsCheckbox.Size = new System.Drawing.Size(92, 21);
            this.StemWordsCheckbox.TabIndex = 1;
            this.StemWordsCheckbox.Text = "Stemming";
            this.StemWordsCheckbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Preprocessing Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Input";
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(813, 477);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 53);
            this.button3.TabIndex = 11;
            this.button3.Text = "Cosine Similarity";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(813, 356);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(181, 39);
            this.button4.TabIndex = 12;
            this.button4.Text = "Jaccard Me!";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(813, 415);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(182, 44);
            this.button5.TabIndex = 13;
            this.button5.Text = "kNN";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 558);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProcessedPost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PostPreview);
            this.Controls.Add(this.PostListView);
            this.Controls.Add(this.SubredditTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Spitefully Spotting Spurious Spammers";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SubredditTextBox;
        private System.Windows.Forms.ListBox PostListView;
        private System.Windows.Forms.TextBox PostPreview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox RemoveStopWordsCheckbox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox StemWordsCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProcessedPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;

    }
}

