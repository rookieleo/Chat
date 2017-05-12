using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace BlindChat
{
    public class RichTextBoxEx : RichTextBox
    {
        private Dictionary<int, string> m_EmotionList = new Dictionary<int, string>();

        public RichTextBoxEx()
        {
            this.KeyUp += new KeyEventHandler(RichTextBoxEx_KeyUp);
        }

        private void RichTextBoxEx_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.Text = "";
                    break;
                case Keys.Back:
                    this.m_EmotionList.Remove(this.SelectionStart);
                    break;
            }
        }

        public void InsertEmotion(string imgKey)
        {
            Clipboard.SetDataObject(Image.FromFile(Application.StartupPath + "\\Emotion\\" + imgKey));
            this.Paste(DataFormats.GetFormat(DataFormats.Bitmap));
            this.m_EmotionList.Add(this.SelectionStart + this.m_EmotionList.Count * (imgKey.Length + 10), "/Emotion:" + imgKey + "/");
        }

        public string GetMessage()
        {
            int count = 0;
            string before = string.Empty, after = string.Empty, msg = this.Text;

            foreach (var emotion in this.m_EmotionList)
            {
                before = msg.Substring(0, emotion.Key - count - 1);
                after = msg.Substring(emotion.Key - count);
                msg = before + emotion.Value + after;
                count++;
            }
            this.Clear(); this.m_EmotionList.Clear();
            return msg;
        }

        public void SetMessage(string UserName, DateTime SendTime, bool Self, string Msg)
        {
            this.SelectionAlignment = (Self) ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            this.AppendText(UserName + "：" + SendTime.ToString("yyyy-MM-dd HH:mm:ss"));
            this.AppendText(Environment.NewLine);
            this.SelectionStart += this.TextLength;

            Regex reg = new Regex(@"/Emotion:\S*/");
            do
            {
                Match emotionMatch = Regex.Match(Msg, @"/Emotion:\S{27}/");

                if (emotionMatch.Success)
                {
                    this.AppendText(Msg.Substring(0, emotionMatch.Index));

                    string s1 = emotionMatch.Value.Remove(emotionMatch.Value.Length - 1).Substring(9);
                    string s2 = Application.StartupPath + "\\Emotion\\" + s1;
                    Image img = Image.FromFile(s2);

                    Clipboard.SetDataObject(img);
                    this.SelectionStart += emotionMatch.Index;
                    this.Paste(DataFormats.GetFormat(DataFormats.Bitmap));

                    Msg = Msg.Substring(emotionMatch.Index + emotionMatch.Value.Length);
                }
            } while (reg.IsMatch(Msg));

            this.AppendText(Msg);
            this.AppendText(Environment.NewLine);
            this.AppendText(Environment.NewLine);
        }
    }
}
