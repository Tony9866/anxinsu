using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liger.Data
{
    public interface ITableResizable
    {
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="tName"></param>
        void SetTable(string tName);
    }
}
