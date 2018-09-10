using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using LigerRM.Common;
using System.Data;
using System.Configuration;
public partial class RentHouse_RentDetail : ViewPageBase
{
    public string RentNo
    {
        set { ViewState["RentNo"] = value; }
        get { return ViewState["RentNo"] == null ? Request["RentNo"] == null ? string.Empty : LigerRM.Common.Global.Encryp.DESDecrypt(Request["RentNo"].ToString()) : ViewState["RentNo"].ToString(); }
    }

    public string EditType //E: Means edit, V: means view only
    {
        get { return Request["type"] == null ? "V" : Request["type"].ToString(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string pass = "&*Js";
            if (Session["RentNo"] != null)
            {
                //CorporationInfo corp = new CorporationInfo(Session["RentNo"].ToString());
                //pass = corp.PassWord;
                lblRentNo.Text = Session["RentNo"].ToString();
            }
            else
                lblRentNo.Text = DateTime.Now.ToString("yyyyMMddHHmmss" + (new Random()).Next(10000, 99999).ToString());

            lblRoomType.Text = Convert.ToString((int)RentPropertyEnumList.RoomType);
            lblDirection.Text = Convert.ToString((int)RentPropertyEnumList.Direction);
            lblStructure.Text = Convert.ToString((int)RentPropertyEnumList.Structure);
            lblBuildingType.Text = Convert.ToString((int)RentPropertyEnumList.BuildingType);
            lblProperty.Text = Convert.ToString((int)RentPropertyEnumList.Property);
            lblRentType.Text = Convert.ToString((int)RentPropertyEnumList.RentType);
            lblOwnType.Text = Convert.ToString((int)RentPropertyEnumList.OwnType);
            //UserInfoHelper.IsValidCorporation(CorporationID, pass);
            //InitialControls();

            InitialControls();
        }
    }

    protected void InitialControls()
    {
        DataBindDistrict();
        DataBindPoliceStationParent();
       
        DataBindRoomType();
 
        if (string.IsNullOrEmpty(RentNo) && EditType == "E")
        {
            lblCreatedBy.Text = SysContext.CurrentUserName;
            lblCreatedByName.Text = SysContext.CurrentRealName;
            lblCreatedDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            CFUserInfo info = new CFUserInfo(SysContext.CurrentUserName);
            txtOwner.Text = info.RealName;
            txtIDCard.Text = info.IDCard;
            txtOwnerTel.Text = info.Phone;
        }
        else
        {
            ddlDistrict.Enabled = false;
            RentInfo rentInfo = new RentInfo(RentNo);
            ViewState["RentNo"] = RentNo;
            lblRentNo.Text = RentNo;

            ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByValue(rentInfo.RDName));
            DataBindStreet();
            ddlStreet.SelectedIndex = ddlStreet.Items.IndexOf(ddlStreet.Items.FindByValue(rentInfo.RSName));
            DataBindRoad(string.Empty);
            ddlRoad.SelectedIndex = ddlRoad.Items.IndexOf(ddlRoad.Items.FindByValue(rentInfo.RRName));

            ddlPoliceStationParent.SelectedIndex = ddlPoliceStationParent.Items.IndexOf(ddlPoliceStationParent.Items.FindByValue(rentInfo.RPSParentName));

            DataBindPoliceStation();
            if (rentInfo.RPSID != null)
            {
                ddlPoliceStation.SelectedIndex = ddlPoliceStation.Items.IndexOf(ddlPoliceStation.Items.FindByValue(rentInfo.RPSID.ToString()));
            }
            else
                ddlPoliceStation.SelectedIndex = -1;

            ddlRoomType.SelectedIndex = ddlRoomType.Items.IndexOf(ddlRoomType.Items.FindByValue(rentInfo.RRoomType));
            ddlDirection.SelectedIndex = ddlDirection.Items.IndexOf(ddlDirection.Items.FindByValue(rentInfo.RDirection));
            ddlBuildingType.SelectedIndex = ddlBuildingType.Items.IndexOf(ddlBuildingType.Items.FindByValue(rentInfo.RBuildingType));
            ddlStructure.SelectedIndex = ddlStructure.Items.IndexOf(ddlStructure.Items.FindByValue(rentInfo.RStructure));
            ddlProperty.SelectedIndex = ddlProperty.Items.IndexOf(ddlProperty.Items.FindByValue(rentInfo.RProperty));

            ddlRentType.SelectedIndex = ddlRentType.Items.IndexOf(ddlRentType.Items.FindByValue(rentInfo.RentType));
            ddlOwnType.SelectedIndex = ddlOwnType.Items.IndexOf(ddlOwnType.Items.FindByValue(rentInfo.OwnType));

            txtAddress.Text = rentInfo.RAddress;
            txtDoor.Text = rentInfo.RDoor;
            if (rentInfo.RTotalDoor == 0)
            {
                txtTotalDoor.Text = string.Empty;
            }
            else
            {
                txtTotalDoor.Text = rentInfo.RTotalDoor.ToString();
            }
            txtFloor.Text = rentInfo.RFloor.ToString();
            if (rentInfo.RTotalFloor == 0)
            {
                txtTotalFloor.Text = string.Empty;
            }
            else
            {
                txtTotalFloor.Text = rentInfo.RTotalFloor.ToString();
            }
            txtHouseAge.Text = rentInfo.RHouseAge.ToString();
            txtBuildRentArea.Text = rentInfo.RRentArea.ToString();
            txtOwner.Text = rentInfo.ROwner;
            txtIDCard.Text = rentInfo.RIDCard;
            txtOwnerTel.Text = rentInfo.ROwnerTel;
            txtFee.Text = rentInfo.RLocationDescription;
            lblCreatedBy.Text = rentInfo.RCreatedBy;
            RentInfoHelper helper = new RentInfoHelper();
            DataTable dtUser = helper.GetDataTable("select * from cf_user where loginName='"+lblCreatedBy.Text+"'");
            foreach (DataRow row in dtUser.Rows)
            {
                lblCreatedByName.Text = row["RealName"].ToString();
            }
            lblCreatedDate.Text = rentInfo.RCreatedDate.ToString("yyyy-MM-dd hh:mm:ss");
            txtLangitude.Text = rentInfo.Longitude;
            txtLatitude.Text = rentInfo.Latitude;

            if (EditType == "E")
            {
                btnSave.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
            }
        }
    }

