using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.AppHome
{
   public class appHouse_Class
    {
       /// <summary>
       /// 唯一标识
       /// </summary>
       public int classId { get; set; }


        /// <summary>
        /// 目录级别
        /// 一级目录“1”
        /// 二级目录“2”
        /// 三级目录“3” --以此类推
        /// </summary>
        public int lvlId { get; set; }

        /// <summary>
        /// 所有分类名称
        /// </summary>
        public string class_Name { get; set; }
        
        /// <summary>
        /// 分类中的图片URL地址
        /// </summary>
        public string imageUrl { get; set; }

       /// <summary>
       /// 目录名称所对应的描述
       /// </summary>
        public string description { get; set; }


    }
}
