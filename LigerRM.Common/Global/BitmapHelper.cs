using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace LigerRM.Common.Global
{
    public class BitmapHelper
    {
        public static Bitmap KiRotate(Bitmap bmp, float angle, Color bkColor)
        {
            int w = bmp.Width + 2;
            int h = bmp.Height + 2;

            PixelFormat pf;

            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = bmp.PixelFormat;
            }

            Bitmap tmp = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tmp);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);

            Bitmap dst = new Bitmap((int)rct.Width, (int)rct.Height, pf);
            g = Graphics.FromImage(dst);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tmp, 0, 0);
            g.Dispose();

            tmp.Dispose();

            return dst;
        }

        /// <summary>
        /// 2014.6.12 剪去图片空余白边
        /// </summary>
        /// <param name="FilePath">源文件</param>
        /// <param name="WhiteBarRate">保留空白边比例</param>
        public static void CutImageWhitePart(string FilePath,string targetPath, int WhiteBarRate)
        {
            Bitmap bmp = new Bitmap(FilePath);
            int top = 0, left = 0;
            int right = bmp.Width, bottom = bmp.Height;
            Color white = Color.White;
            //寻找最上面的标线,从左(0)到右，从上(0)到下
            for (int i = 0; i < bmp.Height; i++)//行
            {
                bool find = false;
                for (int j = 0; j < bmp.Width; j++)//列
                {
                    Color c = bmp.GetPixel(j, i);
                    if (IsWhite(c))
                    {
                        top = i;
                        find = true;
                        break;
                    }
                }
                if (find) break;
            }
            //寻找最左边的标线，从上（top位）到下，从左到右
            for (int i = 0; i < bmp.Width; i++)//列
            {
                bool find = false;
                for (int j = top; j < bmp.Height; j++)//行
                {
                    Color c = bmp.GetPixel(i, j);
                    if (IsWhite(c))
                    {
                        left = i;
                        find = true;
                        break;
                    }
                }
                if (find) break; ;
            }
            ////寻找最下边标线，从下到上，从左到右
            for (int i = bmp.Height - 1; i >= 0; i--)//行
            {
                bool find = false;
                for (int j = left; j < bmp.Width; j++)//列
                {
                    Color c = bmp.GetPixel(j, i);
                    if (IsWhite(c))
                    {
                        bottom = i;
                        find = true;
                        break;
                    }
                }
                if (find) break;
            }
            //寻找最右边的标线，从上到下，从右往左
            for (int i = bmp.Width - 1; i >= 0; i--)//列
            {
                bool find = false;
                for (int j = 0; j <= bottom; j++)//行
                {
                    Color c = bmp.GetPixel(i, j);
                    if (IsWhite(c))
                    {
                        right = i;
                        find = true;
                        break;
                    }
                }
                if (find) break;
            }
            int iWidth = right - left;
            int iHeight = bottom - left;
            int blockWidth = Convert.ToInt32(iWidth * WhiteBarRate / 100);
            bmp = Cut(bmp, left - blockWidth, top - blockWidth, right - left + 2 * blockWidth, bottom - top + 2 * blockWidth);
            if (bmp != null)
            {
                bmp.Save(targetPath, ImageFormat.Bmp);
            }
        }


        /// <summary>
        /// 2014.6.13 来源于网络的一个函数
        /// </summary>
        /// <param name="b"></param>
        /// <param name="StartX"></param>
        /// <param name="StartY"></param>
        /// <param name="iWidth"></param>
        /// <param name="iHeight"></param>
        /// <returns></returns>
        public static Bitmap Cut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                return null;
            }
            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 2014.6.12 判断白色与否，非纯白色
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsWhite(Color c)
        {
            if (c.R < 245 || c.G < 245 || c.B < 245)
                return true;
            else return false;
        }
    }
}
