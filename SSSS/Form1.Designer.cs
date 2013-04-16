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
            this.URLBox = new System.Windows.Forms.TextBox();
            this.TopicList = new System.Windows.Forms.ListBox();
            this.TopicPreview = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // URLBox
            // 
            this.URLBox.Location = new System.Drawing.Point(13, 13);
            this.URLBox.Name = "URLBox";
            this.URLBox.Size = new System.Drawing.Size(591, 22);
            this.URLBox.TabIndex = 0;
            this.URLBox.Text = "Subreddit URL";
            // 
            // TopicList
            // 
            this.TopicList.FormattingEnabled = true;
            this.TopicList.ItemHeight = 16;
            this.TopicList.Location = new System.Drawing.Point(13, 42);
            this.TopicList.Name = "TopicList";
            this.TopicList.Size = new System.Drawing.Size(190, 404);
            this.TopicList.TabIndex = 1;
            // 
            // TopicPreview
            // 
            this.TopicPreview.Location = new System.Drawing.Point(210, 42);
            this.TopicPreview.Multiline = true;
            this.TopicPreview.Name = "TopicPreview";
            this.TopicPreview.ReadOnly = true;
            this.TopicPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TopicPreview.Size = new System.Drawing.Size(596, 401);
            this.TopicPreview.TabIndex = 2;
            this.TopicPreview.Text = "Topic Preview";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Scan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(694, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Preferences";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 455);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TopicPreview);
            this.Controls.Add(this.TopicList);
            this.Controls.Add(this.URLBox);
            this.Name = "Form1";
            this.Text = "Spitefully Spotting Spurious Spammers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLBox;
        private System.Windows.Forms.ListBox TopicList;
        private System.Windows.Forms.TextBox TopicPreview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}

