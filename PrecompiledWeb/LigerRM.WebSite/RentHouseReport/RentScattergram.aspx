<%@ page language="C#" autoeventwireup="true" inherits="RentHouseReport_RentScattergram, App_Web_ywriaorp" %>

<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		body, html {width: 100%;height: 100%;margin:0;font-family:"微软雅黑";}
		#allmap{width:100%;height:100%;}
		p{margin-left:5px; font-size:14px;}
	</style>
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
	<script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
	<title>租赁分布图</title>
</head>
<body>
	<div id="allmap"></div>
</body>
</html>
<script type="text/javascript">
    // 百度地图API功能	
    map = new BMap.Map("allmap");
    map.centerAndZoom(new BMap.Point(<%=defaultLon %>, <%=defaultLat %>), 12);
    var data_info = [<%=dataInfo %>
					];
    var opts = {
        width: 300,     // 信息窗口宽度
        height: 150,     // 信息窗口高度
        title: "房源信息", // 信息窗口标题
        enableMessage: true//设置允许信息窗发送短息
    };
    for (var i = 0; i < data_info.length; i++) {
        var marker = new BMap.Marker(new BMap.Point(data_info[i][0], data_info[i][1]));  // 创建标注
        var content = data_info[i][2];
        map.addOverlay(marker);               // 将标注添加到地图中
        addClickHandler(content, marker);
    }

    map.enableScrollWheelZoom();   //启用滚轮放大缩小，默认禁用
    map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用

    var top_left_control = new BMap.ScaleControl({anchor: BMAP_ANCHOR_TOP_LEFT});// 左上角，添加比例尺
	var top_left_navigation = new BMap.NavigationControl();  //左上角，添加默认缩放平移控件
	var top_right_navigation = new BMap.NavigationControl({anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL}); //右上角，仅包含平移和缩放按钮
	/*缩放控件type有四种类型:
	BMAP_NAVIGATION_CONTROL_SMALL：仅包含平移和缩放按钮；BMAP_NAVIGATION_CONTROL_PAN:仅包含平移按钮；BMAP_NAVIGATION_CONTROL_ZOOM：仅包含缩放按钮*/
	
    map.addControl(top_left_control);        
    map.addControl(top_left_navigation);     
    map.addControl(top_right_navigation); 

    function addClickHandler(content, marker) {
        marker.addEventListener("click", function (e) {
            openInfo(content, e)
        }
		);
    }
    function openInfo(content, e) {
        var p = e.target;
        var point = new BMap.Point(p.getPosition().lng, p.getPosition().lat);
        var infoWindow = new BMap.InfoWindow(content, opts);  // 创建信息窗口对象 
        map.openInfoWindow(infoWindow, point); //开启信息窗口
    }
</script>
