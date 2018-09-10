using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Liger.Common;
using Liger.Data;
using Liger.Common.Extensions;
using Liger.Model;
using LigerRM.Common; 
using Liger.Data.Linq;
using System.Text.RegularExpressions;
using System.Data;
using SignetInternet_BusinessLayer;

public class SystemService
{
    public static DbContext DB = DbHelper.Db;

    //注意这里是读取配置文件，你也可以改成读取数据库等其他方式
    public static int AdminUserID = ConfigurationManager.AppSettings["AdminUserID"].ToInt();
    public static int AdminRoleID = ConfigurationManager.AppSettings["AdminRoleID"].ToInt();
    public static bool EnabledPermission = ConfigurationManager.AppSettings["EnabledPermission"].ToBool();

    /// <summary>
    /// 判断指定用户是否管理员
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    public static bool IsAdministrator(int UserID)
    { 
        if (UserID == AdminUserID && AdminUserID != 0) return true;
        //如果没有配置管理员角色
        if(AdminRoleID == 0) return false; 

        //如果用户的角色包括 AdminRoleID
        return DB.From<CFUserRole>().Where(CFUserRole._.UserID == UserID && CFUserRole._.RoleID == AdminRoleID).Count() > 0;
    }

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

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <returns></returns>
    public static bool UserLogin(string username,string password)
    {
        string tempPass = Encrypt.DESEncrypt(password);
        var loginSuccess = DB.From<CFUser>().Where(CFUser._.LoginName == username && CFUser._.LoginPassword == tempPass).Any();
        if (loginSuccess)
        {
            var user = DB.From<CFUser>().Where(CFUser._.LoginName == username && CFUser._.LoginPassword == tempPass).ToFirst();


            var roles = DB.From<CFUserRole>().Where(CFUserRole._.UserID == user.UserID).ToList();

            var roleids = Array.ConvertAll<int, string>(roles.Select(c => c.RoleID).ToArray(), c => c.ToStr());

            string regDeptIds = string.Empty;
            string carveCorpIds = string.Empty;

            //UserInfoHelper helper = new UserInfoHelper();

            DataTable dt = null;


            SysContext.CurrentUserID = user.UserID;

            SysContext.CurrentDeptID = user.DeptID;

            SysContext.CurrentEmployeeID = user.EmployeeID;

            SysContext.CurrentSupplierID = user.SupplierID;

            if (user.LastLoginTime.HasValue)
                SysContext.CurrentUserLastLoginTime = user.LastLoginTime.Value.ToString();

            if (user.LoginName.HasValue())
                SysContext.CurrentUserName = user.LoginName;

            SysContext.CurrentUserTitle = user.Title;

            SysContext.CurrentRealName = user.RealName;

            SysContext.CurrentRoleID = string.Join(",", roleids);

            UserInfoHelper helper = new UserInfoHelper();
            if (DataPrivilegeRule.IsAdministrator(user.UserID, roleids))
            {

                dt = helper.GetRegDeptList();
                foreach (DataRow row in dt.Rows)
                {
                    regDeptIds += ",'" + row["PSID"].ToString() + "'";
                }

                dt = helper.GetCummunityList();
                foreach (DataRow row in dt.Rows)
                {
                    carveCorpIds += ",'" + row["LSID"].ToString() + "'";
                }

            }
            else
            {
                
                dt = helper.GetUserRegRelationList(user.UserID.ToString());
                foreach (DataRow row in dt.Rows)
                {
                    regDeptIds += ",'" + row["t_ad_reg_dept_id"].ToString() + "'";
                }

                dt = helper.GetCummunityListByUser(user.UserID.ToString());
                foreach (DataRow row in dt.Rows)
                {
                    carveCorpIds += ",'" + row["t_ad_reg_dept_id"].ToString() + "'";
                }
            }

            if (!string.IsNullOrEmpty(regDeptIds))
            {
                regDeptIds = regDeptIds.Substring(1);
                SysContext.CurrentAreaIDs = regDeptIds;
            }
            else
            {
                regDeptIds = "'undefined'";
                SysContext.CurrentAreaIDs = regDeptIds;
            }

            if (!string.IsNullOrEmpty(carveCorpIds))
            {
                carveCorpIds = carveCorpIds.Substring(1);
                SysContext.CurrentCarveIDs = carveCorpIds;
            }
            else
            { 
                carveCorpIds = "'undefined'";
                SysContext.CurrentCarveIDs = carveCorpIds;
            }

            LogManager.WriteLog("USER", user.RealName + " 登录系统");

            user.Attach();
            user.LastLoginTime = DateTime.Now;
            DB.Update<CFUser>(user);

            string currentIp = LigerRM.Common.Global.GlobalHelper.GetIPAddress();
            DataSet ds = DB.ExecuteDataSet("select * from CF_UserLoginStatus where UserID=" + SysContext.CurrentUserID.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DB.ExecuteDataSet("Update CF_UserLoginStatus set LoginTime='" + DateTime.Now.ToString() + "', LoginIP='" + currentIp + "', IsOnline=1 where UserID=" + SysContext.CurrentUserID.ToString());
            }
            else
            {
                DB.ExecuteDataSet("insert into CF_UserLoginStatus values (" + SysContext.CurrentUserID.ToString() + ",'" + DateTime.Now.ToString() + "','" + currentIp + "',1) ");
            }

        }
        return loginSuccess;
    } 