    private void DataBindDistrict()
    {
        ddlDistrict.DataSource = RentDistrict;
        ddlDistrict.DataTextField = "LDName";
        ddlDistrict.DataValueField = "LDID";
        ddlDistrict.DataBind();

        if (string.IsNullOrEmpty(RentNo) && EditType == "E")
        {
            AddListItem(ddlDistrict);
        }
    }

    private void DataBindStreet()
    {
        RentInfoHelper rentInfoHelper = new RentInfoHelper();
        
        DataTable dt= rentInfoHelper.dtStreet(ddlDistrict.SelectedValue);

        if (dt != null)
        {
            ddlStreet.DataSource = dt;
            ddlStreet.DataTextField = "LSName";
            ddlStreet.DataValueField = "LSID";
            ddlStreet.DataBind();

            if (string.IsNullOrEmpty(RentNo) && EditType == "E")
            {
                AddListItem(ddlStreet);
            }
        }
    }

    private void DataBindRoad()
    {
        RentInfoHelper rentInfoHelper = new RentInfoHelper();

        DataTable dt = rentInfoHelper.dtRoad(ddlDistrict.SelectedValue,ddlStreet.SelectedValue);

        if (dt != null)
        {
            ddlRoad.DataSource = dt;
            ddlRoad.DataTextField = "LRName";
            ddlRoad.DataValueField = "LRID";
            ddlRoad.DataBind();

            if (string.IsNullOrEmpty(RentNo) && EditType == "E")
            {
                AddListItem(ddlRoad);
            }
        }
    }


    private void DataBindPoliceStationParent()
    {
        ddlPoliceStationParent.DataSource = PoliceStationParent;
        ddlPoliceStationParent.DataTextField = "PSName";
        ddlPoliceStationParent.DataValueField = "PSID";
        ddlPoliceStationParent.DataBind();

        if (string.IsNullOrEmpty(RentNo) && EditType == "E")
        {
            AddListItem(ddlPoliceStationParent);
            AddListItem(ddlPoliceStation);
        }
    }

