using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Liger.Data;
using System.Web.UI;
using System.Data; 

namespace LigerRM.Common
{
    /// <summary>
    /// 带权限控制的页面基类
    /// </summary>
    public class ViewPageBase : System.Web.UI.Page 
    {

        public enum RentPropertyEnumList
        {
            RoomType = 1,
            Direction = 2,
            Structure = 6,
            BuildingType = 7,
            Property = 8,
            Province = 18,
            NationName = 19,
            RentType = 26,
            OwnType = 27
        }
        /// <summary>
        /// 权限控制
        /// </summary>
        private void CheckPermission()
        {
            //权限判断
            if (SysContext.CurrentUserID == 0)
            {
                Response.Redirect("~/login.htm?FromUrl=" + HttpUtility.UrlEncode(Request.Url.AbsoluteUri));
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.CheckPermission();
            //this.CheckSingleUserLogin();
        }

        private void CheckSingleUserLogin()
        {
            //权限判断
            string currentIp = Global.GlobalHelper.GetIPAddress();
            string oldIp = string.Empty;
            DataSet ds = DbHelper.Db.ExecuteDataSet("select * from CF_UserLoginStatus where UserID=" + SysContext.CurrentUserID.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                oldIp = ds.Tables[0].Rows[0]["LoginIP"].ToString();
            }
            if (!currentIp.Equals(oldIp))
            {
                CookieHelper.RemoveCookie("CurrentUserID");
                Response.Redirect("~/login.htm?FromUrl=" + HttpUtility.UrlEncode(Request.Url.AbsoluteUri));
            }
        }
    }
}
