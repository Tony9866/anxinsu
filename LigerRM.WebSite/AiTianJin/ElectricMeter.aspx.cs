using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LigerRM.Common;
using SignetInternet_BusinessLayer;

public partial class AiTianJin_electricMeter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            System.IO.Stream postData = Request.InputStream;
            //StreamReader sRead = new StreamReader(postData);
            string postContent = Request.Params["json"];
            //sRead.Close();
            Dictionary<string, string> retDic = new Dictionary<string, string>();
            string sql = string.Empty;
            string statucode = "0";
            string reason = "";
            FileStream fs = new FileStream(Server.MapPath("~") + "\\AiTianJin\\Log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + " " + postContent);
            try
            {
                //postContent = "{\"res\":[{\"vipm_sn\":\"020059200\",\"intraday_electricity\":\"5.31\",\"electricity_electricity\":\"43.81\",\"wipm_state\":1,\"current_power\":\"95.50\",\"timeflag\":\"2017-12-11 16:17:11\",\"current_electricity\":\"70.02\"}]}";
                //Response.Write(postContent);
                Dictionary<string, ElectricMeter[]> ret1 = JSONHelper.FromJson<Dictionary<string, ElectricMeter[]>>(postContent);
                //{
                //    “vipm_sn”: "020059200",
                //    “intraday_ electricity”: "5.31",
                //    "electricity_ electricity": "43.81", 
                //    "wipm_state": 1 ,
                //    "current_power": "95.50" ,
                //    "timeflag": "2017-12-11 16:17:11" ,
                //    "current_electricity": "70.02" ,
                //}
                foreach (ElectricMeter b in ret1["res"])
                {
                    sql = "insert into Electric_Meter_Date values ('"+Guid.NewGuid().ToString()+"','" + b.vipm_sn + "','" + b.intraday_electricity + "','" + b.electricity_electricity + "','" + b.wipm_state + "','" + b.current_power + "','" + DateTime.Parse(b.timeflag).ToString() + "','" + b.current_electricity +  "','"+DateTime.Now.ToString()+"')";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
            }
            catch (Exception ex)
            {
                statucode = "201";
                reason = ex.Message;
                sw.WriteLine(DateTime.Now.ToString() + " " + ex.Message);
            }


            ////开始写入
            //sw.WriteLine(DateTime.Now.ToString() + " " + Request.Headers["ResourceId"] + " " + postContent);

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("resutcode", statucode);
            ret.Add("reason", reason);
            Response.Write(JSONHelper.ToJson(ret));
        }
    }
}