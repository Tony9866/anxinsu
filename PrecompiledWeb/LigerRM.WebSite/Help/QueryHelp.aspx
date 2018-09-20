<%@ page language="C#" autoeventwireup="true" inherits="Help_QueryHelp, App_Web_u5puopkp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>关于系统-信息查询</title>
        <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script> 
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-left:20px;">
 
    <div style="width:800px; ">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td width="12.5%" height="26" style="font-weight:bold;"><strong>目录：</strong></td>
            <td width="12.5%" height="26">
            &nbsp;</td><td width="12.5%" height="26">
                &nbsp;</td><td width="12.5%" height="26">&nbsp;</td><td width="12.5%" 
                height="26" style="font-weight:bold;">&nbsp;</td><td width="12.5%" height="26">
            &nbsp;</td><td width="12.5%" height="26">
                &nbsp;</td><td width="12.5%" height="26">&nbsp;</td></tr>
        <tr><td width="12.5%" height="26"><a href="#" onclick="top.f_addTab(null, '关于系统-系统框架', '../help/SysHelp.aspx');">1.系统框架</a></td><td width="12.5%" height="26"><a href="#" onclick="top.f_addTab(null, '关于系统-信息登记', '../help/RegisterHelp.aspx');">2.信息登记</a></td>
            <td width="12.5%" height="26">
            <a href="#" onclick="top.f_addTab(null, '关于系统-信息管理', '../help/ManageHelp.aspx');">3.信息管理</a></td><td width="12.5%" height="26"><a href="#" onclick="top.f_addTab(null, '关于系统-信息查询', '../help/QueryHelp.aspx');">4.信息查询</a></td>
        <td width="12.5%" height="26"><a href="#" onclick="top.f_addTab(null, '关于系统-信息统计', '../help/StatisticHelp.aspx');">5.信息统计</a></td><td width="12.5%" height="26"><a href="#" onclick="top.f_addTab(null, '关于系统-基础信息', '../help/BaseHelp.aspx');">6.基础信息</a></td>
            <td width="12.5%" height="26">
            <a href="#" onclick="top.f_addTab(null, '关于系统-生产系统', '../help/CarveHelp.aspx');">7.生产系统</a></td><td width="12.5%" height="26"><a href="#" onclick="top.f_addTab(null, '关于系统-系统管理', '../help/AdminHelp.aspx');">8.系统管理</a></td></tr>
    </table></div>
    <hr style="border:2px solid #cccccc;" />
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr><td>4.信息查询</td></tr>
        <tr><td class="style1">Step 1：印章信息查询</td></tr>
        <tr><td style="padding-left:10px;">
            点击左侧“印章信息查询”菜单，在打开的页面中，进行信息查询。</td></tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/SignetQuery.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 2：使用单位信息查询</td>
        </tr>
        <tr><td style="padding-left:10px;">点击左侧“使用单位信息查询”菜单，在打开的页面中，进行信息查询。</td></tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/CorporationQuery.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 3：制章单位信息查询</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">点击左侧“制章单位信息查询”菜单，在打开的页面中，进行信息查询。</td>
        </tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/CarveCorpQuery.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 4：接章单位信息查询</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">点击左侧“接章单位信息查询”菜单，在打开的页面中，进行信息查询。</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">
            <img src="../Images/Help/AcceptQuery.png" 
                width="800" /></td>
        </tr>
        <tr><td style="padding-left:10px;">
            &nbsp;</td></tr>
    </table>
    </div>
    </form>
</body>
</html>
