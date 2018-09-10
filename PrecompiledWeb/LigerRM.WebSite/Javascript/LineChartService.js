$(function () {
    $('#containerLine1').highcharts({
        chart: {
            type: 'bar',
            height:'300',
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
            categories: ['暂住证登记', '组织关系', '准生证登记', '日租房申请', '车辆登记', '养老保险', '医疗保险', '低保申请', '户口变更', '残联服务'],
            title: {
                text: null
            },
            gridLineWidth: '0',
            gridLineColor: '#121b4a',
            lineColor: '#121b4a',
            tickColor: '#121b4a',
            tickWidth: 20,
            tickInterval: 0,
            title: {
                text: ''
            },
            labels: {
                enabled: true,
                style:
                {
                    color:"#fff",
                    fontSize:'10px'
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
            tickWidth: 20,
            tickInterval: 200,
            title: {
                text: ''
            },
            labels: {
                enabled: false
            },
            tickPositions: [0, 10]
        },
        tooltip: {
            valueSuffix: '分'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: false,
                    allowOverlap: false
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
            name: '分数',
            borderWidth: 0,
            color: '#00c4dd',
            data: [5, 3, 7, 10, 7, 9, 9, 8, 8, 3]
        }]
    });
});


