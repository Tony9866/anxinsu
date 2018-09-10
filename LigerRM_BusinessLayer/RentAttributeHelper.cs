using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using LigerRM.Common;


namespace SignetInternet_BusinessLayer
{
    public class RentAttributeHelper
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;
        //5  退订   0   产生订单   9  拒绝订单   8   租户取消订单    1   订单过期     2  房主确认订单   7  确认退房   6 申请退房   11  添加评价 
        public  enum AttributeStatus { Submitted=0,NeedPay=1,Complete=2,Rejected=9,Cancelled=8,Expired=7,NeedConfirmCheckOut=6,CheckedOut=5,Evaluated=11}
        public enum PayType { WeChart=0,Wallet=1}

        public string AddRentAttribute(RentAttribute rentAttribute)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();

            //strSql1.Append(" Update Rent_Rent set IsAvailable=1");
            //strSql1.Append(" where RentNo = '" + rentAttribute.RentNo + "'");

            //Update
            strSql.Append("INSERT INTO Rent_RentAttribute ([RentNo],[RRAContactName],[RRAContactTel],[RRANationName],[RRAIDCard]," +
                "[RRentPrice],[RRAContactProvince],[RRAStartDate],[RRAEndDate],[RRARealEndDate],[RRACheckOutPerson],[RRACheckOutReason],[RRADescription],[RRACreatedBy]," +
                "[RRACreatedDate],[RRAModifiedBy],[RRAModifiedDate],[RRAIsActive],[RRAStatus],[AppId],[Body],[MchId],[TradeNO],[TotalFee],[PrepayID]) values (");
            strSql.Append(" '" + rentAttribute.RentNo + "',");
            strSql.Append(" '" + rentAttribute.RRAContactName + "',");
            strSql.Append(" '" + rentAttribute.RRAContactTel + "',");
            strSql.Append(" '" + rentAttribute.RRANationName + "',");
            strSql.Append(" '" + rentAttribute.RRAIDCard + "',");
            strSql.Append(" '" + rentAttribute.RRentPrice + "', ");
            strSql.Append(" '" + rentAttribute.RRAContactProvince + "' ,");
            strSql.Append(" '" + rentAttribute.RRAStartDate + "','" + rentAttribute.RRAEndDate + "',null,'','',");
            strSql.Append(" '" + rentAttribute.RRADescription + "',");
            strSql.Append(" '" + rentAttribute.RRACreatedBy + "',");
            strSql.Append(" '" + rentAttribute.RRACreatedDate.ToString("yyyy-MM-dd HH:mm:ss") + "', ");
            strSql.Append("'" + rentAttribute.RRACreatedBy + "','" + rentAttribute.RRACreatedDate.ToString("yyyy-MM-dd HH:mm:ss") + "', 0 ,'" + rentAttribute.Status + "','','','','',0,''");
            strSql.Append(" )");
            strSql.Append(" select @@identity");


            List<SqlCommand> listSQL = new List<SqlCommand>();
            listSQL.Add(MySQLHelper.CreateCommand(strSql.ToString()));

