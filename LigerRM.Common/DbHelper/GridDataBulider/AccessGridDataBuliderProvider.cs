﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using Liger.Common.Extensions;
using Liger.Data.Extensions;
using Liger.Data;

namespace LigerRM.Common
{
    public class AccessGridDataBuliderProvider : GridDataBuliderProvider
    {
        public AccessGridDataBuliderProvider(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
