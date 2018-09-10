using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmTransfer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogManager.WriteLog("Start...");
            TransferHelper helper = new TransferHelper();

            string sql = "select * from T_DataTransfer where ExcuteStatus='0' order by RecordDate asc";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = helper.CreateJsonStr(dt.Rows[i]);
                LogManager.WriteLog(str);
                DataRequestService.DataRequestNewImplService client = new DataRequestService.DataRequestNewImplService();

                string retStr = client.exeIDUByJson(str);
                Dictionary<string, string> ret = JSONHelper.FromJson<Dictionary<string, string>>(retStr);

                if (ret["state"] == "0") //success
                {
                    sql = "update T_DataTransfer set ExcuteStatus='1', ExcuteDate='" + DateTime.Now.ToString() + "' where ID=" + dt.Rows[i]["ID"].ToString();
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
                else
                {
                    sql = "update T_DataTransfer set ExcuteStatus='2', ExcuteDate='" + DateTime.Now.ToString() + "',FailedMsg='" + ret["errMsg"].Replace("'", "") + "' where ID=" + dt.Rows[i]["ID"].ToString();
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
                LogManager.WriteLog(retStr);
            }
            LogManager.WriteLog("End...");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            string sql = "select * from T_DataTransfer where ExcuteStatus='2' order by recorddate desc";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            dgList.DataSource = dt;

        }

        private void timtransfer_Tick(object sender, EventArgs e)
        {
            timtransfer.Enabled = false;

            LogManager.WriteLog("Start...");
            TransferHelper helper = new TransferHelper();

            string sql = "select * from T_DataTransfer where ExcuteStatus='0' order by RecordDate asc";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            progress.Maximum = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                progress.Value = i;

                string retStr = string.Empty;


                string str = helper.CreateJsonStr(dt.Rows[i]);
                if (str.IndexOf("20140501") > 0)
                {
                    LogManager.WriteLog(str);
                    DataRequestService.DataRequestNewImplService client = new DataRequestService.DataRequestNewImplService();

                    retStr = client.exeIDUByJson(str);
                    Dictionary<string, string> ret = JSONHelper.FromJson<Dictionary<string, string>>(retStr);
                    if (ret["state"] == "0") //success
                    {
                        sql = "update T_DataTransfer set ExcuteStatus='1', ExcuteDate='" + DateTime.Now.ToString() + "' where ID=" + dt.Rows[i]["ID"].ToString();
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                    else
                    {
                        sql = "update T_DataTransfer set ExcuteStatus='2', ExcuteDate='" + DateTime.Now.ToString() + "',FailedMsg='" + ret["errMsg"].Replace("'", "") + "' where ID=" + dt.Rows[i]["ID"].ToString();
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                }
                else
                {
                    sql = "update T_DataTransfer set ExcuteStatus='2', ExcuteDate='" + DateTime.Now.ToString() + "',FailedMsg='" + str + "' where ID=" + dt.Rows[i]["ID"].ToString();
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
                LogManager.WriteLog(retStr);
            }
            LogManager.WriteLog("End...");
            progress.Value = 0;
            timtransfer.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
