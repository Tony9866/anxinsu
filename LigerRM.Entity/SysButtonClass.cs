﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。  
//     技术支持：稻米(www.cnblogs.com/leoxie2011)
//     对此文件的更改可能会导致不正确的行为
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using Liger.Common;
using Liger.Data;

namespace Liger.Model
{

	/// <summary>
	/// 实体类Sys_ButtonClass
	/// </summary>
	[Serializable]
	public class SysButtonClass : Entity 
	{ 
		 public SysButtonClass() 
            : base("Sys_ButtonClass") 
        { 

        }


		#region Model
		private int _BtnClassID;
		private string _BtnClass;
		private string _BtnClassName;
	 
		/// <summary>
		/// 
		/// </summary>
		public int BtnClassID
		{
			get{ return _BtnClassID; }
			set
			{
				this.OnPropertyValueChange(_.BtnClassID,_BtnClassID,value);
				this._BtnClassID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BtnClass
		{
			get{ return _BtnClass; }
			set
			{
				this.OnPropertyValueChange(_.BtnClass,_BtnClass,value);
				this._BtnClass = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BtnClassName
		{
			get{ return _BtnClassName; }
			set
			{
				this.OnPropertyValueChange(_.BtnClassName,_BtnClassName,value);
				this._BtnClassName = value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 获取实体中的标识列
		/// </summary>
		public override Field GetIdentityField()
		{
			return _.BtnClassID;
		}
		/// <summary>
		/// 获取实体中的主键列
		/// </summary>
		public override Field[] GetPrimaryKeyFields()
		{
			return new Field[] {
				_.BtnClassID			};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.BtnClassID,
				_.BtnClass,
				_.BtnClassName
			};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				_BtnClassID,
				_BtnClass,
				_BtnClassName
			};
		} 
		/// <summary>
		/// 设置字段值
		/// </summary>
		public override void SetValue(string fieldName, object value)
        {
            switch (fieldName)
            { 
				case "BtnClassID":
                    this._BtnClassID = DataHelper.ConvertValue<int>(value);
                    break; 
				case "BtnClass":
                    this._BtnClass = DataHelper.ConvertValue<string>(value);
                    break; 
				case "BtnClassName":
                    this._BtnClassName = DataHelper.ConvertValue<string>(value);
                    break; 
            }
        }
		/// <summary>
		/// 获取字段值
		/// </summary>
        public override object GetValue(string fieldName)
        {
            switch (fieldName)
            { 
				case "BtnClassID":
                    return this._BtnClassID; 
				case "BtnClass":
                    return this._BtnClass; 
				case "BtnClassName":
                    return this._BtnClassName; 
				default :
                    return null;
            } 
        }



		#endregion

		#region _Field
		/// <summary>
		/// 字段信息
		/// </summary>
		public class _
		{
			/// <summary>
			/// * 
			/// </summary>
			public readonly static Field All = new Field("*","Sys_ButtonClass");
 
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field BtnClassID = new Field("BtnClassID","Sys_ButtonClass","BtnClassID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field BtnClass = new Field("BtnClass","Sys_ButtonClass","BtnClass");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field BtnClassName = new Field("BtnClassName","Sys_ButtonClass","BtnClassName");
		}
		#endregion

 
	}
}