            DataSet ds = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(strSql.ToString()));


            string sql = "select top 1 * from Rent_RentAttribute where RentNo = '" + rentAttribute.RentNo + "' order by RRAID desc";
            DataTable dt2 = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

            SMS.CommonServices service = new SMS.CommonServices();
            string approveMsg = ConfigurationManager.AppSettings["ApproveMessage"].ToString();
            RentInfo info = new RentInfo(rentAttribute.RentNo);
            service.SendMsg(info.ROwnerTel, approveMsg);

            CFUserInfo userInfo = new CFUserInfo(info.RIDCard, false);
            LockManager manager = new LockManager();
            manager.SendMessageToDevice(userInfo.DeviceID, approveMsg, dt2.Rows[0]["RRAID"].ToString(), userInfo.IDCard);

            SysLogHelper.AddLog(rentAttribute.RRACreatedBy, "增加租赁信息ID：" + rentAttribute.RentNo, "增加-租赁信息");

            return dt2.Rows[0]["RRAID"].ToString();
        }

        public void UpdateRentAttribute(RentAttribute rentAttribute)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Update Rent_RentAttribute set ");
            strSql.Append(" RRAContactName='" + rentAttribute.RRAContactName + "',");
            strSql.Append(" RRAContactTel='" + rentAttribute.RRAContactTel + "',RRANationName='" + rentAttribute.RRANationName + "',");
            strSql.Append(" RRAIDCard = '" + rentAttribute.RRAIDCard + "', RRentPrice = '" + rentAttribute.RRentPrice + "',");
            strSql.Append(" RRAContactProvince='" + rentAttribute.RRAContactProvince + "',");
            strSql.Append(" RRAStartDate='" + rentAttribute.RRAStartDate + "',RRAEndDate='" + rentAttribute.RRAEndDate + "',");
            strSql.Append(" RRADescription='" + rentAttribute.RRADescription + "',");
            strSql.Append(" RRAModifiedBy='" + rentAttribute.RRAModifiedBy + "',");
            strSql.Append(" RRAModifiedDate='" + rentAttribute.RRAModifiedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            strSql.Append(" where RRAID = '" + rentAttribute.RRAID + "'");
            SysLogHelper.AddLog(rentAttribute.RRAModifiedBy, "修改租赁信息ID：" + rentAttribute.RentNo, "修改-租赁信息");

            List<SqlCommand> listSQL = new List<SqlCommand>();
            listSQL.Add(MySQLHelper.CreateCommand(strSql.ToString()));
            //listSQL.Add(MySQLHelper.CreateCommand(strSql1.ToString()));

            MySQLHelper.ExecuteNonQueryTrans(SqlConnString, listSQL);
        }

        public void UpdateOrderInfo(string id,string appId,string body,string mchId,string tradeNo,string fee,string prepayId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Update Rent_RentAttribute set ");
            strSql.Append(" AppId='" + appId + "',");
            strSql.Append(" Body='" + body + "',");
            strSql.Append(" MchId='" + mchId + "',");
            strSql.Append(" TradeNO='" + tradeNo + "',");
            strSql.Append(" TotalFee=" + fee + ",");
            strSql.Append(" PrepayID='" + prepayId + "'");
            strSql.Append(" where RRAID = " + id );
            SysLogHelper.AddLog("0", "更新租赁订单信息ID：" + id, "修改-租赁信息");

            List<SqlCommand> listSQL = new List<SqlCommand>();
            listSQL.Add(MySQLHelper.CreateCommand(strSql.ToString()));
            //listSQL.Add(MySQLHelper.CreateCommand(strSql1.ToString()));

            MySQLHelper.ExecuteNonQueryTrans(SqlConnString, listSQL);
        }

        public DataTable GetRentAttribute(string id)
        {
            string sql = "select * from  Rent_RentAttribute where RRAIsActive=0 and RRAID=" + id;
            DataSet ds = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            return ds.Tables[0];
        }

        public void UpdateStatus(string id,string status)
        {
            string sql = "update Rent_RentAttribute set RRAStatus='" + status + "' where RRAID="+id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

            RentAttribute a = new RentAttribute(id);

            sql = "select * from  Rent_RentAttribute where RRAID=" + id;
            DataSet ds = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            if (ds.Tables[0].Rows.Count > 0)
            {
                sql = "Update Rent_Rent set IsAvailable=1,RentNumber=1 where RentNo = '" + ds.Tables[0].Rows[0]["RentNo"].ToString() + "'";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            }
        }

        public void UpdateEvaluatedStatus(string id, string status)
        {
            string sql = "update Rent_RentAttribute set RRAStatus='" + status + "' where RRAID=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        public void ConfirmRentAttribute(string id, string fee, string RRAContactProvince)
        {
            //UpdateStatus(id, ((int)RentAttributeHelper.AttributeStatus.NeedPay).ToString());
            string sql1 = "update Rent_RentAttribute set rrastatus='" + ((int)RentAttributeHelper.AttributeStatus.NeedPay).ToString() + "',rrentprice='" + fee + "', RRAContactProvince='" + RRAContactProvince + "' where rraid=" + id;
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql1));
            string sql = "select * from Rent_RentAttribute where rraid=" + id;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                SMS.CommonServices service = new SMS.CommonServices();
                string approveMsg = ConfigurationManager.AppSettings["NeedPayMessage"].ToString();
                service.SendMsg(dt.Rows[0]["RRAContactTel"].ToString(), approveMsg);

                CFUserInfo userInfo = new CFUserInfo(dt.Rows[0]["RRAIDCard"].ToString(), false);
                LockManager manager = new LockManager();
                manager.SendMessageToDevice(userInfo.DeviceID, approveMsg, id, userInfo.IDCard);
            }
        }


        public void DeleteRentAttribute(RentAttribute rentAttribute)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            
            strSql1.Append(" Update Rent_Rent set IsAvailable=0");
            strSql1.Append(" where RentNo = '" + rentAttribute.RentNo + "'");
           
            //Update
            strSql.Append(" Update Rent_RentAttribute set RRAIsActive=1, RRAStatus='5', ");
            strSql.Append(" RRAModifiedBy='" + rentAttribute.RRAModifiedBy + "',");
            strSql.Append(" RRAModifiedDate='" + rentAttribute.RRAModifiedDate.Value.ToString("yyyy-MM-dd hh:mm:ss") + "'");
            strSql.Append(" where RRAID = '" + rentAttribute.RRAID + "'");
            SysLogHelper.AddLog(rentAttribute.RRAModifiedBy, "删除租赁信息ID：" + rentAttribute.RentNo, "删除-租赁信息");

            List<SqlCommand> listSQL = new List<SqlCommand>();
            listSQL.Add(MySQLHelper.CreateCommand(strSql.ToString()));
            listSQL.Add(MySQLHelper.CreateCommand(strSql1.ToString()));

            MySQLHelper.ExecuteNonQueryTrans(SqlConnString, listSQL);

            //清除密码和IC卡信息
            ClearPasswordToLock(rentAttribute.RRAID.ToString());
        }

        public string CreateVerifyCode(int maxInt)
        {
            string tempStr = string.Empty;
            Random ran = new Random();
            for (int i = 0; i < maxInt; i++)
            {
                tempStr += ran.Next(maxInt).ToString();
            }
            return tempStr;
        }

        public string CreateUserCode(int maxInt)
        {
            string tempStr = string.Empty;
            Random ran = new Random();
            return ran.Next(100000, 999999).ToString();
        }

        /// <summary>
        /// 更新钱包钱数
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="fee"></param>
        /// <param name="type">0:增加钱包钱数，1：减少钱包钱数</param>
        public string UpdateUserWallet(string idcard, string fee, string type)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                
                
                string sql = "select * from v_CF_User_View where IDCard='" + idcard + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                string userId = dt.Rows[0]["UserID"].ToString();
                sql = "select * from CF_User_Extenal where UserID=" + dt.Rows[0]["UserID"].ToString();
                dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
                string feeRate = ConfigurationManager.AppSettings["FeeRate"];

                if (type.Equals("0"))
                {
                    if (dt.Rows.Count > 0)
                    {
                        decimal wallet = decimal.Parse(dt.Rows[0]["Wallet"].ToString()) + decimal.Parse(fee) * (1 - decimal.Parse(feeRate));
                        sql = "update CF_User_Extenal set wallet = " + wallet.ToString() + " where ExternalID=" + dt.Rows[0]["ExternalID"].ToString();
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                    else
                    {
                        decimal wallet = decimal.Parse(fee) * (1 - decimal.Parse(feeRate));
                        sql = "Insert into CF_User_Extenal values (" + userId + "," + wallet.ToString() + ",0,'','','')";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        decimal wallet = decimal.Parse(dt.Rows[0]["Wallet"].ToString()) - decimal.Parse(fee);
                        sql = "update CF_User_Extenal set wallet = " + wallet.ToString() + " where ExternalID=" + dt.Rows[0]["ExternalID"].ToString();
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                    }
                    else
                    {
                        decimal wallet = -decimal.Parse(fee);
                        sql = "Insert into CF_User_Extenal values (" + userId + "," + wallet.ToString() + ",0,'','','')";
                        MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
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
        /// 是否可以用钱包支付
        /// </summary>
        /// <param name="idCard"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public string CanPayFromWallet(string idCard, string fee)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {

                string sql = "select * from v_CF_User_View where IDCard='" + idCard + "'";
                DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

                if (!dt.Rows[0].IsNull("Wallet") && decimal.Parse(dt.Rows[0]["Wallet"].ToString()) >= decimal.Parse(fee) * 2)
                {
                    ret.Add("ret", "0");
                    ret.Add("msg", "Success");
                }
                else
                {
                    ret.Add("ret", "1");
                    ret.Add("msg", "余额不足，账户中需有两倍以上要缴纳的费用，才可以使用钱包支付！");
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
        /// 钱包付款
        /// </summary>
        /// <param name="rennteeIDCard"></param>
        /// <param name="ownerIDCard"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public string PayUseWallet(string rennteeIDCard, string ownerIDCard, string fee)
        {
            string sql = "select * from v_CF_User_View where IDCard='" + rennteeIDCard + "' or IDCard='" + ownerIDCard + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string renteeUserId = string.Empty;
            string ownerUserId = string.Empty;
            bool add = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row["IDCard"].ToString() == rennteeIDCard)
                    renteeUserId = row["UserID"].ToString();

                if (row["IDCard"].ToString() == ownerIDCard)
                {
                    ownerUserId = row["UserID"].ToString();
                    if (row.IsNull("Wallet"))
                        add = true;
                }
                
            }
            Dictionary<string, string> ret = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(renteeUserId) && !string.IsNullOrEmpty(ownerUserId))
            {
                try
                {
                    sql = "update cf_user_extenal set wallet = wallet - " + fee + " where UserID=" + renteeUserId;
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

                    string rate = ConfigurationManager.AppSettings["FeeRate"];

                    if (!add)
                        sql = "update cf_user_extenal set wallet = wallet + " + (decimal.Parse(fee) * (1 - decimal.Parse(rate))).ToString() + " where UserID=" + ownerUserId;
                    else
                        sql = "Insert into cf_user_extenal values ('" + ownerUserId + "'," + (decimal.Parse(fee) * (1 - decimal.Parse(rate))).ToString() + ",0,'','','')";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));

                    sql = "select * from cf_user_extenal where UserID=" + ownerUserId;
                    DataTable dt3 = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];

                    //AddBillLog(rennteeIDCard, ownerIDCard, fee,((int)PayType.Wallet).ToString());
                    ret.Add("ret", "0");
                    ret.Add("fee", dt3.Rows[0]["wallet"].ToString());
                    ret.Add("msg", "Success");
                }
                catch (Exception ex)
                {
                    ret.Add("ret", "1");
                    ret.Add("fee", "");
                    ret.Add("msg", ex.Message);
                }
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("fee", "");
                ret.Add("msg", "身份信息不匹配");
            }

            return JSONHelper.ToJson(ret);
        }



        /// <summary>
        /// 添加消费记录
        /// </summary>
        /// <param name="rennteeIDCard"></param>
        /// <param name="ownerIDCard"></param>
        /// <param name="fee"></param>
        /// <param name="payType">0：微信，1：钱包</param>
        /// <returns></returns>
        public string AddBillLog(string rennteeIDCard, string ownerIDCard, string fee,string payType)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string rate = ConfigurationManager.AppSettings["FeeRate"];
                string sql = "Insert into sys_bill values ('" + Guid.NewGuid().ToString() + "','房费','" + rennteeIDCard + "','" + ownerIDCard + "','"+payType+"','0','" + DateTime.Now.ToString() + "','收入'," + fee + ")";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                decimal rateFee = 0;
                rateFee = decimal.Parse(fee) * decimal.Parse(rate);
                if (rateFee > 0)
                {
                    sql = "Insert into sys_bill values ('" + Guid.NewGuid().ToString() + "','平台手续费','" + ownerIDCard + "','云上之家服务平台','"+payType+"','1','" + DateTime.Now.ToString() + "','支出'," + rateFee.ToString() + ")";
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }

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

        public string AddDepositLog(string rennteeIDCard, string ownerIDCard, string fee, string payType)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string rate = ConfigurationManager.AppSettings["FeeRate"];
                string sql = "Insert into sys_bill values ('" + Guid.NewGuid().ToString() + "','充值','" + rennteeIDCard + "','" + ownerIDCard + "','" + payType + "','0','" + DateTime.Now.ToString() + "','收入'," + fee + ")";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
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
        /// 添加提现记录
        /// </summary>
        /// <param name="rennteeIDCard"></param>
        /// <param name="ownerIDCard"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public string AddBillLog1(string rennteeIDCard, string ownerIDCard, string fee)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
   
                string sql = "Insert into sys_bill values ('" + Guid.NewGuid().ToString() + "','提现','" + rennteeIDCard + "','" + ownerIDCard + "','0','0','" + DateTime.Now.ToString() + "','支出'," + fee + ")";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
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


        public string AddBillLog3(string rennteeIDCard, string ownerIDCard, string fee)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "Insert into sys_bill values ('" + Guid.NewGuid().ToString() + "','红包','" + rennteeIDCard + "','" + ownerIDCard + "','0','0','" + DateTime.Now.ToString() + "','收入'," + fee + ")";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
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
        /// 添加充值记录
        /// </summary>
        /// <param name="rennteeIDCard"></param>
        /// <param name="ownerIDCard"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public string AddBillLog2(string rennteeIDCard, string ownerIDCard, string fee)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                string sql = "Insert into sys_bill values ('" + Guid.NewGuid().ToString() + "','充值','" + rennteeIDCard + "','" + ownerIDCard + "','0','0','" + DateTime.Now.ToString() + "','收入'," + fee + ")";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
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
        /// 用户充值
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="fee"></param>
        public string DepositUserWallet(string idcard, string fee)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            string sql = "select * from v_CF_User_View where IDCard='" + idcard + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string userId = dt.Rows[0]["UserID"].ToString();
            sql = "select * from CF_User_Extenal where UserID=" + dt.Rows[0]["UserID"].ToString();
            dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string feeRate = ConfigurationManager.AppSettings["FeeRate"];
            if (dt.Rows.Count > 0)
            {
                decimal wallet = decimal.Parse(dt.Rows[0]["Wallet"].ToString()) + decimal.Parse(fee);
                sql = "update CF_User_Extenal set wallet = " + wallet.ToString() + " where ExternalID=" + dt.Rows[0]["ExternalID"].ToString();
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                ret.Add("fee", wallet.ToString());
            }
            else
            {
                decimal wallet = decimal.Parse(fee);
                sql = "Insert into CF_User_Extenal values (" + userId + "," + wallet.ToString() + ",0,'','','')";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                ret.Add("fee", wallet.ToString());
            }
            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 绑定银行卡
        /// </summary>
        /// <param name="idcard"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankName"></param>
        public void UpdateCreditCard(string idcard, string cardNo,string bankName)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            ret.Add("ret", "0");
            string sql = "select * from v_CF_User_View where IDCard='" + idcard + "'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string userId = dt.Rows[0]["UserID"].ToString();
            sql = "select * from CF_User_Extenal where UserID=" + dt.Rows[0]["UserID"].ToString();
            dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            string feeRate = ConfigurationManager.AppSettings["FeeRate"];
            if (dt.Rows.Count > 0)
            {
                sql = "update CF_User_Extenal set CardNO = '" + cardNo + "',BankName='"+bankName+"' where ExternalID=" + dt.Rows[0]["ExternalID"].ToString();
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            }
            else
            {
                sql = "Insert into CF_User_Extenal values (" + userId + ",0,0,'','"+cardNo+"','"+bankName+"')";
                MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
            }

        }

        public void UploadPersonInfo(RentAttribute info)
        {
            //type: 0-出租屋，1-印章系统
            RentInfo rent = new RentInfo(info.RentNo);

            string sql = "insert into T_Person_Info values ('"+Guid.NewGuid().ToString()+"','" + info.RRAID.ToString() + "','" + info.RRAContactName + "','" + info.RRAIDCard + "','0','" + DateTime.Now.ToString() + "','0','','RZF','" + rent.RAddress + "','" + rent.RPSName + "','" + rent.RPSName + "','0','','')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.DataSynConnectionString, MySQLHelper.CreateCommand(sql));
        }

        public void UploadPersonInfo(string id,string motorNo)
        {
            //type: 0-出租屋，1-印章系统,2-车辆
            string sql = "insert into T_Person_Info values ('" + Guid.NewGuid().ToString() + "','" + id + "','" + motorNo + "','" + motorNo + "','2','" + DateTime.Now.ToString() + "','0','','RZF','天津市河西区天塔街环湖南里','120004056','120004056','0','','')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.DataSynConnectionString, MySQLHelper.CreateCommand(sql));
        }

        public void ExpiredOrders()
        {
            string sql = "select * from dbo.Rent_RentAttribute where rrastatus='1' or rrastatus='0'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                DateTime createdOn = DateTime.Parse(row["RRACreatedDate"].ToString());
                if (createdOn.AddMinutes(20) < DateTime.Now)
                {
                    sql = "update Rent_RentAttribute set RRAStatus='" + ((int)RentAttributeHelper.AttributeStatus.Expired).ToString() + "' where RRAID=" + row["RRAID"].ToString();
                    MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
                }
            }
        }

        public void UpdateExternalInfo(RentAttribute info)
        {
            string sql = "select * from Rent_RentAttribute_External where RRAID="+info.RRAID.ToString();
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sql = "Update Rent_RentAttribute_External set HZTenantID='"+info.TenantID+"' where RRAID="+info.RRAID.ToString();
            }
            else
            {
                sql = "Insert into Rent_RentAttribute_External values ("+info.RRAID.ToString()+",'"+info.TenantID+"','"+DateTime.Now.ToString()+"')";
            }
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        /// <summary>
        /// 添加随行人员
        /// </summary>
        /// <param name="name"></param>
        /// <param name="idcard"></param>
        /// <param name="rraId"></param>
        public void AddRetinues(string name,string idcard,string rraId)
        {
            string sql = "Insert into Rent_Retinues values ('" + Guid.NewGuid().ToString() + "','" + idcard + "','" + name + "','" + rraId + "','" + SysContext.CurrentUserName + "','" + DateTime.Now.ToString() + "','')";
            MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql));
        }

        /// <summary>
        /// 添加密码到电子锁
        /// </summary>
        /// <param name="rentNO"></param>
        /// <param name="pass"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string AddPassword(string rentNO,string pass,string startdate,string enddate,string phone)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            string sql = "select * from Rent_Locks where rentNo='" + rentNO + "' and Status='0'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DeviceType"].ToString() == "1") //新锁
                {
                    NewLockManager managerNew = new NewLockManager();
                    string r = managerNew.GetPostInterface(dt.Rows[0]["DeviceID"].ToString(), phone, "2", pass, startdate, enddate); //设置临时密码
                    ret = JSONHelper.FromJson<Dictionary<string, string>>(r);
                }
                else //旧锁
                {
                    LockManager manager = new LockManager();
                    manager.AddPassword(dt.Rows[0]["DeviceID"].ToString(), pass, startdate, enddate);
                    string r = manager.UpdatePassengerInfoToDevice(dt.Rows[0]["DeviceID"].ToString(), "", "", "", pass, DateTime.Parse(startdate).ToString("yyyyMMddHHmm").Substring(2, 10), DateTime.Parse(enddate).ToString("yyyyMMddHHmm").Substring(2, 10), "3");
                    ret = JSONHelper.FromJson<Dictionary<string, string>>(r);
                }
            }
            else
            {
                ret.Add("ret", "1");
                ret.Add("msg", "未发现智能锁信息，无法添加密码");
            }

            return JSONHelper.ToJson(ret);
        }

        /// <summary>
        /// 删除密码和IC卡
        /// </summary>
        /// <param name="aarId"></param>
        /// <returns></returns>
        public string ClearPasswordToLock(string aarId)
        {
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

        /// <summary>
        /// 推送数据到华泽
        /// </summary>
        /// <param name="rraId"></param>
        /// <param name="rentNo"></param>
        public void UploadDataToHZ(string rraId,string rentNo)
        {
            string uploadHZ = ConfigurationManager.AppSettings["UploadDataToHZ"];
            if (uploadHZ.Equals("1")) //upload data to HZ
            {
                LogManager.WriteLog("UploadHZ:Start");
                string hzUrl = ConfigurationManager.AppSettings["HZDataService"];
                HuaZeServiceHelper hzHelper = new HuaZeServiceHelper();
                string bbb = hzHelper.UploadRentInfoToHZ(new RentInfo(rentNo),new RentAttribute(int.Parse(rraId)));
                LogManager.WriteLog("UploadHZ:"+bbb);
            }

            SysLogHelper.AddLog("租户", "订单付费", "租赁信息");
        }

        /// <summary>
        /// 获取随行人员
        /// </summary>
        /// <param name="rraId"></param>
        /// <returns></returns>
        public DataTable GetRetinues(string rraId)
        {
            string sql = "select * from Rent_Retinues where RRAID = '"+rraId+"'";
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            return dt;
        }

        public void SendSMSMessage(string rentee,string ownerphone)
        {
            SMS.CommonServices service = new SMS.CommonServices();
            string msg = ConfigurationManager.AppSettings["CompleteOrderMessage"];
            msg = string.Format(msg, rentee);
            SMS.Authentication au = new SMS.Authentication();
            au.UserID = "admin";
            au.PassWord = "Pa$$w0rd780419";
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            au.TimeStamp = timeStamp;
            au.Token = LigerRM.Common.Global.Encryp.MD5("guardts" + timeStamp + "house");
            service.AuthenticationValue = au;
            string ret = service.SendMsg(ownerphone, msg);
        }
    }
}

