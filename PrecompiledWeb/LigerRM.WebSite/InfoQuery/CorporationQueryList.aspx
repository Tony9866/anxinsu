﻿<%@ page language="C#" autoeventwireup="true" inherits="InfoQuery_CorporationQueryList, App_Web_admd5buh" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>使用单位信息</title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script> 
    <script src="../lib/js/jquery.jqprint-0.3.js" type="text/javascript"></script> 
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <input type="hidden" id="MenuNo" value="CorporationQuery" />
  <div id="mainsearch" style=" width:98%">
    <div class="searchtitle">
        <span>搜索</span><img src="../lib/icons/32X32/searchtool.gif" />
        <div class="togglebtn"></div> 
    </div>
    <div class="navline" style="margin-bottom:4px; margin-top:4px;"></div>
    <div class="searchbox">
        <form id="formsearch" class="l-form"></form>
    </div>
  </div>
  <div id="maingrid"></div> 
  <script src="../BusinessJS/CorporationQueryList.js" type="text/javascript"></script> 
</body>
</html>
