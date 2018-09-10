using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;

using LigerRM.Common; 
using Liger.Model;
using Liger.Data;
using Liger.Common;
using Liger.Common.Extensions;
using Liger.Data.Extensions;
using LigerRM.Service.Setting;

namespace LigerRM.Service
{
    public class AjaxSystem
    {
        public static DbContext DB = DbHelper.Db;
        public HttpContext Context;

        public AjaxSystem()
        {
        }
        public AjaxSystem(HttpContext context)
        {
            this.Context = context;
        }

        public AjaxResult GetIcons(string ID)
        {
            try
            {
                var cache = CacheHelper.Get("SystemIcons");
                if (cache != null)
                {
                    return AjaxResult.Success(cache);
                }
                var rootPath = Context.Server.MapPath("~/lib/icons/");
                string dirPath = rootPath + "32X32\\";
                var files = System.IO.Directory.GetFiles(dirPath);

                //缓存一天吧
                CacheHelper.Insert("SystemIcons", files, 60 * 60 * 24);
                return AjaxResult.Success(files);
            }
            catch (Exception err)
            {
                return AjaxResult.Error("系统错误:" + err.Message);
            }
        } 

        #region 角色

        public static AjaxResult AddRole(CFRole entity)
        {
            return DB.InsertEntity<CFRole>(entity);
        }
        public static AjaxResult UpdateRole(CFRole entity)
        {
            return DB.UpdateEntity<CFRole>(entity);
        }
        public static AjaxResult RemoveRole(string RoleID)
        {
            return DB.DeleteEntity<CFRole>(RoleID);
        }
        #endregion

        #region 菜单
        public static AjaxResult AddMenu(SysMenu entity)
        {
            entity.MenuIcon = entity.MenuIcon.Substring(entity.MenuIcon.IndexOf("lib/"));
            return DB.InsertEntity<SysMenu>(entity);
        }

        public static AjaxResult UpdateMenu(SysMenu entity)
        {
            entity.MenuIcon = entity.MenuIcon.Substring(entity.MenuIcon.IndexOf("lib/"));
            return DB.UpdateEntity<SysMenu>(entity);
        }
        public static AjaxResult RemoveMenu(string MenuID)
        {
            return DB.DeleteEntity<SysMenu>(MenuID);
        }
        #endregion

        #region 按钮
        public static AjaxResult AddButton(SysButton entity)
        {
            entity.BtnIcon = entity.BtnIcon.Substring(entity.BtnIcon.IndexOf("lib/"));
            return DB.InsertEntity<SysButton>(entity);
        }
        public static AjaxResult UpdateButton(SysButton entity)
        {
            entity.BtnIcon = entity.BtnIcon.Substring(entity.BtnIcon.IndexOf("lib/"));
            return DB.UpdateEntity<SysButton>(entity);
        }
        public static AjaxResult RemoveButton(string BtnID)
        {
            return DB.DeleteEntity<SysButton>(BtnID);
        }
        public static AjaxResult AddCUDButtons(string MenuNo)
        {
            try
            {
                DB.BeginTransaction();
                //SysButton btn = new SysButton();
                //btn.BtnID = 0;
                //btn.MenuNo = MenuNo;
                //btn.BtnName = "增加";
                //btn.BtnNo = "add";
                //btn.BtnIcon = "lib/icons/silkicons/add.png";
                //return DB.InsertEntity<SysButton>(btn);

                //btn = new SysButton();
                //btn.BtnID = 0;
                //btn.MenuNo = MenuNo;
                //btn.BtnName = "修改";
                //btn.BtnNo = "modify";
                //btn.BtnIcon = "lib/icons/silkicons/application_edit.png";
                //DB.InsertEntity<SysButton>(btn);

                //btn = new SysButton();
                //btn.BtnID = 0;
                //btn.MenuNo = MenuNo;
                //btn.BtnName = "删除";
                //btn.BtnNo = "delete";
                //btn.BtnIcon = "lib/icons/silkicons/delete.png";
                //DB.InsertEntity<SysButton>(btn);

                //btn = new SysButton();
                //btn.BtnID = 0;
                //btn.MenuNo = MenuNo;
                //btn.BtnName = "查看";
                //btn.BtnNo = "view";
                //btn.BtnIcon = "lib/icons/silkicons/application_view_detail.png";
                //DB.InsertEntity<SysButton>(btn);
                DB.Insert<SysButton>(new SysButton()
                {
                    MenuNo = MenuNo,
                    BtnName = "增加",
                    BtnNo = "add",
                    BtnIcon = "lib/icons/silkicons/add.png"
                });
                DB.Insert<SysButton>(new SysButton()
                {
                    MenuNo = MenuNo,
                    BtnName = "修改",
                    BtnNo = "modify",
                    BtnIcon = "lib/icons/silkicons/application_edit.png"
                });
                DB.Insert<SysButton>(new SysButton()
                {
                    MenuNo = MenuNo,
                    BtnName = "删除",
                    BtnNo = "delete",
                    BtnIcon = "lib/icons/silkicons/delete.png"
                });
                DB.Insert<SysButton>(new SysButton()
                {
                    MenuNo = MenuNo,
                    BtnName = "查看",
                    BtnNo = "view",
                    BtnIcon = "lib/icons/silkicons/application_view_detail.png"
                });
                DB.CommitTransaction();
                DB.CloseTransaction();
                return AjaxResult.Success();
            }
            catch (Exception err)
            {
                DB.RollbackTransaction();
                DB.CloseTransaction();
                return AjaxResult.Error(err.Message);
            }
        }


