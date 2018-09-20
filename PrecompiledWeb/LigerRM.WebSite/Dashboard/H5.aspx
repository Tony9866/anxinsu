<%@ page language="C#" autoeventwireup="true" inherits="Dashboard_H5, App_Web_beoost5v" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>天津市河西区智慧社区</title>
    <style type="text/css">


.AjaxTabStrip .ajax__tab_tab
{
     text-align:center;
     vertical-align:middle;
    width: 105px; 
    background-image:url(../image/li/1.jpg);
}

.AjaxTabStrip .ajax__tab_hover .ajax__tab_tab
{
    font-weight:bold;
     color:#337ffd;
}

.AjaxTabStrip .ajax__tab_active .ajax__tab_tab
{
    background-image:url('../images/tablebk.png');
    background-position: left bottom;
    background-repeat:repeat-x;
    height:30px;
    font-weight:bold;
    vertical-align:middle;
    text-align:center;
    padding-top:5px;
    color:#337ffd;
}

.AjaxTabStrip .ajax__tab_body
{
    border: 0px solid #999999;
    padding: 0px;

}
        .style1
        {
            font-size: large;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=0.5, maximum-scale=2.0, user-scalable=yes" />
</head>
<body style="margin:0; background-color:#f1f1f1; font-family:微软雅黑">
<form runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td align="center" height="30" style="background-color:#337ffd;"><img src="../images/title.png" height="70%"/></td></tr>
            <tr><td align="center" height="30" valign="top">1e807f5cc1db6ca173d824653495aa73&#39;[&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td></tr>
            <tr><td height="5px" style=" background-color:#cccccc;"></td></tr>
            <tr><td style="">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr><td width="80%" align="left">
                    <iframe name="weather_inc" src="http://i.tianqi.com/index.php?c=code&id=48" height="45" frameborder="0" marginwidth="0" marginheight="0" scrolling="no"></iframe>
                    </td><td align="right" width="20%" style="padding-right:10px;">河西区</td></tr>
                </table>
            </td></tr>
            <tr><td height="5px" style=" background-color:#cccccc;"></td></tr>
            <tr><td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr><td width="25%"><a href="http://www.tjgaj.gov.cn/site/default.aspx"><img src="../Images/gov.png" width="100%" /></a></td><td width="25%">
                        <a href="guardtsapp://tenant.guardts.house/launcher"><img src="../Images/House.png" width="100%"  /></a></td><td width="25%">
                            <img src="../Images/Power.png" width="100%"  /></td><td width="25%">
                            <img src="../Images/P.png" width="100%"  /></td></tr>
                    <tr><td width="25%"><a href="http://www.tjxf.gov.cn/"><img src="../Images/XF.png" width="100%"  /></a></td><td width="25%">
                       <a href="http://m.haodf.com/touch/hospital/DE4roiYGYZwmj5uuYe-Bqregr.htm?from=alading"> <img src="../Images/hospital.png" width="100%"  /></a></td><td width="25%">
                            <a href="http://www.tjgaj.gov.cn/site/default.aspx"><img src="../Images/wq.png" width="100%"  /></a></td><td width="25%">
                            <a href="http://4g.enorth.com.cn/"><img src="../Images/more.png" width="100%"  /></a></td></tr>
                </table>
            </td></tr>
            <tr><td height="5px" style=" background-color:#cccccc;"></td></tr>
            <tr><td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr><td width="20%"><img src="../images/pIcon.png" width="100%" /></td><td width="30%">剩余车位<%= MOTOR_LEFTCOUNT %>个</td><td width="20%"><img src="../images/houseIcon.png" width="100%" /></td><td width="30%">剩余房间<%=HOUSE_LEFTCOUNT %>间</td></tr>
                </table>
            </td></tr>
            <tr><td height="5px" style=" background-color:#cccccc;"></td></tr>
            <tr><td align="center">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                    Width="100%" CssClass="AjaxTabStrip">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                    <HeaderTemplate>
实时热点
</HeaderTemplate>
<ContentTemplate>
         
    <table cellspacing="0" 
        
        style="margin: 0px auto; padding: 0px; border-width: 0px 0px 1px 1px; border-bottom-style: solid; border-left-style: solid; border-bottom-color: rgb(239, 239, 239); border-left-color: rgb(239, 239, 239); width: 100%; color: rgb(0, 0, 0); font-family: Simsun; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
        <tr>
            <th style="text-align: center; line-height: 26px; padding-top: 2px; color: rgb(73, 73, 73); font-weight: normal; border-style: solid; border-color: rgb(239, 239, 239); border-width: 1px 1px 0px 0px; background: rgb(255, 255, 255);" 
                width="10%">
                序号</th>
            <th style="text-align: center; line-height: 26px; padding-top: 2px; color: rgb(73, 73, 73); font-weight: normal; border-style: solid; border-color: rgb(239, 239, 239); border-width: 1px 1px 0px 0px; background: rgb(255, 255, 255);">
                新闻标题</th>
            <th style="text-align: center; line-height: 26px; padding-top: 2px; color: rgb(73, 73, 73); font-weight: normal; border-style: solid; border-color: rgb(239, 239, 239); border-width: 1px 1px 0px 0px; background: rgb(255, 255, 255);" 
                width="30%">
                媒体</th>
            <th style="text-align: center; line-height: 26px; padding-top: 2px; color: rgb(73, 73, 73); font-weight: normal; border-style: solid; border-color: rgb(239, 239, 239); border-width: 1px 1px 0px 0px; background: rgb(255, 255, 255);" 
                width="20%">
                时间</th>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                1</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://news.sina.com.cn/c/nd/2017-09-27/doc-ifymenmt7198342.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                长征五号失败原因或于年底查清 致探月任务推迟</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                科技日报</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-27 04:45</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                2</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://sports.sina.com.cn/china/j/2017-09-26/doc-ifymfcih6116575.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                巴甲豪门欲签高拉特 已联系球员或用哥国脚交换</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                新浪体育</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-26 21:56</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                3</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://news.sina.com.cn/o/2017-09-26/doc-ifymenmt7092403.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                这东西身价狂跌 2年前卖6千现在3千都卖不动</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                央视财经</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-26 17:13</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                4</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://sports.sina.com.cn/basketball/nba/2017-09-27/doc-ifymfcih6266924.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                与詹皇再续前缘!韦德将1年230万底薪加盟骑士</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                新浪体育</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-27 06:09</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                5</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://news.sina.com.cn/c/nd/2017-09-27/doc-ifymeswe0213944.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                侠客岛:十九大之前发布的这则重磅意见很有意味</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                人民日报海外版-海外网</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-27 01:27</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                6</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://news.sina.com.cn/o/2017-09-26/doc-ifymenmt7155348.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                印新书渲染洞朗内幕 称中国这件秘密武器逼退印</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                参考消息</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-26 21:45</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                7</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://news.sina.com.cn/o/2017-09-27/doc-ifymenmt7180006.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                中国游客大军国庆出境游在即 韩商家却早早放弃</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                参考消息</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-27 00:25</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                8</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://news.sina.com.cn/c/nd/2017-09-26/doc-ifymeswe0152188.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                这4类人今年确定要涨钱 看看有你吗</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                新华社</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-26 19:32</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                9</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://news.sina.com.cn/c/gat/2017-09-26/doc-ifymenmt7071233.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                台女星多次强调“中国台湾省”:这是在保护台湾</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                人民日报海外版-海外网</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-26 16:11</td>
        </tr>
        <tr>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                10</td>
            <td class="ConsTi" 
                style="margin: 0px; padding: 2px 0px 0px 6px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 14px; text-align: left; line-height: 28px; color: rgb(51, 51, 51);">
                <a href="http://sports.sina.com.cn/g/laliga/2017-09-27/doc-ifymfcih6251760.shtml" 
                    style="color: rgb(128, 0, 128); text-decoration: none;" target="_blank">
                欧冠-C罗梅开二度贝尔传射 皇马3-1客场首胜多特</a></td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                新浪体育</td>
            <td style="margin: 0px; padding: 2px 0px 0px; border-width: 1px 1px 0px 0px; border-top-style: solid; border-right-style: solid; border-top-color: rgb(239, 239, 239); border-right-color: rgb(239, 239, 239); font-size: 12px; text-align: center; line-height: 21px; color: rgb(51, 51, 51);">
                09-27 03:37</td>
        </tr>
    </table>
         
</ContentTemplate>
                    

</cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                    <HeaderTemplate>
生活资讯
</HeaderTemplate>
<ContentTemplate>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr><td>
    <img src="../images/midbanner.png" width="100%"/>   
    </td></tr>
    <tr><td height="30" style="padding:5px; font-weight:bold;">蔬菜价格</td></tr>
    <tr>
        <td style="padding:5px; text-align:left;">
            <asp:DataList ID="dlCai" runat="server" BackColor="#F1F1F1" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" 
                RepeatColumns="2" Width="100%" CellSpacing="3">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <ItemStyle ForeColor="#444444" Height="25px" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem,"name") %>价格：<%# decimal.Parse(DataBinder.Eval(Container.DataItem,"Price").ToString()).ToString("c") %>元
                </ItemTemplate>
                <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
        </td>
    </tr>
    <tr><td height="5px" style=" background-color:#cccccc;"></td></tr>
        <tr><td height="30" style="padding:5px; font-weight:bold;">水果价格</td></tr>
    <tr>
        <td style="padding:5px; text-align:left;">
            <asp:DataList ID="dlFruit" runat="server" BackColor="#F1F1F1" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" 
                RepeatColumns="2" Width="100%" CellSpacing="3">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <ItemStyle ForeColor="#444444" Height="25px" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem,"name") %>价格：<%# decimal.Parse(DataBinder.Eval(Container.DataItem,"Price").ToString()).ToString("c") %>元
                </ItemTemplate>
                <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
        </td>
    </tr>
