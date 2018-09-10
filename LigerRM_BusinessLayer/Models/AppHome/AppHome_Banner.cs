using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.AppHome
{
    public class AppHome_Banner
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public long BannerId { get; set; }

        /// <summary>
        /// Banner类型 1 外链 2 内链 3 无链接
        /// </summary>
        public int BannerType { get; set; }

        /// <summary>
        /// Banner图片地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 外联地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 内链类别编号
        /// 1-房源编号 2-房屋分类列表
        /// </summary>
        public int innerClassId { get; set; }

        /// <summary>
        /// 内链类别内容
        /// 单个房屋详情的编号
        /// 房屋分类编号
        /// </summary>
        public string innerContent { get; set; }
    }
}
