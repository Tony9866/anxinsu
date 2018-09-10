using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using LigerRM.Common;
using SignetInternet_BusinessLayer;
using System.Data;
using System.Collections;

namespace LigerRM.WebService
{

    //所有接口辨别需要编号，才能赋予接口权限
    //创建家庭锁               CreateHomeLock             1
    //获取家庭数据返回信息     GetHomeLockReturnInfo      2
    //绑定网关                 AddGateway                 3 
    //获取pin码                GetPinInfo                 4
    //删除网关,锁              DeleteGatewayLock          5
    //获取当前用户新锁         GetUserNewLockList         6
    //获取家庭信息             GetNewFamilyInfo           7
    //修改家庭信息             UpdateNewFamilyInfo        8
    //开锁接口                 NewOpenDoor                9
    //添加密码和IC卡,新锁      NewAddPasswordICcard       10
    //删除密码和IC卡,新锁      NewDelPasswordICcard       11
    //查询密码和卡片           NewSelPasswordICcard       12
    //数据绑定接口             DataBindInfo               13

    /// <summary>
    /// LockManageServices 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class LockManageServices : System.Web.Services.WebService
    {
        public Authentication authentication = new Authentication();
        public ServiceCredential myCredential;

        /// <summary>
        /// 创建家庭锁
        /// </summary>
        /// <param name="address">家庭锁详细地址</param>
        /// <param name="familyName">家庭名称</param>
        /// <param name="userId">用户ID</param>
        /// <param name="city">家庭锁所属区域</param>
        /// <param name="ownerName">房主姓名</param>
        /// <param name="ownerMobile">房主手机号</param>
        /// <param name="ownerId">房主身份证号</param>
        /// <param name="ownerAddress">房屋所在地址</param>
        /// <param name="homeStatus">房屋状态  1  住房   2  租房</param>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string CreateHomeLock(string address, string familyName, string userId, string city, string ownerName, string ownerMobile, string ownerId, string ownerAddress, string homeStatus)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                NewLockManager manager = new NewLockManager();
                //传值校验
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("address", address);
                dic.Add("familyName", familyName);
                dic.Add("userId", userId);
                dic.Add("city", city);
                dic.Add("ownerName", ownerName);
                dic.Add("ownerMobile", ownerMobile);
                dic.Add("ownerId", ownerId);
                dic.Add("ownerAddress", ownerAddress);
                dic.Add("homeStatus", homeStatus);
                string returnFiled = manager.checkIsNullFild(dic);
                if (returnFiled != string.Empty)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                    return JSONHelper.ToJson(ret);
                }
                if (manager.GetIsEnterprise(userId) == "2")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
                //判断接口是否授权
                if (!manager.GetIsInterfacePermissions("1", userId))
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
                if (!manager.checkidcard(ownerId)) //身份证格式校验
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "房主身份证号（ownerId）格式校验错误！");
                    return JSONHelper.ToJson(ret);
                }
                if (!manager.IsTelephone(ownerMobile)) //手机号格式校验
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "房主手机号格式（ownerMobile）校验错误！");
                    return JSONHelper.ToJson(ret);
                }
                if (homeStatus != "1" && homeStatus != "2")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "homeStatus参数值超出允许范围！");
                    return JSONHelper.ToJson(ret);
                }
                LogManager.WriteLog("Start......");
                string deviceID = Guid.NewGuid().ToString("N");
                string sql = string.Empty;
                //请求远程创建家庭接口
                string familyReturn = manager.createHomeInfo(deviceID);
                LogManager.WriteLog("Start......" + familyReturn);
                Dictionary<string, object> returnInfo = new Dictionary<string, object>();
                returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(familyReturn);
                if (returnInfo["ret"].ToString() == "0")
                {
                    string dateTime = DateTime.Now.ToString();
                    //信息记录
                    sql = "insert into Rent_NewLock_Process output inserted.NewLockId values('" + Guid.NewGuid().ToString() + "', '" + userId + "', '" + deviceID + "', '" + address + "', '','','true','','','','','" + dateTime + "','','" + familyName + "', '" + city + "')";
                    LogManager.WriteLog("SQL:" + sql);
                    DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    sql = "select * from Rent_NewLock_Process where NewLockID='" + dt.Rows[0]["NewLockID"].ToString() + "'";
                    LogManager.WriteLog("SQL:" + sql);
                    //锁房屋绑定
                    DataTable dtInfo = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    sql = "insert into Rent_Locks values('" + dtInfo.Rows[0]["DeviceID"].ToString() + "', 1, '0', 'NoConfiguration', '0', '" + dateTime + "', '0', '0', '" + dt.Rows[0]["NewLockID"].ToString() + "')";
                    LogManager.WriteLog("SQL:" + sql);
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    //家庭信息创建
                    sql = "insert into Enterprise_Homeowner_Info values('" + Guid.NewGuid().ToString() + "', '" + ownerName + "', '" + ownerMobile + "',  '" + ownerId + "', '" + ownerAddress + "', '" + homeStatus + "', '" + userId + "', '" + dt.Rows[0]["NewLockID"].ToString() + "', '" + dateTime + "', '', '', '')";
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
        /// 获取家庭数据返回信息
        /// </summary>
        /// <param name="devId">新锁编号ID</param>
        /// <param name="type"> 1 网关返回数据  2  智能锁返回数据   3   pin码返回数据   4  删除网关      5   删除锁</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetHomeLockReturnInfo(string newLockId, int type, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                NewLockManager managerNew = new NewLockManager();
                //传值校验
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("newLockId", newLockId);
                dic.Add("type", type.ToString());
                string returnFiled = managerNew.checkIsNullFild(dic);
                if (returnFiled != string.Empty)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                    return JSONHelper.ToJson(ret);
                }
                //判断是否授权
                if (managerNew.GetIsEnterprise(userId) == "2")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
                //判断接口是否授权
                if (!managerNew.GetIsInterfacePermissions("2", userId))
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
                string sql = "select * from Rent_NewLock_Process where NewLockID='" + newLockId + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "未获取该家庭锁信息！");
                    return JSONHelper.ToJson(ret);
                }
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
                else
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "type参数值超出允许范围！");
                    return JSONHelper.ToJson(ret);
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
        public string AddGateway(string gatewayId, string devKey, string newLockID, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                NewLockManager managerNew = new NewLockManager();
                //传值校验
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("gatewayId", gatewayId);
                dic.Add("devKey", devKey);
                dic.Add("newLockID", newLockID);
                string returnFiled = managerNew.checkIsNullFild(dic);
                if (returnFiled != string.Empty)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                    return JSONHelper.ToJson(ret);
                }
                //判断是否授权
                if (managerNew.GetIsEnterprise(userId) == "2")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
                //判断接口是否授权
                if (!managerNew.GetIsInterfacePermissions("3", userId))
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
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
        public string GetPinInfo(string newLockId, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                NewLockManager managerNew = new NewLockManager();
                //传值校验
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("newLockId", newLockId);
                string returnFiled = managerNew.checkIsNullFild(dic);
                if (returnFiled != string.Empty)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                    return JSONHelper.ToJson(ret);
                }
                //判断是否授权
                if (managerNew.GetIsEnterprise(userId) == "2")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
                //判断接口是否授权
                if (!managerNew.GetIsInterfacePermissions("4", userId))
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
                //判断是否已经获取网关地址
                string sql = "select * from Rent_NewLock_Process where NewLockID='" + newLockId + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "未获取该家庭锁信息！");
                    return JSONHelper.ToJson(ret);
                }
                if (dt.Rows[0]["GatewayId"].ToString() == "" || dt.Rows[0]["DevKey"].ToString() == "" || dt.Rows[0]["IsCreateGateway"].ToString() == "")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "请先配置好网关，在获取PIN码");
                    return JSONHelper.ToJson(ret);
                }
                //添加pin码
                string addLockInfo = managerNew.createAddLock(dt.Rows[0]["GatewayId"].ToString(), newLockId);
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
        public string DeleteGatewayLock(string newLockID, int type, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string LockInfo = string.Empty;
                NewLockManager managerNew = new NewLockManager();
                //传值校验
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("newLockID", newLockID);
                dic.Add("type", type.ToString());
                string returnFiled = managerNew.checkIsNullFild(dic);
                if (returnFiled != string.Empty)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                    return JSONHelper.ToJson(ret);
                }
                //判断是否授权
                if (managerNew.GetIsEnterprise(userId) == "2")
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
                //判断接口是否授权
                if (!managerNew.GetIsInterfacePermissions("5", userId))
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                    return JSONHelper.ToJson(ret);
                }
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
                else
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "type参数值超出允许范围！");
                    return JSONHelper.ToJson(ret);
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
                        delSql = "delete from Enterprise_Homeowner_Info where NewLockID='" + newLockID + "'";
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
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            NewLockManager manager = new NewLockManager();
            //传值校验
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("userId", userId);
            string returnFiled = manager.checkIsNullFild(dic);
            if (returnFiled != string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                return JSONHelper.ToJson(ret);
            }
            //判断是否授权
            if (manager.GetIsEnterprise(userId) == "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
            }
            else if (!manager.GetIsInterfacePermissions("6", userId)) //判断接口是否授权
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            else
            {
                RentInfoHelper helper = new RentInfoHelper();
                ret.Add("ret", "0");
                ret.Add("msg", helper.GetJSONInfo("select * from v_EnterpriseHomeLock_view where UserId='" + userId + "'"));
            }
            return JSONHelper.ToJson(ret);

        }

        /// <summary>
        /// 获取家庭信息
        /// </summary>
        /// <param name="newLockID">家庭编号</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string GetNewFamilyInfo(string newLockId, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();
            NewLockManager manager = new NewLockManager();
            //传值校验
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("newLockId", newLockId);
            string returnFiled = manager.checkIsNullFild(dic);
            if (returnFiled != string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                return JSONHelper.ToJson(ret);
            }
            //判断是否授权
            if (manager.GetIsEnterprise(userId) == "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            //判断接口是否授权
            if (!manager.GetIsInterfacePermissions("7", userId))
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            RentInfoHelper helper = new RentInfoHelper();
            ret.Add("ret", "0");
            ret.Add("msg", helper.GetJSONInfo("select * from v_EnterpriseHomeLock_view where NewLockID='" + newLockId + "'"));
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        ///修改家庭信息
        /// </summary>
        /// <param name="newLockID">家庭编号</param>
        /// <param name="Address">家庭锁地址</param>
        /// <param name="FamilyName">家庭锁名称</param>
        /// <param name="City">区域</param>
        /// <param name="ownerName">房主姓名</param>
        /// <param name="ownerMobile">房主手机号</param>
        /// <param name="ownerId">房主身份证号</param>
        /// <param name="ownerAddress">房屋所在地址</param>
        /// <param name="homeStatus">房屋状态  1  住房   2  租房</param> 
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string UpdateNewFamilyInfo(string newLockId, string address, string familyName, string city, string ownerName, string ownerMobile, string ownerId, string ownerAddress, string homeStatus, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            NewLockManager managerNew = new NewLockManager();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            if (string.Empty == newLockId)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "字段newLockId不允许为空！");
                return JSONHelper.ToJson(ret);
            }
            //判断是否授权
            if (managerNew.GetIsEnterprise(userId) == "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            //判断接口是否授权
            if (!managerNew.GetIsInterfacePermissions("8", userId))
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            try
            {
                //字符串拼接
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("Address", address);
                dic.Add("FamilyName", familyName);
                dic.Add("City", city);
                dic.Add("EnterpriseHomeownerName", ownerName);
                dic.Add("EnterpriseHomeownerMobile", ownerMobile);
                dic.Add("EnterpriseHomeownerId", ownerId);
                dic.Add("EnterpriseHomeownerAddress", ownerAddress);
                dic.Add("EnterpriseHomeStatus", homeStatus);
                string sqlDate = string.Empty;
                string sqlDateE = string.Empty;
                string[] strArr = { "Address", "FamilyName", "City" };
                foreach (KeyValuePair<string, string> array in dic)
                {
                    if (array.Value != string.Empty)
                    {
                        if (((IList)strArr).Contains(array.Key))
                        {
                            sqlDate += array.Key + "='" + array.Value + "',";
                        }
                        else
                        {
                            if (array.Key == "EnterpriseHomeownerMobile" && !managerNew.IsTelephone(array.Value)) //手机号校验
                            {
                                ret.Add("ret", "1");
                                ret.Add("msg", "房主手机号格式（ownerMobile）校验错误！");
                                return JSONHelper.ToJson(ret);
                            }
                            if (array.Key == "EnterpriseHomeownerId" && !managerNew.checkidcard(array.Value)) //身份证校验
                            {
                                ret.Add("ret", "1");
                                ret.Add("msg", "房主身份证号（ownerId）格式校验错误！");
                                return JSONHelper.ToJson(ret);
                            }
                            if (array.Key == "EnterpriseHomeStatus" && array.Value != "1" && array.Value != "2") //房租类型校验
                            {
                                ret.Add("ret", "1");
                                ret.Add("msg", "homeStatus参数值超出允许范围！");
                                return JSONHelper.ToJson(ret);
                            }
                            sqlDateE += array.Key + "='" + array.Value + "',";
                        }
                    }
                }
                if (sqlDate != string.Empty)
                {
                    sqlDate = sqlDate.Substring(0, sqlDate.Length - 1);
                    string sql = "update Rent_NewLock_Process set " + sqlDate + " where NewLockID='" + newLockId + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
                if (sqlDateE != string.Empty)
                {
                    sqlDateE = sqlDateE.Substring(0, sqlDateE.Length - 1);
                    string sql = "update Enterprise_Homeowner_Info set " + sqlDateE + " where NewLockID='" + newLockId + "'";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
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
        /// <param name="userId">授权ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string NewOpenDoor(string newLockId, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            NewLockManager managerNew = new NewLockManager();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            //传值校验
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("newLockId", newLockId);
            dic.Add("UserId", userId);
            string returnFiled = managerNew.checkIsNullFild(dic);
            if (returnFiled != string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                return JSONHelper.ToJson(ret);
            }
            //判断是否授权
            if (managerNew.GetIsEnterprise(userId) == "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            //判断接口是否授权
            if (!managerNew.GetIsInterfacePermissions("9", userId))
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            string lockId = managerNew.getDeviceID(newLockId, "DeviceID");
            if (lockId == string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "未获取该家庭锁信息！");
                return JSONHelper.ToJson(ret);
            }
            //开锁
            string open = managerNew.openDoorSDK(lockId, userId);
            Dictionary<string, object> returnInfo = new Dictionary<string, object>();
            returnInfo = JSONHelper.FromJson<Dictionary<string, object>>(open);
            if (returnInfo["ret"].ToString() == "0")
            {
                ret.Add("ret", "0");
            }
            else
            {
                ret.Add("ret", "1");
            }
            ret.Add("msg", returnInfo["msg"].ToString());
            return JSONHelper.ToJson(ret);
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
        public string NewAddPasswordICcard(string newLockId, string type, string pwdAndCard, string startTime, string endTime, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            NewLockManager managerNew = new NewLockManager();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            //传值校验
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("newLockId", newLockId);
            dic.Add("type", type);
            if (type == "1" || type == "2")
            {
                if (pwdAndCard == string.Empty)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "永久录入字段pwdAndCard不允许为空！");
                    return JSONHelper.ToJson(ret);
                }
                else
                {
                    dic.Add("pwdAndCard", pwdAndCard);
                }
            }
            dic.Add("startTime", startTime);
            dic.Add("endTime", endTime);
            string returnFiled = managerNew.checkIsNullFild(dic);
            if (returnFiled != string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                return JSONHelper.ToJson(ret);
            }
            //是否给公司授权
            if (managerNew.GetIsEnterprise(userId) == "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            //判断接口是否授权
            if (!managerNew.GetIsInterfacePermissions("10", userId))
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            string[] strArr = { "1", "2", "3", "4" };
            bool exists = ((IList)strArr).Contains(type);
            if (!exists)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "type参数值超出允许范围！");
                return JSONHelper.ToJson(ret);
            }
            string deviceId = managerNew.getDeviceID(newLockId, "DeviceID");
            string UserId = managerNew.getDeviceID(newLockId, "UserId");
            if (deviceId == string.Empty || userId == string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "未获取该家庭锁信息！");
                return JSONHelper.ToJson(ret);
            }
            return managerNew.GetPostInterface(deviceId, UserId, type, pwdAndCard, startTime, endTime);
        }

        /// <summary>
        /// 删除密码和IC卡   新锁
        /// </summary>
        /// <param name="type">类型  1 删除密码   2 删除卡片</param>
        /// <param name="id">id</param>
        /// <param name="userId">授权企业ID</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string NewDelPasswordICcard(string id, string type, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            string returnInfo = string.Empty;
            NewLockManager managerNew = new NewLockManager();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            //传值校验
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            dic.Add("type", type);
            dic.Add("userId", userId);
            string returnFiled = managerNew.checkIsNullFild(dic);
            if (returnFiled != string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                return JSONHelper.ToJson(ret);
            }
            if (managerNew.GetIsEnterprise(userId) == "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            //判断接口是否授权
            if (!managerNew.GetIsInterfacePermissions("11", userId))
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            if (type != "1" && type != "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "type参数值超出允许范围！");
                return JSONHelper.ToJson(ret);
            }
            string sql = string.Empty;
            //校验删除的密码和卡片是否属于该企业
            if (type == "1")
            {
                sql = "select * from v_RentPass_view where Status='0' and UserId='" + userId + "'and IsAdd is not null and len(IsAdd)>0 and ID='" + id + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    returnInfo = managerNew.DeletePassword(id);
                }
                else
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "未查到该密码，无法删除！");
                    return JSONHelper.ToJson(ret);
                }
            }
            else if (type == "2")
            {
                sql = "select ID from v_RentICCard_view where Status='0' and UserId='" + userId + "'and ICCard is not null and len(ICCard)>0 and ID='" + id + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    returnInfo = managerNew.DeleteICCard(id);
                }
                else
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "未查到该卡片，无法删除！");
                    return JSONHelper.ToJson(ret);
                }
            }
            return returnInfo;
        }

        /// <summary>
        /// 查询密码和IC卡
        /// </summary>
        /// <param name="newLockID">新锁id</param>
        /// <param name="type">2  密码列表   1 卡片列表</param>
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string NewSelPasswordICcard(string newLockId, int type, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            NewLockManager managerNew = new NewLockManager();
            Dictionary<string, string> ret = new Dictionary<string, string>();
            //传值校验
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("newLockId", newLockId);
            dic.Add("type", type.ToString());
            string returnFiled = managerNew.checkIsNullFild(dic);
            if (returnFiled != string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                return JSONHelper.ToJson(ret);
            }
            //判断是否授权
            if (managerNew.GetIsEnterprise(userId) == "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            //判断接口是否授权
            if (!managerNew.GetIsInterfacePermissions("12", userId))
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            if (type != 1 && type != 2)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "type参数值超出允许范围！");
                return JSONHelper.ToJson(ret);
            }
            string lockId = managerNew.getDeviceID(newLockId, "DeviceID");
            string UserId = managerNew.getDeviceID(newLockId, "UserId");
            if (lockId == string.Empty || userId == string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "未获取该家庭锁信息！");
                return JSONHelper.ToJson(ret);
            }
            RentInfoHelper helper = new RentInfoHelper();
            if (type == 1)
            {
                ret.Add("ret", "0");
                ret.Add("msg", helper.GetJSONInfo("select ID,LockID,ICCard,StartDate,EndDate,IsValid,UserId from v_RentICCard_view where LockID='" + lockId + " and Status='0' and UserId='" + UserId + "'and ICCard is not null and len(ICCard)>0"));
                return JSONHelper.ToJson(ret);
            }
            else
            {
                ret.Add("ret", "0");
                ret.Add("msg", helper.GetJSONInfo("select ID,LockID,Password,StartDate,EndDate,IsValid,UserId from v_RentPass_view where LockID='" + lockId + "' and Status='0' and UserId='" + UserId + "'and IsAdd is not null and len(IsAdd)>0"));
                return JSONHelper.ToJson(ret);
            }

        }

        /// <summary>
        /// 数据绑定接口
        /// </summary>
        /// <param name="gatewayJson">网关json信息</param>
        /// 
        /// <returns></returns>
        [WebMethod]
        [SoapHeader("authentication")]
        public string DataBindInfo(string gatewayJson, string userId)
        {
            if (!authentication.ValideLockUser())
            {
                return "{'headerError'}";
            }
            NewLockManager managerNew = new NewLockManager();
            string sql = string.Empty;
            Dictionary<string, string> ret = new Dictionary<string, string>();
            //传值校验
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("gatewayJson", gatewayJson);
            dic.Add("userId", userId);
            string returnFiled = managerNew.checkIsNullFild(dic);
            if (returnFiled != string.Empty)
            {
                ret.Add("ret", "1");
                ret.Add("msg", "字段" + returnFiled + "不允许为空！");
                return JSONHelper.ToJson(ret);
            }
            //判断是否授权
            if (managerNew.GetIsEnterprise(userId) == "2")
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            //判断接口是否授权
            if (!managerNew.GetIsInterfacePermissions("13", userId))
            {
                ret.Add("ret", "1");
                ret.Add("msg", "我公司暂无给贵公司授权该接口,请核对再操做！");
                return JSONHelper.ToJson(ret);
            }
            Dictionary<string, object> retRequest = new Dictionary<string, object>();
            retRequest = JSONHelper.FromJson<Dictionary<string, object>>(gatewayJson);
            try
            {
                //查询锁信息
                sql = "select * from Rent_NewLock_Process where GatewayId= '" + retRequest["D-id"].ToString() + "' and DevKey='" + retRequest["D-key"].ToString() + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "未获取该家庭锁信息！");
                }
                else
                {
                    //查询用户表信息（通过我们app添加）
                    sql = "select * from CF_User where LoginName='" + dt.Rows[0]["UserId"].ToString() + "'";
                    DataTable dtUser = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    //查询SDK添加
                    sql = "select * from Enterprise_Homeowner_Info where NewLockID='" + dt.Rows[0]["NewLockID"].ToString() + "'";
                    DataTable dtSDK = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                    if (dtUser.Rows.Count <= 0 && dtSDK.Rows.Count <= 0)
                    {
                        ret.Add("ret", "1");
                        ret.Add("msg", "获取用户信息失败！");
                    }
                    else
                    {
                        var item = new Hashtable();
                        if (dtUser.Rows.Count > 0)
                        {
                            item["userName"] = dtUser.Rows[0]["RealName"].ToString();
                            item["userMoblie"] = dtUser.Rows[0]["LoginName"].ToString();
                        }
                        else
                        {
                            item["userName"] = dtSDK.Rows[0]["EnterpriseHomeownerName"].ToString();
                            item["userMoblie"] = dtSDK.Rows[0]["EnterpriseHomeownerMobile"].ToString();
                        }
                        item["NewLockId"] = dt.Rows[0]["NewLockID"].ToString();
                        ret.Add("ret", "0");
                        ret.Add("msg", JSONHelper.ToJson(item));
                    }
                }
            }
            catch (Exception ex)
            {
                ret.Add("ret", "1");
                ret.Add("msg", ex.Message);
            }
            return JSONHelper.ToJson(ret);
        }
    }
}
