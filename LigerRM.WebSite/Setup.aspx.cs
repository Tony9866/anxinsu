using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Setup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
            AppSettingsSection app = config.AppSettings;
            ConnectionStringsSection conn = config.ConnectionStrings;

            DataTable dtApp = new DataTable();
            dtApp.Columns.Add("AppName");
            dtApp.Columns.Add("AppValue");
            foreach (KeyValueConfigurationElement key in app.Settings)
            {
                DataRow row = dtApp.NewRow();
                row["AppName"] = key.Key;
                row["AppValue"] = key.Value;
                dtApp.Rows.Add(row);
            }

            dlAppSettings.DataSource = dtApp;
            dlAppSettings.DataBind();

            DataTable dtConn = new DataTable();
            dtConn.Columns.Add("AppName");
            dtConn.Columns.Add("AppValue");
            for(int i=0;i<conn.ConnectionStrings.Count;i++)
            {
                DataRow row = dtConn.NewRow();
                if (!conn.ConnectionStrings[i].Name.Equals("LocalSqlServer"))
                {
                    row["AppName"] = conn.ConnectionStrings[i].Name;
                    row["AppValue"] = conn.ConnectionStrings[i].ConnectionString;
                    dtConn.Rows.Add(row);
                }
            }

            dlConnSettings.DataSource = dtConn;
            dlConnSettings.DataBind();
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (btnNext.Text=="完成")
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
            AppSettingsSection app = config.AppSettings;
            ConnectionStringsSection conn = config.ConnectionStrings;
            foreach (DataListItem item in dlAppSettings.Items)
            {
                Label lblName = item.FindControl("lblName") as Label;
                TextBox txtValue = item.FindControl("txtValue") as TextBox;
                if (app.Settings.AllKeys.Contains(lblName.Text))
                {
                    app.Settings[lblName.Text].Value = txtValue.Text;
                    
                }
            }

            foreach (DataListItem item in dlConnSettings.Items)
            {
                Label lblName = item.FindControl("lblName") as Label;
                TextBox txtValue = item.FindControl("txtValue") as TextBox;
                    conn.ConnectionStrings[lblName.Text].ConnectionString = txtValue.Text;

            }
            config.Save(ConfigurationSaveMode.Modified);
            ScriptManager.RegisterStartupScript(btnNext, btnNext.GetType(), "success", "alert('设置保存成功！');", true);
        }
        else
        {
            pnApp.Visible = true;
            pnConn.Visible = false;
            btnNext.Text = "完成";
            btnPrevious.Visible = true;
        }

        
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        pnApp.Visible = false;
        pnConn.Visible = true;
        btnNext.Text = "下一步";
        btnPrevious.Visible = false;
    }

    protected void btnConn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        TextBox txtValue = btn.Parent.FindControl("txtValue") as TextBox;

        using (SqlConnection conn = new SqlConnection(txtValue.Text))
        {
            try
            {
                conn.Open();
                ScriptManager.RegisterStartupScript(btn, btn.GetType(), "success", "alert('数据库测试成功！');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(btn, btn.GetType(), "success", "alert('数据库测试失败！');", true);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}