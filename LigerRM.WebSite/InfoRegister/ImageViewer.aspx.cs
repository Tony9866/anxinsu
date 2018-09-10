using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using System.Data;
using System.IO;
using System.Drawing;

public partial class ImageViewer : System.Web.UI.Page
{
    public string files = string.Empty;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            Dictionary<long, string> viewFiles = new Dictionary<long, string>();
            string id = Request.QueryString["id"];
            string signetId = Request["signetId"];


            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(signetId))
            {
                SignetFileHelper helper = new SignetFileHelper();
                DataTable dt = helper.SignetFileSelectBySignetId(signetId);


                foreach (DataRow row in dt.Rows)
                {
                    string fileName = Server.MapPath("~" + "\\uploadedfiles\\");
                    byte[] bytes = (byte[])row["sf_file_data"];
                    string file = DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
                    fileName = fileName + signetId + "_" + row["id"].ToString() + "_" + file;
                    FileStream fs;
                    FileInfo fi = new System.IO.FileInfo(fileName);
                    fs = fi.OpenWrite();
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                    viewFiles.Add(long.Parse(row["id"].ToString()), signetId + "_" + row["id"].ToString() + "_" + file);
                }
            }

            KeyValuePair<long, string> last = viewFiles.Last(i => i.Key > 0);
            KeyValuePair<long, string> first = viewFiles.First(i => i.Key > 0);
            if (long.Parse(id) == first.Key)
            {
                btnLeft.Enabled = false;
                btnLeft.ImageUrl = "~/images/ldisable.jpg";
                btnRight.Enabled = true;
                btnRight.ImageUrl = "~/images/right.jpg";
            }
            if (long.Parse(id) == last.Key)
            {
                btnRight.Enabled = false;
                btnRight.ImageUrl = "~/images/rdisable.png";
                btnLeft.Enabled = true;
                btnLeft.ImageUrl = "~/images/left.jpg";
            }

            if (viewFiles.Count == 1)
            {
                btnRight.Enabled = false;
                btnRight.ImageUrl = "~/images/rdisable.png";
                btnLeft.Enabled = false;
                btnLeft.ImageUrl = "~/images/ldisable.jpg";
            }

            showImage(viewFiles[long.Parse(id)]);
            ViewState["currentId"] = long.Parse(id);
            ViewState["files"] = viewFiles;
        }
    }
    protected void btnRight_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<long, string> viewFiles = new Dictionary<long, string>();
        viewFiles = ViewState["files"] as Dictionary<long, string>;
        KeyValuePair<long,string> last = viewFiles.Last(i =>i.Key>0);
        if (last.Key > long.Parse(ViewState["currentId"].ToString()))
        {
            KeyValuePair<long, string> imgUrl = viewFiles.First(i => i.Key > long.Parse(ViewState["currentId"].ToString()));

            showImage(imgUrl.Value);
            ViewState["currentId"] = imgUrl.Key;
            if (last.Key == imgUrl.Key)
            {
                btnRight.Enabled = false;
                btnRight.ImageUrl = "~/images/rdisable.png";
                btnLeft.Enabled = true;
                btnLeft.ImageUrl = "~/images/left.jpg";
            }
            else
            {
                btnLeft.Enabled = true;
                btnLeft.ImageUrl = "~/images/left.jpg";
                btnRight.Enabled = true;
                btnRight.ImageUrl = "~/images/right.jpg";
            }

        }
        else
        {
            btnRight.Enabled = false;
            btnRight.ImageUrl = "~/images/rdisable.png";
            btnLeft.Enabled = true;
            btnLeft.ImageUrl = "~/images/left.jpg";
        }

        //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "viewer", "$(function() {var i = document.getElementById('imgPic'); $zoom = $('#zoom01').gzoom({sW: i.width,sH: i.height,lW: i.width * 2,lH: i.height * 2,lighbox : true,zoomIcon: '../images/gtk-zoom-in.png'});", true);
    }

    protected void showImage(string url)
    {
        Bitmap bmp = new Bitmap(Server.MapPath("~")+"\\uploadedfiles\\"+url);
        int width, height;
        double rate = 0;
        rate = double.Parse(bmp.Width.ToString()) / double.Parse(bmp.Height.ToString());
        width = bmp.Width;
        height = bmp.Height;
        if (rate >= 1)
        {
            if (width >= 480)
            {
                width = 480;
                height = (int)(480 / rate);
            }
        }
        else
        {
            if (height >= 360)
            {
                height = 360;
                width = (int)(360 * rate);
            }
        }

        imgPic.ImageUrl = "~/uploadedfiles/" + url;
        imgPic.Width = width;
        imgPic.Height = height;
    }
    protected void btnLeft_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<long, string> viewFiles = new Dictionary<long, string>();
        viewFiles = ViewState["files"] as Dictionary<long, string>;
        KeyValuePair<long, string> first = viewFiles.First(i => i.Key > 0);
        if (first.Key < long.Parse(ViewState["currentId"].ToString()))
        {
            KeyValuePair<long, string> imgUrl = viewFiles.Last(i => i.Key < long.Parse(ViewState["currentId"].ToString()));

            showImage(imgUrl.Value);
            ViewState["currentId"] = imgUrl.Key;
            if (first.Key == imgUrl.Key)
            {
                btnLeft.Enabled = false;
                btnLeft.ImageUrl = "~/images/ldisable.jpg";
                btnRight.Enabled = true;
                btnRight.ImageUrl = "~/images/right.jpg";
            }
            else
            {
                btnLeft.Enabled = true;
                btnLeft.ImageUrl = "~/images/left.jpg";
                btnRight.Enabled = true;
                btnRight.ImageUrl = "~/images/right.jpg";
            }

        }
        else
        {
            btnLeft.Enabled = false;
            btnLeft.ImageUrl = "~/images/ldisable.jpg";
            btnRight.Enabled = true;
            btnRight.ImageUrl = "~/images/right.jpg";
        }
    }
    protected void btRotateRight_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<long, string> viewFiles = new Dictionary<long, string>();
        viewFiles = ViewState["files"] as Dictionary<long, string>;
        
        long currentId = long.Parse(ViewState["currentId"].ToString());
        KeyValuePair<long, string> target = viewFiles.Single(i => i.Key == currentId);
        string url = Server.MapPath("~") + "\\uploadedfiles\\";
        if (!string.IsNullOrEmpty(target.Value))
        {
            Bitmap bmp = new Bitmap(url+target.Value);
            Bitmap rotate = KiRotate90(bmp, "R");
            string file = target.Key.ToString()+DateTime.Now.ToString("hhmmss")+".bmp";
            rotate.Save(Server.MapPath("~") + "\\uploadedfiles\\" + file);
            bmp.Dispose();
            rotate.Dispose();
            showImage(file);
            viewFiles[target.Key] = file;
            ViewState["files"] = viewFiles;
        }

    }

    public static Bitmap KiRotate90(Bitmap img, string direction)
    {
        try
        {
            switch(direction)
            {
                case "R":
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case "L":
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }
            return img;
        }
        catch
        {
            return null;
        }
    }
    protected void btRotateLeft_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<long, string> viewFiles = new Dictionary<long, string>();
        viewFiles = ViewState["files"] as Dictionary<long, string>;

        long currentId = long.Parse(ViewState["currentId"].ToString());
        KeyValuePair<long, string> target = viewFiles.Single(i => i.Key == currentId);
        string url = Server.MapPath("~") + "\\uploadedfiles\\";
        if (!string.IsNullOrEmpty(target.Value))
        {
            Bitmap bmp = new Bitmap(url + target.Value);
            Bitmap rotate = KiRotate90(bmp, "L");
            string file = target.Key.ToString() + DateTime.Now.ToString("hhmmss") + ".bmp";
            rotate.Save(Server.MapPath("~") + "\\uploadedfiles\\" + file);
            bmp.Dispose();
            rotate.Dispose();
            showImage(file);
            viewFiles[target.Key] = file;
            ViewState["files"] = viewFiles;
        }
    }
}