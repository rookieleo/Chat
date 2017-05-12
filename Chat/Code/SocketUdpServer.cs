using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BlindChat
{
    /// <summary>
    /// udp 服务器  主要接收和返回自己的主机信息
    /// </summary>
    public class SocketUdpServer : IDisposable
    {
        #region 单例模式
        private static SocketUdpServer socketudpserver = new SocketUdpServer();
        public static SocketUdpServer GetInstance() { return socketudpserver; }
        #endregion

        private byte[] m_Buffer = new byte[1024];

        private bool IsDispose = false;
        private EndPoint m_ListenPoint = new IPEndPoint(IPAddress.Any, Config.ListenPort);
        private Socket m_ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public delegate void MessageHandle(Contact contact);
        public event MessageHandle OnLineEvent;
        public event MessageHandle DownLineEvent;
        public event MessageHandle OnChatEvent;

        private SocketUdpServer()
        {
            //监听全局广播
            this.m_ListenSocket.Bind(m_ListenPoint);
        }

        public void Listen()
        {
            //会收到所有人的消息
            this.m_ListenSocket.BeginReceiveFrom(m_Buffer, 0, m_Buffer.Length, SocketFlags.None, ref m_ListenPoint, new AsyncCallback(Recevie), null);
        }

        private void Recevie(IAsyncResult result)
        {
            int length = -1;
            try
            {
                length = this.m_ListenSocket.EndReceiveFrom(result, ref m_ListenPoint);
                this.AnalysisData(Datagram.Convert(m_Buffer, length));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (!IsDispose)
                {
                    this.m_ListenSocket.BeginReceiveFrom(m_Buffer, 0, m_Buffer.Length, SocketFlags.None, ref m_ListenPoint, new AsyncCallback(Recevie), result);
                }
            }
        }

        private void AnalysisData(Datagram data)
        {
            Contact contact = new Contact(data.Message, data.FromAddress, ComunicationState.Waiting, new IPEndPoint(IPAddress.Parse(data.FromAddress), Config.ListenPort));
            //if (!contact.Compare(Config.LocalIPAddress))
            //{
            switch (data.Type)
            {
                case DatagramType.OnLine:
                    this.OnLineEvent(contact);
                    Datagram sendDataGram = new Datagram(DatagramType.GiveInfo);
                    this.m_ListenSocket.SendTo(Encoding.Default.GetBytes(sendDataGram.ToString()), new IPEndPoint(IPAddress.Parse(data.FromAddress), Config.ListenPort));
                    break;
                case DatagramType.GiveInfo:
                    if (!contact.Compare(Config.LocalIPAddress))
                    {
                        this.OnLineEvent(contact);
                    }
                    break;
                case DatagramType.DownLine:
                    this.DownLineEvent(contact);
                    break;
                case DatagramType.Chat:
                    Contact chatContact = ContactList.GetContact(data.FromAddress);
                    if (!object.Equals(chatContact, null))
                    {
                        if (chatContact.State == ComunicationState.Talking)
                        {
                            chatContact.Message = data.Message;
                            this.OnChatEvent(chatContact);
                        }
                        else
                        {
                            chatContact.Message = data.Message;
                            MessageInfo messageInfo = new MessageInfo(chatContact, DateTime.Now);
                            QueueMessage.Add(messageInfo);
                            this.OnChatEvent(chatContact);
                        }
                    }
                    break;
            }
            //}
        }

        #region 析构和释放
        ~SocketUdpServer()
        {
            this.m_ListenSocket.Shutdown(SocketShutdown.Both);
            this.m_ListenSocket.Close();
            IsDispose = true;
        }
        public void Dispose()
        {
            this.m_ListenSocket.Shutdown(SocketShutdown.Both);
            this.m_ListenSocket.Close();
            IsDispose = true;
        }
        #endregion
    }
}
