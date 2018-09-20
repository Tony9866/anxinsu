<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="Help_ManageHelp, App_Web_tghrto2f" %>
=======
<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="Help_ManageHelp, App_Web_4ym522yy" %>
=======
﻿<%@ page language="C#" autoeventwireup="true" inherits="Help_ManageHelp, App_Web_b1vjgpmq" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>关于系统-系统框架</title>
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
        <tr><td>3.信息管理</td></tr>
        <tr><td class="style1">Step 1：印章备案</td></tr>
        <tr><td style="padding-left:10px;">
            点击左侧“印章备案”菜单，在打开的页面中，点击“增加备案印章”备案需要备案的印章。</td></tr>
        <tr><td style="padding-left:10px;"><img src="../Images/Help/SignetApprove.png" 
                width="800" /></td></tr>
        <tr>
            <td style="padding-left:10px;">
                系统提供备案提醒功能，每隔10分钟，系统会提示印章备案信息，点击后直接进入备案界面。如下图右下角。</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">
                <img src="../Images/Help/AutoApprove.png" width="800" /></td>
        </tr>
        <tr>
            <td style="padding-left:10px;">
                备案印章后，可进行印章打单。</td>
        </tr>
        <tr>
            <td style="padding-left:10px;" class="style1">
                <img src="../Images/Help/PrintOrder.png" width="800" /></td>
        </tr>
        <tr><td style="">Step 2：印章缴销</td></tr>
        <tr><td style="padding-left:10px;">
            点击左侧“印章缴销”菜单，在打开的页面中，选中已交付的印章进行印章缴销。</td></tr>
        <tr><td style="padding-left:10px;"><img src="../Images/Help/SignetDestroy.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 3：印章报废</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">
                点击左侧“印章报废”菜单，在打开的页面中，选中已交付的印章进行印章报废。</td>
        </tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/SignetCancel.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 4：印章挂失</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">
                点击左侧“印章挂失”菜单，在打开的页面中，选中已交付的印章进行印章挂失。</td>
        </tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/SignetLoss.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 5：印章年检</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">
                点击左侧“印章年检”菜单，在打开的页面中，选中已交付的印章进行印章年检。</td>
        </tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/SignetCheck.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 6：印章上传</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">
                点击左侧“印章上传”菜单，在打开的页面中，选中已交付的印章上传到省级汇总系统中。</td>
        </tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/SignetUpload.png" 
                width="800" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
