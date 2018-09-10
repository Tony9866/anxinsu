
$(function () {
    $('#containerLine3').highcharts({
        chart: {
            type: 'column',
            height: '75%',
            backgroundColor: 'rgba(0,0,0,0)'
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
                '21',
                '19',
                '18',
                '23',
                '15',
                '14'
            ],
            gridLineWidth: '0',
            gridLineColor: '#121b4a',
            lineColor: '#121b4a',
            tickColor: '#121b4a',
            tickWidth: 0,
            crosshair: true,
            labels: {
                enabled: true
            }
        },
        yAxis: {
            min: 0,
            gridLineWidth: '0',
            gridLineColor: '#121b4a',
            lineColor: '#121b4a',
            tickColor: '#121b4a',
            tickWidth: 0,
            title: {
                text: ''
            },
                        labels: {
                enabled: false
            },
            tickInterval: 200,
            tickPositions: [0, 20]
        },
        tooltip: {
            footerFormat: '{series.name}: <b>{point.y} C',
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
                    enabled: true,
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
            name: '天津',
            color: '#00c4dd',
            data: [18, 17, 12, 9, 9, 5]
        }]
    });
});
 