$(function () {
    $('#containerLine2').highcharts({
        chart: {
            type: 'column',
            height: '75%',
            backgroundColor: 'rgba(0,0,0,0)',
            color:'#ffffff'
        },
        title: {
            text: ''
        },

        credits: {
            enabled: false
        },
        exporting: {
            enabled: false
        },
        xAxis: {
            categories: [
                '1#',
                '2#',
                '3#',
                '4#',
                '5#',
                '6#',
                '7#'
            ],
            gridLineWidth: '0',
            gridLineColor: '#121b4a',
            lineColor: '#121b4a',
            tickColor: '#121b4a',
            tickWidth: 0,
            color: '#ffffff',
            crosshair: true,
            labels: {
                enabled: true,
                color:'#ffffff'
            }
        },
        yAxis: {
            min: 0,
            gridLineWidth: '0',
            gridLineColor: '#121b4a',
            lineColor: '#121b4a',
            tickColor: '#121b4a',
            tickWidth: 0,
            color:'#ffffff',
            title: {
                text: ''
            },
            labels: {
                enabled: false
            },
            tickInterval: 2000,
            tickPositions: [0, 350]
        },
        tooltip: {

            pointFormat: '{series.name}: <b>{point.y:.0f}人</b>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            },
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: false,
                    format: '{point.y}',
                    color:'#ffffff'
                }
            }
        },
        legend: {

            enabled: false,
            floating: true

        },
        series: [{
            name: '人数',
            color: '#00c4dd',
            data: [96, 152, 103, 329,53,23,33]
        }]
    });
});

