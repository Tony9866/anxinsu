﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Data.Common;

namespace LigerRM.Common
{
    public class JSONHelper
    {
        /// <summary>
        /// 类对像转换成json格式
        /// </summary> 
        /// <returns></returns>
        public static string ToJson(object t)
        {
            return new JavaScriptSerializer().Serialize(t);
        }

        /// <summary>
        /// json格式转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T FromJson<T>(string strJson) where T : class
        {
            return new JavaScriptSerializer().Deserialize<T>(strJson);
        }

         

        /// <summary>
        /// 获取树格式对象的JSON
        /// </summary>
        /// <param name="commandText">commandText</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param>
        /// <returns></returns>
        public static string GetArrayJSON(string commandText, string id, string pid)
        {
            var o = ArrayToTreeData(commandText, id, pid);
            return ToJson(o);
        }
        /// <summary>
        /// 获取树格式对象的JSON
        /// </summary>
        /// <param name="command">command</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param>
        /// <returns></returns>
        public static string GetArrayJSON(DbCommand command, string id, string pid)
        {
            var o = ArrayToTreeData(command, id, pid);
            return ToJson(o);
        }

        /// <summary>
        /// 获取树格式对象的JSON
        /// </summary>
        /// <param name="list">线性数据</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param>
        /// <returns></returns>
        public static string GetArrayJSON(IList<Hashtable> list, string id, string pid)
        {
            var o = ArrayToTreeData(list, id, pid);
            return ToJson(o);
        }

        /// <summary>
        /// 获取树格式对象
        /// </summary>
        /// <param name="command">command</param>
        /// <param name="id">id的字段名</param>
        /// <param name="pid">pid的字段名</param>
        /// <returns></returns>
        public static object ArrayToTreeData(DbCommand command, string id, string pid)
        {
            var reader = DbHelper.Db.ExecuteReader(command);
            var list = DbReaderToHash(reader);
            return JSONHelper.ArrayToTreeData(list, id, pid);
        }

        /// <summary>
        /// 获取树格式对象
        /// </summary>
        /// <param name="commandText">sql</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param> 
        /// <returns></returns>
        public static object ArrayToTreeData(string commandText, string id, string pid)
        {
            var reader = DbHelper.Db.ExecuteReader(commandText);
            var list = DbReaderToHash(reader);
            return JSONHelper.ArrayToTreeData(list, id, pid);
        }
         
        /// <summary>
        /// 获取树格式对象
        /// </summary>
        /// <param name="list">线性数据</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param>
        /// <returns></returns>
        public static object ArrayToTreeData(IList<Hashtable> list, string id, string pid)
        {
            var h = new Hashtable(); //数据索引 
            var r = new List<Hashtable>(); //数据池,要返回的 
            foreach (var item in list)
            {
                if (!item.ContainsKey(id)) continue;
                h[item[id].ToString()] = item;
            }
            foreach (var item in list)
            {
                if (!item.ContainsKey(id)) continue;
                if (!item.ContainsKey(pid) || item[pid] == null || !h.ContainsKey(item[pid].ToString()))
                {
                    r.Add(item);
                }
                else
                {
                    var pitem = h[item[pid].ToString()] as Hashtable;
                    if (!pitem.ContainsKey("children"))
                        pitem["children"] = new List<Hashtable>();
                    var children = pitem["children"] as List<Hashtable>;
                    children.Add(item);
                }
            }
            return r;
        }


        /// <summary>
        /// 执行SQL 返回json
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string ExecuteCommandToJSON(DbCommand command)
        {
            var o = ExecuteReaderToHash(command);
            return ToJson(o);
        }

        /// <summary>
        /// 执行SQL 返回json
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static string ExecuteCommandToJSON(string commandText)
        {
            var o = ExecuteReaderToHash(commandText);
            return ToJson(o);
        }

        /// <summary>
        /// 将db reader转换为Hashtable列表
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static List<Hashtable> ExecuteReaderToHash(string commandText)
        {
            var reader = DbHelper.Db.ExecuteReader(commandText);
            return DbReaderToHash(reader);
        }

        /// <summary>
        /// 将db reader转换为Hashtable列表
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static List<Hashtable> ExecuteReaderToHash(DbCommand command)
        {
            var reader = DbHelper.Db.ExecuteReader(command);
            return DbReaderToHash(reader);
        }

        /// <summary>
        /// 将db reader转换为Hashtable列表
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<Hashtable> DbReaderToHash(IDataReader reader)
        {
            var list = new List<Hashtable>();
            while (reader.Read())
            {
                var item = new Hashtable();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var name = reader.GetName(i);
                    var value = reader[i];
                    item[name] = value;
                }
                list.Add(item);
            }
            return list;
        }
    }
}
