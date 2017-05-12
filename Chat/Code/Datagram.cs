using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net;

namespace BlindChat
{
    /*****************************************************************
     * 定义广播的数据格式
     * Type=OnLine,FromAdress=xxx,ToAdress=zzz,Message=mmm
     * 类型为上线广播  从xxx主机到zzz主机  信息是mmm       
     * CHAT这个就是消息 可能有各种=,的字符串
     * 这种就直接将CHAT去掉后 后面的都为mmm
    *****************************************************************/

    public enum DatagramType
    {
        /// <summary>
        /// 上线  一应一答
        /// </summary>
        OnLine = 1,
        /// <summary>
        /// 下线 一应
        /// </summary>
        DownLine,
        /// <summary>
        /// 确认收到 一应
        /// </summary>
        /// <summary>
        /// 正常聊天 一应一答
        /// </summary>
        Chat,
        /// <summary>
        /// 给予个人的信息
        /// </summary>
        GiveInfo

    }

    public class Datagram
    {
        public DatagramType Type { get; set; }

        public string FromAddress { get; set; }

        public string ToAddress { get; set; }

        public string Message { get; set; }

        public int Length { get { return this.Message.Length; } }

        public Datagram() { }

        public Datagram(DatagramType dataType)
        {
            this.Type = dataType;
            this.FromAddress = Config.LocalIPAddress;
            this.ToAddress = "";
            this.Message = Dns.GetHostName();
        }

        public Datagram(string msg)
        {
            this.Type = DatagramType.Chat;
            this.FromAddress = Config.LocalIPAddress;
            this.ToAddress = "";
            this.Message = msg;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Type={0},", this.Type.ToString());
            sb.AppendFormat("FromAddress={0},", this.FromAddress.ToString());
            sb.AppendFormat("ToAddress={0},", this.ToAddress.ToString());
            sb.AppendFormat("Message={0}", this.Message.ToString());
            return sb.ToString();
        }

        public byte[] ToByteStream()
        {
            return Encoding.Default.GetBytes(this.ToString());
        }

        public static Datagram Convert(byte[] buf, int length)
        {
            string msg = Encoding.Default.GetString(buf, 0, length);

            Datagram data = new Datagram();

            string msgType = msg.Substring(0, msg.IndexOf(','));
            data.Type = (DatagramType)Enum.Parse(typeof(DatagramType), msgType.Split('=')[1]);
            msg = msg.Remove(0, msgType.Length + 1);

            string fromAddr = msg.Substring(0, msg.IndexOf(','));
            data.FromAddress = fromAddr.Split('=')[1];
            msg = msg.Remove(0, fromAddr.Length + 1);

            string toAddr = msg.Substring(0, msg.IndexOf(','));
            data.ToAddress = toAddr.Split('=')[1];
            msg = msg.Remove(0, toAddr.Length + 1);

            data.Message = msg.Substring(msg.IndexOf('=') + 1);

            return data;
        }
    }
}
