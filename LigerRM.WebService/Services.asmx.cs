using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Services.Protocols;
using SignetInternet_BusinessLayer;
using LigerRM.Common;
using System.Data;
using LigerRM_BusinessLayer;
using System.Configuration;
using XGAPI;
using XGAPI.Enums;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace LigerRM.WebService
{
    /// <summary>
    /// Summary description for Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Services : System.Web.Services.WebService
    {
        public Authentication authentication = new Authentication();
        public ServiceCredential myCredential;

        //public enum RentPropertyEnumList
        //{
        //    RoomType = 1,
        //    Direction = 2,
        //    Structure = 6,
        //    BuildingType = 7,
        //    Property = 8,
        //    Province = 18,
        //    NationName = 19
        //}

        /// <summary>
        /// 验证用户登录，返回true登陆成功，返回false，登录失败
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string ValidateLogin(string username, string password, string userType)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.ValidateLogin(username, password, userType).ToString();
        }

        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetUserInfo(string username, string deviceId)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            RentInfoHelper helper = new RentInfoHelper();
            UpdateDeviceID(username, deviceId);
            return helper.GetJSONInfo("select a.*, c.RoleName from v_CF_User_View as a LEFT OUTER JOIN CF_UserRole as b on a.UserID = b.UserID LEFT OUTER JOIN CF_Role as c on c.RoleID = b.RoleID where LoginName='" + username + "'");
        }

        /// <summary>
        /// 验证房源信息，返回true有，返回false
        /// </summary>
        /// <param name="houseID">房源编号</param>
        /// <returns>true:可以用，false:不可以用</returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string ValidateHouseID(string houseID)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            if (helper.IsExistsRentNo(houseID))
                return "false";
            else
                return "true";
        }

        /// <summary>
        /// 验证房源是否绑定锁信息，返回true有，返回false
        /// </summary>
        /// <param name="houseID">房源编号</param>
        /// <returns>true:绑定，false:没绑定</returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string ValidateHouseBindLock(string houseID)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            if (helper.IsExistsRentNoBindLock(houseID))
                return "0";
            else
                return "1";
        }

        /// <summary>
        /// 获得某人名下的房屋信息
        /// </summary>
        /// <param name="idcard">身份证号</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseInfo(string idcard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from v_RentDetail_view where RIDCard='" + idcard + "'  and isObsoleted = 0");
        }

        /// <summary>
        /// 获取房屋相信信息
        /// </summary>
        /// <param name="rentNo"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseDetailInfo(string rentNo)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select *,GETDATE() as time,'ValidateHour'=12,'RedPackageDesc'=case when r.RedPackageID is not null then '入住满12 小时后可领取,仅为在线支付的用户提供,活动时间'+cast(month(r.RedPackageStartDate) as varchar)+'月'+cast(day(r.RedPackageStartDate) as varchar)+'日-'+cast(month(r.RedPackageEndDate) as varchar)+'月'+cast(day(r.RedPackageEndDate) as varchar)+'日' end from v_RentDetail_view left join Sys_RedPackage r on r.RedPackageObject = RentNO and r.RedPackageStartDate <=GETDATE() and r.RedPackageEndDate>GETDATE() and r.RedPackageStatus='0' where RentNO='" + rentNo + "'  and isObsoleted = 0");

        }

        /// <summary>
        /// 获取登录用户名下的房子
        /// </summary>
        /// <param name="loginName">登录用户名</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseInfoByLoginName(string loginName)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from v_RentDetail_view where RCreatedBy='" + loginName + "' and isObsoleted = 0");
        }

        /// <summary>
        /// 注册用户信息
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">登录密码</param>
        /// <param name="userType">用户类型，0：租户，1：房东</param>
        /// <param name="realName">真实姓名</param>
        /// <param name="title">头衔（可以为空）</param>
        /// <param name="sex">性别</param>
        /// <param name="phone">电话</param>
        /// <param name="fax">传真</param>
        /// <param name="email">邮箱</param>
        /// <param name="idcard">身份证号</param>
        /// <param name="nickName">昵称</param>
        /// <param name="address">住址</param>
        /// /// <param name="status">用户状态，0：正常，1：监控中：</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddUserInfo(string loginName, string password, string userType, string realName, string title,
            string sex, string phone, string fax, string email, string idcard, string nickName, string address, string status)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            string tempPass = Encrypt.DESEncrypt(password);
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                helper.GetJSONInfo("insert into cf_user values ('" + loginName + "','" + tempPass + "','','" + userType + "','','" + realName + "','" + title + "','" + sex + "','" +
                    phone + "','" + fax + "','" + email + "','" + idcard + "','" + nickName + "','" + address + "','" + DateTime.Now.ToString() + "',0,'" + DateTime.Now.ToString() + "',0,'" + DateTime.Now.ToString() + "','0')");

                //添加默认权限
                UserInfoHelper userhelper = new UserInfoHelper();
                CFUserInfo info = new CFUserInfo(loginName);
                userhelper.InsertUserRole(info.UserID.ToString(), "20");
                ret.Add("ret", "0");
                ret.Add("msg", "Success");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }

            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 验证用户名是否可用
        /// </summary>
        /// <param name="loginName">用户注册的用户名</param>
        /// <returns>true:可以注册，false：不能注册</returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string ValidateLoginName(string loginName)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            if (helper.IsExistsLoginName(loginName))
                return "false";
            else
                return "true";
        }

        #region 房源信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RentNo"></param>
        /// <param name="RAddress"></param>
        /// <param name="RRentArea"></param>
        /// <param name="RProperty"></param>
        /// <param name="ROwner"></param>
        /// <param name="RIDCard"></param>
        /// <param name="RLocationDescription"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public bool AddRentInfoTest(string RentNo, string RAddress, decimal RRentArea, string RProperty,
            string ROwner, string RIDCard, string RLocationDescription)
        {
            RentInfo rentInfo = new RentInfo(RentNo);
            rentInfo.RentNo = RentNo;
            RentInfoHelper helper = new RentInfoHelper();

            DataTable dt = helper.GetDataTable("select * from v_District_view");
            int count = dt.Rows.Count;
            Random r = new Random(1);
            int rowIndex = r.Next(count - 1);

            if (count >= 1)
            {
                rentInfo.RDName = dt.Rows[rowIndex]["LDID"].ToString();
                rentInfo.RSName = dt.Rows[rowIndex]["LSID"].ToString();
                rentInfo.RRName = dt.Rows[rowIndex]["LRID"].ToString();
            }
            else
            {
                rentInfo.RDName = "3";
                rentInfo.RSName = "8";
                rentInfo.RRName = "5";
            }

            dt = helper.GetDataTable("select p.*,c.PSID as childId from dbo.v_ParentPoliceStation p inner join Rent_PoliceStation c on c.ParentID = p.PSID ");

            count = dt.Rows.Count;
            rowIndex = r.Next(count - 1);
            if (count >= 1)
            {
                rentInfo.RPSParentName = dt.Rows[rowIndex]["PSID"].ToString();
                rentInfo.RPSName = dt.Rows[rowIndex]["childId"].ToString();
            }
            else
            {
                rentInfo.RPSParentName = "5";
                rentInfo.RPSName = "11";
            }

            rentInfo.RPSID = "0";
            rentInfo.RAddress = RAddress;
            rentInfo.RDoor = "1";
            rentInfo.RTotalDoor = 1;

            rentInfo.RRoomType = "";
            rentInfo.RDirection = "";
            rentInfo.RStructure = "";
            rentInfo.RBuildingType = "";
            rentInfo.RProperty = RProperty;

            rentInfo.RFloor = "";
            rentInfo.RTotalFloor = 0;

            rentInfo.RHouseAge = 0;
            rentInfo.RRentArea = RRentArea;
            rentInfo.ROwner = ROwner;
            rentInfo.ROwnerTel = "";
            rentInfo.RIDCard = RIDCard;
            rentInfo.RLocationDescription = RLocationDescription;

            rentInfo.RMapID = 0;

            //if (string.IsNullOrEmpty(RentNo))
            //{
            //    rentInfo.RCreatedBy = "admin";
            //    rentInfo.RCreatedDate = DateTime.Now ;
            //}
            //else
            //{
            rentInfo.RCreatedBy = "admin";
            rentInfo.RCreatedDate = DateTime.Now;
            rentInfo.RModifiedBy = "admin";
            rentInfo.RModifiedDate = DateTime.Now;
            //}

            string retStr = GetLocationInfo(RAddress, "天津");
            if (retStr.IndexOf("lng") > 0)
            {
                retStr = retStr.Substring(retStr.IndexOf("\"lng\""));
                string lng = retStr.Substring(6, retStr.IndexOf("\n"));
                lng = lng.Replace("\n", "").Trim().Replace(",", "");
                retStr = retStr.Substring(retStr.IndexOf("\"lat\""));
                string lat = retStr.Substring(6, retStr.IndexOf("\n"));
                lat = lat.Replace("\n", "").Trim().Replace(",", "");
                rentInfo.Longitude = lng;
                rentInfo.Latitude = lat;
            }

            RentInfoHelper rentInfoHelper = new RentInfoHelper();
            try
            {
                rentInfoHelper.UpdateRent(rentInfo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RentNo">房产证编号，用户输入</param>
        /// <param name="RDName">区划，选择，必填，GetDistrictList,传值LDID</param>
        /// <param name="RSName">街道，选择，必填，GetStreetList获取，传值LSID</param>
        /// <param name="RRName">街区，选择，必填，GetStreetList获取，传值LSID</param>
        /// <param name="RPSName">所属派出所，选择，必填，parentstationId获取，传值PSID</param>
        /// <param name="RAddress">房屋详细地址，用户输入，必填</param>
        /// <param name="RDoor">门牌号，用户输入，必填</param>
        /// <param name="RTotalDoor">总门牌号，用户输入，选填</param>
        /// <param name="RRoomType">房型，选择，必填，GetHouseType方法获取，传值RSOID</param>
        /// <param name="RDirection">朝向，选择，必填，GetHouseDirection方法获取，传值RSOID</param>
        /// <param name="RStructure">结构，选择，必填，GetHouseStructure方法获取，传值RSOID</param>
        /// <param name="RBuildingType">建筑结构，选择，必填，GetBuildingStructure方法获取，传值RSOID</param>
        /// <param name="RFloor">房屋层数，用户输入，选填</param>
        /// <param name="RTotalFloor">房屋总层数，用户输入，选填</param>
        /// <param name="RHouseAge">房龄，用户输入，选填</param>
        /// <param name="RRentArea">房屋面积，用户输入，必填</param>
        /// <param name="RProperty">房产性质，选择，必填，GetHouseProperty方法获取，传值RSOID</param>
        /// <param name="ROwner">房主名称，用户输入，必填</param>
        /// <param name="ROwnerTel">房主电话，用户输入，选填</param>
        /// <param name="RIDCard">房主身份证号，用户输入，必填</param>
        /// <param name="RLocationDescription">房屋描述，用户输入，选填</param>
        /// <param name="RPSParentName">所属派分局，选择，必填，GetPoliceStationList获取，传值PSID</param>
        /// <param name="createdBy">创建人，登录名，必填</param>
        /// <param name="rentType">租赁类型，选择，必填，GetHouseRentType方法获取，传值RSOID</param>
        /// <param name="ownType">所有类型，选择，必填，GetHouseOwnType方法获取，传值RSOID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddRentInfo(string RentNo, string RDName, string RSName, string RRName, string RPSName, string RAddress,
            string RDoor, string RTotalDoor, string RRoomType, string RDirection, string RStructure, string RBuildingType, string RFloor, string RTotalFloor, string RHouseAge,
            decimal RRentArea, string RProperty, string ROwner, string ROwnerTel, string RIDCard, string RLocationDescription, string RPSParentName, string createdBy, string rentType, string ownType)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
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

        #endregion

        #region 租赁信息
        /// <summary>
        /// 添加租房记录
        /// </summary>
        /// <param name="RentNo"></param>
        /// <param name="RRAContactName"></param>
        /// <param name="RRAContactTel"></param>
        /// <param name="RRAIDCard"></param>
        /// <param name="RRentPrice"></param>
        /// <param name="RRAStartDate"></param>
        /// <param name="RRAEndDate"></param>
        /// <param name="RRADescription"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddRentRecord(string RentNo, string RRAContactName, string RRAContactTel,
            string RRAIDCard, string RRentPrice, string RRAStartDate, string RRAEndDate,
            string RRADescription, string createdBy, string password)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            try
            {
                RentAttribute rentAttribute = new RentAttribute(RentNo);
                rentAttribute.RentNo = RentNo;
                rentAttribute.RRAContactName = RRAContactName;

                rentAttribute.RRAContactTel = RRAContactTel;
                rentAttribute.RRANationName = password;
                rentAttribute.RRAIDCard = RRAIDCard;
                rentAttribute.RRentPrice = decimal.Parse(RRentPrice);
                rentAttribute.RRAContactProvince = "";
                rentAttribute.RRAStartDate = DateTime.Parse(RRAStartDate);
                rentAttribute.RRAEndDate = DateTime.Parse(RRAEndDate);
                rentAttribute.RRADescription = RRADescription;

                rentAttribute.RRACreatedBy = createdBy;
                rentAttribute.RRACreatedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                rentAttribute.RRAModifiedBy = createdBy;
                rentAttribute.RRAModifiedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                rentAttribute.RRAIsActive = true;
                rentAttribute.Status = ((int)RentAttributeHelper.AttributeStatus.Submitted).ToString();

                RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();

                string id = rentAttributeHelper.AddRentAttribute(rentAttribute);

                string uploadData = ConfigurationManager.AppSettings["UploadData"];
                if (uploadData.Equals("1"))
                {
                    rentAttribute.RRAID = int.Parse(id);
                    rentAttributeHelper.UploadPersonInfo(rentAttribute);
                }

                Dictionary<string, string> ret = new Dictionary<string, string>();


                if ((rentAttribute.RRAEndDate - rentAttribute.RRAStartDate).TotalHours >= 12)
                {
                    string sql = "update Sys_RedPackage set RedPackageStatus='1',memo='" + id + "'  where RedPackageObject='" + rentAttribute.RentNo + "' and RedPackageStatus='0' and RedPackageStartDate<='" + DateTime.Now.ToString() + "' and RedPackageEndDate>'" + DateTime.Now.ToString() + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }



                ret.Add("ret", "0");
                ret.Add("Id", id);

                return JSONHelper.ToJson(ret);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> ret = new Dictionary<string, string>();
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);

                return JSONHelper.ToJson(ret);
            }
        }

        #endregion

        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentAttribute(string id)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentAttributeHelper helper = new RentAttributeHelper();
            DataTable dt = helper.GetRentAttribute(id);
            Dictionary<string, string> ret = new Dictionary<string, string>();
            if (dt.Rows.Count > 0)
            {
                ret.Add("ret", "0");
                ret.Add("RRAID", id);
                ret.Add("RentNo", dt.Rows[0]["RentNo"].ToString());
                ret.Add("RRAContactName", dt.Rows[0]["RRAContactName"].ToString());
                ret.Add("RRAContactTel", dt.Rows[0]["RRAContactTel"].ToString());
                ret.Add("RRAIDCard", dt.Rows[0]["RRAIDCard"].ToString());
                ret.Add("RRentPrice", dt.Rows[0]["RRentPrice"].ToString());
                ret.Add("RRAStartDate", dt.Rows[0]["RRAStartDate"].ToString());
                ret.Add("RRAEndDate", dt.Rows[0]["RRAEndDate"].ToString());
                ret.Add("RRADescription", dt.Rows[0]["RRADescription"].ToString());
                ret.Add("RRACreatedBy", dt.Rows[0]["RRACreatedBy"].ToString());
                ret.Add("RRACreatedDate", dt.Rows[0]["RRACreatedDate"].ToString());
                ret.Add("RRAStatus", dt.Rows[0]["RRAStatus"].ToString());
                return JSONHelper.ToJson(ret);
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", "No rows selected!");
            }
            return JSONHelper.ToJson(ret);
        }
        //  RRAContactProvince  0 线下   1 线上
        [WebMethod]
        [SoapHeader("authentication")]
        public string ConfirmRentAttribute(string id, string fee, string RRAContactProvince)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentAttributeHelper helper = new RentAttributeHelper();
            helper.ConfirmRentAttribute(id, fee, RRAContactProvince);
            SysLogHelper.AddLog("房东", "确认订单", "租赁信息");
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            return JSONHelper.ToJson(ret);
        }
        //拒绝订单
        [WebMethod]
        [SoapHeader("authentication")]
        public string RejectRentAttribute(string id)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentAttributeHelper helper = new RentAttributeHelper();
            helper.UpdateStatus(id, ((int)RentAttributeHelper.AttributeStatus.Rejected).ToString());
            SysLogHelper.AddLog("房东", "拒绝订单", "租赁信息");
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            return JSONHelper.ToJson(ret);
        }
        //取消订单
        [WebMethod]
        [SoapHeader("authentication")]
        public string CancelRentAttribute(string id)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentAttributeHelper helper = new RentAttributeHelper();
            helper.UpdateStatus(id, ((int)RentAttributeHelper.AttributeStatus.Cancelled).ToString());
            SysLogHelper.AddLog("租户", "取消订单", "租赁信息");
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            return JSONHelper.ToJson(ret);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string IsOrderConfirmed(string id)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            bool ret = helper.IsOrderConfirmed(id);
            Dictionary<string, string> ret1 = new Dictionary<string, string>();

            if (ret)
            {
                ret1.Add("ret", "0");
                ret1.Add("msg", "Done");
            }
            else
            {
                ret1.Add("ret", "1");
                ret1.Add("msg", "Waiting");
            }
            return JSONHelper.ToJson(ret1);
        }


        [WebMethod]
        [SoapHeader("authentication")]
        public string CompleteRentAttribute(string id)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            try
            {
                RentAttributeHelper helper = new RentAttributeHelper();
                helper.UpdateStatus(id, ((int)RentAttributeHelper.AttributeStatus.Complete).ToString());
                DataTable dt = helper.GetRentAttribute(id);
                //添加密码到锁中
                if (dt.Rows.Count > 0)
                {
                    LogManager.WriteLog("AddPassword:Start");
                    string aaa = AddPasswordToLock(dt.Rows[0]["RentNo"].ToString(), dt.Rows[0]["RRANationName"].ToString(), dt.Rows[0]["RRAStartDate"].ToString(), dt.Rows[0]["RRAEndDate"].ToString(), dt.Rows[0]["RRAContactTel"].ToString());
                    LogManager.WriteLog("AddPassword:" + aaa);
                }

                string uploadHZ = ConfigurationManager.AppSettings["UploadDataToHZ"];
                RentInfo r = new RentInfo(dt.Rows[0]["RentNo"].ToString());
                RentAttribute rr = new RentAttribute(int.Parse(id));
                if (uploadHZ.Equals("1")) //upload data to HZ
                {
                    LogManager.WriteLog("UploadHZ:Start");
                    string hzUrl = ConfigurationManager.AppSettings["HZDataService"];
                    HuaZeServiceHelper hzHelper = new HuaZeServiceHelper();

                    string bbb = hzHelper.UploadRentInfoToHZ(r, rr);
                    LogManager.WriteLog("UploadHZ:" + bbb);
                }
                //发送短信到房东
                helper.SendSMSMessage(rr.RRAContactName, r.ROwnerTel);
                SysLogHelper.AddLog("租户", "订单付费", "租赁信息");

                ret.Add("ret", "0");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentsByCoodinates(string lat, string lon, string distance)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetRentsByCoordinate(lat, lon, distance);
        }
        //新的地图搜索
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetNewRentsByCoodinates(string lat, string lon, string distance, string startdate, string enddate)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetNewRentsByCoordinate(lat, lon, distance, startdate, enddate);
        }

        //热门数据
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentsByCoodinatesPopular(string lat, string lon, string distance)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetRentsByCoordinatePopular(lat, lon, distance);
        }

        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetDistrictList()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_District");
        }

        /// <summary>
        /// 根据区划获取街道列表
        /// </summary>
        /// <param name="district">区划ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetStreetList(string district)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_Street where LDID=" + district);
        }

        /// <summary>
        /// 获取道路列表
        /// </summary>
        /// <param name="district">区划ID</param>
        /// <param name="street">街道ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRoadList(string district)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_Road where LDID='" + district + "'");
        }

        /// <summary>
        /// 获取分居列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetPoliceStationList()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_PoliceStation where parentId='0'");
        }

        /// <summary>
        /// 获取某分居下属派出所列表
        /// </summary>
        /// <param name="parentstationId">分局ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetLocalPoliceStationList(string parentstationId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_PoliceStation where parentId=  '" + parentstationId + "'");
        }

        /// <summary>
        /// 获取房屋类型
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseType()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=1");
        }

        /// <summary>
        /// 获取房屋朝向
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseDirection()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=2");
        }

        /// <summary>
        /// 获取房屋结构
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseStructure()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=6");
        }


        /// <summary>
        /// 获取房屋建筑结构
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetBuildingStructure()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=7");
        }

        /// <summary>
        /// 获取房屋建筑类型
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseClass()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=6");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCard">获取某人的租房历史</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentHistory(string idCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }

            RentAttributeHelper aHelper = new RentAttributeHelper();
            aHelper.ExpiredOrders();

            RentInfoHelper helper = new RentInfoHelper();

            return helper.GetJSONInfo("select distinct *,'ValidateHour'=12,CONVERT(varchar(100), RRAStartDate, 20) as StartDate,CONVERT(varchar(100), RRAEndDate, 20) as EndDate,CONVERT(varchar(100), getdate(), 20) as SysDate,CONVERT(varchar(100), rracreateddate, 20) as CreatedOn,convert(varchar(100),DATEADD(MINUTE,20,rracreateddate),20) as ExpireDate,  RRANationName as Password from v_RentHistory_view  left join Sys_RedPackage r on r.RedPackageObject = RentNO and r.RedPackageStartDate <=GETDATE() and r.RedPackageEndDate>GETDATE()  where RRAIDCard='" + idCard + "' order by RRACreatedDate desc");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCard">获取某人的租房历史</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentOwnerHistory(string idCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }

            RentAttributeHelper aHelper = new RentAttributeHelper();
            aHelper.ExpiredOrders();

            RentInfoHelper helper = new RentInfoHelper();
            string sql = "select v.*,r.*,'ValidateHour'=12,   CONVERT(varchar(100), v.RRAStartDate, 20) as StartDate,CONVERT(varchar(100), v.RRAEndDate, 20) as EndDate,CONVERT(varchar(100), getdate(), 20) as SysDate,CONVERT(varchar(100), rracreateddate, 20) as CreatedOn,convert(varchar(100),DATEADD(MINUTE,20,rracreateddate),20) as ExpireDate,  RRANationName as Password, " +
            "p.strStatus,p.strType,AlertStatus= case when strStatus='1' then " +
            "case when SUBSTRING(strType,2,1)='1' then '2' else '1' end " +
            "else '0' end " +
            "from v_RentHistory_view v " +
            "left join Sys_RedPackage r on r.RedPackageObject = RentNO and r.RedPackageStartDate <=GETDATE() and r.RedPackageEndDate>GETDATE() " +
            "left join v_PersonAlert_View p on p.ObjectID = RRAID " +
            "where RIDCard='" + idCard + "'  order by RRACreatedDate desc";
            return helper.GetJSONInfo(sql);
        }



        /// <summary>
        /// 获取房产性质
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseProperty()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=8");
        }

        /// <summary>
        /// 获取租赁类型
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseRentType()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=26");
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string SendMessageToPlice(string rentNo, string sign)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //string msg = "[温馨提示]尊敬的用户，您本次办理业务的短信验证码为991855，有效期为10分钟，请尽快办理。";
            string msg = "[温馨提示]尊敬的用户，您辖区内{0}的出租屋已经出租。";
            if (sign.Equals("0"))
            {
                msg = "[温馨提示]尊敬的用户，您辖区内{0}的出租屋已经出租。";
            }
            else
            {
                msg = "[温馨提示]尊敬的用户，您辖区内{0}的出租屋已经空置。";
            }
            string police = string.Empty;
            DataSet ds1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand("select RAddress,RPSName from rent_rent where rentNO='" + rentNo + "'"));
            if (ds1.Tables[0].Rows.Count > 0)
            {
                msg = string.Format(msg, ds1.Tables[0].Rows[0]["RAddress"].ToString());
                police = ds1.Tables[0].Rows[0]["RPSName"].ToString();
            }
            else
            {
                dic.Add("ret", "1");
            }
            DataSet ds = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand("select PSContactTel from Rent_PoliceStation where PSID=" + police));
            if (ds.Tables[0].Rows.Count > 0)
            {
                string phone = ds.Tables[0].Rows[0]["PSContactTel"].ToString();
                string msg1 = LigerRM.Common.Global.GSMHelper.SendMessage(phone, msg);
                dic.Add("ret", "0");
                dic.Add("phone", phone);
                dic.Add("msg", msg1);
            }
            else
            {
                dic.Add("ret", "1");
            }
            return JSONHelper.ToJson(dic);
        }

        /// <summary>
        /// 获取房屋所有类型
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHouseOwnType()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=27");
        }

        /// <summary>
        /// 删除房屋信息
        /// </summary>
        /// <param name="houseNo">房屋编码</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string DeleteHouseInfo(string houseNo)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            try
            {
                RentInfoHelper helper = new RentInfoHelper();
                helper.GetJSONInfo("update Rent_Rent set isObsoleted = 1 where RentNO='" + houseNo.Replace(" ", "") + "'");
                return "true";
            }
            catch (Exception ex)
            {
                return "false";
            }

        }



        /// <summary>
        /// 获取国籍列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetNationnalityList()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=19");
        }

        /// <summary>
        /// 获取省份
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetProvinceList()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_RentSystemOption where RSOParentNo=18");
        }


        /// <summary>
        /// 根据经纬度获取地址
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetAddress(string lat, string lng)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string res = "";

            string url = "http://api.map.baidu.com/geocoder?output=json&location=" + lat + ",%20" + lng + "&key=37492c0ee6f924cb5e934fa08c6b1676";
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

        [WebMethod]
        [SoapHeader("authentication")]
        public string HelloWord(string user, string pass, string timestamp, string token)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            if (authentication.ValideUser())
            {
                return "Hello word!";
            }
            else
            {
                return "{'headerError'}"; //"InValide:{UserID:" + authentication.UserID + ",Password:" + authentication.PassWord + ",TimeStamp:" + authentication.TimeStamp + ",Token:" + authentication.Token + "}";
            }
        }

        /// <summary>
        /// 根据地址获取经纬度
        /// </summary>
        /// <param name="address">具体地址</param>
        /// <param name="city">城市</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
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

        /// <summary>
        /// 查询房源信息
        /// </summary>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="pageIndex">第几页，从1开始</param>
        /// <param name="housetype">房型（GetHouseType获取，传RSONo）</param>
        /// <param name="rentType">租赁类型，1：月租，0：日租</param>
        /// <param name="address">地址</param>
        /// <param name="isAvalible">租赁状态，0：可租，1：不可租</param>
        /// <param name="userID">登录用户ID，租户app里面用固定值1</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHousesByCondition(int pageSize, int pageIndex, string housetype, string rentType, string address, string isAvalible, string userID, string startdate, string endate)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            string where = "1=1 and isObsoleted=0 ";
            if (!string.IsNullOrEmpty(housetype))
                where += " and RRoomType='" + housetype + "'";
            if (!string.IsNullOrEmpty(rentType))
                where += " and RRentType='" + rentType + "'";
            if (!string.IsNullOrEmpty(address))
                where += " and RAddress like '%" + address + "%'";

            string dateSql = "select distinct rentno from Rent_RentAttribute where (((rrastartdate BETWEEN '" + startdate + "' and '" + endate + "') or (rraenddate BETWEEN '" + startdate + "' and '" + endate + "')) or ((rrastartdate <'" + startdate + "' and rraenddate>'" + endate + "'))) and rrastatus in ('0','1','2','6')";
            //DataTable dateDt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(dateSql)).Tables[0];
            //dateSql = string.Empty;
            //foreach (DataRow row in dateDt.Rows)
            //{
            //    dateSql += "'" + row["rentno"].ToString() + "',";
            //}

            //dateSql = " and rentno not in (" + dateSql + "'')";
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

            //where += dateSql;
            where += " and Region NOT IN (" + dateSql + ")";
            System.Data.SqlClient.SqlDataReader r = helper.GetList(pageSize, pageIndex, "v_RentDetail_view", "RID", where, "*", "RCreatedDate", true);
            var list = new List<Hashtable>();
            list = JSONHelper.DbReaderToHash(r);
            //查询所有数据
            string sqlArray = string.Empty;
            for (int j = 0; j < list.Count; j++)
            {

                //if (list[j]["Region"] != tempStr)
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

        /// <summary>
        /// 查询房源信息
        /// </summary>
        /// <param name="housetype">房型（GetHouseType获取，传RSONo）</param>
        /// <param name="rentType">租赁类型，1：月租，0：日租</param>
        /// <param name="address">地址</param>
        /// <param name="isAvalible">租赁状态，0：可租，1：不可租</param>
        /// <param name="userID">登录用户ID，租户app里面用固定值1</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHousesCountByCondition(string housetype, string rentType, string address, string isAvalible, string userID)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string where = "1=1 and isObsoleted=0 ";
            if (!string.IsNullOrEmpty(housetype))
                where += " and RRoomType='" + housetype + "'";
            if (!string.IsNullOrEmpty(rentType))
                where += " and RRentType='" + rentType + "'";
            if (!string.IsNullOrEmpty(address))
                where += " and RAddress like '%" + rentType + "%'";
            if (!string.IsNullOrEmpty(isAvalible))
                where += " and Available=" + isAvalible;

            RentInfoHelper helper = new RentInfoHelper();
            if (!userID.Equals("1"))
            {
                string tempStr = string.Empty;
                int user = 0;
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

            DataTable dt1 = helper.GetList("v_RentDetail_view", "RID", where, "*", "RCreatedDate", true);
            return dt1.Rows.Count.ToString();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="oldPassword">老密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string ChangePassword(string username, string oldPassword, string newPassword, string userType)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            string tempPass = Encrypt.DESEncrypt(newPassword);
            if (ValidateLogin(username, oldPassword, userType).ToLower().Equals("true"))
            {
                helper.GetJSONInfo("update cf_user set LoginPassword='" + tempPass + "' where LoginName='" + username + "'");
                return "true";
            }
            else
            {
                return "false";
            }
        }

        /// <summary>
        /// 返回租房人以往的租住信息
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentInfo(string idcard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            //select * from dbo.v_RentHistory_view where RIDCard=
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from dbo.v_RentHistory_view where RRAIDCard='" + idcard + "'");
        }

        /// <summary>
        /// 返回房东名下的房屋列表
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentList(string idcard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            //select * from dbo.v_RentHistory_view where RIDCard=
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select dbo.v_RentDetail_view.*, dbo.Rent_Locks.DeviceID from dbo.v_RentDetail_view left join  dbo.Rent_Locks on(dbo.v_RentDetail_view.RentNO=dbo.Rent_Locks.RentNo) where RIDCard='" + idcard + "' and isObsoleted = '0'");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RentNO"></param>
        /// <param name="fileName"></param>
        /// <param name="memo"></param>
        /// <param name="userId"></param>
        /// <param name="data"></param>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddRentImage(string RentNO, string fileName, string memo, string userId, string imageStr)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            byte[] data = Convert.FromBase64String(imageStr);
            //FileStream fs = new FileStream(Server.MapPath("~") + "\\UploadedFiles\\" + RentNO + ".jpg", FileMode.Create);
            try
            {

                //fs.Write(data, 0, data.Length);
                //fs.Close();
                //fs.Dispose();
                //LigerRM.Common.GZipHelper.CompressFile(Server.MapPath("~") + "\\UploadedFiles\\" + RentNO + ".jpg", Server.MapPath("~") + "\\UploadedFiles\\" + RentNO + ".gz");
                string guid = Guid.NewGuid().ToString();
                RentImageHelper helper = new RentImageHelper();
                helper.AddRentImage(guid, RentNO, fileName, memo, userId);
                //FileStream fr = new FileStream(Server.MapPath("~") + "\\UploadedFiles\\" + RentNO + ".jpg", FileMode.Open);
                //byte[] data1 = new byte[fr.Length];
                //try
                //{
                //    fr.Read(data1, 0, (int)fr.Length);
                //    fr.Close();
                //    fr.Dispose();
                //byte[] zipData = LigerRM.Common.GZipHelper.Compress(data);
                helper.UpdateRentImage(guid, memo, data);
                ret.Add("ret", "0");
                //}
                //catch (Exception ex)
                //{
                //    ret.Add("ret", "1");
                //    ret.Add("msg", ex.Message);
                //}
                //finally
                //{
                //    fr.Close();
                //    fr.Dispose();
                //}

            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }
        //获取图片
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentImageList(string rentNo)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            var retDate = new Hashtable();
            RentImageHelper helper = new RentImageHelper();
            string count = string.Empty;
            List<Hashtable> images = helper.GetRentImages(rentNo, out count);
            retDate.Add("RentNO", rentNo);
            retDate.Add("count", count);
            for (int i = 0; i < images.Count; i++)
            {
                retDate.Add("ImageId" + i, images[i]["ImageId"].ToString());
                retDate.Add("Image" + i, images[i]["ImagePath"].ToString());
            }
            return JSONHelper.ToJson(retDate);
        }

        //删除图片
        [WebMethod]
        [SoapHeader("authentication")]
        public string DelRentImageList(string ImageId, string ImagePath)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                RentImageHelper helper = new RentImageHelper();
                helper.DelRentImages(ImageId, ImagePath);
                ret.Add("ret", "0");
                ret.Add("msg", "Success");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateOrderInfo(string id, string appId, string body, string mchId, string tradeNo, string fee, string prepayId, string ownerIdCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                RentAttributeHelper helper = new RentAttributeHelper();
                helper.UpdateOrderInfo(id, appId, body, mchId, tradeNo, fee, prepayId);

                //helper.UpdateUserWallet(ownerIdCard, fee, "0");

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

        [WebMethod]
        [SoapHeader("authentication")]
        public string CanOpenDoor(string lockId, string idCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = "select * from rent_locks l inner join rent_rent r on r.rentNo = l.rentNo where l.DeviceID='" + lockId + "' and (Status='0' or status='2')";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sql = "select * from Rent_RentAttribute where rentNO='" + dt.Rows[0]["RentNO"].ToString() + "' and rrastartdate <='" + DateTime.Now.ToString() + "' and rraEndDate>='" + DateTime.Now.ToString() + "' and rraisactive=0 and rrastatus='2' and RRAIDCard='" + idCard + "'";
                dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ret.Add("ret", "0");
                    ret.Add("msg", "可以开锁！");
                }
                else
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "您无权对此智能锁进行操作！");
                }
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", "您无权对此智能锁进行操作！");
            }

            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 是否能租
        /// </summary>
        /// <param name="rentNo"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string CanRentTheHouse(string rentNo, string startdate, string enddate)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = "select * from dbo.v_RentHistory_view where  IsExpired='0' and rrastatus in ('2', '9', '6', '3') and rentno = '" + rentNo + "'" +
                "and ((RRAEndDate >'" + enddate + "' and RRAStartDate<='" + enddate + "') or ('" + startdate + "'>=RRAStartDate and '" + startdate + "'<RRAEndDate) or ('" + startdate + "'<=RRAStartDate and '" + enddate + "'>=RRAEndDate))";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            RentInfoHelper helper = new RentInfoHelper();
            string returnStr = helper.GetJSONInfo(sql);

            if (string.IsNullOrEmpty(returnStr) || returnStr.Equals("[]"))
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("RentRecord", returnStr);
            }
            return JSONHelper.ToJson(ret);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHoseRentHistory(string rentNo, string startdate, string enddate)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = "select * from dbo.v_RentHistory_view where  IsExpired='0' and rrastatus in ('2', '5', '6', '11', '3') and rentno = '" + rentNo + "'" +
                "and ((RRAEndDate >'" + enddate + "' and RRAStartDate<='" + enddate + "') or ('" + startdate + "'>=RRAStartDate and '" + startdate + "'<RRAEndDate) or ('" + startdate + "'<=RRAStartDate and '" + enddate + "'>=RRAEndDate))";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            RentInfoHelper helper = new RentInfoHelper();
            string returnStr = helper.GetJSONInfo(sql);

            if (string.IsNullOrEmpty(returnStr) || returnStr.Equals("[]"))
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("RentRecord", returnStr);
            }
            return JSONHelper.ToJson(ret);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string OpenDoor(string lockId)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = "select TOP 1 * from Rent_Locks where DeviceID='" + lockId + "' order by ID desc";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DeviceType"].ToString() == "1")  //新锁
                {
                    NewLockManager managerNew = new NewLockManager();
                    string newLock = managerNew.openDoor(lockId);
                    Dictionary<string, object> returnInfo = new Dictionary<string, object>();
                    returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(newLock);
                    if (returnInfo["ret"].ToString() == "0")
                    {
                        ret.Add("ret", "0");
                    }
                    else
                    {
                        ret.Add("ret", "1");
                    }
                    ret.Add("msg", returnInfo["msg"].ToString());
                }
                else
                {
                    LockManager manager = new LockManager();
                    string r = manager.UnLockDevice(lockId);
                    if (string.IsNullOrEmpty(r))
                    { }
                    else
                    {
                        if (r.Substring(0, 1).Equals("0"))
                        {
                            ret.Add("ret", r.Substring(0, 1));
                            ret.Add("LockID", r.Substring(1));
                            ret.Add("msg", "开锁成功");
                        }
                        else if (r.Substring(0, 1).Equals("1"))
                        {
                            ret.Add("ret", r.Substring(0, 1));
                            ret.Add("LockID", r.Substring(1));
                            ret.Add("msg", "已执行开锁操作，但未成功！");
                        }
                        else if (r.Substring(0, 1).Equals("2"))
                        {
                            ret.Add("ret", r.Substring(0, 1));
                            ret.Add("LockID", r.Substring(1));
                            ret.Add("msg", "开锁超时，请重新操作！");
                        }
                        else
                        {
                            ret.Add("ret", r.Substring(0, 1));
                            ret.Add("LockID", r.Substring(1));
                            ret.Add("msg", "开锁失败！");
                        }
                    }
                }
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", "未查到任何锁相关信息！");
            }

            return JSONHelper.ToJson(ret);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string AddRentExternalInfo(string RentNo, string desc)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                RentInfoHelper helper = new RentInfoHelper();
                helper.UpdateRentExternal(RentNo, desc);
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

        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentExternalInfo(string RentNo)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_External where Rent_NO='" + RentNo + "'");

        }

        /// <summary>
        /// 更新钱包
        /// </summary>
        /// <param name="idCard"></param>
        /// <param name="fee"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateUserWallet(string idCard, string fee, string type)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentAttributeHelper helper = new RentAttributeHelper();
            return helper.UpdateUserWallet(idCard, fee, type);

        }

        /// <summary>
        /// 钱包充值
        /// </summary>
        /// <param name="idCard"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string DepositWallet(string idCard, string fee)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            //Dictionary<string, string> ret = new Dictionary<string, string>();
            //ret.Add("ret", "0");
            RentAttributeHelper helper = new RentAttributeHelper();
            string ret = helper.DepositUserWallet(idCard, fee);
            helper.AddBillLog2(idCard, idCard, fee);
            return ret;
        }


        /// <summary>
        /// 钱包支付
        /// </summary>
        /// <param name="rennteeIDCard"></param>
        /// <param name="ownerIDCard"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string PayUseWallet(string rennteeIDCard, string ownerIDCard, string money)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentAttributeHelper helper = new RentAttributeHelper();
            string ret = helper.CanPayFromWallet(rennteeIDCard, money);

            Dictionary<string, string> retDic = JSONHelper.FromJson<Dictionary<string, string>>(ret);
            if (retDic["ret"].Equals("0"))
            {
                return helper.PayUseWallet(rennteeIDCard, ownerIDCard, money);
            }
            else
            {
                return JSONHelper.ToJson(retDic);
            }
        }

        /// <summary>
        /// 获取智能锁信息（添加新锁）
        /// </summary>
        /// <param name="rentNO"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddPasswordToLock(string rentNO, string pass, string startdate, string enddate, string userId)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = "select * from Rent_Locks where rentNo='" + rentNO + "' and Status='0'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DeviceType"].ToString() == "1") //新锁
                {
                    NewLockManager managerNew = new NewLockManager();
                    managerNew.GetPostInterface(dt.Rows[0]["DeviceID"].ToString(), userId, "2", pass, startdate, enddate); //设置临时密码
                }
                else //旧锁
                {
                    LockManager manager = new LockManager();
                    manager.AddPassword(dt.Rows[0]["DeviceID"].ToString(), pass, startdate, enddate);
                    string r = manager.UpdatePassengerInfoToDevice(dt.Rows[0]["DeviceID"].ToString(), "", "", "", pass, DateTime.Parse(startdate).ToString("yyyyMMddHHmm").Substring(2, 10), DateTime.Parse(enddate).ToString("yyyyMMddHHmm").Substring(2, 10), "3");
                }
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", "未发现智能锁信息，无法添加密码");
            }
            return JSONHelper.ToJson(ret);
        }



        [WebMethod]
        [SoapHeader("authentication")]
        public string ClearPasswordToLock(string aarId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            RentAttribute a = new RentAttribute(int.Parse(aarId));
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand("select * from Rent_Locks where rentno='" + a.RentNo + "'")).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string returnStr1 = string.Empty;
                if (dt.Rows[0]["DeviceType"].ToString() == "1") //新锁
                {
                    NewLockManager managerNew = new NewLockManager();
                    //清空临时卡
                    string iCCard = managerNew.delAction(a.RRAContactTel, "临时卡片", a.RRAStartDate.ToString(), a.RRAEndDate.ToString(), dt.Rows[0]["DeviceID"].ToString(), "1");
                    //清空临时密码
                    string password = managerNew.delAction(a.RRAContactTel, "临时密码", a.RRAStartDate.ToString(), a.RRAEndDate.ToString(), dt.Rows[0]["DeviceID"].ToString(), "1");
                    Dictionary<string, object> retIC = new Dictionary<string, object>();
                    retIC = JSONHelper.FromJson<Dictionary<string, object>>(iCCard);
                    Dictionary<string, object> retPass = new Dictionary<string, object>();
                    retPass = JSONHelper.FromJson<Dictionary<string, object>>(password);
                    if (retIC["ret"].ToString() == "1" || retPass["ret"].ToString() == "1")
                    {
                        returnStr1 = "ICCard:" + retIC["msg"].ToString() + "Pass:" + retPass["msg"].ToString();
                    }
                }
                else  //旧锁
                {
                    string sql = "select * from Rent_Locks_ICCards where LockID='" + dt.Rows[0]["DeviceID"].ToString() + "' and StartDate='" + a.RRAStartDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and EndDate='" + a.RRAEndDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                    LockManager manager = new LockManager();
                    DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    foreach (DataRow row in dt1.Rows)
                    {
                        string returnStr = manager.UpdatePassengerInfoToDevice(dt.Rows[0]["DeviceID"].ToString(), row["ICCard"].ToString(), "", "", "", a.RRAStartDate.ToString("yyyyMMddHHmm").Substring(2, 10), a.RRAEndDate.ToString("yyyyMMddHHmm").Substring(2, 10), "2");
                    }

                    returnStr1 = manager.UpdatePassengerInfoToDevice(dt.Rows[0]["DeviceID"].ToString(), "", "", "", a.RRANationName, a.RRAStartDate.ToString("yyyyMMddHHmm").Substring(2, 10), a.RRAEndDate.ToString("yyyyMMddHHmm").Substring(2, 10), "4");
                }

                dic.Add("ret", "0");
                dic.Add("msg", returnStr1);
            }
            else
            {
                dic.Add("ret", "1");
                dic.Add("msg", "未发现智能锁信息，无法添加密码");
            }
            return JSONHelper.ToJson(dic);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string GetSystemClock()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 添加账单记录
        /// </summary>
        /// <param name="renteeIDCard"></param>
        /// <param name="ownerIDCard"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddBillLog(string renteeIDCard, string ownerIDCard, string fee, string type)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            RentAttributeHelper helper = new RentAttributeHelper();
            return helper.AddBillLog(renteeIDCard, ownerIDCard, fee, type);
        }

        /// <summary>
        /// 获取账单记录
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetBillLog(string idCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from sys_bill where PayTo='" + idCard + "' or Payfrom='" + idCard + "' order by paydate desc");
        }

        /// <summary>
        /// 跟更新推送设备信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateDeviceID(string userId, string deviceId)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "update cf_user set fax = '" + deviceId + "' where LoginName='" + userId + "'";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                ret.Add("ret", "0");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 获取费率信息
        /// </summary>
        /// <param name="fee"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetPayRateDesc(string fee)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string rate = ConfigurationManager.AppSettings["FeeRate"];
            if (decimal.Parse(rate) > 0)
            {
                ret.Add("ret", "0");
                ret.Add("rate", rate);
                ret.Add("fee", string.Format("{0:00.00}", (decimal.Parse(fee) * (decimal.Parse(rate)))));
                ret.Add("msg", "费用金额为：" + fee + "元，平台收取" + string.Format("{0:0.00%}", decimal.Parse(rate)) + "的手续费，实际入账金额为" + string.Format("{0:00.00}", (decimal.Parse(fee) * (1 - decimal.Parse(rate)))) + "元");
            }
            else
            {
                ret.Add("ret", "0");
                ret.Add("rate", "0");
                ret.Add("fee", string.Format("{0:00.00}", (decimal.Parse(fee) * (decimal.Parse(rate)))));
                ret.Add("msg", "优惠期内，免收平台手续费！");
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 推送信鸽消息到某个设备
        /// </summary>
        /// <param name="togleId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string SendMessageToDevice(string togleId, string message, string rraid, string idCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            LockManager manager = new LockManager();
            return manager.SendMessageToDevice(togleId, message, rraid, idCard);
        }

        /// <summary>
        /// 是否存在电话号码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string IsExistsPhone(string phone)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                SignetHelper helper = new SignetHelper();
                string sql = string.Empty;
                sql = "select * from cf_user where Phone='" + phone + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ret.Add("ret", "2");
                    ret.Add("msg", "电话号码已存在");
                }
                else
                {
                    ret.Add("ret", "0");
                    ret.Add("msg", "电话号码可以使用");
                }
            }
            catch (Exception ex)
            {
                ret.Add("1", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }


        /// <summary>
        /// 是否存在身份证号
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string IsExistsIDCard(string idcard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                SignetHelper helper = new SignetHelper();
                string sql = string.Empty;
                sql = "select * from cf_user where IDCard='" + idcard + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ret.Add("ret", "2");
                    ret.Add("msg", "身份证号码已存在");
                }
                else
                {
                    ret.Add("ret", "0");
                    ret.Add("msg", "身份证号码可以使用");
                }
            }
            catch (Exception ex)
            {
                ret.Add("1", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 绑定银行卡
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankName"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateCreditCard(string idcard, string cardNo, string bankName)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                RentAttributeHelper helper = new RentAttributeHelper();
                helper.UpdateCreditCard(idcard, cardNo, bankName);
                ret.Add("ret", "0");
                ret.Add("msg", "Success");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }


        [WebMethod]
        [SoapHeader("authentication")]
        public string ForgotPassword(string LoginName, string newPassword)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                RentInfoHelper helper = new RentInfoHelper();
                string tempPass = Encrypt.DESEncrypt(newPassword);
                helper.GetJSONInfo("update cf_user set LoginPassword='" + tempPass + "' where LoginName='" + LoginName + "'");
                ret.Add("ret", "0");
                ret.Add("msg", "Success");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 申请退房退房
        /// </summary>
        /// <param name="rraId"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string ApplyCheckOut(string rraId, string applyer, string reason)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";

            //}

            string sql = "update Rent_RentAttribute set rrarealenddate='" + DateTime.Now.ToString() + "',RRACheckOutReason='" + reason + "',RRACheckOutPerson='" + applyer + "',RRAStatus='" + ((int)RentAttributeHelper.AttributeStatus.NeedConfirmCheckOut).ToString() + "' where RRAID=" + rraId;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            sql = "select * from Rent_RentAttribute where rraid=" + rraId;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                CFUserInfo applyUser = new CFUserInfo(applyer);
                RentInfo house = new RentInfo(dt.Rows[0]["RentNo"].ToString());
                CFUserInfo userInfo = new CFUserInfo(dt.Rows[0]["RRAIDCard"].ToString(), false);
                LockManager manager = new LockManager();
                string applyMsg = ConfigurationManager.AppSettings["ApplyCheckOutMessage"].ToString();
                if (applyUser.IDCard == dt.Rows[0]["RRAIDCard"].ToString())
                {
                    CFUserInfo owner = new CFUserInfo(house.RIDCard, false);
                    manager.SendMessageToDevice(owner.DeviceID, applyMsg, rraId, owner.IDCard);
                }
                else
                    manager.SendMessageToDevice(userInfo.DeviceID, applyMsg, rraId, userInfo.IDCard);
            }

            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            ret.Add("msg", "Success");
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 确认退房
        /// </summary>
        /// <param name="rraId"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string ConfirmCheckOut(string rraId)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";

            //}

            string sql = "update Rent_RentAttribute set RRAStatus='" + ((int)RentAttributeHelper.AttributeStatus.CheckedOut).ToString() + "' where RRAID=" + rraId;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            //清除密码
            ClearPasswordToLock(rraId);

            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            ret.Add("msg", "Success");
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 获取过期时间
        /// </summary>
        /// <param name="rraId"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetExpireTime(string rraId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";

            }

            string sql = "update Rent_RentAttribute set RRAStatus='" + ((int)RentAttributeHelper.AttributeStatus.NeedPay).ToString() + "' where RRAID=" + rraId;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            ret.Add("msg", "Success");
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 确认退房
        /// </summary>
        /// <param name="rraId"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string ExpiredOrder(string rraId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";

            }

            string sql = "update Rent_RentAttribute set RRAStatus='" + ((int)RentAttributeHelper.AttributeStatus.Expired).ToString() + "' where RRAID=" + rraId;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            //sql = "select * from sys_redPackage where " +
            //        " RedPackageObject=( select rentno from Rent_RentAttribute where rraid= "+rraId.ToString()+") " +
            //        " and RedPackageStatus='1'" +
            //        " and RedPackageStartDate<=GETDATE()" +
            //        " and RedPackageEndDate>GETDATE()";

            //DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    sql = "update sys_redPackage set RedPackageStatus='0',memo='' where RedPackageID='" + dt.Rows[0]["RedPackageID"] + "'";
            //    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            //}

            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            ret.Add("msg", "Success");
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 添加评价
        /// </summary>
        /// <param name="evaObject"></param>
        /// <param name="evaType"></param>
        /// <param name="service"></param>
        /// <param name="enviroment"></param>
        /// <param name="cost"></param>
        /// <param name="desc"></param>
        /// <param name="evaPerson"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddEvaluation(string orderId, string evaObject, string evaType, string service, string enviroment, string cost, string desc, string evaPerson)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";

            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                Evaluate eva = new Evaluate();
                eva.EvaluateID = Guid.NewGuid().ToString();
                eva.EvaluateObject = evaObject;
                eva.EvaluateType = evaType;
                eva.EvaluateItem0 = decimal.Parse(service);
                eva.EvaluateItem1 = decimal.Parse(enviroment);
                eva.EvaluateItem2 = decimal.Parse(cost);
                eva.EvaluateDesc = desc;
                eva.EvaluateItem3 = 0;
                eva.EvaluateItem4 = 0;
                eva.EvaluatePerson = evaPerson;
                eva.EvaluateDate = DateTime.Now;

                EvaluateHelper helper = new EvaluateHelper();
                helper.AddEvaluate(eva);

                RentAttributeHelper helper1 = new RentAttributeHelper();
                helper1.UpdateEvaluatedStatus(orderId, ((int)RentAttributeHelper.AttributeStatus.Evaluated).ToString());

                ret.Add("ret", "0");
                ret.Add("msg", "Success");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 获取评价列表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetEvaluationList(string obj)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                RentInfoHelper helper = new RentInfoHelper();
                string returnStr = helper.GetJSONInfo("select * from v_Rent_Evaluation_view where RentNO = '" + obj + "'");
                ret.Add("ret", "0");
                ret.Add("msg", returnStr);
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }


        /// <summary>
        /// 获取评价列表
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetEvaluationPersonList(string obj)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                RentInfoHelper helper = new RentInfoHelper();
                string returnStr = helper.GetJSONInfo("select * from dbo.Rent_Evaluate where EvaluateObject = '" + obj + "'");
                ret.Add("ret", "0");
                ret.Add("msg", returnStr);
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 是否存在相同的房源地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string IsExistsSameAddress(string address)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "select * from rent_rent where RAddress='" + address + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    ret.Add("ret", "0");
                    ret.Add("msg", "地址可以使用");
                }
                else
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "该房源地址已经存在，无法录入同样的地址！");
                }
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }


        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateRentInfo(string RentNo, string RDName, string RSName, string RRName, string RPSName, string RAddress,
            string RDoor, string RTotalDoor, string RRoomType, string RDirection, string RStructure, string RBuildingType, string RFloor, string RTotalFloor, string RHouseAge,
            decimal RRentArea, string RProperty, string ROwner, string ROwnerTel, string RIDCard, string RLocationDescription, string RPSParentName, string createdBy, string rentType, string ownType)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfo rentInfo = new RentInfo(RentNo);
            rentInfo.RentNo = RentNo;
            RentInfoHelper helper = new RentInfoHelper();

            rentInfo.RDName = RDName;
            rentInfo.RSName = RSName;
            rentInfo.RRName = RRName;

            rentInfo.RPSParentName = RPSParentName;
            rentInfo.RPSName = RPSName;
            rentInfo.RPSID = RPSName;

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


        //录入身份证  rraid  订单ID
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddIDCardToDevice(string idcard, string deviceId, string rraId)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            Dictionary<string, string> ret = new Dictionary<string, string>();

            string sql = "select * from v_RentHistory_view where RRAIDCard='" + idcard + "' and DeviceID='" + deviceId + "' and RRAStartDate<='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and RRAEndDate>'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and RRAID='" + rraId + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DeviceType"].ToString() == "1")  //新锁
                {
                    NewLockManager managerNew = new NewLockManager();
                    string retNew = managerNew.GetPostInterface(deviceId, dt.Rows[0]["RRAContactTel"].ToString(), "4", "", dt.Rows[0]["RRAStartDate"].ToString(), dt.Rows[0]["RRAEndDate"].ToString());
                    Dictionary<string, object> returnInfo = new Dictionary<string, object>();
                    returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(retNew);
                    if (returnInfo["ret"].ToString() == "1")
                    {
                        return retNew;
                    }
                }
                else //旧锁
                {
                    LockManager manager = new LockManager();
                    string r = manager.UpdatePassengerInfoToDevice(deviceId, "", "", "", "", DateTime.Parse(dt.Rows[0]["RRAStartDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10), DateTime.Parse(dt.Rows[0]["RRAEndDate"].ToString()).ToString("yyyyMMddHHmm").Substring(2, 10), "7");
                }

                ret.Add("ret", "0");
                ret.Add("msg", "success");
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", "您无权对此智能锁进行操作，或者因为租约未开始！请在租约日期生效后再进行操作！");
            }
            return JSONHelper.ToJson(ret);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string GetOrderStatus(string rraId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }

            Dictionary<string, string> ret = new Dictionary<string, string>();

            try
            {
                RentAttribute a = new RentAttribute(int.Parse(rraId));
                ret.Add("ret", "0");
                ret.Add("msg", "success");
                ret.Add("status", a.Status);
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }

            return JSONHelper.ToJson(ret);
        }


        /// <summary>
        /// 添加随行人员
        /// </summary>
        /// <param name="rraId"></param>
        /// <param name="createdBy"></param>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddRetinues(string rraId, string createdBy, string jsonstr)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            List<Retinue> retinues = new List<Retinue>();
            //[{"PartnerName":"张三","PartnerIdCard":"130133199302243318"},{"PartnerName":"张三","PartnerIdCard":"130133199302243318"}]
            retinues = JSONHelper.FromJson<List<Retinue>>(jsonstr);

            try
            {

                foreach (Retinue rentinue in retinues)
                {
                    string sql = "Insert into Rent_Retinues values ('" + Guid.NewGuid().ToString() + "','" + rentinue.PartnerIdCard + "','" + rentinue.PartnerName + "','" + rraId + "','" + createdBy + "','" + DateTime.Now.ToString() + "','')";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
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

        /// <summary>
        /// 根据订单获取随行人员
        /// </summary>
        /// <param name="rraId"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRetinues(string rraId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_Retinues where RRAID='" + rraId + "'");
        }

        /// <summary>
        /// 获取常用随行人员
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRetinuesByIDCard(string idCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select distinct IDCard,Name from Rent_Retinues where CreatedBy='" + idCard + "'");
        }

        /// <summary>
        /// 修改随行人员信息
        /// </summary>
        /// <param name="rentinueId"></param>
        /// <param name="name"></param>
        /// <param name="idcard"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateRetinues(string rentinueId, string name, string idcard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "update Rent_Retinues set IDCard='" + idcard + "',Name='" + name + "' where RetinueID='" + rentinueId + "'";
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

        /// <summary>
        /// 删除随行人员信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string DeleteRetinue(string idcard, string createdBy)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "delete from Rent_Retinues where IDCard='" + idcard + "' and createdBy='" + createdBy + "'";
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

        /// <summary>
        /// 锁与房屋绑定
        /// </summary>
        /// <param name="deviceID">锁ID</param>
        /// <param name="rentId">房屋ID</param>
        /// <param name="lockType">0 旧锁  1 新锁</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string CreateLockDevice(string deviceID, string rentId, string lockType)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "insert into Rent_Locks values ('" + deviceID + "','" + lockType + "','" + 0 + "','" + rentId + "','" + 0 + "','" + DateTime.Now.ToString() + "','','" + 0 + "','" + 0 + "')";
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

        /// <summary>
        /// 查询当前用户金额
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetUserWallet(string jsonRequest)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> retJson = new Dictionary<string, string>();
            string jsonRequestInfo = Encrypt.AESDecode(jsonRequest);
            if (string.Empty == jsonRequestInfo) //aes校验
            {

                retJson.Add("ret", "1");  //失败
                retJson.Add("msg", "验证失败");
            }
            try
            {
                Dictionary<string, object> retRequest = new Dictionary<string, object>();
                retRequest = JSONHelper.FromJson<Dictionary<string, object>>(jsonRequestInfo);
                //查询金额
                string sql = "select * from v_CF_User_View where IDCard='" + retRequest["idCard"].ToString() + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    retJson.Add("ret", "1"); //暂无用户
                    retJson.Add("msg", "暂无用户");
                }
                else
                {
                    //收取手续费
                    //if ((Convert.ToDouble(dt.Rows[0]["Wallet"]) - Convert.ToDouble(retRequest["fee"])) >= 1)
                    if ((Convert.ToDouble(dt.Rows[0]["Wallet"]) - Convert.ToDouble(retRequest["fee"])) >= 0)
                    {
                        retJson.Add("ret", "0"); //成功
                        retJson.Add("msg", "success");
                    }
                    else
                    {
                        retJson.Add("ret", "1"); //失败
                        retJson.Add("msg", "金额不足,暂时无法提现");
                    }
                }
            }
            catch (Exception ex)
            {
                retJson.Add("ret", "1");  //异常
                retJson.Add("msg", ex.Message);
            }

            return JSONHelper.ToJson(retJson);

        }

        /// <summary>
        /// 增加提现log
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string CreateWithdrawalsLog(string jsonRequest)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
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
            //修改钱包金额
            RentAttributeHelper helper = new RentAttributeHelper();
            //平台手续费  暂时关闭
            //string fee = (Convert.ToDouble(retRequest["fee"].ToString()) + 1).ToString();
            string fee = (Convert.ToDouble(retRequest["fee"].ToString())).ToString();
            return helper.UpdateUserWallet(retRequest["idCard"].ToString(), fee, "1");
        }

        /// <summary>
        /// 增加提现返回log
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string CreateWithdrawalsReturnLog(string jsonRequest)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string jsonRequestInfo = Encrypt.AESDecode(jsonRequest);
            if (string.Empty == jsonRequestInfo) //aes校验
            {
                ret.Add("ret", "1");
                ret.Add("msg", "request json false");
                return JSONHelper.ToJson(ret);
            }
            Dictionary<string, object> retRequest = new Dictionary<string, object>();
            retRequest = JSONHelper.FromJson<Dictionary<string, object>>(jsonRequestInfo);
            try
            {

                //查询是否有提现申请
                string sqlWithdrawalsLog = "select * from CF_User_Withdrawals_Log where NoOrder= '" + retRequest["no_order"].ToString() + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlWithdrawalsLog)).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    ret.Add("ret", "2");//脏数据
                    ret.Add("msg", "false log");
                }
                //提现成功
                if (retRequest["Status"].ToString() == "0000" && retRequest["result_pay"].ToString() == "SUCCESS")
                {
                    //提现成功
                    string sqlUpdateWithdrawalsLog = "update CF_User_Withdrawals_Log set TradingState='" + 1 + "' where NoOrder='" + retRequest["no_order"].ToString() + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlUpdateWithdrawalsLog));
                    //添加账单明细
                    string sqlTX = "Insert into sys_bill values ('" + Guid.NewGuid().ToString() + "','平台提现','" + "云上之家服务平台" + "','" + dt.Rows[0]["IDCard"].ToString() + "','" + "2" + "','1','" + DateTime.Now.ToString() + "','支出'," + retRequest["money_order"].ToString() + ")";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlTX));
                    //手续费  暂时关闭
                    //string sqlSX = "Insert into sys_bill values ('" + Guid.NewGuid().ToString() + "','平台手续费','" + dt.Rows[0]["IDCard"].ToString() + "','" + "云上之家服务平台" + "','" + "1" + "','1','" + DateTime.Now.ToString() + "','支出'," + "1" + ")";
                    //MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlSX));
                }
                else
                {
                    //提现失败
                    string sqlUpdateWithdrawalsLog = "update CF_User_Withdrawals_Log set TradingState='" + 2 + "' where NoOrder='" + retRequest["no_order"].ToString() + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlUpdateWithdrawalsLog));
                    //防止外部恶意盗用

                    if (Convert.ToDouble(dt.Rows[0]["Free"]) - Convert.ToDouble(retRequest["money_order"]) == 0)
                    {
                        //修改钱包金额
                        RentAttributeHelper helper = new RentAttributeHelper();
                        Double fee = Convert.ToDouble(retRequest["money_order"].ToString());
                        //手续费   暂时关闭
                        //fee += 1;
                        helper.UpdateUserWallet(dt.Rows[0]["IDCard"].ToString(), fee.ToString(), "0");
                    }
                }
                //插入log数据
                string sql = "insert into CF_User_ReturnInfo_Log values ('" + Guid.NewGuid().ToString() + "','" + retRequest["Status"].ToString() + "','" + retRequest["sPara"].ToString() + "','" + retRequest["CreatedOn"].ToString() + "','" + retRequest["dt_order"].ToString() + "','" + retRequest["info_order"].ToString() + "','" + retRequest["money_order"].ToString() + "','" + retRequest["no_order"].ToString() + "','" + retRequest["oid_partner"].ToString() + "','" + retRequest["oid_paybill"].ToString() + "','" + retRequest["result_pay"].ToString() + "','" + retRequest["settle_date"].ToString() + "','" + retRequest["sign"].ToString() + "','" + retRequest["sign_type"].ToString() + "','" + DateTime.Now.ToString() + "')";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                ret.Add("ret", "0");
                ret.Add("msg", "success");
            }
            catch (Exception ex)
            {
                //提现异常
                string sqlUpdateWithdrawalsLog = "update CF_User_Withdrawals_Log set TradingState='" + 3 + "' where NoOrder='" + retRequest["no_order"].ToString() + "'";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlUpdateWithdrawalsLog));
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 获取提现状态
        /// </summary>
        /// <returns></returns>
        //[WebMethod]
        //[SoapHeader("authentication")]
        //public string GetWithdrawalsState(string IDCard)
        //{
        //    if (!authentication.ValideUser())
        //    {
        //        return "{'headerError'}";
        //    }
        //    Dictionary<string, string> ret = new Dictionary<string, string>();
        //    try
        //    {
        //        string sqlWithdrawalsLog = "select * from CF_User_Withdrawals_Log where IDCard= '" + IDCard + "'";
        //        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlWithdrawalsLog)).Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            ret.Add("state", dt.Rows[0]["TradingState"].ToString());  //0 提现中  1 提现成功   2 提现失败  3 提现异常
        //        } else {
        //            ret.Add("state", "4");  //4  暂无提现
        //        }
        //        ret.Add("ret", "0");
        //        ret.Add("msg", "success");
        //    }
        //    catch (Exception ex)
        //    {
        //        ret.Add("ret", "1");
        //        ret.Add("msg", ex.Message);
        //    }
        //    return JSONHelper.ToJson(ret);
        //}

        //        /// <summary>
        ///// 删除随行人员信息
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //[WebMethod]
        //[SoapHeader("authentication")]
        //public string DeleteRetinue(string Id)

        /// <summary>
        /// 开红包接口，
        /// </summary>
        /// <param name="id">红包ID</param>
        /// <param name="status">红包状态</param>
        /// <param name="type">房东还是房客开启，0：房东，1：房客</param>
        /// <param name="idCard">身份证号</param>
        /// <param name="money">钱数</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string TearOpenRedPackage(string id, string status, string type, string idCard, string money)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string sql = string.Empty;
            string statusStr = string.Empty;
            if (status == ((int)LigerRM.Common.RedPackageHelper.RedPackageHelper.RedPackageStatus.Used).ToString())
            {
                if (type == "0")
                    statusStr = ((int)LigerRM.Common.RedPackageHelper.RedPackageHelper.RedPackageStatus.PartPayed).ToString();
                else
                    statusStr = "5";
            }
            else
            {
                if (status == ((int)LigerRM.Common.RedPackageHelper.RedPackageHelper.RedPackageStatus.PartPayed).ToString() || status == "5")
                    statusStr = ((int)LigerRM.Common.RedPackageHelper.RedPackageHelper.RedPackageStatus.Payed).ToString();
            }
            if (type == "0")
            {
                sql = "update Sys_RedPackage set RedPackageStatus='" + statusStr + "',RentOwner='" + idCard + "',RentOwnerUpdatedOn='" + DateTime.Now.ToString() + "' where RedPackageID='" + id + "'";
            }
            else
            {
                sql = "update Sys_RedPackage set RedPackageStatus='" + statusStr + "',Rentee='" + idCard + "',RenteeUpdatedOn='" + DateTime.Now.ToString() + "' where RedPackageID='" + id + "'";
            }



            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

                //更新钱包
                RentAttributeHelper helper = new RentAttributeHelper();
                helper.UpdateUserWallet(idCard, money, "0");
                //UpdateUserWallet(idCard, money, "0");
                //添加纪录
                helper.AddBillLog3("", idCard, money);

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

        /// <summary>
        /// 创建小程序支付订单
        /// </summary>
        /// <param name="rraId"></param>
        /// <param name="title"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string PayWithWeChartByJs(string rraId, string Idcard, string title, string money, string openId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string APP_ID = "wx9988d8c301815f63";
            string WX_PARTNER_ID = "1481965242";
            string SIGN_KEY = "413ac6a2651c14455ec7a0cd498ab6d8";

            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            ret.Add("APP_ID", APP_ID);
            ret.Add("WX_PARTNER_ID", WX_PARTNER_ID);
            ret.Add("SIGN_KEY", SIGN_KEY);

            string Body = string.Empty;  //订单描述
            string Subject = string.Empty;//订单简介
            string TotalAmount = string.Empty;//金额
            string OutTradeNo = string.Empty;//订单号

            Body = "我是测试数据";
            Subject = "微信支付";
            TotalAmount = (double.Parse(money) * 100).ToString();

            int ranNumer = new Random().Next(1, 1000);
            OutTradeNo = "20170216test0170501111111S001111119" + ranNumer.ToString();

            //微信支付 基础配置信息
            string wx_appid = "wx9988d8c301815f63";//微信开放平台审核通过的应用
            string wx_mch_id = "1481965242"; //微信支付分配的商户号
            string wx_nonce_str = GetRandomString(16);//随机字符串，不长于32位
            string aa = title;////商品描述交易字段格式根据不同的应用场景按照以下格式：APP——需传入应用市场上的APP名字-实际商品名称，天天爱消除-游戏充值。

            string strcode = aa;
            byte[] buffer = Encoding.UTF8.GetBytes(strcode);
            string wx_body = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            string wx_out_trade_no = "CZ" + DateTime.Now.ToString("yyyyMMddHHmmss") + GetRandomString(10);//商户系统内部的订单号,32个字符内、可包含字母, 其他说明见商户订单号
            string wx_total_fee = TotalAmount;//;//订单总金额，单位为分，详见支付金额
            string wx_spbill_create_ip = GetWebClientIp();//// 	用户端实际ip
            //string wx_spbill_create_ip = "39.108.15.78";
            string wx_notify_url = "http://www.guardts.com/payment/WeChart_NotifyUrl.aspx";////接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
            string wx_trade_type = "JSAPI";////支付类型
            string wx_sign = "";// 签名
            string wx_key = "413ac6a2651c14455ec7a0cd498ab6d8"; //密钥

            var dic = new Dictionary<string, string>
            {
                {"appid", wx_appid},
                {"mch_id", wx_mch_id},
                {"nonce_str", wx_nonce_str},
                {"body", wx_body},
                {"out_trade_no", wx_out_trade_no},//商户自己的订单号码
                {"total_fee", wx_total_fee},
                {"spbill_create_ip",wx_spbill_create_ip},//服务器的IP地址
                {"notify_url", wx_notify_url},//异步通知的地址，不能带参数
                {"trade_type", wx_trade_type},
                {"openid", openId}
            };

            //加入签名
            dic.Add("sign", GetSignString(dic));

            var sb = new StringBuilder();
            sb.Append("<xml>");


            foreach (var d in dic)
            {
                sb.Append("<" + d.Key + ">" + d.Value + "</" + d.Key + ">");
            }
            sb.Append("</xml>"); var xml = new XmlDocument();
            //  xml.LoadXml(GetPostString("https://api.mch.weixin.qq.com/pay/unifiedorder", sb.ToString()));
            CookieCollection coo = new CookieCollection();
            Encoding en = Encoding.GetEncoding("UTF-8");
            LogManager.WriteLog("WeChartStart:" + sb.ToString());
            HttpWebResponse response = CreatePostHttpResponse("https://api.mch.weixin.qq.com/pay/unifiedorder", sb.ToString(), en);
            //打印返回值
            Stream stream = response.GetResponseStream();   //获取响应的字符串流
            StreamReader sr = new StreamReader(stream); //创建一个stream读取流
            string html = sr.ReadToEnd();   //从头读到尾，放到字符串html

            Console.WriteLine(html);
            xml.LoadXml(html);
            //对请求返回值 进行处理

            var root = xml.DocumentElement;

            DataSet ds = new DataSet();
            StringReader stram = new StringReader(html);
            XmlTextReader reader = new XmlTextReader(stram);
            ds.ReadXml(reader);
            string return_code = ds.Tables[0].Rows[0]["return_code"].ToString();
            LogManager.WriteLog("WeChartReturn:" + html);
            if (return_code.ToUpper() == "SUCCESS")
            {
                //通信成功
                string result_code = ds.Tables[0].Rows[0]["result_code"].ToString();//业务结果
                if (result_code.ToUpper() == "SUCCESS")
                {
                    var res = new Dictionary<string, string>
                    {
                        {"appid", wx_appid},
                        {"partnerid", wx_mch_id},
                        {"prepayid", root.SelectSingleNode("/xml/prepay_id").InnerText},
                        {"noncestr", dic["nonce_str"]},
                        {"timestamp", GetTimeStamp()},
                        {"package", "Sign=WXPay"}
                    };

                    string json_str = "{'appid':'" + wx_appid + "','noncestr':'" + dic["nonce_str"] + "','package':'Sign=WXPay','partnerid':'" + wx_mch_id + "','prepayid':'" + root.SelectSingleNode("/xml/prepay_id").InnerText + "','timestamp':" + GetTimeStamp() + ",'sign':'" + GetSignString(res) + "'}";
                    LogManager.WriteLog("JsonStr:" + json_str);
                    json_str = json_str.Replace("'", "\"");
                    if (!string.IsNullOrEmpty(rraId))
                    {
                        if (rraId != "-1") //订单
                            AddPayLog(rraId.ToString(), "0", wx_out_trade_no);
                        else //充值
                            AddPayLog(Idcard, "1", wx_out_trade_no);

                        LogManager.WriteLog("Type:" + rraId != "-1" ? "0" : "1  TradeNO:" + wx_out_trade_no);

                    }
                    return json_str;
                }
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 创建微信支付订单
        /// </summary>
        /// <param name="rraId"></param>
        /// <param name="title"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string PayWithWeChart(string rraId, string Idcard, string title, string money)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            string APP_ID = "wxae25cb3fefdc75ae";
            string WX_PARTNER_ID = "1481965242";
            string SIGN_KEY = "413ac6a2651c14455ec7a0cd498ab6d8";

            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            ret.Add("APP_ID", APP_ID);
            ret.Add("WX_PARTNER_ID", WX_PARTNER_ID);
            ret.Add("SIGN_KEY", SIGN_KEY);

            string Body = string.Empty;  //订单描述
            string Subject = string.Empty;//订单简介
            string TotalAmount = string.Empty;//金额
            string OutTradeNo = string.Empty;//订单号

            Body = "我是测试数据";
            Subject = "微信支付";
            TotalAmount = (double.Parse(money) * 100).ToString();

            int ranNumer = new Random().Next(1, 1000);
            OutTradeNo = "20170216test0170501111111S001111119" + ranNumer.ToString();

            //微信支付 基础配置信息
            string wx_appid = "wxae25cb3fefdc75ae";//微信开放平台审核通过的应用
            string wx_mch_id = "1481965242"; //微信支付分配的商户号
            string wx_nonce_str = GetRandomString(16);//随机字符串，不长于32位
            string aa = title;////商品描述交易字段格式根据不同的应用场景按照以下格式：APP——需传入应用市场上的APP名字-实际商品名称，天天爱消除-游戏充值。

            string strcode = aa;
            byte[] buffer = Encoding.UTF8.GetBytes(strcode);
            string wx_body = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            string wx_out_trade_no = "CZ" + DateTime.Now.ToString("yyyyMMddHHmmss") + GetRandomString(10);//商户系统内部的订单号,32个字符内、可包含字母, 其他说明见商户订单号
            string wx_total_fee = TotalAmount;//;//订单总金额，单位为分，详见支付金额
            string wx_spbill_create_ip = GetWebClientIp();//// 	用户端实际ip
            //string wx_spbill_create_ip = "39.108.15.78";
            string wx_notify_url = "http://www.guardts.com/payment/WeChart_NotifyUrl.aspx";////接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
            string wx_trade_type = "APP";////支付类型
            //string wx_sign = "";// 签名
            //string wx_key = "413ac6a2651c14455ec7a0cd498ab6d8"; //密钥

            var dic = new Dictionary<string, string>
            {
                {"appid", wx_appid},
                {"mch_id", wx_mch_id},
                {"nonce_str", wx_nonce_str},
                {"body", wx_body},
                {"out_trade_no", wx_out_trade_no},//商户自己的订单号码
                {"total_fee", wx_total_fee},
                {"spbill_create_ip",wx_spbill_create_ip},//服务器的IP地址
                {"notify_url", wx_notify_url},//异步通知的地址，不能带参数
                {"trade_type", wx_trade_type}
            };

            //加入签名
            dic.Add("sign", GetSignString(dic));

            var sb = new StringBuilder();
            sb.Append("<xml>");


            foreach (var d in dic)
            {
                sb.Append("<" + d.Key + ">" + d.Value + "</" + d.Key + ">");
            }
            sb.Append("</xml>");
            var xml = new XmlDocument();
            xml.XmlResolver = null;
            //  xml.LoadXml(GetPostString("https://api.mch.weixin.qq.com/pay/unifiedorder", sb.ToString()));
            CookieCollection coo = new CookieCollection();
            Encoding en = Encoding.GetEncoding("UTF-8");
            LogManager.WriteLog("WeChartStart:" + sb.ToString());
            HttpWebResponse response = CreatePostHttpResponse("https://api.mch.weixin.qq.com/pay/unifiedorder", sb.ToString(), en);
            //打印返回值
            Stream stream = response.GetResponseStream();   //获取响应的字符串流
            StreamReader sr = new StreamReader(stream); //创建一个stream读取流
            string html = sr.ReadToEnd();   //从头读到尾，放到字符串html

            Console.WriteLine(html);
            xml.LoadXml(html);
            //对请求返回值 进行处理

            var root = xml.DocumentElement;

            DataSet ds = new DataSet();
            StringReader stram = new StringReader(html);
            XmlTextReader reader = new XmlTextReader(stram);
            ds.ReadXml(reader);
            string return_code = ds.Tables[0].Rows[0]["return_code"].ToString();
            LogManager.WriteLog("WeChartReturn:" + html);
            if (return_code.ToUpper() == "SUCCESS")
            {
                //通信成功
                string result_code = ds.Tables[0].Rows[0]["result_code"].ToString();//业务结果
                if (result_code.ToUpper() == "SUCCESS")
                {
                    var res = new Dictionary<string, string>
                    {
                        {"appid", wx_appid},
                        {"partnerid", wx_mch_id},
                        {"prepayid", root.SelectSingleNode("/xml/prepay_id").InnerText},
                        {"noncestr", dic["nonce_str"]},
                        {"timestamp", GetTimeStamp()},
                        {"package", "Sign=WXPay"}
                    };

                    string json_str = "{'appid':'" + wx_appid + "','noncestr':'" + dic["nonce_str"] + "','package':'Sign=WXPay','partnerid':'" + wx_mch_id + "','prepayid':'" + root.SelectSingleNode("/xml/prepay_id").InnerText + "','timestamp':" + GetTimeStamp() + ",'sign':'" + GetSignString(res) + "'}";
                    LogManager.WriteLog("JsonStr:" + json_str);
                    json_str = json_str.Replace("'", "\"");
                    if (!string.IsNullOrEmpty(rraId))
                    {
                        if (rraId != "-1") //订单
                            AddPayLog(rraId.ToString(), "0", wx_out_trade_no);
                        else //充值
                            AddPayLog(Idcard, "1", wx_out_trade_no);

                        LogManager.WriteLog("Type:" + rraId != "-1" ? "0" : "1  TradeNO:" + wx_out_trade_no);

                    }
                    return json_str;
                }
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 添加支付记录
        /// </summary>
        /// <param name="payObject">对象</param>
        /// <param name="type">类型0：订单支付，1：充值</param>
        /// <param name="tradeNO">流水号</param>
        public void AddPayLog(string payObject, string type, string tradeNO)
        {
            string sql = "Insert into Sys_PayReturnLog values ('" + Guid.NewGuid().ToString() + "','" + payObject + "','" + DateTime.Now.ToString() + "','" + tradeNO + "','" + type + "','','0',null)";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }


        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateWeChartOrder(string tradeNo, string fee)
        {
            LogManager.WriteLog("CallStart:" + tradeNo + " " + fee);
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "select * from Sys_PayReturnLog where TradeNO='" + tradeNo + "' and PayStatus='0'";
                DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

                LogManager.WriteLog("sql:" + sql);
                if (dt1.Rows.Count > 0)
                {
                    try
                    {
                        if (dt1.Rows[0]["PayType"].ToString() == "0")
                        {
                            sql = "select * from v_RentHistory_view where RRAID=" + dt1.Rows[0]["PayObject"].ToString();

                            LogManager.WriteLog("sql:" + sql);
                            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                            CompleteRentAttribute(dt.Rows[0]["RRAID"].ToString());
                            LogManager.WriteLog("complete:" + dt.Rows[0]["RRAID"].ToString());
                            RentAttributeHelper helper = new RentAttributeHelper();
                            helper.UpdateUserWallet(dt.Rows[0]["RIDCard"].ToString(), fee, "0");
                            helper.AddBillLog(dt.Rows[0]["RRAIDCard"].ToString(), dt.Rows[0]["RIDCard"].ToString(), fee, "0");
                        }
                        else
                        {
                            RentAttributeHelper helper = new RentAttributeHelper();
                            helper.UpdateUserWallet(dt1.Rows[0]["PayObject"].ToString(), fee, "0");
                            helper.AddBillLog2("", dt1.Rows[0]["PayObject"].ToString(), fee);
                        }

                        sql = "update Sys_PayReturnLog set PayStatus='1',ReturnTime='" + DateTime.Now.ToString() + "' where TradeNO='" + tradeNo + "' and PayStatus='0'";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                    catch (Exception ex)
                    {
                        LogManager.WriteLog("Exception:" + ex.Message);
                    }
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



        /// <summary>
        /// 从字符串里随机得到，规定个数的字符串.
        /// </summary>
        /// <param name="allChar"></param>
        /// <param name="CodeCount"></param>
        /// <returns></returns>
        public static string GetRandomString(int CodeCount)
        {
            string allChar = "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(allCharArray.Length - 1);
                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }
                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }


        public static string GetWebClientIp()
        {
            string userIP = "IP";

            try
            {
                if (System.Web.HttpContext.Current == null
            || System.Web.HttpContext.Current.Request == null
            || System.Web.HttpContext.Current.Request.ServerVariables == null)
                    return "";

                string CustomerIP = "";

                //CDN加速后取到的IP   
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                }

                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }

            return userIP;
        }




        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受   
        }

        public static HttpWebResponse CreatePostHttpResponse(string url, string datas, Encoding charset)
        {
            HttpWebRequest request = null;
            //HTTPSQ请求
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            StringBuilder buffer = new StringBuilder();
            buffer.AppendFormat(datas);
            byte[] data = charset.GetBytes(buffer.ToString());
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            return request.GetResponse() as HttpWebResponse;
        }


        public string GetSignString(Dictionary<string, string> dic)
        {
            string key = "413ac6a2651c14455ec7a0cd498ab6d8"; ;//商户平台 API安全里面设置的KEY  32位长度
            //排序
            dic = dic.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
            //连接字段
            var sign = dic.Aggregate("", (current, d) => current + (d.Key + "=" + d.Value + "&"));
            sign += "key=" + key;
            //MD5
            //Response.Write(sign+"<br/>");
            sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sign, "MD5").ToUpper();

            return sign;
        }

        public string GetSignString1(Dictionary<string, string> dic)
        {
            string key = "413ac6a2651c14455ec7a0cd498ab6d8";//商户平台 API安全里面设置的KEY  32位长度
            //排序
            dic = dic.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
            //连接字段
            var sign = dic.Aggregate("", (current, d) => current + (d.Key + "=" + d.Value + "&"));
            sign += "key=" + key;
            //MD5
            //Response.Write(sign + "<br/>" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sign, "MD5").ToUpper());
            sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sign, "MD5").ToUpper();
            return sign;
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

        /// <summary>
        /// 返回红包状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRedPackageStatus(string id)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = "select * from Sys_RedPackage where RedPackageID='" + id + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ret.Add("ret", "0");
                ret.Add("status", dt.Rows[0]["RedPackageStatus"].ToString());
                ret.Add("msg", "success");
            }
            return JSONHelper.ToJson(ret);
        }


        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateRedPackageStatus(string id, string rraId, string status)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = "Update Sys_RedPackage set RedPackageStatus='" + status + "',memo='" + rraId + "' where RedPackageID='" + id + "'";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            ret.Add("ret", "0");
            ret.Add("msg", "success");
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 获取提现所有信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetWithdrawalsList(string IDCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from CF_User_Withdrawals_Log where IDCard= '" + IDCard + "'");
        }

        /// <summary>
        /// 获取提现状态
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetWithdrawalsState(string NoOrder)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sqlWithdrawalsLog = "select * from CF_User_Withdrawals_Log where NoOrder= '" + NoOrder + "'";
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


        /// <summary>
        /// 是否绑定房屋接口
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetRentBindLockStutus(string address)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string where = "1=1";
            if (!string.IsNullOrEmpty(address))
                where += " and RAddress like '%" + address + "%'";
            string sql = string.Empty;
            string dateSql = string.Empty;
            int i = 0;
            int j = 0;
            sql = "select * from Rent_Rent where " + where;//所有房屋
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string[] arrayRent = new string[dt.Rows.Count];
            foreach (DataRow row in dt.Rows)
            {
                arrayRent[i] = row["RentNo"].ToString();
                i++;
            }
            sql = "select * from v_Rent_Locks_view where " + where;//绑锁房屋
            DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string[] arrayRentBind = new string[dt1.Rows.Count];
            foreach (DataRow row in dt1.Rows)
            {
                arrayRentBind[j] = row["RentNo"].ToString();
                j++;
            }
            string[] rentNo = arrayRent.Except(arrayRentBind).Union(arrayRentBind.Except(arrayRent)).ToArray();
            foreach (string arr in rentNo)
            {
                dateSql += "'" + arr + "',";
            }
            dateSql = "and  RentNo in (" + dateSql + "'')";
            sql = "select * from Rent_Rent where 1=1" + dateSql;
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo(sql);
        }

        /// <summary>
        /// 创建家庭锁
        /// </summary>
        /// <param name="address">房屋地址</param>
        /// <param name="familyName">家庭名称</param>
        /// <param name="userId">用户ID</param>
        /// <param name="city">区域</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string CreateHomeLock(string address, string familyName, string userId, string city)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                LogManager.WriteLog("Start......");
                string deviceID = Guid.NewGuid().ToString("N");
                string sql = string.Empty;
                //请求远程创建家庭接口
                NewLockManager manager = new NewLockManager();
                string familyReturn = manager.createHomeInfo(deviceID);
                LogManager.WriteLog("Start......" + familyReturn);
                Dictionary<string, object> returnInfo = new Dictionary<string, object>();
                returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(familyReturn);
                if (returnInfo["ret"].ToString() == "0")
                {
                    //信息记录
                    sql = "insert into Rent_NewLock_Process output inserted.NewLockId values('" + Guid.NewGuid().ToString() + "', '" + userId + "', '" + deviceID + "', '" + address + "', '','','true','','','','','" + DateTime.Now.ToString() + "','','" + familyName + "', '" + city + "')";
                    LogManager.WriteLog("SQL:" + sql);
                    DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    sql = "select * from Rent_NewLock_Process where NewLockID='" + dt.Rows[0]["NewLockID"].ToString() + "'";
                    LogManager.WriteLog("SQL:" + sql);
                    DataTable dtInfo = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    sql = "insert into Rent_Locks values('" + dtInfo.Rows[0]["DeviceID"].ToString() + "', 1, '0', 'NoConfiguration', '0', '" + DateTime.Now.ToString() + "', '0', '0', '" + dt.Rows[0]["NewLockID"].ToString() + "')";
                    LogManager.WriteLog("SQL:" + sql);
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    ret.Add("ret", "0");
                    ret.Add("msg", dt.Rows[0]["NewLockID"].ToString());
                }
                else
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", returnInfo["msg"].ToString());
                }
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 新锁与房屋绑定
        /// </summary>
        /// <param name="rentNo">锁编号</param>
        /// <param name="">新锁Id</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string BandHomeLockDevice(string rentNo, string newLockID)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = string.Empty;
                sql = "select * from Rent_Locks where Memo='" + newLockID + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows[0]["RentNo"].ToString() == "NoConfiguration")
                {
                    sql = "Update Rent_Locks set RentNo='" + rentNo + "'where Memo='" + newLockID + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
                else //多个房屋绑定一把锁
                {
                    sql = "insert into Rent_Locks values('" + dt.Rows[0]["DeviceID"].ToString() + "', 1, '0', '" + rentNo + "', '0', '" + DateTime.Now.ToString() + "', '0', '0', '" + newLockID + "')";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
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

        /// <summary>
        /// 获取家庭数据返回信息
        /// </summary>
        /// <param name="devId">新锁编号ID</param>
        /// <param name="type"> 1 网关返回数据  2  智能锁返回数据   3   pin码返回数据   4  删除网关      5   删除锁</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHomeLockReturnInfo(string newLockId, int type)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "select * from Rent_NewLock_Process where NewLockID='" + newLockId + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                ret.Add("ret", "0");
                if (type == 1)
                {
                    ret.Add("msg", dt.Rows[0]["IsCreateGateway"].ToString());
                }
                else if (type == 2)
                {
                    ret.Add("msg", dt.Rows[0]["IsCreateLock"].ToString());
                }
                else if (type == 3)
                {
                    ret.Add("msg", dt.Rows[0]["PinInfo"].ToString());
                }
                else if (type == 4)
                {
                    ret.Add("msg", dt.Rows[0]["IsDeleteGateway"].ToString());
                }
                else if (type == 5)
                {
                    ret.Add("msg", dt.Rows[0]["IsDeleteLock"].ToString());
                }
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 绑定网关
        /// </summary>
        /// <param name="gatewayId">网关ID</param>
        /// <param name="devKey"> 网关KEY</param>
        /// <param name="newLockID"> 新锁ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddGateway(string gatewayId, string devKey, string newLockID)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                //网关查询
                string selSql = "select * from Rent_NewLock_Process where GatewayId='" + gatewayId + "' and DevKey='" + devKey + "'and IsCreateGateway='true'";
                DataTable d1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(selSql)).Tables[0];
                if (d1.Rows.Count > 0)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "网关存在，请先解绑在绑定！");
                    return JSONHelper.ToJson(ret);

                }
                //添加网关
                NewLockManager managerNew = new NewLockManager();
                string addGatewayInfo = managerNew.createAddGateway(gatewayId, devKey, newLockID);
                Dictionary<string, object> returnInfo = new Dictionary<string, object>();
                returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(addGatewayInfo);
                if (returnInfo["ret"].ToString() == "0")
                {
                    string sql = "Update Rent_NewLock_Process set GatewayId='" + gatewayId + "', DevKey='" + devKey + "', UpdatedOn='" + DateTime.Now.ToString() + "'where NewLockID='" + newLockID + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    ret.Add("ret", "0");
                }
                else
                {
                    ret.Add("ret", "1");
                }
                ret.Add("msg", returnInfo["msg"].ToString());
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 获取pin码
        /// </summary>
        /// <param name="newLockID"> 新锁ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetPinInfo(string newLockID)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                NewLockManager managerNew = new NewLockManager();
                //判断是否已经获取网关地址
                string sql = "select * from Rent_NewLock_Process where NewLockID='" + newLockID + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows[0]["GatewayId"].ToString() == "" || dt.Rows[0]["DevKey"].ToString() == "" || dt.Rows[0]["IsCreateGateway"].ToString() == "")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "请先配置好网关，在获取PIN码");
                    return JSONHelper.ToJson(ret);
                }
                //添加pin码
                string addLockInfo = managerNew.createAddLock(dt.Rows[0]["GatewayId"].ToString(), newLockID);
                Dictionary<string, object> returnInfo = new Dictionary<string, object>();
                returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(addLockInfo);
                if (returnInfo["ret"].ToString() == "0")
                {
                    ret.Add("ret", "0");
                }
                else
                {
                    ret.Add("ret", "1");
                }
                ret.Add("msg", returnInfo["msg"].ToString());
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 删除网关,锁
        /// </summary>
        /// <param name="gatewayId">新锁ID</param>
        /// <param name="type">1，删除网关  2 删除锁  3  强制删除网关 4 删除家庭</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string DeleteGatewayLock(string newLockID, int type)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string LockInfo = string.Empty;
                NewLockManager managerNew = new NewLockManager();
                if (type == 1) //删除网关
                {
                    LockInfo = managerNew.deleteGateway(newLockID);
                }
                else if (type == 2)   //删除锁
                {
                    LockInfo = managerNew.deleteAddLock(newLockID);
                }
                else if (type == 3)  //强制删除网关
                {
                    LockInfo = managerNew.forceDelGate(newLockID);
                }
                else if (type == 4)  //删除家庭
                {
                    LockInfo = managerNew.deleteFamily(newLockID);
                }
                Dictionary<string, object> returnInfo = new Dictionary<string, object>();
                returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(LockInfo);
                if (returnInfo["ret"].ToString() == "0")
                {
                    ret.Add("ret", "0");
                    string lockId = managerNew.getDeviceID(newLockID, "DeviceID");
                    //删除所有密码
                    string delSqlPass = "Update Rent_Locks_Password set IsValid='0' where LockID='" + lockId + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(delSqlPass));
                    //删除所有卡片
                    string delSqlIc = "Update Rent_Locks_ICCards set IsValid='0' where LockID='" + lockId + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(delSqlIc));
                    if (type == 2)
                    {
                        string delSqlLock = "Update Rent_NewLock_Process set IsDeleteLock='' where NewLockID='" + newLockID + "'";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(delSqlLock));
                    }
                    else if (type == 3)
                    {
                        string delSqlGate = "Update Rent_NewLock_Process set IsDeleteGateway='true', PinInfo='',IsCreateLock='', IsDeleteLock='' , IsCreateGateway='', GatewayId='', DevKey='' where NewLockID='" + newLockID + "'";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(delSqlGate));
                    }
                    else if (type == 4) //删除家庭
                    {
                        string delSql = string.Empty;
                        delSql = "delete from Rent_NewLock_Process where NewLockID='" + newLockID + "'";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(delSql));
                        delSql = "delete from Rent_Locks where Memo='" + newLockID + "'";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(delSql));
                    }
                }
                else
                {
                    ret.Add("ret", "1");
                }
                ret.Add("msg", returnInfo["msg"].ToString());
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 获取当前用户新锁
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetUserNewLockList(string userId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_NewLock_Process where UserId='" + userId + "'");
        }

        /// <summary>
        /// 获取家庭信息
        /// </summary>
        /// <param name="newLockID">家庭编号</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetNewFamilyInfo(string newLockID)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_NewLock_Process where NewLockID='" + newLockID + "'");
        }

        /// <summary>
        ///修改家庭信息
        /// </summary>
        /// <param name="newLockID">家庭编号</param>
        /// <param name="Address">家庭锁地址</param>
        /// <param name="FamilyName">家庭锁名称</param>
        /// <param name="City">区域</param>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateNewFamilyInfo(string newLockID, string address, string familyName, string city)
        {
            string sqlDate = "City='" + city + "',Address='" + address + "', FamilyName='" + familyName + "'";
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "update Rent_NewLock_Process set " + sqlDate + " where NewLockID='" + newLockID + "'";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                ret.Add("ret", "0");
                ret.Add("msg", "修改成功！");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 开锁接口   新锁
        /// </summary>
        /// <param name="newLockID">新锁标识</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string NewOpenDoor(string newLockID)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            NewLockManager managerNew = new NewLockManager();
            string lockId = managerNew.getDeviceID(newLockID, "DeviceID");
            return managerNew.openDoor(lockId);
        }

        /// <summary>
        /// 添加密码和IC卡   新锁
        /// </summary>
        /// <param name="type">类型   1 永久密码  2 临时密码  3 永久卡和永久身份证  4  临时卡和临时身份证</param>
        /// <param name="newLockID">新锁id</param>
        /// <param name="pwd">当密码时候输入   卡片时候不输入</param>
        /// <param name="startTime endTime">当永久密码和永久卡片时候  开始时间和结束时间相同</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string NewAddPasswordICcard(string newLockID, string type, string pwd, string startTime, string endTime)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            NewLockManager managerNew = new NewLockManager();
            return managerNew.GetPostInterface(managerNew.getDeviceID(newLockID, "DeviceID"), managerNew.getDeviceID(newLockID, "UserId"), type, pwd, startTime, endTime);
        }

        /// <summary>
        /// 删除密码和IC卡   新锁
        /// </summary>
        /// <param name="type">类型  1 删除密码   2 删除卡片</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string NewDelPasswordICcard(string id, string type)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string returnInfo = string.Empty;
            NewLockManager managerNew = new NewLockManager();
            if (type == "1")
            {
                returnInfo = managerNew.DeletePassword(id);
            }
            else if (type == "2")
            {
                returnInfo = managerNew.DeleteICCard(id);
            }
            return returnInfo;
        }

        /// <summary>
        /// 查询密码和IC卡   新锁
        /// </summary>
        /// <param name="newLockID">新锁id</param>
        /// <param name="type">1  密码列表   2 卡片列表</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string NewSelPasswordICcard(string newLockID, int type)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            NewLockManager managerNew = new NewLockManager();
            string lockId = managerNew.getDeviceID(newLockID, "DeviceID");
            string userId = managerNew.getDeviceID(newLockID, "UserId");
            RentInfoHelper helper = new RentInfoHelper();
            if (type == 1)
            {
                return helper.GetJSONInfo("select * from v_RentICCard_view where LockID='" + lockId + "'and IsValid='1' and Status='0' and UserId='" + userId + "'and ICCard is not null and len(ICCard)>0");
            }
            else
            {
                return helper.GetJSONInfo("select * from v_RentPass_view where LockID='" + lockId + "'and IsValid='1' and Status='0' and UserId='" + userId + "'and IsAdd is not null and len(IsAdd)>0");
            }

        }

        /// <summary>
        /// 扫码演示   新锁
        /// </summary>
        /// <param name="GatewayId">网关ID</param>
        /// <param name="DevKey">网关KEY</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string NewScanCode(string GatewayId, string DevKey)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string sql = string.Empty;
            Dictionary<string, string> ret = new Dictionary<string, string>();
            sql = "select * from Rent_NewLock_Process where GatewayId='" + GatewayId + "'and DevKey='" + DevKey + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sql = "select * from Rent_Locks where Memo='" + dt.Rows[0]["NewLockID"].ToString() + "'";
                DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt1.Rows[0]["RentNo"].ToString() == "NoConfiguration")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "该锁暂无绑定房屋");
                }
                else
                {
                    RentInfoHelper helper = new RentInfoHelper();
                    ret.Add("ret", "0");
                    ret.Add("msg", helper.GetJSONInfo("select * from Rent_Locks where Memo='" + dt.Rows[0]["NewLockID"].ToString() + "'"));
                }
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", "暂无查找信息");
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 查询信鸽推送信息
        /// </summary>
        /// <param name="IdCard">身份证</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetSendMessageInfo(string IdCard)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from Rent_Send_Message where DelStatus='1' and IdCard ='" + IdCard + "'");
        }

        /// <summary>
        /// 修改信鸽读取状态
        /// </summary>
        /// <param name="SendMessageId">信鸽Id</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string SetSendMessage(string SendMessageId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("Update Rent_Send_Message set DelStatus='2' where SendMessageId='" + SendMessageId + "'");
        }

        /// <summary>
        /// 获取民警下的所有小区
        /// </summary>
        /// <param name="userID">用户Id</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetBelongRegion(string userId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from v_PoliceArea_view where UserId=" + userId);
        }

        /// <summary>
        /// 获取民警小区所有房屋以及订单数
        /// </summary>
        /// <param name="userID">用户Id</param>
        /// <param name="lrid">区域ID</param>
        /// <param name="oderBy">默认倒叙   1 倒叙  2 正序</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetBelongRent(string userId, string lrid, string oderBy, string startTime, string endTime)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            string sql = string.Empty;
            string dataSql = string.Empty;
            string filedSort = string.Empty;
            var list = new List<Hashtable>();
            //筛选民警管辖的区域房屋
            if (string.Empty == lrid)
            {
                sql = "select LRID from v_PoliceArea_view where UserId='" + userId + "'";
                DataTable dtR = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                foreach (DataRow row in dtR.Rows)
                {
                    dataSql += "'" + row["LRID"].ToString() + "',";
                }
            }
            else
            {
                dataSql = "'" + lrid + "',";
            }

            dataSql = " a.RRNameID in (" + dataSql + "'')";
            filedSort = oderBy == "1" ? "desc" : "asc"; //排序   1 倒叙  2 正序
            //筛选所有的出租的房屋  按照数量排序
            string sqlR = "select count(a.RentNo) as count , a.RentNo, a.RAddress, a.ROwner from v_RentDetail_view as a left join v_RentHistory_view as b on  a.RentNO = b.RentNO where a.IsObsoleted = '0' and b.rrastatus in ('2', '5', '6', '11', '3') and ((b.RRAEndDate >'" + endTime + "' and b.RRAStartDate<='" + endTime + "') or ('" + startTime + "'>=b.RRAStartDate and '" + startTime + "'<b.RRAEndDate) or ('" + startTime + "'<=b.RRAStartDate and '" + endTime + "'>=b.RRAEndDate))  and " + dataSql + " group by a.RentNo, a.RAddress, a.ROwner order by count " + filedSort + "";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlR)).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                var item = new Hashtable();
                item["count"] = row["count"].ToString();
                item["RentNo"] = row["RentNo"].ToString();
                item["RAddress"] = row["RAddress"].ToString();
                item["ROwner"] = row["ROwner"].ToString();
                item["startTime"] = startTime;
                item["endTime"] = endTime;
                list.Add(item);
            }
            return JSONHelper.ToJson(list);
        }

        /// <summary>
        /// 获取当个订单详情
        /// </summary>
        /// <param name="rraid">订单ID</param>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetOrderInfo(string rraid)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from v_RentHistory_view where RRAID='" + rraid + "'");
        }

        /// <summary>
        /// 获取民警下所有房屋
        /// </summary>
        /// <param name="userId">民警ID</param>
        /// <param name="address">地址</param>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetPoliceAllRent(string userId, string address)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string sql = string.Empty;
            string dataSql = string.Empty;
            //筛选民警管辖的区域ID
            sql = "select LRID from v_PoliceArea_view where UserId='" + userId + "'";
            DataTable dtR = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            foreach (DataRow row in dtR.Rows)
            {
                dataSql += "'" + row["LRID"].ToString() + "',";
            }

            dataSql = " RRNameID in (" + dataSql + "'')";
            RentInfoHelper helper = new RentInfoHelper();
            if (address == string.Empty)
            {
                return helper.GetJSONInfo("select * from v_RentDetail_view where " + dataSql + " order by RID desc");
            }
            else
            {
                return helper.GetJSONInfo("select * from v_RentDetail_view where " + dataSql + " and  RAddress like '%" + address + "%' order by RID desc");
            }
        }

        /// <summary>
        /// 民警信息弹框
        /// </summary>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetPoliceFrameInfo()
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string frameInfoType = ConfigurationManager.AppSettings["FrameInfoType"];
                string frameInfoContect = ConfigurationManager.AppSettings["FrameInfoContect"];
                string frameInfoTextContect = ConfigurationManager.AppSettings["FrameInfoTextContect"];
                string sqlR = "select top 1 * from t_web_text where wt_status='A' order by wt_time desc";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sqlR)).Tables[0];
                var item = new Hashtable();
                item["title"] = frameInfoContect;
                if (frameInfoType == "1") //内容
                {
                    item["titleContent"] = dt.Rows[0]["wt_title"].ToString();
                }
                else
                {   //时间
                    item["titleContent"] = dt.Rows[0]["wt_time"].ToString();
                }
                item["textContent"] = frameInfoTextContect;
                item["text"] = dt.Rows[0]["wt_text"].ToString();
                ret.Add("ret", "0");
                ret.Add("msg", JSONHelper.ToJson(item));
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 民警检索接口
        /// </summary>
        /// <param name="userId">民警ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="name">用户名称（房主、房客）</param>
        /// <param name="idCard">身份证号</param>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string PoliceRetrieval(string userId, string startTime, string endTime, string name, string idCard)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            string sql = string.Empty;
            string dataSql = string.Empty;  //所属区域
            string nameSql = string.Empty; //名称检索
            //筛选民警管辖的区域ID
            sql = "select LRID from v_PoliceArea_view where UserId='" + userId + "'";
            DataTable dtR = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            foreach (DataRow row in dtR.Rows)
            {
                dataSql += "'" + row["LRID"].ToString() + "',";
            }
            dataSql = " Expr4 in (" + dataSql + "'')";
            RentInfoHelper helper = new RentInfoHelper();
            if (name != string.Empty && idCard != string.Empty)
            {
                nameSql = "(((RRAContactName like '%" + name + "%') and (RRAIDCard like '%" + idCard + "%')) or ((ROwner like '%" + name + "%') and (RIDCard like '%" + idCard + "%')))";
            }
            else if (name != string.Empty && idCard == string.Empty)
            {
                nameSql = "((RRAContactName like '%" + name + "%') or (ROwner like '%" + name + "%'))";
            }
            else if (name == string.Empty && idCard != string.Empty)
            {
                nameSql = "( (RRAIDCard like '%" + idCard + "%') or (RIDCard like '%" + idCard + "%'))";
            }
            else
            {
                nameSql = "((RRAContactName like '%" + name + "%') or (RRAIDCard like '%" + idCard + "%') or (ROwner like '%" + name + "%') or (RIDCard like '%" + idCard + "%'))";
            }
            return helper.GetJSONInfo("select * from dbo.v_RentHistory_view where rrastatus in ('2', '5', '6', '11', '3') and ((RRAEndDate >'" + endTime + "' and RRAStartDate<='" + endTime + "') or ('" + startTime + "'>=RRAStartDate and '" + startTime + "'<RRAEndDate) or ('" + startTime + "'<=RRAStartDate and '" + endTime + "'>=RRAEndDate)) and " + dataSql + " and " + nameSql + "");
        }

        /// <summary>
        /// 民警评分接口
        /// </summary>
        /// <param name="rentNo">房屋ID</param>
        /// <param name="score">评分  0-5</param>
        /// <param name="type">1 消防安全   2 信息录入  3 违规处罚</param>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string AddPoliceEvaluation(string rentNo, string score, string type)
        {
            //if (!authentication.ValideUser())
            //{
            //    return "{'headerError'}";
            //}
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = string.Empty;
                string dataSql = string.Empty;  //所有评分ID
                //筛选房屋下所有评分
                sql = "select * from v_Rent_Evaluation_view where RentNO = '" + rentNo + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    dataSql += "'" + row["EvaluateID"].ToString() + "',";
                }
                dataSql = " EvaluateID in (" + dataSql + "'')";
                sql = "select top 1 * from Rent_Evaluate where " + dataSql + "";
                DataTable dtS = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                string filedSql = string.Empty;
                string[] bit = new string[3];
                if (dtS.Rows[0]["EvaluateItem3"].ToString() != string.Empty && dtS.Rows[0]["EvaluateItem3"].ToString() != "0" && dtS.Rows[0]["EvaluateItem3"].ToString() != "0.00")
                {
                    filedSql = dtS.Rows[0]["EvaluateItem3"].ToString();
                    bit = filedSql.Split('|');//用|进行分割
                }

                if (type == "1")
                {
                    filedSql = score + "|" + bit[1] + "|" + bit[2];
                }
                else if (type == "2")
                {
                    filedSql = bit[0] + "|" + score + "|" + bit[2];
                }
                else
                {
                    filedSql = bit[0] + "|" + bit[1] + "|" + score;
                }
                sql = "Update Rent_Evaluate set EvaluateItem3= '" + filedSql + "' where " + dataSql + "";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                ret.Add("ret", "0");
                ret.Add("msg", "修改成功！");
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }


        /// <summary>
        /// 获取报警信息列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetAlertInfoList(string userId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from v_Alter_info_view where alertstatus='0' and  strArea in (select t_ad_reg_dept_id from t_UserAreaView where t_wu_user_id = " + userId + ")");
        }

        /// <summary>
        /// 获取报警信息列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetAlertAllInfoList(string userId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select * from v_Alter_info_view where strArea in (select t_ad_reg_dept_id from t_UserAreaView where t_wu_user_id = " + userId + ") order by RelatedDate desc");
        }

        /// <summary>
        /// 获取报警信息列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetAlertInfoListByUserID(string userId)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            RentInfoHelper helper = new RentInfoHelper();
            return helper.GetJSONInfo("select v_Alter_info_view.* from v_Alter_info_view inner join T_Person_Info p on p.ID = RelatedID where HandlePerson='" + userId + "' and v_Alter_info_view.strArea in (select t_ad_reg_dept_id from t_UserAreaView where t_wu_user_id = " + userId + ") order by RelatedDate desc");
        }

        /// <summary>
        /// 获取报警信息列表
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string HandleAlertInfo(string alertId, string userId, string desc)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            AlertInfoHelper helper = new AlertInfoHelper();
            helper.HandleAlertInfo(alertId, userId, desc);
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            ret.Add("msg", "success");
            return JSONHelper.ToJson(ret);
        }

        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateCheckOutEndDate(string rraId, string endDate)
        {
            if (!authentication.ValideUser())
            {
                return "{'headerError'}";
            }
            string sql = "update Rent_RentAttribute set RRAEndDate='" + endDate + "' where RRAID=" + rraId;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            ret.Add("msg", "success");
            return JSONHelper.ToJson(ret);
        }






    }
}
