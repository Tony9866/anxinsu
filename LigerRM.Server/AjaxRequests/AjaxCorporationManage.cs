using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LigerRM.Common;
using SignetInternet_BusinessLayer;

namespace LigerRM.Server.AjaxRequests
{
    public class AjaxCorporationManage
    {
        public static AjaxResult RemoveCorps(string ID)
        {
            CorporationHelper helper = new CorporationHelper();
            if (helper.IsCorporationInUsed(ID))
            {
                return AjaxResult.Error("该使用单位已经注册印章，无法删除！");
            }
            else
            {
                helper.DeleteCorporation(ID);
                SysLogHelper.AddLog(SysContext.CurrentUserName, "删除企业信息ID：" + ID, "删除-企业信息");
                return AjaxResult.Success();
            }
        }

        public static AjaxResult ExistsSameContent(string content)
        {
            CorporationHelper helper = new CorporationHelper();
            if (helper.IsExistsSameCorp(content))
            {
                return AjaxResult.Error("相同的单位名称已经存在，请重新填写！");
            }
            else
                return AjaxResult.Success();
        }
    }
}
