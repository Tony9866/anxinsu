
$(function () {
    $('#divEnv').highcharts({
        chart: {
            type: 'bar',
            backgroundColor: 'rgba(0,0,0,0)'
        },
        title: {
            text: ''
        },
        subtitle: {
            text: ''
        },
        credits: {
            enabled: false
        },
        exporting: {
            enabled: false
        },
        xAxis: {
            categories: ['PM25', 'PM10'],
            title: {
                text: null
            },
            gridLineWidth: '0',
            gridLineColor: '#121b4a',
            lineColor: '#121b4a',
            tickColor: '#121b4a',
            tickWidth: 0,
            title: {
                text: ''
            },
            labels: {
                enabled: true,
                style:
                {
                    color: "#fff",
                    fontSize: '10px'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: '',
                align: 'high'
            },
            gridLineWidth: '0',
            gridLineColor: '#121b4a',
            lineColor: '#121b4a',
            tickColor: '#121b4a',
            tickWidth: 0,
            tickPositions: [0, 200],
            title: {
                text: ''
            },
            labels: {
                enabled: false
            },
            tickInterval: 1200,
            tickPositions: [0, 200]
        },
        tooltip: {
            valueSuffix: ''
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: false,
                    allowOverlap: false
                }
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
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: 0,
            y: 0,
            floating: false,
            borderWidth: 0,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true,
            enabled: false
        },
        credits: {
            enabled: false
        },
        series: [{
            name: '指数',
            color: '#00c4dd',
            data: env
        }]
    });
});


