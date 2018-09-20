<%@ page language="C#" autoeventwireup="true" inherits="RentHouseReport_RentLineChart, App_Web_axifaauw" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <script type="text/javascript" src="../lib/js/jquery-1.8.3.min.js"></script>
  <script type="text/javascript" src="../lib/js/highcharts.js"></script>
  <script type="text/javascript" src="http://cdn.hcharts.cn/highcharts/exporting.js"></script>
  <script type="text/javascript">
      $(function () {
          var title;
          var subtitle;
          var yTitle;
          var xTitle;
          var category;
          var serieTitle;
          var data;

          title = "<%=title %>";
          subtitle = "<%=subtitle %>";
          yTitle = "<%=yTitle %>";

          serieTitle = "日揽件量"
          category = [<%=category %>];

          var chartData=[];

          <%for(int j=0;j<serialData.Length;j++) 
          {%>
            chartData.push({name:'<%=serialName[j] %>',data:[<%=serialData[j] %>]});
          <%} %>


          $('#container').highcharts({
              chart: {
                  type: 'line'
              },
              title: {
                  text: title
              },
              subtitle: {
                  text: subtitle
              },
              xAxis: {
                  categories: category
              },
              yAxis: {
                  title: {
                      text: yTitle
                  }
              },
              plotOptions: {
                  line: {
                      dataLabels: {
                          enabled: true
                      },
                      enableMouseTracking: true
                  }
              },
              series: chartData
          });
      });
			
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="container"></div>
    </div>
    </form>
</body>
</html>
