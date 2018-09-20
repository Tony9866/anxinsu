<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="MotorManage_AlertInfoList, App_Web_pllqux4z" %>
=======
﻿<%@ page language="C#" autoeventwireup="true" inherits="MotorManage_AlertInfoList, App_Web_pwpc5inb" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>预警信息</title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerTab.js" type="text/javascript"></script>
</head>
<body style="padding:10px;height:100%; text-align:center;">
     <div id="mainbody" class="l-mainbody" style="width:99.2%; margin:0 auto; margin-top:3px;" >
        <div position="center" id="framecenter"> 
            <div tabid="person" title="人员信息"> 
                <iframe frameborder="0" name="person" id="person" src="PersonList.aspx"></iframe>
            </div> 
            <div tabid="home" title="车辆信息"> 
                <iframe frameborder="0" name="home" id="home" src="MotorList.aspx"></iframe>
            </div> 
        </div> 
    </div>

    <script type="text/jscript">
        //几个布局的对象
        var layout, tab, accordion;
        //tabid计数器，保证tabid不会重复
        var tabidcounter = 0;
        //窗口改变时的处理函数
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        $(document).ready(function () {
            //布局初始化 
            //layout
            layout = $("#mainbody").ligerLayout({ height: '100%', heightDiff: -3, leftWidth: 190, onHeightChanged: f_heightChanged, minLeftWidth: 120 });
            var bodyHeight = $(".l-layout-center:first").height();
            //Tab
            tab = $("#framecenter").ligerTab({ height: bodyHeight, contextmenu: true });
        });
    </script>
</body>
</html>
