using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LigerRM.Common.Helper;

using System.IO;
using System.Configuration;

namespace LigerRM.Common.ImageHelper
{
    public class ImageHelper : Basics
    {
        public string FlieUrl
        {
            get { return ConfigurationManager.AppSettings["FlieUrl"]; }
        }
        /// <summary>
        /// Base64二进制流还原文件  
        /// </summary>
        /// <param name="FilePath"></param>  
        /// <param name="StringBase64"></param>  
        public string Base64Decode(string StringBase64)
        {
            try
            {
                string FileName = @"\SysFiles\Image\" + DateTime.Now.ToString("yyyyMMDDHHmmssfff") + ".jpg";
                FileStream fileStream = new FileStream(FlieUrl + FileName, FileMode.Create);
                byte[] buffer = ToImage(StringBase64);
                fileStream.Write(buffer, 0, buffer.Length);
                fileStream.Close();

                return FileName;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        /// <summary>
        /// 将Base64字符串转换为图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private byte[] ToImage(string base64)
        {
            base64 = base64.Replace("base64,", "■");
            string[] Arr = base64.Split('■');
            byte[] bytes = null;
            if (Arr.Length == 2)
            {
                bytes = Convert.FromBase64String(Arr[1]);
            }
            return bytes;
        }
    }
}
