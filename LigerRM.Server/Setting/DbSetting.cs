using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Xml;
using LigerRM.Common;
using Liger.Common.Extensions;

namespace LigerRM.Service.Setting
{
    public class DbColumn
    {
        public string name { get; set; }
        public string display { get; set; }
        public string type { get; set; }
    }

    public class DbView
    {
        public string name { get; set; } 
        public string display { get; set; } 
        public List<DbColumn> columns { get; set; } 
    }

    public class DbSettingHelper
    {
        private static readonly string XMLPATH = HttpContext.Current.Server.MapPath("~/Config/dbsetting.xml");

        public static string GetSettingsJSON()
        {
            return JSONHelper.ToJson(GetSettings());
        } 

        public static List<DbView> GetSettings()
        {
            var doc = new XmlDocument();
            doc.Load(XMLPATH);
            var nodes = doc.SelectNodes("/settings/view");
            var settings = new List<DbView>();
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["name"] == null)
                    continue;
                var view = new DbView()
                {
                    name = node.Attributes["name"].InnerText,
                    display = node.Attributes["display"].InnerText
                };
                if (view.display.IsNullOrEmpty())
                    view.display = view.name;

                var columns = new List<DbColumn>();
                var columnNodes = node.ChildNodes;
                foreach (XmlNode columnNode in columnNodes)
                {
                    var column = new DbColumn()
                    {
                        name = columnNode.Attributes["name"].InnerText,
                        display = columnNode.Attributes["display"].InnerText,
                        type = columnNode.Attributes["type"].InnerText
                    };
                    if (column.display.IsNullOrEmpty())
                        column.display = column.name;
                    if (column.type.IsNullOrEmpty())
                        column.type = "text";
                    columns.Add(column);
                }
                view.columns = columns;

                settings.Add(view);
            }
            return settings;
        }

    }
}