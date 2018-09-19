using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using SignetInternet_BusinessLayer;
using LigerRM.Common;
using System.Text;



namespace LigerRM.WebService
{

    public class Api : ApiHelp
    {
        ApiLayer apilay = new ApiLayer();


        #region  app首页
        /// <summary>
        /// app首页
        /// </summary>
        /// <returns></returns>   
        public string AppHome(string cityName)
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                AppHomeModel cf = new AppHomeModel();
                cf.Banner = apilay.GetBanner();
                cf.Especially = apilay.GetEspecially(cityName);
                cf.Recommend = apilay.GetRecommend(cityName);
                cf.about = apilay.GetaboutUs();
                cf.Class = apilay.GethouseClass();
                cf.Label = apilay.GetfooterLabel();
                Return.Code = "0001";//1
                Return.Data = cf;
                string json = JSONHelper.ToJson(Return);
                return json;

            }
            //递查逻辑
            catch (InvalidCastException e)
            {
                string mag = e.GetType().ToString().Split('.')[1];
                Return.Code = "4002";
                Return.Msg = "无效类型转换的异常！";
                Return.Data = "";
                string json = JSONHelper.ToJson(Return);
                return json;
            }
            catch (InvalidOperationException e)
            {
                string mag = e.GetType().ToString().Split('.')[1];
                Return.Code = "4002";
                Return.Msg = "无效操作异常！";
                //返回数据 如错显示错误 如无错返回空
                Return.Data = "";
                string json = JSONHelper.ToJson(Return);
                return json;
            }
            catch (SoapHeaderException e)
            {
                string mag = e.GetType().ToString().Split('.')[1];
                Return.Code = "3001";
                Return.Msg = "Soap服务器处理异常！";
                Return.Data = "";
                string json = JSONHelper.ToJson(Return);
                return json;
            }
            catch (Exception ex)
            {
                string mag = ex.GetType().ToString().Split('.')[1];
                Return.Code = "1001";
                Return.Msg = "后台程序错误！";
                Return.Data = "";
                string json = JSONHelper.ToJson(Return);
                return json;
            }
        }
        #endregion


        #region 获取验证码
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="?">手机号</param>
        /// <param name="SendType">验证码类型</param>
        /// <returns></returns>
        public string VerificationCode(string phone, int SendType)
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                if (!IsMobilePhone(phone))
                {
                    Return.Code = "4001";
                    Return.Msg = "手机号格式错误！！！";
                    return JSONHelper.ToJson(Return);
                }

                string Code = CreateRandomCode(6, 0);
                string msg = "[温馨提示]尊敬的用户，您的验证码是" + Code + "。";
                string Message = LigerRM.Common.Global.GSMHelper.SendMessage(phone, msg);
                //保存验证码
                string Md5 = GetSignString(phone + Code);
                Cookie.SaveCookie("VerificationCode", Md5, 20);
                Return.Code = "0001";
                Return.Msg = "验证码发生成功！！！";
                Return.Data = Code;
                return JSONHelper.ToJson(Return);

            }
            catch (Exception ex)
            {
                Return.Code = "0001";
                Return.Msg = "验证码获取失败！！！";
                return JSONHelper.ToJson(Return);
            }
        }
        #endregion
        #region 获取用户信息
        public string GetUserInformation(int Obtain, string OpenId)
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                ThirdPartyFResultBind UserMod = new ThirdPartyFResultBind();
                var e = apilay.GetUser(Obtain, OpenId);
                if (e.UserID != null)
                {
                    UserMod.ID = e.UserID.ToString();
                    UserMod.IsNeed = 0;
                    UserMod.NickName = e.NickName;
                    UserMod.Phone = e.Phone;
                    UserMod.Photo = e.Headimgurl;
                    UserMod.Uname = e.RealName;
                    UserMod.QQ_Token = e.QQAccess_Token;
                    UserMod.QQ_Token_LastTime = e.QQ_Token_LastTime;
                    UserMod.WeChat_Token = e.WeChatAccess_Token;
                    UserMod.WeChat_Token_LastTime = e.WeChat_Token_LastTime;
                    Return.Code = "0001";
                    Return.Data = UserMod;
                    return JSONHelper.ToJson(Return);
                }
                else
                {
                    Return.Code = "4001";
                    Return.Msg = "未能获取到任何信息！！！";
                    return JSONHelper.ToJson(Return);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
        #region  绑定手机号

        /// <summary>
        /// 绑定手机号用户信息
        /// </summary>
        /// <param name="Phone">手机号</param>
        /// <param name="Code">验证码</param>
        /// <returns></returns>
        public string BindingPhone(string Data, string Phone, string Code)
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                ThirdPartyParams Mod = new ThirdPartyParams();
                string st = JSONHelper.ToJson(Mod);
                try
                {
                    Mod = Newtonsoft.Json.JsonConvert.DeserializeObject<ThirdPartyParams>(Data);
                }
                catch (Exception ex)
                {
                    Return.Code = "4001";
                    Return.Msg = "入参无法解析！！";
                    return JSONHelper.ToJson(Return);
                }


                string Md5 = GetSignString(Phone + Code);
                //验证手机验证码是否一直
                if (!Md5.Equals(Cookie.GetCookie("VerificationCode")))
                {
                    Return.Code = "4001";
                    Return.Msg = "验证码错误！！！";
                    return JSONHelper.ToJson(Return);
                }

                var UserMod = apilay.GetUser(2, Phone);

                SignetInternet_BusinessLayer.Models.Login.CF_User BllMod = new SignetInternet_BusinessLayer.Models.Login.CF_User();
                BllMod.Phone = Phone;
                BllMod.WeChat_Token_LastTime = DateTime.Now;
                BllMod.WeChatAccess_Token = Mod.Access_Token;
                BllMod.WeChatOpenid = Mod.Openid;
                BllMod.NickName = Mod.Nickname;
                BllMod.LoginName = Phone;
                BllMod.LastLoginTime = DateTime.Now;
                BllMod.Headimgurl = Mod.Headimgurl;
                BllMod.Sex = Mod.Sex;
                if (UserMod.UserID == 0)
                {
                    int count = apilay.AddUser(BllMod);
                    if (count == 0)
                    {
                        Return.Code = "1001";
                        Return.Msg = "绑定失败！！！";
                        return JSONHelper.ToJson(Return);
                    }

                    return JSONHelper.ToJson(GetUserInformation(3, Phone));
                }
                else
                {
                    int count = apilay.UpdateUser(BllMod);
                    if (count == 0)
                    {
                        Return.Code = "1001";
                        Return.Msg = "绑定失败！！！";
                        return JSONHelper.ToJson(Return);
                    }
                    return JSONHelper.ToJson(GetUserInformation(3, Phone));
                }



            }
            catch (Exception ex)
            {
                Return.Code = "1001";
                Return.Msg = "绑定失败！！！";
                return JSONHelper.ToJson(Return);
            }
        }
        #endregion
        #region  app登录


        /// <summary>
        ///  第三方登录
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string ThirdParty(string Access_Token, string Openid, int LoginType)
        {
            ReturnJosn Rresult = new ReturnJosn();

            //ThirdPartyParams Mod = Newtonsoft.Json.JsonConvert.DeserializeObject<ThirdPartyParams>(data);
            try
            {
                if (string.IsNullOrEmpty(Access_Token))
                {
                    Rresult.Code = "4001";
                    Rresult.Msg = "Access_Token不能为空";
                    return JSONHelper.ToJson(Rresult);
                }
                if (string.IsNullOrEmpty(Openid))
                {
                    Rresult.Code = "4001";
                    Rresult.Msg = "Openid不能为空";
                    return JSONHelper.ToJson(Rresult);
                }
                if (LoginType == -1)
                {
                    Rresult.Code = "4001";
                    Rresult.Msg = "请求类型不能为空";
                    return JSONHelper.ToJson(Rresult);
                }
                //验证是否是需要绑定手机号 0 第一次登陆 
                int Register = IsRegister(LoginType, Openid);
                if (Register == 0)
                {
                    ThirdPartyFResultNeedBind NNeedMod = new ThirdPartyFResultNeedBind();
                    NNeedMod.IsNeed = 1;
                    Rresult.Code = "0001";
                    Rresult.Data = NNeedMod;
                    return JSONHelper.ToJson(Rresult);
                }

                //更新登录信息
                apilay.SetLoginUser(Access_Token, Openid);
                return JSONHelper.ToJson(GetUserInformation(LoginType, Openid));

            }
            catch (Exception ex)
            {
                Rresult.Code = "1001";
                Rresult.Msg = "发生异常";
                Rresult.Data = "";
                return JSONHelper.ToJson(Rresult);
            }


        }




        /// <summary>
        /// 验证是否是第一次登陆
        /// </summary>
        /// <param name="Mod"></param>
        /// <returns></returns>
        public int IsRegister(int LoginType, string Openid)
        {

            try
            {
                var e = apilay.GetUser(LoginType, Openid);
                if (e.UserID > 0)
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
        #region 获取省市县
        public string GetProvinces()
        {
            return apilay.GetProvinces();
        }

        public string GetCity(string ProvincesId)
        {
            return apilay.GetCity(ProvincesId);
        }

        public string GetArea(string CityId)
        {
            return apilay.GetArea(CityId);
        }
        #endregion
        #region 获取房屋属性(发布房屋,请求房屋需要设置的属性)

        public string GetBasicAttributes()
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                BasicAttributes Mod = new BasicAttributes();
                //配套设施
                Mod.Facilities = apilay.BasicAttributes();
                //周边
                Mod.Periphery = apilay.BasicAttributes(2);
                //景点
                Mod.ScenicSpot = apilay.BasicAttributes(3);
                //房屋特色
                Mod.Characteristic = apilay.BasicAttributes(4);
                Return.Code = "0001";
                Return.Data = Mod;
                return JSONHelper.ToJson(Return);

            }
            catch (Exception ex)
            {
                Return.Code = "4001";
                Return.Msg = "发生错误！！";
                return JSONHelper.ToJson(Return);
            }
        }


        #endregion
    }
}