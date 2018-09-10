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
	/// 实体类CF_Department
	/// </summary>
	[Serializable]
	public class CFDepartment : Entity 
	{ 
		 public CFDepartment() 
            : base("CF_Department") 
        { 

        }


		#region Model
		private int _DeptID;
		private string _DeptName;
		private string _DeptDesc;
		private int? _DeptParentID;
		private int? _CreateUserID;
		private DateTime? _CreateDate;
		private int? _ModifyUserID;
		private DateTime? _ModifyDate;
		private string _RecordStatus;
	 
		/// <summary>
		/// 
		/// </summary>
		public int DeptID
		{
			get{ return _DeptID; }
			set
			{
				this.OnPropertyValueChange(_.DeptID,_DeptID,value);
				this._DeptID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptName
		{
			get{ return _DeptName; }
			set
			{
				this.OnPropertyValueChange(_.DeptName,_DeptName,value);
				this._DeptName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptDesc
		{
			get{ return _DeptDesc; }
			set
			{
				this.OnPropertyValueChange(_.DeptDesc,_DeptDesc,value);
				this._DeptDesc = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DeptParentID
		{
			get{ return _DeptParentID; }
			set
			{
				this.OnPropertyValueChange(_.DeptParentID,_DeptParentID,value);
				this._DeptParentID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateUserID
		{
			get{ return _CreateUserID; }
			set
			{
				this.OnPropertyValueChange(_.CreateUserID,_CreateUserID,value);
				this._CreateUserID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			get{ return _CreateDate; }
			set
			{
				this.OnPropertyValueChange(_.CreateDate,_CreateDate,value);
				this._CreateDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ModifyUserID
		{
			get{ return _ModifyUserID; }
			set
			{
				this.OnPropertyValueChange(_.ModifyUserID,_ModifyUserID,value);
				this._ModifyUserID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyDate
		{
			get{ return _ModifyDate; }
			set
			{
				this.OnPropertyValueChange(_.ModifyDate,_ModifyDate,value);
				this._ModifyDate = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordStatus
		{
			get{ return _RecordStatus; }
			set
			{
				this.OnPropertyValueChange(_.RecordStatus,_RecordStatus,value);
				this._RecordStatus = value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 获取实体中的标识列
		/// </summary>
		public override Field GetIdentityField()
		{
			return _.DeptID;
		}
		/// <summary>
		/// 获取实体中的主键列
		/// </summary>
		public override Field[] GetPrimaryKeyFields()
		{
			return new Field[] {
				_.DeptID			};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.DeptID,
				_.DeptName,
				_.DeptDesc,
				_.DeptParentID,
				_.CreateUserID,
				_.CreateDate,
				_.ModifyUserID,
				_.ModifyDate,
				_.RecordStatus
			};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				_DeptID,
				_DeptName,
				_DeptDesc,
				_DeptParentID,
				_CreateUserID,
				_CreateDate,
				_ModifyUserID,
				_ModifyDate,
				_RecordStatus
			};
		} 
		/// <summary>
		/// 设置字段值
		/// </summary>
		public override void SetValue(string fieldName, object value)
        {
            switch (fieldName)
            { 
				case "DeptID":
                    this._DeptID = DataHelper.ConvertValue<int>(value);
                    break; 
				case "DeptName":
                    this._DeptName = DataHelper.ConvertValue<string>(value);
                    break; 
				case "DeptDesc":
                    this._DeptDesc = DataHelper.ConvertValue<string>(value);
                    break; 
				case "DeptParentID":
                    this._DeptParentID = DataHelper.ConvertValue<int?>(value);
                    break; 
				case "CreateUserID":
                    this._CreateUserID = DataHelper.ConvertValue<int?>(value);
                    break; 
				case "CreateDate":
                    this._CreateDate = DataHelper.ConvertValue<DateTime?>(value);
                    break; 
				case "ModifyUserID":
                    this._ModifyUserID = DataHelper.ConvertValue<int?>(value);
                    break; 
				case "ModifyDate":
                    this._ModifyDate = DataHelper.ConvertValue<DateTime?>(value);
                    break; 
				case "RecordStatus":
                    this._RecordStatus = DataHelper.ConvertValue<string>(value);
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
				case "DeptID":
                    return this._DeptID; 
				case "DeptName":
                    return this._DeptName; 
				case "DeptDesc":
                    return this._DeptDesc; 
				case "DeptParentID":
                    return this._DeptParentID; 
				case "CreateUserID":
                    return this._CreateUserID; 
				case "CreateDate":
                    return this._CreateDate; 
				case "ModifyUserID":
                    return this._ModifyUserID; 
				case "ModifyDate":
                    return this._ModifyDate; 
				case "RecordStatus":
                    return this._RecordStatus; 
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
			public readonly static Field All = new Field("*","CF_Department");
 
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DeptID = new Field("DeptID","CF_Department","DeptID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DeptName = new Field("DeptName","CF_Department","DeptName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DeptDesc = new Field("DeptDesc","CF_Department","DeptDesc");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DeptParentID = new Field("DeptParentID","CF_Department","DeptParentID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CreateUserID = new Field("CreateUserID","CF_Department","CreateUserID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CreateDate = new Field("CreateDate","CF_Department","CreateDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModifyUserID = new Field("ModifyUserID","CF_Department","ModifyUserID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModifyDate = new Field("ModifyDate","CF_Department","ModifyDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RecordStatus = new Field("RecordStatus","CF_Department","RecordStatus");
		}
		#endregion

 
	}
}

