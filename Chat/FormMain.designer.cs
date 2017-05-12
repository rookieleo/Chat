namespace BlindChat
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.gbFriend = new System.Windows.Forms.GroupBox();
            this.tvContact = new System.Windows.Forms.TreeView();
            this.gbChat = new System.Windows.Forms.GroupBox();
            this.emotionPanel1 = new Chat.EmotionPanel();
            this.rtbChat = new BlindChat.RichTextBoxEx();
            this.gbMessage = new System.Windows.Forms.GroupBox();
            this.tsMessage = new System.Windows.Forms.ToolStrip();
            this.tsbEmotion = new System.Windows.Forms.ToolStripButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbMessage = new BlindChat.RichTextBoxEx();
            this.gbFriend.SuspendLayout();
            this.gbChat.SuspendLayout();
            this.gbMessage.SuspendLayout();
            this.tsMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFriend
            // 
            this.gbFriend.Controls.Add(this.tvContact);
            this.gbFriend.Location = new System.Drawing.Point(13, 13);
            this.gbFriend.Name = "gbFriend";
            this.gbFriend.Size = new System.Drawing.Size(163, 499);
            this.gbFriend.TabIndex = 0;
            this.gbFriend.TabStop = false;
            this.gbFriend.Text = "联系人";
            // 
            // tvContact
            // 
            this.tvContact.Location = new System.Drawing.Point(6, 21);
            this.tvContact.Margin = new System.Windows.Forms.Padding(2);
            this.tvContact.Name = "tvContact";
            this.tvContact.ShowRootLines = false;
            this.tvContact.Size = new System.Drawing.Size(151, 472);
            this.tvContact.TabIndex = 3;
            // 
            // gbChat
            // 
            this.gbChat.Controls.Add(this.emotionPanel1);
            this.gbChat.Controls.Add(this.rtbChat);
            this.gbChat.Enabled = false;
            this.gbChat.Location = new System.Drawing.Point(182, 13);
            this.gbChat.Name = "gbChat";
            this.gbChat.Size = new System.Drawing.Size(388, 319);
            this.gbChat.TabIndex = 1;
            this.gbChat.TabStop = false;
            this.gbChat.Text = "聊天";
            // 
            // emotionPanel1
            // 
            this.emotionPanel1.Location = new System.Drawing.Point(0, 109);
            this.emotionPanel1.Name = "emotionPanel1";
            this.emotionPanel1.Size = new System.Drawing.Size(300, 210);
            this.emotionPanel1.TabIndex = 2;
            this.emotionPanel1.Visible = false;
            this.emotionPanel1.ItemClickEvent += new Chat.EmotionPanel.ItemClickHandler(emotionPanel1_ItemClickEvent);
            // 
            // rtbChat
            // 
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Location = new System.Drawing.Point(7, 21);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(375, 292);
            this.rtbChat.TabIndex = 1;
            this.rtbChat.Text = "";
            // 
            // gbMessage
            // 
            this.gbMessage.Controls.Add(this.tsMessage);
            this.gbMessage.Controls.Add(this.btnSend);
            this.gbMessage.Controls.Add(this.rtbMessage);
            this.gbMessage.Enabled = false;
            this.gbMessage.Location = new System.Drawing.Point(182, 338);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Size = new System.Drawing.Size(388, 174);
            this.gbMessage.TabIndex = 2;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "消息";
            // 
            // tsMessage
            // 
            this.tsMessage.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEmotion});
            this.tsMessage.Location = new System.Drawing.Point(3, 17);
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.Size = new System.Drawing.Size(382, 25);
            this.tsMessage.TabIndex = 2;
            this.tsMessage.Text = "消息工具栏";
            // 
            // tsbEmotion
            // 
            this.tsbEmotion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEmotion.Image = ((System.Drawing.Image)(resources.GetObject("tsbEmotion.Image")));
            this.tsbEmotion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmotion.Name = "tsbEmotion";
            this.tsbEmotion.Size = new System.Drawing.Size(23, 22);
            this.tsbEmotion.Text = "表情";
            this.tsbEmotion.Click += new System.EventHandler(this.tsbEmotion_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(307, 144);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtbMessage
            // 
            this.rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMessage.Location = new System.Drawing.Point(7, 45);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(375, 91);
            this.rtbMessage.TabIndex = 0;
            this.rtbMessage.Text = "";
            this.rtbMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbMessage_KeyDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 522);
            this.Controls.Add(this.gbMessage);
            this.Controls.Add(this.gbChat);
            this.Controls.Add(this.gbFriend);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "瞎聊客户端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.gbFriend.ResumeLayout(false);
            this.gbChat.ResumeLayout(false);
            this.gbMessage.ResumeLayout(false);
            this.gbMessage.PerformLayout();
            this.tsMessage.ResumeLayout(false);
            this.tsMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFriend;
        private System.Windows.Forms.GroupBox gbChat;
        private System.Windows.Forms.GroupBox gbMessage;
        private System.Windows.Forms.Button btnSend;
        private RichTextBoxEx rtbMessage;
        private System.Windows.Forms.TreeView tvContact;
        private System.Windows.Forms.ToolStrip tsMessage;
        private System.Windows.Forms.ToolStripButton tsbEmotion;
        private RichTextBoxEx rtbChat;
        private Chat.EmotionPanel emotionPanel1;
    }
}

