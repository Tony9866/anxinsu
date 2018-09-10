using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LigerRM.Common
{
    public class LogManager
    {


        private static string logPath = "";
        /// <summary>
        /// 保存日志的文件夹
        /// </summary>
        public static string LogPath
        {
            get
            {
                if (logPath == string.Empty)
                {
                    logPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                return logPath;
            }
            set { logPath = value; }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(string msg)
        {
            WriteLog("", msg);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(string prev,string msg)
        {
            try
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(
                    LogPath + "/log/" + prev +
                    DateTime.Now.ToString("yyyyMMdd") + ".Log"
                    );
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sw.WriteLine(msg);
                sw.Close();
            }
            catch(Exception err)
            {
                    
            }
        }
         
    } 

}
