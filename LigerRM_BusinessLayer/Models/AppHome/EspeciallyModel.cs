﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.AppHome
{
    public class EspeciallyModel
    {
        
        /// <summary>
        /// 唯一标识
        /// </summary>
        public long SpecialId { get; set; }
        /// <summary>
        /// 标题名称
        /// </summary>
        public string typeName { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 特色房源图片地址
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
