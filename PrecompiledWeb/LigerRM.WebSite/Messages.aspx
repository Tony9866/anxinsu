<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="Messages, App_Web_gl2v1pkx" %>
=======
<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="Messages, App_Web_3k4kbla2" %>
=======
﻿<%@ page language="C#" autoeventwireup="true" inherits="Messages, App_Web_zohai5sv" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

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
    <script src="../lib/js/jquery.jqprint-0.3.js" type="text/javascript"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            
        <script type="text/javascript">
            function f_view(id) {
                parent.$.ligerDialog.open({ height: 440, width: 620, url: '../BaseManage/MessageDetail.aspx?EditType=V&Id=' + id + "&userLevel=<%=SysContext.CurrentDeptID %>" + "&carveId=<%=SysContext.CurrentCarveIDs %>", title: '发布信息' });
            }
        </script>
        <asp:Repeater ID="rptMessage" runat="server">
            <ItemTemplate>
            <tr><td style="color:Blue;height:25px;"><li style="list-style-type: square; list-style-position: inside"><a href="#" onclick="javascript:f_view('<%# Eval("wt_serial_id").ToString() %>');"><%# Eval("wt_title").ToString()%></a>&nbsp;&nbsp;<span style="color:Gray">[<%# Eval("wt_time").ToString()%>]</span></li></td></tr>
            </ItemTemplate>
        </asp:Repeater></table>
    </div>
    </form>
</body>
</html>
