using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace BlindChat
{
    /// <summary>
    /// UDP的客户端  主要用户发送数据
    /// </summary>
    public class SocketUdpClient
    {
        public Contact CurrentContact { get; set; }

        private IPEndPoint m_BroadcastPoint = new IPEndPoint(IPAddress.Broadcast, Config.ListenPort);
        private Socket m_BroadcastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private Socket m_ComunicationSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public SocketUdpClient() { }

        public void Broadcast(DatagramType type)
        {
            Datagram dataGram = new Datagram(type);
            this.m_BroadcastSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            this.m_BroadcastSocket.SendTo(dataGram.ToByteStream(), m_BroadcastPoint);
        }

        public void Send(string message)
        {
            Datagram dataGram = new Datagram(message);
            m_ComunicationSocket.SendTo(dataGram.ToByteStream(), this.CurrentContact.RemoteEndPoint);
        }
    }
}
