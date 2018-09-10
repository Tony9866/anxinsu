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
using System.Configuration;
using System.Collections;
using LigerRM_BusinessLayer;
using System.Xml;
using System.Net;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public partial class EvenHeardLock_Default : System.Web.UI.Page
{
    protected string appKey = "123";
    protected string appSecret = "LXS-123";
    protected string accountOpening = "17702285600";
    protected string setPwdTimeUrl = "https://smart.miitzc.com/tmall/setPwd";  //设置临时密码
    protected string setPwdUrl = "https://smart.miitzc.com/tmall/setPerPwd";  //设置永久密码
    protected string setCardUrl = "https://smart.miitzc.com/tmall/setPerCardPwd";  //设置永久卡密码
    protected string setCardTimeUrl = "https://smart.miitzc.com/tmall/setCardPwd";  //设置临时卡密码
    protected string deleteUrl = " https://smart.miitzc.com/tmall/deletePwd";   //删除操做(卡和密码)

    protected void Page_Load(object sender, EventArgs e)
    {
        //string time = (Convert.ToInt64("1517414400000") / 1000).ToString();


        //Response.Write(DateTime.Parse("2017-07-01 12:00:10").ToString());

        //锁的操做
        //string startTime = DateTimeToStamp(System.DateTime.Now, 0).ToString();
        //string endTime = DateTimeToStamp(System.DateTime.Now, 60).ToString();
        //string startTime = GetCreatetime(DateTime.Parse(DateTime.Now.ToString()));
        //string endTime = GetCreatetime(DateTime.Parse(DateTime.Now.ToString()));
        //DateTime startDate = DateTime.Now.AddDays(-1);
        //Response.Write(startDate.ToString());
        //Response.Write(startTime);
        //Response.Write(GetPostInterface("gdts880701", "11111", "1", "123123", startTime, endTime));
        //{"res":[{"ret":"true","StartDate":"","EndDate":"","uuid":"-222222","userId":"11111"}]}
        //Response.Write(delAction("11111", "临时密码", "333333", "2018-01-22 11:27:26.000", "2018-01-22 11:57:26.000", "gdts880701"));
        //insert into Rent_Locks_Password values ('gdts880701','222222','2018-01-19 13:31:51','2018-01-19 13:34:51','0','1')

        //删除，解冻， 冻结
        //NewLockManager managerNew = new NewLockManager();
        //Response.Write(managerNew.GetPostInterface("wshill", "111111", "4", "110dd0015faa1a19", "2018-02-11 00:00:00.000", "2018-02-12 00:00:00.000"));  //添加接口
        //Response.Write(managerNew.delAction("111111", "临时密码", "2018-02-11 00:00:00.000", "2018-02-12 00:00:00.000", "wshill", "2"));
        //一键开锁
        //Response.Write(managerNew.openDoor("h10801205"));


        //推送校验
        //string sql = "select * from Rent_Lock_User_ICCards where UserId='" + 11111 + "'";
        //DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        //string dateSql = string.Empty;
        //foreach (DataRow row in dt.Rows)
        //{
        //    dateSql += "'" + row["ICCardId"].ToString() + "',";
        //}
        //dateSql = " ID in (" + dateSql + "'')";
        //Response.Write(dateSql);
        //string sql1 = "update Rent_Locks_ICCards set ICCard='" + 1243123431234 + "' where " + dateSql + "and StartDate='" + GetDateTime("1516344669") + "' and EndDate='" + GetDateTime("1516346469") + "'";
        //MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql1));

        //string postContent = "{res:[{ret:\"ture\",StartDate:\"\",EndDate:\"\",uuid:\"-34b634a4\",userId:\"11111\"}]}";
        ////{res:[{ret:"",StartDate:"",EndDate:"",uuid:"-34b634a4",userId:"11111"}]}
        //Dictionary<string, IdCardCallBack[]> retCallBack = JSONHelper.FromJson<Dictionary<string, IdCardCallBack[]>>(postContent);
        //foreach (IdCardCallBack b in retCallBack["res"])
        //{
        //    if (b.ret != "ture")
        //    {

        //    }
        //    else
        //    {
        //        string sql = "select * from Rent_Lock_User_ICCards where UserId='" + b.userId + "'";
        //        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        //        string dateSql = string.Empty;
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            dateSql += "'" + row["ICCardId"].ToString() + "',";
        //        }
        //        dateSql = " ID in (" + dateSql + "'')";
        //        if (string.Empty == b.StartDate && string.Empty == b.EndDate)
        //        {
        //            sql = "update Rent_Locks_ICCards set ICCard='" + b.uuid + "' where " + dateSql + "";
        //        }
        //        else
        //        {
        //            sql = "update Rent_Locks_ICCards set ICCard='" + b.uuid + "' where " + dateSql + "and StartDate='" + GetDateTime(b.StartDate) + "' and EndDate='" + GetDateTime(b.EndDate) + "'";
        //        }
        //        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

        //    }

        //}

        //string postContent = "{\"res\":[{\"openType\":\"密码开锁\",\"pwd\":\"425343\",\"openTime\":\"\",\"userId\":\"111111\",\"devId\":\"12121212\"}]}";
        //Dictionary<string, LockReturnBak[]> retCallBack = JSONHelper.FromJson<Dictionary<string, LockReturnBak[]>>(postContent);
        //foreach (LockReturnBak b in retCallBack["res"])
        //{
        //    string sql = "insert into Rent_Locks_ReturnLog values ('" + Guid.NewGuid().ToString() + "','" + b.userId + "','" + b.devId + "','" + b.pwd + "','" + 1 + "','" + GetDateTime(b.openTime) + "','" + DateTime.Now.ToString() + "','" + b.openType + "', '')";
        //    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        //}

        //address = 1313;
        //endate = "2019-11-12 14:00";
        //housetype = "";
        //isAvalible = 0;
        //pageIndex = 1;
        //pageSize = 1000;
        //rentType = "";
        //startdate = "2017-11-11 00:00";
        //userID = 1;


        //搜索房屋
        //GetHousesByCondition(1000, 1, "", "", "1313", "0", "1", "2017-11-11 00:00", "2017-11-12 00:00");



        //ClearPasswordToLock("837");
        //ApplyCheckOut("821", "13699233594", "房客行程有变");
        //CompleteRentAttribute("826");
        //AddIDCardToDevice("130402199101161511", "0701002200100022", "837");
        //GetRentOwnerHistory("130133199302243319");
        //GetRentBindLockStutus("5");
        //PayWithWeChart("922", "130402199101161511", "支付房费", "1", "JSAPI");
        //OpenDoor("wshill");
        //Response.Write(Guid.NewGuid().ToString("N"));

        //string sql = "select Memo from Rent_Locks where DeviceID='will002'";
        //DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        //addAndUpdateFiled(dt.Rows[0]["Memo"].ToString(), 2, "false");
        //string ww = string.Empty;

       



        //string aa = AddRentInfo(
        //    "vYMDWrb3lh8K",
        //    "01",
        //    "02",
        //    "9",
        //    "120004056", 
        //    "天津市河西区天塔街环湖中路环湖南里30号楼30门30",
        //    "30", 
        //    "30",
        //    "02", 
        //    "02",
        //    "01", 
        //    "02", 
        //    "30",
        //    "30", 
        //    "30", 
        //    30, 
        //    "fagnchanxingzhi", 
        //    "周琦",
        //    "13699233594",
        //    "130402199101161511",
        //    "30",
        //    "120004",
        //    "13699233594",
        //    "01",
        //    "02"
        //    );
        //Response.Write(aa);
        //添加家庭
        //Response.Write(CreateHomeLock("环湖南里小区", "我的第一个家庭", "17702285600"));
        //添加网关
       // Response.Write(addGateway("A00190", "gprsgw0190", "8becd343-764e-4214-a55c-8b98c7e79874"));     
        //添加锁
        //Response.Write(getPinInfo("8becd343-764e-4214-a55c-8b98c7e79874")); 
        //删除锁和网关
        //Response.Write(DeleteGatewayLock("50abfaa8-8db9-4bab-851e-f5694efdacd4", 4));
        //添加密码和卡片
        //Response.Write(NewAddPasswordICcard("50abfaa8-8db9-4bab-851e-f5694efdacd4", "4", "111111", "2018-03-13 10:19:46", "2018-03-13 10:19:46"));
        //删除密码和卡片
        //Response.Write(NewDelPasswordICcard("", ""));
        //新锁和房屋绑定
       // Response.Write(BandHomeLockDevice("v1gdqVj6uSiGj1kS2p", "ce57c4be-96f5-464a-8576-ac989e331a92"));
        //扫码开锁
        //Response.Write(NewScanCode("A00190", "gprsgw0190"));
        //新地图
        //Response.Write(GetNewRentsByCoodinates("39.07461714999739", "117.2491883544814", "5000", "2018-04-25 15:39:11", "2018-04-26 15:39:11"));
        //获取未租房接口
        //string sql = "select RentNo from dbo.v_RentHistory_view where  IsExpired='0' and rrastatus not in ('5','9','8','7','11') " +
        //      "and (RRAEndDate < '2018-04-25 10:19:46' or RRAStartDate> '2018-04-26 10:19:46')";
        //DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

        //string dateSql = string.Empty;
        //foreach (DataRow row in dt.Rows)
        //{
        //    dateSql += "'" + row["RentNo"].ToString() + "',";
        //}
        //dateSql = " RentNo in (" + dateSql + "'')";

        //Response.Write(dateSql);

        /////////////////////////////////////sdk  测试/////////////////////////////////////////////////////////////////
        //Response.Write(CreateHomeLock("sdk测试aaaaa", "sdaak", "12030701", "解析去aaa", "weiyuzhu", "17702285600", "120221199302281313", "家里", "1"));
        //Response.Write(DeleteGatewayLock("c64ac1fc-b993-4027-b517-ee5aaf23ef72", 1));
       // Response.Write(AddGateway("A00246", "gprsgw0246", "c64ac1fc-b993-4027-b517-ee5aaf23ef72"));
        //Response.Write(GetHomeLockReturnInfo("c64ac1fc-b993-4027-b517-ee5aaf23ef72", 2));
       // Response.Write(GetPinInfo("c64ac1fc-b993-4027-b517-ee5aaf23ef72"));
       // Response.Write(GetUserNewLockList("12030701"));
        //Response.Write(GetNewFamilyInfo("c64ac1fc-b993-4027-b517-ee5aaf23ef72"));
       // Response.Write(NewOpenDoor("c64ac1fc-b993-4027-b517-ee5aaf23ef72"));
       // Response.Write(PoliceRetrieval("298", "2018-04-18 17:00", "2018-05-18 17:00", "王明明", ""));
      //  Response.Write(UpdateNewFamilyInfo("7c5cc837-8659-4492-9a1b-b2c27bea0f88", "", "", "5555", "2222", "22222", "2222", "", ""));
        //Response.Write(NewAddPasswordICcard("c64ac1fc-b993-4027-b517-ee5aaf23ef72", "4", "", "2018-04-19 14:30:00", "2018-04-19 14:34:00"));
        //Response.Write(NewSelPasswordICcard("c64ac1fc-b993-4027-b517-ee5aaf23ef72", 1));
       // Response.Write(NewDelPasswordICcard("320", "2", "12030701"));
       // Response.Write(PoliceRetrieval("298", "2018-04-20 16:00:00", "2018-04-30 16:00:00", "高", ""));

    }





}