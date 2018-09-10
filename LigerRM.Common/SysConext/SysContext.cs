using System.Collections.Generic;
using Liger.Common.Extensions;
using System;

namespace LigerRM.Common
{
    public sealed class SysContext
    {
        public static void SetCurrent(int userid)
        {
            CurrentUserID = userid; 
        }

        public static void ClearUserStatus()
        {
            CookieHelper.SetCookie("CurrentUserID", "0", DateTime.Now);
        }

        /// <summary>
        /// 当前用户角色 多个用逗号隔开
        /// </summary>
        public static string CurrentRoleID
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentRoleID").ToStr();
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentRoleID");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentRoleID", value, DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentRoleID", value, DateTime.Now.AddHours(2));
                }

            }
        }
        /// <summary>
        /// 当前用户部门
        /// </summary>
        public static string CurrentDeptID
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentDeptID");
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentDeptID");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentDeptID", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentDeptID", value.ToStr(), DateTime.Now.AddHours(2));
                } 
            }
        }

        public static string CurrentAreaIDs
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentAreaIDs").ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentAreaIDs");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentAreaIDs", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentAreaIDs", value.ToStr(), DateTime.Now.AddHours(2));
                }
            }
        }

        public static string CurrentRealName
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentRealName").ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentRealName");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentRealName", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentRealName", value.ToStr(), DateTime.Now.AddHours(2));
                }
            }
        }

        public static string CurrentCarveIDs
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentCarveIDs").ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentCarveIDs");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentCarveIDs", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentCarveIDs", value.ToStr(), DateTime.Now.AddHours(2));
                }
            }
        }
        /// <summary>
        /// 供应商ID 如果当前用户是供应商，需要这个
        /// </summary>
        public static string CurrentSupplierID
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentSupplierID");
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentSupplierID");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentSupplierID", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentSupplierID", value.ToStr(), DateTime.Now.AddHours(2));
                }
            }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public static int CurrentUserID
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentUserID").ToInt();
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentUserID");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentUserID", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentUserID", value.ToStr(), DateTime.Now.AddHours(2));
                }
                
            }
        }

        public static string CurrentUserName
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentUserName").ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentUserName");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentUserName", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentUserName", value.ToStr(), DateTime.Now.AddHours(2));
                }

            }
        }


        public static string CurrentEmployeeID
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentEmployeeID");
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentEmployeeID");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentEmployeeID", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentEmployeeID", value.ToStr(), DateTime.Now.AddHours(2));
                }
            }
        }



        /// <summary>
        /// 上次登录时间
        /// </summary>
        public static string CurrentUserLastLoginTime
        {
            get
            {
                  return CookieHelper.GetCookieValue("CurrentUserLastLoginTime"); 
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentUserLastLoginTime");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentUserLastLoginTime", value.ToStr(), DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentUserLastLoginTime", value.ToStr(), DateTime.Now.AddHours(2));
                }
            }
        }



        public static string CurrentUserTitle
        {
            get
            {
                try
                {
                    return CookieHelper.GetCookieValue("CurrentUserTitle").ToStr();
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                var cookie = CookieHelper.GetCookie("CurrentUserTitle");
                if (cookie != null)
                {
                    CookieHelper.SetCookie("CurrentUserTitle", value, DateTime.Now.AddHours(2));
                }
                else
                {
                    //有效期，一个钟头
                    CookieHelper.AddCookie("CurrentUserTitle", value, DateTime.Now.AddHours(2));
                }

            }
        }
    }
}
