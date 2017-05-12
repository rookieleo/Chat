using System;
using System.Configuration;
using System.Net;

namespace BlindChat
{
    public class Config
    {
        public static string AppName
        {
            get
            {
                return ConfigurationManager.AppSettings["AppName"];
            }
        }

        public static string RootDir
        {
            get
            {
                return ConfigurationManager.AppSettings["RootDir"];
            }
        }

        public static int ListenPort
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["ListenPort"]);
            }
        }

        public static string LocalIPAddress
        {
            get
            {
                string localIP = string.Empty;

                foreach (IPAddress ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (ip.AddressFamily.ToString().Equals("InterNetwork"))
                    {
                        localIP = ip.ToString();
                    }
                }

                return localIP;
            }
        }
    }
}
