using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chat
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class EmotionPanel : UserControl
    {
        private int m_PageSize = 0;
        private int m_PageIndex = 1;
        private int m_ImageCount = 0;
        private int m_RowCount = 5;
        private int m_ColumnCount = 9;
        private int m_EachImageSize = 29;
        private int m_EachPageImageCount = 32;
        private string[] m_ImageNameList;
        private string m_ImagePath = Application.StartupPath + @"\Emotion";
        private string m_EmotionPagePath = Application.StartupPath + @"\EmotionPage.html";

        public delegate void ItemClickHandler(string imgKey);
        public event ItemClickHandler ItemClickEvent;

        public EmotionPanel()
        {
            InitializeComponent();
        }

        public void EmotionPanel_Load(object sender, EventArgs e)
        {
            EmotionPanelLoad(1);
        }

        public void EmotionPanelLoad(int pageIndex)
        {
            m_ImageNameList = System.IO.Directory.GetFiles(m_ImagePath);
            m_ImageCount = m_ImageNameList.Length;
            m_PageSize = m_ImageCount % (m_RowCount * m_ColumnCount) == 0 ? m_ImageCount / (m_RowCount * m_ColumnCount) : m_ImageCount / (m_RowCount * m_ColumnCount) + 1;

            m_PageIndex = pageIndex;

            int count = 1;
            string tableContent = "<tr>";
            for (int i = 0; i < m_RowCount * m_ColumnCount; i++)
            {
                if (count <= m_ColumnCount)
                {
                    tableContent += "<td><a href='#' onmouseover='Preview(this)' onclic><img src='" + m_ImageNameList[((m_PageIndex - 1) * m_EachPageImageCount) + i] + "' onclick='ItemClicked(this)'/></a></td>";
                }
                else
                {
                    tableContent += "</tr><tr>";
                    tableContent += "<td><a href='#' onmouseover='Preview(this)'><img src='" + m_ImageNameList[((m_PageIndex - 1) * m_EachPageImageCount) + i] + "' onclick='ItemClicked(this)' /></a></td>";
                    count = 1;
                }
                count++;
            }
            tableContent += "<td></td></tr>";

            string pageContent = System.IO.File.ReadAllText(m_EmotionPagePath).Replace("$TableRow$", tableContent);
            System.IO.File.WriteAllText(System.IO.Path.GetTempPath() + "tmp.html", pageContent);
            this.wbEmotionPage.Navigate(System.IO.Path.GetTempPath() + "tmp.html");
        }

        public void PreviousClicked()
        {
            EmotionPanelLoad((m_PageIndex - 1) == 0 ? 1 : m_PageIndex - 1);

        }

        public void NextClicked()
        {
            EmotionPanelLoad((m_PageIndex + 1) > m_PageSize ? m_PageSize : m_PageIndex + 1);

        }

        public void ItemClicked(string imgKey)
        {
            if (ItemClickEvent != null)
            {
                ItemClickEvent(imgKey);
            }
        }
    }
}
