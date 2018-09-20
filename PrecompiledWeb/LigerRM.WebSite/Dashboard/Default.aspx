<%@ page language="C#" autoeventwireup="true" inherits="Dashboard_Default, App_Web_dzcdubmf" %>
<%@ Register src="BaiduMap.ascx" tagname="BaiduMap" tagprefix="uc1" %>

<html >
<head runat="server">
    <title>天塔平安智慧社区数据分析系统</title>
    <script type="text/javascript">
            var leftCount = <%=HOUSE_LEFTCOUNT %>;
            var usedCount = <%=HOUSE_USEDCOUNT %>;

            var motorleftCount = <%=MOTOR_LEFTCOUNT %>;
            var motorusedCount = <%=MOTOR_USEDCOUNT %>;
            var sound = 1;

            function PlaySound()
            {
                var audio = document.getElementById("bgMusic");
                if (sound==1)
                {
                    sound=0;
                    audio.pause();
                    document.getElementById("imgSound").src='../Images/mute.png';
                }
                else
                {
                    sound=1;
                    audio.play();
                    document.getElementById("imgSound").src='../Images/sound.png';
                }
            }

            function clearCanvas()
            {  
                var c=document.getElementById("canvas");  
                var cxt=c.getContext("2d");  
                c.height=c.height;  
                 animation();
            }

            var c = "<%= WEATHER_CATEGORIES%>".split(",");
            var t = [];
            var t1= "<%= WEATHER_DATA%>".split(",")
            var env = [];

            t1.forEach(function(data,index,arr){  
                t.push(+data);  
            });  

            var e= "<%= ENV_DATA%>".split(",");

            e.forEach(function(data,index,arr){  
                env.push(+data);  
            });  
    </script>
        <script src="../Javascript/jquery-1.8.3.min.js"></script>
	<script src="../Javascript/highcharts.js"></script>
    <script src="../Javascript/exporting.js"></script>
    <script src="../Javascript/highcharts-zh_CN.js"></script>
    <link href="../Css/style-e65b74606e.css" rel="stylesheet" />
    <link href="../Css/font-awesome.min.css" rel="stylesheet" />
    <script src="../Javascript/grid-light.js"></script>
    <script src="../Javascript/LineChartService.js?autorefresh=Random()"></script>
    <script src="../Javascript/LineChartWater.js?autorefresh=Random()"></script>
    <script src="../Javascript/LineChartElectronic.js?autorefresh=Random()"></script>
    <script src="../Javascript/PieChartAccident.js?autorefresh=Random()"></script>
    <script src="../Javascript/PieChartHouse.js?autorefresh=Random()"></script>
    <script src="../Javascript/PieChartMotor.js?autorefresh=Random()"></script>
    <script src="../Javascript/WeatherReport.js?autorefresh=Random(0)"></script>
    <script src="../Javascript/EnvReport.js?autorefresh=Random()"></script>
    
    <style type="text/css">
        html,body{margin-left: 0px;
margin-top: 0px;
margin-right: 0px;
margin-bottom: 0px;
width:100%; 

height:100%;
vertical-align:top;
}
.audio{ 
/*设置音乐显示位置*/
	width:30px;
	z-index:100;
	filter:alpha(opacity=30);  
      -moz-opacity:0.3;  
      -khtml-opacity: 0.3;  
      opacity: 0.3;
       font-size:10px;
       line-height:25px;
	}
        
        .fill {
          height: 100%;
          width: 100%;
          background-color: #04060e; 
          margin-left: 0px;
          margin-right: 0px; 
          margin-top: 0px; 
          margin-bottom: 0px;
        }
A.white:HOVER
{color:#04060e;
  background-color:#dddddd;
  width:100%;
  vertical-align:middle;
  height:80%;
  display:block;
  line-height:25px;
 }
A.white:LINK
{color:White;}
A.white:VISITED
{color:White;}
A.white:ACTIVE
{color:White;}

A.white1:HOVER
{color:White;
 }
A.white1:LINK
{color:White;}
A.white1:VISITED
{color:White;}
A.white1:ACTIVE
{color:White;}
    </style>
</head>
<body>
    <form id="form1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <div class="canvaszz" style="position:fixed; z-index:-1000;"> 
  <canvas id="canvas">
