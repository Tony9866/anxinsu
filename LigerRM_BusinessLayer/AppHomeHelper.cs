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

        //获得房屋分类列表
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
                //11111
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

        //获得头部信息
        public string GetMod(long BannerId)
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT *  FROM AppHome_Banner WHERE BannerId='").Append(BannerId).Append("'");
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
                if (count > 1)
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

        //头部属性
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

        //获取各省列表
        public List<Public_Provinces> GetListProvince() 
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * ");
                str.Append("FROM Public_Provinces ");
                List<Public_Provinces> List = GetList<Public_Provinces>(str.ToString());
                return List;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        //获取城市列表
        public string GetListCity(string provinceid) 
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * ");
                str.Append("FROM Public_City where provinceid= " + provinceid);
                List<Public_City> List = GetList<Public_City>(str.ToString());
                if (List != null)
                {
                    Return.Code = "0";
                    Return.Data = List;
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

        /// <summary>
        /// 获取排序编号，通过cityId查找是否存在
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string GetSortId(string cityId ) 
        {
            ReturnJosn Return = new ReturnJosn();
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT * ");
                str.Append("FROM AppHome_SpecialInfo where cityId= " + cityId);
                List<AppHome_SpecialInfo> list = GetList<AppHome_SpecialInfo>(str.ToString());
                if (list.Count == 0)
                {
                    //如果为空值需要先new一个实例给list 然后再通过mod赋值进来。
                    list = new List<AppHome_SpecialInfo>();
                    AppHome_SpecialInfo mod=new AppHome_SpecialInfo();
                    mod.sortId = 1;
                    list.Add(mod);
                    Return.Code = "0";
                    Return.Data = list; 
                }
                //if (list != null)
                //{
                //    Return.Code = "0";
                //    Return.Data = list;
                //}
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

    }








    //房屋分类字段属性读写
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

    //省表中的属性读写
    public class Public_Provinces
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 省编号
        /// </summary>
        public string provinceid { get; set; }

        /// <summary>
        /// 省名称
        /// </summary>
        public string province { get; set; }
    }

    //城市表中获取所需数据
    public class Public_City
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public string cityId { get; set; }

        /// <summary>
        /// 省编号
        /// </summary>
        public string provinceid { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string city { get; set; }
    }

    //获取特色房源中的排序编号
    public class AppHome_SpecialInfo {

        /// <summary>
        /// 区域排序
        /// </summary>
        public int sortId {get; set;}

        /// <summary>
        /// 城市编号
        /// </summary>
        public string cityId { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// 排序最大值
        ///// </summary>
        //public int maxSortId { get; set; }
    }

}
