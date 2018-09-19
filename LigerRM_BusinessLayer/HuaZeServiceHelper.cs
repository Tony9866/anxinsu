using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LigerRM.Common;
using System.Configuration;

namespace SignetInternet_BusinessLayer
{
    public class HuaZeServiceHelper
    {
        public string UploadRentInfoToHZ(RentInfo info,RentAttribute attInfo)
        {





            // 准备代理人（二房东）信息相关参数
            Dictionary<string, string> landLord = new Dictionary<string, string>();

            landLord.Add("PRINCIPALNAME", info.ROwner);
            landLord.Add("IDENTITYID", info.RIDCard);
            landLord.Add("LINKMOBILE", info.ROwnerTel);
            landLord.Add("DAYRENTADDRESS", info.RAddress);
            landLord.Add("DEPARTMENTOFREGISTER", info.RPSParentName);
            landLord.Add("LOCALPOLICESTATION", info.RPSName);
            landLord.Add("LOCALBRANCH", info.RPSParentName);


            //rent.Add("rentName", info.ROwner);
            //rent.Add("rentIdentityID", info.RIDCard);
            //rent.Add("rentTel", info.ROwnerTel);


            // 准备房屋信息相关参数
            Dictionary<string, string> roomInfo = new Dictionary<string, string>();
            roomInfo.Add("HOUSENUMBER", "110");
            roomInfo.Add("LANDLORDNAME", info.RRealOwner);
            roomInfo.Add("LANDLORDIDENTITYID", info.RRealIDCard);
            roomInfo.Add("LANDLORDLINKTEL", info.RRealOwnerTel);


            #region
            //原文件对照表
            //houseInfo.Add("holderName", info.RRealOwner);
            //houseInfo.Add("holderIdentityID", info.RRealIDCard);
            //houseInfo.Add("holderTel", info.RRealOwnerTel);
            //houseInfo.Add("departmentOfRegister", info.RPSParentName);
            //houseInfo.Add("localPoliceStation", info.RPSName);
            //houseInfo.Add("localBranch", info.RPSParentName);


            //string building = string.Empty;
            //string address = string.Empty;
            //string tempAddr = info.RAddress;
            //int temNum = 0;
            //for (int i = 0; i < tempAddr.Length; i++)
            //{
            //    if (int.TryParse(tempAddr.Substring(i, 1), out temNum))
            //    {
            //        building = tempAddr.Substring(0, i);
            //        address = tempAddr.Substring(i);
            //        break;
            //    }
            //}

            //houseInfo.Add("building", building);
            //houseInfo.Add("address", address);
            #endregion


            // 准备住客相关参数
            Dictionary<string, string> tenantRenter = new Dictionary<string, string>();
            tenantRenter.Add("ID", string.IsNullOrEmpty(attInfo.TenantID) ? "" : attInfo.TenantID);
            tenantRenter.Add("TENANTRENTERNAME", attInfo.RRAContactName);
            tenantRenter.Add("IDENTITYID", attInfo.RRAIDCard);
            tenantRenter.Add("TENANTRENTERPHONE", attInfo.RRAContactTel);
            string sex = "1";
            if (attInfo.RRAIDCard.Length == 18)
            {
                sex = attInfo.RRAIDCard.Substring(14, 3);
            }
            if (attInfo.RRAIDCard.Length == 15)
            {
                sex = attInfo.RRAIDCard.Substring(12, 3);
            }
            if (int.Parse(sex) % 2 == 0)
            {
                tenantRenter.Add("SEX", "女");
            }
            else
            {
                tenantRenter.Add("SEX", "男");
            }

            tenantRenter.Add("NATION", "");
            tenantRenter.Add("HOUSEADDRESS","");
            //tenantRenter.Add("isLongValidDate", "0");
            tenantRenter.Add("STARTVALIDDATE","");
            tenantRenter.Add("ENDVALIDDATE","");
            tenantRenter.Add("ISFOREIGNER", "否");
            tenantRenter.Add("NATIONALITY","中国");
            tenantRenter.Add("STARTRENTDATE",attInfo.RRAStartDate.ToString("yyyy/MM/dd"));

            if (attInfo.RRARealEndDate.HasValue)
                tenantRenter.Add("ENDRENTDATE", attInfo.RRARealEndDate.Value.ToString("yyyy/MM/dd"));
            else
                tenantRenter.Add("ENDRENTDATE", attInfo.RRAEndDate.ToString("yyyy/MM/dd"));
            tenantRenter.Add("IDENTITYPIC", "");
            tenantRenter.Add("CHECKINROOMHOUSE", "110");

            #region
            //原 准备住客相关参数 对照表
            //Dictionary<string, string> tenant = new Dictionary<string, string>();
            //tenant.Add("id", string.IsNullOrEmpty(attInfo.TenantID) ? "" : attInfo.TenantID);
            //tenant.Add("tenantName", attInfo.RRAContactName);
            //tenant.Add("tenantIdentityID", attInfo.RRAIDCard);
            //tenant.Add("tenantTel", attInfo.RRAContactTel);
            //string sex = "1";
            //if (attInfo.RRAIDCard.Length == 18)
            //{
            //    sex = attInfo.RRAIDCard.Substring(14, 3);
            //}
            //if (attInfo.RRAIDCard.Length == 15)
            //{
            //    sex = attInfo.RRAIDCard.Substring(12, 3);
            //}
            //if (int.Parse(sex) % 2 == 0)
            //{
            //    tenant.Add("tenantSex", "女");
            //}
            //else
            //{
            //    tenant.Add("tenantSex", "男");
            //}

            //tenant.Add("tenantNation", "暂无");
            //tenant.Add("tenantAddress", info.RAddress);
            //tenant.Add("isLongValidDate", "0");
            //tenant.Add("startValidDate", attInfo.RRAStartDate.ToString("yyyy/MM/dd"));
            //tenant.Add("endValidDate", attInfo.RRAEndDate.ToString("yyyy/MM/dd"));
            //tenant.Add("isForeigner", "0");
            //tenant.Add("nationality", "中国");
            //tenant.Add("startRentDate", attInfo.RRAStartDate.ToString("yyyy/MM/dd"));
            //if (attInfo.RRARealEndDate.HasValue)
            //    tenant.Add("endRentDate", attInfo.RRARealEndDate.Value.ToString("yyyy/MM/dd"));
            //else
            //    tenant.Add("endRentDate", attInfo.RRAEndDate.ToString("yyyy/MM/dd"));
            #endregion

            // 准备访问url

            //string url = "http://117.9.114.110:8081/dailyrentconsole/outservice/hzxxadddailydata";
            string url = "http://60.30.66.199:8022/dailyrentconsole/outservice/hzxxadddailydata";

            //string url = ConfigurationManager.AppSettings["HZDataService"];

            //{"landLordId":"402881c265338a290165353fe1c80000","roomInfoId":"402881c265338a290165353fe1cc0001","tenantRenterId":"402881c265338a290165353fe1ce0002","result":"success"}
            //{"rentID":"402881a65f5c6974015f5c79a4250000","houseID":"402881a65f5c6974015f5c79a42a0001","tenantID":"402881a65f5c6974015f5c79a42b0002","result":"success"}

            Dictionary<string,string> other = new Dictionary<string,string>();
            string ret = LigerRM.Common.WebRequestHelper.WebRequestPoster.Post(url + "?landLord=" + JSONHelper.ToJson(landLord) + "&roomInfo=" + JSONHelper.ToJson(roomInfo) + "&tenantRenter=" + JSONHelper.ToJson(tenantRenter));
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic = JSONHelper.FromJson<Dictionary<string, string>>(ret);
            if (dic["result"].ToLower() == "success")
            {
                string roomInfoId = dic["roomInfoId"];
                string landLordId = dic["landLordId"];
                string tenantRenterId = dic["tenantRenterId"];
                attInfo.TenantID = tenantRenterId;
                info.RRentID = roomInfoId;
                info.RHouseID = landLordId;
                RentInfoHelper helper = new RentInfoHelper();
                helper.UpdateRentExternal(info, true);

                RentAttributeHelper attrHelper = new RentAttributeHelper();
                attrHelper.UpdateExternalInfo(attInfo);
                
                AddUploadLog(info.RentNo, attInfo.RRAID.ToString(), ret, "0", string.Empty);
            }
            else
            {
                
                AddUploadLog(info.RentNo, attInfo.RRAID.ToString(), ret, "1", string.Empty);
            }
            return ret;
        }

        /// <summary>
        /// 添加上传日志
        /// </summary>
        /// <param name="rentNo"></param>
        /// <param name="rraid"></param>
        /// <param name="returnStr"></param>
        /// <param name="status">0：成功，1：失败</param>
        /// <param name="memo"></param>
        public void AddUploadLog(string rentNo, string rraid, string returnStr, string status, string memo)
        {
            string sql = "Insert into Rent_Upload_Log values ('"+rentNo+"',"+rraid.ToString()+",'"+returnStr+"','"+status+"','"+DateTime.Now.ToString()+"','"+memo+"')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }
    }
}
