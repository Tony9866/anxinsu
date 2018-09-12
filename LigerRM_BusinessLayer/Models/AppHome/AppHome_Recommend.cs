using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.AppHome
{
    public class AppHome_Recommend
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int recommendId { get; set; }

        ///// <summary>
        ///// 类型
        ///// </summary>
        //public int Type { get; set; }

        /// <summary>
        /// 标题名称
        /// </summary>
        public string typeName { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public int classId { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string class_Name { get; set; }

        /// <summary>
        /// 热门推荐描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 热门推荐图片地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 图片占比
        /// </summary>
        public string imageSize { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public string cityId { get; set; }

        ///// <summary>
        ///// 省编号
        ///// </summary>
        //public string provinceid { get; set; }
    }
}