    /// <summary>
    /// 获取指定用户有权限的菜单列表
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    public static List<SysMenu> GetUserMenus(int UserID)
    { 
        //如果没有启用权限控制，或者是管理员，直接获取全部菜单
        if (!EnabledPermission || IsAdministrator(UserID))
            return DB.From<SysMenu>().ToList();

        var sql = GetUserMenusCommandText(UserID);

        var ds = DB.ExecuteDataSet(sql);

        if (ds == null || ds.Tables.Count == 0)
            return new List<SysMenu>();

        return DbEntityHelper.DataTableToEntities<SysMenu>(ds.Tables[0]);
    }


    private static string GetUserMenusCommandText(int UserID)
    {
        string sql = @" select * from sys_menu where (menuid in({0}) or menuid in({1})) and menuid not in ({2}) ";

        //子查询1：获取用户有权限的菜单ID
        string query1 = @"select distinct PrivilegeAccessKey from CF_Privilege where PrivilegeMaster = 'CF_User' and PrivilegeMasterKey = {0} and PrivilegeAccess = 'Sys_Menu' and PrivilegeOperation = 'Permit'".FormatWith(UserID);
        //子查询2：获取用户所属角色有权限的菜单ID
        string query2 = @"select distinct PrivilegeAccessKey from CF_Privilege where PrivilegeMaster = 'CF_Role' and PrivilegeMasterKey in (select RoleID from CF_UserRole where UserID = {0}) and PrivilegeAccess = 'Sys_Menu' and PrivilegeOperation = 'Permit'".FormatWith(UserID);
        //子查询3：获取用户禁止权限的菜单ID
        string query3 = @"select distinct PrivilegeAccessKey from CF_Privilege where PrivilegeMaster = 'CF_User' and PrivilegeMasterKey = {0} and PrivilegeAccess = 'Sys_Menu' and PrivilegeOperation = 'Forbid'".FormatWith(UserID);

        sql = sql.FormatWith(query1, query2, query3);

        return sql;
    }



    /// <summary>
    /// 获取指定用户有权限的菜单列表(JSON Tree格式)
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    public static string GetUserMenusTreeJSON(int UserID)
    {
        var sql = "select * from sys_menu ";
        //如果没有启用权限控制，或者是管理员，直接获取全部菜单
        if (EnabledPermission && !IsAdministrator(UserID))
        {
            sql = GetUserMenusCommandText(UserID);
        }
        sql = sql.Trim();

        sql = new Regex("^select \\*", RegexOptions.IgnoreCase).Replace(sql, "select MenuID as [id],MenuNo,MenuParentNo,MenuID,MenuName as [text],MenuName,MenuIcon as [icon],MenuIcon,MenuUrl");

        sql += " order by MenuOrder asc";
        return JSONHelper.GetArrayJSON(sql, "MenuNo", "MenuParentNo"); 
    }

