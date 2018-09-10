using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data.Common;
using System.Data;
using Liger.Data;



namespace Liger.Data.Oracle
{
    public class OracleProvider : DbProvider
    {
        public OracleProvider(string connectionString)
            : base(connectionString, OracleClientFactory.Instance, '"', '"', ':')
        {
        }

        public override string RowAutoID
        {
            get { return "select {0}.currval from dual"; }
        }

        public override bool SupportBatch
        {
            get { return true; }
        }
    }
}
