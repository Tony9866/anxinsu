using System;
using System.Data;
using System.Data.Common;
using Liger.Common;
using Liger.Data;

namespace Liger.Model
{
    /// <summary>
	/// RentDistrict
	/// </summary>
	[Serializable]
    public class RentDistrict : Entity
    {
        public RentDistrict()
           : base("Rent_District")
        {

        }

        #region Model
        private int _LDID;
        private string _LDName;
        private string _LDDescription;
        private int? _LDMap;
        //private DateTime? _CreatedDate;
        private string _LDShortName;
        private bool _LDStatus;
        private bool _LDIsImport;

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
        public string LDDescription
        {
            get { return _LDDescription; }
            set
            {
                this.OnPropertyValueChange(_.LDDescription, _LDDescription, value);
                this._LDDescription = value;
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
        public int? LDMap
        {
            get { return _LDMap; }
            set
            {
                this.OnPropertyValueChange(_.LDMap, _LDMap, value);
                this._LDMap = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool LDStatus
        {
            get { return _LDStatus; }
            set
            {
                this.OnPropertyValueChange(_.LDStatus, _LDStatus, value);
                this._LDStatus = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LDShortName
        {
            get { return _LDShortName; }
            set
            {
                this.OnPropertyValueChange(_.LDShortName, _LDShortName, value);
                this._LDShortName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool LDIsImport
        {
            get { return _LDIsImport; }
            set
            {
                this.OnPropertyValueChange(_.LDIsImport, _LDIsImport, value);
                this._LDIsImport = value;
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.LDID;
        }
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
                _.LDID            };
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.LDID,
                _.LDName,
                _.LDDescription,
                _.LDMap,
                //_.CreateDate,
                _.LDShortName,
                _.LDStatus,
                _.LDIsImport
    };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                _LDID,
                _LDName,
                _LDDescription,
                _LDMap,
                //_CreateDate,
                _LDShortName,
                _LDStatus,
                _LDIsImport
            };
        }
        /// <summary>
        /// 设置字段值
        /// </summary>
        public override void SetValue(string fieldName, object value)
        {
            switch (fieldName)
            {
                case "LDID":
                    this._LDID = DataHelper.ConvertValue<int>(value);
                    break;
                case "LDName":
                    this._LDName = DataHelper.ConvertValue<string>(value);
                    break;
                case "LDDescription":
                    this._LDDescription = DataHelper.ConvertValue<string>(value);
                    break;
                case "LDMap":
                    this._LDMap = DataHelper.ConvertValue<int?>(value);
                    break;
                case "LDShortName":
                    this._LDShortName = DataHelper.ConvertValue<string>(value);
                    break;
                //case "CreateDate":
                //    this._CreateDate = DataHelper.ConvertValue<DateTime?>(value);
                //    break;
                case "LDStatus":
                    this._LDStatus = DataHelper.ConvertValue<bool>(value);
                    break;
                case "LDIsImport":
                    this._LDIsImport = DataHelper.ConvertValue<bool>(value);
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
                case "LDID":
                    return this._LDID;
                case "LDName":
                    return this._LDName;
                case "LDDescription":
                    return this._LDDescription;
                case "LDMap":
                    return this._LDMap;
                //case "CreateDate":
                //    return this._CreateDate;
                case "LDShortName":
                    return this._LDShortName;
                case "LDStatus":
                    return this._LDStatus;
                case "LDIsImport":
                    return this._LDIsImport;
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
            public readonly static Field All = new Field("*", "Rent_District");

            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LDID = new Field("LDID", "Rent_District", "LDID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LDName = new Field("LDName", "Rent_District", "LDName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LDDescription = new Field("LDDescription", "Rent_District", "LDDescription");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LDMap = new Field("LDMap", "Rent_District", "LDMap");
            /// <summary>
            /// 
            /// </summary>
            //public readonly static Field CreateDate = new Field("CreateDate", "Rent_District", "CreateDate");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LDShortName = new Field("LDShortName", "Rent_District", "LDShortName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LDStatus = new Field("LDStatus", "Rent_District", "LDStatus");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LDIsImport = new Field("LDIsImport", "Rent_District", "LDIsImport");
        }
        #endregion


    }
}