    private void DataBindRoad(string policeStationId)
    {
        ddlRoad.DataTextField = "LRName";
        ddlRoad.DataValueField = "LRID";
        ddlRoad.DataSource = RentRoad;
        ddlRoad.DataBind();
    }

    private void DataBindPoliceStation()
    {
        RentInfoHelper rentInfoHelper = new RentInfoHelper();

        DataTable dt = rentInfoHelper.dtPoliceStation(ddlPoliceStationParent.SelectedValue);

        if (dt != null)
        {
            ddlPoliceStation.DataSource = dt;
            ddlPoliceStation.DataTextField = "PSName";
            ddlPoliceStation.DataValueField = "PSID";
            ddlPoliceStation.DataBind();

            if (string.IsNullOrEmpty(RentNo) && EditType == "E")
            {
                AddListItem(ddlPoliceStation);
            }
        }
    }

    private void DataBindRoomType()
    {
        ddlRoomType.DataSource = RentRoomType;
        ddlRoomType.DataTextField = "RSOName";
        ddlRoomType.DataValueField = "RSONo";
        ddlRoomType.DataBind();

        ddlDirection.DataSource = RentDirection;
        ddlDirection.DataTextField = "RSOName";
        ddlDirection.DataValueField = "RSONo";
        ddlDirection.DataBind();

        ddlBuildingType.DataSource = RentBuildingType;
        ddlBuildingType.DataTextField = "RSOName";
        ddlBuildingType.DataValueField = "RSONo";
        ddlBuildingType.DataBind();

        ddlStructure.DataSource = RentStructure;
        ddlStructure.DataTextField = "RSOName";
        ddlStructure.DataValueField = "RSONo";
        ddlStructure.DataBind();

        ddlProperty.DataSource = RentProperty;
        ddlProperty.DataTextField = "RSOName";
        ddlProperty.DataValueField = "RSONo";
        ddlProperty.DataBind();

        ddlRentType.DataSource = RentType;
        ddlRentType.DataTextField = "RSOName";
        ddlRentType.DataValueField = "RSONo";
        ddlRentType.DataBind();

        ddlOwnType.DataSource = OwnType;
        ddlOwnType.DataTextField = "RSOName";
        ddlOwnType.DataValueField = "RSONo";
        ddlOwnType.DataBind();
    }

    private void AddListItem(DropDownList ddl)
    {
        ListItem lt = new ListItem();
        lt.Text = "请选择";
        lt.Value = "0";
        lt.Selected = true;
        ddl.Items.Add(lt);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBindStreet();
        DataBindRoad();
    }

