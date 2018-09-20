<%@ control language="C#" autoeventwireup="true" inherits="Dashboard_BaiduMap, App_Web_ccravnrh" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta name="keywords" content="" />
<meta name="description" content="" />
<title></title>
<!--���ðٶȵ�ͼAPI-->
<style type="text/css">
    html,body{margin:0;padding:0;}
    .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}
    .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}
</style>
<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=OG00ESUZvs88soSk5aDuxxw1R8r5NGtn"></script>
</head>

<body>
  <!--�ٶȵ�ͼ����-->
  <div style="width:100%;height:100%;border:#121b4a solid 1px; padding:10px;" id="dituContent"></div>
</body>
    
<script type="text/javascript">
    var houseOverLayered = 0;
    var motorOverLayered = 0;
    var isShowLabel = 0;
    //�����ͳ�ʼ����ͼ������
    function initMap() {
        houseOverLayered = 0;
        motorOverLayered=0;
        createMap(); //������ͼ
        setMapEvent(); //���õ�ͼ�¼�
        addMapControl(); //���ͼ��ӿؼ�
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
        width: 300,     // ��Ϣ���ڿ��
        height: 130,     // ��Ϣ���ڸ߶�
        title: "��Դ��Ϣ", // ��Ϣ���ڱ���
        enableMessage: true//����������Ϣ�����Ͷ�Ϣ
    };

    //������ͼ������
    function createMap() {
        var map = new BMap.Map("dituContent"); //�ڰٶȵ�ͼ�����д���һ����ͼ

        var point = new BMap.Point(117.192715, 39.085556); //����һ�����ĵ�����
        map.centerAndZoom(point, 18); //�趨��ͼ�����ĵ�����겢����ͼ��ʾ�ڵ�ͼ������


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
        window.map = map; //��map�����洢��ȫ��
        //addHouseInfo();
    }

    //��ͼ�¼����ú�����
    function setMapEvent() {
        map.enableDragging(); //���õ�ͼ��ק�¼���Ĭ������(�ɲ�д)
        map.enableScrollWheelZoom(); //���õ�ͼ���ַŴ���С
        map.enableDoubleClickZoom(); //�������˫���Ŵ�Ĭ������(�ɲ�д)
        map.enableKeyboard(); //���ü����������Ҽ��ƶ���ͼ
    }

    function addHouseInfo()
    {

        //��ӳ�������Ϣ
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
            var marker = new BMap.Marker(new BMap.Point(data_info[i][0], data_info[i][1]),{ icon: myIcon });  // ������ע
            var content = data_info[i][3];
            if (houseOverLayered==0)
            {
                map.addOverlay(marker);               // ����ע��ӵ���ͼ��
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

    //��ͼ�ؼ���Ӻ�����
    function addMapControl() {
        //���ͼ��������ſؼ�
        var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
        map.addControl(ctrl_nav);

        //���ͼ����ӱ����߿ؼ�
        var ctrl_sca = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
        map.addControl(ctrl_sca);
        //��ӳ�λ��Ϣ
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
        var infoWindow = new BMap.InfoWindow(content, opts);  // ������Ϣ���ڶ��� 
        map.openInfoWindow(infoWindow, point); //������Ϣ����
    }

    initMap(); //�����ͳ�ʼ����ͼ
</script>
<style type="text/css">  
   .anchorBL{  
       display:none;  
   }  
  </style> 
</html>
