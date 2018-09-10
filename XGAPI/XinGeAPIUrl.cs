using System;
using XGAPI.Helper;

namespace XGAPI
{
    public class XinGeAPIUrl
    {

        public static readonly String RESTAPI_PUSHSINGLEDEVICE = "http://openapi.xg.qq.com/v2/push/single_device";
        public static readonly String RESTAPI_PUSHSINGLEACCOUNT = "http://openapi.xg.qq.com/v2/push/single_account";
        public static readonly String RESTAPI_PUSHACCOUNTLIST = "http://openapi.xg.qq.com/v2/push/account_list";
        public static readonly String RESTAPI_PUSHALLDEVICE = "http://openapi.xg.qq.com/v2/push/all_device";
        public static readonly String RESTAPI_PUSHTAGS = "http://openapi.xg.qq.com/v2/push/tags_device";
        public static readonly String RESTAPI_QUERYPUSHSTATUS = "http://openapi.xg.qq.com/v2/push/get_msg_status";
        public static readonly String RESTAPI_QUERYDEVICECOUNT = "http://openapi.xg.qq.com/v2/application/get_app_device_num";
        public static readonly String RESTAPI_QUERYTAGS = "http://openapi.xg.qq.com/v2/tags/query_app_tags";
        public static readonly String RESTAPI_CANCELTIMINGPUSH = "http://openapi.xg.qq.com/v2/push/cancel_timing_task";
        public static readonly String RESTAPI_BATCHSETTAG = "http://openapi.xg.qq.com/v2/tags/batch_set";
        public static readonly String RESTAPI_BATCHDELTAG = "http://openapi.xg.qq.com/v2/tags/batch_del";
        public static readonly String RESTAPI_QUERYTOKENTAGS = "http://openapi.xg.qq.com/v2/tags/query_token_tags";
        public static readonly String RESTAPI_QUERYTAGTOKENNUM = "http://openapi.xg.qq.com/v2/tags/query_tag_token_num";
        public static readonly String RESTAPI_CREATEMULTIPUSH = "http://openapi.xg.qq.com/v2/push/create_multipush";
        public static readonly String RESTAPI_PUSHACCOUNTLISTMULTIPLE = "http://openapi.xg.qq.com/v2/push/account_list_multiple";
        public static readonly String RESTAPI_PUSHDEVICELISTMULTIPLE = "http://openapi.xg.qq.com/v2/push/device_list_multiple";
        public static readonly String RESTAPI_QUERYINFOOFTOKEN = "http://openapi.xg.qq.com/v2/application/get_app_token_info";
        public static readonly String RESTAPI_QUERYTOKENSOFACCOUNT = "http://openapi.xg.qq.com/v2/application/get_app_account_tokens";
        public static readonly String RESTAPI_DELETETOKENOFACCOUNT = "http://openapi.xg.qq.com/v2/application/del_app_account_tokens";
        public static readonly String RESTAPI_DELETEALLTOKENSOFACCOUNT = "http://openapi.xg.qq.com/v2/application/del_app_account_all_tokens";

        public static readonly String HTTP_POST = "POST";
        public static readonly String HTTP_GET = "GET";

        public static readonly int DEVICE_ALL = 0;
        public static readonly int DEVICE_BROWSER = 1;
        public static readonly int DEVICE_PC = 2;
        public static readonly int DEVICE_ANDROID = 3;
        public static readonly int DEVICE_IOS = 4;
        public static readonly int DEVICE_WINPHONE = 5;

        public static readonly int IOSENV_PROD = 1;
        public static readonly int IOSENV_DEV = 2;

        public static readonly long IOS_MIN_ID = 2200000000L;
    }
}
