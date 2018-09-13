using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using SignetInternet_BusinessLayer;
using LigerRM.Common;


namespace LigerRM.WebService
{

    public class Api:ApiHelp
    {
        ApiLayer apilay = new ApiLayer();


        #region  app首页
        /// <summary>
        /// app首页
        /// </summary>
        /// <returns></returns>   
        public string AppHome()
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                AppHomeModel cf = new AppHomeModel();
                cf.Banner = apilay.GetBanner();
                cf.Especially = apilay.GetEspecially();
                cf.Recommend = apilay.GetRecommend();
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



        #region  app登录


        /// <summary>
        ///  第三方登录
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        //public string ThirdParty(string Data)
        //{
        //    ReturnJosn Rresult = new ReturnJosn();
        //    try
        //    {
        //        //Data = "{LoginType:1,Access_Token:\"yW0KoxpHeVbYmpB4TKVDWCmWHnEuPg3x89BcI0LMW3PSaMd-5pz2X_7FlXSe65kT_ooT9EnAYLJiq9M5-oIgcg\",Openid:\"oq_cfw_Lu-yL0uvRNTFU58lPRxEw\",Nickname:\"🦄ʘᴗʘ咸蛋娇娃🌦\",Headimgurl:\"https://wx.qlogo.cn/mmopen/Q3auHgzwzM5CYzbib7YiacibEu040fZC1HdCEQPibKdvVibELKmoJgkJibz3uWqpibS7Xoc6XCmKPJm8ygbcTFHDbhv3w/0\",Sex:0,Operation:0}";
        //        try
        //        {
        //            ThirdPartyParams Mod = JsonConvert.DeserializeObject<ThirdPartyParams>(Data);
        //            if (string.IsNullOrEmpty(Mod.Access_Token))
        //            {
        //                Rresult.Code = "1";
        //                Rresult.Errmsg = "Access_Token不能为空";
        //                return ToJson(Rresult);
        //            }
        //            if (string.IsNullOrEmpty(Mod.Openid))
        //            {
        //                Rresult.Code = "1";
        //                Rresult.Errmsg = "Openid不能为空";
        //                return ToJson(Rresult);
        //            }
        //            if (Mod.LoginType == -1)
        //            {
        //                Rresult.Code = "1";
        //                Rresult.Errmsg = "请求类型不能为空";
        //                return ToJson(Rresult);
        //            }

        //            if (Mod.Operation == -1)
        //            {
        //                Rresult.Code = "1";
        //                Rresult.Errmsg = "请求类型不能为空";
        //                return ToJson(Rresult);
        //            }
        //            Sys_User UserMod = null;
        //            string BindID = "";
        //            int IsNeed = -1;
        //            //开始进行检测入参数据
        //            if (Mod.LoginType == (int)LoginType.QQ)
        //            {
        //                #region 当前为QQ登录，首先检测是否之前已经登录过
        //                IsNeed = IsNeedBindPhone(Mod, ref UserMod, ref BindID);
        //                #endregion
        //            }
        //            else if (Mod.LoginType == (int)LoginType.WeChat)
        //            {
        //                #region 当前为微信登录，首先检测是否之前已经登录过
        //                IsNeed = IsNeedBindPhone(Mod, ref UserMod, ref BindID);
        //                #endregion
        //            }
        //            else
        //            {
        //                #region 当前登录方式不合法，抛回错误
        //                Rresult.Code = "1";
        //                Rresult.Msg = "选择登录方式不正确";
        //                Rresult.Data = "";
        //               // AddErrorLog("ThirdParty_Error", "选择登录方式不正确:" + Mod.LoginType);
        //                return ToJson(Rresult);
        //                #endregion
        //            }


