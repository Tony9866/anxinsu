using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LigerRM.Common;
using LigerRM.Common.ImageHelper;


namespace SignetInternet_BusinessLayer
{
    public class AppHomeHelper : BaseHelper
    {


        public List<AppHouse_Class> GetListClass()
        {
            //ceshi yixai 
            try
            {
                string str = "SELECT *  FROM appHouse_Class ";
                List<AppHouse_Class> List = GetList<AppHouse_Class>(str);
                return List;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region  Banner
        public string SetBanner(string data, int UserId)
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                AppHome_Banner Mod = Newtonsoft.Json.JsonConvert.DeserializeObject<AppHome_Banner>(data);
                Mod.AddTime = DateTime.Now;
                
                //UserId = covert.tostring(Session["RentNo"]);
                Mod.AddUser = UserId;
                Mod.ImageUrl = new ImageHelper().Base64Decode(Mod.ImageUrl);
                StringBuilder str = new StringBuilder();
                if (Mod.BannerId > 0)
                {
                    AppHome_Banner DBMod = GetModel<AppHome_Banner>("SELECT *  FROM AppHome_Banner WHERE BannerId=" + Mod.BannerId);
                    if (DBMod != null)
                    {
                        DBMod.BannerType = Mod.BannerType;
                        DBMod.Describe = Mod.Describe;
                        if (Mod.ImageUrl != "") DBMod.ImageUrl = Mod.ImageUrl;
                        DBMod.innerClassId = Mod.innerClassId;
                        DBMod.innerContent = Mod.innerContent;
                        DBMod.Url = Mod.Url;
                        switch (DBMod.BannerType)
                        {
                            case 1:
                                DBMod.innerClassId = -1;
                                DBMod.innerContent = "";
                                break;
                            case 2:
                                DBMod.Url = "";
                                break;
                            case 3:
                                DBMod.Url = "";
                                DBMod.innerClassId = -1;
                                DBMod.innerContent = "";
                                break;
                        }
         
                    }
                    else
                    {
                        Return.Code = "";
                        Return.Msg = "操作失败，未能成功修改数据！！！";
                        return JSONHelper.ToJson(Return);
                    }
                    str.Append("update AppHome_Banner set  BannerType=" + DBMod.BannerType + " ,Describe='" + DBMod.Describe + "',ImageUrl='" + DBMod.ImageUrl + "',innerClassId=" + DBMod.innerClassId + ",innerContent='" + DBMod.innerContent + "',Url='" + DBMod.Url + "' where  BannerId=" + Mod.BannerId);


                }
                else
                {
                    str.Append("Insert into  AppHome_Banner VALUES(" + Mod.BannerType + ",'" + Mod.ImageUrl + "','" + Mod.Url + "','" + Mod.Describe + "'," + Mod.innerClassId + ",'" + Mod.innerContent + "','" + Mod.AddTime + "'," + Mod.AddUser + ")");
                }


                int count = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(str.ToString()));
                if (count > 0)
                {
                    Return.Code = "0";
                    Return.Msg = "操作成功！！！";
                }
                else
                {
                    Return.Code = "";
                    Return.Msg = "操作失败，未能成功插入数据！！！";
                }
                return JSONHelper.ToJson(Return);
            }
            catch (Exception ex)
            {
                Return.Code = "1";
                Return.Msg = "操作失败，出现系统异常！";
                return JSONHelper.ToJson(Return);
            }
        }

        public string GetMod(long BannerId)
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT *  FROM AppHome_Banner WHERE BannerId=").Append(BannerId);
                AppHome_Banner Mod = GetModel<AppHome_Banner>(str.ToString());
                if (Mod != null)
                {
                    Return.Code = "0";
                    Return.Data = Mod;
                }
                else
                {
                    Return.Code = "1";
                    Return.Msg = "未能找到相关数据！！！";
                }
                return JSONHelper.ToJson(Return);
            }
            catch (Exception ex)
            {
                Return.Code = "1";
                Return.Msg = "发生错误！！！";
                return JSONHelper.ToJson(Return);

            }
        }

        public string DeleteBanner(long BannerId)
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("DELETE AppHome_Banner WHERE BannerId=" + BannerId);
                int count = MySQLHelper.ExecuteNonQuery(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(str.ToString()));
                if (count > 0)
                {
                    Return.Code = "0";
                    Return.Msg = "删除成功！！！";
                }
                else
                {
                    Return.Code = "1";
                    Return.Msg = "删除失败！！！";
                }
                return JSONHelper.ToJson(Return);
            }
            catch (Exception ex)
            {
                Return.Code = "1";
                Return.Msg = "操作失败，出现系统异常！";
                return JSONHelper.ToJson(Return);
            }
        }

        public class AppHome_Banner
        {
            /// <summary>
            /// 唯一表示
            /// </summary>
            public long BannerId { get; set; }
            /// <summary>
            /// Banner类型 1外链 2 内链 3 无链接
            /// </summary>
            public int BannerType { get; set; }
            /// <summary>
            /// Banner图片
            /// </summary>
            public string ImageUrl { get; set; }
            /// <summary>
            /// 外链地址
            /// </summary>
            public string Url { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public string Describe { get; set; }
            /// <summary>
            /// 内链类型
            /// </summary>
            public int innerClassId { get; set; }
            /// <summary>
            /// 内链内容 （内链类型=1[房屋类型ID]  内链类型=2[房屋编号]）
            /// </summary>
            public string innerContent { get; set; }
            /// <summary>
            /// 添加时间
            /// </summary>
            public DateTime AddTime { get; set; }
            /// <summary>
            /// 添加人
            /// </summary>
            public int AddUser { get; set; }
        }

        #endregion

    }

    public class AppHouse_Class
    {
        /// <summary>
        /// 房屋分类ID
        /// </summary>
        public int classId { get; set; }
        /// <summary>
        /// 房屋分类名称
        /// </summary>
        public string class_Name { get; set; }

    }


}
