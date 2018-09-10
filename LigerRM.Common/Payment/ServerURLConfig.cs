using System;

/**
* 请求服务地址 配置
*
*/

namespace LigerRM.Common.Payment
{
	public class ServerURLConfig
	{
		public static string PAY_URL = "https://cashier.lianlianpay.com/payment/bankgateway.htm"; // 网银收银台支付服务地址
		public static string QUERY_USER_BANKCARD_URL = "https://queryapi.lianlianpay.com/bankcardbindlist.htm"; // 用户已绑定银行卡列表查询
		public static string QUERY_BANKCARD_URL = "https://queryapi.lianlianpay.com/bankcardbin.htm"; //银行卡卡bin信息查询

        public static string WECHARTPAY_URL = "https://yintong.com.cn/offline_api/createOrder_init.htm"; // 网银收银台支付服务地址
        public static string WECHARTQUERY_URL = "https://yintong.com.cn/offline_api/queryOrder.htm";
    }
}

