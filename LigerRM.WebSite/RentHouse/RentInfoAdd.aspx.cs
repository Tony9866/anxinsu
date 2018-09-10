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
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Text;
public partial class RentHouse_RentInfoAdd : ViewPageBase
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
                lblRentNo.Text = Session["RentNo"].ToString();
            }

            lblProvince.Text = Convert.ToString((int)RentPropertyEnumList.Province);
            lblNationName.Text = Convert.ToString((int)RentPropertyEnumList.NationName);

            InitialControls();

            if (EditType == "D")
            {
                RentInfo rentInfo = new RentInfo(RentNo);
                btnSave.Visible = false;
                if (rentInfo == null || rentInfo.IsAvailable == false)
                {
                    lblRentStatus.Text = "此房源未出租，不能退房";
                    btnDelete.Visible = false;
                }
                else if (rentInfo.IsAvailable == true)
                {
                    btnDelete.Visible = true;
                }
            }
            else if (EditType == "V")
            {
                btnSave.Visible = false;
                btnDelete.Visible = false;
            }
        }
    }

    protected void InitialControls()
    {
        RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();

        DataBindProvince();
        DataBindNationName();



        if (EditType == "D")
        {
            RentAttribute rentAttribute = new RentAttribute(int.Parse(RentNo));

            lblRentNo.Text = rentAttribute.RentNo;
            RentInfo rentInfo = new RentInfo(rentAttribute.RentNo);

            txtContactName.Text = rentAttribute.RRAContactName;
            txtIDCard.Text = rentAttribute.RRAIDCard;
            txtContactTel.Text = rentAttribute.RRAContactTel;
            txtRentPrice.Text = rentAttribute.RRentPrice.ToString();

            ddlContactProvince.SelectedIndex = ddlContactProvince.Items.IndexOf(ddlContactProvince.Items.FindByText(rentAttribute.RRAContactProvince));
            ddlNationName.SelectedIndex = ddlNationName.Items.IndexOf(ddlNationName.Items.FindByText(rentAttribute.RRANationName));
            txtStartDate.Text = rentAttribute.RRAStartDate.ToString("yyyy-MM-dd");
            txtEndDate.Text = rentAttribute.RRAEndDate.ToString("yyyy-MM-dd");

            txtDescription.Text = rentAttribute.RRADescription;
            lblCreatedBy.Text = rentAttribute.RRACreatedBy;
            RentInfoHelper helper = new RentInfoHelper();
            DataTable dtUser = helper.GetDataTable("select * from cf_user where loginName='" + lblCreatedBy.Text + "'");
            foreach (DataRow row in dtUser.Rows)
            {
                lblCreatedByName.Text = row["RealName"].ToString();
            }
            lblCreatedDate.Text = rentAttribute.RRACreatedDate.ToString("yyyy-MM-dd hh:mm:ss");
            btnStart.Visible = false;
            btnEnd.Visible = false;
            btnSave.Visible = false;
        }
        else
        {
            //获取租房者信息
            RentAttribute rentAttribute = new RentAttribute(int.Parse(RentNo));

            lblRentNo.Text = rentAttribute.RentNo;
            RentInfo rentInfo = new RentInfo(rentAttribute.RentNo);

            txtContactName.Text = rentAttribute.RRAContactName;   //承租人姓名
            txtIDCard.Text = rentAttribute.RRAIDCard;    //身份证号ID
            txtContactTel.Text = rentAttribute.RRAContactTel;   //承租人联系电话
            txtRentPrice.Text = rentAttribute.RRentPrice.ToString(); //租赁价格

            ddlContactProvince.SelectedIndex = ddlContactProvince.Items.IndexOf(ddlContactProvince.Items.FindByText(rentAttribute.RRAContactProvince));  //获取所属省份
            ddlNationName.SelectedIndex = ddlNationName.Items.IndexOf(ddlNationName.Items.FindByText(rentAttribute.RRANationName));  //获取所属国籍
            txtStartDate.Text = rentAttribute.RRAStartDate.ToString("yyyy-MM-dd"); //租赁起始时间
            txtEndDate.Text = rentAttribute.RRAEndDate.ToString("yyyy-MM-dd");  //租赁结束时间

            txtDescription.Text = rentAttribute.RRADescription;  //备注
            lblCreatedBy.Text = rentAttribute.RRACreatedBy; 
            RentInfoHelper helper = new RentInfoHelper();
            DataTable dtUser = helper.GetDataTable("select * from cf_user where loginName='" + lblCreatedBy.Text + "'");
            foreach (DataRow row in dtUser.Rows)
            {
                lblCreatedByName.Text = row["RealName"].ToString(); //创建人
            }
            lblCreatedDate.Text = rentAttribute.RRACreatedDate.ToString("yyyy-MM-dd hh:mm:ss");  //创建时间

            if (EditType == "A")
            {
                lblRentStatus.Text = "此房源已出租";
                btnSave.Visible = false;
            }

        }
    }

    private void DataBindProvince()
    {
        ddlContactProvince.DataSource = Province;
        ddlContactProvince.DataTextField = "RSOName";
        ddlContactProvince.DataValueField = "RSOID";
        ddlContactProvince.DataBind();
    }

    private void DataBindNationName()
    {
        ddlNationName.DataSource = NationName;
        ddlNationName.DataTextField = "RSOName";
        ddlNationName.DataValueField = "RSOID";
        ddlNationName.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        RentInfo rentInfo = new RentInfo(RentNo);
        //租户身份扫描
        //string url = ConfigurationManager.AppSettings["CertificateUrl"];
        //string data = "{" +
        //                       "\"AppID\":\"0000004\"," +
        //                       "\"FunID\":\"000\"," +
        //                       "\"OrderID\":\""+Guid.NewGuid().ToString().Replace("-","").Substring(0,30)+"\"," +
        //                       "\"HouseID\":\""+RentNo+"\"," +
        //                       "\"LessorID\":\""+rentInfo.RIDCard+"\"," +
        //                       "\"LessorName\":\""+rentInfo.ROwner+"\"," +
        //                       "\"LesseeID\":\""+txtIDCard.Text+"\"," +
        //                       "\"LesseeName\":\""+txtContactName.Text+"\"," +
        //                       "\"Rent\":\""+txtRentPrice.Text+"\"," +
        //                       "\"RentType\":\""+rentInfo.RentType+"\"," +
        //                       "\"StartTime\":\""+txtStartDate.Text+"\"," +
        //                       "\"EndTime\":\""+txtEndDate.Text+"\"," +
        //                       "\"AgentFlag\":\"0\"," +
        //                       "\"AgentID\":\"\"," +
        //                       "\"AgentName\":\"\"" +
        //                       "}";

        //string ret = LigerRM.Common.WebRequestHelper.WebRequestPoster.Post(url, data);
        ////{'ret':'1','desc':'SDT-HOUSE-3836333933303230313730333233313032333235333631'}
        //Dictionary<string,string> result =  JSONHelper.FromJson<Dictionary<string, string>>(ret);
        //if (result["ret"] == "1")
        //{
            

            RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();

            RentAttribute rentAttribute = new RentAttribute(int.Parse(RentNo));
            rentAttribute.RentNo = lblRentNo.Text;
            rentAttribute.RRAContactName = txtContactName.Text.Trim();
            rentAttribute.RRAContactTel = txtContactTel.Text.Trim();
            rentAttribute.RRANationName = ddlNationName.SelectedItem.Text;
            rentAttribute.RRAIDCard = txtIDCard.Text.Trim();
            rentAttribute.RRentPrice = Convert.ToDecimal(txtRentPrice.Text.Trim());

            rentAttribute.RRAContactProvince = ddlContactProvince.SelectedItem.Text;

            rentAttribute.RRAStartDate = Convert.ToDateTime(txtStartDate.Text);
            rentAttribute.RRAEndDate = Convert.ToDateTime(txtEndDate.Text);

            rentAttribute.RRADescription = txtDescription.Text.Trim();
            rentAttribute.Status = ((int)RentAttributeHelper.AttributeStatus.Complete).ToString();
            


            //if (rentInfo.IsAvailable == false)
            //{
            //    rentAttribute.RRACreatedBy = SysContext.CurrentUserName;
            //    rentAttribute.RRACreatedDate = System.DateTime.Now;

            //    //rentAttributeHelper.AddRentAttribute(rentAttribute);
            //}
            //else
            //{
                if (EditType == "E")
                {
                    rentAttribute.RRAModifiedBy = SysContext.CurrentUserName;
                    rentAttribute.RRAModifiedDate = System.DateTime.Now;
                    rentAttributeHelper.UpdateRentAttribute(rentAttribute);
                }
            //}
            //RentAttributeHelper helper = new RentAttributeHelper();
            //string number = helper.AddRentAttribute(rentAttribute);
            //string imgUrl = CreateQR(number);
            //Session["RentOrder"] = rentAttribute;
            //Response.Redirect("ScanImage.aspx?url=" + imgUrl + "&ran=" + number);

            Session["RentNo"] = null;
            ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:SubmitDialog('" + rentAttribute.RentNo + "');", true);
        //}
    }

    public string CreateQR(string nr)
    {
        Bitmap bt;
        if (!string.IsNullOrEmpty(nr))
        {
            string filename = Guid.NewGuid().ToString().ToUpper();
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            bt = qrCodeEncoder.Encode(nr, Encoding.UTF8);
            string imgPath = System.Web.HttpContext.Current.Server.MapPath("~/Images/") + filename + ".jpg";
            try
            {
                bt.Save(imgPath);
                return filename + ".jpg";
            }
            catch (Exception)
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();

        RentAttribute rentAttribute = new RentAttribute(lblRentNo.Text);

        rentAttribute.RRAModifiedBy = SysContext.CurrentUserName;
        rentAttribute.RRAModifiedDate = System.DateTime.Now;
        rentAttribute.RRAIsActive = true;
        
        rentAttributeHelper.DeleteRentAttribute(rentAttribute);

        Session["RentNo"] = null;
        ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:DeleteDialog('" + rentAttribute.RentNo + "');", true);
    }
}