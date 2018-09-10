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
    /// 内部  Ajax类 容器对象
    /// </summary>
    internal class AjaxTypeContainer
    {
        private static readonly BindingFlags ActionBindingFlags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase;


        public AjaxTypeContainer(Type t)
        {
            this.AjaxClass = t;
            this.Actions = new List<AjaxAction>();
            var methods = t.GetMethods(ActionBindingFlags);
            foreach (var method in methods)
            {
                this.Actions.Add(new AjaxAction(method));
            }
        }
        public Type AjaxClass { get; private set; }

        public List<AjaxAction> Actions { get; private set; }

        public AjaxAction GetAction(string methodName)
        {
            return Actions.Where(c => c.Method.Name == methodName).FirstOrDefault();
        }

        public MethodInfo GetMethod(string methodName)
        {

            var action = Actions.Where(c => c.Method.Name == methodName).FirstOrDefault();
            if (action == null)
            {
                return null;
            }
            return action.Method;
        }
    }

}
