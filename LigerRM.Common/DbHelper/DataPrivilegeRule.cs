using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Data;
using Liger.Model;
using System.Configuration;
using Liger.Common.Extensions;
namespace LigerRM.Common
{
    //数据权限规则的处理类
    public class DataPrivilegeRule
    {

         public DbContext DbContext { get; set; }

         public DataPrivilegeRule(DbContext dbContext)
         {
             this.DbContext = dbContext;
         }

         //注意这里是读取配置文件，你也可以改成读取数据库等其他方式
         public static int AdminUserID = ConfigurationManager.AppSettings["AdminUserID"].ToInt();
         public static int AdminRoleID = ConfigurationManager.AppSettings["AdminRoleID"].ToInt();
         public static bool EnabledPermission = ConfigurationManager.AppSettings["EnabledPermission"].ToBool();

         /// <summary>
         /// 判断当前用户是否是管理员
         /// </summary>
         /// <returns></returns>
         public static bool IsAdministrator()
         {
             if (SysContext.CurrentUserID == AdminUserID && AdminUserID != 0) return true;
             //如果没有配置管理员角色
             if (AdminRoleID == 0) return false;

             if (SysContext.CurrentRoleID.ToInt() == AdminRoleID) return true;

             var roleids = SysContext.CurrentRoleID.Split(',');

             if (roleids.Contains(AdminRoleID.ToStr())) return true;

             return false;
         }

         public static bool IsAdministrator(int userId,string[] roleids)
         {
             if (userId == AdminUserID && AdminUserID != 0) return true;
             //如果没有配置管理员角色
             if (AdminRoleID == 0) return false;

             if (SysContext.CurrentRoleID.ToInt() == AdminRoleID) return true;

             //var roleids = SysContext.CurrentRoleID.Split(',');
             foreach (string role in roleids)
             {
                 if (role == AdminRoleID.ToString())
                 {
                     return true;
                 }
             }
             //if (roleids.Contains(AdminRoleID.ToStr())) return true;

             return false;
         }

        /// <summary>
        /// 获取权限条件规则
        /// </summary>
        /// <returns></returns>
        public FilterGroup GetRuleGroup(string view)
        { 
            var entity = this.DbContext.From<CFDataPrivilege>().Where(CFDataPrivilege._.DataPrivilegeView == view).ToFirst();

            if (entity == null) return null;
            if (string.IsNullOrEmpty(entity.DataPrivilegeRule)) return null;
            return JSONHelper.FromJson<FilterGroup>(entity.DataPrivilegeRule);
        }

        /// <summary>
        /// 数据权限规则（跟业务规则合并）
        /// </summary>
        /// <param name="view"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public FilterGroup GetRuleGroup(string view, FilterGroup rule)
        {
            //如果没有启用权限控制，不需要合并【数据权限】
            if (!EnabledPermission) return rule;
            //如果是管理员，不需要合并【数据权限】
            if (IsAdministrator()) return rule;

            var dpRule = GetRuleGroup(view);
            if (dpRule == null) return rule;

            return new FilterGroup()
            {
                op = "and",
                groups = new List<FilterGroup>()
                {
                    rule,
                    dpRule
                }
            }; 
        }
    }
}