        public static AjaxResult ClearButtons(string MenuNo)
        {
            try
            {
                var result = DB.Delete<SysButton>(SysButton._.MenuNo == MenuNo);
                if (result == 0)
                {
                    return AjaxResult.Error("删除失败");
                }
                else
                {
                    return AjaxResult.Success(result, "删除 成功");
                }
            }
            catch (Exception err)
            {
                LogManager.WriteLog("Error", err.Message);
                return AjaxResult.Error("系统错误:" + err.Message);
            }
        }
        #endregion

        #region 数据权限

        /// <summary>
        /// 获取 数据权限 
        /// </summary>
        public static AjaxResult GetDataPrivilege(string ID)
        {
            return DB.GetEntity<CFDataPrivilege>(CFDataPrivilege._.DataPrivilegeID == ID);
        }
        /// <summary>
        /// 增加 数据权限 
        /// </summary>
        public static AjaxResult AddDataPrivilege(NameValueCollection form)
        {
            var entity = new CFDataPrivilege();
            entity.Load(form);
            return DB.InsertEntity<CFDataPrivilege>(entity);
        }
        /// <summary>
        /// 更新 数据权限 
        /// </summary>
        public static AjaxResult UpdateDataPrivilege(NameValueCollection form)
        {
            var entity = DB.From<CFDataPrivilege>().Where(CFDataPrivilege._.DataPrivilegeID == form["DataPrivilegeID"]).ToFirst();
            entity.Attach();
            entity.Load(form);
            return DB.UpdateEntity<CFDataPrivilege>(entity);
        }
        /// <summary>
        /// 删除 数据权限 
        /// </summary>
        public static AjaxResult RemoveDataPrivilege(string ID)
        {
            return DB.DeleteEntity<CFDataPrivilege>(ID);
        }


        #endregion

        #region  底层 方法 执行权限


        public static AjaxResult GetAdminMethodSetting()
        {
            return AjaxResult.Success(MethodSettingHelper.GetSettings());
        }

        public static AjaxResult SaveAdminMethodSetting(string data)
        {
            var actions = new JavaScriptSerializer().Deserialize<IList<string>>(data);
            var settings = new List<MethodSetting>();
            foreach (var action in actions)
            {
                var typename = action.Split('.')[0];
                var methodname = action.Split('.')[1];
                settings.Add(new MethodSetting()
                {
                    name = methodname,
                    type = typename
                });
            }
            MethodSettingHelper.SetSettings(settings);
            return AjaxResult.Success();
        }
        #endregion 

