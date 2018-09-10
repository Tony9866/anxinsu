 
             var chart = null;
$(function () {
    $('#containerPie3').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            spacing: [0, 0, 0, 0],
            height:'75%',
            backgroundColor: 'rgba(0,0,0,0)'
        },
        colors: [
            '#234591',
            '#00c4dd'
        ],
        title: {
            floating: true,
            text: '车位分析'
        },
                        credits: {  
          enabled:false  
},
exporting: {  
            enabled:false  
},
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                },
                point: {
                    events: {

                    }
                }
            }
        },
        series: [{
            type: 'pie',
            innerSize: '80%',
            name: '占比',
            borderWidth: 0,
            data: [
                
                ['已用', motorusedCount],
                {name:'空闲', y:motorleftCount,                    sliced: true,
                    selected: true}
            ]
        }]
    }, function (c) {
        // 环形图圆心
        var centerY = c.series[0].center[1],
            titleHeight = parseInt(c.title.styles.fontSize);
        c.setTitle({
            y: centerY + titleHeight / 2
        });
        chart = c;
    });
});

(function (a) { "object" === typeof module && module.exports ? module.exports = a : a(Highcharts) })(function (a) {
    a.createElement("link", { href: "https://fonts.googleapis.com/css?family\x3dUnica+One", rel: "stylesheet", type: "text/css" }, null, document.getElementsByTagName("head")[0]); a.theme = {
        colors: "#2b908f #90ee7e #f45b5b #7798BF #aaeeee #ff0066 #eeaaee #55BF3B #DF5353 #7798BF #aaeeee".split(" "), chart: {
            backgroundColor: { linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 }, stops: [[0, "#121b4a"], [1, "#121b4a"]] }, style: { fontFamily: "'Unica One', sans-serif" },
            plotBorderColor: "#606063"
        }, title: { style: { color: "#E0E0E3", textTransform: "uppercase", fontSize: "10px" } }, subtitle: { style: { color: "#E0E0E3", textTransform: "uppercase" } }, xAxis: { gridLineColor: "#707073", labels: { style: { color: "#E0E0E3" } }, lineColor: "#707073", minorGridLineColor: "#505053", tickColor: "#707073", title: { style: { color: "#A0A0A3" } } }, yAxis: { gridLineColor: "#707073", labels: { style: { color: "#E0E0E3" } }, lineColor: "#707073", minorGridLineColor: "#505053", tickColor: "#707073", tickWidth: 1, title: { style: { color: "#A0A0A3" } } },
        tooltip: { backgroundColor: "rgba(0, 0, 0, 0.85)", style: { color: "#F0F0F0" } }, plotOptions: { series: { dataLabels: { color: "#B0B0B3" }, marker: { lineColor: "#333" } }, boxplot: { fillColor: "#505053" }, candlestick: { lineColor: "white" }, errorbar: { color: "white" } }, legend: { itemStyle: { color: "#E0E0E3" }, itemHoverStyle: { color: "#FFF" }, itemHiddenStyle: { color: "#606063" } }, credits: { style: { color: "#666" } }, labels: { style: { color: "#707073" } }, drilldown: { activeAxisLabelStyle: { color: "#F0F0F3" }, activeDataLabelStyle: { color: "#F0F0F3" } }, navigation: {
            buttonOptions: {
                symbolStroke: "#DDDDDD",
                theme: { fill: "#505053" }
            }
        }, rangeSelector: { buttonTheme: { fill: "#505053", stroke: "#000000", style: { color: "#CCC" }, states: { hover: { fill: "#707073", stroke: "#000000", style: { color: "white" } }, select: { fill: "#000003", stroke: "#000000", style: { color: "white" } } } }, inputBoxBorderColor: "#505053", inputStyle: { backgroundColor: "#333", color: "silver" }, labelStyle: { color: "silver" } }, navigator: {
            handles: { backgroundColor: "#666", borderColor: "#AAA" }, outlineColor: "#CCC", maskFill: "rgba(255,255,255,0.1)", series: { color: "#7798BF", lineColor: "#A6C7ED" },
            xAxis: { gridLineColor: "#505053" }
        }, scrollbar: { barBackgroundColor: "#808083", barBorderColor: "#808083", buttonArrowColor: "#CCC", buttonBackgroundColor: "#606063", buttonBorderColor: "#606063", rifleColor: "#FFF", trackBackgroundColor: "#404043", trackBorderColor: "#404043" }, legendBackgroundColor: "rgba(0, 0, 0, 0.5)", background2: "#505053", dataLabelsColor: "#B0B0B3", textColor: "#C0C0C0", contrastTextColor: "#F0F0F3", maskColor: "rgba(255,255,255,0.3)"
    }; a.setOptions(a.theme)
});
 