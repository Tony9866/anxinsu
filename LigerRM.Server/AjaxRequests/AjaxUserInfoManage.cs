using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.Web.Script.Serialization;
using System.Data;

namespace LigerRM.Server.AjaxRequests
{
    public class AjaxUserInfoManage
    {
        public static AjaxResult UpdateUserAreaRef(string User, string DataJSON)
        {
            var data = new JavaScriptSerializer().Deserialize<List<Dictionary<string, object>>>(DataJSON);
            UserInfoHelper helper = new UserInfoHelper();
            DeleteUserAreaRef(User);
            foreach (var item in data)
            {

                RentInfoHelper rHelper = new RentInfoHelper();
                DataTable dt = rHelper.GetDataTable("select * from Rent_PoliceStation where parentId=" + item["PSID"].ToString());
                if (dt.Rows.Count<=0)
                {
                string Region = item["PSID"].ToString();
                helper.InsertRelationShip(User, Region);
                }
            }
            return AjaxResult.Success();
        }

        public static AjaxResult GetUserAreaRef(string userId)
        {
            var data = new List<Dictionary<string, object>>();
            var regions = "0";
            UserInfoHelper helper = new UserInfoHelper();
            DataTable dt = helper.GetUserRegRelationList(userId);
            foreach(DataRow row in dt.Rows)
            {
                regions += "," + row["t_ad_reg_dept_id"].ToString();
            }

            return AjaxResult.Success(data,regions);
        }


        public static AjaxResult DeleteUserAreaRef(string User)
        {
            UserInfoHelper helper = new UserInfoHelper();
            helper.DeleteRelationShip(User);
            return AjaxResult.Success();
        }


        public static AjaxResult DeleteUserCommunityRef(string User)
        {
            UserInfoHelper helper = new UserInfoHelper();
            helper.DeleteCommunityRelationShip(User);
            return AjaxResult.Success();
        }

        public static AjaxResult UpdateUserCommunityRef(string User, string DataJSON)
        {
            var data = new JavaScriptSerializer().Deserialize<List<Dictionary<string, object>>>(DataJSON);
            UserInfoHelper helper = new UserInfoHelper();
            DeleteUserCommunityRef(User);
            foreach (var item in data)
            {

                RentInfoHelper rHelper = new RentInfoHelper();
                string Region = item["LSID"].ToString();
                helper.InsertCommunityRelationShip(User, Region);

            }
            return AjaxResult.Success();
        }
    }
}
