<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_RentImageDetail, App_Web_0qr5aslx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/js/LG.js" type="text/javascript"></script> 
    <script src="../lib/ligerUI/js/ligerui.all.js" type="text/javascript"></script>   
    <script src="../lib/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>  
    
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script>  
    <script src="../lib/json2.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerTextBox.js" type="text/javascript"></script> 
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script>
    
    <script src="../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script> 
    <script src="../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script src="../lib/jquery.form.js" type="text/javascript"></script>

    <script src="../lib/js/iconselector.js" type="text/javascript"></script> 
    <style type="text/css">
    .l-panel td.l-grid-row-cell-editing { padding-bottom: 2px;padding-top: 2px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
            if (t == 1) {
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
                    <td height="30" style="width: 150px">
                        <asp:Label ID="Label1" runat="server" Text="房源编号：" Width="150px"></asp:Label>
                    </td>
                    <td width="35%">
                        <asp:Label ID="lblSignetId" runat="server" Text=""></asp:Label>
                    </td>
                    <td width="15%">
                        照片名称：</td>
                    <td width="35%">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" style="width: 15%">
                        照片文件：</td>
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
    </div>
    </form>
</body>
</html>