        #region 菜单-按钮 列表
        private static Dictionary<string, object> ConvertMenu(SysMenu entity)
        {
            return new Dictionary<string, object>()
            {
                {"AccessName",entity.MenuName},
                {"AccessIcon",entity.MenuIcon},
                {"AccessNo",entity.MenuNo}, 
                {"MenuID",entity.MenuID},
                {"BtnID",0}
            };
        }

        private static List<Dictionary<string, object>> ConvertMenuButtons(SysMenu entity, List<SysButton> buttons)
        {
            var menuButtons = buttons.Where(c => c.MenuNo == entity.MenuNo);
            if (menuButtons == null || menuButtons.Count() == 0)
                return new List<Dictionary<string, object>>();
            var dicList = new List<Dictionary<string, object>>();
            foreach (var menuButton in menuButtons)
            {
                dicList.Add(new Dictionary<string, object>()
            {
                {"AccessName",menuButton.BtnName},
                {"AccessIcon",menuButton.BtnIcon},
                {"AccessNo",menuButton.BtnNo},
                {"MenuID",0},
                {"BtnID",menuButton.BtnID}
            });
            }
            return dicList;
        }

        public static AjaxResult GetAccess()
        {
            var menus = DB.From<SysMenu>().ToList();
            var buttons = DB.From<SysButton>().ToList();

            //一级菜单
            var pmenus = menus.Where(c => string.IsNullOrEmpty(c.MenuParentNo));

            var data = new List<Dictionary<string, object>>();

            foreach (var pmenu in pmenus)
            {
                var dic = ConvertMenu(pmenu);

                //二级菜单
                var menuChildren = menus.Where(c => c.MenuParentNo == pmenu.MenuNo);

                if (menuChildren != null && menuChildren.Count() != 0)
                {
                    var dicChildren = new List<Dictionary<string, object>>();
                    foreach (var subMenu in menuChildren)
                    {
                        var dicSubMenu = ConvertMenu(subMenu);
                        //按钮
                        dicSubMenu["children"] = ConvertMenuButtons(subMenu, buttons);
                        dicChildren.Add(dicSubMenu);
                    }
                    dic["children"] = dicChildren;
                }

                data.Add(dic);
            }
            return AjaxResult.Success(data);
        }

        #endregion

        #region 权限保存

