<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SingelElectronicMonitor.aspx.cs" Inherits="Dashboard_SingelElectronicMonitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><html><head>
	<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">	<meta name="description" content="">
	<title>电量检测</title>
	<script src="https://img.hcharts.cn/jquery/jquery-1.8.3.min.js"></script>
	<script src="https://img.hcharts.cn/highcharts/highcharts.js"></script>
	<script src="https://img.hcharts.cn/highcharts/modules/exporting.js"></script>
	<script src="https://img.hcharts.cn/highcharts/modules/oldie.js"></script>
	<script src="https://img.hcharts.cn/highcharts-plugins/highcharts-zh_CN.js"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
            <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/json2.js" type="text/javascript"></script> 
</head>
<body>
<div style=" margin:5px; padding:5px;">
	<div id="r-result">
		  <div id="mainsearch" style=" width:100%">
    <div class="searchtitle">
        <span>搜索</span><img src="../lib/icons/32X32/searchtool.gif" />
        <div class="togglebtn"></div> 
    </div>
    <div class="navline" style="margin-bottom:4px; margin-top:4px;"></div>
    <div class="searchbox">
        <form id="formsearch" class="l-form"></form>
    </div>
  </div>
        </div>
	<div id="container" style="min-width:400px;height:400px"></div>
</div>


	<script>

	    var rootPath = "../";
	    Date.prototype.Format = function (fmt) { //author: meizz 
	        var o = {
	            "M+": this.getMonth() + 1,                 //月份 
	            "d+": this.getDate(),                    //日 
	            "h+": this.getHours(),                   //小时 
	            "m+": this.getMinutes(),                 //分 
	            "s+": this.getSeconds(),                 //秒 
	            "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
	            "S": this.getMilliseconds()             //毫秒 
	        };
	        if (/(y+)/.test(fmt))
	            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
	        for (var k in o)
	            if (new RegExp("(" + k + ")").test(fmt))
	                fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
	        return fmt;
	    }
	    $("#formsearch").ligerForm({
	        fields: [

          { display: "监测日期", name: "timeflag", newline: false, labelWidth: 70, width: 120, space: 20, type: "date", cssClass: "field",
              attr: {
                  op: "greaterorequal"
              }
          },
          { display: "监测房屋", name: "vipm_sn", newline: false, labelWidth: 70, width: 400, space: 20, type: "select", cssClass: "field",
              options: {
                  url: '../handler/select.ashx?view=v_RentElectronic_View&idfield=ElectronicDeviceID&textfield=RAddress&distinct=true',
                  initValue: '', valueFieldID: 'ElectronicDeviceID', selectBoxWidth: '400'
              }
          }

          ],
	        toJSON: JSON2.stringify
	    });

	    var dtNow = new Date();
	    var dtStart = new Date(dtNow.getTime());
	    $("#timeflag").val(formatDate(dtStart));

	    var t1;


	    var button = $('<ul><li style="margin-right:8px"></li><li></li></ul><div class="l-clear"></div>').appendTo("#formsearch");
	    LG.createButton({
	        appendTo: button,
	        text: '搜索',
	        defaultButton: 'true',
	        click: function () {
	            var rule = LG.bulidFilterGroup("#formsearch");
	            ShowMap(JSON2.stringify(rule));

	            var d = $("#timeflag").val();
	            var dtDate = new Date(d);
	            var today = new Date();
	            if (dtDate.getFullYear() == today.getFullYear() && dtDate.getMonth() == today.getMonth() && dtDate.getDate() == today.getDate()) {

	                t1 = setInterval(function () {
	                    ShowMap(JSON2.stringify(rule));
	                }, 60000);
	            }
	            else {
	                clearInterval(t1);
	            }

	        }
	    });


	    function formatDate(d) {
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

	        if (month.length < 2) month = '0' + month;
	        if (day.length < 2) day = '0' + day;

	        return [year, month, day].join('-');
	    }

	    function activeLastPointToolip(chart) {
	        var points = chart.series[0].points;
	        chart.tooltip.refresh(points[points.length - 1]);
	    }



        function ShowMap(rule) {

            var d = $("#timeflag").val();
            var id = $("#ElectronicDeviceID").val();
            var dtDate = new Date(d);

            $.getJSON('../handler/ajax.ashx?type=AjaxBaseManage&method=GetElectronicData', { ID: id, year: dtDate.getFullYear().toString(), month: dtDate.getMonth() + 1, day: dtDate.getDate(), ran: Math.random() }, function (data) {

                var jsonObj = JSON.parse(data.Message);
                $('#container').highcharts({
                    chart: {
                        zoomType: 'x'
                    },
                    title: {
                        text: '电表使用功率走势图'
                    },
                    subtitle: {
                        text: document.ontouchstart === undefined ?
                '鼠标拖动可以进行缩放' : '手势操作进行缩放'
                    },
                    xAxis: {
                        type: 'datetime',
                        dateTimeLabelFormats: {
                            millisecond: '%H:%M:%S.%L',
                            second: '%H:%M:%S',
                            minute: '%H:%M',
                            hour: '%H:%M',
                            day: '%m-%d',
                            week: '%m-%d',
                            month: '%Y-%m',
                            year: '%Y'
                        }
                    },
                    tooltip: {
                        dateTimeLabelFormats: {
                            millisecond: '%H:%M:%S.%L',
                            second: '%H:%M:%S',
                            minute: '%H:%M',
                            hour: '%H:%M',
                            day: '%Y-%m-%d',
                            week: '%m-%d',
                            month: '%Y-%m',
                            year: '%Y'
                        }
                    },
                    yAxis: {
                        title: {
                            text: '功率'
                        }
                    },
                    legend: {
                        enabled: false
                    },
                    plotOptions: {
                        area: {
                            fillColor: {
                                linearGradient: {
                                    x1: 0,
                                    y1: 0,
                                    x2: 0,
                                    y2: 1
                                },
                                stops: [
                            [0, Highcharts.getOptions().colors[0]],
                            [1, Highcharts.Color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                        ]
                            },
                            marker: {
                                radius: 2
                            },
                            lineWidth: 1,
                            states: {
                                hover: {
                                    lineWidth: 1
                                }
                            },
                            threshold: null
                        }
                    },
                    series: [{
                        type: 'area',
                        name: '功率',
                        data: jsonObj
                    }]
                });
            });
        }

	    $(function () {
	        (function (b) { "object" === typeof module && module.exports ? module.exports = b : b(Highcharts) })(function (b) {
	            (function (a) {
	                a.createElement("link", { href: "https://fonts.googleapis.com/css?family\x3dSignika:400,700", rel: "stylesheet", type: "text/css" }, null, document.getElementsByTagName("head")[0]); a.wrap(a.Chart.prototype, "getContainer", function (a) { a.call(this); this.container.style.background = "url(http://www.highcharts.com/samples/graphics/sand.png)" }); a.theme = { colors: "#f45b5b #8085e9 #8d4654 #7798BF #aaeeee #ff0066 #eeaaee #55BF3B #DF5353 #7798BF #aaeeee".split(" "),
	                    chart: { backgroundColor: null, style: { fontFamily: "Signika, serif"} }, title: { style: { color: "black", fontSize: "16px", fontWeight: "bold"} }, subtitle: { style: { color: "black"} }, tooltip: { borderWidth: 0 }, legend: { itemStyle: { fontWeight: "bold", fontSize: "13px"} }, xAxis: { labels: { style: { color: "#6e6e70"}} }, yAxis: { labels: { style: { color: "#6e6e70"}} }, plotOptions: { series: { shadow: !0 }, candlestick: { lineColor: "#404048" }, map: { shadow: !1} }, navigator: { xAxis: { gridLineColor: "#D0D0D8"} }, rangeSelector: { buttonTheme: { fill: "white", stroke: "#C0C0C8",
	                        "stroke-width": 1, states: { select: { fill: "#D0D0D8"}}
	                    }
	                    }, scrollbar: { trackBorderColor: "#C0C0C8" }, background2: "#E0E0E8"
	                }; a.setOptions(a.theme)
	            })(b)
	    });

	    ShowMap('');
	    });
</script>

</body></html>