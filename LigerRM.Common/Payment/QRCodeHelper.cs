using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;

namespace LigerRM.Common.Payment
{
    public static class QRCodeHelper
    {
        public static string CreateQR(string nr)
        {
            Bitmap bt;
            if (!string.IsNullOrEmpty(nr))
            {
                string filename = Guid.NewGuid().ToString().ToUpper();
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                bt = qrCodeEncoder.Encode(nr, Encoding.UTF8);
                string imgPath = System.Web.HttpContext.Current.Server.MapPath("~/Images/") + filename + ".jpg";
                try
                {
                    bt.Save(imgPath);
                    return filename + ".jpg";
                }
                catch (Exception)
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}
