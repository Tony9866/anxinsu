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



        #region  app登录页

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




        #endregion

    }
}