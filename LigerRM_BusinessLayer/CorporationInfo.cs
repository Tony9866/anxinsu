using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SignetInternet_BusinessLayer
{
    public class CorporationInfo
    {
        private static String SqlConnString = MySQLHelper.SqlConnString;

        private string m_corpId;
        private string m_corpName;
        private string m_sortId;
        private string m_aliasName;
        private string m_fullName;
        private string m_corpClass;
        private string m_corpClassName;
        private string m_corpType;
        private string m_corpTypeName;
        private string m_areaId;
        private string m_areaName;
        private string m_bossName;
        private string m_bossIDCard;
        private string m_address;
        private string m_linker;
        private string m_linkway;
        private string m_postCode;
        private string m_taxno;
        private string m_accountNo;
        private string m_otherNo;
        private string m_passWord;
        private string m_creator;
        private DateTime m_createDate;
        private string m_cancellor;
        private DateTime? m_cancelDate;
        private string m_cancelType;
        private string m_cancelReason;
        private string m_status;
        private string m_memo;
        private string m_bizNo;
        private string m_region;
        private string m_regionname;

        private List<string> m_RegDeptList = new List<string>();

        public string CorpID { get { return m_corpId; } set { m_corpId = value; } }
        public string CorpName { get { return m_corpName; } set { m_corpName = value; } }
        public string SortID { get { return m_sortId; } set { m_sortId = value; } }
        public string AliasName { get { return m_aliasName; } set { m_aliasName = value; } }
        public string FullName { get { return m_fullName; } set { m_fullName = value; } }
        public string CorpClass { get { return m_corpClass; } set { m_corpClass = value; } }
        public string CorpClassName { get { return m_corpClassName; } set { m_corpClassName = value; } }
        public string CorpType { get { return m_corpType; } set { m_corpType = value; } }
        public string CorpTypeName { get { return m_corpTypeName; } set { m_corpTypeName = value; } }
        public string AreaID { get { return m_areaId; } set { m_areaId = value; } }
        public string AreaName { get { return m_areaName; } }
        public string BossName { get { return m_bossName; } set { m_bossName = value ;} }
        public string BossIDCard { get { return m_bossIDCard; } set { m_bossIDCard = value; } }
        public string Address { get { return m_address; } set { m_address = value; } }
        public string Linker { get { return m_linker; } set { m_linker = value; } }
        public string LinkWay { get { return m_linkway; } set { m_linkway = value; } }
        public string PostCode { get { return m_postCode; } set { m_postCode = value; } }
        public string TaxNo { get { return m_taxno; } set { m_taxno = value; } }
        public string AccountNo { get { return m_accountNo; } set { m_accountNo = value; } }
        public string OtherNo { get { return m_otherNo; } set { m_otherNo = value; } }
        public string PassWord { get { return m_passWord; } set { m_passWord = value; } }
        public string Creator { get { return m_creator; } set { m_creator = value; } }
        public DateTime CreateDate { get { return m_createDate; } set { m_createDate = value; } }
        public string Canceller { get { return m_cancellor; } set { m_cancellor = value; } }
        public DateTime? CancelDate { get { return m_cancelDate; } set { m_cancelDate = value; } }
        public string CancelType { get { return m_cancelType; } set { m_cancelType = value; } }
        public string CancelReason { get { return m_cancelReason; } set { m_cancelReason = value; } }
        public string Status { get { return m_status; } set { m_status = value; } }
        public string Memo { get { return m_memo; } set { m_memo = value; } }
        public string BizNo { get { return m_bizNo; } set { m_bizNo = value; } }
        public string Region { get { return m_region; } set { m_region = value; } }
        public string RegionName { get { return m_regionname; } set { m_regionname = value; } }
        public List<string> RegDept { get { return m_RegDeptList; } }

        public CorporationInfo()
        { }

        public CorporationInfo(string corpId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select *,t_area.ar_area_name from t_corporation inner join t_corp_class on co_corp_class = cc_corp_class inner join t_general_code on gc_id = co_type and gc_code_group = 'CT' left join t_area on t_area.ar_area_id = co_area_id where co_corp_id=@corpId");
            SqlParameter[] parameters = {
                                        new SqlParameter("@corpId",SqlDbType.VarChar,12),
                                        };
            parameters[0].Value = corpId;
            DataTable corpTable = MySQLHelper.ExecuteDataset(SqlConnString, MySQLHelper.CreateCommand(sqlStr.ToString(), parameters)).Tables[0];
            if (corpTable != null && corpTable.Rows.Count > 0)
            {
                m_corpId = corpTable.Rows[0]["co_corp_id"].ToString();
                m_region = m_corpId.Substring(0, 6);
                m_corpName = corpTable.Rows[0]["co_corp_name"].ToString();
                m_sortId = corpTable.Rows[0]["co_sort_id"].ToString();
                m_aliasName = corpTable.Rows[0]["co_alias_name"].ToString();
                m_fullName = corpTable.Rows[0]["co_full_name"].ToString();
                m_corpClass = corpTable.Rows[0]["co_corp_class"].ToString();
                m_corpClassName = corpTable.Rows[0]["cc_description"].ToString();
                m_corpType = corpTable.Rows[0]["co_type"].ToString();
                m_corpTypeName = corpTable.Rows[0]["gc_name"].ToString();
                m_areaId = corpTable.Rows[0]["co_area_id"].ToString();
                m_areaName = corpTable.Rows[0]["ar_area_name"].ToString();
                m_bossName= corpTable.Rows[0]["co_boss"].ToString();
                m_bossIDCard = corpTable.Rows[0]["co_boss_idcard"].ToString();
                m_address= corpTable.Rows[0]["co_address"].ToString();
                m_linker= corpTable.Rows[0]["co_linker"].ToString();
                m_linkway= corpTable.Rows[0]["co_link_way"].ToString();
                m_postCode= corpTable.Rows[0]["co_post_code"].ToString();
                m_taxno= corpTable.Rows[0]["co_tax_no"].ToString();
                m_accountNo= corpTable.Rows[0]["co_account_no"].ToString();
                m_otherNo= corpTable.Rows[0]["co_other_no"].ToString();
                m_passWord= corpTable.Rows[0]["co_password"].ToString();
                m_creator= corpTable.Rows[0]["co_creator"].ToString();
                m_createDate= DateTime.Parse(corpTable.Rows[0]["co_create_date"].ToString());
                m_bizNo = corpTable.Rows[0]["co_biz_id"].ToString();
                m_cancellor= corpTable.Rows[0]["co_who_cancel"].ToString();
                if (corpTable.Rows[0]["co_cancel_date"] == null || string.IsNullOrEmpty(corpTable.Rows[0]["co_cancel_date"].ToString()))
                    m_cancelDate = null;
                else
                    m_cancelDate = DateTime.Parse(corpTable.Rows[0]["co_cancel_date"].ToString());
                 m_cancelType= corpTable.Rows[0]["co_cancel_type"].ToString();
                 m_cancelReason= corpTable.Rows[0]["co_cancel_reason"].ToString();
                 m_status= corpTable.Rows[0]["co_status"].ToString();
                 m_memo= corpTable.Rows[0]["co_memo"].ToString();
                 
            }
        }
    }
}
