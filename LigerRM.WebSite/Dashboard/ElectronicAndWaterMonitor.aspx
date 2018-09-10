<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ElectronicAndWaterMonitor.aspx.cs" Inherits="Dashboard_ElectronicAndWaterMonitor" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><html><head>
	<meta charset="utf-8">
 <link rel="icon" href="https://static.jianshukeji.com/highcharts/images/favicon.ico">
<meta name="viewport" content="width=device-width, initial-scale=1">	<meta name="description" content="">
	<title>电量监测</title>
	<script src="https://img.hcharts.cn/jquery/jquery-1.8.3.min.js"></script>
	<script src="https://img.hcharts.cn/highcharts/highcharts.js"></script>
	<script src="https://img.hcharts.cn/highcharts/modules/exporting.js"></script>
	<script src="https://img.hcharts.cn/highcharts-plugins/highcharts-zh_CN.js"></script>
</head>
<body>
<form runat="server" >
<div style="border-bottom:solid 2px #cccccc; margin:5px;height:30px; padding-top:5px;">
    <table border="0" cellpadding="0" cellspacing="0" style="font-family: 黑体; font-size:14px; width:100%;">
        <tr>
        <td>
        监测用户：
        </td><td>
    <asp:DropDownList ID="ddlAddress" runat="server" AutoPostBack="True">
    </asp:DropDownList>
        </td><td align="right">
            <input type="button" value="远程断电" onclick="javascript:window.clearInterval(t1);alert('断电成功！');" />
        </td></tr>
    </table>


</div>
<div id="container" style="min-width:400px;height:400px"></div>

	<script>
	    Highcharts.setOptions({
	        global: {
	            useUTC: false
	        }
	    });
	    function activeLastPointToolip(chart) {
	        var points = chart.series[0].points;
	        chart.tooltip.refresh(points[points.length - 1]);
	    }
	    var t1;
	    $('#container').highcharts({
	        chart: {
	            type: 'spline',
	            animation: Highcharts.svg, // don't animate in old IE
	            marginRight: 10,
	            events: {
	                load: function () {
	                    // set up the updating of the chart each second
	                    var series = this.series[0],
                    chart = this;
	                    t1 = setInterval(function () {
	                        var x = (new Date()).getTime(), // current time
                        y = Math.random();
	                        series.addPoint([x, y], true, true);
	                        activeLastPointToolip(chart)
	                    }, 5000);
	                }
	            }
	        },
	        title: {
	            text: '用电实时数据'
	        },
	        xAxis: {
	            type: 'datetime',
	            tickPixelInterval: 150
	        },
	        yAxis: {
	            title: {
	                text: '值'
	            },
	            plotLines: [{
	                value: 0,
	                width: 1,
	                color: '#808080'
	            }]
	        },
	        tooltip: {
	            formatter: function () {
	                if (Highcharts.numberFormat(this.y, 2) > 0.6)
	                    return '<b style="color:red;">' + this.series.name + '</b><br/><span style="color:red;">' +
                                Highcharts.dateFormat('%Y-%m-%d %H:%M:%S', this.x) + '</span><br/><span style="color:red;">用电量：' +
                                Highcharts.numberFormat(this.y, 2) + 'kw/h</span>';
	                else
	                    return '<b>' + this.series.name + '</b><br/>' +
                                Highcharts.dateFormat('%Y-%m-%d %H:%M:%S', this.x) + '<br/>用电量：' +
                                Highcharts.numberFormat(this.y, 2)+'kw/h';
	            }
	        },
	        legend: {
	            enabled: false
	        },
	        exporting: {
	            enabled: false
	        },
	        series: [{
	            name: '用电量',
	            data: (function () {
	                // generate an array of random data
	                var data = [],
                time = (new Date()).getTime(),
                i;
	                for (i = -19; i <= 0; i += 1) {
	                    data.push({
	                        x: time + i * 1000,
	                        y: Math.random()
	                    });
	                }
	                return data;
	            } ())
	        }]
	    }, function (c) {
	        activeLastPointToolip(c)
	    });
</script>
</form>
</body></html>