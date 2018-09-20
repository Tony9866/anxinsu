<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="Test, App_Web_gl2v1pkx" %>
=======
<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="Test, App_Web_3k4kbla2" %>
=======
﻿<%@ page language="C#" autoeventwireup="true" inherits="Test, App_Web_zohai5sv" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

<%@ Register src="Dashboard/BaiduMap.ascx" tagname="BaiduMap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:DataList ID="dlImages" runat="server">
        <ItemTemplate>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Image ID="imgTarget" runat="server" />
<br />
                <asp:Button ID="btnLoad" runat="server" Text="Button" onclick="btnLoad_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnLoad" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </ItemTemplate>
        </asp:DataList>

    
    </div>
    </form>
</body>
</html>
