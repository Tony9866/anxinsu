using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using LigerRM.Common;
using LigerRM_BusinessLayer;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using System.Net;
using System.Xml;
using System.Text;
using System.IO;

public partial class AiTianJin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //热门房源
        //RentInfoHelper helper = new RentInfoHelper();
        //Response.Write(helper.GetRentsByCoordinatePopular("39.080037", "117.256013", "500000"));

        //获取图片
        //var retDate = new Hashtable();
        //retDate.Add("RentNO", "1515144983327");
        //RentImageHelper helper = new RentImageHelper();
        //string count = string.Empty;
        //List<Hashtable> images = helper.GetRentImages("1515144983327", out count);
        //retDate.Add("count", count);
        //for (int i = 0; i < images.Count; i++)
        //{
        //    retDate.Add("ImageId" + i, images[i]["ImageId"].ToString());
        //    retDate.Add("Image" + i, images[i]["ImagePath"].ToString());
        //}
        //Response.Write(JSONHelper.ToJson(retDate));

        //获取房源是否绑定锁
        //RentInfoHelper helper = new RentInfoHelper();
        //if (helper.IsExistsRentNoBindLock("151071493994"))
        //    Response.Write(1);
        //else
        //    Response.Write(2);

        //获取房源
        //Dictionary<string, string> ret = new Dictionary<string, string>();

        //try
        //{
        //    RentInfoHelper helper = new RentInfoHelper();
        //    string aa = helper.GetJSONInfo("select * from v_RentDetail_view where RentNO='" + "1510714939946" + "'  and isObsoleted = 0");
        //    ret.Add("ret", "0");
        //    ret.Add("msg", aa);
        //}
        //catch (Exception ex)
        //{
        //    ret.Add("ret", "1");
        //    ret.Add("msg", ex.Message);
        //}
        //Response.Write(JSONHelper.ToJson(ret));


        //获取评价
        //string sqlEvaluation = "SELECT top 10 EvaluateObject, sum(count)/count(*) as count FROM (SELECT EvaluateObject, (EvaluateItem0+EvaluateItem1+EvaluateItem2)/3 as count FROM Rent_Evaluate WHERE EvaluateType = 1) as a GROUP BY a.EvaluateObject ORDER BY count DESC";
        //DataSet dataEvaluation = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlEvaluation));
        //int i = 0;
        //i = dataEvaluation.Tables[0].Rows.Count;
        //string[] arrayObject = new string[i];
        //var arrayKayObject = new Hashtable();
        //i = 0;
        //foreach (DataRow row in dataEvaluation.Tables[0].Rows)
        //{
        //    arrayObject[i] = row["EvaluateObject"].ToString();
        //    var name = row["EvaluateObject"].ToString();
        //    var value = row["count"].ToString();
        //    i++;
        //    arrayKayObject[name] = value;
        //}
        //if (arrayKayObject.Contains("650"))
        //{
        //    Response.Write(arrayKayObject["650"]);
        //}
        //else
        //{
        //    Response.Write("2");
        //}
        //Response.Write(string.Join(",", arrayObject));
        //string sql = "select rid,rentno,ROwner,ROwnerTel,RIDCard,RAddress,RDName,RRName,RRentTypeDesc,RLocationDescription,RRentType,Latitude,Longitude,RentNumber as Status,rFloor,rtotalfloor,rrentarea,rroomtypedesc, rdirectiondesc, RPropertyDesc from v_RentDetail_view where IsObsoleted = 0 and rid in(" + string.Join(",", arrayObject) + ") order by RCreatedDate desc";
        //DataSet ds = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

        //删除房屋
        //try
        //{
        //    string str = "   6304179825";
        //    RentInfoHelper helper = new RentInfoHelper();
        //    helper.GetJSONInfo("update Rent_Rent set isObsoleted = 1 where RentNO='" + str.Replace(" ", "") + "'");
        //    Response.Write("true");
        //}
        //catch (Exception ex)
        //{
        //    Response.Write("false");
        //}

        //得到房屋详情
        //RentInfoHelper helper = new RentInfoHelper();
        //Response.Write(helper.GetJSONInfo("select * from v_RentDetail_view where RIDCard='" + 370881198411094833 + "'  and isObsoleted = 0"));

        //修改房屋信息
        //UpdateRentInfo(
        //    "1515406909398", 
        //    "",
        //    "", 
        //    "9", 
        //    "120004056", 
        //    "天津市河西区天塔街环湖中路环湖南里11号楼11门1010",
        //    "1010",
        //    "11",
        //    "01",
        //    "01",
        //    "01",
        //    "02",
        //    "10",
        //    "11",
        //    "11",
        //    1,
        //    "fagnchanxingzhi",
        //    "王明国",
        //    "13821872153",
        //    "370881198411094833",
        //    "100",
        //    "120004",
        //    "13821872153",
        //    "02",
        //    "02");


        //搜索房屋接口
        //Response.Write(GetHousesByCondition(
        //    1000,
        //    1,
        //    "02",
        //    "02",
        //    "",
        //    "0",
        //    "1",
        //    "2018-01-09 13:14",
        //    "2018-02-09 13:14"
        //  ));

        //退房
        //ConfirmCheckOut("750");

        //调用web server接口
        //string time = GetTimeStamp();
        //rentHouse.Authentication header = new rentHouse.Authentication();
        //header.UserID = "admin";
        //header.PassWord = "Pa$$w0rd780419";
        //header.TimeStamp = time;
        //header.Token = LigerRM.Common.Global.Encryp.MD5("guardts" + time + "house");

        //rentHouse.Services service = new rentHouse.Services();
        //service.AuthenticationValue = header;
        //Response.Write(service.GetDistrictList());

        //herder认证
        //Response.Write(ValideUser("admin", "Pa$$w0rd780419", time, LigerRM.Common.Global.Encryp.MD5("guardts" + time + "house")));

        //aes加密
        //Response.Write(Encrypt.AESEncode("123456"));
        //Response.Write(Encrypt.AESDecode("PE9X7lyZkjVMBUe6vMaN5Q=="));
        //string key = LigerRM.Common.Global.Encryp.MD5("SGQ&&sgq");
        //Response.Write(key.Substring(0, 32) + "<br/>");
        //Response.Write(key);

        //测试md5
        //Response.Write(LigerRM.Common.Global.Encryp.MD5("SGQ&&sgq"));

        //提现
        //Dictionary<string, string> retRequestJson = new Dictionary<string, string>();
        //retRequestJson.Add("no_order", "20180109142212");
        //retRequestJson.Add("oid_partner", "201705091001717478");
        //retRequestJson.Add("oid_paybill", "2018010939980485");
        //retRequestJson.Add("ret_code", "0000");
        //retRequestJson.Add("ret_msg", "交易成功");
        //retRequestJson.Add("sign", "SO6mEhpza6QkuMEgURMOWm0fhdVVVGKupfOaYo6Gh/Fpj5BjsQoUzkT8ifDbbBxGljY9KSiLPVYsGFu9MdVnMSsn3pDPCaXfc8ymhgqngYzzBspT/EHl1CpCcQE/Tmhh+zXIZAVpu71PsRVvi6H9YmFbhwBUMWLp590+2XnBUz8=");
        //retRequestJson.Add("sign_type", "RSA");
        //retRequestJson.Add("idCard", "222222");
        //retRequestJson.Add("fee", "12.22");
        //string aesJson = Encrypt.AESEncode(JSONHelper.ToJson(retRequestJson));
        //string aa = CreateWithdrawalsLog(aesJson);
        //Response.Write(aa);
        //Dictionary<string, object> retSpide = new Dictionary<string, object>();
        //retSpide = JSONHelper.FromJson<Dictionary<string, object>>(aa);
        //if (retSpide["ret"].ToString() == "0" && retSpide["msg"].ToString() == "success")
        //{
        //    Response.Write(1);
        //}
        //else
        //{
        //    Response.Write(2);
        //}

        //提现返回
        string aa = CreateWithdrawalsReturnLog("9999", "System.Collections.Generic.SortedDictionary`2[System.String,System.String]", DateTime.Now.ToString(), "20170911234649", "体现", "0.1", "20180109142212", "201705091001717478", "2017091169065407", "SUCCESS", "20170911", "a708cc12335bc39ebe313d8bed5a6fcb", "MD5");
        Dictionary<string, object> retSpide = new Dictionary<string, object>();
        retSpide = JSONHelper.FromJson<Dictionary<string, object>>(aa);
        if (retSpide["ret"].ToString() == "0" && retSpide["msg"].ToString() == "success")
        {
            Response.Write(1);
        }
        else
        {
            Response.Write(2);
        }
        //string Status, string sPara, string CreatedOn, string dt_order, string info_order, string money_order, string no_order, string oid_partner, string oid_paybill, string result_pay, string settle_date, string sign, string sign_type

        //算出时间周
        //Response.Write(m_GetWeekNow());

        //提现状态请求
        //Response.Write(GetWithdrawalsState("1"));

        //测试加密
        //Dictionary<string, string> retJson = new Dictionary<string, string>();
        //retJson.Add("name", "sadasd");
        //retJson.Add("bankName", "asdadad");
        //retJson.Add("cardNO", "12312321331");
        //retJson.Add("fee", "11.11");
        //retJson.Add("orderName", "asdadad");
        //retJson.Add("IdCard", "asda213213dad");
        ////Response.Write(Encrypt.AESEncode(JSONHelper.ToJson(retJson)));
        //Response.Write(Encrypt.AESDecode("i3gSHtsblUoIQQl7w5CZTZKYpXGFehaetJthwkwa1OcO3YcevA2tFKLhwJ9q2E0ivuoJaqcy9RrN7SaXKbjoJV6oDCNhk62UfkQ2XyBdTQES39inx7ey6uqVyL/mPZGcmKk6jJ2B91tsHmmnunlrxE0xrJfw3bLBrUjpTcXShlA="));

    }

    public string GetWithdrawalsState(string IDCard)
    {
        Dictionary<string, string> ret = new Dictionary<string, string>();
        try
        {
            string sqlWithdrawalsLog = "select * from CF_User_Withdrawals_Log where IDCard= '" + IDCard + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlWithdrawalsLog)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ret.Add("state", dt.Rows[0]["TradingState"].ToString());  //0 提现中  1 提现成功   2 提现失败  3 提现异常
            }
            else
            {
                ret.Add("state", "4");  //4  暂无提现
            }
            ret.Add("ret", "0");
            ret.Add("msg", "success");
        }
        catch (Exception ex)
        {
            ret.Add("ret", "1");
            ret.Add("msg", ex.Message);
        }
        return JSONHelper.ToJson(ret);
    }


    private string m_GetWeekNow()
    {

        string strWeek = DateTime.Now.DayOfWeek.ToString();

        switch (strWeek)
        {

            case "Monday":

                return "1";

            case "Tuesday":

                return "2";

            case "Wednesday":

                return "3";

            case "Thursday":

                return "4";

            case "Friday":

                return "5";

            case "Saturday":

                return "6";

            case "Sunday":

                return "7";

        }

        return "0";

    }

    public string CreateWithdrawalsReturnLog(string Status, string sPara, string CreatedOn, string dt_order, string info_order, string money_order, string no_order, string oid_partner, string oid_paybill, string result_pay, string settle_date, string sign, string sign_type)
    {
        Dictionary<string, string> ret = new Dictionary<string, string>();
        try
        {
            //提现成功
            if (Status == "0000" && result_pay == "SUCCESS")
            {
                //提现成功
                string sqlUpdateWithdrawalsLog = "update CF_User_Withdrawals_Log set TradingState='" + 1 + "' where NoOrder='" + no_order + "'";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlUpdateWithdrawalsLog));
            }
            else
            {
                //提现失败
                string sqlUpdateWithdrawalsLog = "update CF_User_Withdrawals_Log set TradingState='" + 2 + "' where NoOrder='" + no_order + "'";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlUpdateWithdrawalsLog));
                string sqlWithdrawalsLog = "select * from CF_User_Withdrawals_Log where NoOrder= '" + no_order + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlWithdrawalsLog)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Free"].ToString() == money_order)
                    {
                        //修改钱包金额
                        RentAttributeHelper helper = new RentAttributeHelper();
                        Double fee = Convert.ToDouble(money_order);
                        fee += 1;
                        helper.UpdateUserWallet(dt.Rows[0]["IDCard"].ToString(), fee.ToString(), "0");
                    }
                }
            }
            //插入log数据
            string sql = "insert into CF_User_ReturnInfo_Log values ('" + Guid.NewGuid().ToString() + "','" + Status + "','" + sPara + "','" + CreatedOn + "','" + dt_order + "','" + info_order + "','" + money_order + "','" + no_order + "','" + oid_partner + "','" + oid_paybill + "','" + result_pay + "','" + settle_date + "','" + sign + "','" + sign_type + "','" + DateTime.Now.ToString() + "')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            ret.Add("ret", "0");
            ret.Add("msg", "success");
        }
        catch (Exception ex)
        {
            ret.Add("ret", "1");
            ret.Add("msg", ex.Message);
        }
        return JSONHelper.ToJson(ret);

    }


    public string CreateWithdrawalsLog(string jsonRequest)
    {
        string jsonRequestInfo = Encrypt.AESDecode(jsonRequest);
        if (string.Empty == jsonRequestInfo) //aes校验
        {
            Dictionary<string, string> retJson = new Dictionary<string, string>();
            retJson.Add("ret", "1");
            retJson.Add("msg", "request json false");
            return JSONHelper.ToJson(retJson);
        }
        Dictionary<string, object> retRequest = new Dictionary<string, object>();
        retRequest = JSONHelper.FromJson<Dictionary<string, object>>(jsonRequestInfo);
        //插入log数据
        string sql = "insert into CF_User_Withdrawals_Log values ('" + Guid.NewGuid().ToString() + "','" + retRequest["idCard"].ToString() + "','" + retRequest["no_order"].ToString() + "','" + retRequest["oid_partner"].ToString() + "','" + retRequest["oid_paybill"].ToString() + "','" + retRequest["ret_code"].ToString() + "','" + retRequest["ret_msg"].ToString() + "','" + retRequest["sign"].ToString() + "','" + retRequest["sign_type"].ToString() + "','" + 0 + "','" + retRequest["fee"].ToString() + "','" + DateTime.Now.ToString() + "')";
        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        return "111";
    }


    public bool ValideUser(string UserID, string PassWord, string TimeStamp, string Token)
    {
        if (UserID == "admin" && PassWord == "Pa$$w0rd780419")
        {
            if (string.IsNullOrEmpty(TimeStamp))
                return false;
            string str = LigerRM.Common.Global.Encryp.MD5("guardts" + TimeStamp + "house");
            if (str.Equals(Token))
                return true;
            else
                return false;
        }
        else
            return false;
    }


    /// <summary>  
    /// 获取时间戳  
    /// </summary>  
    /// <returns></returns>  
    public static string GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds).ToString();
    }

    public string ConfirmCheckOut(string rraId)
    {
        string sql = "update Rent_RentAttribute set RRAStatus='" + ((int)RentAttributeHelper.AttributeStatus.CheckedOut).ToString() + "' where RRAID=" + rraId;
        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

        //清除密码
        ClearPasswordToLock(rraId);

        Dictionary<string, string> ret = new Dictionary<string, string>();
        ret.Add("ret", "0");
        ret.Add("msg", "Success");
        return JSONHelper.ToJson(ret);
    }

    public string ClearPasswordToLock(string aarId)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        RentAttribute a = new RentAttribute(int.Parse(aarId));
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand("select * from Rent_Locks where rentno='" + a.RentNo + "'")).Tables[0];
        string lockID = dt.Rows.Count.ToString();
        string a1 = a.RRAStartDate.ToString("yyyy-MM-dd HH:mm:ss");
        string a2 = a.RRAEndDate.ToString("yyyy-MM-dd HH:mm:ss");
        ////LockID='" + dt.Rows[0]["DeviceID"].ToString() + "' and StartDate='" + a1 + "' and EndDate='" + a2 + "'
        //string sql = "select * from Rent_Locks_ICCards where LockID='" + dt.Rows[0]["DeviceID"].ToString() + "' and StartDate='" + a.RRAStartDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and EndDate='" + a.RRAEndDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        string sql = "select * from Rent_Locks_ICCards where LockID='" + lockID + "'";

        LockManager manager = new LockManager();
        DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        foreach (DataRow row in dt1.Rows)
        {
            string returnStr = manager.UpdatePassengerInfoToDevice(dt.Rows[0]["DeviceID"].ToString(), row["ICCard"].ToString(), "", "", "", a.RRAStartDate.ToString("yyyyMMddHHmm").Substring(2, 10), a.RRAEndDate.ToString("yyyyMMddHHmm").Substring(2, 10), "2");
        }

        if (dt.Rows.Count > 0)
        {

            string returnStr = manager.UpdatePassengerInfoToDevice(dt.Rows[0]["DeviceID"].ToString(), "", "", "", a.RRANationName, a.RRAStartDate.ToString("yyyyMMddHHmm").Substring(2, 10), a.RRAEndDate.ToString("yyyyMMddHHmm").Substring(2, 10), "4");


            dic.Add("ret", "0");
            dic.Add("msg", returnStr);
        }
        else
        {
            dic.Add("ret", "1");
            dic.Add("msg", "未发现智能锁信息，无法添加密码");
        }
        return JSONHelper.ToJson(dic);
    }

    public string GetHousesByCondition(int pageSize, int pageIndex, string housetype, string rentType, string address, string isAvalible, string userID, string startdate, string endate)
    {
        string where = "1=1 and isObsoleted=0 ";
        if (!string.IsNullOrEmpty(housetype))
            where += " and RRoomType='" + housetype + "'";
        if (!string.IsNullOrEmpty(rentType))
            where += " and RRentType='" + rentType + "'";
        if (!string.IsNullOrEmpty(address))
            where += " and RAddress like '%" + address + "%'";

        string dateSql = "select distinct rentno from Rent_RentAttribute where (((rrastartdate BETWEEN '" + startdate + "' and '" + endate + "') or (rraenddate BETWEEN '" + startdate + "' and '" + endate + "')) or ((rrastartdate <'" + startdate + "' and rraenddate>'" + endate + "'))) and rrastatus in ('0','1','2','6')";
        DataTable dateDt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(dateSql)).Tables[0];
        dateSql = string.Empty;
        foreach (DataRow row in dateDt.Rows)
        {
            dateSql += "'" + row["rentno"].ToString() + "',";
        }

        dateSql = " and rentno not in (" + dateSql + "'')";

        RentInfoHelper helper = new RentInfoHelper();
        if (!userID.Equals("1"))
        {
            string tempStr = string.Empty;
            DataTable dt = helper.GetDataTable("select * from dbo.Rent_user_dept_relationship where t_wu_user_id = (select userid from cf_user where loginname = '" + userID + "')");
            foreach (DataRow row in dt.Rows)
            {
                tempStr += row["t_ad_reg_dept_id"].ToString() + ",";
            }

            if (!string.IsNullOrEmpty(tempStr))
            {
                tempStr = tempStr.Substring(0, tempStr.Length - 1);
                where += " and Region in (" + tempStr + ")";
            }
        }

        where += dateSql;

        System.Data.SqlClient.SqlDataReader r = helper.GetList(pageSize, pageIndex, "v_RentDetail_view", "RID", where, "*", "RCreatedDate", true);
        //return helper.GetJSONInfo(r);
        var list = new List<Hashtable>();
        list = JSONHelper.DbReaderToHash(r);
        //查询所有数据
        string sqlArray = string.Empty;
        for (int j = 0; j < list.Count; j++)
        {
            if (j == (list.Count - 1))
            {
                sqlArray += "'" + list[j]["RentNO"].ToString() + "'";
            }
            else
            {
                sqlArray += "'" + list[j]["RentNO"].ToString() + "',";
            }


        }
        var arrayKayObject = new Hashtable();  //配凑Key=>value
        if (!string.IsNullOrEmpty(sqlArray))
        {
            //根据地区的房屋id获取该地区评分的数据
            string sqlEvaluation = "SELECT  RentNO, sum(count)/count(*) as count FROM (SELECT RentNO, (EvaluateItem0+EvaluateItem1+EvaluateItem2)/3 as count FROM v_Rent_Evaluation_view WHERE EvaluateType = 1 and RentNO in(" + sqlArray + ")) as a GROUP BY a.RentNO ORDER BY count DESC";
            DataSet dataEvaluation = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlEvaluation));
            foreach (DataRow row in dataEvaluation.Tables[0].Rows)
            {
                var name = row["RentNO"].ToString();
                var value = row["count"].ToString();
                arrayKayObject[name] = value;
            }

        }
        for (int k = 0; k < list.Count; k++)
        {
            string rentNo = list[k]["RentNO"].ToString();
            RentImageHelper helperImage = new RentImageHelper();
            string count = string.Empty;
            List<Hashtable> images = helperImage.GetRentImages(rentNo, out count);
            var item1 = new Hashtable();
            for (int q = 0; q < images.Count; q++)
            {
                list[k].Add("Image" + q, images[q]["ImagePath"].ToString());  //添加图片
            }
            //筛选key
            if (arrayKayObject.Contains(rentNo))
            {
                list[k].Add("Evaluate", arrayKayObject[rentNo]);   //添加评分
            }
        }
        return JSONHelper.ToJson(list);
    }


    public string UpdateRentInfo(string RentNo, string RDName, string RSName, string RRName, string RPSName, string RAddress,
           string RDoor, string RTotalDoor, string RRoomType, string RDirection, string RStructure, string RBuildingType, string RFloor, string RTotalFloor, string RHouseAge,
           decimal RRentArea, string RProperty, string ROwner, string ROwnerTel, string RIDCard, string RLocationDescription, string RPSParentName, string createdBy, string rentType, string ownType)
    {

        RentInfo rentInfo = new RentInfo(RentNo);
        rentInfo.RentNo = RentNo;
        RentInfoHelper helper = new RentInfoHelper();

        rentInfo.RDName = RDName;
        rentInfo.RSName = RSName;
        rentInfo.RRName = RRName;

        rentInfo.RPSParentName = RPSParentName;
        rentInfo.RPSName = RPSName;
        rentInfo.RPSID = RPSName;
        //rentInfo.RPSID = int.Parse(RPSName);

        rentInfo.RAddress = RAddress;
        rentInfo.RDoor = RDoor;
        rentInfo.RTotalDoor = int.Parse(RTotalDoor);

        rentInfo.RRoomType = RRoomType;
        rentInfo.RDirection = RDirection;
        rentInfo.RStructure = RStructure;
        rentInfo.RBuildingType = RBuildingType;
        rentInfo.RProperty = RProperty;

        rentInfo.RFloor = RFloor;
        rentInfo.RTotalFloor = int.Parse(RTotalFloor);

        rentInfo.RHouseAge = int.Parse(RHouseAge);
        rentInfo.RRentArea = RRentArea;
        rentInfo.ROwner = ROwner;
        rentInfo.ROwnerTel = ROwnerTel;
        rentInfo.RIDCard = RIDCard;
        rentInfo.RLocationDescription = RLocationDescription;

        rentInfo.RMapID = 0;

        rentInfo.RCreatedBy = createdBy;
        rentInfo.RCreatedDate = DateTime.Now;
        rentInfo.RModifiedBy = createdBy;
        rentInfo.RModifiedDate = DateTime.Now;

        rentInfo.RentType = rentType;
        rentInfo.OwnType = ownType;

        string retStr = GetLocationInfo(RAddress, "天津");
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(retStr);
        XmlNode status = doc.SelectSingleNode("GeocoderSearchResponse/status");
        if (status.InnerText == "0")
        {
            XmlNode lng = doc.SelectSingleNode("GeocoderSearchResponse/result/location/lng");
            XmlNode lat = doc.SelectSingleNode("GeocoderSearchResponse/result/location/lat");
            rentInfo.Longitude = lng.InnerText;
            rentInfo.Latitude = lat.InnerText;
        }


        //string retStr = GetLocationInfo(RAddress, "天津");
        //if (retStr.IndexOf("lng") > 0)
        //{
        //    int aa = retStr.IndexOf("\"lng\"");
        //    retStr = retStr.Substring(retStr.IndexOf("\"lng\""));
        //    string lng = retStr.Substring(6, retStr.IndexOf("\n"));
        //    lng = lng.Replace("\n", "").Trim().Replace(",", "");
        //    retStr = retStr.Substring(retStr.IndexOf("\"lat\""));
        //    string lat = retStr.Substring(6, retStr.IndexOf("\n"));
        //    lat = lat.Replace("\n", "").Trim().Replace(",", "");
        //    rentInfo.Longitude = lng;
        //    rentInfo.Latitude = lat;
        //}

        RentInfoHelper rentInfoHelper = new RentInfoHelper();
        try
        {
            rentInfoHelper.UpdateRent(rentInfo);
            return "true";
        }
        catch (Exception ex)
        {
            return "false";
        }
    }

    public string GetLocationInfo(string address, string city)
    {
        //if (!authentication.ValideUser())
        //{
        //    return "{'headerError'}";
        //}
        string tempAddress = System.Web.HttpUtility.UrlEncode(address).ToUpper();
        string tempCity = System.Web.HttpUtility.UrlEncode(city).ToUpper();

        string url = "http://api.map.baidu.com/geocoder/v2/?address=" + tempAddress + "&ak=OG00ESUZvs88soSk5aDuxxw1R8r5NGtn";
        WebRequest request = WebRequest.Create(url);
        request.Method = "POST";
        XmlDocument xmlDoc = new XmlDocument();
        string sendData = xmlDoc.InnerXml;
        byte[] byteArray = Encoding.Default.GetBytes(sendData);

        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        WebResponse response = request.GetResponse();
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.GetEncoding("utf-8"));
        string responseXml = reader.ReadToEnd();
        return responseXml;

    }
}