</canvas> </div>
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
    <tr style="height:15%;">
    <td style="padding-bottom:5px;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border-bottom:2px solid #1188eb;">
        <tr>
        <td width="23%" style="color:#1188eb; font-size:10px; vertical-align:bottom; padding-left:10px; padding-bottom:5px;" 
                rowspan="2">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <img src="../Images/timer.png" width="20px" />&nbsp;<asp:Label ID="lblTimer" runat="server"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
                    <asp:Timer ID="timer" runat="server" Interval="1000" 
                ontick="timer_Tick">
                    </asp:Timer>
        </td>
        <td width="54%">
        <div style="width: 100%; height: 100%;  color: white; font-size:3em; text-align:center; border-bottom:6px solid #1188eb; " 
        ><strong>天塔平安智慧社区数据分析系统</strong>
        
        </div>
        </td>
        <td width="23%" rowspan="2" align="right" style="padding-right:2px;">
            <table border="0" cellpadding="0" cellspacing="0" width="70%" style="color:#1188eb; font-size:10px;-moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;" >
                <tr><td height="30" width="25%" style="background-color:#516393;" align="center"><a href="#" class="white">服务</a></td>
                    <td width="25%" style="background-color:#516393;" align="center"><a href="../index.aspx" class="white">管理</a></td>
                    <td width="25%" style="background-color:#516393;" align="center"><a href="#" class="white">设置</a></td>
                    <td width="25%" style="background-color:#516393;" align="center"><a href="#" onclick="javascript:PlaySound();" class="white"><img id="imgSound" src="../Images/sound.png" height="20px" title="点击开启/关闭声音"  style="cursor: hand" /></a></td></tr>
            </table>
        </td></tr>
    </table>
        
    </td></tr>
    <tr style="height:75%;">
    <td valign="top">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
        <tr>
        <td width="10%" valign="top"  style=" padding-left:5px; background-image:url('../images/opbk.png'); border:1px solid #1188eb; font-size:12px;-moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr><td style="color:White; height:30px; font-size:1.1em; padding:10px; padding-left:0px;">
                                <a href="#" onclick="javascript:wopen('RankDetailInfo.aspx','',1000,400);" 
                                    class="white1">社区综合排名</a><br /><span style="font-size:0.6em; color:#00c4dd;">Community Ranking</span></td></tr>
                                <asp:Repeater ID="rpCommunity" runat="server">
                                <ItemTemplate>
                                <tr><td style="color:#1188eb; height:35px; font-size:0.6em;">NO.<%# Eval("Rank")%><span style="color:White; font-size:0.6em;">&nbsp;<%# Eval("Name")%></span></td></tr>
                                <tr><td height="4px" style="background-image:url(../images/leftlineBK.png); background-position:0px 0px; background-repeat:none;">
                                    <img src="../images/leftline.png" width='<%# Eval("Score")%>%' height="4px" title='得分：<%# Eval("Score")%>' style="cursor: hand" />
                                </td></tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </table>
            </td>
        <td width="1%"></td>
        <td valign="top" style="width:11%;height:48%;" >
        <table border="0" cellpadding="0" width="100%" style="height:100%;">
            <tr style="height:50%;"><td height="50%" valign="top" style="background-image:url('../images/opbk.png'); border:1px solid #1188eb;-moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                        <tr><td style="color:White; height:30px; font-size:1.1em; padding:10px;">
                            <a href="#" onclick="javascript:wopen('PoliceDetailInfo.aspx','',1000,500);" 
                                class="white1">矛盾纠纷分析</a><br /><span style="font-size:0.6em; color:#00c4dd;">Policy service analysis</span></td></tr>
                        <tr><td  ">
                        <div id="containerPie1" style="width: 100%;height:100%;"> </div>
                        </td></tr>
                        <tr><td style="padding-left:5px; padding-right:5px;">
                        <table border="0" cellpadding="3" cellspacing="0" width="100%">
                            <tr><td style="background-color:#04060e;color:#1188eb;height:40px; font-size:1em; width:60%; vertical-align:top; padding:3px;">9月纠纷警情<br />
                                <span style="color:White; font-size:1.5em;">23起</span></td>
                                <td width="4px">&nbsp;</td>
                                <td style="background-color:#04060e;color:#1188eb;height:40px; font-size:1em; width:40%; vertical-align:top; padding:3px;">同比增长<br />
                                   <span style="color:White; font-size:1.5em;"> <span style="color:Red;">+</span>150%</span></td></tr>
                        </table>
                        </td></tr>
                    </table>

            </td></tr>
            <tr><td height="10px" ></td></tr>
            <tr style="height:50%;"><td height="50%"  valign="bottom" style="background-image:url('../images/opbk.png'); border:1px solid #1188eb;-moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                        <tr><td style="color:White; height:30px; font-size:1.1em; padding:10px;"><a href="#" onclick="javascript:wopen('GovServiceDetailInfo.aspx','',980,450);" 
                                class="white1">政府服务业务排名</a><br /><span style="font-size:0.6em; color:#00c4dd;">Community Satisfaction</span></td></tr>
                        <tr><td>
                        <div id="containerLine1" style="width: 100%; height:100%; z-index:-1000; " ></div>
                        </td></tr>
                    </table>
            </td></tr>
        </table>
        
        </td>
        <td width="1%"></td>
        <td width="48%" style="">
