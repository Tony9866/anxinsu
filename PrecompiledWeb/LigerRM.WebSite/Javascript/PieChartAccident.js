
var chart = null;
var sIndex = 0;
var sliced0 = true;
var slected0 = true;
var sliced1 = false;
var slected1 = false;
var sliced2 = false;
var slected2 = false;
var stitle = "已处理：62.5%";

//$(function () {
function DrawAccident() {
    
    if (sIndex == 0) {
        sliced0 = true;
        slected0 = true;
        sliced1 = false;
        slected1 = false;
        sliced2 = false;
        slected2 = false;
        stitle = "已处理<br/>62.5%";
    }

    if (sIndex == 1) {
        sliced0 = false;
        slected0 = false;
        sliced1 = true;
        slected1 = true;
        sliced2 = false;
        slected2 = false;
        stitle = "未处理<br/>12.5%";
    }

    if (sIndex == 2) {
        sliced0 = false;
        slected0 = false;
        sliced1 = false;
        slected1 = false;
        sliced2 = true;
        slected2 = true;
        stitle = "处理中<br/>25%";
    }

    $('#containerPie1').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            spacing: [0, 0, 0, 0],
            height: '75%',
            backgroundColor: 'rgba(0,0,0,0)'
        },
        colors: [
            '#234591',
            '#00c4dd',
            '#ffffff'
        ],
        title: {
            floating: true,
            text: stitle,
            style:
            {
                fontSize: '1em'
            }
        },
        credits: {
            enabled: false
        },
        exporting: {
            enabled: false
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

            }
        }
    },
    series: [{
        type: 'pie',
        innerSize: '80%',
        borderWidth: 0,
        name: '占比',
        data: [
                { name: '已处理', y: 5,
                    sliced: sliced0,
                    selected: slected0
                },
                { name: '未处理', y: 1,
                    sliced: sliced1,
                    selected: slected1
                },
                {
                    name: '处理中',
                    y: 2,
                    sliced: sliced2,
                    selected: slected2
                }
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

if (sIndex == 0)
    sIndex = 1;
else {
    if (sIndex == 1)
        sIndex = 2;
    else {
        if (sIndex == 2)
            sIndex = 0;
    }
    } 
}
    //});

    $(function () {
        DrawAccident();

        window.setInterval(DrawAccident, 6000);
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
