<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapLocation.aspx.cs" Inherits="InfoRegister_MapLocation" %>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		body, html{width: 100%;height: 100%;margin:0;font-family:"微软雅黑";}
		#allmap{height:500px;width:100%;}
		#r-result{width:100%; font-size:14px;}
	</style>
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
	<title>城市名定位</title>
</head>
<body onload="theLocation();">
	<div id="allmap" style="width:530px;height:400px; margin:auto;"></div>
</body>
</html>
<script type="text/javascript">
    // 百度地图API功能
    var lan = "<%=Lan %>";
    var lat = "<%=Lat %>";
    var map = new BMap.Map("allmap");
    map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
    //map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用
    map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件
    map.addControl(new BMap.OverviewMapControl()); //添加默认缩略地图控件
    map.addControl(new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_RIGHT }));   //右下角，打开
    map.centerAndZoom(new BMap.Point(lan, lat), 16);

    // 用经纬度设置地图中心点
    function theLocation() {
        map.clearOverlays();
        var new_point = new BMap.Point(lan, lat);
        var marker = new BMap.Marker(new_point);  // 创建标注
        map.addOverlay(marker);              // 将标注添加到地图中
        map.panTo(new_point);

    }
</script>