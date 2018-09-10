using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignetInternet_DataLayer.BaseDataSetTableAdapters;
namespace SignetInternet_BusinessLayer
{
    public static class SysLogHelper
    {
        
        public static void AddLog(string user, string content, string type)
        {
            RentInfoHelper helper = new RentInfoHelper();
            helper.ExcuteSql("insert into sys_log values ('"+user+"','"+DateTime.Now.ToString()+"','"+content+"','"+type+"')");
           // Sys_LogTableAdapter adapter = new Sys_LogTableAdapter();
           // adapter.up_SignetInternet_SysLogInsert(user, DateTime.Now, content, type);
        }
    }
}