        //            if (IsNeed == 0)
        //            {
        //                //刷新ACCESS_TOKEN
        //                if (Mod.LoginType == (int)LoginType.QQ)
        //                {
        //                    UserMod.QQ_Token = Mod.Access_Token;
        //                    UserMod.QQ_Token_LastTime = DateTime.Now;
        //                }
        //                else if (Mod.LoginType == (int)LoginType.WeChat)
        //                {
        //                    UserMod.WeChat_Token = Mod.Access_Token;
        //                    UserMod.WeChat_Token_LastTime = DateTime.Now;
        //                }

        //                UserMod = UserService.Update(UserMod);
        //                //当前不需要绑定,直接返回用户信息
        //                LoginSuccessResult Result = new LoginSuccessResult();
        //                //用户ID
        //                Result.UserId = UserMod.ID;

        //                //是否VIP
        //                if (UserMod.GradeID != null && UserMod.GradeID.Value == 2)
        //                {
        //                    Result.IsVip = "2";
        //                }
        //                else
        //                {
        //                    if (UserMod.AddTime.AddDays(3) > DateTime.Now)
        //                    {
        //                        Result.IsVip = "1";
        //                    }
        //                    else
        //                    {
        //                        Result.IsVip = "0";
        //                    }
        //                }
        //                //Vip到期时间
        //                Result.VIPTime = UserMod.AddTime.AddDays(3).ToString("yyyy-MM-dd HH:mm:ss");
        //                //昵称
        //                Result.NickName = UserMod.NickName;
        //                //电话
        //                Result.Phone = UserMod.Phone;
        //                //头像
        //                Result.Photo = UserMod.Photo;
        //                //个性签名
        //                Result.Signature = UserMod.Signature;
        //                //个性签名
        //                Result.Email = UserMod.Email;
        //                //Token
        //                if (Mod.LoginType == (int)LoginType.QQ)
        //                {
        //                    //登陆类型
        //                    Result.LoginType = "0";
        //                    Result.Token = UserMod.QQ_Token;
        //                }
        //                else if (Mod.LoginType == "WeChat")
        //                {
        //                    //登陆类型
        //                    Result.LoginType = "1";
        //                    Result.Token = UserMod.WeChat_Token;
        //                }
        //                //用户类型
        //                Result.UserType = UserMod.TypeID.ToString();
        //                //是否需要重新登录
        //                Result.Again = "0";
        //                //是否需要绑定
        //                Result.IsNeed = "0";
        //                //
        //                Result.LoginResults = "0";

        //                Rresult.Code = "0";
        //                Rresult.Msg = "登陆成功";
        //                Rresult.Data = Result;
        //                return JSONHelper.ToJson(Rresult);
        //            }
        //            else if (IsNeed == 1)
        //            {
        //                //当前需要绑定，返回一个需要绑定的信号以及已完成绑定的ID 
        //                LoginFailResult Result = new LoginFailResult();
        //                Result.IsNeed = IsNeed.ToString();
        //                Result.BindID = BindID;
        //                Rresult.Code = "0";
        //                Rresult.Msg = "Success";
        //                Rresult.Data = Result;
        //            }
        //            else
        //            {
        //                //。。这怎么进来的？
        //                Rresult.Code = "1";
        //                Rresult.Msg = "发生了不可能事件..";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Rresult.Code = "1";
        //            Rresult.Msg = "入参数据无法解析";
        //            Rresult.Data = "";
        //           // AddErrorLog("ThirdParty_Error", "入参数据无法解析:" + Data);
        //            return JSONHelper.ToJson(Rresult);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Rresult.Code = "1";
        //        Rresult.Msg = "发生异常";
        //        Rresult.Data = "";
        //        //AddErrorLog("ThirdParty_Error", "发生异常:" + Data);
        //        return JSONHelper.ToJson(Rresult);
        //    }
        //    return JSONHelper.ToJson(Rresult);
        //}
        #endregion 
        /// <summary>
        /// app登录页
        /// </summary>
        /// <returns></returns>
        //public string AppLogin()
        //{
        //    ReturnJosn Return = new ReturnJosn();
        //    try
        //    {

        //    }
        //    catch (Exception e)
        //    {
                
        //        throw;
        //    }
        //}





    }
}