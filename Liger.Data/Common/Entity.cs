using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using Liger.Data.Resources;

namespace Liger.Data
{
    /// <summary>
    /// 实体信息,可序列号
    /// </summary>
    [Serializable]
    public class Entity  
    { 
        /// <summary>
        /// 表名/视图名
        /// </summary>
        private string entityEame;

        /// <summary>
        /// 字段别名
        /// </summary>
        private string aliasName;

        /// <summary>
        /// 修改的字段集合
        /// </summary>
        private List<Field> changedFields = new List<Field>();

        /// <summary>
        /// 是否开始修改
        /// </summary>
        private bool isAttached;

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Entity() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entityEame">表名/视图名</param>
        public Entity(string entityEame)
            :this(entityEame,null)
        { 
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entityEame">表名/视图名</param>
        public Entity(string entityEame, string aliasName)
        {
            this.entityEame = entityEame;
            this.aliasName = aliasName;
        } 

        #endregion

        #region 修改属性

        /// <summary>
        /// 将实体置为修改状态
        /// 后面改变的属性将会记录起来,并在Update的时候只更新记录的字段
        /// </summary>
        public void Attach()
        {
            this.isAttached = true;
        }


        /// <summary>
        /// 将实体置为非修改状态
        /// 后面改变的属性将不会记录起来
        /// </summary>
        public void DeAttach()
        {
            this.isAttached = false;
        }

        /// <summary>
        /// 记录 字段修改  
        /// </summary>
        /// <param name="field"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void OnPropertyValueChange(Field field, object oldValue, object newValue)
        {
            if (oldValue != newValue && this.isAttached)
            {
                lock (this.changedFields)
                {
                    if (!this.changedFields.Contains(field))
                        this.changedFields.Add(field);
                }
            }
        }
        

        /// <summary>
        /// 清除修改记录
        /// </summary>
        public void ClearModifyFields()
        {
            changedFields.Clear();
        }

        /// <summary>
        /// 返回修改过的字段列表
        /// </summary>
        public List<Field> GetChangedFields()
        {
            return changedFields;
        }
        #endregion

        #region 设置属性、访问属性 
        /// <summary>
        /// 获取属性的值，默认使用反射的方式，建议重载
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public virtual object GetValue(string propertyName)
        {
            var p = this.GetType().GetProperty(propertyName);
            if (p != null)
                return p.GetValue(this, null);
            return null;
        }
        /// <summary>
        /// 设置属性的值，默认使用反射的方式，建议重载
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        public virtual void SetValue(string propertyName, object value)
        {
            var p = this.GetType().GetProperty(propertyName);
            if (p != null)
                p.SetValue(this, value, null);
        }  
        #endregion

        #region 获取字段、值、主键、标示列

        /// <summary>
        /// 获取全部字段
        /// </summary>
        /// <returns></returns>
        public virtual Field[] GetFields() { return null; }

        /// <summary>
        /// 获取全部值
        /// </summary>
        /// <returns></returns>
        public virtual object[] GetValues() { return null; }

        /// <summary>
        /// 获取主键(可能有多个)
        /// </summary>
        /// <returns></returns>
        public virtual Field[] GetPrimaryKeyFields() { return null; }


        /// <summary>
        /// 获取标识列
        /// </summary>
        public virtual Field GetIdentityField()
        {
            return null;
        }
        #endregion
         
        #region 是否只读、获取表名
        /// <summary>
        /// 是否只读
        /// </summary>
        public virtual bool IsReadOnly()
        {
            return false;
        }

        /// <summary>
        /// 获取表名/视图 名
        /// </summary>
        public string GetName()
        {
            return entityEame;
        }

        /// <summary>
        /// 别名
        /// </summary>
        /// <returns></returns>
        public string GetAliasName()
        {
            return aliasName; 
        }
        /// <summary>
        /// 设置别名
        /// </summary>
        /// <param name="aliasName"></param>
        public void SetAliasName(string aliasName)
        {
            this.aliasName = aliasName;
        }
        #endregion
         
       
    }
}