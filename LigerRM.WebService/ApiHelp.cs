using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignetInternet_BusinessLayer.Models.AppHome;
using System.Text.RegularExpressions;

namespace LigerRM.WebService
{
    public class ApiHelp
    {

        #region  接口基础返回类
        /// <summary>
        /// 基础返回类
        /// </summary>
        public class ReturnJosn
        {
            /// <summary>
            /// 返回代码
            /// </summary>
            public string Code { get; set; }
            /// <summary>
            /// 返回信息
            /// </summary>
            public string Msg { get; set; }
            /// <summary>
            /// 返回内容
            /// </summary>
            public object Data { get; set; }

            public ReturnJosn()
            {
                Msg = "Success!";
            }
        }


        #endregion

        #region  APP首页
        public class AppHomeModel
        {
            /// <summary>
            /// Banner
            /// </summary>
            public List<AppHome_Banner> Banner { get; set; }
            /// <summary>
            /// 特色房源
            /// </summary>
            public List<EspeciallyModel> Especially { get; set; }

            /// <summary>
            /// 热门推荐
            /// </summary>
            public List<AppHome_Recommend> Recommend { get; set; }

            /// <summary>
            /// 所有服务协议内容
            /// </summary>
            public List<appHome_aboutUs> about { get; set; }

            /// <summary>
            /// 分类显示
            /// </summary>
            public List<appHouse_Class> Class { get; set; }


            /// <summary>
            /// 底部标签显示
            /// </summary>
            public List<footerLabel> Label { get; set; }

        }
        #endregion
        #region  功能：产生数字和字符混合的随机字符串
        /// <summary>
        /// 功能：产生数字和字符混合的随机字符串
        /// </summary>
        /// <param name="codecount">字符串的个数</param>
        /// <returns></returns>
        public string CreateRandomCode(int codecount, int Type)
        {
            string allchar = "";
            if (Type == 0)
            {
                allchar = "0,1,2,3,4,5,6,7,8,9";
            }
            else
            {
                // 数字和字符混合字符串
                allchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,A,B,C,D,E,F,G,H,I,J,K,L,M,N";
            }

            //分割成数组
            string[] allchararray = allchar.Split(',');
            string randomcode = "";

            //随机数实例
            System.Random rand = new System.Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < codecount; i++)
            {
                //获取一个随机数
                int t = rand.Next(allchararray.Length);
                //合成随机字符串
                randomcode += allchararray[t];
            }
            return randomcode;
        }
        #endregion
        #region  APP登陆注册

        #region 判断是否是合法手机号
        /// <summary>
        /// 判断输入的字符串是否是一个合法的手机号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsMobilePhone(string input)
        {
            Regex regex = new Regex("^[1][3-8]\\d{9}$");
            return regex.IsMatch(input);
        }
        #endregion

        /// <summary>
        /// 开始构造第三方登录通用入参数据
        /// </summary>
        public class ThirdPartyParams
        {
            /// <summary>
            /// 当前登录类型 0 QQ 1微信
            /// </summary>
            private int _loginType;

            public int LoginType
            {
                get { return _loginType; }
                set { _loginType = value; }
            }


            /// <summary>
            /// 对应登录类型的_access_Token
            /// </summary>
            private string _access_Token;

            public string Access_Token
            {
                get { return _access_Token; }
                set { _access_Token = value; }
            }
            /// <summary>
            /// 唯一识别信息
            /// </summary>
            private string _openid;

            public string Openid
            {
                get { return _openid; }
                set { _openid = value; }
            }
            /// <summary>
            ///  返回昵称
            /// </summary>
            private string _nickname;

            public string Nickname
            {
                get { return _nickname; }
                set { _nickname = value; }
            }
            /// <summary>
            /// 返回头像数据
            /// </summary>
            private string _headimgurl;

            public string Headimgurl
            {
                get { return _headimgurl; }
                set { _headimgurl = value; }
            }
            /// <summary>
            /// 性别
            /// </summary>
            private int _sex;

            public int Sex
            {
                get { return _sex; }
                set { _sex = value; }
            }


            /// <summary>
            ///  回传当前操作是注销还还是登录
            /// </summary>
            private int _operation;

            public int Operation
            {
                get { return _operation; }
                set { _operation = value; }
            }

        }

        /// <summary>
        /// 开始构造第三方登录成功但是未注册时的数据
        /// </summary>
        public class ThirdPartyFResultNeedBind
        {
            /// <summary>
            /// 是否需要绑定
            /// </summary>
            private int _isNeed;

            public int IsNeed
            {
                get { return _isNeed; }
                set { _isNeed = value; }
            }



        }

        /// <summary>
        /// 开始构造第三方登录成功而且已注册时的数据
        /// </summary>
        public class ThirdPartyFResultBind
        {


