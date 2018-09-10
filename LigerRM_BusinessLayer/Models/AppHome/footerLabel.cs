using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.AppHome
{
   public class footerLabel
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int id { get; set; }

       /// <summary>
        /// 标签编号
       /// </summary>
        public int tabId { get; set; }

       /// <summary>
        /// 标签名称
       /// </summary>
        public string tabName { get; set; }

       /// <summary>
        /// 标签描述
       /// </summary>
        public string description { get; set; }

       /// <summary>
        /// 图标地址
       /// </summary>
        public string iconUrl { get; set; }
    }
}
