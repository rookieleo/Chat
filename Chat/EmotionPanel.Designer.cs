namespace Chat
{
    partial class EmotionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcEmotion = new System.Windows.Forms.TabControl();
            this.tpDefaultEmotion = new System.Windows.Forms.TabPage();
            this.wbEmotionPage = new System.Windows.Forms.WebBrowser();
            this.tcEmotion.SuspendLayout();
            this.tpDefaultEmotion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcEmotion
            // 
            this.tcEmotion.Controls.Add(this.tpDefaultEmotion);
            this.tcEmotion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEmotion.Location = new System.Drawing.Point(0, 0);
            this.tcEmotion.Name = "tcEmotion";
            this.tcEmotion.SelectedIndex = 0;
            this.tcEmotion.Size = new System.Drawing.Size(300, 200);
            this.tcEmotion.TabIndex = 0;
            // 
            // tpDefaultEmotion
            // 
            this.tpDefaultEmotion.Controls.Add(this.wbEmotionPage);
            this.tpDefaultEmotion.Location = new System.Drawing.Point(4, 22);
            this.tpDefaultEmotion.Margin = new System.Windows.Forms.Padding(0);
            this.tpDefaultEmotion.Name = "tpDefaultEmotion";
            this.tpDefaultEmotion.Padding = new System.Windows.Forms.Padding(3);
            this.tpDefaultEmotion.Size = new System.Drawing.Size(292, 174);
            this.tpDefaultEmotion.TabIndex = 0;
            this.tpDefaultEmotion.Text = "默认";
            this.tpDefaultEmotion.UseVisualStyleBackColor = true;
            // 
            // wbEmotionPage
            // 
            this.wbEmotionPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbEmotionPage.Location = new System.Drawing.Point(3, 3);
            this.wbEmotionPage.Margin = new System.Windows.Forms.Padding(0);
            this.wbEmotionPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbEmotionPage.Name = "wbEmotionPage";
            this.wbEmotionPage.ScrollBarsEnabled = false;
            this.wbEmotionPage.Size = new System.Drawing.Size(286, 168);
            this.wbEmotionPage.TabIndex = 0;
            this.wbEmotionPage.WebBrowserShortcutsEnabled = false;
            this.wbEmotionPage.ObjectForScripting = this;
            // 
            // EmotionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcEmotion);
            this.Name = "EmotionPanel";
            this.Size = new System.Drawing.Size(300, 200);
            this.Load += new System.EventHandler(this.EmotionPanel_Load);
            this.tcEmotion.ResumeLayout(false);
            this.tpDefaultEmotion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcEmotion;
        private System.Windows.Forms.TabPage tpDefaultEmotion;
        private System.Windows.Forms.WebBrowser wbEmotionPage;
    }
}
