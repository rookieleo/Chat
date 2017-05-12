using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BlindChat
{
    public enum ComunicationState
    {
        /// <summary>
        /// 交谈中 就是和该用户的窗体打开
        /// </summary>
        Talking,
        /// <summary>
        /// 等待中 和该用户交谈的窗体没有打开
        /// </summary>
        Waiting,
        /// <summary>
        /// 已经下线了
        /// </summary>
        DownLine
    }
    public class Contact
    {
        public string IP { get; set; }
        public string Host { get; set; }
        public string Message { get; set; }
        public ComunicationState State { get; set; }
        public EndPoint RemoteEndPoint { get; set; }

        public Contact() { }

        public Contact(string host, string ip, ComunicationState state, EndPoint endPoint)
        {
            this.Host = host;
            this.IP = ip;
            this.State = state;
            this.RemoteEndPoint = endPoint;
        }

        public bool Compare(string ip)
        {
            return string.Equals(this.IP, ip);
        }
    }
    public class ContactList
    {
        private static List<Contact> CurrentContactList = new List<Contact>();

        public static void SetComunicationState(string ip, ComunicationState state)
        {
            Contact contact = CurrentContactList.Find(x => string.Equals(x.IP, ip));
            if (contact != null)
            {
                contact.State = state;
            }
        }

        public static bool Exists(string ip)
        {
            return CurrentContactList.Exists(x => string.Equals(x.IP, ip));
        }

        public static void Add(Contact contact)
        {
            if (!Exists(contact.IP))
            {
                CurrentContactList.Add(contact);
            }
        }

        public static int GetIndex(string ip)
        {
            return CurrentContactList.FindIndex(x => string.Equals(x.IP, ip));
        }

        public static void Remove(string ip)
        {
            if (Exists(ip))
            {
                CurrentContactList.RemoveAll(x => string.Equals(x.IP, ip));
            }
        }

        public static Contact GetContact(string ip)
        {
            return CurrentContactList.Find(x => string.Equals(x.IP, ip));
        }

        public static Contact GetContactByPoint(EndPoint endPoint)
        {
            return CurrentContactList.Find(x => string.Equals(endPoint.ToString(), x.RemoteEndPoint.ToString()));
        }

        public static void Clear()
        {
            CurrentContactList.Clear();
        }
    }
}
