using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.Login
{
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
        /// 微信最后登录时间
        /// </summary>
        public DateTime? WeChat_Token_LastTime { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Headimgurl { get; set; }
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
        /// <summary>
        /// QQ最后登录时间
        /// </summary>
        public DateTime? QQ_Token_LastTime { get; set; }
        /// <summary>
        /// 临时手机号（作为验证用）
        /// </summary>
        public string TemporaryPhone { get; set; }

    }
}
