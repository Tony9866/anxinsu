using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.Rent_Rent
{
    public class Rent_BasicAttributes
    {
        /// <summary>
        /// 房屋属性ID
        /// </summary>
        public long BasicAttributesId { get; set; }
        /// <summary>
        /// 属性类型  1  配套设施 2 周边  3景点  4 房屋特色
        /// </summary>
        //public int Type { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string BasicAttributesName { get; set; }

    }

    public class TwoRent_BasicAttributes:Rent_BasicAttributes
    {
        /// <summary>
        /// 图标（选中）
        /// </summary>
        public string Icon1 { get; set; }
        /// <summary>
        /// 图标（未选中）
        /// </summary>
        public string Icon2 { get; set; }
    }
}