<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%" style="border:1px solid #1188eb;">
                    <tr><td height="10%" style="background-image:url('../images/opbk.png'); -moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                        <tr><td style="color:#1188eb; font-size:20px; padding:10px;" width="200px">
                        今日小区出行人数<br />
                            <span style="color:White; font-size:24px;" id="personCount">357</span>人
                        </td><td style="padding:10px; color:#1188eb;">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/line.png" />
                            </td><td style="color:#1188eb; font-size:20px; padding:10px;" width="100px">
                        车位数<br />
                            <span style="color:White; font-size:24px;"><%=MOTOR_TOTALCOUNT %></span>个
                        </td><td style="padding:10px; color:#1188eb;">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/line.png" />
                            </td>
                            <td style="color:#1188eb; font-size:20px; padding:10px;" width="150px">
                        空余日租房<br />
                            <span style="color:White; font-size:24px;"><%=HOUSE_LEFTCOUNT %></span>间
                        </td><td style="padding:10px; color:#1188eb;">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/line.png" />
                            </td>
                            <td style="color:#1188eb; font-size:20px; padding:10px;" width="120px">
                        纠纷预警<br />
                            <span style="color:White; font-size:24px;">10</span>起
                        </td><td style="padding:10px; color:#1188eb;">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/line.png" />
                            </td>
                            <td width="80px">
                            </td>
                            <td align="right" style="color: #1188eb; font-size: 20px; padding: 10px;" width="120px">
                                <a href="#" onclick="javascript:wopen('../MotorManage/AlertInfoList.aspx','',900,600);" class="white1" >预警信息</a></td>
                        </tr>
                    </table>
                    </td></tr>
                    <tr><td height="75%" style="-moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;">
                                   <div style="width:100%; height: 100%;" >
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                                        <tr><td height="97%">
                                        <uc1:BaiduMap ID="BaiduMap1" runat="server" />
                                        </td></tr>
                                        <tr><td height="3%" style="background-color:#121b4a;">
                                        <a href="#" onclick="javascript:initMap();"><img id="imgLabel" src="../images/label.png" height="30px" title="点击显示/隐藏地图标签" style="cursor: hand" /></a>
                                        <div style="display:none;">
                                          <audio controls="false" id="bgMusic" autoplay="autoplay" class="audio" height="15px" loop>
                                            <source src="Music.mp3" type="audio/mp3"> 
                                        </audio></div>
                                        </td></tr>
                                   </table>
                
               </div>
                    </td></tr>
                </table>
        </td>
        <td width="1%"></td>
        <td width="11%"  style="" valign="top">
