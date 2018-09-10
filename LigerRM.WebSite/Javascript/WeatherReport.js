
$(function () {
    $('#divWeather').highcharts({
        chart: {
            type: 'areaspline',
            backgroundColor: 'rgba(0,0,0,0)'
        },
        title: {
            text: ''
        },
        legend: {
            layout: 'vertical',
            align: 'left',
            verticalAlign: 'top',
            x: 50,
            y: 50,
            floating: true,
            borderWidth: 1,
            backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'
        },
        xAxis: {
            categories: c,
            plotBands: [{ // visualize the weekend
                from: 4.5,
                to: 6.5,
                color: 'rgba(68, 170, 213, .2)'
            }],
            lineColor:'#ffffff',//设置坐标颜色  
            lineWidth:0,        //设置坐标宽度  
            gridLineWidth: '0',
            gridLineColor: '#04060e',
            labels: {
                enabled: true
            } 
        },
        yAxis: {
            title: {
                text: ''
            },
            gridLineWidth: '0',
            gridLineColor: '#04060e',
            labels: {
                enabled: false
            } 
        },
        tooltip: {
            shared: true,
            valueSuffix: '度'
        },
        credits: {
            enabled: false
        },
        plotOptions: {
            areaspline: {
                fillOpacity: 0.5
            }
        },
        legend: {

            enabled: false,
            floating: true,
            labels: {
                enabled: false
            } 
        },
        exporting: {
            enabled: false
        },
        series: [{
            name: '温度',
            data: t
        }]
    });
});