    protected void ddlStreet_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBindRoad();
    }
    protected void ddlPoliceStationParent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBindPoliceStation();
        txtAddress.Text = ddlPoliceStationParent.SelectedItem.Text;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        RentInfoHelper rentInfoHelper = new RentInfoHelper();
        //if (rentInfoHelper.IsExistsSameAddressRent(ddlDistrict.Text,ddlStreet.Text,ddlRoad.Text,txtDoor.Text.Trim()))
        //{
        //    string detailAddress = ddlDistrict.Text + "-" + ddlStreet.Text + "-" + ddlRoad.Text + "-" + txtDoor.Text.Trim();
        //    ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:$.ligerDialog.warn('相同的房源名称("+ detailAddress + ")已经存在，请重新填写！');", true);
        //}
        //else
        //{
            
            //if (string.IsNullOrEmpty(lblRentNo.Text))
            //{
            //    lblRentNo.Text = rentInfoHelper.GetRentNo(ddlDistrict.SelectedValue);
            //}
                
            RentInfo rentInfo = new RentInfo(lblRentNo.Text);
            rentInfo.RentNo = lblRentNo.Text;
            rentInfo.RDName = ddlDistrict.SelectedValue;
            rentInfo.RSName = ddlStreet.SelectedValue;
            rentInfo.RRName = ddlRoad.SelectedValue;
            rentInfo.RPSParentName = ddlPoliceStationParent.SelectedValue;
            rentInfo.RPSName = ddlPoliceStation.SelectedValue;
            rentInfo.RLocationDescription = txtFee.Text;
            //rentInfo.RPSID = Convert.ToInt32(ddlPoliceStation.SelectedValue);
            rentInfo.RPSID = ddlPoliceStation.SelectedValue;

            rentInfo.RAddress = txtAddress.Text.Trim();
            rentInfo.RDoor = txtDoor.Text.Trim();

            if (!string.IsNullOrEmpty(txtTotalDoor.Text.Trim()))
            {
                rentInfo.RTotalDoor = Convert.ToInt16(txtTotalDoor.Text.Trim());
            }
            else
            {
                rentInfo.RTotalDoor = 0;
            }

            if (ddlRoomType.SelectedValue != "0")
            {
                rentInfo.RRoomType = ddlRoomType.SelectedItem.Value;
            }
            else
            {
                rentInfo.RRoomType = string.Empty;
            }
            if (ddlDirection.SelectedValue != "0")
            {
                rentInfo.RDirection = ddlDirection.SelectedItem.Value;
            }
            else
            {
                rentInfo.RDirection = string.Empty;
            }
            if (ddlStructure.SelectedValue != "0")
            {
                rentInfo.RStructure = ddlStructure.SelectedItem.Value;
            }
            else
            {
                rentInfo.RStructure = string.Empty;
            }
            if (ddlBuildingType.SelectedValue != "0")
            {
                rentInfo.RBuildingType = ddlBuildingType.SelectedItem.Value;
            }
            else
            {
                rentInfo.RBuildingType = string.Empty;
            }
            if (ddlProperty.SelectedValue != "0")
            {
                rentInfo.RProperty = ddlProperty.SelectedItem.Value;
            }
            else
            {
                rentInfo.RProperty = string.Empty;
            }

            rentInfo.RFloor = txtFloor.Text.Trim();
            if (!string.IsNullOrEmpty(txtTotalFloor.Text.Trim()))
            {
                rentInfo.RTotalFloor = Convert.ToInt16(txtTotalFloor.Text.Trim());
            }
            else
            {
                rentInfo.RTotalFloor = 0;
            }
            rentInfo.RentType = ddlRentType.SelectedValue;
            rentInfo.OwnType = ddlOwnType.SelectedValue;
            rentInfo.RHouseAge = Convert.ToInt16(txtHouseAge.Text.Trim());
            rentInfo.RRentArea = Convert.ToDecimal(txtBuildRentArea.Text.Trim());
            rentInfo.ROwner = txtOwner.Text.Trim();
            rentInfo.ROwnerTel = txtOwnerTel.Text.Trim();
            rentInfo.RIDCard = txtIDCard.Text.Trim();
            //rentInfo.RLocationDescription = txtLocationDescription.Text.Trim();

            rentInfo.RMapID = 0;

            if (string.IsNullOrEmpty(RentNo))
            {
                rentInfo.RCreatedBy = SysContext.CurrentUserName;
                rentInfo.RCreatedDate = System.DateTime.Now;
            }
            else
            {
                rentInfo.RModifiedBy = SysContext.CurrentUserName;
                rentInfo.RModifiedDate = System.DateTime.Now;
            }

            rentInfo.Longitude = txtLangitude.Text;
            rentInfo.Latitude = txtLatitude.Text;

            rentInfoHelper.UpdateRent(rentInfo);
            Session["RentNo"] = null;
            ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:SubmitDialog('" + rentInfo.RentNo + "');", true);
        //}
    }


    protected void ddlPoliceStation_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBindRoad(string.Empty);
        string sql = "select * from Rent_Road where LRID='" + ddlRoad.SelectedValue +"'";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtAddress.Text = dt.Rows[0]["LDName"].ToString() + dt.Rows[0]["PSName"].ToString() + dt.Rows[0]["LSName"].ToString();
        }
    }
    protected void ddlRoad_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAddress.Text = ddlPoliceStationParent.Text + ddlPoliceStation.Text + ddlRoad.Text;

        string sql = "select * from Rent_Road where LRID='" + ddlRoad.SelectedValue + "'";
        DataTable dt = MySQLHelper.ExecuteDataset(MySQLHelper.SqlConnString, MySQLHelper.CreateCommand(sql)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtAddress.Text = dt.Rows[0]["LDName"].ToString() + dt.Rows[0]["PSName"].ToString() + dt.Rows[0]["LSName"].ToString();
        }
    }
}