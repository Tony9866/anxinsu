using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using LigerRM.Common;
using Liger.Common.Extensions;

namespace LigerRM.Service.Setting
{
    public class MethodSetting
    {
        public string name { get; set; } 
        public string type { get; set; }
    }


    public class MethodSettingHelper
    {
        private static readonly string XMLPATH = HttpContext.Current.Server.MapPath("~/Config/adminmethod.xml");

        public static string GetSettingsJSON()
        {
            return JSONHelper.ToJson(GetSettings());
        }

        private static List<MethodSetting> Settings;

        public static List<MethodSetting> GetSettings()
        {
            var doc = new XmlDocument();
            doc.Load(XMLPATH);
            var nodes = doc.SelectNodes("/settings/method");
            var settings = new List<MethodSetting>();
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["name"] == null)
                    continue;
                var view = new MethodSetting()
                {
                    name = node.Attributes["name"].InnerText,
                    type = node.Attributes["type"].InnerText
                };
             
                settings.Add(view);
            }
            Settings = settings;
            return settings;
        }

        public static bool Exist(string type, string method)
        {
            if(Settings == null)
                return GetSettings().Any(c => c.type == type && c.name == method);
            else
                return Settings.Any(c => c.type == type && c.name == method);
        }

        public static void SetSettings(List<MethodSetting> settings)
        {
            var doc = new XmlDocument();
            doc.Load(XMLPATH);
            var root = doc.SelectSingleNode("/settings");

            root.RemoveAll();

            foreach (var setting in settings)
            {
                var ele = doc.CreateElement("method");
                ele.SetAttribute("name", setting.name);
                ele.SetAttribute("type", setting.type);
                 
                root.AppendChild(ele);
            }

            doc.Save(XMLPATH);
        }
    }
}