</table>
  
</ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                    <HeaderTemplate>
周边商圈
</HeaderTemplate>
<ContentTemplate>
 <iframe src="http://m.dianping.com/tianjin?from=city_hot" width="100%" height="500px" style="border:none;"></iframe>          
</ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                    <HeaderTemplate>
智能家居
</HeaderTemplate>
                        <ContentTemplate>

                            <div class="g-article" 
                                style="margin: 0px; padding: 0px; color: rgb(51, 51, 51); font-family: 'Microsoft YaHei', 'Lucida Grande', 'Lucida Sans Unicode', STHeiti, Helvetica, Arial, Verdana, sans-serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16.8px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
                                <div ID="article_box" class="m-article" 
                                    style="margin: 0px; padding: 0px; font-size: 18px; color: rgb(51, 51, 51); line-height: 30px; width:100%overflow: hidden; text-align: center;">
                                    <div class="style1" 
                                        style="margin: 0px; padding: 15px 20px; background: rgb(241, 242, 243);">
                                        据说是90后最爱的十大智能家居产品……</div>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　一、智能恒温器</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　要说这真的是单身狗的福音了，可以代替暖被窝的人哦。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261029304287.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　夏天的空调、冬天的暖气，总是能让你生活在冰火两重天的世界，而这款智能恒温器就可以根据你的喜好，调节家里的温度;它搭载的定位功能，可以根据你离家的距离自动进行调节，让你刚进家门就感受到舒适的温度。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　二、智能马桶盖</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　这两年，日本2000元以上的马桶盖被我天朝民众扫劫一空，智能马桶盖就成了新一代网红。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261029305498.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　与传统马桶盖相比，智能马桶盖的亮点功能就是马桶圈加热、温水洗屁屁、烘干暖风，让你的菊花也感受到春天般的温暖。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　三、扫地<a href="http://www.wanwushuo.com/" key="" 
                                            style="cursor: pointer; text-decoration: none; color: rgb(11, 59, 140); font-size: 14px; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); border-bottom-width: 1px; border-bottom-style: dashed; border-bottom-color: rgb(17, 17, 17);" 
                                            target="_blank" title="机器人">机器人</a></p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261029313144.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　这可真是懒癌患者的一大福音了。扫地机器人都搭载了多点距阵<a href="http://www.wanwushuo.com/" key="" 
                                            style="cursor: pointer; text-decoration: none; color: rgb(11, 59, 140); font-size: 14px; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); border-bottom-width: 1px; border-bottom-style: dashed; border-bottom-color: rgb(17, 17, 17);" 
                                            target="_blank" title="人工智能">人工智能</a>系统，可以自动检测房子的方位，自动打扫，没电了还会自己乖乖跑去充电。不过，如果遇到犄角旮旯还是需要人工辅助的。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　四、脚踏洗衣机</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　这种洗衣机比较迷你，只能放进4斤半的衣物，而这正是单身狗最爱的款式。一件衣服放洗衣机洗太浪费，攒着一起洗又会把房子搞乱，不洗又不能放衣柜。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261029314667.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　这个脚踏洗衣机就可以解决这个问题了。它的容量比较小，放一件衣服进去也不会浪费，放水放洗衣液后，脚踏着那个踏板就可以轻松洗完衣服了，袜子等小的衣物也不用手洗了。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　但是这个也被人吐槽，懒癌单身狗就是不想动，你还让我用脚踏?</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　五、智能灯泡</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　是不是买灯泡的时候总是拿不准该买什么亮度和色调的?是不是拥有一颗年轻的心会厌倦一成不变的灯泡?智能灯泡就是来下凡拯救你的。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261029316083.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　智能灯泡是一种新的灯泡产品形式，采用嵌入式物联网核心技术，可以根据你的需要和喜好调节亮度和色调，营造不同的情境体验，甚至可以模拟提出日落的效果;还可以通过手机进行<a 
                                            href="http://www.qianjia.com/res/News/Search?Keyword=%E8%BF%9C%E7%A8%8B%E6%8E%A7%E5%88%B6&amp;System=%E6%99%BA%E8%83%BD%E5%AE%B6%E5%B1%85" 
                                            key="" 
                                            style="cursor: pointer; text-decoration: none; color: rgb(11, 59, 140); font-size: 14px; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); border-bottom-width: 1px; border-bottom-style: dashed; border-bottom-color: rgb(17, 17, 17);" 
                                            target="_blank" title="远程控制">远程控制</a>，这更是方便了瘫床上就不想动星人。有的智能灯泡还搭载了无线网络节点，还能省去路由器。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　六、智能锁</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261029324403.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　最开始的智能锁只有单一的密码解锁功能，但是发展到现在，它还具备了摄像、语音等功能，还可以通过手机解锁，在安全性和便利性上都有很大的提升。当然，手机可千万别弄丢哦。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　七、智能摄像头</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261029325721.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　智能摄像头最方便的就是可以通过手机、电脑端进行控制，随时可以查看家里的情况，对于家里有老人和宠物的童鞋来说最合适不过了。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　八、智能音箱</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　每天早上叫醒我的不是梦想(贫穷)，而是智能音箱。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261030367155.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　只要家里有WIFI，智能音箱就可以工作。通过它，你能跟方便的设置播放或者关闭音乐的时间，想一想伴随着自家爱豆的声音起床是不是很开心呢?</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　除此以外，智能音箱被尝试作为<a 
                                            href="http://www.qianjia.com/res/News/Search?Keyword=%E6%99%BA%E8%83%BD%E4%BD%8F%E5%AE%85&amp;System=%E6%99%BA%E8%83%BD%E5%AE%B6%E5%B1%85" 
                                            key="" 
                                            style="cursor: pointer; text-decoration: none; color: rgb(11, 59, 140); font-size: 14px; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); border-bottom-width: 1px; border-bottom-style: dashed; border-bottom-color: rgb(17, 17, 17);" 
                                            target="_blank" title="智能家居系统">智能家居系统</a>的入口，也就是说，你通过与智能音箱进行语音，就可以控制家里所有的<a 
                                            href="http://smarthome.qianjia.com/" key="" 
                                            style="cursor: pointer; text-decoration: none; color: rgb(11, 59, 140); font-size: 14px; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); border-bottom-width: 1px; border-bottom-style: dashed; border-bottom-color: rgb(17, 17, 17);" 
                                            target="_blank" title="智能家居">智能家居</a>，当然目前的技术水平，仍未能完美实现。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　九、智能插座</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261030368258.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　智能插座的最大的亮点在于，它新加了无线节点、充电保护、各种电子产品插头等新功能，可以通过手机APP对插座进行掌控。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　十、毛巾烘干机</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: center; width:100%overflow: hidden; font-size: 16px;">
                                        <img alt="" 
                src="http://www.qianjia.com/Upload/News/20170926/images/201709261030369391.jpg" 
                style="border: 0px; vertical-align: middle; display: block; width: 100%; margin: 0px auto; height: auto; max-width: 100%; max-height: 100%;" />
                                    </p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width: 100%; overflow: hidden; font-size: 16px;">
                                        　　毛巾放在卫生间方便使用，但是潮湿的环境不仅容易让毛巾有异味，而且也为细菌提供了温床。而毛巾烘干机内置的空气干燥装置，可以快速把毛巾烘干，同时还可以通过紫外线射灯进行杀菌。</p>
                                    <p style="margin: 25px 0px; padding: 0px; letter-spacing: 0.2px; text-align: left; width:100%overflow: hidden; font-size: 16px;">
                                        　　这几种<a 
                                            href="http://www.qianjia.com/res/News/Search?Keyword=%E6%99%BA%E8%83%BD%E7%AA%97%E5%B8%98&amp;System=%E6%99%BA%E8%83%BD%E5%AE%B6%E5%B1%85" 
                                            key="" 
                                            style="cursor: pointer; text-decoration: none; color: rgb(11, 59, 140); font-size: 14px; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); border-bottom-width: 1px; border-bottom-style: dashed; border-bottom-color: rgb(17, 17, 17);" 
                                            target="_blank" title="智能家居产品">智能家居产品</a>，有让你心动的吗?</p>
                                </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            
            </td></tr>
        </table></form>
</body>
</html>
