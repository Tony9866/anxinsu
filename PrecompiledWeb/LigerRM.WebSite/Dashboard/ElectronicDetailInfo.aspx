<%@ page language="C#" autoeventwireup="true" inherits="Dashboard_ElectronicDetailInfo, App_Web_gmqoropr" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 12.75pt;
            width: 64pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style2
        {
            width: 64pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style3
        {
            width: 133pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style4
        {
            width: 80pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style5
        {
            width: 135pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style6
        {
            width: 101pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style7
        {
            width: 48pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style8
        {
            height: 12.75pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style9
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style10
        {
            height: 12.75pt;
            width: 66pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style11
        {
            width: 66pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style12
        {
            width: 137pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style13
        {
            width: 77pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style14
        {
            width: 179pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style15
        {
            width: 62pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style16
        {
            height: 12.75pt;
            width: 67pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style17
        {
            width: 136pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style18
        {
            width: 87pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style19
        {
            width: 123pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style20
        {
            width: 119pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
    </style>
</head>
<body  style="background-image:url('../images/opbk.png');">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div style="width:100%; text-align:center; font-size:24px; color:White;">用户用电信息</div>
        <br />

        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            Width="100%">
            <cc1:TabPanel runat="server" HeaderText="环湖南里24-101" ID="TabPanel1">
            <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:785pt" width="1044">

        <tr height="17">
            <td class="style1" height="17" width="85">
                用户编号</td>
            <td class="style2" width="85">
                用户名称</td>
            <td class="style2" width="85">
                电表相线</td>
            <td class="style3" width="177">
                电表条码</td>
            <td class="style4" width="106">
                出厂编号</td>
            <td class="style5" width="180">
                用户地址</td>
            <td class="style6" width="134">
                数据时间</td>
            <td class="style7" width="64">
                购电次数</td>
            <td class="style7" width="64">
                剩余金额</td>
            <td class="style7" width="80">
                总购电金额</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-28 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                117.03</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-27 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                118.8</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-26 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                121.11</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-25 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                123.85</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-24 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                125.83</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-23 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                127.64</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-22 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                129.6</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-21 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                131.74</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-20 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                133.71</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-19 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                135.98</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-18 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                138.42</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-17 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                140.75</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-16 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                144.39</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-15 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                146.89</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-14 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                148.75</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-13 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                150.93</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-12 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                153.65</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-11 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                157.04</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-10 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                160.49</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-09 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                164.14</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-08 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                169.64</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-07 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                173.71</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-06 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                176.33</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-05 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                178.26</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-04 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                180.79</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-03 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                183.3</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-02 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                186.67</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-09-01 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                188.7</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-31 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                190.89</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-30 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                193.19</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-29 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                195.93</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-28 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                199.24</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-27 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                202.03</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-26 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                205.32</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-25 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                210.76</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-24 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                220.72</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-23 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                225.17</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-22 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                232.67</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-21 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                245.86</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-20 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                259.6</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-19 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                273.4</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-18 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                282.35</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-17 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                284.4</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-16 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                289.7</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-15 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                293.46</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-14 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                297.8</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-13 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                302.9</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-12 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                307.41</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-11 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                314.27</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-10 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                319.74</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-09 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                323.94</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-08 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                327.89</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-07 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                331.91</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-06 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                336.2</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-05 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                340.66</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-04 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                346.47</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-03 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                350.61</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-02 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                354.46</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-08-01 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                357.79</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-31 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                360.66</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-30 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                363.55</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-29 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                366.28</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-28 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                369.69</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-27 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                372.88</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-26 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                375.71</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-25 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                381.99</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-24 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                389.92</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-23 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                397.61</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-22 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                402.64</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-21 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                411.8</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-20 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                421.59</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-19 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                431.67</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-18 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                441.1</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-17 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                451.95</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-16 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                461.46</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-15 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                473.16</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-14 00:00:00</td>
            <td align="right" class="style9">
                16</td>
            <td align="right" class="style9">
                486.35</td>
            <td align="right" class="style9">
                8555.08</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-13 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                10.11</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-12 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                20.39</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-11 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                27.77</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-10 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                35.37</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-09 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                43.51</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-08 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                51.23</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-07 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                58.28</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-06 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                65.61</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-05 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                72.69</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-04 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                81.2</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-03 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                86.04</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-02 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                92.24</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-07-01 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                101.23</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-30 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                109.9</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-29 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                115.99</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-28 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                120.51</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-27 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                127.93</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-26 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                133.42</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-25 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                135.69</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-24 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                139.6</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-23 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                142.69</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-22 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                144.79</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-21 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                152.55</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-20 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                156.44</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-19 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                162.45</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-18 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                174.32</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-17 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                185.08</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-16 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                191.7</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-15 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                194.76</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-14 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                197.47</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-13 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                199.77</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-12 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                202.32</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-11 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                205.55</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-10 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                208.47</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-09 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                210.94</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-08 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                213.99</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-07 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                216.56</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-06 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                218.71</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-05 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                220.72</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-04 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                223.17</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-03 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                225.68</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-02 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                228.29</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0008145198</td>
            <td class="style9">
                杨金利</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126091100027131068</td>
            <td class="style9">
                122110005820</td>
            <td class="style9">
                环湖中路环湖南里24-101</td>
            <td class="style9">
                2017-06-01 00:00:00</td>
            <td align="right" class="style9">
                15</td>
            <td align="right" class="style9">
                232.99</td>
            <td align="right" class="style9">
                8068.68</td>
        </tr>
    </table>
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="环湖南里24-305">
                <ContentTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:797pt" width="1061">

                        <tr height="17">
                            <td class="style10" height="17" width="88">
                                用户编号</td>
                            <td class="style11" width="88">
                                用户名称</td>
                            <td class="style11" width="88">
                                电表相线</td>
                            <td class="style12" width="182">
                                电表条码</td>
                            <td class="style13" width="102">
                                出厂编号</td>
                            <td class="style14" width="238">
                                用户地址</td>
                            <td class="style7" width="64">
                                数据时间</td>
                            <td class="style7" width="64">
                                购电次数</td>
                            <td class="style7" width="64">
                                剩余金额</td>
                            <td class="style15" width="83">
                                总购电金额</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-28 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                396.36</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-27 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                398.61</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-26 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                400.56</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-25 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                402.14</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-24 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                405.03</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-23 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                406.83</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-22 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                408.14</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-21 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                411.1</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-20 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                411.65</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-19 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                414.59</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-18 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                415.97</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-17 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                417.7</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-16 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                421</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-15 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                423.62</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-14 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                426.46</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-13 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                427.09</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-12 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-11 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                445.42</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-10 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-09 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                459.35</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-08 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                462.85</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-07 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                479.5</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-06 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                482.27</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-05 00:00:00</td>
                            <td align="right" class="style9">
                                14</td>
                            <td align="right" class="style9">
                                495.16</td>
                            <td align="right" class="style9">
                                6073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-04 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                0</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-03 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-02 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-09-01 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                18.95</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-31 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-30 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                23.66</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-29 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-28 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                32.77</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-27 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-26 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                42.06</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-25 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                48.13</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-24 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-23 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-22 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-21 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                74.98</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-20 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                84.35</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-19 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                87.01</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-18 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                97.99</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-17 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                102.52</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-16 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                107.49</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-15 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                112.14</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-14 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                117.67</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-13 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                124.49</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-12 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                129.07</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-11 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-10 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-09 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-08 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-07 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                173.43</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-06 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                183.47</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-05 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-04 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                191.39</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-03 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                203.06</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-02 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                211.77</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-08-01 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                220.44</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-31 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                229.56</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-30 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                237.3</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-29 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                242.82</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-28 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-27 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                253.99</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-26 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                254.9</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-25 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-24 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-23 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                265.52</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-22 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                270.72</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-21 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                273.43</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-20 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                279.96</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-19 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                288.28</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-18 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                294.53</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-17 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-16 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                302.93</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-15 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-14 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-13 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                340.1</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-12 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-11 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                355.51</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-10 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                367.8</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-09 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-08 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-07 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-06 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                392.41</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-05 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                406.23</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-04 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-03 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-02 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                434.49</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-07-01 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                447.86</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-30 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                451.64</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-29 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                465.4</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-28 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                474.13</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-27 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                477.96</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-26 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                487.35</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-25 00:00:00</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                            <td class="style9">
                                　</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-24 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                494.19</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-23 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                496.1</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-22 00:00:00</td>
                            <td align="right" class="style9">
                                13</td>
                            <td align="right" class="style9">
                                498.87</td>
                            <td align="right" class="style9">
                                5573.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-21 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                2.37</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-20 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                3.02</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-19 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                3.92</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-18 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                4.96</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-17 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                5.84</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-16 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                8.85</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-15 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                11.06</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-14 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                11.8</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-13 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                13.3</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-12 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                14.94</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-11 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                17.92</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-10 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                19.45</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-09 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                24.29</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-08 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                25.75</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-07 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                27.96</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-06 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                30.13</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-05 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                31.97</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-04 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                35.03</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-03 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                35.77</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-02 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                38.66</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                        <tr height="17">
                            <td class="style8" height="17">
                                0025952689</td>
                            <td class="style9">
                                周卫平</td>
                            <td class="style9">
                                单相</td>
                            <td class="style9">
                                1210126089900035059973</td>
                            <td class="style9">
                                105110029475</td>
                            <td class="style9">
                                河西区体院北环湖南里(7区)24门305</td>
                            <td class="style9">
                                2017-06-01 00:00:00</td>
                            <td align="right" class="style9">
                                12</td>
                            <td align="right" class="style9">
                                39.73</td>
                            <td align="right" class="style9">
                                5073.5</td>
                        </tr>
                    </table>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="环湖南里32-205">
            <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:826pt" width="1100">
        <tr height="17">
            <td class="style16" height="17" width="89">
                用户编号</td>
            <td class="style7" width="64">
                用户名称</td>
            <td class="style7" width="64">
                电表相线</td>
            <td class="style17" width="181">
                电表条码</td>
            <td class="style18" width="116">
                出厂编号</td>
            <td class="style19" width="164">
                用户地址</td>
            <td class="style20" width="158">
                数据时间</td>
            <td class="style11" width="88">
                购电次数</td>
            <td class="style11" width="88">
                剩余金额</td>
            <td class="style11" width="88">
                总购电金额</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-28 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                239.6</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-27 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                241.82</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-26 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                243.03</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-25 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                244.63</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-24 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                246.6</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-23 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                247.53</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-22 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                249.09</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-21 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                250.51</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-20 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                251.96</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-19 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                253.46</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-18 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                255</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-17 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                256.49</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-16 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                258.08</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-15 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                259.61</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-14 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                261.37</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-13 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                263.19</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-12 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                264.98</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-11 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                266.86</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-10 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                269.03</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-09 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                273.73</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-08 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                278.42</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-07 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                280.38</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-06 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                282.54</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-05 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                284.67</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-04 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                286.68</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-03 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                288.84</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-02 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                290.84</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-09-01 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                295.33</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-31 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                297.65</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-30 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                299.68</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-29 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                301.97</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-28 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                305.12</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-27 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                307.38</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-26 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                309.95</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-25 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                314.17</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-24 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                321.36</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-23 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                325.86</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-22 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                331.12</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-21 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                339.01</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-20 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                345.19</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-19 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                350.72</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-18 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                354.61</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-17 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                358.78</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-16 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                363.83</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-15 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                368.46</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-14 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                372.72</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-13 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                378.32</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-12 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                383.57</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-11 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                393.04</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-10 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                402.19</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-09 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                408.92</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-08 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                417.64</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-07 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                423.44</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-06 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                430.74</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-05 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                435.45</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-04 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                446.98</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-03 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                453.11</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-02 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                460.94</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-08-01 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                466.39</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-31 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                469.85</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-30 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                471.94</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-29 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                474.56</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-28 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                477.44</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-27 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                479.84</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-26 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                482.24</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-25 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                488.84</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-24 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                494.19</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-23 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                496.94</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-22 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                500.04</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-21 00:00:00</td>
            <td align="right" class="style9">
                9</td>
            <td align="right" class="style9">
                504.77</td>
            <td align="right" class="style9">
                3875.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-20 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                13.95</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-19 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                20.58</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-18 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                27.45</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-17 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                35.29</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-16 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                45.15</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-15 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                53.13</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-14 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                65.9</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-13 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                78.89</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-12 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                92.62</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-11 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                104</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-10 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                113.04</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-09 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                123.99</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-08 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                134.53</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-07 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                143.69</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-06 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                150.04</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-05 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                155.14</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-04 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                162.62</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-03 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                170.58</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-02 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                183.55</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-07-01 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                193.24</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-30 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                203.5</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-29 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                208.76</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-28 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                218.24</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-27 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                224.95</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-26 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                228.71</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-25 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                234.06</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-24 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                237.76</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-23 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                240.22</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-22 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                243.62</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-21 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                249.99</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-20 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                256.11</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-19 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                267.53</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-18 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                278.68</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-17 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                289.24</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-16 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                296.99</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-15 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                299.15</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-14 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                300.68</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-13 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                301.91</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-12 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                303.95</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-11 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                306.31</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-10 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                311.48</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-09 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                322.49</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-08 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                324.74</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-07 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                325.64</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-06 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                326.49</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-05 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                327.39</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-04 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                328.4</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-03 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                329.41</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-02 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                330.49</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
        <tr height="17">
            <td class="style8" height="17">
                0006496904</td>
            <td class="style9">
                何占海</td>
            <td class="style9">
                单相</td>
            <td class="style9">
                1210126001300024736731</td>
            <td class="style9">
                124110044466</td>
            <td class="style9">
                体北环湖南里32-205</td>
            <td class="style9">
                2017-06-01 00:00:00</td>
            <td align="right" class="style9">
                8</td>
            <td align="right" class="style9">
                331.45</td>
            <td align="right" class="style9">
                3375.46</td>
        </tr>
    </table>
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="环湖南里33号-5">
            <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:746pt" width="994">

            <tr height="17" style="height:12.75pt">
                <td class="style1" height="17" width="83">
                    用户编号</td>
                <td class="style2" width="64">
                    用户名称</td>
                <td class="style2" width="64">
                    电表相线</td>
                <td class="style3" width="176">
                    电表条码</td>
                <td class="style4" width="114">
                    出厂编号</td>
                <td class="style5" width="164">
                    用户地址</td>
                <td class="style6" width="137">
                    数据时间</td>
                <td class="style2" width="64">
                    购电次数</td>
                <td class="style2" width="64">
                    剩余金额</td>
                <td class="style2" width="64">
                    总购电金额</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-28 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    241.95</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-27 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    245.17</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-26 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    247.14</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-25 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    250.38</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-24 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    253.03</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-23 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    255.6</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-22 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    258.49</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-21 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    261.45</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-20 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    263.96</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-19 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    267.19</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-18 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    271.85</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-17 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    274.52</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-16 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    279.8</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-15 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    283.14</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-14 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    286.47</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-13 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    289.98</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-12 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    292.96</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-11 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    296.28</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-10 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    300.73</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-09 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    305.77</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-08 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    309.84</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-07 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    312.3</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-06 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    316.48</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-05 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    320.58</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-04 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    323.24</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-03 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    326.27</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-02 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    329.19</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-09-01 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    333.24</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-31 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    336.17</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-30 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    339.75</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-29 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    343.05</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-28 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    346.85</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-27 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    352.39</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-26 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    359.3</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-25 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    365.91</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-24 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    378.48</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-23 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    389.94</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-22 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    398.93</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-21 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    408.47</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-20 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    414.9</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-19 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    425.01</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-18 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    433.74</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-17 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    440.47</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-16 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    451.95</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-15 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    465.02</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-14 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    474.69</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-13 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    484.6</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-12 00:00:00</td>
                <td align="right" class="style8">
                    29</td>
                <td align="right" class="style8">
                    495.94</td>
                <td align="right" class="style8">
                    13396.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-11 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    14.68</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-10 00:00:00</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-09 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    43.55</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-08 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    62.26</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-07 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    80.08</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-06 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    96.02</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-05 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    110.58</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-04 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    126.2</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-03 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    140.66</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-02 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    151.63</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-08-01 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    165.41</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-31 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    173.74</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-30 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    179.01</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-29 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    182.37</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-28 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    188.08</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-27 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    195.38</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-26 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    200.44</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-25 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    212.69</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-24 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    227.28</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-23 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    238.56</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-22 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    247.28</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-21 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    261.36</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-20 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    285.04</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-19 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    300.47</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-18 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    319.98</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-17 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    333.44</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-16 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    348.51</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-15 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    367.88</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-14 00:00:00</td>
                <td align="right" class="style8">
                    28</td>
                <td align="right" class="style8">
                    388.14</td>
                <td align="right" class="style8">
                    12896.9</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-13 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    4.55</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-12 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    24.17</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-11 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    43.43</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-10 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    59.33</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-09 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    75.12</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-08 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    91.97</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-07 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    105.51</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-06 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    117</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-05 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    130.74</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-04 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    140.81</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-03 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    154.2</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-02 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    169.75</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-07-01 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    182.77</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-30 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    197.99</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-29 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    212.74</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-28 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    228.09</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-27 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    240.85</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-26 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    249.84</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-25 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    256.31</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-24 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    262.37</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-23 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    267.78</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-22 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    272.15</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-21 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    283.53</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-20 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    296.18</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-19 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    306.41</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-18 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    311.67</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-17 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    318.94</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-16 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    325.67</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-15 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    330.31</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-14 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    336.3</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-13 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    340.26</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-12 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    345.61</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-11 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    350.25</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-10 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    354.23</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-09 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    358.61</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-08 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    362.92</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-07 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    367.72</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-06 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    372.99</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-05 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    379.22</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-04 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    385.05</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-03 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    390.56</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-02 00:00:00</td>
                <td align="right" class="style8">
                    27</td>
                <td align="right" class="style8">
                    394.86</td>
                <td align="right" class="style8">
                    12493.2</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002717643</td>
                <td class="style8">
                    魏英萍</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024960822</td>
                <td class="style8">
                    124110066875</td>
                <td class="style8">
                    体北环湖南里33号-5</td>
                <td class="style8">
                    2017-06-01 00:00:00</td>
                <td align="right" class="style8">
                    26</td>
                <td align="right" class="style8">
                    0</td>
                <td align="right" class="style8">
                    12093.2</td>
            </tr>
        </table>
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="环湖南里35-404-406">
            <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:799pt" width="1063">

            <tr height="17" style="height:12.75pt">
                <td class="style9" height="17" width="97">
                    用户编号</td>
                <td class="style2" width="64">
                    用户名称</td>
                <td class="style2" width="64">
                    电表相线</td>
                <td class="style10" width="174">
                    电表条码</td>
                <td class="style11" width="101">
                    出厂编号</td>
                <td class="style12" width="196">
                    用户地址</td>
                <td class="style13" width="136">
                    数据时间</td>
                <td class="style14" width="77">
                    购电次数</td>
                <td class="style14" width="77">
                    剩余金额</td>
                <td class="style14" width="77">
                    总购电金额</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-28 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    414.17</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-27 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    416.32</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-26 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    419.92</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-25 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    425.65</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-24 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    427.17</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-23 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    428.87</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-22 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    431.1</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-21 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    433.86</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-20 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    435.92</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-19 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    438.89</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-18 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    441.78</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-17 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    444.34</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-16 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    447.05</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-15 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    450.17</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-14 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    453.12</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-13 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    455.74</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-12 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    458.41</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-11 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    460.72</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-10 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    464.45</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-09 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    466.28</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-08 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    468.64</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-07 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    475.54</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-06 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    480.66</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-05 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    486.04</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-04 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    491.67</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-03 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    494.16</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-02 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    495.65</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-09-01 00:00:00</td>
                <td align="right" class="style8">
                    22</td>
                <td align="right" class="style8">
                    497.14</td>
                <td align="right" class="style8">
                    9228.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-31 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    199.28</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-30 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    201.22</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-29 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    202.77</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-28 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    204.35</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-27 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    206.1</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-26 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    208.7</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-25 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    211.39</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-24 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    213.79</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-23 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    215.99</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-22 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    218.73</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-21 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    221.93</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-20 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    224.38</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-19 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    227.1</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-18 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    229.71</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-17 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    232.02</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-16 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    235.36</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-15 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    237.66</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-14 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    241.69</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-13 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    244.03</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-12 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    247.15</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-11 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    253.3</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-10 00:00:00</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-09 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    259.84</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-08 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    266.78</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-07 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    271.16</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-06 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    276.43</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-05 00:00:00</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-04 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    289.51</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-03 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    297.52</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-02 00:00:00</td>
                <td align="right" class="style8">
                    21</td>
                <td align="right" class="style8">
                    302.32</td>
                <td align="right" class="style8">
                    8928.04</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-08-01 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    18.35</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-31 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    21.24</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-30 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    22.87</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-29 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    24.49</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-28 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    26.05</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-27 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    27.41</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-26 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    29.02</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-25 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    30.58</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-24 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    32.19</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-23 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    33.87</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-22 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    35.51</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-21 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    37.11</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-20 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    38.58</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-19 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    40.34</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-18 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    41.93</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-17 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    45.08</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-16 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    52.28</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-15 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    59</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-14 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    66.54</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-13 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    76.46</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-12 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    86.49</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-11 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    95.45</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-10 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    102.6</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-09 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    110.39</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-08 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    118.69</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-07 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    124.26</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-06 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    130.64</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-05 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    136.87</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-04 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    138.5</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-03 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    140.04</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-02 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    141.67</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-07-01 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    143.29</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-30 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    144.83</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-29 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    146.43</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-28 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    148.05</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-27 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    149.65</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-26 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    154.4</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-25 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    158.04</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-24 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    161.61</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-23 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    164.34</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-22 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    168.53</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-21 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    172.5</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-20 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    176.31</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-19 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    179.55</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-18 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    182.59</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-17 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    185.05</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-16 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    188.34</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-15 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    191.87</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-14 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    195.88</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-13 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    198.93</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-12 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    201.05</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-11 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    202.2</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-10 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    203.44</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-09 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    205.57</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-08 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    209.48</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-07 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    212.97</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-06 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    215.99</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-05 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    220.11</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-04 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    223.19</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-03 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    226.38</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-02 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    228.92</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0012407646</td>
                <td class="style8">
                    刘保生</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126001300024736953</td>
                <td class="style8">
                    124110044488</td>
                <td class="style8">
                    体院北环湖南里35-404-406</td>
                <td class="style8">
                    2017-06-01 00:00:00</td>
                <td align="right" class="style8">
                    20</td>
                <td align="right" class="style8">
                    232.45</td>
                <td align="right" class="style8">
                    8639.34</td>
            </tr>
        </table>
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="环湖南里36-308">
            <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:733pt" width="977">

            <tr height="17" style="height:12.75pt">
                <td class="style15" height="17" width="86">
                    用户编号</td>
                <td class="style2" width="64">
                    用户名称</td>
                <td class="style2" width="64">
                    电表相线</td>
                <td class="style16" width="182">
                    电表条码</td>
                <td class="style17" width="99">
                    出厂编号</td>
                <td class="style18" width="155">
                    用户地址</td>
                <td class="style19" width="135">
                    数据时间</td>
                <td class="style2" width="64">
                    购电次数</td>
                <td class="style2" width="64">
                    剩余金额</td>
                <td class="style2" width="64">
                    总购电金额</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-28 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    151.78</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-27 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    154.26</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-26 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    158.47</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-25 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    161.64</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-24 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    164.5</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-23 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    167.57</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-22 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    169.56</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-21 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    173.61</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-20 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    175.8</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-19 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    178.67</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-18 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    182.19</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-17 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    186.21</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-16 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    191.04</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-15 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    194.17</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-14 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    200.04</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-13 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    204.09</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-12 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    207.15</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-11 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    210.86</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-10 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    213.31</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-09 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    216.54</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-08 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    220.68</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-07 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    225.19</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-06 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    229.3</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-05 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    232.12</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-04 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    235.58</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-03 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    238.75</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-02 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    241.42</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-09-01 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    244.13</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-31 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    247.43</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-30 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    249.91</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-29 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    252.83</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-28 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    256.76</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-27 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    259.92</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-26 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    262.02</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-25 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    267.01</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-24 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    277.04</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-23 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    285.71</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-22 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    298.83</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-21 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    311.65</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-20 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    322.11</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-19 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    331.27</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-18 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    340.83</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-17 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    351.45</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-16 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    359.02</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-15 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    368.34</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-14 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    374.78</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-13 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    382.98</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-12 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    392.13</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-11 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    402.26</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-10 00:00:00</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-09 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    411.82</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-08 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    419.04</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-07 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    425.87</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-06 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    435.89</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-05 00:00:00</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-04 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    461.21</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-03 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    468.95</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-02 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    477.32</td>
                <td align="right" class="style8">
                    6981.57</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-08-01 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    11.12</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-31 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    17</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-30 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    20.85</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-29 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    23.92</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-28 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    26.26</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-27 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    29.55</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-26 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    34.21</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-25 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    40.63</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-24 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    45.17</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-23 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    53.1</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-22 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    58.2</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-21 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    66.62</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-20 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    81.58</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-19 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    89.36</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-18 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    97.62</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-17 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    108.95</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-16 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    121.28</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-15 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    131.71</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-14 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    142.94</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-13 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    152.29</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-12 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    162.76</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-11 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    172.82</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-10 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    182.95</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-09 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    197.01</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-08 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    210.01</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-07 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    221.09</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-06 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    228.15</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-05 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    238.97</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-04 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    248.71</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-03 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    255.77</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-02 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    264.57</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-07-01 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    273.55</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-30 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    282.28</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-29 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    289.86</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-28 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    298.2</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-27 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    306.42</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-26 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    313.39</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-25 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    319.84</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-24 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    325.47</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-23 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    330.42</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-22 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    334.62</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-21 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    343.45</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-20 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    350.91</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-19 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    360.88</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-18 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    372.85</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-17 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    384.34</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-16 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    391.83</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-15 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    397.46</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-14 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    401.89</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-13 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    405.99</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-12 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    410.03</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-11 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    413.51</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-10 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    417.42</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-09 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    420.21</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-08 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    423.45</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-07 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    428.61</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-06 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    431.92</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-05 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    435.17</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-04 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    439.18</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-03 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    442.97</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-02 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    446.5</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0002655912</td>
                <td class="style8">
                    李翔平</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985264</td>
                <td class="style8">
                    101110245987</td>
                <td class="style8">
                    体北环湖南里36号308</td>
                <td class="style8">
                    2017-06-01 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    450.1</td>
                <td align="right" class="style8">
                    6509.32</td>
            </tr>
        </table>
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel7" runat="server" HeaderText="环湖南里37-108">
            <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:766pt" width="1020">
            <colgroup>
                <col style="mso-width-source:userset;mso-width-alt:3254;width:67pt" 
                    width="89" />
                <col span="2" style="width:48pt" width="64" />
                <col style="mso-width-source:userset;mso-width-alt:6034;width:124pt" 
                    width="165" />
                <col style="mso-width-source:userset;mso-width-alt:3876;width:80pt" 
                    width="106" />
                <col style="mso-width-source:userset;mso-width-alt:7350;width:151pt" 
                    width="201" />
                <col style="mso-width-source:userset;mso-width-alt:5083;width:104pt" 
                    width="139" />
                <col span="3" style="width:48pt" width="64" />
            </colgroup>
            <tr height="17" style="height:12.75pt">
                <td class="style20" height="17" width="89">
                    用户编号</td>
                <td class="style2" width="64">
                    用户名称</td>
                <td class="style2" width="64">
                    电表相线</td>
                <td class="style21" width="165">
                    电表条码</td>
                <td class="style22" width="106">
                    出厂编号</td>
                <td class="style23" width="201">
                    用户地址</td>
                <td class="style24" width="139">
                    数据时间</td>
                <td class="style2" width="64">
                    购电次数</td>
                <td class="style2" width="64">
                    剩余金额</td>
                <td class="style2" width="64">
                    总购电金额</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-28 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    51.74</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-27 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    54.08</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-26 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    56.89</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-25 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    59.95</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-24 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    62.82</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-23 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    65.81</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-22 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    67.86</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-21 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    70.19</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-20 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    73.16</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-19 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    75.98</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-18 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    79.83</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-17 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    83.69</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-16 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    86.92</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-15 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    89.47</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-14 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    92.21</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-13 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    94.58</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-12 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    98</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-11 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    104.38</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-10 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    107.93</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-09 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    114.51</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-08 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    120.32</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-07 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    125.93</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-06 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    130.84</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-05 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    135.2</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-04 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    140.93</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-03 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    145.67</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-02 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    148.39</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-09-01 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    152.06</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-31 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    154.8</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-30 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    157.09</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-29 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    159.57</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-28 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    162.18</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-27 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    169.58</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-26 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    177.24</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-25 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    183.96</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-24 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    193.63</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-23 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    200.45</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-22 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    207.1</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-21 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    213.25</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-20 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    217.89</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-19 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    224.26</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-18 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    227.83</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-17 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    230.44</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-16 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    234.46</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-15 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    237.03</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-14 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    239.28</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-13 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    243.11</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-12 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    246.66</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-11 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    249.48</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-10 00:00:00</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
                <td class="style8">
                    　</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-09 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    255.41</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-08 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    259.43</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-07 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    262.88</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-06 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    266</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-05 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    270.14</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-04 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    275.36</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-03 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    277.83</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-02 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    281.21</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-08-01 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    285.7</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-31 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    288.1</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-30 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    290.64</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-29 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    292.75</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-28 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    296.45</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-27 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    299.23</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-26 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    302.13</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-25 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    305.89</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-24 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    310.07</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-23 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    313.88</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-22 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    317.64</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-21 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    321.49</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-20 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    326.9</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-19 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    331.1</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-18 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    335.77</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-17 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    338.79</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-16 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    343.22</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-15 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    347.29</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-14 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    352.94</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-13 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    359.47</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-12 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    368.87</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-11 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    375.48</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-10 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    383.33</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-09 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    393.14</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-08 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    405.27</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-07 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    416.24</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-06 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    423.15</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-05 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    430.05</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-04 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    436.16</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-03 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    443.35</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-02 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    450.47</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-07-01 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    458</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-30 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    466.01</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-29 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    472.12</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-28 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    475.44</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-27 00:00:00</td>
                <td align="right" class="style8">
                    10</td>
                <td align="right" class="style8">
                    482.76</td>
                <td align="right" class="style8">
                    8766</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-26 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    16.57</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-25 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    23.26</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-24 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    28.75</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-23 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    31.36</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-22 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    34.26</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-21 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    37.98</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-20 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    41.19</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-19 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    44.9</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-18 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    48.24</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-17 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    51.6</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-16 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    55.23</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-15 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    59.89</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-14 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    63.42</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-13 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    66.39</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-12 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    69.93</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-11 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    72.92</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-10 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    75.55</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-09 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    80.63</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-08 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    83.89</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-07 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    86.62</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-06 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    88.99</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-05 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    91.14</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-04 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    93.55</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-03 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    95.74</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-02 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    98.4</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
            <tr height="17" style="height:12.75pt">
                <td class="style7" height="17">
                    0004727079</td>
                <td class="style8">
                    张有贵</td>
                <td class="style8">
                    单相</td>
                <td class="style8">
                    1210126009600022985325</td>
                <td class="style8">
                    101110245993</td>
                <td class="style8">
                    河西区体院北环湖南里37-108</td>
                <td class="style8">
                    2017-06-01 00:00:00</td>
                <td align="right" class="style8">
                    9</td>
                <td align="right" class="style8">
                    102.04</td>
                <td align="right" class="style8">
                    8293.5</td>
            </tr>
        </table>
            </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>

    </div>
    </form>
    
    
    
</body>
</html>
