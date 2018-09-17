using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignetInternet_BusinessLayer.Models.AppHome;
using SignetInternet_BusinessLayer.Models.Login;
using SignetInternet_BusinessLayer.Models.Region;
using LigerRM.Common;

namespace SignetInternet_BusinessLayer
{
    public class ApiLayer : BaseHelper
    {
        #region  接口基础返回类

        //获取banner 头里的3张图片和文字描述
        public List<AppHome_Banner> GetBanner()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT *  FROM AppHome_Banner");
                List<AppHome_Banner> List = GetList<AppHome_Banner>(str.ToString());
                return List;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        //获取特色房源里的 3个class 来展示图片跟文字信息。
        public List<EspeciallyModel> GetEspecially(string cityName)
        {
            try
            {
                string CityId = GetLocal(cityName);
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * ");
                str.Append("FROM AppHome_SpecialInfo ");
                str.Append("WHERE ");
                str.Append("    cityId = '").Append(CityId).Append("'");
                List<EspeciallyModel> List = GetList<EspeciallyModel>(str.ToString());
                if (cityName != "天津市" && (List == null || List.Count == 0))
                {
                    List = GetEspecially("天津市");
                }
                return List;
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        //获取热门推荐里的6个class来展示图片跟文字信息。
        public List<AppHome_Recommend> GetRecommend(string cityName)
        {
            try
            {
                string CityId = GetLocal(cityName);
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * ");
                str.Append("FROM appHome_Recommend ");
                str.Append("WHERE  ");
                str.Append("    cityId = '").Append(CityId).Append("'");
                List<AppHome_Recommend> List = GetList<AppHome_Recommend>(str.ToString());
                if (cityName != "天津市" && (List == null || List.Count == 0))
                {
                    //CityId != "120100"
                    List = GetRecommend("天津市");
                }

                    return List;
                
            }
            catch (Exception e)
            {

                throw;
            }
        }
        //获取热门推荐里底部3个content_Name公司信息展示
        public List<appHome_aboutUs> GetaboutUs()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("select * from appHome_aboutUs");
                List<appHome_aboutUs> List = GetList<appHome_aboutUs>(str.ToString());
                return List;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        //层末分类显示
        public List<appHouse_Class> GethouseClass()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("select imageUrl, class_name, lvlId from appHouse_Class");
                List<appHouse_Class> List = GetList<appHouse_Class>(str.ToString());
                return List;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        //底部标签显示
        public List<footerLabel> GetfooterLabel()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("select * from appHome_footerLabel");
                List<footerLabel> List = GetList<footerLabel>(str.ToString());
                return List;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        #endregion
        #region  获取用户信息

        public CF_User GetUser(int Obtain, string OpenId)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                CF_User Mod = new CF_User();
                str.Append("SELECT * FROM CF_User  ");
                if (Obtain == 1)
                {
                    str.Append("WHERE WeChatOpenid='").Append(OpenId).Append("'");
                }
                else if (Obtain == 0)
                {
                    str.Append("WHERE QQOpenid='").Append(OpenId).Append("'");
                }
                else if (Obtain == 2)
                {
                    str.Append("WHERE UserID=").Append(OpenId).Append("");
                }
                else if (Obtain == 3)
                {
                    str.Append("WHERE Phone='").Append(OpenId).Append("'");
                }
                else
                {
                    Mod = new CF_User();
                    return Mod;
                }
                Mod = GetModel<CF_User>(str.ToString());
                if (Mod == null)
                {
                    return new CF_User();
                }
                return Mod;
            }
            catch (Exception ex)
            {
                return new CF_User();
            }
        }



