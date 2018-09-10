using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigerRM.Common
{
    /// <summary>
    /// 明细页面的页面视图基类
    /// </summary>
    public class ViewDetailPage : ViewPageBase
    {
        public string CurrentID { get; private set; }
        public byte IsView { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.CurrentID = Request.QueryString["ID"];

            if (Request.QueryString["IsView"] == "1")
            {
                IsView = 1;
            }
            else
            {
                IsView = 0;
            }
        }
    }
}
