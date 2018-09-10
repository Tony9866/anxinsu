using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Script.Serialization;
using System.Linq;
using System.Collections.Specialized;
using Liger.Common;
using Liger.Data;
using Liger.Common.Extensions;

namespace LigerRM.Common
{
    /// <summary>
    /// 内部 Ajax 方法 容器
    /// </summary>
    internal class AjaxAction
    {
        public AjaxAction(MethodInfo method)
        {
            this.Method = method;
            this.Parameters = this.Method.GetParameters();
        }

        public MethodInfo Method { get; private set; }

        public ParameterInfo[] Parameters { get; private set; }
    }
}
