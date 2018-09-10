using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignetInternet_DataLayer.SignetDataSetTableAdapters;

namespace SignetInternet_BusinessLayer
{
    public class CarveEmployeeInfo
    {
        private string m_employeeId;
        private string m_name;
        private string m_idcard;
        private string m_gender;
        private string m_position;
        private string m_nationality;
        private string m_address;
        private string m_privince;
        private string m_city;
        private string m_district;
        private string m_tempAddress;
        private string m_tempPrivince;
        private string m_tempCity;
        private string m_tempDistrict;
        private byte[] m_image;
        private string m_phone;
        private string m_linker;
        private string m_linkway;
        private string m_carvecorp_id;
        private string m_register;
        private DateTime? m_registDate;
        private string m_cancelCorp;
        private string m_canceller;
        private DateTime? m_cancel_date;
        private string m_memo;
        private bool m_obsolete;

        public string EmployeeId{get{return m_employeeId;}set{m_employeeId = value;}}
        public string EmployeeName{get{return m_name;}set{m_name = value;}}
        public string IDCard{get{return m_idcard;}set{m_idcard = value;}}
        public string Gender{get{return m_gender;}set{m_gender = value;}}
        public string Position { get { return m_position; } set { m_position = value; } }
        public string Nationality { get { return m_nationality; } set { m_nationality = value; } }
        public string Address { get { return m_address; } set { m_address = value; } }
        public string Privince { get { return m_privince; } set { m_privince = value; } }
        public string City { get { return m_city; } set { m_city = value; } }
        public string District { get { return m_district; } set { m_district = value; } }
        public string TempAddress { get { return m_tempAddress; } set { m_tempAddress = value; } }
        public string TempPrivince { get { return m_tempPrivince; } set { m_tempPrivince = value; } }
        public string TempCity { get { return m_tempCity; } set { m_tempCity = value; } }
        public string TempDistrict { get { return m_tempDistrict; } set { m_tempDistrict = value; } }
        public byte[] Image { get { return m_image; } set { m_image = value; } }
        public string Phone { get { return m_phone; } set { m_phone = value; } }
        public string Linker { get { return m_linker; } set { m_linker = value; } }
        public string Linkway { get { return m_linkway; } set { m_linkway = value; } }
        public string CarveCorpId { get { return m_carvecorp_id; } set { m_carvecorp_id = value; } }
        public string Register { get { return m_register; } set { m_register = value; } }
        public DateTime? RegistDate { get { return m_registDate; } set { m_registDate = value; } }
        public string CancelCorp { get { return m_cancelCorp; } set { m_cancelCorp = value; } }
        public string Canceller { get { return m_canceller; } set { m_canceller = value; } }
        public DateTime? CancelDate { get { return m_cancel_date; } set { m_cancel_date = value; } }
        public string Memo { get { return m_memo; } set { m_memo = value; } }
        public bool Obsolete { get {return m_obsolete; } set { m_obsolete = value; } }
        public CarveEmployeeInfo(string empId)
        {
            GetBaseInfo(empId);
        }

        public CarveEmployeeInfo()
        { }

        private void GetBaseInfo(string empId)
        {
            t_carvecorp_EmployeeTableAdapter adapter = new t_carvecorp_EmployeeTableAdapter();
            SignetInternet_DataLayer.SignetDataSet.t_carvecorp_EmployeeDataTable dt = adapter.up_SignetInternet_CarveCorpEmployeeSelectByID(empId);
            foreach (SignetInternet_DataLayer.SignetDataSet.t_carvecorp_EmployeeRow row in dt.Rows)
            {
                m_employeeId = empId;
                m_name = row.ce_name;
                m_idcard = row.ce_IDCard;
                m_gender = row.ce_gender;
                m_position = row.IsNull("ce_position") ? string.Empty : row.ce_position;
                m_nationality = row.IsNull("ce_national") ? string.Empty : row.ce_national;
                m_address = row.IsNull("ce_address") ? string.Empty : row.ce_address;
                m_privince = row.IsNull("ce_privince") ? string.Empty : row.ce_privince;
                m_city = row.IsNull("ce_city") ? string.Empty : row.ce_city;
                m_district = row.IsNull("ce_district") ? string.Empty : row.ce_district;

                m_tempAddress = row.IsNull("ce_tempAddress") ? string.Empty : row.ce_tempAddress;
                m_tempPrivince = row.IsNull("ce_tempPrivince") ? string.Empty : row.ce_tempPrivince;
                m_tempCity = row.IsNull("ce_tempCity") ? string.Empty : row.ce_tempCity;
                m_tempDistrict = row.IsNull("ce_tempDistrict") ? string.Empty : row.ce_tempDistrict;

                m_image = row.IsNull("ce_Image") ? null : row.ce_Image;
                m_phone = row.IsNull("ce_phone") ? string.Empty : row.ce_phone;

                m_linker = row.IsNull("ce_linker") ? string.Empty : row.ce_linker;
                m_linkway = row.IsNull("ce_linkway") ? string.Empty : row.ce_linkway;
                m_carvecorp_id = row.IsNull("ce_carve_corp_id") ? string.Empty : row.ce_carve_corp_id;
                m_register = row.IsNull("ce_register") ? string.Empty : row.ce_register;

                if (!row.IsNull("ce_register_date"))
                    m_registDate = row.ce_register_date;
                m_cancelCorp = row.IsNull("ce_cancel_corp") ? string.Empty : row.ce_cancel_corp;
                m_canceller = row.IsNull("ce_canceller") ? string.Empty : row.ce_canceller;
                if (!row.IsNull("ce_cancel_date"))
                    m_cancel_date = row.ce_cancel_date;

                m_memo = row.IsNull("ce_memo") ? string.Empty : row.ce_memo;
                m_obsolete = row.IsNull("ce_obsolete") ? false : row.ce_obsolete;
            }

        }
    }
}
