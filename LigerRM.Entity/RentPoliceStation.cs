using System;
using System.Data;
using System.Data.Common;
using Liger.Common;
using Liger.Data;

namespace Liger.Model
{
    /// <summary>
	/// RentPoliceStation
	/// </summary>
	[Serializable]
    public class RentPoliceStation : Entity
    {
        public RentPoliceStation()
           : base("Rent_PoliceStation")
        {

        }

        #region Model
        private string _PSID;
        private string _ParentID;
        private string _PSName;
        private string _PSDescription;
        private string _PSContactPerson;
        private string _PSContactTel;
        private string _PSAddress;
        private string _PSShortName;
        private string _ParentName;
        private bool _PSStatus;
        private bool _PSIsImport;
        private int? _PSMapID;
        private DateTime? _PSCreatedDate;
        private DateTime? _PSModifiedDate;

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
        public string ParentID
        {
            get { return _ParentID; }
            set
            {
                this.OnPropertyValueChange(_.ParentID, _ParentID, value);
                this._ParentID = value;
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
        public string PSDescription
        {
            get { return _PSDescription; }
            set
            {
                this.OnPropertyValueChange(_.PSDescription, _PSDescription, value);
                this._PSDescription = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PSContactPerson
        {
            get { return _PSContactPerson; }
            set
            {
                this.OnPropertyValueChange(_.PSContactPerson, _PSContactPerson, value);
                this._PSContactPerson = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PSContactTel
        {
            get { return _PSContactTel; }
            set
            {
                this.OnPropertyValueChange(_.PSContactTel, _PSContactTel, value);
                this._PSContactTel = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PSShortName
        {
            get { return _PSShortName; }
            set
            {
                this.OnPropertyValueChange(_.PSShortName, _PSShortName, value);
                this._PSShortName = value;
            }
        }

        public string ParentName
        {
            get { return _ParentName; }
            set
            {
                this.OnPropertyValueChange(_.ParentName, _ParentName, value);
                this._ParentName = value;
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
        public int? PSMapID
        {
            get { return _PSMapID; }
            set
            {
                this.OnPropertyValueChange(_.PSMapID, _PSMapID, value);
                this._PSMapID = value;
            }
        }
 
        /// <summary>
        /// 
        /// </summary>
        public bool PSIsImport
        {
            get { return _PSIsImport; }
            set
            {
                this.OnPropertyValueChange(_.PSIsImport, _PSIsImport, value);
                this._PSIsImport = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool PSStatus
        {
            get { return _PSStatus; }
            set
            {
                this.OnPropertyValueChange(_.PSStatus, _PSStatus, value);
                this._PSStatus = value;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		public DateTime? PSCreatedDate
        {
            get { return _PSCreatedDate; }
            set
            {
                this.OnPropertyValueChange(_.PSCreatedDate, _PSCreatedDate, value);
                this._PSCreatedDate = value;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		public DateTime? PSModifiedDate
        {
            get { return _PSModifiedDate; }
            set
            {
                this.OnPropertyValueChange(_.PSModifiedDate, _PSModifiedDate, value);
                this._PSModifiedDate = value;
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return null;
        }
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
                _.PSID            };
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.PSID,
                _.ParentID,
                _.PSName,
                _.PSDescription,
                _.PSContactPerson,
                _.PSContactTel,
                _.PSAddress,
                _.PSShortName,
                _.ParentName,
                _.PSStatus,
                _.PSIsImport,
                _.PSMapID,
                _.PSCreatedDate,
                _.PSModifiedDate
                
    };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                _PSID,
                _ParentID,
                _PSName,
                _PSDescription,
                _PSContactPerson,
                _PSContactTel,
                _PSAddress,
                _PSShortName,
                _ParentName,
                _PSStatus,
                _PSIsImport,
                _PSMapID,
                _PSCreatedDate,
                _PSModifiedDate
            };
        }
        /// <summary>
        /// 设置字段值
        /// </summary>
        public override void SetValue(string fieldName, object value)
        {
            switch (fieldName)
            {
                case "PSID":
                    this.PSID = DataHelper.ConvertValue<string>(value);
                    break;
                case "ParentID":
                    this._ParentID = DataHelper.ConvertValue<string>(value);
                    break;
                case "PSName":
                    this._PSName = DataHelper.ConvertValue<string>(value);
                    break;
                case "PSDescription":
                    this._PSDescription = DataHelper.ConvertValue<string>(value);
                    break;
                case "PSContactPerson":
                    this._PSContactPerson = DataHelper.ConvertValue<string>(value);
                    break;
                case "PSContactTel":
                    this._PSContactTel = DataHelper.ConvertValue<string>(value);
                    break;
                case "PSAddress":
                    this._PSAddress = DataHelper.ConvertValue<string>(value);
                    break;
                case "PSShortName":
                    this._PSShortName = DataHelper.ConvertValue<string>(value);
                    break;
                case "ParentName":
                    this._ParentName = DataHelper.ConvertValue<string>(value);
                    break;
                case "PSStatus":
                    this._PSStatus = DataHelper.ConvertValue<bool>(value);
                    break;
                case "PSIsImport":
                    this._PSIsImport = DataHelper.ConvertValue<bool>(value);
                    break;
                case "PSMapID":
                    this._PSMapID = DataHelper.ConvertValue<int?>(value);
                    break;
                case "PSCreatedDate":
                    this._PSCreatedDate = DataHelper.ConvertValue<DateTime?>(value);
                    break;
                case "PSModifiedDate":
                    this._PSModifiedDate = DataHelper.ConvertValue<DateTime?>(value);
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
                case "PSID":
                    return this._PSID;
                case "ParentID":
                    return this._ParentID;
                case "PSName":
                    return this._PSName;
                case "PSDescription":
                    return this._PSDescription;
                case "PSContactPerson":
                    return this._PSContactPerson;
                case "PSContactTel":
                    return this._PSContactTel;
                case "PSAddress":
                    return this._PSAddress;
                case "PSShortName":
                    return this._PSShortName;
                case "ParentName":
                    return this._ParentName;
                case "PSStatus":
                    return this._PSStatus;
                case "PSIsImport":
                    return this._PSIsImport;
                case "PSMapID":
                    return this._PSMapID;
                case "PSCreatedDate":
                    return this._PSCreatedDate;
                case "PSModifiedDate":
                    return this._PSModifiedDate;
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
            public readonly static Field All = new Field("*", "Rent_PoliceStation");

            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PSID = new Field("PSID", "Rent_PoliceStation", "PSID");

            public readonly static Field ParentID = new Field("ParentID", "Rent_PoliceStation", "ParentID");

            public readonly static Field PSName = new Field("PSName", "Rent_PoliceStation", "PSName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PSDescription = new Field("PSDescription", "Rent_PoliceStation", "PSDescription");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PSContactPerson = new Field("PSContactPerson", "Rent_PoliceStation", "PSContactPerson");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PSContactTel = new Field("PSContactTel", "Rent_PoliceStation", "PSContactTel");

            public readonly static Field PSAddress = new Field("PSAddress", "Rent_PoliceStation", "PSAddress");
            /// <summary>
            /// 
            /// </summary>
            //public readonly static Field CreateDate = new Field("CreateDate", "Rent_District", "CreateDate");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PSShortName = new Field("PSShortName", "Rent_PoliceStation", "PSShortName");
            public readonly static Field ParentName = new Field("ParentName", "Rent_PoliceStation", "ParentName");

            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PSStatus = new Field("PSStatus", "Rent_PoliceStation", "PSStatus");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field PSIsImport = new Field("PSIsImport", "Rent_PoliceStation", "PSIsImport");

            public readonly static Field PSMapID = new Field("PSMapID", "Rent_PoliceStation", "PSMapID");

            public readonly static Field PSCreatedDate = new Field("PSCreatedDate", "Rent_PoliceStation", "PSCreatedDate");

            public readonly static Field PSModifiedDate = new Field("PSModifiedDate", "Rent_PoliceStation", "PSModifiedDate");
        }
        #endregion


    }
}
