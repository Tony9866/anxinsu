using System;
using System.Data;
using System.Data.Common;
using Liger.Common;
using Liger.Data;

namespace Liger.Model
{
    /// <summary>
	/// RentStreet
	/// </summary>
	[Serializable]
    public class RentStreet : Entity
    {
        public RentStreet()
           : base("Rent_Street")
        {

        }

        #region Model
        private int _LSID;
        private int _LDID;
        private string _LSName;
        private string _LSDescription;
        private int? _LSMap;
        //private DateTime? _CreatedDate;
    
        private string _LDName;
        private bool _LSStatus;
        private bool _LSIsImport;

        /// <summary>
        /// 
        /// </summary>
        public int LSID
        {
            get { return _LSID; }
            set
            {
                this.OnPropertyValueChange(_.LSID, _LSID, value);
                this._LSID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int LDID
        {
            get { return _LDID; }
            set
            {
                this.OnPropertyValueChange(_.LDID, _LDID, value);
                this._LDID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LSName
        {
            get { return _LSName; }
            set
            {
                this.OnPropertyValueChange(_.LSName, _LSName, value);
                this._LSName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LDName
        {
            get { return _LDName; }
            set
            {
                this.OnPropertyValueChange(_.LDName, _LDName, value);
                this._LDName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LSDescription
        {
            get { return _LSDescription; }
            set
            {
                this.OnPropertyValueChange(_.LSDescription, _LSDescription, value);
                this._LSDescription = value;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public DateTime? CreateDate
        //{
        //    get { return _CreateDate; }
        //    set
        //    {
        //        this.OnPropertyValueChange(_.CreateDate, _CreateDate, value);
        //        this._CreateDate = value;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        public int? LSMap
        {
            get { return _LSMap; }
            set
            {
                this.OnPropertyValueChange(_.LSMap, _LSMap, value);
                this._LSMap = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool LSStatus
        {
            get { return _LSStatus; }
            set
            {
                this.OnPropertyValueChange(_.LSStatus, _LSStatus, value);
                this._LSStatus = value;
            }
        }

      
        /// <summary>
        /// 
        /// </summary>
        public bool LSIsImport
        {
            get { return _LSIsImport; }
            set
            {
                this.OnPropertyValueChange(_.LSIsImport, _LSIsImport, value);
                this._LSIsImport = value;
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.LSID;
        }
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
                _.LSID            };
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.LSID,
                _.LDID,
                _.LSName,
                _.LSDescription,
                _.LSMap,
                //_.CreateDate,
              
                _.LDName,
                _.LSStatus,
                _.LSIsImport
    };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                _LSID,
                _LDID,
                _LSName,
                _LSDescription,
                _LSMap,
                //_CreateDate,
               
                _LDName,
                _LSStatus,
                _LSIsImport
            };
        }
        /// <summary>
        /// 设置字段值
        /// </summary>
        public override void SetValue(string fieLSName, object value)
        {
            switch (fieLSName)
            {
                case "LSID":
                    this._LSID = DataHelper.ConvertValue<int>(value);
                    break;
                case "LDID":
                    this._LDID = DataHelper.ConvertValue<int>(value);
                    break;
                case "LSName":
                    this._LSName = DataHelper.ConvertValue<string>(value);
                    break;
                case "LSDescription":
                    this._LSDescription = DataHelper.ConvertValue<string>(value);
                    break;
                case "LSMap":
                    this._LSMap = DataHelper.ConvertValue<int?>(value);
                    break;
                
                case "LDName":
                    this._LDName = DataHelper.ConvertValue<string>(value);
                    break;
                //case "CreateDate":
                //    this._CreateDate = DataHelper.ConvertValue<DateTime?>(value);
                //    break;
                case "LSStatus":
                    this._LSStatus = DataHelper.ConvertValue<bool>(value);
                    break;
                case "LSIsImport":
                    this._LSIsImport = DataHelper.ConvertValue<bool>(value);
                    break;

            }
        }
        /// <summary>
        /// 获取字段值
        /// </summary>
        public override object GetValue(string fieLSName)
        {
            switch (fieLSName)
            {
                case "LSID":
                    return this._LSID;
                case "LDID":
                    return this._LDID;
                case "LSName":
                    return this._LSName;
                case "LSDescription":
                    return this._LSDescription;
                case "LSMap":
                    return this._LSMap;
                //case "CreateDate":
                //    return this._CreateDate;
      
                case "LDName":
                    return this._LDName;
                case "LSStatus":
                    return this._LSStatus;
                case "LSIsImport":
                    return this._LSIsImport;
                default:
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
            public readonly static Field All = new Field("*", "Rent_Street");

            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LSID = new Field("LSID", "Rent_Street", "LSID");

            public readonly static Field LDID = new Field("LDID", "Rent_Street", "LDID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LSName = new Field("LSName", "Rent_Street", "LSName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LSDescription = new Field("LSDescription", "Rent_Street", "LSDescription");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LSMap = new Field("LSMap", "Rent_Street", "LSMap");
            /// <summary>
            /// 
            /// </summary>
            //public readonly static Field CreateDate = new Field("CreateDate", "Rent_District", "CreateDate");
            /// <summary>
            /// 
            /// </summary>
          
            public readonly static Field LDName = new Field("LDName", "Rent_Street", "LDName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LSStatus = new Field("LSStatus", "Rent_Street", "LSStatus");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LSIsImport = new Field("LSIsImport", "Rent_Street", "LSIsImport");
        }
        #endregion


    }
}