<table border="0" cellpadding="0" width="100%" style="height:100%;">
            <tr><td height="50%" valign="top"  style=" background-image:url('../images/opbk.png'); -moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333; border:1px solid #1188eb;">
            
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%; z-index:100;" >
                        <tr><td style="color:White; height:30px; font-size:1.1em; padding:10px;filter:alpha(Opacity=100);-moz-opacity:2;opacity: 2;"><a href="#" onclick="javascript:wopen('PersonMonitorList.aspx','',1000,500);" class="white1">人员检测</a><br /><span style="font-size:0.6em; color:#00c4dd;">Personal detection</span></td></tr>
                        <tr><td style="">
                        <div id="containerLine2" style="width: 100%; height: 90%;">
                    </div>
                        </td></tr>
                        <tr><td style="padding-left:5px; padding-right:5px;">
                        <table border="0" cellpadding="3" cellspacing="0" width="100%">
                            <tr><td style="background-color:#04060e;color:#1188eb;height:40px; font-size:1em; padding-left:10px;">人员检测最快<br />
                                <span style="color:White; font-size:1.5em;">13点 同比<span style="color:Red;">+</span>10.3%</span></td>
                                </tr>
                        </table>
                        </td></tr>
                    </table>
            
            </td></tr>
            <tr><td height="10px" ></td></tr>
            <tr><td height="50%" valign="top" style="background-image:url('../images/opbk.png'); border:1px solid #1188eb;-moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;">
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%; ">
                        <tr><td style="color:White; height:30px; font-size:1.0em; padding:10px;">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr><td align="left"style="color:White; height:30px; font-size:1.1em; padding:10px;">出租房分析<br /><span style="font-size:0.6em; color:#00c4dd;">Rental housing analysis</span></td><td align="right"><a href="#" onclick="javascript:addHouseInfo();"><img src="../images/mapicon.png" width="15"/></a></td></tr>
                        </table>
                        </td></tr>
                        <tr><td>
                        <div id="containerPie2" style="width: 100%; height:100%;" ></div>
                        </td></tr>
                        <tr><td style="padding-left:5px; padding-right:5px;">
                        <table border="0" cellpadding="3" cellspacing="0" width="100%">
                            <tr><td style="background-color:#04060e;color:#1188eb;height:40px; font-size:1em; padding-left:10px; width:50%;">共有房屋<br />
                                <span style="color:White; font-size:1.5em;"><%=HOUSE_TOTALCOUNT %>间</span></td>
                                <td width="4px">&nbsp;</td>
                                <td style="background-color:#04060e;color:#1188eb;height:40px; font-size:1em; padding-left:10px; width:50%;">剩余<br />
                                    <span style="color:White; font-size:1.5em;"><%=HOUSE_LEFTCOUNT %>间</span></td></tr>
                        </table>
                        </td></tr>
                    </table>
                                    
            
            </td></tr>
        </table>
        </td>
        <td width="1%"></td>
        <td width="11%"  style="" valign="top">
