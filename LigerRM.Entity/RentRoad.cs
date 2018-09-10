using System;
using System.Data;
using System.Data.Common;
using Liger.Common;
using Liger.Data;

namespace Liger.Model
{
    /// <summary>
	/// RentRoad
	/// </summary>
	[Serializable]
    public class RentRoad : Entity
    {
        public RentRoad()
           : base("Rent_Road")
        {

        }

        #region Model
        private string _LRID;
        private string _LSID;
        private string _LDID;
        private string _LRName;
        private string _LRDescription;
        private string _LRMap;
        //private DateTime? _CreatedDate;
        private string _LDName;
        private string _LSName;
        private string _PSName;
        private bool _LRStatus;
        private bool _LRIsImport;
        private string _PSID;

        /// <summary>
        /// 
        /// </summary>
        public string LRID
        {
            get { return _LRID; }
            set
            {
                this.OnPropertyValueChange(_.LRID, _LRID, value);
                this._LRID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LSID
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
        public string LDID
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
        public string LRName
        {
            get { return _LRName; }
            set
            {
                this.OnPropertyValueChange(_.LRName, _LRName, value);
                this._LRName = value;
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
        public string PSName
        {
            get { return _PSName; }
            set
            {
                this.OnPropertyValueChange(_.PSName, _PSName, value);
                this._PSName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LRDescription
        {
            get { return _LRDescription; }
            set
            {
                this.OnPropertyValueChange(_.LRDescription, _LRDescription, value);
                this._LRDescription = value;
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
        public string LRMap
        {
            get { return _LRMap; }
            set
            {
                this.OnPropertyValueChange(_.LRMap, _LRMap, value);
                this._LRMap = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PSID
        {
            get { return _PSID; }
            set
            {
                this.OnPropertyValueChange(_.PSID, _PSID, value);
                this._PSID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool LRStatus
        {
            get { return _LRStatus; }
            set
            {
                this.OnPropertyValueChange(_.LRStatus, _LRStatus, value);
                this._LRStatus = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool LRIsImport
        {
            get { return _LRIsImport; }
            set
            {
                this.OnPropertyValueChange(_.LRIsImport, _LRIsImport, value);
                this._LRIsImport = value;
            }
        }


        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.LRID;
        }
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
                _.LRID            };
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.LRID,
                _.LSID,
                _.LDID,
                _.LRName,
                _.LRDescription,
                _.LRMap,
                //_.CreateDate,
                _.LSName,
                _.LDName,
                _.PSName,
                _.LRStatus,
                _.LRIsImport,
                _.PSID
    };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                _LRID,
                _LSID,
                _LDID,
                _LRName,
                _LRDescription,
                _LRMap,
                //_CreateDate,
                _LSName,
                _LDName,
                _PSName,
                _LRStatus,
                _LRIsImport,
                _PSID
            };
        }
        /// <summary>
        /// 设置字段值
        /// </summary>
        public override void SetValue(string fieLRName, object value)
        {
            switch (fieLRName)
            {
                case "LRID":
                    this._LRID = DataHelper.ConvertValue<string>(value);
                    break;
                case "LSID":
                    this._LSID = DataHelper.ConvertValue<string>(value);
                    break;
                case "LDID":
                    this._LDID = DataHelper.ConvertValue<string>(value);
                    break;
                case "LRName":
                    this._LRName = DataHelper.ConvertValue<string>(value);
                    break;
                case "LRDescription":
                    this._LRDescription = DataHelper.ConvertValue<string>(value);
                    break;
                case "LRMap":
                    this._LRMap = DataHelper.ConvertValue<string>(value);
                    break;
                case "LSName":
                    this._LSName = DataHelper.ConvertValue<string>(value);
                    break;
                case "LDName":
                    this._LDName = DataHelper.ConvertValue<string>(value);
                    break;
                case "PSName":
                    this._PSName = DataHelper.ConvertValue<string>(value);
                    break;
                //case "CreateDate":
                //    this._CreateDate = DataHelper.ConvertValue<DateTime?>(value);
                //    break;
                case "LRStatus":
                    this._LRStatus = DataHelper.ConvertValue<bool>(value);
                    break;
                case "LRIsImport":
                    this._LRIsImport = DataHelper.ConvertValue<bool>(value);
                    break;
                case "PSID":
                    this._PSID = DataHelper.ConvertValue<string>(value);
                    break;
            }
        }
        /// <summary>
        /// 获取字段值
        /// </summary>
        public override object GetValue(string fieLRName)
        {
            switch (fieLRName)
            {
                case "LRID":
                    return this._LRID;
                case "LSID":
                    return this._LSID;
                case "LDID":
                    return this._LDID;
                case "LRName":
                    return this._LRName;
                case "LRDescription":
                    return this._LRDescription;
                case "LRMap":
                    return this._LRMap;
                //case "CreateDate":
                //    return this._CreateDate;
                case "LSName":
                    return this._LSName;
                case "LDName":
                    return this._LDName;
                case "PSName":
                    return this._PSName;
                case "LRStatus":
                    return this._LRStatus;
                case "LRIsImport":
                    return this._LRIsImport;
                case "PSID":
                    return this._PSID;
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
            public readonly static Field All = new Field("*", "Rent_Road");

            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LRID = new Field("LRID", "Rent_Road", "LRID");

            public readonly static Field LSID = new Field("LSID", "Rent_Road", "LSID");

            public readonly static Field LDID = new Field("LDID", "Rent_Road", "LDID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LRName = new Field("LRName", "Rent_Road", "LRName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LRDescription = new Field("LRDescription", "Rent_Road", "LRDescription");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LRMap = new Field("LRMap", "Rent_Road", "LRMap");

            public readonly static Field PSID = new Field("PSID", "Rent_Road", "PSID");
            /// <summary>
            /// 
            /// </summary>
            //public readonly static Field CreateDate = new Field("CreateDate", "Rent_District", "CreateDate");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LSName = new Field("LSName", "Rent_Road", "LSName");
            public readonly static Field LDName = new Field("LDName", "Rent_Road", "LDName");
            public readonly static Field PSName = new Field("PSName", "Rent_Road", "PSName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LRStatus = new Field("LRStatus", "Rent_Road", "LRStatus");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LRIsImport = new Field("LRIsImport", "Rent_Road", "LRIsImport");
        }
        #endregion


    }
}
