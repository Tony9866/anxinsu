<%@ page language="C#" autoeventwireup="true" inherits="RentHouseReport_RentHouseForPoliceMonth, App_Web_axifaauw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>警局月统计</title>
     <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/ligerUI/js/plugins/ligerComboBox.js" type="text/javascript"></script> 
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script> 
    <script src="../lib/js/jquery.jqprint-0.3.js" type="text/javascript"></script> 
    <script src="../lib/commonvalidate.js" type="text/javascript"></script>
        
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <ipnut type="hidden" id="MenuNo" value="PoliceStationStatistic" />
  <div id="mainsearch" style=" width:98%">
    <div class="searchtitle">
        <span>搜索</span><img src="../lib/icons/32X32/searchtool.gif" />
        <div class="togglebtn"></div> 
    </div>
    <div class="navline" style="margin-bottom:4px; margin-top:4px;"></div>
    <div class="searchbox">
        <form id="formsearch" class="l-form"></form>
    </div>
  </div>
  <form id="mainform">
  <div id="maingrid" style="height:auto;"></div> 
  </form>
<script type="text/javascript">
    var rootPath = "../";
    var userId = <%=LigerRM.Common.SysContext.CurrentUserID %>;
    //搜索表单应用ligerui样式
    $("#formsearch").ligerForm({
        fields: [
          { display: "统计类型", name: "statistictype", newline: false, labelWidth: 80, width: 150, space: 30, type: "select", cssClass: "field", comboboxName: "统计类型",
              options: {
                  data: [
                    { text: '按年份统计', id: '0' },
                    { text: '按月份统计', id: '1' },
                    { text: '按日统计', id: '2' }
                ],
                  valueFieldID: 'statistictype'
              }
          },
            { display: "年份", name: "statisticyear", newline: false, labelWidth: 80, width: 80, space: 30, type: "select", cssClass: "field", comboboxName: "年份",
                options: {
                    url: '../handler/select.ashx?view=v_RentHistory_view&idfield=year&textfield=year&distinct=true',
                    valueFieldID: 'statisticyear'
                }
            },
          { display: "月份", name: "statisticmonth", newline: false, labelWidth: 80, width: 80, space: 30, type: "select", cssClass: "field", comboboxName: "月份",
              options: {
                  data: [
                    { text: '1月', id: '1' },
                    { text: '2月', id: '2' },
                    { text: '3月', id: '3' },
                    { text: '4月', id: '4' },
                    { text: '5月', id: '5' },
                    { text: '6月', id: '6' },
                    { text: '7月', id: '7' },
                    { text: '8月', id: '8' },
                    { text: '9月', id: '9' },
                    { text: '10月', id: '10' },
                    { text: '11月', id: '11' },
                    { text: '12月', id: '12' }
                ],
                  valueFieldID: 'statisticmonth'
              }
          },
            { display: "", name: "statisticday", newline: false, labelWidth: 0, width: 0.1, space: 0, type: "hidden", cssClass: "field" },
             {
                 display: "所属警局", name: "所属警局", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
                 options: {
                     url: '../handler/select.ashx?view=Rent_PoliceStation&idfield=PSName&textfield=PSName&distinct=true&needAll=1&&where={"op":"and","rules":[{"op":"equal","field":"ParentID","value":"0","type":"string"}]}',
                     initValue: '全部', valueFieldID: 'psname', selectBoxWidth: '160'
                 }
             },
            { display: "", name: "userId", newline: false, labelWidth: 0, width: 0, space: 0, type: "hidden", cssClass: "field" }

          ],
        toJSON: JSON2.stringify
    });
    $("[name=statistictype]").val('1');
    $("[name=统计类型]").val('按月份统计');

    var date = new Date();
    $("[name=statisticyear]").val(date.getFullYear());
    $("[name=年份]").val(date.getFullYear());
     $("#userId").val(userId);
    var m = 0;
    if (date.getMonth() >= 12)
        m = 1;
    else
        m = date.getMonth() + 1;

    $("[name=statisticmonth]").val(m);
    $("[name=月份]").val(m + "月");

    $("[name=统计类型]").change(function (value) {
        if ($("[name=statistictype]").val() == '0') {
            parent.f_reloadCurrentTab('../RentHouseReport/RentHouseForPolice.aspx', '房源时段统计');
        }
        if ($("[name=statistictype]").val() == '2') {
            parent.f_reloadCurrentTab('../RentHouseReport/RentHouseForPoliceDay.aspx', '房源时段统计');
        }
    });
    //列表结构
    var columnStr = [
          { display: "警局名称", name: "PSName", width: 250, type: "text", align: "left",
              totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:right>合计:</div>';
                        },
                        align: 'right'
                    }
          },
          { display: "1日", name: "num1", width: 50, minWidth: 50, type: "text", align: "center",
              totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
              render: function (item) {
                  if (item.num1 != null && item.num1 > 0)
                      return item.num1;
                  else
                      return "-";
              }
          },
       { display: "2日", name: "num2", width: 50, minWidth: 50, type: "text", align: "center",
           totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
           render: function (item) {
               if (item.num2 != null && item.num2 > 0)
                   return item.num2;
               else
                   return "-";
           }
       },
              { display: "3日", name: "num3", width: 50, minWidth: 50, type: "text", align: "center",
                  totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                  render: function (item) {
                      if (item.num3 != null && item.num3 > 0)
                          return item.num3;
                      else
                          return "-";
                  }
              },
                     { display: "4日", name: "num4", width: 50, minWidth: 50, type: "text", align: "center",
                         totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                         render: function (item) {
                             if (item.num4 != null && item.num4 > 0)
                                 return item.num4;
                             else
                                 return "-";
                         }
                     },
                            { display: "5日", name: "num5", width: 50, minWidth: 50, type: "text", align: "center",
                                totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                                render: function (item) {
                                    if (item.num5 != null && item.num5 > 0)
                                        return item.num5;
                                    else
                                        return "-";
                                }
                            }
                            , { display: "6日", name: "num6", width: 50, minWidth: 50, type: "text", align: "center",
                                totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                                render: function (item) {
                                    if (item.num6 != null && item.num6 > 0)
                                        return item.num6;
                                    else
                                        return "-";
                                }
                            }
                            , { display: "7日", name: "num7", width: 50, minWidth: 50, type: "text", align: "center",
                                totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                                render: function (item) {
                                    if (item.num7 != null && item.num7 > 0)
                                        return item.num7;
                                    else
                                        return "-";
                                }
                            }
                            ,
               { display: "8日", name: "num8", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num8 != null && item.num8 > 0)
                           return item.num8;
                       else
                           return "-";
                   }
               },
               { display: "9日", name: "num9", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num9 != null && item.num9 > 0)
                           return item.num9;
                       else
                           return "-";
                   }
               },
               { display: "10日", name: "num10", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num10 != null && item.num10 > 0)
                           return item.num10;
                       else
                           return "-";
                   }
               },
               { display: "11日", name: "num11", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num11 != null && item.num11 > 0)
                           return item.num11;
                       else
                           return "-";
                   }
               },
               { display: "12日", name: "num12", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num12 != null && item.num12 > 0)
                           return item.num12;
                       else
                           return "-";
                   }
               },
               { display: "13日", name: "num13", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num13 != null && item.num13 > 0)
                           return item.num13;
                       else
                           return "-";
                   }
               },
               { display: "14日", name: "num14", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num14 != null && item.num14 > 0)
                           return item.num14;
                       else
                           return "-";
                   }
               },
               { display: "15日", name: "num15", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num15 != null && item.num15 > 0)
                           return item.num15;
                       else
                           return "-";
                   }
               },
               { display: "16日", name: "num16", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num16 != null && item.num16 > 0)
                           return item.num16;
                       else
                           return "-";
                   }
               },
               { display: "17日", name: "num17", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num17 != null && item.num17 > 0)
                           return item.num17;
                       else
                           return "-";
                   }
               },
               { display: "18日", name: "num18", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num18 != null && item.num18 > 0)
                           return item.num18;
                       else
                           return "-";
                   }
               },
               { display: "19日", name: "num19", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num19 != null && item.num19 > 0)
                           return item.num19;
                       else
                           return "-";
                   }
               },
               { display: "20日", name: "num20", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num20 != null && item.num20 > 0)
                           return item.num20;
                       else
                           return "-";
                   }
               },
               { display: "21日", name: "num21", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num21 != null && item.num21 > 0)
                           return item.num21;
                       else
                           return "-";
                   }
               },
               { display: "22日", name: "num22", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num22 != null && item.num22 > 0)
                           return item.num22;
                       else
                           return "-";
                   }
               },
               { display: "23日", name: "num23", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num23 != null && item.num23 > 0)
                           return item.num23;
                       else
                           return "-";
                   }
               },
               { display: "24日", name: "num24", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num24 != null && item.num24 > 0)
                           return item.num24;
                       else
                           return "-";
                   }
               },
               { display: "25日", name: "num25", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num25 != null && item.num25 > 0)
                           return item.num25;
                       else
                           return "-";
                   }
               },
               { display: "26日", name: "num26", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num26 != null && item.num26 > 0)
                           return item.num26;
                       else
                           return "-";
                   }
               },
               { display: "27日", name: "num27", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num27 != null && item.num27 > 0)
                           return item.num27;
                       else
                           return "-";
                   }
               },
               { display: "28日", name: "num28", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num28 != null && item.num28 > 0)
                           return item.num28;
                       else
                           return "-";
                   }
               },
               { display: "29日", name: "num29", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num29 != null && item.num29 > 0)
                           return item.num29;
                       else
                           return "-";
                   }
               },
               { display: "30日", name: "num30", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num30 != null && item.num30 > 0)
                           return item.num30;
                       else
                           return "-";
                   }
               },
               { display: "31日", name: "num31", width: 50, minWidth: 50, type: "text", align: "center",
                   totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:center>' + suminf.sum + '</div>';
                        }
                    },
                   render: function (item) {
                       if (item.num31 != null && item.num31 > 0)
                           return item.num31;
                       else
                           return "-";
                   }
               }];

    var toolbarOptions = {
        items: [
            { text: '打印', id: 'print', click: toolbarBtnItemClick, img: "../lib/icons/32X32/print.gif" },
            { line: true },
            { text: '图表', id: 'chart', click: toolbarBtnItemClick, img: "../lib/icons/silkicons/chart_bar.png" },
            { line: true },
            { text: '分布图', id: 'Scatt', click: toolbarBtnItemClick, img: "../lib/icons/silkicons/heart.png" }
        ]
    };

    var grid = $("#maingrid").ligerGrid({
        columns: columnStr,
        dataAction: 'server', pageSize: 20, toolbar: {},
        url: rootPath + 'handler/grid.ashx?procedure=up_RentReport_RentHouseStatisticByPoliceStation',
        parms: { where: JSON2.stringify({
            op: 'and',
            rules: [{ field: 'statistictype', value: $("[name=statistictype]").val(), type: 'string' },
              { field: 'statisticyear', value: $("[name=statisticyear]").val(), type: 'string' },
              { field: 'statisticmonth', value: $("[name=statisticmonth]").val(), type: 'string' },
               { field: 'statisticday', value: '', type: 'string' },
              { field: 'psname', value: $("#psname").val(), type: 'string'},
              { field: 'userId', value:userId, type: 'string'}]
        }
          )
        }, toolbar: toolbarOptions,
        sortName: 'PSName',
        width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26,
        selectRowButtonOnly: true, usePager: false
    });

    //加载toolbar
    //LG.loadToolbar(grid, toolbarBtnItemClick);
    //工具条事件
    function toolbarBtnItemClick(item) {
        switch (item.id) {
            case "print":
                $("#maingrid").jqprint({ debug: false, operaSupport: true });
                //$("#maingrid").printArea();
                break;
            case "chart":
                top.f_addTab(null, '月度统计', "../RentHouseReport/RentLineChart.aspx?type=1&category=" + $("#statistictype").val() + "&year=" + $("#statisticyear").val() + "&month=" + $("#statisticmonth").val() + "&day=" + $("#statisticday").val() + "&psname=" + $("#psname").val());
                break;
            case "Scatt":
                top.f_addTab(null, '租赁分布点图', "../RentHouseReport/RentScattergram.aspx?type=1&category=" + $("#statistictype").val() + "&year=" + $("#statisticyear").val() + "&month=" + $("#statisticmonth").val() + "&day=" + $("#statisticday").val() + "&psname=" + $("#psname").val());
                break;
        }
    }



    //增加搜索按钮,并创建事件
    LG.appendSearchButtonsNoAdvance("#formsearch", grid);

    function f_reload() {
        grid.loadData();
    }
     
</script>

</body>
</html>
