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
	/// 实体类Products
	/// </summary>
	[Serializable]
	public class Products : Entity 
	{ 
		 public Products() 
            : base("Products") 
        { 

        }


		#region Model
		private int _ProductID;
		private string _ProductName;
		private int? _SupplierID;
		private int? _CategoryID;
		private string _QuantityPerUnit;
		private decimal? _UnitPrice;
		private int? _UnitsInStock;
		private int? _UnitsOnOrder;
		private int? _ReorderLevel;
		private bool _Discontinued;
		private string _EAN13;
	 
		/// <summary>
		/// Number automatically assigned to new product.
		/// </summary>
		public int ProductID
		{
			get{ return _ProductID; }
			set
			{
				this.OnPropertyValueChange(_.ProductID,_ProductID,value);
				this._ProductID = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			get{ return _ProductName; }
			set
			{
				this.OnPropertyValueChange(_.ProductName,_ProductName,value);
				this._ProductName = value;
			}
		}
		/// <summary>
		/// Same entry as in Suppliers table.
		/// </summary>
		public int? SupplierID
		{
			get{ return _SupplierID; }
			set
			{
				this.OnPropertyValueChange(_.SupplierID,_SupplierID,value);
				this._SupplierID = value;
			}
		}
		/// <summary>
		/// Same entry as in Categories table.
		/// </summary>
		public int? CategoryID
		{
			get{ return _CategoryID; }
			set
			{
				this.OnPropertyValueChange(_.CategoryID,_CategoryID,value);
				this._CategoryID = value;
			}
		}
		/// <summary>
		/// (e.g., 24-count case, 1-liter bottle).
		/// </summary>
		public string QuantityPerUnit
		{
			get{ return _QuantityPerUnit; }
			set
			{
				this.OnPropertyValueChange(_.QuantityPerUnit,_QuantityPerUnit,value);
				this._QuantityPerUnit = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitPrice
		{
			get{ return _UnitPrice; }
			set
			{
				this.OnPropertyValueChange(_.UnitPrice,_UnitPrice,value);
				this._UnitPrice = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UnitsInStock
		{
			get{ return _UnitsInStock; }
			set
			{
				this.OnPropertyValueChange(_.UnitsInStock,_UnitsInStock,value);
				this._UnitsInStock = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UnitsOnOrder
		{
			get{ return _UnitsOnOrder; }
			set
			{
				this.OnPropertyValueChange(_.UnitsOnOrder,_UnitsOnOrder,value);
				this._UnitsOnOrder = value;
			}
		}
		/// <summary>
		/// Minimum units to maintain in stock.
		/// </summary>
		public int? ReorderLevel
		{
			get{ return _ReorderLevel; }
			set
			{
				this.OnPropertyValueChange(_.ReorderLevel,_ReorderLevel,value);
				this._ReorderLevel = value;
			}
		}
		/// <summary>
		/// Yes means item is no longer available.
		/// </summary>
		public bool Discontinued
		{
			get{ return _Discontinued; }
			set
			{
				this.OnPropertyValueChange(_.Discontinued,_Discontinued,value);
				this._Discontinued = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EAN13
		{
			get{ return _EAN13; }
			set
			{
				this.OnPropertyValueChange(_.EAN13,_EAN13,value);
				this._EAN13 = value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 获取实体中的标识列
		/// </summary>
		public override Field GetIdentityField()
		{
			return _.ProductID;
		}
		/// <summary>
		/// 获取实体中的主键列
		/// </summary>
		public override Field[] GetPrimaryKeyFields()
		{
			return new Field[] {
				_.ProductID			};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.ProductID,
				_.ProductName,
				_.SupplierID,
				_.CategoryID,
				_.QuantityPerUnit,
				_.UnitPrice,
				_.UnitsInStock,
				_.UnitsOnOrder,
				_.ReorderLevel,
				_.Discontinued,
				_.EAN13
			};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				_ProductID,
				_ProductName,
				_SupplierID,
				_CategoryID,
				_QuantityPerUnit,
				_UnitPrice,
				_UnitsInStock,
				_UnitsOnOrder,
				_ReorderLevel,
				_Discontinued,
				_EAN13
			};
		} 
		/// <summary>
		/// 设置字段值
		/// </summary>
		public override void SetValue(string fieldName, object value)
        {
            switch (fieldName)
            { 
				case "ProductID":
                    this._ProductID = DataHelper.ConvertValue<int>(value);
                    break; 
				case "ProductName":
                    this._ProductName = DataHelper.ConvertValue<string>(value);
                    break; 
				case "SupplierID":
                    this._SupplierID = DataHelper.ConvertValue<int?>(value);
                    break; 
				case "CategoryID":
                    this._CategoryID = DataHelper.ConvertValue<int?>(value);
                    break; 
				case "QuantityPerUnit":
                    this._QuantityPerUnit = DataHelper.ConvertValue<string>(value);
                    break; 
				case "UnitPrice":
                    this._UnitPrice = DataHelper.ConvertValue<decimal?>(value);
                    break; 
				case "UnitsInStock":
                    this._UnitsInStock = DataHelper.ConvertValue<int?>(value);
                    break; 
				case "UnitsOnOrder":
                    this._UnitsOnOrder = DataHelper.ConvertValue<int?>(value);
                    break; 
				case "ReorderLevel":
                    this._ReorderLevel = DataHelper.ConvertValue<int?>(value);
                    break; 
				case "Discontinued":
                    this._Discontinued = DataHelper.ConvertValue<bool>(value);
                    break; 
				case "EAN13":
                    this._EAN13 = DataHelper.ConvertValue<string>(value);
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
				case "ProductID":
                    return this._ProductID; 
				case "ProductName":
                    return this._ProductName; 
				case "SupplierID":
                    return this._SupplierID; 
				case "CategoryID":
                    return this._CategoryID; 
				case "QuantityPerUnit":
                    return this._QuantityPerUnit; 
				case "UnitPrice":
                    return this._UnitPrice; 
				case "UnitsInStock":
                    return this._UnitsInStock; 
				case "UnitsOnOrder":
                    return this._UnitsOnOrder; 
				case "ReorderLevel":
                    return this._ReorderLevel; 
				case "Discontinued":
                    return this._Discontinued; 
				case "EAN13":
                    return this._EAN13; 
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
			public readonly static Field All = new Field("*","Products");
 
			/// <summary>
			/// Number automatically assigned to new product.
			/// </summary>
			public readonly static Field ProductID = new Field("ProductID","Products","ProductID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProductName = new Field("ProductName","Products","ProductName");
			/// <summary>
			/// Same entry as in Suppliers table.
			/// </summary>
			public readonly static Field SupplierID = new Field("SupplierID","Products","SupplierID");
			/// <summary>
			/// Same entry as in Categories table.
			/// </summary>
			public readonly static Field CategoryID = new Field("CategoryID","Products","CategoryID");
			/// <summary>
			/// (e.g., 24-count case, 1-liter bottle).
			/// </summary>
			public readonly static Field QuantityPerUnit = new Field("QuantityPerUnit","Products","QuantityPerUnit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UnitPrice = new Field("UnitPrice","Products","UnitPrice");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UnitsInStock = new Field("UnitsInStock","Products","UnitsInStock");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UnitsOnOrder = new Field("UnitsOnOrder","Products","UnitsOnOrder");
			/// <summary>
			/// Minimum units to maintain in stock.
			/// </summary>
			public readonly static Field ReorderLevel = new Field("ReorderLevel","Products","ReorderLevel");
			/// <summary>
			/// Yes means item is no longer available.
			/// </summary>
			public readonly static Field Discontinued = new Field("Discontinued","Products","Discontinued");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EAN13 = new Field("EAN13","Products","EAN13");
		}
		#endregion

 
	}
}

