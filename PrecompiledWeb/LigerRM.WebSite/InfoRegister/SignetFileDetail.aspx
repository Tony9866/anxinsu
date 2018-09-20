<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="InfoRegister_SignetFileDetail, App_Web_f331nnfv" %>
=======
<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="InfoRegister_SignetFileDetail, App_Web_0tvrujba" %>
=======
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="InfoRegister_SignetFileDetail, App_Web_5iuxsxpj" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function CloseDialog() {
        parent.$.ligerDialog.close();
        parent.$(".l-dialog,.l-window-mask").css("display", "none");
    }

    function Validate() {
        var f = document.getElementById("<%=fuFile.ClientID %>");
        if (f.value == '') {
            $.ligerDialog.error('请先选择上传的文件！');
            return false;
        }
        $.ligerDialog.waitting('正在保存中,请稍候...');
        return true;
    }

    function wopen(pageURL, title, w, h) {
        var left = (screen.width / 2) - (w / 2);
        var top = (screen.height / 2) - (h / 2) - 20;
        var random = Math.floor(Math.random() * (1000 + 1));
        var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
    }

    function SaveDialog() {

        $.ligerDialog.alert('印章文件上传成功！', '提示', 'success', function (item, Dialog, index) {
            var t = QueryString('v');
            if (t==1) {
                window.close();
            }
            else {
                parent.$.ligerDialog.close();
                parent.window.f_reload();
                parent.$(".l-dialog,.l-window-mask").css("display", "none");
            }
        });
    }

    function QueryString(name) {
        var qs = name + "=";
        var str = location.search;
        if (str.length > 0) {
            begin = str.indexOf(qs);
            if (begin != -1) {
                begin += qs.length;
                end = str.indexOf("&", begin);
                if (end == -1) end = str.length;
                return (str.substring(begin, end));
            }
        }
        return null;
    }

    function CaptureImage() {
        wopen('CaptureImage.aspx?id=', '使用单位详细信息', '650', '580');
    }
</script>
<table style="width:100%;" border="1" cellpadding="1" cellspacing="1">
                <tr>
                    <td height="30" style="width: 15%">
                        印章编号：</td>
                    <td width="35%">
                        <asp:Label ID="lblSignetId" runat="server" Text=""></asp:Label>
                    </td>
                    <td width="15%">
                        文件类型：</td>
                    <td width="35%">
                        <asp:DropDownList ID="ddlFileType" runat="server" DataTextField="gc_name" 
                            DataValueField="gc_id">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="30" style="width: 15%">
                        印章文件：</td>
                    <td colspan="3">
                        <asp:FileUpload ID="fuFile" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td height="30" style="width: 15%">
                        备注：</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtMemo" runat="server" TextMode="MultiLine" Width="410px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" style="width: 15%">
                        &nbsp;</td>
                    <td colspan="3">
                        <asp:Button ID="btnOK" runat="server" CssClass="buttonDefault" Text="上传文件" 
                            onclick="btnCancel_Click" 
                            onclientclick="javascript:return Validate();" />
                             <div style="display:none;">
                             <asp:Button ID="btnForce" runat="server" CssClass="buttonDefault" Text="确定年检" onclick="btnCancel_Click" 
                            /></div>
                        &nbsp;
                        <input ID="Button2" type="button" value="关闭窗口" class="buttonDefault" onclick="javascript:CloseDialog();" /></td>
                </tr>
            </table>
</asp:Content>