<table border="0" cellpadding="0" width="100%" style="height:100%;">
            <tr><td height="50%" valign="top"  style="background-image:url('../images/opbk.png'); border:1px solid #1188eb;-moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                        <tr><td style="color:White; height:30px; font-size:1.1em; padding:10px; "><a href="#" onclick="javascript:wopen('SingelElectronicMonitor.aspx','',1000,500);" class="white1"> 用电异常</a><br /><span style="font-size:0.6em; color:#00c4dd;">Ectricity anomaly detection</span></td></tr>
                        <tr><td align="center" valign="bottom">
                        <div id="containerLine3" style="width: 100%; height: 100%;">
                    </div>
                        </td></tr>
                        <tr><td style="padding-left:5px; padding-right:5px;">
                        <table border="0" cellpadding="3" cellspacing="0" width="100%">
                            <tr><td style="background-color:#04060e;color:#1188eb;height:40px; font-size:1em; padding-left:10px;">用电增速最快<br />
                                <span style="color:White; font-size:1.5em;">8点 同比<span style="color:Red;">+</span>13.6%</span></td>
                                </tr>
                        </table>
                        </td></tr>
                    </table>
            
            </td></tr>
            <tr><td height="10px" bgcolor=""></td></tr>
            <tr><td height="50%" valign="top" style="background-image:url('../images/opbk.png'); border:1px solid #1188eb;-moz-box-shadow:2px 2px 5px #333333; -webkit-box-shadow:2px 2px 5px #333333; box-shadow:2px 2px 5px #333333;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%;">
                        <tr><td style="color:White; height:30px; font-size:1.0em; padding:10px;">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr><td align="left"style="color:White; height:30px; font-size:1.1em; padding:10px;">车位分析<br /><span style="font-size:0.6em; color:#00c4dd;">Parking analysis</span></td><td align="right"><a href="#" onclick="javascript:addMotorInfo();"><img src="../images/mapicon.png" width="15"/></a></td></tr>
                        </table>
                        </td></tr>
                        <tr><td>
                        <div id="containerPie3" style="width: 100%; height:100%;" ></div>
                        </td></tr>
                        <tr><td style="padding-left:5px; padding-right:5px;">
                        <table border="0" cellpadding="3" cellspacing="0" width="100%">
                            <tr><td style="background-color:#04060e;color:#1188eb;height:40px; font-size:1em; width:50%; padding-left:10px;">共有车位<br />
                                <span style="color:White; font-size:1.5em;"><%=MOTOR_TOTALCOUNT %>个</span></td>
                                <td width="4px">&nbsp;</td>
                                <td style="background-color:#04060e;color:#1188eb;height:40px; font-size:1em; width:50%; padding-left:10px;">剩余<br />
                                    <span style="color:White; font-size:1.5em;"><%=MOTOR_LEFTCOUNT %>个</span></td></tr>
                        </table>
                        </td></tr>
                    </table>
                                    
            
            </td></tr>
        </table>

        </td>
        </tr>
    </table>
    </td></tr>
    <tr style="height:10%;"><td valign="bottom" align="left" style=" padding-top:5px;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td width="20%" style="color:White; font-weight:bold;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr><td><img  src="../Images/LogoPolice.png"/></td>
                </tr>
            </table>
                 </td>
            <td width="20%">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr><td align="left" style="color:#ffffff; ">环境分析</td></tr>
                <tr><td style="padding-bottom:5px;"><div id="divEnv" 
                        style="width: 100%; height: 76px;"></td></tr>
            </table>
            
                </td>
            <td width="20%">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr><td align="left" style="color:#ffffff; ">天气分析</td></tr>
                <tr><td style="padding-bottom:5px;"><div id="divWeather" style="width: 100%; height: 76px;"></td></tr>
            </table>
            
            </td>
            <td width="40%" style=" color:#1188eb; font-size:12px; padding-left:20px;color:#1188eb; ">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr><td width="16%" style="color:#1188eb; font-size:0.6em;"><a href="http://www.tjgaj.gov.cn/site/default.aspx" target="_blank">民生服务平台</a></td><td width="16%" style="color:#1188eb; font-size:1.0em;"><a href="http://www.tjmuch.com/" target="_blank">肿瘤医院</a></td><td width="2px" rowspan="3"><img src="../images/bottomline.png"/>
                    &nbsp;</td><td width="16%" style="color:#1188eb; font-size:0.6em;"><a href="http://www.dianping.com/" target="_blank">周边商圈</a></td><td width="16%"  style="color:#1188eb; font-size:1.0em;"><a href="http://www.enorth.com.cn/" target="_blank">北方网</a></td><td width="2px" rowspan="3"><img src="../images/bottomline.png"/></td><td width="16%" style="color:#1188eb; font-size:0.6em;">常规预警</td><td width="16%"  style="color:#1188eb; font-size:1.0em;">常用表格</td></tr>
                <tr><td width="16%">&nbsp;</td><td width="16%">&nbsp;</td><td width="16%">&nbsp;</td><td width="16%">
                    &nbsp;</td><td width="16%">&nbsp;</td><td width="16%">&nbsp;</td></tr>
                <tr><td width="16%" style="color:#1188eb; font-size:0.6em;"><a href="http://www.tj.gov.cn/" target="_blank">政府服务网</a></td><td width="16%"  style="color:#1188eb; font-size:1.0em;">缴费平台</td><td width="16%" style="color:#1188eb; font-size:0.6em;">菜市场管理</td><td width="16%"  style="color:#1188eb; font-size:1.0em;">
                    无人机管理</td><td width="16%" style="color:#1188eb; font-size:0.6em;">常规预警</td><td width="16%"  style="color:#1188eb; font-size:1.0em;">进入后台</td></tr>
            </table>
            </td></tr>
        </table>
    </td></tr>
