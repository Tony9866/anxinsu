using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SignetInternet_BusinessLayer;

public partial class Download : System.Web.UI.Page
{
    /// <summary>
    /// 取得要下载文件的路径
    /// </summary>
    private string m_path;
    public string fileRpath
    {
        get
        {
            m_path = Request["fileRpath"] == null ? "" : Request["fileRpath"];
            return m_path;
        }
        set {
            m_path  = value;
        }
    }

    private string SignetIDs
    {
        get
        {
            return Request["signetIds"] == null ? "" : Request["signetIds"];
        }
    }

    /// <summary>
    /// 取得要下载文件的名称
    /// </summary>

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (!string.IsNullOrEmpty(SignetIDs))
            //{
            //    m_path = AutoSealHelper.GenerateAutoSealFile(SignetIDs);
            //}
            this.DownloadFile();
        }
    }
    public void DownloadFile()
    {

        Response.ClearHeaders();
        Response.Clear();
        Response.Expires = 0;
        Response.Buffer = true;
        Response.AddHeader("Accept-Language", "zh-tw");
        System.IO.FileStream files = new FileStream(m_path, FileMode.Open, FileAccess.Read, FileShare.Read);
        byte[] byteFile = null;
        if (files.Length == 0)
        {
            byteFile = new byte[1];
        }
        else
        {
            byteFile = new byte[files.Length];
        }
        files.Read(byteFile, 0, (int)byteFile.Length);
        files.Close();

        //Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("autoseal.txt", System.Text.Encoding.UTF8));


        Response.AppendHeader("Content-Disposition", "attachment;filename=autoseal.txt");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        Response.ContentType = "application/ms-word";
        Response.BinaryWrite(byteFile);
        Response.End();

    }
}