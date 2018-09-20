<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="RentHouse_ScanImage, App_Web_0r5pok1k" %>
=======
<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="RentHouse_ScanImage, App_Web_5ncvhhwe" %>
=======
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="RentHouse_ScanImage, App_Web_bslrsuh2" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function SubmitDialog() {
        var manager = $.ligerDialog.alert('租赁信息保存成功！', '提示', 'success', function (item, Dialog, index) {
            window.close();
            window.opener.f_reload();
        });

    }

    function ErrorDialog(str) {
        var manager = $.ligerDialog.alert('实名认证失败：'+str, '提示', 'success', function (item, Dialog, index) {
            
        });

    }
</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr><td align="center" height="60" style="font-size:24px;">请租户扫描二维码，进行身份验证</td></tr>
    <tr><td align="center"><asp:Image ID="imgScan" runat="server"  ImageUrl="~/Images/71CC2C5B-9567-4573-85D7-2F01272920FE.jpg" /></td></tr>
    <tr><td align="center" height="80">
        <asp:Label ID="lblRet" runat="server" Font-Size="18px" ForeColor="Red" 
            Text="验证中，请不要关闭页面......"></asp:Label>
        <asp:Timer ID="timer" runat="server" Interval="6000" ontick="timer_Tick">
        </asp:Timer>
        </td></tr>
</table>
</asp:Content>

