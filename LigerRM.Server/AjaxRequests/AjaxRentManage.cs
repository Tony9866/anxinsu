
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LigerRM.Common;
using Liger.Data;
using System.Data;
using SignetInternet_BusinessLayer;

namespace LigerRM.Server.AjaxRequests
{
    public class AjaxRentManage
    {
        public static DbContext DB = DbHelper.Db;

        public static AjaxResult AddRentRecord(string name,string idcard)
        {

            string sql = "select * from rent_rentattribute where (('" + DateTime.Now + "'>=RRAStartDate and '" + DateTime.Now.ToString() + "'< RRAEndDate)" +
            " or ('" + DateTime.Now.AddDays(4).ToString() + "'>RRAStartDate and '" + DateTime.Now.AddDays(4).ToString() + "'<=RRAEndDate) or ('" + DateTime.Now.ToString() + "'<RRAStartDate and '" + DateTime.Now.AddDays(4).ToString() + "'>RRAEndDate)) and rrastatus not in ('5','7','8','9') order by RRACreatedDate desc";
            DataTable dt1 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

            Dictionary<string, string> used = new Dictionary<string, string>();
            Dictionary<string,string> all = new Dictionary<string,string>();
            Dictionary<string, string> left = new Dictionary<string, string>();
            foreach (DataRow r in dt1.Rows)
            {
                used.Add(r["rraId"].ToString(), r["RentNO"].ToString());
            }

            sql = "select * from v_RentDetail_view where RIDCard=(select idcard from CF_User where LoginName='" + LigerRM.Common.SysContext.CurrentUserName + "')";
            DataTable dt = DB.ExecuteDataSet(sql).Tables[0];

            foreach (DataRow r in dt.Rows)
            {
                all.Add(r["rid"].ToString(), r["RentNO"].ToString());
            }

            foreach (KeyValuePair<string, string> p in all)
            {
                if (!used.Values.Contains(p.Value))
                    left.Add(p.Key, p.Value);
            }

            string rentNo = string.Empty;

            if (left.Count == 0)
            {
                Random ran = new Random(1);
                int index = ran.Next(0, all.Count);
                rentNo = dt.Rows[index]["RentNO"].ToString();
            }
            else
            {
                Random ran = new Random(1);
                int index = ran.Next(0, left.Count);
                rentNo = left.Values.ToList()[index];
            }
            RentInfo rentInfo = new RentInfo(rentNo);
            //租户身份扫描

            RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();

            RentAttribute rentAttribute = new RentAttribute(rentInfo.RentNo);
            rentAttribute.RentNo = rentInfo.RentNo;
            rentAttribute.RRAContactName = name;
            rentAttribute.RRAContactTel = string.Empty;
            rentAttribute.RRANationName = string.Empty;
            rentAttribute.RRAIDCard = idcard;
            rentAttribute.RRentPrice = Convert.ToDecimal(rentInfo.RLocationDescription);
            rentAttribute.RRAContactProvince = string.Empty;
            rentAttribute.RRAStartDate = DateTime.Now;
            rentAttribute.RRAEndDate = DateTime.Now.AddDays(4);
            rentAttribute.RRADescription = string.Empty;
            rentAttribute.Status = ((int)RentAttributeHelper.AttributeStatus.Complete).ToString();
            rentAttribute.RRACreatedBy = SysContext.CurrentUserName;
            rentAttribute.RRACreatedDate = System.DateTime.Now;
            RentAttributeHelper helper = new RentAttributeHelper();
            string number = helper.AddRentAttribute(rentAttribute);

            //写入华泽数据
            helper.UploadDataToHZ(number, rentInfo.RentNo);
            return AjaxResult.Success();
        } 
    }
}
