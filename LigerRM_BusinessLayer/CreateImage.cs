using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Web;
using System.Net;
using System.Web.UI.HtmlControls;
using ThoughtWorks.QRCode.Codec;


namespace SignetInternet_BusinessLayer
{
/// <summary>
/// ��֤��ģ��
/// </summary>
    public class CreateImage
    {
        public void DrawImage()
        {
     
            CreateImage img=new CreateImage();
            HttpContext.Current.Session.Timeout = 10;
            HttpContext.Current.Session["CheckCode"]=img.RndNum(4);
            img.CreateImages(HttpContext.Current.Session["CheckCode"].ToString());
        }

        /// <summary>
            /// ������֤ͼƬ
            /// </summary>
            /// <param name="checkCode">��֤�ַ�</param>
        private void CreateImages(string checkCode)
            {
                int iwidth = (int)(checkCode.Length * 13);
                System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 23);
                Graphics g = Graphics.FromImage(image);
                g.Clear(Color.White);
                //������ɫ
                Color[] c = {Color.Black,Color.Red,Color.DarkBlue,Color.Green,Color.Orange,Color.Brown,Color.DarkCyan,Color.Purple};
                //�������� 
                string[] font = {"Verdana","Microsoft Sans Serif","Comic Sans MS","Arial","����"};
                Random rand = new Random();
                //���������
                for(int i=0;i<50;i++)
                {
                    int x = rand.Next(image.Width);
                    int y = rand.Next(image.Height);
                    g.DrawRectangle(new Pen(Color.LightGray, 0),x,y,1,1);
                }

                //�����ͬ�������ɫ����֤���ַ�
                for(int i=0;i<checkCode.Length;i++)
                {
                    int cindex = rand.Next(7);
                    int findex = rand.Next(5);

                    Font f = new System.Drawing.Font(font[findex], 10, System.Drawing.FontStyle.Bold);
                    Brush b = new System.Drawing.SolidBrush(c[cindex]);
                    int ii=4;
                    if((i+1)%2==0)
                    {
                        ii=2;
                    }
                    g.DrawString(checkCode.Substring(i,1), f, b, 3+(i*12), ii);
                }
                //��һ���߿�
                g.DrawRectangle(new Pen(Color.Black,0),0,0,image.Width-1,image.Height-1);

                //����������
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
                HttpContext.Current.Response.ClearContent();
                //Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Jpeg";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                g.Dispose();
                image.Dispose();
            }

        /// <summary>
            /// �����������ĸ
            /// </summary>
            /// <param name="VcodeNum">������ĸ�ĸ���</param>
            /// <returns>string</returns>
        private string RndNum(int VcodeNum) 
            {
                string Vchar = "0,1,2,3,4,5,6,7,8,9" ;
                string[] VcArray = Vchar.Split(',') ;
                string VNum = "" ; //�����ַ����̣ܶ��Ͳ���StringBuilder��
                int temp = -1 ; //��¼�ϴ������ֵ������������������һ���������

                //����һ���򵥵��㷨�Ա�֤����������Ĳ�ͬ
                Random rand =new Random(2);
                for ( int i = 1 ; i < VcodeNum+1 ; i++ ) 
                { 
                    if ( temp != -1) 
                    {
                        rand =new Random(i*temp*unchecked((int)DateTime.Now.Ticks));
                    } 
                    int t = rand.Next(VcArray.Length ) ;
                    if (temp != -1 && temp == t) 
                    {
                        return RndNum( VcodeNum );
                    }
                    temp = t ;
                    VNum += VcArray[t];
                }
                return VNum ;
            }

        public string CreateQR(string nr)
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
                     return imgPath;
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