</table>
        <script>
            function DrawBack() {
                //宇宙特效
                "use strict";
                var canvas = document.getElementById('canvas'),
  ctx = canvas.getContext('2d'),
  w = canvas.width = window.innerWidth,
  h = canvas.height = window.innerHeight,

  hue = 217,
  stars = [],
  count = 0,
  maxStars = 1300; //星星数量

                var canvas2 = document.createElement('canvas'),
  ctx2 = canvas2.getContext('2d');
                canvas2.width = 100;
                canvas2.height = 100;
                var half = canvas2.width / 2,
  gradient2 = ctx2.createRadialGradient(half, half, 0, half, half, half);
                gradient2.addColorStop(0.025, '#CCC');
                gradient2.addColorStop(0.1, 'hsl(' + hue + ', 61%, 33%)');
                gradient2.addColorStop(0.25, 'hsl(' + hue + ', 64%, 6%)');
                gradient2.addColorStop(1, 'transparent');

                ctx2.fillStyle = gradient2;
                ctx2.beginPath();
                ctx2.arc(half, half, half, 0, Math.PI * 2);
                ctx2.fill();

                // End cache

                function random(min, max) {
                    if (arguments.length < 2) {
                        max = min;
                        min = 0;
                    }

                    if (min > max) {
                        var hold = max;
                        max = min;
                        min = hold;
                    }

                    return Math.floor(Math.random() * (max - min + 1)) + min;
                }

                function maxOrbit(x, y) {
                    var max = Math.max(x, y),
    diameter = Math.round(Math.sqrt(max * max + max * max));
                    return diameter / 2;
                    //星星移动范围，值越大范围越小，
                }

                var Star = function () {

                    this.orbitRadius = random(maxOrbit(w, h));
                    this.radius = random(60, this.orbitRadius) / 8;
                    //星星大小
                    this.orbitX = w / 2;
                    this.orbitY = h / 2;
                    this.timePassed = random(0, maxStars);
                    this.speed = random(this.orbitRadius) / 500000;
                    //星星移动速度
                    this.alpha = random(2, 10) / 10;

                    count++;
                    stars[count] = this;
                }

                Star.prototype.draw = function () {
                    var x = Math.sin(this.timePassed) * this.orbitRadius + this.orbitX,
    y = Math.cos(this.timePassed) * this.orbitRadius + this.orbitY,
    twinkle = random(10);

                    if (twinkle === 1 && this.alpha > 0) {
                        this.alpha -= 0.05;
                    } else if (twinkle === 2 && this.alpha < 1) {
                        this.alpha += 0.05;
                    }

                    ctx.globalAlpha = this.alpha;
                    ctx.drawImage(canvas2, x - this.radius / 2, y - this.radius / 2, this.radius, this.radius);
                    this.timePassed += this.speed;
                }

                for (var i = 0; i < maxStars; i++) {
                    new Star();
                }

                function animation() {
                    ctx.globalCompositeOperation = 'source-over';
                    ctx.globalAlpha = 0.5; //尾巴
                    ctx.fillStyle = 'hsla(' + hue + ', 64%, 6%, 2)';
                    ctx.fillRect(0, 0, w, h)

                    ctx.globalCompositeOperation = 'lighter';
                    for (var i = 1, l = stars.length; i < l; i++) {
                        stars[i].draw();
                    };

                    window.requestAnimationFrame(animation);
                }

                animation();
            }

            DrawBack();

            function wopen(pageURL, title, w, h) {
                var left = (screen.width / 2) - (w / 2);
                var top = (screen.height / 2) - (h / 2);
                var targetWin = window.open(pageURL, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
                //window.showModalDialog(pageURL, "", "dialogWidth=" + w + "px;dialogHeight=" + h + "px;top="+top+";left="+left);
            }

            setInterval(function () {
                f_countPerson();
            }, 5000);

            function f_countPerson() {
                var person = document.getElementById("personCount");
                var ran = GetRandomNum(0, 5);
                var ran1 = GetRandomNum(0, 5);
                person.innerHTML = parseInt(person.innerHTML) + parseInt(ran) - parseInt(ran1);
            }

            function GetRandomNum(Min, Max) {
                var Range = Max - Min;
                var Rand = Math.random();
                return (Min + Math.round(Rand * Range));
            } 
</script>
    </form>
</body>
</html>
