<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="ChartDrill, App_Web_gl2v1pkx" %>
=======
<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="ChartDrill, App_Web_3k4kbla2" %>
=======
﻿<%@ page language="C#" autoeventwireup="true" inherits="ChartDrill, App_Web_zohai5sv" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script type="text/javascript" src="../lib/js/jquery-1.8.3.min.js"></script>
  <script type="text/javascript" src="../lib/js/highcharts.js"></script>
  <script type="text/javascript" src="http://cdn.hcharts.cn/highcharts/exporting.js"></script>
  <script type="text/javascript">
      $(function () {


          Highcharts.theme = {
              colors: ["#DDDF0D", "#55BF3B", "#DF5353", "#7798BF", "#aaeeee", "#ff0066", "#eeaaee",
		"#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
              chart: {
                  backgroundColor: {
                      linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                      stops: [
				[0, 'rgb(48, 48, 96)'],
				[1, 'rgb(0, 0, 0)']
			]
                  },
                  borderColor: '#000000',
                  borderWidth: 2,
                  className: 'dark-container',
                  plotBackgroundColor: 'rgba(255, 255, 255, .1)',
                  plotBorderColor: '#CCCCCC',
                  plotBorderWidth: 1
              },
              title: {
                  style: {
                      color: '#C0C0C0',
                      font: 'bold 16px "Trebuchet MS", Verdana, sans-serif'
                  }
              },
              subtitle: {
                  style: {
                      color: '#666666',
                      font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'
                  }
              },
              xAxis: {
                  gridLineColor: '#333333',
                  gridLineWidth: 1,
                  labels: {
                      style: {
                          color: '#A0A0A0'
                      }
                  },
                  lineColor: '#A0A0A0',
                  tickColor: '#A0A0A0',
                  title: {
                      style: {
                          color: '#CCC',
                          fontWeight: 'bold',
                          fontSize: '12px',
                          fontFamily: 'Trebuchet MS, Verdana, sans-serif'

                      }
                  }
              },
              yAxis: {
                  gridLineColor: '#333333',
                  labels: {
                      style: {
                          color: '#A0A0A0'
                      }
                  },
                  lineColor: '#A0A0A0',
                  minorTickInterval: null,
                  tickColor: '#A0A0A0',
                  tickWidth: 1,
                  title: {
                      style: {
                          color: '#CCC',
                          fontWeight: 'bold',
                          fontSize: '12px',
                          fontFamily: 'Trebuchet MS, Verdana, sans-serif'
                      }
                  }
              },
              tooltip: {
                  backgroundColor: 'rgba(0, 0, 0, 0.75)',
                  style: {
                      color: '#F0F0F0'
                  }
              },
              toolbar: {
                  itemStyle: {
                      color: 'silver'
                  }
              },
              plotOptions: {
                  line: {
                      dataLabels: {
                          color: '#CCC'
                      },
                      marker: {
                          lineColor: '#333'
                      }
                  },
                  spline: {
                      marker: {
                          lineColor: '#333'
                      }
                  },
                  scatter: {
                      marker: {
                          lineColor: '#333'
                      }
                  },
                  candlestick: {
                      lineColor: 'white'
                  }
              },
              legend: {
                  itemStyle: {
                      font: '9pt Trebuchet MS, Verdana, sans-serif',
                      color: '#A0A0A0'
                  },
                  itemHoverStyle: {
                      color: '#FFF'
                  },
                  itemHiddenStyle: {
                      color: '#444'
                  }
              },
              credits: {
                  style: {
                      color: '#666'
                  }
              },
              labels: {
                  style: {
                      color: '#CCC'
                  }
              },

              navigation: {
                  buttonOptions: {
                      symbolStroke: '#DDDDDD',
                      hoverSymbolStroke: '#FFFFFF',
                      theme: {
                          fill: {
                              linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                              stops: [
						[0.4, '#606060'],
						[0.6, '#333333']
					]
                          },
                          stroke: '#000000'
                      }
                  }
              },

              // scroll charts
              rangeSelector: {
                  buttonTheme: {
                      fill: {
                          linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                          stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
                      },
                      stroke: '#000000',
                      style: {
                          color: '#CCC',
                          fontWeight: 'bold'
                      },
                      states: {
                          hover: {
                              fill: {
                                  linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                  stops: [
							[0.4, '#BBB'],
							[0.6, '#888']
						]
                              },
                              stroke: '#000000',
                              style: {
                                  color: 'white'
                              }
                          },
                          select: {
                              fill: {
                                  linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                  stops: [
							[0.1, '#000'],
							[0.3, '#333']
						]
                              },
                              stroke: '#000000',
                              style: {
                                  color: 'yellow'
                              }
                          }
                      }
                  },
                  inputStyle: {
                      backgroundColor: '#333',
                      color: 'silver'
                  },
                  labelStyle: {
                      color: 'silver'
                  }
              },

              navigator: {
                  handles: {
                      backgroundColor: '#666',
                      borderColor: '#AAA'
                  },
                  outlineColor: '#CCC',
                  maskFill: 'rgba(16, 16, 16, 0.5)',
                  series: {
                      color: '#7798BF',
                      lineColor: '#A6C7ED'
                  }
              },

              scrollbar: {
                  barBackgroundColor: {
                      linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                      stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
                  },
                  barBorderColor: '#CCC',
                  buttonArrowColor: '#CCC',
                  buttonBackgroundColor: {
                      linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                      stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
                  },
                  buttonBorderColor: '#CCC',
                  rifleColor: '#FFF',
                  trackBackgroundColor: {
                      linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                      stops: [
				[0, '#000'],
				[1, '#333']
			]
                  },
                  trackBorderColor: '#666'
              },

              // special colors for some of the
              legendBackgroundColor: 'rgba(0, 0, 0, 0.5)',
              background2: 'rgb(35, 35, 70)',
              dataLabelsColor: '#444',
              textColor: '#C0C0C0',
              maskColor: 'rgba(255,255,255,0.3)'
          };

          // Apply the theme
          var highchartsOptions = Highcharts.setOptions(Highcharts.theme);

          var colors = Highcharts.getOptions().colors,
        categories = ['<%=Categorys %>'],
        name = '<%=Name %>',
        data = [<%=Data %>];

          function setChart(name, categories, data, color) {
              chart.xAxis[0].setCategories(categories, false);
              chart.series[0].remove(false);
              chart.addSeries({
                  name: name,
                  data: data
              }, false);
              chart.redraw();
          }

          var chart = $('#container').highcharts({
              chart: {
                  type: 'column'
              },
              title: {
                  text: '<%=Title %>'
              },
              subtitle: {
                  text: '<%=SubTitle %>'
              },
              xAxis: {
                  categories: categories
              },
              yAxis: {
                  title: {
                      text: '<%=yAxis %>'
                  }
              },
              plotOptions: {
                  column: {
                      cursor: 'pointer',
                      point: {
                          events: {
                              click: function () {
                                  var drilldown = this.drilldown;
                                  if (drilldown) { // drill down
                                      setChart(drilldown.name, drilldown.categories, drilldown.data);
                                  } else { // restore
                                      setChart(name, categories, data);
                                  }
                              }
                          }
                      },
                      dataLabels: {
                          enabled: true,
                          color: colors[0],
                          style: {
                              fontWeight: 'bold'
                          },
                          formatter: function () {
                              return this.y + '枚';
                          }
                      }
                  }
              },
              tooltip: {
                  formatter: function () {
                      var point = this.point,
                    s = this.x + ':<b>' + this.y + '枚</b><br/>';
                      if (point.drilldown) {
                          s += '点击查看[' + point.category + ']下印章状态分组数量';
                      } else {
                          s += '点击返回分类汇总';
                      }
                      return s;
                  }
              },
              series: [{
                  name: name,
                  data: data
              }],
              exporting: {
                  enabled: true
              }
          })
    .highcharts(); // return chart
      });				
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="container" style="min-width:700px;height:350px;"></div>
    </div>
    </form>
</body>
</html>
