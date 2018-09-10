using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Liger.Data;
using System.Web.UI;
using Liger.Web.MVC;
namespace LigerRM.Common
{
    /// <summary>
    /// 带权限控制的页面基类
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TModelBulider"></typeparam>
    public class ViewPageBase<TModel, TModelBulider> : ViewPage<TModel, TModelBulider>
        where TModelBulider : IModelBulider, new()
    {
        /// <summary>
        /// 权限控制
        /// </summary>
        private void CheckPermission()
        {
            //权限判断
            //base.RequireRedirectedUrl = "";
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.CheckPermission();
        }
    }

    /// <summary>
    /// 带权限控制的页面基类
    /// </summary>
    public class ViewPageBase : ViewPage 
    {
        /// <summary>
        /// 权限控制
        /// </summary>
        private void CheckPermission()
        {
            //权限判断
            //base.RequireRedirectedUrl = "";
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.CheckPermission();
        }  
    }
}
