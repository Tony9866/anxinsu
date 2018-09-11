using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignetInternet_BusinessLayer.Models.AppHome;

namespace SignetInternet_BusinessLayer
{
    public class ApiLayer : BaseHelper
    {

        #region  接口基础返回类

        //获取banner 头里的3张图片和文字描述
        public List<AppHome_Banner> GetBanner()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT *  FROM AppHome_Banner");
                List<AppHome_Banner> List = GetList<AppHome_Banner>(str.ToString());
                return List;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //获取特色房源里的 3个class 来展示图片跟文字信息。
        public List<EspeciallyModel> GetEspecially()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("SELECT *  FROM AppHome_SpecialInfo");
                List<EspeciallyModel> List = GetList<EspeciallyModel>(str.ToString());
                return List;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //获取热门推荐里的6个class来展示图片跟文字信息。
        public List<AppHome_Recommend> GetRecommend()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("select * from appHome_Recommend");
                List<AppHome_Recommend> List = GetList<AppHome_Recommend>(str.ToString());
                return List;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        //获取热门推荐里底部3个content_Name公司信息展示
        public List<appHome_aboutUs> GetaboutUs() 
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("select * from appHome_aboutUs");
                List<appHome_aboutUs> List = GetList<appHome_aboutUs>(str.ToString());
                return List;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
        //层末分类显示
        public List<appHouse_Class> GethouseClass() 
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("select imageUrl, class_name, lvlId from appHouse_Class");
                List<appHouse_Class> List = GetList<appHouse_Class>(str.ToString());
                return List;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
        //底部标签显示
        public List<footerLabel> GetfooterLabel() 
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("select * from appHome_footerLabel");
                List<footerLabel> List = GetList<footerLabel>(str.ToString());
                return List;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        #endregion


    }
}
