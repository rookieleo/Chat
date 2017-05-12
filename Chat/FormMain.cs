using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlindChat;
using System.Net;

namespace BlindChat
{
    public partial class FormMain : Form
    {
        private SocketUdpClient m_ComunicationSocket = new SocketUdpClient();

        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.tvContact.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvContact_NodeMouseDoubleClick);
            SocketUdpServer.GetInstance().OnChatEvent += new SocketUdpServer.MessageHandle(this.Receive_Event);
            SocketUdpServer.GetInstance().OnLineEvent += new SocketUdpServer.MessageHandle(this.OnLine_Event);
            SocketUdpServer.GetInstance().DownLineEvent += new SocketUdpServer.MessageHandle(this.DownLine_Event);
            SocketUdpServer.GetInstance().Listen();
            this.m_ComunicationSocket.Broadcast(DatagramType.OnLine);
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!object.Equals(this.m_ComunicationSocket.CurrentContact, null))
            {
                ContactList.SetComunicationState(this.m_ComunicationSocket.CurrentContact.IP, ComunicationState.Waiting);
            }
            this.m_ComunicationSocket.Broadcast(DatagramType.DownLine);
            Application.Exit();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = this.rtbMessage.GetMessage();
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("发送信息不能为空");
                }
                else
                {
                    this.m_ComunicationSocket.Send(message);
                    this.rtbChat.SetMessage(Dns.GetHostName(), DateTime.Now, true, message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void emotionPanel1_ItemClickEvent(string imgKey)
        {
            this.rtbMessage.InsertEmotion(imgKey);
            this.emotionPanel1.Visible = false;
        }
        private void tsbEmotion_Click(object sender, EventArgs e)
        {
            this.emotionPanel1.Visible = !this.emotionPanel1.Visible;
        }
        private void rtbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSend.PerformClick();
            }
        }

        private void tvContact_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!object.Equals(this.m_ComunicationSocket.CurrentContact, null))
            {
                ContactList.SetComunicationState(this.m_ComunicationSocket.CurrentContact.IP, ComunicationState.Waiting);
            }
            this.m_ComunicationSocket.CurrentContact = ContactList.GetContact(e.Node.Name);
            ContactList.SetComunicationState(this.m_ComunicationSocket.CurrentContact.IP, ComunicationState.Talking);

            this.rtbChat.Clear();
            this.rtbChat.SelectionStart = 0;
            this.Text = "正在和" + this.m_ComunicationSocket.CurrentContact.Host + "聊天中";
            this.gbChat.Enabled = true; this.gbMessage.Enabled = true; e.Node.ForeColor = Color.Black;
            LoadUnReadMessage();
        }

        private void OnLine_Event(Contact contact)
        {
            while (!this.IsHandleCreated) ;
            this.tvContact.Invoke((EventHandler)delegate
            {
                TreeNode tNode = new TreeNode(contact.Host);
                tNode.Name = contact.IP;
                this.tvContact.Nodes.Add(tNode);
                ContactList.Add(contact);
            });
        }
        private void DownLine_Event(Contact contact)
        {
            if (string.Equals(Config.LocalIPAddress, contact.IP))
            {
                Application.Exit();
            }
            else
            {
                while (!this.IsHandleCreated) ;
                this.tvContact.Invoke((EventHandler)delegate
                {
                    this.tvContact.Nodes.RemoveAt(ContactList.GetIndex(contact.IP));
                    ContactList.Remove(contact.IP);
                });
            }
        }
        private void Receive_Event(Contact contact)
        {
            //判断 远端的网络端点是否是当前的 打开的窗体
            if (!object.Equals(this.m_ComunicationSocket.CurrentContact, null) && this.m_ComunicationSocket.CurrentContact.Compare(contact.IP))
            {
                while (!this.IsHandleCreated) ;
                this.rtbChat.Invoke((EventHandler)delegate
                {
                    this.rtbChat.SetMessage(contact.Host, DateTime.Now, false, contact.Message);
                });
            }
            else
            {
                while (!this.IsHandleCreated) ;
                this.tvContact.Invoke((EventHandler)delegate
                {
                    foreach (TreeNode tNode in this.tvContact.Nodes)
                    {
                        if (tNode.Name.Equals(contact.IP))
                        {
                            tNode.ForeColor = Color.Red;
                        }
                    }
                });
            }
        }

        private void LoadUnReadMessage()
        {
            Queue<MessageInfo> messageQueque = QueueMessage.GetAndRemove(this.m_ComunicationSocket.CurrentContact);
            if (!object.Equals(messageQueque, null))
            {
                foreach (MessageInfo msgInfo in messageQueque)
                {
                    this.rtbChat.SetMessage(msgInfo.ChatContact.Host, DateTime.Now, false, msgInfo.ChatContact.Message);
                }
            }
        }
    }
}
