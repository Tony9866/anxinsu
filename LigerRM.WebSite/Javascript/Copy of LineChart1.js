$(function () {
    $('#containerLine1').highcharts({
        chart: {
            type: 'bar'
        },
        title: {
            text: ''
        },
        xAxis: {
            categories: ['非洲', '美洲', '亚洲', '欧洲', '大洋洲'],
            gridLineWidth: '0',
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            gridLineWidth:'0'
        },
        tooltip: {
            valueSuffix: ' 百万'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: false,
                    allowOverlap: false
                }
            }
        },
        credits: {
            enabled: false
        },
        exporting: {
            enabled: false
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 100,
            enabled: false,
            floating: true,
            borderWidth: 0,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: false
        },
        credits: {
            enabled: false
        },
        series: [{
            name: null,
                            dataLabels: {
                    enabled: false,
                    allowOverlap: false
                },
            data: [107, 31, 635, 203, 2]
        }]
    });
});