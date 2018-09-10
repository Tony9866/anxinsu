

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        void exportexcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "utf-8";
            Response.AppendHeader("Content-Disposition", "attachment;filename=Export.xls");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            
            Response.ContentType = "application/ms-excel";
            this.EnableViewState = false;
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            Response.Write("<style type='text/css'>tr{text-align:left;border:1px solid gray;vnd.ms-excel.numberformat:@}</style>"); //添加样式和Excel输出格式
            oHtmlTextWriter.WriteLine(hf.Value);  
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

        void exportword()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "gb2312";
            Response.AppendHeader("Content-Disposition", "attachment;filename=tmp.doc");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");

            Response.ContentType = "application/ms-word";
            this.EnableViewState = false;
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            oHtmlTextWriter.WriteLine(hf.Value);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            exportexcel();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            exportword();
        }

    }