    /// <summary>
    /// 获取指定用户和指定菜单有权限的按钮列表
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="MenuNo"></param>
    /// <returns></returns>
    public static List<SysButton> GetUserButtons(int UserID,string MenuNo)
    {
        var buttons = DB.From<SysButton>().Where(SysButton._.MenuNo == MenuNo).ToList();

        //如果没有启用权限控制，或者是管理员，直接获取全部按钮
        if (!EnabledPermission || IsAdministrator(UserID)) 
            return buttons;

        //只获取有权限的
        return buttons.Where(c => HasButtonPermission(UserID, c.BtnID)).ToList();
    }


     /// <summary>
     /// 判断某按钮是否有权限
     /// </summary>
     /// <param name="UserID"></param>
     /// <param name="Roles"></param>
     /// <returns></returns>
    public static bool HasButtonPermission(int UserID, int BtnID)
    {
        string queryPermit = @"select count(*) from CF_Privilege where 
        (PrivilegeAccess = 'Sys_Button' and PrivilegeAccessKey = {1}) and (
        (PrivilegeMaster = 'CF_User' and PrivilegeMasterKey = {0} and PrivilegeOperation = 'Permit') or
        (PrivilegeMaster = 'CF_Role' and PrivilegeMasterKey in (select distinct RoleID from CF_UserRole where UserID = {0}))
        )
".FormatWith(UserID, BtnID);

        string queryForbid = @"select count(*) from CF_Privilege where 
        PrivilegeAccess = 'Sys_Button' and PrivilegeAccessKey = {1} and
        PrivilegeMaster = 'CF_User' and PrivilegeMasterKey = {0} and PrivilegeOperation = 'Forbid'
".FormatWith(UserID, BtnID);

        return DB.ExecuteScalar(queryPermit).ToInt() > 0 && DB.ExecuteScalar(queryForbid).ToInt() == 0;
    }

