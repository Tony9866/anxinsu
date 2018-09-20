<%@ page language="C#" autoeventwireup="true" inherits="ImageViewer, App_Web_5iuxsxpj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head runat="server">
    <title></title>
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <link href="../lib/css/jquery.gzoom.css" rel="stylesheet" type="text/css" />
    <link href="../lib/css/jquery-ui-1.7.1.custom.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../lib/gzoom/ui.core.min.js"></script>
    <script type="text/javascript" src="../lib/gzoom/ui.slider.min.js"></script>
    <script type="text/javascript" src="../lib/gzoom/jquery.mousewheel.js"></script> <!-- optional -->
    <script type="text/javascript" src="../lib/gzoom/jquery.gzoom.js"></script>
</head>
<body style="text-align:center;" oncontextmenu="return false" >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <%--        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <table border="0" cellpadding="0" cellspacing="0" width="860">
                    <tr>
                    <td valign="middle"><asp:ImageButton ID="btnLeft" runat="server" ImageUrl="~/Images/left.jpg" 
                                Width="110px" onclick="btnLeft_Click" /></td>
                        <td align="center" valign="middle" height="390" width="520" style="background-color:#dddddd; text-align:center;">
                        <div id="wrap" style="width:300px;margin:0 auto;">
                        <div id="zoom01"  style="margin:0 auto;">
                            <asp:Image ID="imgPic" runat="server" Height="390" Width="520" />
                            </div></div>
                        </td>
                        <td valign="middle"><asp:ImageButton ID="btnRight" runat="server" ImageUrl="~/Images/right.jpg" 
                                onclick="btnRight_Click" Width="110px" /></td>
                    </tr>
                    <tr><td colspan="3">
                        <asp:ImageButton ID="btRotateLeft" runat="server" ImageUrl="~/Images/left.jpg" 
                                 Width="50px" onclick="btRotateLeft_Click" />
                    &nbsp;<asp:ImageButton ID="btRotateRight" runat="server" ImageUrl="~/Images/right.jpg" 
                                 Width="50px" onclick="btRotateRight_Click" />
                    </td></tr>
                </table>
    <script type="text/javascript">
        function doNothing() {
            //window.event.returnValue = false;
            return true;
        }


      $(function() {
          var i = document.getElementById("<%=imgPic.ClientID %>");
          $("#wrap").css({ width: i.width });
        $zoom = $("#zoom01").gzoom({
            sW: i.width,
            sH: i.height,
            lW: i.width * 3,
            lH: i.height * 3,
            lighbox : true,
            zoomIcon: '../images/gtk-zoom-in.png'
        });
      });

    </script>


    </div>
    </form>
</body>
</html>
