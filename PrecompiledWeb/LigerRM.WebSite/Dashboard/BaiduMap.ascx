<%@ control language="C#" autoeventwireup="true" inherits="Dashboard_BaiduMap, App_Web_ccravnrh" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta name="keywords" content="" />
<meta name="description" content="" />
<title></title>
<!--引用百度地图API-->
<style type="text/css">
    html,body{margin:0;padding:0;}
    .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}
    .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}
</style>
<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=OG00ESUZvs88soSk5aDuxxw1R8r5NGtn"></script>
</head>

<body>
  <!--百度地图容器-->
  <div style="width:100%;height:100%;border:#121b4a solid 1px; padding:10px;" id="dituContent"></div>
</body>
    
<script type="text/javascript">
    var houseOverLayered = 0;
    var motorOverLayered = 0;
    var isShowLabel = 0;
    //创建和初始化地图函数：
    function initMap() {
        houseOverLayered = 0;
        motorOverLayered=0;
        createMap(); //创建地图
        setMapEvent(); //设置地图事件
        addMapControl(); //向地图添加控件
        if (isShowLabel==0)
        {
            isShowLabel=1;
            document.getElementById('imgLabel').src = "../images/label.png";
            }
        else
        {
            isShowLabel = 0;
            document.getElementById('imgLabel').src = "../images/unlabel.png";
            }
    }

    var opts = {
        width: 300,     // 信息窗口宽度
        height: 130,     // 信息窗口高度
        title: "房源信息", // 信息窗口标题
        enableMessage: true//设置允许信息窗发送短息
    };

    //创建地图函数：
    function createMap() {
        var map = new BMap.Map("dituContent"); //在百度地图容器中创建一个地图

        var point = new BMap.Point(117.192715, 39.085556); //定义一个中心点坐标
        map.centerAndZoom(point, 18); //设定地图的中心点和坐标并将地图显示在地图容器中


        var myStyleJson = [
          {
              "featureType": "water",
              "elementType": "all",
              "stylers": {
                  "color": "#021019"
              }
          },
          {
              "featureType": "highway",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "highway",
              "elementType": "geometry.stroke",
              "stylers": {
                  "color": "#147a92"
              }
          },
          {
              "featureType": "arterial",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "arterial",
              "elementType": "geometry.stroke",
              "stylers": {
                  "color": "#0b3d51"
              }
          },
          {
              "featureType": "local",
              "elementType": "geometry",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "land",
              "elementType": "all",
              "stylers": {
                  "color": "#08304b"
              }
          },
          {
              "featureType": "railway",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "railway",
              "elementType": "geometry.stroke",
              "stylers": {
                  "color": "#08304b"
              }
          },
          {
              "featureType": "subway",
              "elementType": "geometry",
              "stylers": {
                  "lightness": -70
              }
          },
          {
              "featureType": "building",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "all",
              "elementType": "labels.text.fill",
              "stylers": {
                  "color": "#ffffff",
                  "visibility": "off" 
              }
          },
          {
              "featureType": "all",
              "elementType": "labels.text.stroke",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "building",
              "elementType": "geometry",
              "stylers": {
                  "color": "#022338"
              }
          },
          {
              "featureType": "green",
              "elementType": "geometry",
              "stylers": {
                  "color": "#062032"
              }
          },
          {
              "featureType": "boundary",
              "elementType": "all",
              "stylers": {
                  "color": "#1e1c1c"
              }
          },
          {
              "featureType": "manmade",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#999999"
              }
          }
];