    #region 页面配置信息
    /// <summary>
    /// 获取列表页面配置信息(JSON格式)
    /// </summary>
    /// <returns></returns>
    public static string GetListPageConfig(string view)
    {
        var config = DB.From<CFConfiguration>().Where(CFConfiguration._.View == view)
            .Select(CFConfiguration._.Search, CFConfiguration._.Grid)
            .ToFirst();
        if (config == null) return "null";
        if (config.Grid.IsNullOrEmpty()) config.Grid = "null";
        if (config.Search.IsNullOrEmpty()) config.Search = "null";
        return "{" + @"""Grid"":{0},""Search"":{1}".FormatWith(config.Grid, config.Search) + "}";
    }


    /// <summary>
    /// 获取明细页面配置信息(JSON格式)
    /// </summary>
    /// <returns></returns>
    public static string GetDetailPageConfig(string view)
    {
        var config = DB.From<CFConfiguration>().Where(CFConfiguration._.View == view)
            .Select(CFConfiguration._.Form)
            .ToFirst();
        if (config == null) return "null";
        if (config.Form.IsNullOrEmpty()) config.Form = "null";
        return "{" + @"""Form"":{0}".FormatWith(config.Form) + "}";
    }

    /// <summary>
    /// 获取页面配置信息(JSON格式)
    /// </summary>
    /// <returns></returns>
    public static string GetPageConfig(string view)
    {
        var config = DB.From<CFConfiguration>().Where(CFConfiguration._.View == view)
            .ToFirst();
        if (config == null) return "null";
        if (config.Form.IsNullOrEmpty()) config.Form = "null";
        if (config.Grid.IsNullOrEmpty()) config.Grid = "null";
        if (config.Search.IsNullOrEmpty()) config.Search = "null";
        return "{" + @"""Grid"":{0},""Search"":{1},""Form"":{2}".FormatWith(config.Grid, config.Search, config.Form) + "}";
    }
    #endregion

    #region 用户 角色的JSON信息
    /// <summary>
    /// 获取全部用户账户列表
    /// </summary>
    /// <returns></returns>
    public static string GetUserListJSON()
    {
        var sql = "select UserID,LoginName,[Title] from CF_User";
        sql += " where UserID <> {0}".FormatWith(AdminUserID);
        sql += " and UserID not in (select UserID from CF_UserRole where RoleID = {0}) ".FormatWith(AdminRoleID);

        return JSONHelper.ExecuteCommandToJSON(sql);
    }

    /// <summary>
    /// 获取全部角色列表
    /// </summary>
    /// <returns></returns>
    public static string GetRoleListJSON()
    {
        var sql = "select RoleID,RoleName from CF_Role where RoleID <> {0} ".FormatWith(AdminRoleID);

        return JSONHelper.ExecuteCommandToJSON(sql);
    }
    #endregion


    #region 字段权限 JSON 配置

    /// <summary>
    /// 获取字段权限
    /// </summary>
    /// <param name="view"></param>
    /// <returns></returns>
    public static string GetFieldPrivilege(string view)
    {
        string sql = @"select PrivilegeMaster,PrivilegeMasterKey,PrivilegeAccess,PrivilegeAccessKey,PrivilegeOperation from CF_Privilege";
        sql += " where PrivilegeAccess like '{0}.%'".FormatWith(view);

        return JSONHelper.ExecuteCommandToJSON(sql);
    }


    /// <summary>
    /// 获取当前用 指定视图 禁止的字段列表
    /// </summary>
    /// <param name="view"></param>
    /// <returns></returns>
    public static string GetForbidFields(string view)
    {  
        //如果没有启用权限控制，或者是管理员，不作限制
        if (!EnabledPermission || IsAdministrator(SysContext.CurrentUserID))
            return "[]";

        var userid = SysContext.CurrentUserID;
        string sql = @"select PrivilegeAccess from CF_Privilege";
        sql += " where PrivilegeAccess like '{0}.%'".FormatWith(view);
        sql += " and (";
        sql += @"    (PrivilegeMaster = 'CF_User' and PrivilegeMasterKey = {0}) or ".FormatWith(userid);
        sql += @"    (PrivilegeMaster = 'CF_Role' and PrivilegeMasterKey in (select RoleID from CF_UserRole where UserID = {0})) ".FormatWith(userid);
        sql += ")";
        sql += " and PrivilegeOperation = 'Forbid' ";

        var reader = DB.ExecuteReader(sql);
        var fields = new List<string>();
        while (reader.Read())
        {
            fields.Add(reader["PrivilegeAccess"].ToStr().Replace(view + ".", ""));
        } 
        return JSONHelper.ToJson(fields);
    }


    #endregion

    public static bool ValidateLoginTimes(string userid, int times, int minutes)
    {
        int tempTime = 0;
        string sql = string.Empty;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddMinutes(0-minutes);
        sql = "select top "+times.ToString()+" LogID,status,LoginTime from Sys_LoginLog where LoginID='"+userid+"' order by LoginTime desc";
        DataTable dt = DB.ExecuteDataSet(sql).Tables[0];
        if (dt.Rows.Count < times)
            return true;
        else
        {
            if (DateTime.Parse(dt.Rows[0]["LoginTime"].ToString()).AddMinutes(0 - minutes) <= DateTime.Parse(dt.Rows[dt.Rows.Count-1]["LoginTime"].ToString()))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!dt.Rows[i]["Status"].ToBool())
                    {
                        tempTime++;
                        if (tempTime >= times)
                        {
                            if (DateTime.Parse(dt.Rows[0]["LoginTime"].ToString()).AddMinutes(10) > DateTime.Now)
                                return false;
                            else
                                return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
                return true;
        }
        return true;
    }

    public static bool AddLoginTimes(string userId,string status)
    { 
        DB.ExecuteNonQuery("insert into Sys_LoginLog values ('"+userId+"','"+DateTime.Now.ToString()+"',"+status+")");
        return true;
    }

    public static bool ValidateRegions(string username)
    {
        DataSet ds = DB.ExecuteDataSet("select * from t_user_dept_relationship where t_wu_user_id=(select userid from CF_User where LoginName = '" + username + "')");
        DataSet ds1 = DB.ExecuteDataSet("select * from t_carve_corp_user_ref where UserID=(select userid from CF_User where LoginName = '" + username + "')");

        return ds.Tables[0].Rows.Count > 0 && ds1.Tables[0].Rows.Count > 0;
    }
}