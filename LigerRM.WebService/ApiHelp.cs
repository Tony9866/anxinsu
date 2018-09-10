using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignetInternet_BusinessLayer.Models.AppHome;

namespace LigerRM.WebService
{
    public class ApiHelp
    {
        
        #region  接口基础返回类
        /// <summary>
        /// 基础返回类
        /// </summary>
        public class ReturnJosn
        {
            /// <summary>
            /// 返回代码
            /// </summary>
            public string Code { get; set; }
            /// <summary>
            /// 返回信息
            /// </summary>
            public string Msg { get; set; }
            /// <summary>
            /// 返回内容
            /// </summary>
            public object Data { get; set; }

            public ReturnJosn()
            {
                Msg = "Success!";
            }
        }


        #endregion

        #region  APP首页
        public class AppHomeModel
        {
            /// <summary>
            /// Banner
            /// </summary>
            public List<AppHome_Banner> Banner { get; set; }
            /// <summary>
            /// 特色房源
            /// </summary>
            public List<EspeciallyModel> Especially { get; set; }

            /// <summary>
            /// 热门推荐
            /// </summary>
            public List<AppHome_Recommend> Recommend { get; set; }

            /// <summary>
            /// 所有服务协议内容
            /// </summary>
            public List<appHome_aboutUs> about { get; set; }

            /// <summary>
            /// 分类显示
            /// </summary>
            public List<appHouse_Class> Class { get; set; }


            /// <summary>
            /// 底部标签显示
            /// </summary>
            public List<footerLabel> Label { get; set; }

        }
        #endregion

        //#region 获取用户信息
        //public class UserNameModel
        //{
        //    public object UserName { get; set; }
        //}
        //#endregion
    }
}