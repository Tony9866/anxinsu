 
using System;
using System.Data;
using System.Data.Common;
using Liger.Common;
using Liger.Data;

namespace Liger.Model
{

    /// <summary>
    /// 实体类Rent_RentSystemOption
    /// </summary>
    [Serializable]
    public class RentSystemOption : Entity
    {
        public RentSystemOption()
           : base("Rent_RentSystemOption")
        {

        }

        #region Model
        private int _RSOID;
        private string _RSONo;
        private string _RSOParentNo;
        private int _RSOOrder;
        private string _RSOName;
        private string _RSOUrl;
        private int? _IsVisible;
     
        /// <summary>
        /// 
        /// </summary>
        public int RSOID
        {
            get { return _RSOID; }
            set
            {
                this.OnPropertyValueChange(_.RSOID, _RSOID, value);
                this._RSOID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RSONo
        {
            get { return _RSONo; }
            set
            {
                this.OnPropertyValueChange(_.RSONo, _RSONo, value);
                this._RSONo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RSOParentNo
        {
            get { return _RSOParentNo; }
            set
            {
                this.OnPropertyValueChange(_.RSOParentNo, _RSOParentNo, value);
                this._RSOParentNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RSOOrder
        {
            get { return _RSOOrder; }
            set
            {
                this.OnPropertyValueChange(_.RSOOrder, _RSOOrder, value);
                this._RSOOrder = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RSOName
        {
            get { return _RSOName; }
            set
            {
                this.OnPropertyValueChange(_.RSOName, _RSOName, value);
                this._RSOName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RSOUrl
        {
            get { return _RSOUrl; }
            set
            {
                this.OnPropertyValueChange(_.RSOUrl, _RSOUrl, value);
                this._RSOUrl = value;
            }
        }
     
        /// <summary>
        /// 
        /// </summary>
        public int? IsVisible
        {
            get { return _IsVisible; }
            set
            {
                this.OnPropertyValueChange(_.IsVisible, _IsVisible, value);
                this._IsVisible = value;
            }
        }
        
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.RSOID;
        }
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
                _.RSOID            };
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.RSOID,
                _.RSONo,
                _.RSOParentNo,
                _.RSOOrder,
                _.RSOName,
                _.RSOUrl,
                _.IsVisible
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                _RSOID,
                _RSONo,
                _RSOParentNo,
                _RSOOrder,
                _RSOName,
                _RSOUrl,
                _IsVisible 
            };
        }
        /// <summary>
        /// 设置字段值
        /// </summary>
        public override void SetValue(string fieldName, object value)
        {
            switch (fieldName)
            {
                case "RSOID":
                    this._RSOID = DataHelper.ConvertValue<int>(value);
                    break;
                case "RSONo":
                    this._RSONo = DataHelper.ConvertValue<string>(value);
                    break;
                case "RSOParentNo":
                    this._RSOParentNo = DataHelper.ConvertValue<string>(value);
                    break;
                case "RSOOrder":
                    this._RSOOrder = DataHelper.ConvertValue<int>(value);
                    break;
                case "RSOName":
                    this._RSOName = DataHelper.ConvertValue<string>(value);
                    break;
                case "RSOUrl":
                    this._RSOUrl = DataHelper.ConvertValue<string>(value);
                    break;
                case "IsVisible":
                    this._IsVisible = DataHelper.ConvertValue<int?>(value);
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
                case "RSOID":
                    return this._RSOID;
                case "RSONo":
                    return this._RSONo;
                case "RSOParentNo":
                    return this._RSOParentNo;
                case "RSOOrder":
                    return this._RSOOrder;
                case "RSOName":
                    return this._RSOName;
                case "RSOUrl":
                    return this._RSOUrl;
                case "IsVisible":
                    return this._IsVisible;
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
            public readonly static Field All = new Field("*", "Rent_RentSystemOption");

            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RSOID = new Field("RSOID", "Rent_RentSystemOption", "RSOID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RSONo = new Field("RSONo", "Rent_RentSystemOption", "RSONo");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RSOParentNo = new Field("RSOParentNo", "Rent_RentSystemOption", "RSOParentNo");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RSOOrder = new Field("RSOOrder", "Rent_RentSystemOption", "RSOOrder");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RSOName = new Field("RSOName", "Rent_RentSystemOption", "RSOName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RSOUrl = new Field("RSOUrl", "Rent_RentSystemOption", "RSOUrl");
            
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IsVisible = new Field("IsVisible", "Rent_RentSystemOption", "IsVisible");
            
        }
        #endregion


    }
}


