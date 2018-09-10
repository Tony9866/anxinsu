<%@ page language="C#" autoeventwireup="true" inherits="Payment_OrderConfirm, App_Web_25otvmgp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />

    
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>  
    <script src="../lib/ligerUI/js/plugins/ligerTab.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerLayout.js" type="text/javascript"></script>
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <link href="../lib/css/index.css" rel="stylesheet" type="text/css" />
    <script src="../lib/js/common.js" type="text/javascript"></script>
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/login.js" type="text/javascript"></script>

        <script src="../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script> 
    <script src="../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script src="../lib/js/changepassword.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerForm.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function showdiv() {
            document.getElementById("bg").style.display = "block";
            document.getElementById("show").style.display = "block";
        }
        function hidediv() {
            document.getElementById("bg").style.display = 'none';
            document.getElementById("show").style.display = 'none';
        }  
function btnshow_onclick() {

}

    </script>  
    <style type="text/css">
#bg{ display: none;  position: absolute;  top: 0%;  left: 0%;  width: 100%;  height: 100%;  background-color: black;  z-index:1001;  -moz-opacity: 0.7;  opacity:.70;  filter: alpha(opacity=70);}  
         #show{display: none;  position: absolute;  top: 25%;  left: 22%;  width: 53%;  height: 49%;  padding: 8px;  border: 8px solid #E8E9F7;  background-color: white;  z-index:1002;  overflow: auto;}  
        .style1
        {
            height: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="padding:10px;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td>订单确认</td></tr>
        <tr><td style="padding:5px;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr style="background-color:#eeeeee;"><td height="30">订单编号</td><td>物品名称</td><td>数量</td><td>费用</td><td>备注</td></tr>
                <tr><td class="style1">
                    <asp:Label ID="lblOrderID" runat="server"></asp:Label>
                    </td><td class="style1">
                        <asp:Label ID="lblGoodsName" runat="server"></asp:Label>
                    </td><td class="style1">
                        <asp:Label ID="lblCount" runat="server"></asp:Label>
                    </td><td class="style1">
                        <asp:Label ID="lblCost" runat="server"></asp:Label>
                    </td><td class="style1">
                        <asp:Label ID="lblMemo" runat="server"></asp:Label>
                    </td></tr>
                <tr><td>
                    &nbsp;</td><td>
                        &nbsp;</td><td>
                        &nbsp;</td><td>
                        &nbsp;</td><td>
                        &nbsp;</td></tr>
            </table>
        </td></tr>
        <tr><td>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr><td colspan="6">
                支付方式</td></tr>
            <tr><td>
                <asp:RadioButton ID="rbUnion" runat="server" GroupName="rb" Checked="True" />
                </td><td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/unionpay.png" />
                </td><td>
                    <asp:RadioButton ID="rbAliPay" runat="server" GroupName="rb" />
                </td><td>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/alipay.png" />
                </td><td>
                    <asp:RadioButton ID="rbWeChart" runat="server" GroupName="rb" />
                </td><td class="style1">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/wechartpay.png" />
                </td></tr>
            <tr><td>
                &nbsp;</td><td>
                    &nbsp;</td><td>
                    &nbsp;</td><td>
                    &nbsp;</td><td>
                    &nbsp;</td><td class="style1">
                    &nbsp;</td></tr>
        </table>
        </td></tr>
        <tr><td>
            <asp:Button ID="btnClose" runat="server" CssClass="buttonDefault" Text="关闭" />
&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="buttonDefault" 
                onclick="btnNext_Click" Text="下一步" />
            &nbsp;<input id="btnshow" type="button" value="Show" onclick="showdiv();" onclick="return btnshow_onclick()" /> 
                     <div id="bg"></div>  
     <div id="show">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td align="center">
                <asp:Label ID="lblTitle" runat="server" Font-Size="24px" ForeColor="#000066"></asp:Label>
                </td></tr>
            <tr><td  align="center">
            <asp:Image ID="imgCode" runat="server" 
    ImageUrl="~/Images/97C6CA9E-5D61-40D8-AF4B-289B3CE9DB8F.jpg" />
            </td></tr>
            <tr><td></td></tr>
            <tr><td align="center">
                <asp:Button ID="btnCancel" runat="server" Text="停止支付" CssClass="buttonDefault"
                    OnClientClick="javascript:hidediv();" onclick="btnCancel_Click" />
            </td></tr>
        </table>  
         
     </div>  
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="timer" runat="server" Enabled="False" Interval="1000" 
                        ontick="timer_Tick">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td></tr>
    </table>
    </div>
    </form>
</body>
</html>
