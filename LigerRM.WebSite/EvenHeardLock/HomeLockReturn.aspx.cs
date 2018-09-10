using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.IO;
using System.Data;

public partial class EvenHeardLock_HomeLockReturn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string postContent = Request.Params["parameters"];
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = string.Empty;
            string menu = string.Empty;
            string FiledInfo = string.Empty;
            string statucode = "000";
            string reason = "request success";
            //////////打印
            FileStream fs = new FileStream(Server.MapPath("~") + "\\EvenHeardLock\\HomeLockReturnLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + "接收到参数" + postContent);
            try
            {
                //string postContent = "{\"res\":[{\"ret\":\"existence\",\"msg\":\"网关已存在\",\"devId\":\"e9bfd5fdf6154e688f3aa04269356dc0\",\"type\":\"1\"}]}";
                Dictionary<string, HomeLockReturn[]> retCallBack = JSONHelper.FromJson<Dictionary<string, HomeLockReturn[]>>(postContent);
                foreach (HomeLockReturn b in retCallBack["res"])
                {
                    string devIdFiled = "DeviceID";
                     if (b.type == 1)  //网关返回数据
                    {
                        menu = "网关数据返回";
                    }
                    else if (b.type == 2) //智能锁返回数据
                    {
                        menu = "智能门锁数据返回";
                    }
                    else if (b.type == 3) //pin码返回数据
                    {
                        menu = "PIN码数据返回";
                    }
                    else if (b.type == 4)  //删除网关 
                    {
                        menu = "网关删除数据返回";
                        devIdFiled = "GatewayId";
                    }
                    else if (b.type == 5)  //删除锁
                    {
                        menu = "锁删除数据返回";
                        devIdFiled = "PinInfo";
                    }
                    
                    sql = "select * from Rent_NewLock_Process where " + devIdFiled + "= '"+ b.devId +"'";
                    DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        addAndUpdateFiled(b.devId, b.type, b.ret, devIdFiled);
                        sql = "insert into Rent_Lock_Logs values ('" + Guid.NewGuid().ToString() + "','" + dt.Rows[0]["DeviceID"].ToString() + "','" + menu + "','" + DateTime.Now.ToString() + "','" + b.msg + "')";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                    else
                    {
                        statucode = "201";
                        reason = "暂无锁信息";
                    }
                   
                }
            }
            catch (Exception ex)
            {
                statucode = "201";
                reason = ex.Message;
                //sw.WriteLine(DateTime.Now.ToString() + "异常信息： " + ex.Message);
            }
            sw.WriteLine(DateTime.Now.ToString() + "返回信息：" + reason);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            ret.Add("resutcode", statucode);
            ret.Add("reason", reason);
            Response.Write(JSONHelper.ToJson(ret));
        }

     }

    /// <summary>  
    /// 字段填充 
    /// </summary>  
    /// <param name="menu">字段值</param> 
    /// <param name="type">类型</param> 
    /// <param name="filed">填充数据</param> 
    /// <returns></returns>  
    private void addAndUpdateFiled(string devId, int type, string filed, string devIdFiled)
    {
        string sqlMosaic = string.Empty;
        if (type == 1) //网关返回数据
        {
            sqlMosaic = "IsCreateGateway='" + filed + "', IsDeleteGateway='', IsDeleteLock=''";
        }
        else if (type == 2)  //智能锁返回数据
        {
            sqlMosaic = "IsCreateLock='" + filed + "', IsDeleteLock=''";
        }
        else if(type == 3) //pin码返回数据
        {
            sqlMosaic = "PinInfo='" + filed + "'";
        }
        else if (type == 4) ///删除网关
        {
            sqlMosaic = "IsDeleteGateway='" + filed + "',  PinInfo='',IsCreateLock='', IsDeleteLock='' , IsCreateGateway='', GatewayId='', DevKey=''";
        }
        else if (type == 5) ///删除锁
        {
            sqlMosaic = "IsDeleteLock='" + filed + "', PinInfo='',IsCreateLock=''";
        }
        string sql = "Update Rent_NewLock_Process set " + sqlMosaic + " where " + devIdFiled + "='" + devId + "'";
        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
    }
}