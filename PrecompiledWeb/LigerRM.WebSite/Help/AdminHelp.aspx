<%@ page language="C#" autoeventwireup="true" inherits="Help_AdminHelp, App_Web_u5puopkp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>关于系统-系统管理</title>
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
        <tr><td>8.系统管理</td></tr>
        <tr><td class="style1">Step 1：用户管理</td></tr>
        <tr><td style="padding-left:10px;">
            点击左侧“用户管理”菜单，在打开的页面中，点击“新增”添加一个新的用户。</td></tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/UserManage.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 2：角色管理</td>
        </tr>
        <tr><td style="padding-left:10px;">点击左侧“角色管理”菜单，在打开的页面中，点击“增加”添加一个新的角色。</td></tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/RoleManage.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 3：权限中心</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">点击左侧“权限中心”菜单，在打开的页面中，分配用户或者角色的权限。</td>
        </tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/Privalige.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 4：数据权限</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">点击左侧“数据权限”菜单，在打开的页面中，分配用户或者角色的数据使用权限。</td>
        </tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/DataPrivalige.png" 
                width="800" /></td></tr>
        <tr>
            <td style="">Step 4：菜单管理</td>
        </tr>
        <tr>
            <td style="padding-left:10px;">点击左侧“菜单管理”菜单，在打开的页面中，控制系统的菜单。</td>
        </tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/MenuManage.png" 
                width="800" /></td></tr>
        <tr><td style="padding-left:10px;">
            对于每一个菜单，进行菜单按钮的管理。</td></tr>
        <tr><td style="padding-left:10px;">
            <img src="../Images/Help/ButtonManage.png" 
                width="800" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
