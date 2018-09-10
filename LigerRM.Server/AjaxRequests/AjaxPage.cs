using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LigerRM.Common;
using System.Configuration;

namespace LigerRM.Server.AjaxRequests
{
    public class AjaxPage
    {
        public static AjaxResult GetEncryptString(string sourceStr)
        { 
            var encryptData = LigerRM.Common.Global.Encryp.DESEncrypt(sourceStr);
            AjaxResult ret = AjaxResult.Success();
            ret.Data = encryptData;
            return ret;
        }

        public static AjaxResult GetUploadFileUrl(string version)
        {
            var urlData = "";
            if (version.Equals("1"))
                urlData = ConfigurationManager.AppSettings["FileUploadUrl"];
            if (version.Equals("2"))
                urlData = ConfigurationManager.AppSettings["FileUploadUrl2"];
            AjaxResult ret = AjaxResult.Success();
            ret.Data = urlData;
            return ret;
        }


    }
}
