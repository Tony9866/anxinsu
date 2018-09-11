using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigerRM.Common.Helper
{
    public  class Basics
    {
        /// <summary>
        /// 基础返回类
        /// </summary>
        public  class ReturnJosn
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
    }
}
