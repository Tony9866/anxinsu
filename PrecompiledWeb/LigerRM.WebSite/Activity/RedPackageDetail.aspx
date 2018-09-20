<%@ page language="C#" autoeventwireup="true" inherits="Activity_RedPackageDetail, App_Web_llzkahaw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
    <table border="0" cellpadding="0" cellpadding="0" width="600px">
        <tr><td width="100px" height="30">红包个数：</td><td width="200px">
            <asp:TextBox ID="txtNum" runat="server" CssClass="txt"></asp:TextBox>
            </td><td width="100px">红包类型：</td><td width="200px">
            <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">随机红包</asp:ListItem>
                <asp:ListItem Value="1">固定金额</asp:ListItem>
            </asp:RadioButtonList>
            </td></tr>
        <tr><td width="100px" height="30">最小金额：</td><td width="200px">
            <asp:TextBox ID="txtMin" runat="server"></asp:TextBox>
            </td><td width="100px">最大金额：</td><td width="200px">
            <asp:TextBox ID="txtMax" runat="server"></asp:TextBox>
            </td></tr>

        <tr><td width="100px" height="30">开始日期：</td><td width="200px">
            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            </td><td width="100px">结束日期：</td><td width="200px">
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            </td></tr>

        <tr>
            <td height="30" width="100px">
                红包总额：</td>
            <td width="200px">
                <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
            </td>
            <td  colspan="2">
                <asp:Button ID="btnClose" runat="server" Text="关闭窗口" CssClass="buttonDefault" />
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="保存信息" 
                    CssClass="buttonDefault" onclick="btnSave_Click" />
            </td>
        </tr>
        <tr><td width="100px" height="30">所属区域：</td><td colspan="3">
        <table border="0" cellpadding="0" cellpadding="0" width ="100%">
            <tr><td width="100px" height="30px">区域：</td><td>
            <asp:DropDownList ID="ddlArea" runat="server" 
                    onselectedindexchanged="ddlArea_SelectedIndexChanged" AutoPostBack="True" 
                    DataTextField="PSName" DataValueField="PSID" Width="100%">
            </asp:DropDownList>
                </td></tr>
            <tr id="trPolice" runat="server" visible=""><td width="100px" height="30px">派出所：</td><td>
            <asp:DropDownList ID="ddlPoliceStation" runat="server" AutoPostBack="True" 
                    DataTextField="PSName" DataValueField="PSID" 
                    onselectedindexchanged="ddlPoliceStation_SelectedIndexChanged" 
                    Width="100%">
            </asp:DropDownList>
                </td></tr>
            <tr  runat="server" visible=""><td width="100px" height="30px">小区：</td><td>
            <asp:DropDownList ID="ddlXiaoQu" runat="server" DataTextField="LRName" 
                    DataValueField="LSID" AutoPostBack="True" 
                    onselectedindexchanged="ddlXiaoQu_SelectedIndexChanged" Width="100%" >
            </asp:DropDownList>
                </td></tr>
        </table>
            </td></tr>
        <tr><td width="100px" height="30">&nbsp;</td><td colspan="3">

                    <asp:GridView ID="gvHouse" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" EnableModelValidation="True" Width="100%">
                        <Columns>
                            <asp:CheckBoxField DataField="flag" HeaderText="选择" />
                            <asp:BoundField DataField="RentNO" HeaderText="房屋编码" />
                            <asp:BoundField DataField="RAddress" HeaderText="关联对象" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>

            </td></tr>
        <tr><td width="100px" height="30">&nbsp;</td><td width="200px">&nbsp;</td><td width="100px">&nbsp;</td><td width="200px">
            &nbsp;</td></tr>
    </table>
                    </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