            /// <summary>
            /// 是否绑定
            /// </summary>
            private int _isNeed;

            public int IsNeed
            {
                get { return _isNeed; }
                set { _isNeed = value; }
            }


            private string _iD;
            /// <summary>
            /// 用户编号
            /// </summary>
            public string ID
            {
                get { return _iD; }
                set { _iD = value; }
            }

            private string _uname;
            /// <summary>
            /// 用户名 
            /// </summary>
            public string Uname
            {
                get { return _uname; }
                set { _uname = value; }
            }
            private string _nickName;
            /// <summary>
            /// 昵称
            /// </summary>
            public string NickName
            {
                get { return _nickName; }
                set { _nickName = value; }
            }
            private string _photo;
            /// <summary>
            /// 头像
            /// </summary>
            public string Photo
            {
                get { return _photo; }
                set { _photo = value; }
            }
            private string _phone;
            /// <summary>
            /// 电话
            /// </summary>
            public string Phone
            {
                get { return _phone; }
                set { _phone = value; }
            }
            private string _qQ_Token;

            public string QQ_Token
            {
                get { return _qQ_Token; }
                set { _qQ_Token = value; }
            }
            private DateTime? _qQ_Token_LastTime;

            public DateTime? QQ_Token_LastTime
            {
                get { return _qQ_Token_LastTime; }
                set { _qQ_Token_LastTime = value; }
            }
            private string _weChat_Token;

            public string WeChat_Token
            {
                get { return _weChat_Token; }
                set { _weChat_Token = value; }
            }

            private DateTime? _weChat_Token_LastTime;

            public DateTime? WeChat_Token_LastTime
            {
                get { return _weChat_Token_LastTime; }
                set { _weChat_Token_LastTime = value; }
            }
            //private string _signature;

            //public string Signature
            //{
            //    get { return _signature; }
            //    set { _signature = value; }
            //}


        }

        /// <summary>
        /// 用户信息
        /// </summary>
        public class CF_User
        {

            /// <summary>
            /// 用户唯一表示
            /// </summary>
            public int UserID { get; set; }
            /// <summary>
            /// 账号
            /// </summary>
            public string LoginName { get; set; }
            /// <summary>
            /// 密码
            /// </summary>
            public string LoginPassword { get; set; }
            /// <summary>
            /// 角色
            /// </summary>
            public int DeptID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int SupplierID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int EmployeeID { get; set; }
            /// <summary>
            /// 真实姓名
            /// </summary>
            public string RealName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 性别
            /// </summary>
            public int Sex { get; set; }
            /// <summary>
            /// 手机号
            /// </summary>
            public string Phone { get; set; }
            /// <summary>
            /// 传真
            /// </summary>
            public string Fax { get; set; }
            /// <summary>
            /// 邮箱
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// 身份证
            /// </summary>
            public string IDCard { get; set; }
            /// <summary>
            /// 昵称
            /// </summary>
            public string NickName { get; set; }
            /// <summary>
            /// 地址
            /// </summary>
            public string Address { get; set; }
            /// <summary>
            /// 最后登陆时间
            /// </summary>
            public DateTime LastLoginTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int CreateUserID { get; set; }
            /// <summary>
            /// 用户添加时间
            /// </summary>
            public int CreateDate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int ModifyUserID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int ModifyDate { get; set; }
            /// <summary>
            /// 用户唯一表示
            /// </summary>
            public string RecordStatus { get; set; }
            /// <summary>
            /// 微信 凭证
            /// </summary>
            public string WeChatAccess_Token { get; set; }
            /// <summary>
            /// 微信登陆 唯一标示
            /// </summary>
            public string WeChatOpenid { get; set; }
            /// <summary>
            /// 头像
            /// </summary>
            public int Headimgurl { get; set; }
            /// <summary>
            /// 1 登陆 2 注销
            /// </summary>
            public string Operation { get; set; }
            /// <summary>
            /// QQ 凭证
            /// </summary>
            public string QQAccess_Token { get; set; }
            /// <summary>
            /// QQ登陆 唯一标示
            /// </summary>
            public string QQOpenid { get; set; }
        }

        #endregion
        #region  加密
        public string GetSignString(Dictionary<string, string> dic)
        {
            //连接字段
            var sign = dic.Aggregate("", (current, d) => current + (d.Key + "=" + d.Value + "&"));
            sign = sign.Substring(0, sign.Length - 1);
            sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sign, "MD5").ToLower();

            return sign;
        }

        public string GetSignString(string dic)
        {
            //连接字段
            string key = "D4F##4T556!RTG@" + dic + "54R434F@556$5TR*~";
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5").ToLower();

            return sign;
        }

        #endregion
        //#region 获取用户信息
        //public class UserNameModel
        //{
        //    public object UserName { get; set; }
        //}
        //#endregion
    }
}