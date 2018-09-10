using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class RentInfo
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;

        private string m_RentNo;
        private string m_RDName;
        private string m_RSName;
        private string m_RRName;
        private string m_RPSParentName;
        private string m_RPSName;
        private string m_RAddress;
        private string m_RDoor;
        private int m_RTotalDoor;
        private string m_RRoomType;
        private string m_RDirection;
        private string m_RStructure;
        private string m_RBuildingType;
        private string m_RFloor;
        private int m_RTotalFloor;
        private int m_RHouseAge;
        private string m_RProperty;
        private decimal m_RRentArea;
        private decimal m_RBuildArea;
        private string m_ROwner;
        private string m_ROwnerTel;
        private string m_RIDCard;

        private string m_RealOwner;
        private string m_RealIDCard;
        private string m_RealOwnerTel;
        private string m_HouseId;
        private string m_RentID;
        private DateTime? m_Uploaddate;
        private string m_ExternalDevice;

        private string m_RLocationDescription;
        private Int32 m_RMapID;
        private string m_RPSID;
        private string m_RCreatedBy;
        private DateTime m_RCreatedDate;
        private string m_RModifiedBy;
        private DateTime? m_RModifiedDate;
        private bool m_IsAvailable;
        private string m_Longitude;
        private string m_Latitude;
        private string m_rentType;
        private string m_ownType;
        private bool m_isObsoleted;
        private string m_rentNumber;

        private List<string> m_RentList = new List<string>();

        public string RentNo { get { return m_RentNo; } set { m_RentNo = value; } }
        public string RDName { get { return m_RDName; } set { m_RDName = value; } }

        public string RSName { get { return m_RSName; } set { m_RSName = value; } }

        public string RRName { get { return m_RRName; } set { m_RRName = value; } }
        public string RPSParentName { get { return m_RPSParentName; } set { m_RPSParentName = value; } }
        public string RPSName { get { return m_RPSName; } set { m_RPSName = value; } }

        public string RAddress { get { return m_RAddress; } set { m_RAddress = value; } }
        public string RDoor { get { return m_RDoor; } set { m_RDoor = value; } }
        public int RTotalDoor { get { return m_RTotalDoor; } set { m_RTotalDoor = value; } }
        public string RRoomType { get { return m_RRoomType; } set { m_RRoomType = value; } }
        public string RDirection { get { return m_RDirection; } set { m_RDirection = value; } }
        public string RStructure { get { return m_RStructure; } set { m_RStructure = value; } }
        public string RBuildingType { get { return m_RBuildingType; } set { m_RBuildingType = value; } }
        public string RFloor { get { return m_RFloor; } set { m_RFloor = value; } }
        public int RTotalFloor { get { return m_RTotalFloor; } set { m_RTotalFloor = value; } }
        public int RHouseAge { get { return m_RHouseAge; } set { m_RHouseAge = value; } }
        public string RProperty { get { return m_RProperty; } set { m_RProperty = value; } }
        public decimal RRentArea { get { return m_RRentArea; } set { m_RRentArea = value; } }
        public decimal RBuildArea { get { return m_RBuildArea; } set { m_RBuildArea = value; } }

        public string ROwner { get { return m_ROwner; } set { m_ROwner = value; } }
        public string ROwnerTel { get { return m_ROwnerTel; } set { m_ROwnerTel = value; } }
        public string RIDCard { get { return m_RIDCard; } set { m_RIDCard = value; } }

        public string RRealOwner { get { return m_RealOwner; } set { m_RealOwner = value; } }
        public string RRealOwnerTel { get { return m_RealOwnerTel; } set { m_RealOwnerTel = value; } }
        public string RRealIDCard { get { return m_RealIDCard; } set { m_RealIDCard = value; } }
        public string RHouseID { get { return m_HouseId; } set { m_HouseId = value; } }
        public string RRentID { get { return m_RentID; } set { m_RentID = value; } }
        public string RExternalID { get { return m_ExternalDevice; } set { m_ExternalDevice = value; } }
        public DateTime? RUploadDate { get { return m_Uploaddate; } set { m_Uploaddate = value; } }

        public string RLocationDescription { get { return m_RLocationDescription; } set { m_RLocationDescription = value; } }
        public Int32 RMapID { get { return m_RMapID; } set { m_RMapID = value; } }

        public string RPSID { get { return m_RPSID; } set { m_RPSID = value; } }

        public string RCreatedBy { get { return m_RCreatedBy; } set { m_RCreatedBy = value; } }
        public DateTime RCreatedDate { get { return m_RCreatedDate; } set { m_RCreatedDate = value; } }

        public string RModifiedBy { get { return m_RModifiedBy; } set { m_RModifiedBy = value; } }
        public DateTime? RModifiedDate { get { return m_RModifiedDate; } set { m_RModifiedDate = value; } }

        public bool IsAvailable { get { return m_IsAvailable; } set { m_IsAvailable = value; } }

        public List<string> RentPage { get { return m_RentList; } }

        public string Longitude { get { return m_Longitude; } set { m_Longitude = value; } }
        public string Latitude { get { return m_Latitude; } set { m_Latitude = value; } }

        public string RentType { get { return m_rentType; } set { m_rentType = value; } }
        public string OwnType { get { return m_ownType; } set { m_ownType = value; } }
        public bool IsObsoleted { get { return m_isObsoleted; } set { m_isObsoleted = value; } }
        public string RentNumber { get { return m_rentNumber; } set { m_rentNumber = value; } }

        public RentInfo()
        { }

        public RentInfo(string RentNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT * FROM Rent_Rent WITH (NOLOCK) where RentNo=@RentNo");
            SqlParameter[] parameters = {
                                        new SqlParameter("@RentNo",SqlDbType.NVarChar,20),
                                        };
            parameters[0].Value = RentNo;

            DataTable rentTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (rentTable != null && rentTable.Rows.Count > 0)
            {
                m_RentNo = rentTable.Rows[0]["RentNo"].ToString();
                m_RDName = rentTable.Rows[0]["RDName"].ToString();
                m_RSName = rentTable.Rows[0]["RSName"].ToString();
                m_RRName = rentTable.Rows[0]["RRName"].ToString();
                m_RPSName = rentTable.Rows[0]["RPSName"].ToString();
                m_RPSParentName = rentTable.Rows[0]["RPSParentName"].ToString();
                m_RAddress = rentTable.Rows[0]["RAddress"].ToString();
                m_RDoor = rentTable.Rows[0]["RDoor"].ToString();
                m_RTotalDoor = (int)rentTable.Rows[0]["RTotalDoor"];
                m_RRoomType = rentTable.Rows[0]["RRoomType"].ToString();
                m_RDirection = rentTable.Rows[0]["RDirection"].ToString();
                m_RStructure = rentTable.Rows[0]["RStructure"].ToString();
                m_RBuildingType = rentTable.Rows[0]["RBuildingType"].ToString();
                m_RFloor = rentTable.Rows[0]["RFloor"].ToString();
                m_RTotalFloor = (int)rentTable.Rows[0]["RTotalFloor"];
                m_RHouseAge = (int)rentTable.Rows[0]["RHouseAge"];
                m_RProperty = rentTable.Rows[0]["RProperty"].ToString();
                m_RRentArea = Convert.ToDecimal(rentTable.Rows[0]["RRentArea"]);
                m_RBuildArea = Convert.ToDecimal(rentTable.Rows[0]["RBuildArea"]);
                m_ROwner = rentTable.Rows[0]["ROwner"].ToString();
                m_ROwnerTel = rentTable.Rows[0]["ROwnerTel"].ToString();
                m_RIDCard = rentTable.Rows[0]["RIDCard"].ToString();
                m_isObsoleted = bool.Parse(rentTable.Rows[0]["IsObsoleted"].ToString());
                m_RLocationDescription = rentTable.Rows[0]["RLocationDescription"].ToString();
                m_rentNumber = rentTable.Rows[0]["RentNumber"].ToString();

                if (rentTable.Rows[0]["RMapID"] == null || string.IsNullOrEmpty(rentTable.Rows[0]["RMapID"].ToString()))
                    m_RMapID = 0;
                else
                    m_RMapID = Convert.ToInt32(rentTable.Rows[0]["RMapID"]);

                object cs = rentTable.Rows[0]["RPSID"];
                if (rentTable.Rows[0]["RPSID"] == null || string.IsNullOrEmpty(rentTable.Rows[0]["RPSID"].ToString()))
                    m_RPSID = "0";
                else
                    m_RPSID = rentTable.Rows[0]["RPSID"].ToString();
                m_RCreatedBy = rentTable.Rows[0]["RCreatedBy"].ToString();
                m_RCreatedDate = DateTime.Parse(rentTable.Rows[0]["RCreatedDate"].ToString());
                m_RModifiedBy = rentTable.Rows[0]["RModifiedBy"].ToString();

                if (rentTable.Rows[0]["RModifiedDate"] == null || string.IsNullOrEmpty(rentTable.Rows[0]["RModifiedDate"].ToString()))
                    m_RModifiedDate = null;
                else
                    m_RModifiedDate = DateTime.Parse(rentTable.Rows[0]["RModifiedDate"].ToString());
                m_rentType = rentTable.Rows[0]["RRentType"].ToString();
                m_ownType = rentTable.Rows[0]["ROwnType"].ToString();
                m_IsAvailable = Convert.ToBoolean(rentTable.Rows[0]["IsAvailable"]);
                 rentTable.Rows[0]["RRoomType"].ToString();
            }

            sqlStr = new StringBuilder();
            sqlStr.Append("SELECT * FROM Rent_Map WITH (NOLOCK) where RentNo=@RentNo");
            SqlParameter[] parameters1 = {
                                        new SqlParameter("@RentNo",SqlDbType.NVarChar,20)
                                        };
            parameters1[0].Value = RentNo;

            DataTable mapDt = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters1)).Tables[0];
            if (mapDt != null && mapDt.Rows.Count > 0)
            {
                m_Longitude = mapDt.Rows[0]["Longitude"].ToString();
                m_Latitude = mapDt.Rows[0]["Latitude"].ToString();
            }


            string sql = "SELECT * FROM Rent_External WITH (NOLOCK) where Rent_No=@RentNo";
            SqlParameter[] parameters2 = {
                            new SqlParameter("@RentNo",SqlDbType.NVarChar,20)
                            };
            parameters2[0].Value = RentNo;

            mapDt = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sql, parameters2)).Tables[0];
            if (mapDt != null && mapDt.Rows.Count > 0)
            {
                m_ExternalDevice = mapDt.Rows[0]["ExternalDevice"].ToString();
                m_HouseId = mapDt.Rows[0]["HZHouseID"].ToString();
                if (!mapDt.Rows[0].IsNull("HZUploadDate"))
                    m_Uploaddate = DateTime.Parse(mapDt.Rows[0]["HZUploadDate"].ToString());
                m_RealOwner = mapDt.Rows[0]["RentRealOwner"].ToString();
                m_RealIDCard = mapDt.Rows[0]["RentRealOwnerID"].ToString();
                m_RealOwnerTel = mapDt.Rows[0]["RentRealOwnerPhone"].ToString();
                m_RentID = mapDt.Rows[0]["HZRentID"].ToString();
            }

            if (string.IsNullOrEmpty(m_RealOwner))
                m_RealOwner = m_ROwner;
            if (string.IsNullOrEmpty(m_RealIDCard))
                m_RealIDCard = m_RIDCard;
            if (string.IsNullOrEmpty(m_RealOwnerTel))
                m_RealOwnerTel = m_ROwnerTel;
        }
    }
}
