using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigerRM.Common.Payment
{
    public class WeChartParentConfig
    {
        // RSA银通公钥
        public static string YT_PUB_KEY = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCSS/DiwdCf/aZsxxcacDnooGph3d2JOj5GXWi+q3gznZauZjkNP8SKl3J2liP0O6rU/Y/29+IUe+GTMhMOFJuZm1htAtKiu5ekW0GlBMWxf4FPkYlQkPE0FtaoMP3gYfh+OwI+fIRrpW3ySn3mScnc6Z700nU/VYrRkfcSCbSnRwIDAQAB";
        // RSA商户私钥
        public static string TRADER_PRI_KEY = "MIICdQIBADANBgkqhkiG9w0BAQEFAASCAl8wggJbAgEAAoGBALy3Gdg8tnY9tiImwbxdMHPlytHhVqpP5yKqHufXXPS1Hv2WZxSBkqmK4rF05O1vP6gYiwj4XTOSqtWA94RT7a0eY52d+/HF3ilZkqJJ57HnZKwo0AKQ+ijoJ0w6JaVCqvfadwInh2LDvDuNF7Td5PVA4s4Q1uWNxMQEnpvXKNJXAgMBAAECgYAfv+Z3PO+twQAtiru5hywps5WF7hV4nezTJjAA7XjUKszF+VHqX0pff+BX3sTNNZROIaLypWZ40MoxFXuPJdesqKQiI5U6ovuyYdB3vFk0QIr8Zsr8Ns6yiYrLSXF3jbsGiM+i/JHtuwqoO8AKkn3xKhRGRFLxSQ/hamV/xJbTgQJBAN17ZnDqBKl0A8bNEq4//MNWNZZilDuP2soUJ7Pa1S2IqpkuPy9x+i62B1PupWCSnlg+vLA61rPwZMiw/QhzGvcCQQDaIGJ18Tr6jiYwNyczngj2kTREVjx3bnQA4drrIhDJPp8UGStx0Rg50MX5uQzUj/e3D4MVomHguK9sD4+e9cuhAkBACAQG0vFEGEFbQUCMVf16b7sQXjGiwqUrVQZhbfvBrUg8/uzPh7EfvgqCTnVLZTgYJRMiE/CsluxcRSbyQWzjAkAJF8iC+idnQn29DM+Ji1D8VllDcATdRbF4R/IEU0s32HBxOgthl0HXRyi5nEk4ozfEXdUtFbPW1lwZuRxXmA+BAkAdGCwLvjqmmwaivE2GWBvOLj7ouI9Z/ylBtQHhJTTQmCds8OzvZSi7g3Bi0SKUID610AigCBEcy8AiG792pEMT";
        // MD5 KEY
        public static string MD5_KEY = "201708071000001543TaiShi_20170512";
        // 接收异步通知地址
        public static string NOTIFY_URL = "http://localhost:54000/notify_url.aspx";  //请变更yourdomain为你的域名（及端口）
        // 支付结束后返回地址
        public static string URL_RETURN = "http://localhost:54000/UnionPay/urlReturn.aspx";    //请变更为您的返回地址
        // 商户编号
        public static string OID_PARTNER = "201705091001717481";     //请变更为您的商户号
        // 签名方式 RSA或MD5
        public static string SIGN_TYPE = "MD5";    					//请选择签名方式
        // 接口版本号，固定1.0
        public static string VERSION = "1.0";
        // 业务类型，连连支付根据商户业务为商户开设的业务类型； （101001：虚拟商品销售、109001：实物商品销售）
        public static string BUSI_PARTNER = "101001";   //请选择业务类型
    }
}
