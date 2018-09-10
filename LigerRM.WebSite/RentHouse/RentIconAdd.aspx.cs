using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignetInternet_BusinessLayer;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using System.Text;
using LigerRM.Common;
using System.Data;

public partial class RentHouse_RentIconAdd : System.Web.UI.Page
{
    private static DataTable dtRenties = new DataTable();
    public string RentNo
    {
        set { ViewState["RentNo"] = value; }
        get { return ViewState["RentNo"] == null ? Request["RentNo"] == null ? string.Empty : Request["RentNo"].ToString() : ViewState["RentNo"].ToString(); }
    }
    public string RRAID
    {
        get { return ViewState["rraId"] == null ? Request["rraId"] == null ? string.Empty : Request["rraId"].ToString() : ViewState["rraId"].ToString(); }
    }

    public string EditType //E: Means edit, V: means view only
    {
        get { return Request["type"] == null ? "V" : Request["type"].ToString(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dtRenties = new DataTable();
            InitialControls();
        }
    }

    protected void InitialControls()
    {
        RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();
        lblRentNo.Text = RentNo;
        RentInfo rentInfo = new RentInfo(RentNo);
        if (!string.IsNullOrEmpty(RRAID))
        {
            RentAttribute rra = new RentAttribute(int.Parse(RRAID));
            lblAddress.Text = rentInfo.RAddress;
            lblCreatedBy.Text = rra.RRACreatedBy;
            lblCreatedDate.Text = rra.RRACreatedDate.ToString();
            txtRentPrice.Text = rra.RRentPrice.ToString();
            txtStartDate.Text = rra.RRAStartDate.ToString("yyyy-MM-dd");
            txtEndDate.Text = rra.RRAEndDate.ToString("yyyy-MM-dd");
            txtContactName.Text = rra.RRAContactName;
            txtContactTel.Text = rra.RRAContactTel;
            txtIDCard.Text = rra.RRAIDCard;
            txtPassword.Text = rra.RRANationName;

            dlRenties.DataSource = rentAttributeHelper.GetRetinues(RRAID);
            dlRenties.DataBind();

            btnDelete.Visible = true;
            btnSave.Visible = false;
            imgAdd.Visible = false;
            imgCard.Visible = false;
            btnStart.Visible = false;
            btnEnd.Visible = false;
        }
        else
        {
            lblCreatedBy.Text = SysContext.CurrentUserName;
            lblCreatedByName.Text = SysContext.CurrentRealName;
            lblCreatedDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            lblAddress.Text = rentInfo.RAddress;
            txtRentPrice.Text = rentInfo.RLocationDescription;
            txtStartDate.Text = Request["startDate"];
            txtEndDate.Text = DateTime.Parse(txtStartDate.Text).AddDays(4).ToString("yyyy-MM-dd");
            txtEndDate.Text = Request["endDate"];
            if (dtRenties.Columns.Count <= 0)
            {
                dtRenties.Columns.Add("Name");
                dtRenties.Columns.Add("IDCard");
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        RentInfo rentInfo = new RentInfo(RentNo);
        //租户身份扫描

        RentAttributeHelper rentAttributeHelper = new RentAttributeHelper();

        RentAttribute rentAttribute = new RentAttribute(lblRentNo.Text);
        rentAttribute.RentNo = lblRentNo.Text;
        rentAttribute.RRAContactName = txtContactName.Text.Trim();
        rentAttribute.RRAContactTel = txtContactTel.Text.Trim();
        rentAttribute.RRANationName = txtPassword.Text;
        rentAttribute.RRAIDCard = txtIDCard.Text.Trim();
        rentAttribute.RRentPrice = Convert.ToDecimal(txtRentPrice.Text.Trim());
        rentAttribute.RRAContactProvince = string.Empty;
        rentAttribute.RRAStartDate = Convert.ToDateTime(txtStartDate.Text);
        rentAttribute.RRAEndDate = Convert.ToDateTime(txtEndDate.Text);
        rentAttribute.RRADescription = string.Empty;
        rentAttribute.Status = ((int)RentAttributeHelper.AttributeStatus.Complete).ToString();



        if (rentInfo.IsAvailable == false)
        {
            rentAttribute.RRACreatedBy = SysContext.CurrentUserName;
            rentAttribute.RRACreatedDate = System.DateTime.Now;

        }
        else
        {
            if (EditType == "E")
            {
                rentAttribute.RRAModifiedBy = SysContext.CurrentUserName;
                rentAttribute.RRAModifiedDate = System.DateTime.Now;
                rentAttributeHelper.UpdateRentAttribute(rentAttribute);
            }
        }
        RentAttributeHelper helper = new RentAttributeHelper();
        string number = helper.AddRentAttribute(rentAttribute);

        for (int i = 0; i < dlRenties.Items.Count; i++)
        {
            TextBox txtName = dlRenties.Items[i].FindControl("txtName") as TextBox;
            TextBox txtIdCard = dlRenties.Items[i].FindControl("txtIdCard") as TextBox;

            dtRenties.Rows[i][0] = txtName.Text;
            dtRenties.Rows[i][1] = txtIdCard.Text;
        }
        //写入随行人员
        foreach (DataRow row in dtRenties.Rows)
        {
            if (!row.IsNull("Name") && !row.IsNull("IDCard"))
                helper.AddRetinues(row["Name"].ToString(), row["IDCard"].ToString(), number);
        }

        //写入密码
        helper.AddPassword(lblRentNo.Text, txtPassword.Text, txtStartDate.Text, txtEndDate.Text, txtContactTel.Text);

        //写入华泽数据
        helper.UploadDataToHZ(number, lblRentNo.Text);

        //string imgUrl = CreateQR(number);
        //Session["RentOrder"] = rentAttribute;
        //Response.Redirect("ScanImage.aspx?url=" + imgUrl + "&ran=" + number);

        //Session["RentNo"] = null;
        ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:SubmitDialog();", true);
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
        RentAttribute rentAttribute = new RentAttribute(int.Parse(RRAID));

        rentAttribute.RRAModifiedBy = SysContext.CurrentUserName;
        rentAttribute.RRAModifiedDate = System.DateTime.Now;
        rentAttribute.RRAIsActive = true;

        rentAttributeHelper.DeleteRentAttribute(rentAttribute);
        ScriptManager.RegisterStartupScript(btnSave, GetType(), "warning", "javascript:DeleteDialog('" + rentAttribute.RentNo + "');", true);
    }
    protected void imgAdd_Click(object sender, ImageClickEventArgs e)
    {
        DataRow row = dtRenties.NewRow();
        row["Name"] = string.Empty;
        row["IDCard"] = string.Empty;
        for(int i=0;i<dlRenties.Items.Count;i++)
        {
            TextBox txtName = dlRenties.Items[i].FindControl("txtName") as TextBox;
            TextBox txtIdCard = dlRenties.Items[i].FindControl("txtIdCard") as TextBox;

            dtRenties.Rows[i][0] = txtName.Text;
            dtRenties.Rows[i][1] = txtIdCard.Text;
        }
        dtRenties.Rows.Add(row);

        dlRenties.DataSource = dtRenties;
        dlRenties.DataBind();
    }
    protected void dlRenties_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item|| e.Item.ItemType== ListItemType.AlternatingItem)
        {
            System.Web.UI.WebControls.ImageButton img = e.Item.FindControl("imgRead") as System.Web.UI.WebControls.ImageButton;
            ImageButton imgDel = e.Item.FindControl("imgDel") as ImageButton;
            TextBox txtName = e.Item.FindControl("txtName") as TextBox;
            TextBox txtIdCard = e.Item.FindControl("txtIdCard") as TextBox;
            img.Attributes.Add("onClick", "javascript:ReadCardByDesc(\'"+txtName.ClientID+"','"+txtIdCard.ClientID+"\');");

            if (!string.IsNullOrEmpty(RRAID))
            {
                img.Visible = false;
                imgDel.Visible = false;
            }
        }
    }
    protected void dlRenties_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            for (int i = 0; i < dlRenties.Items.Count; i++)
            {
                TextBox txtName = dlRenties.Items[i].FindControl("txtName") as TextBox;
                TextBox txtIdCard = dlRenties.Items[i].FindControl("txtIdCard") as TextBox;

                dtRenties.Rows[i][0] = txtName.Text;
                dtRenties.Rows[i][1] = txtIdCard.Text;
            }

            dtRenties.Rows.RemoveAt(e.Item.ItemIndex);
            dlRenties.DataSource = dtRenties;
            dlRenties.DataBind();
        }

    }
}