        #endregion
        #region  绑定手机号
        public int BindingPhone(string Phone, int UserId)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("UPDATE CF_User ");
                str.Append("SET");
                str.Append("    Phone=").Append(Phone);
                str.Append("WHERE UserId='").Append(UserId).Append("'");
                int count = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(str.ToString()));
                if (count > 0)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #region  编辑用户信息
        public int AddUser(CF_User Mod)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("INSERT into CF_User ");
                str.Append("(");
                str.Append("    Phone,");
                str.Append("    WeChat_Token_LastTime,");
                str.Append("    WeChatAccess_Token,");
                str.Append("    WeChatOpenid,");
                str.Append("    NickName,");
                str.Append("    LoginName,");
                str.Append("    LastLoginTime,");
                str.Append("    Headimgurl,");
                str.Append("    Sex ) ");
                str.Append("VALUES ( ");
                str.Append("    '").Append(Mod.Phone).Append("',");
                str.Append("    '").Append(Mod.WeChat_Token_LastTime).Append("',");
                str.Append("    '").Append(Mod.WeChatAccess_Token).Append("',");
                str.Append("    '").Append(Mod.WeChatOpenid).Append("',");
                str.Append("    '").Append(Mod.NickName).Append("',");
                str.Append("    '").Append(Mod.LoginName).Append("',");
                str.Append("    '").Append(Mod.LastLoginTime).Append("',");
                str.Append("    '").Append(Mod.Headimgurl).Append("',");
                str.Append("    ").Append(Mod.Sex).Append("");
                str.Append(")");


                //StringBuilder str = new StringBuilder();
                //str.Append("UPDATE CF_User ");
                //str.Append("SET");
                //str.Append("    Phone=").Append(Mod.Phone).Append(",");
                //str.Append("    WeChat_Token_LastTime=").Append(Mod.WeChat_Token_LastTime).Append(",");
                //str.Append("    WeChatAccess_Token=").Append(Mod.WeChatAccess_Token).Append(",");
                //str.Append("    WeChatOpenid=").Append(Mod.WeChatOpenid).Append(",");
                //str.Append("    NickName=").Append(Mod.NickName).Append(",");
                //str.Append("    LoginName=").Append(Mod.LoginName).Append(",");
                //str.Append("    LastLoginTime=").Append(Mod.LastLoginTime).Append(",");
                //str.Append("    Headimgurl=").Append(Mod.Headimgurl).Append(",");
                //str.Append("    Sex=").Append(Mod.Sex).Append(",");
                //str.Append("WHERE UserId='").Append(Mod.).Append("'");
                int count = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(str.ToString()));
                if (count > 0)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int UpdateUser(CF_User Mod)
        {
            try
            {
                CF_User DbMod = GetUser(3, Mod.Phone);
                StringBuilder str = new StringBuilder();
                str.Append("UPDATE CF_User ");
                str.Append("SET");
                str.Append("    WeChat_Token_LastTime=").Append(Mod.WeChat_Token_LastTime).Append(",");
                str.Append("    WeChatAccess_Token=").Append(Mod.WeChatAccess_Token).Append(",");
                str.Append("    WeChatOpenid=").Append(Mod.WeChatOpenid).Append(",");
                if (string.IsNullOrEmpty(DbMod.Headimgurl))
                {
                    str.Append("    Headimgurl=").Append(Mod.Headimgurl).Append(",");
                }
                str.Append("    LastLoginTime=").Append(Mod.LastLoginTime).Append(",");
                str.Append("WHERE UserId='").Append(DbMod.UserID).Append("'");
                int count = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(str.ToString()));
                if (count > 0)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int SetLoginUser(string WeChatAccess_Token, string Openid)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("UPDATE CF_User ");
                str.Append("SET");
                str.Append("    WeChat_Token_LastTime='").Append(DateTime.Now).Append("',");
                str.Append("    WeChatAccess_Token='").Append(WeChatAccess_Token).Append("',");
                str.Append("    LastLoginTime='").Append(DateTime.Now).Append("'  ");
                str.Append("WHERE WeChatOpenid='").Append(Openid).Append("'");
                int count = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(str.ToString()));
                if (count > 0)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #region 获取省市(区)县
        public string GetProvinces()
        {
            ReturnJosn Return=new ReturnJosn();
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * FROM Public_Provinces");
                List<ProvincesModel> list = GetList<ProvincesModel>(str.ToString());
                if (list == null)  
                {
                    list = new List<ProvincesModel>();
                }
                Return.Code = "0001";
                Return.Data = list;
                return JSONHelper.ToJson(Return);
            }
            catch (Exception ex)
            {
                Return.Code = "2001";
                Return.Msg = "发生错误！！！";
                return JSONHelper.ToJson(Return); 
            }
        }


        #endregion

    }
}
