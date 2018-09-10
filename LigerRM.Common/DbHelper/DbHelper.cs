using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Liger.Data;
namespace LigerRM.Common
{
    /// <summary>
    /// 使用默认的DbContext,并加入logging
    /// </summary>
    public class DbHelper
    {

        public static bool EnabledLog = ConfigurationManager.AppSettings["EnabledLog"].ToString() == "true";

        public static readonly DbContext Db = DbContext.Default;

        public static readonly DbContext DBCustome = DbContext.CurrentDB;

        static DbHelper()
        {
            if (EnabledLog)
            {
                Db.Logging((sql) =>
                {
                    if (EnabledLog)
                        LogManager.WriteLog("SQL", sql);
                });
            }
        }
    }
}