if (isShowLabel==1)
{
            myStyleJson = [
          {
              "featureType": "water",
              "elementType": "all",
              "stylers": {
                  "color": "#021019"
              }
          },
          {
              "featureType": "highway",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "highway",
              "elementType": "geometry.stroke",
              "stylers": {
                  "color": "#147a92"
              }
          },
          {
              "featureType": "arterial",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "arterial",
              "elementType": "geometry.stroke",
              "stylers": {
                  "color": "#0b3d51"
              }
          },
          {
              "featureType": "local",
              "elementType": "geometry",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "land",
              "elementType": "all",
              "stylers": {
                  "color": "#08304b"
              }
          },
          {
              "featureType": "railway",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "railway",
              "elementType": "geometry.stroke",
              "stylers": {
                  "color": "#08304b"
              }
          },
          {
              "featureType": "subway",
              "elementType": "geometry",
              "stylers": {
                  "lightness": -70
              }
          },
          {
              "featureType": "building",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "all",
              "elementType": "labels.text.fill",
              "stylers": {
                  "color": "#ffffff"
              }
          },
          {
              "featureType": "all",
              "elementType": "labels.text.stroke",
              "stylers": {
                  "color": "#000000"
              }
          },
          {
              "featureType": "building",
              "elementType": "geometry",
              "stylers": {
                  "color": "#022338"
              }
          },
          {
              "featureType": "green",
              "elementType": "geometry",
              "stylers": {
                  "color": "#062032"
              }
          },
          {
              "featureType": "boundary",
              "elementType": "all",
              "stylers": {
                  "color": "#1e1c1c"
              }
          },
          {
              "featureType": "manmade",
              "elementType": "geometry.fill",
              "stylers": {
                  "color": "#999999"
              }
          }
];
}
        map.setMapStyle({ styleJson: myStyleJson });
        window.map = map; //将map变量存储在全局
        //addHouseInfo();
    }

    //地图事件设置函数：
    function setMapEvent() {
        map.enableDragging(); //启用地图拖拽事件，默认启用(可不写)
        map.enableScrollWheelZoom(); //启用地图滚轮放大缩小
        map.enableDoubleClickZoom(); //启用鼠标双击放大，默认启用(可不写)
        map.enableKeyboard(); //启用键盘上下左右键移动地图
    }

    function addHouseInfo()
    {

        //添加出租屋信息
        var data_info = [<%=dataInfo %>];
        for (var i = 0; i < data_info.length; i++) {
            var myIcon;
            if(data_info[2]=="False")
            {
                myIcon = new BMap.Icon("http://qxw2332340157.my3w.com/Images/H-1.png", new BMap.Size(25, 30), {
                });
            }
            else
            {
                myIcon = new BMap.Icon("http://qxw2332340157.my3w.com/Images/H-0.png", new BMap.Size(25, 30), {
                });
            }
            var marker = new BMap.Marker(new BMap.Point(data_info[i][0], data_info[i][1]),{ icon: myIcon });  // 创建标注
            var content = data_info[i][3];
            if (houseOverLayered==0)
            {
                map.addOverlay(marker);               // 将标注添加到地图中
                addClickHandler(content, marker);
                }
            else
            {
                //map.removeOverlay(marker);
                map.clearOverlays(); 
                if (motorOverLayered==1)
                {
                motorOverLayered=0;
                    addMotorInfo();
                    }
             }
        }
        if (houseOverLayered == 0)
            houseOverLayered = 1;
        else
            houseOverLayered = 0;

    }

    //地图控件添加函数：
    function addMapControl() {
        //向地图中添加缩放控件
        var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
        map.addControl(ctrl_nav);

        //向地图中添加比例尺控件
        var ctrl_sca = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
        map.addControl(ctrl_sca);
        //添加车位信息
    }

    function addMotorInfo()
    {
        var data_info = [<%=motordataInfo %>];
        for (var i = 0; i < data_info.length; i++) {
            var pIcon = new BMap.Icon("http://qxw2332340157.my3w.com/Images/pGif.gif", new BMap.Size(10, 10), {
                    });
            var pmarker = new BMap.Marker(new BMap.Point(data_info[i][0], data_info[i][1]),{ icon: pIcon });
            map.addOverlay(pmarker);

        }

        if (motorOverLayered==0)
            {
            map.addOverlay(pmarker);

            if (motorOverLayered == 0)
                motorOverLayered = 1;
            else
                motorOverLayered = 0;
        }
        else
        {
            map.clearOverlays();
            if (houseOverLayered==1)
            {
                houseOverLayered=0;
                motorOverLayered = 0;
                addHouseInfo(); 
            }
            else
                motorOverLayered = 0;
            }
    }

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

    initMap(); //创建和初始化地图
</script>
<style type="text/css">  
   .anchorBL{  
       display:none;  
   }  
  </style> 
</html>
