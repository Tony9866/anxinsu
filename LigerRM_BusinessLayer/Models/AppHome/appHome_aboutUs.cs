using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.AppHome
{
    public class appHome_aboutUs
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int id { get; set; }


        /// <summary>
        /// 内容编号
        /// </summary>
        public int contentId { get; set; }


        /// <summary>
        /// 内容名称
        /// </summary>
        public string content_Name { get; set; }

        /// <summary>
        /// 内容英文名称
        /// </summary>
        public string EN_content_Name { get; set; }


        /// <summary>
        /// 内容
        /// </summary>
        public string contents { get; set; }



    }
}
