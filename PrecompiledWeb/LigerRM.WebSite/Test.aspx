<%@ page language="C#" autoeventwireup="true" inherits="Test, App_Web_3k4kbla2" %>

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
