<%@ page language="C#" autoeventwireup="true" inherits="InfoRegister_FileUpload, App_Web_5iuxsxpj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <title>上传印章图像</title>
        <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" /> 
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <base target="_self">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script  type="text/javascript">
            function PreviewImage() {
                var file = document.getElementById("<%=upFile.ClientID %>");
                var src = window.URL.createObjectURL(file.files[0]);
                var pImg = document.getElementById("<%=imgSinget.ClientID %>");
                pImg.src = src;
            }

            function GetReturnFile(i) {
                var imgS = window.opener.document.getElementById("ctl00_ContentPlaceHolder1_tbInfo_TabPanel1_imgSinget");
                window.opener.document.getElementById("ctl00_ContentPlaceHolder1_tbInfo_TabPanel1_hdImage").value = i;
                imgS.src = '../'+i;
                window.close();
            }

</script>
<table width="100%" border="1" cellpadding="1" cellspacing="1" >
    <tr>
        <td></td>
    </tr>
    <tr>
        <td align="center">
            <asp:Image ID="imgSinget" runat="server" ImageUrl="~/Images/EmptyImg.jpg" Width="200" Height="200" />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:FileUpload ID="upFile" runat="server" Width="403px" 
               onchange="javascript:PreviewImage();"  />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnSave" runat="server" Text="上传图片" onclick="btnSave_Click" 
                UseSubmitBehavior="False" CssClass="buttonDefault" />
            &nbsp;
            <input id="Button2" type="button" value="取消上传" 
                onclick="javascript:GetReturnFile('a');" class="buttonDefault"  /></td>
    </tr>
</table>
    </div>
    </form>
</body>
</html>
