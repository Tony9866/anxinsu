using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class RentAttribute
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;

        private int m_RRAID;
        private string m_RentNo;
        private string m_RRAContactName;
        private string m_RRAContactTel;
        private string m_RRANationName;
        private string m_RRAIDCard;
        private decimal m_RRentPrice;
        private string m_RRAContactProvince;
        private DateTime m_RRAStartDate;
        private DateTime m_RRAEndDate;
        private DateTime? m_RRARealEndDate;
        private string m_RRADescription;
        private DateTime m_RRACreatedDate;
        private string m_RRACreatedBy;
        private DateTime? m_RRAModifiedDate;
        private string m_RRAModifiedBy;
        private string m_Status;
        private bool m_RRAIsActive;
        private string m_tenantId;

        private List<string> m_RentList = new List<string>();

        public int RRAID { get { return m_RRAID; } set { m_RRAID = value; } }

        public string RentNo { get { return m_RentNo; } set { m_RentNo = value; } }

        public string RRAContactName { get { return m_RRAContactName; } set { m_RRAContactName = value; } }

        public string RRAContactTel { get { return m_RRAContactTel; } set { m_RRAContactTel = value; } }

        public string RRANationName { get { return m_RRANationName; } set { m_RRANationName = value; } }

        public string RRAIDCard { get { return m_RRAIDCard; } set { m_RRAIDCard = value; } }

        public decimal RRentPrice { get { return m_RRentPrice; } set { m_RRentPrice = value; } }
         
        public string RRAContactProvince { get { return m_RRAContactProvince; } set { m_RRAContactProvince = value; } }

        public DateTime RRAStartDate { get { return m_RRAStartDate; } set { m_RRAStartDate = value; } }

        public DateTime RRAEndDate { get { return m_RRAEndDate; } set { m_RRAEndDate = value; } }

        public DateTime? RRARealEndDate { get { return m_RRARealEndDate; } set { m_RRARealEndDate = value; } }
        public string RRACheckOutPerson { get; set; }
        public string RRACheckOutReason { get; set; }

        public string RRADescription { get { return m_RRADescription; } set { m_RRADescription = value; } }

        public string RRACreatedBy { get { return m_RRACreatedBy; } set { m_RRACreatedBy = value; } }
        public DateTime RRACreatedDate { get { return m_RRACreatedDate; } set { m_RRACreatedDate = value; } }

        public string RRAModifiedBy { get { return m_RRAModifiedBy; } set { m_RRAModifiedBy = value; } }
        public DateTime? RRAModifiedDate { get { return m_RRAModifiedDate; } set { m_RRAModifiedDate = value; } }
         
        public bool RRAIsActive { get { return m_RRAIsActive; } set { m_RRAIsActive = value; } }


        public List<string> RentPage { get { return m_RentList; } }

        public string Status { get { return m_Status; } set { m_Status = value; } }

        public string TenantID { get { return m_tenantId; } set { m_tenantId = value; } }

        public RentAttribute()
        { }

        public RentAttribute(string RentNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT TOP 1 * FROM Rent_RentAttribute  rra WITH (NOLOCK) INNER JOIN Rent_Rent rr WITH (NOLOCK) ON rra.RentNo=rr.RentNO WHERE rra.RentNo=@RentNo and rr.IsAvailable=1 order by RRAID DESC, RRACreatedDate desc");
            SqlParameter[] parameters = {
                                        new SqlParameter("@RentNo",SqlDbType.NVarChar,20),
                                        };
            parameters[0].Value = RentNo;

            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
            {
                m_RRAID = Convert.ToInt16(rentTable.Rows[0]["RRAID"]);
                m_RentNo = rentTable.Rows[0]["RentNo"].ToString();
                m_RRAContactName = rentTable.Rows[0]["RRAContactName"].ToString();
                m_RRAContactTel = rentTable.Rows[0]["RRAContactTel"].ToString();
                m_RRANationName = rentTable.Rows[0]["RRANationName"].ToString();
                m_RRAIDCard = rentTable.Rows[0]["RRAIDCard"].ToString();
                m_RRentPrice = Convert.ToDecimal(rentTable.Rows[0]["RRentPrice"]);
                m_RRAContactProvince = rentTable.Rows[0]["RRAContactProvince"].ToString();
                m_RRAStartDate = DateTime.Parse(rentTable.Rows[0]["RRAStartDate"].ToString());
                m_RRAEndDate = DateTime.Parse(rentTable.Rows[0]["RRAEndDate"].ToString());
                if (!rentTable.Rows[0].IsNull("RRARealEndDate"))
                    m_RRARealEndDate = DateTime.Parse(rentTable.Rows[0]["RRARealEndDate"].ToString());
                RRACheckOutPerson =  rentTable.Rows[0]["RRACheckOutPerson"].ToString();
                RRACheckOutReason = rentTable.Rows[0]["RRACheckOutReason"].ToString();
                m_RRADescription = rentTable.Rows[0]["RRADescription"].ToString();
                m_RRACreatedBy = rentTable.Rows[0]["RRACreatedBy"].ToString();
                m_RRACreatedDate = DateTime.Parse(rentTable.Rows[0]["RRACreatedDate"].ToString());
                m_RRAModifiedBy = rentTable.Rows[0]["RRAModifiedBy"].ToString();
                if (rentTable.Rows[0]["RRAStatus"] == null)
                    m_Status = rentTable.Rows[0]["RRAStatus"].ToString();

                if (rentTable.Rows[0]["RRAModifiedDate"] == null || string.IsNullOrEmpty(rentTable.Rows[0]["RRAModifiedDate"].ToString()))
                    m_RRAModifiedDate = null;
                else
                    m_RRAModifiedDate = DateTime.Parse(rentTable.Rows[0]["RRAModifiedDate"].ToString());

                m_RRAIsActive = Convert.ToBoolean(rentTable.Rows[0]["RRAIsActive"].ToString());
            }
        }

        public RentAttribute(int rraId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT * FROM Rent_RentAttribute  WHERE RRAID=@RRAID");
            SqlParameter[] parameters = {
                                        new SqlParameter("@RRAID",SqlDbType.Int),
                                        };
            parameters[0].Value = rraId;

            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
            {
                m_RRAID = Convert.ToInt16(rentTable.Rows[0]["RRAID"]);
                m_RentNo = rentTable.Rows[0]["RentNo"].ToString();
                m_RRAContactName = rentTable.Rows[0]["RRAContactName"].ToString();
                m_RRAContactTel = rentTable.Rows[0]["RRAContactTel"].ToString();
                m_RRANationName = rentTable.Rows[0]["RRANationName"].ToString();
                m_RRAIDCard = rentTable.Rows[0]["RRAIDCard"].ToString();
                m_RRentPrice = Convert.ToDecimal(rentTable.Rows[0]["RRentPrice"]);
                m_RRAContactProvince = rentTable.Rows[0]["RRAContactProvince"].ToString();
                m_RRAStartDate = DateTime.Parse(rentTable.Rows[0]["RRAStartDate"].ToString());
                m_RRAEndDate = DateTime.Parse(rentTable.Rows[0]["RRAEndDate"].ToString());
                if (!rentTable.Rows[0].IsNull("RRARealEndDate"))
                    m_RRARealEndDate = DateTime.Parse(rentTable.Rows[0]["RRARealEndDate"].ToString());
                RRACheckOutPerson = rentTable.Rows[0]["RRACheckOutPerson"].ToString();
                RRACheckOutReason = rentTable.Rows[0]["RRACheckOutReason"].ToString();
                m_RRADescription = rentTable.Rows[0]["RRADescription"].ToString();
                m_RRACreatedBy = rentTable.Rows[0]["RRACreatedBy"].ToString();
                m_RRACreatedDate = DateTime.Parse(rentTable.Rows[0]["RRACreatedDate"].ToString());
                m_RRAModifiedBy = rentTable.Rows[0]["RRAModifiedBy"].ToString();
                if (rentTable.Rows[0]["RRAStatus"] != null)
                    m_Status = rentTable.Rows[0]["RRAStatus"].ToString();

                if (rentTable.Rows[0]["RRAModifiedDate"] == null || string.IsNullOrEmpty(rentTable.Rows[0]["RRAModifiedDate"].ToString()))
                    m_RRAModifiedDate = null;
                else
                    m_RRAModifiedDate = DateTime.Parse(rentTable.Rows[0]["RRAModifiedDate"].ToString());

                m_RRAIsActive = Convert.ToBoolean(rentTable.Rows[0]["RRAIsActive"].ToString());
            }

            string sql = "select * from Rent_RentAttribute_External where RRAID=" + rraId;
            DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                m_tenantId = dt.Rows[0]["HZTenantID"].ToString();
            }
        }
    }
}