        /// <summary>
        /// 保存用户权限
        /// </summary>
        /// <param name="DataJSON">前台权限列表的JSON</param>
        /// <param name="UserID">UserID</param>
        /// <returns></returns>
        public static AjaxResult SaveUserPermission(string DataJSON, int UserID)
        {
            try
            {
                var data = new JavaScriptSerializer().Deserialize<List<Dictionary<string, object>>>(DataJSON);
                DB.BeginTransaction();
                //先清空之前的权限分配
                DB.Delete<CFPrivilege>(
                    CFPrivilege._.PrivilegeMaster == "CF_User" &&
                    CFPrivilege._.PrivilegeMasterKey == UserID
                    );
                foreach (var item in data)
                {
                    //是否分配权限 
                    var Permit = (bool)item["Permit"];
                    //是否禁止权限
                    var Forbid = (bool)item["Forbid"];
                    //是否按钮
                    var isButton = item["BtnID"].ToInt() != 0;

                    int MenuID = item["MenuID"].ToInt();
                    int BtnID = item["BtnID"].ToInt();

                    if (Permit || Forbid)
                    {
                        DB.Insert<CFPrivilege>(new CFPrivilege()
                        {
                            PrivilegeMaster = "CF_User",
                            PrivilegeMasterKey = UserID,
                            PrivilegeAccess = isButton ? "Sys_Button" : "Sys_Menu",
                            PrivilegeAccessKey = isButton ? BtnID : MenuID,
                            PrivilegeOperation = Permit ? "Permit" : "Forbid"
                        });
                    }
                }
                DB.CommitTransaction();
                DB.CloseTransaction();
                return AjaxResult.Success();
            }
            catch (Exception err)
            {
                DB.RollbackTransaction();
                DB.CloseTransaction();
                return AjaxResult.Error(err.Message);
            }
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="DataJSON">前台权限列表的JSON</param>
        /// <param name="RoleID">RoleID</param>
        /// <returns></returns>
        public static AjaxResult SaveRolePermission(string DataJSON, int RoleID)
        {
            try
            {
                var data = new JavaScriptSerializer().Deserialize<List<Dictionary<string, object>>>(DataJSON);
                DB.BeginTransaction();
                //先清空之前的权限分配
                DB.Delete<CFPrivilege>(
                    CFPrivilege._.PrivilegeMaster == "CF_Role" &&
                    CFPrivilege._.PrivilegeMasterKey == RoleID
                    );
                foreach (var item in data)
                {
                    //是否分配权限 
                    var Permit = (bool)item["Permit"];
                    //是否按钮
                    var isButton = item["BtnID"].ToInt() != 0;

                    int MenuID = item["MenuID"].ToInt();
                    int BtnID = item["BtnID"].ToInt();

                    if (Permit)
                    {
                        DB.Insert<CFPrivilege>(new CFPrivilege()
                        {
                            PrivilegeMaster = "CF_Role",
                            PrivilegeMasterKey = RoleID,
                            PrivilegeAccess = isButton ? "Sys_Button" : "Sys_Menu",
                            PrivilegeAccessKey = isButton ? BtnID : MenuID,
                            PrivilegeOperation = "Permit"
                        });
                    }

                }
                DB.CommitTransaction();
                DB.CloseTransaction();
                return AjaxResult.Success();
            }
            catch (Exception err)
            {
                DB.RollbackTransaction();
                DB.CloseTransaction();
                return AjaxResult.Error(err.Message);
            }
        }

        #endregion

        #region 权限获取

        /// <summary>
        /// 获取指定角色有权限的 菜单/按钮 
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public static AjaxResult GetRolePermission(int RoleID)
        {
            var privilegeList = DB.From<CFPrivilege>().Where(
                   CFPrivilege._.PrivilegeMaster == "CF_Role" &&
                   CFPrivilege._.PrivilegeMasterKey == RoleID
                   ).ToList();
            if (privilegeList == null || privilegeList.Count == 0)
                return AjaxResult.Success();
            var dicList = new List<Dictionary<string, object>>();
            foreach (var privilege in privilegeList)
            {
                var dic = new Dictionary<string, object>();
                if (string.Compare(privilege.PrivilegeAccess, "Sys_Menu", true) == 0)
                {
                    dic["MenuID"] = privilege.PrivilegeAccessKey;
                    dic["BtnID"] = 0;
                }
                else
                {
                    dic["MenuID"] = 0;
                    dic["BtnID"] = privilege.PrivilegeAccessKey;
                }
                dicList.Add(dic);
            }
            return AjaxResult.Success(dicList);
        }


        /// <summary>
        /// 获取指定用户有权限控制(允许或禁止)的 菜单/按钮 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static AjaxResult GetUserPermission(int UserID)
        {
            var privilegeList = DB.From<CFPrivilege>().Where(
                   CFPrivilege._.PrivilegeMaster == "CF_User" &&
                   CFPrivilege._.PrivilegeMasterKey == UserID
                   ).ToList();
            if (privilegeList == null || privilegeList.Count == 0)
                return AjaxResult.Success();
            var dicList = new List<Dictionary<string, object>>();
            foreach (var privilege in privilegeList)
            {
                var dic = new Dictionary<string, object>();
                if (string.Compare(privilege.PrivilegeAccess, "Sys_Menu", true) == 0)
                {
                    dic["MenuID"] = privilege.PrivilegeAccessKey;
                    dic["BtnID"] = 0;
                }
                else
                {
                    dic["MenuID"] = 0;
                    dic["BtnID"] = privilege.PrivilegeAccessKey;
                }
                //是否分配权限
                dic["Permit"] = privilege.PrivilegeOperation == "Permit";
                //是否禁止权限
                dic["Forbid"] = privilege.PrivilegeOperation == "Forbid";
                dicList.Add(dic);
            }
            return AjaxResult.Success(dicList);
        }

        #endregion

        #region 获取有权限的按钮列表

        public AjaxResult GetMyButtons(string MenuNo)
        {
            //var buttons = DB.From<SysButton>().Where(SysButton._.MenuNo == MenuNo).ToList();

            var buttons = SystemService.GetUserButtons(SysContext.CurrentUserID, MenuNo);

            return AjaxResult.Success(buttons);
        }

        #endregion


        #region 改变密码

        public static AjaxResult ChangePassword(string OldPassword, string LoginPassword)
        {
            LogManager.WriteLog("USER", SysContext.CurrentUserTitle + " 修改密码");

            var user = DB.From<CFUser>().Where(CFUser._.UserID == SysContext.CurrentUserID).ToFirst();
            string tempOldPassword = SignetInternet_BusinessLayer.Encrypt.DESEncrypt(OldPassword);
            if (user.LoginPassword != tempOldPassword)
            {
                return AjaxResult.Error("旧密码输入错误");
            }
            user.Attach();
            user.LoginPassword = SignetInternet_BusinessLayer.Encrypt.DESEncrypt(LoginPassword);
            DB.Update<CFUser>(user);
            return AjaxResult.Success();
        }

        #endregion


        public static AjaxResult GetWhere(string groupJSON)
        {
            var group = new JavaScriptSerializer().Deserialize<FilterGroup>(groupJSON);

            var translator = new FilterTranslator(group);

            translator.Translate();

            return AjaxResult.Success((object)translator.ToString());
        }


        #region 收藏

        /// <summary>
        /// 获取 收藏 
        /// </summary>
        public static AjaxResult GetMyFavorite()
        {
            return AjaxResult.Success(DB.From<CFFavorite>().Where(CFFavorite._.UserID == SysContext.CurrentUserID).ToList());
        }

        /// <summary>
        /// 增加 收藏 
        /// </summary>
        public static AjaxResult AddMyFavorite(int MenuID, string FavoriteContent)
        {
            var entity = new CFFavorite();
            var menu = DB.From<SysMenu>().Where(SysMenu._.MenuID == MenuID).ToFirst();
            entity.FavoriteTitle = menu.MenuName;
            entity.FavoriteContent = FavoriteContent;
            entity.FavoriteAddTime = DateTime.Now;
            entity.Url = menu.MenuUrl;
            entity.Icon = menu.MenuIcon; 
            entity.UserID = SysContext.CurrentUserID;
            return DB.InsertEntity<CFFavorite>(entity);
        } 

        /// <summary>
        /// 删除 收藏 
        /// </summary>
        public static AjaxResult RemoveMyFavorite(string ID)
        {
            return DB.DeleteEntity<CFFavorite>(ID);
        }

        #endregion


        #region 页面配置信息(列表页、明细页)
        /// <summary>
        /// 获取 页面配置信息 
        /// </summary>
        public static AjaxResult GetConfiguration(string ID)
        {
            return DB.GetEntity<CFConfiguration>(CFConfiguration._.ConfigID == ID);
        }
        /// <summary>
        /// 增加 页面配置信息 
        /// </summary>
        public static AjaxResult AddConfiguration(NameValueCollection form)
        {
            var entity = new CFConfiguration();
            entity.Load(form);
            return DB.InsertEntity<CFConfiguration>(entity);
        }
        /// <summary>
        /// 更新 页面配置信息 
        /// </summary>
        public static AjaxResult UpdateConfiguration(NameValueCollection form)
        {
            var entity = DB.From<CFConfiguration>().Where(CFConfiguration._.ConfigID == form["ConfigID"]).ToFirst();
            entity.Attach();
            entity.Load(form);
            return DB.UpdateEntity<CFConfiguration>(entity);
        }
        /// <summary>
        /// 删除 页面配置信息 
        /// </summary>
        public static AjaxResult RemoveConfiguration(string ID)
        {
            return DB.DeleteEntity<CFConfiguration>(ID);
        }



        #endregion

        #region 保存字段权限

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="DataJSON"></param>
        /// <returns></returns>
        public static AjaxResult SaveFieldPrivilege(string DataJSON,string view)
        {
            try
            {
                var data = new JavaScriptSerializer().Deserialize<List<Dictionary<string, object>>>(DataJSON);
                DB.BeginTransaction();
                //先清空之前的权限分配
                DB.Delete<CFPrivilege>(
                    CFPrivilege._.PrivilegeAccess == view + ".Field"
                    );
                foreach (var item in data)
                { 
                    DB.Insert<CFPrivilege>(new CFPrivilege()
                    {
                        PrivilegeMaster = item["PrivilegeMaster"].ToStr(),
                        PrivilegeMasterKey = item["PrivilegeMasterKey"].ToInt(),
                        PrivilegeAccess = item["PrivilegeAccess"].ToStr(),
                        PrivilegeAccessKey = 0,
                        PrivilegeOperation = item["PrivilegeOperation"].ToStr()
                    }); 
                }
                DB.CommitTransaction();
                DB.CloseTransaction();
                return AjaxResult.Success();
            }
            catch (Exception err)
            {
                DB.RollbackTransaction();
                DB.CloseTransaction();
                return AjaxResult.Error(err.Message);
            }
        }

        #endregion

        //Johnson Start
        #region 区域

        public static AjaxResult AddDistrict(RentDistrict entity)
        {
            return DB.InsertEntity<RentDistrict>(entity);
        }
        public static AjaxResult UpdateDistrict(RentDistrict entity)
        {
            return DB.UpdateEntity<RentDistrict>(entity);
        }
        public static AjaxResult RemoveDistrict(string LDID)
        {
            return DB.DeleteEntity<RentDistrict>(LDID);
        }
        #endregion

        #region 街道

        public static AjaxResult AddStreet(RentStreet entity)
        {
            return DB.InsertEntity<RentStreet>(entity);
        }
        public static AjaxResult UpdateStreet(RentStreet entity)
        {
            return DB.UpdateEntity<RentStreet>(entity);
        }
        public static AjaxResult RemoveStreet(string LSID)
        {
            return DB.DeleteEntity<RentStreet>(LSID);
        }
        #endregion

        #region 社区

        public static AjaxResult AddRoad(RentRoad entity)
        {
            return DB.InsertEntity<RentRoad>(entity);
        }
        public static AjaxResult UpdateRoad(RentRoad entity)
        {
            return DB.UpdateEntity<RentRoad>(entity);
        }
        public static AjaxResult RemoveRoad(string LRID)
        {
            return DB.DeleteEntity<RentRoad>(LRID);
        }
        #endregion

        #region 警局信息

        public static AjaxResult AddPoliceStation(RentPoliceStation entity)
        {
            return DB.InsertEntity<RentPoliceStation>(entity);
        }
        public static AjaxResult UpdatePoliceStation(RentPoliceStation entity)
        {
            return DB.UpdateEntity<RentPoliceStation>(entity);
        }
        public static AjaxResult RemovePoliceStation(string PSID)
        {
            return DB.DeleteEntity<RentPoliceStation>(PSID);
        }
        #endregion

        #region Rent基础数据
        public static AjaxResult AddRentSystemOption(RentSystemOption entity)
        {
            entity.RSOUrl = "0";
            entity.RSONo = "0";
            return DB.InsertEntity<RentSystemOption>(entity);
        }

        public static AjaxResult UpdateRentSystemOption(RentSystemOption entity)
        {
            entity.RSOUrl = "0";
            entity.RSONo = "0";
            return DB.UpdateEntity<RentSystemOption>(entity);
        }
        public static AjaxResult RemoveRentSystemOption(string RSOID)
        {
            return DB.DeleteEntity<RentSystemOption>(RSOID);
        }
        #endregion
    }
}