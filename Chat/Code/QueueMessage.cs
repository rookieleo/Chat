using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BlindChat
{
    public class MessageInfo
    {
        public Contact ChatContact { get; set; }
        public DateTime ReceiveTime { get; set; }

        public MessageInfo() { }
        public MessageInfo(Contact chatContact, DateTime receiveTime)
        {
            this.ChatContact = chatContact;
            this.ReceiveTime = receiveTime;
        }
    }
    /// <summary>
    /// 将未收到的信息放到静态队列中
    /// </summary>
    public class QueueMessage
    {
        private static IDictionary<Contact, Queue<MessageInfo>> MessageList = new Dictionary<Contact, Queue<MessageInfo>>();

        public static void Add(MessageInfo messageInfo)
        {
            if (MessageList.Keys.Contains(messageInfo.ChatContact))
            {
                //将信息加入原来的队列
                MessageList[messageInfo.ChatContact].Enqueue(messageInfo);
            }
            else
            {
                //新建一个键  并将信息入队
                Queue<MessageInfo> queue = new Queue<MessageInfo>();
                queue.Enqueue(messageInfo);
                MessageList.Add(messageInfo.ChatContact, queue);
            }
        }

        public static Queue<MessageInfo> GetAndRemove(Contact chatContact)
        {
            Queue<MessageInfo> queue = null;

            if (MessageList.Keys.Contains(chatContact))
            {
                //取出并移除字典
                queue = MessageList[chatContact];
                MessageList.Remove(chatContact);
            }

            return queue;
        }
    }
}
