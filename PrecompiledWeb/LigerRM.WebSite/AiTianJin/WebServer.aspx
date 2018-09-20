<%@ page language="C#" autoeventwireup="true" inherits="AiTianJin_WebServer, App_Web_vqv1r35l" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <script src="../lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
</head>
<body>
   <form id="form1" method="post" action="?Action=Login" >
    <div>
        <input type="submit" value="查询用户认证数据" />
        <br /><br />
        
    </div>
    </form>
     <form id="form2" method="post" action="?Action=spideInfo" >
    <div>
        <input type="submit" value="探针查询数据" />
        <br /><br />
    </div>
    </form>
      <form id="form3" method="post" action="?Action=userWechat" >
    <div>
        请输入mac地址:<input type="text" name="mac" value="" /><br />
        <input type="submit" value="用户微信信息查询" />
        <br /><br />
    </div>
    </form>
     <form id="form4" method="post" action="?Action=userAdInfo" >
    <div>
     请输入mac地址:<input type="text" name="mac" value="" /><br />
        <input type="submit" value="页面广告浏览记录" />
        <br /><br />
    </div>
    </form>
      <form id="form5" method="post" action="?Action=wifiStatic" >
    <div>
     请输入mac地址:<input type="text" name="mac" value="" /><br />
        <input type="submit" value=" wifi设备WiFi连网记录" />
        <br /><br />
    </div>
    </form>
     <form id="form6" method="post" action="?Action=authStatic" >
    <div>
    请输入mac地址:<input type="text" name="mac" value="" /><br />
        <input type="submit" value=" wifi设备认证记录" />
        <br /><br />
    </div>
    </form>
      <form id="form7" method="post" action="?Action=passStatic" >
    <div>
     请输入mac地址:<input type="text" name="mac" value="" /><br />
        <input type="submit" value=" 认证放行记录" />
        <br /><br />
    </div>
    </form>
</body>
</html>
