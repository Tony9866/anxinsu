<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="BaseManage_MessageDetail, App_Web_gnmc3w40" %>
=======
<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="BaseManage_MessageDetail, App_Web_cc24bspp" %>
=======
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="BaseManage_MessageDetail, App_Web_idpc1t1v" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function validateForm() {
        var hd = document.getElementById("<%=hdCarve.ClientID %>");
        hd.value = document.getElementById("txtCarve").value;
    }

</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%" class="table-c">
    <tr><td>
    <table border="0" cellpadding="0" cellspacing="0" width="600">
        <tr><td width="100" height="25">信息标题：</td><td width="500">
            <asp:TextBox ID="txtTitle" runat="server" Height="25px" 
                MaxLength="200" CssClass="txt" Width="470px"></asp:TextBox>
            </td></tr>
        <tr><td width="100" height="25">信息内容：</td><td width="500">
            <asp:TextBox ID="txtContent" runat="server" Height="107px" TextMode="MultiLine" 
                CssClass="txt" Width="470px"></asp:TextBox>
            </td></tr>
        <tr style="display:blcok;" runat="server" id="trCarves"><td width="100" height="25">推送单位：</td><td width="500">
            <input id="txtCarve" type="text" style="width:470px;height:25px;" class="txt" />
            <img src="../images/gtk-zoom-in.png" 
                onclick="javascript: $.ligerDialog.open({ height: 350, width: 500, url: 'CarveCorpSelect.aspx', title: '派出所选择' });" 
                width="20" />
            
            <br />
            <span style="color: #FF0000">注：如果要对全体发布，推送单位留空即可。</span></td></tr>
        <tr><td width="100" height="25">发布人：</td><td width="500">
            <asp:Label ID="lblReporter" runat="server"></asp:Label>
            <asp:HiddenField ID="hdCarve" runat="server" />
            </td></tr>
        <tr><td width="100" height="25">发布时间：</td><td width="500">
            <asp:Label ID="lblDate" runat="server"></asp:Label>
            </td></tr>
        <tr><td width="100" height="25">&nbsp;</td><td width="500">
            <asp:Button ID="btnOK" runat="server" CssClass="buttonDefault" Text="确定" 
                onclick="btnOK_Click" OnClientClick="javascript:validateForm();" />&nbsp;
            <input id="Button1" onclick='javascript:parent.$.ligerDialog.close();parent.$(".l-dialog,.l-window-mask").css("display", "none");' type="button" 
        value="关闭窗口" class="buttonDefault" />
            </td></tr>
    </table></td></tr>
</table>
</asp:Content>

