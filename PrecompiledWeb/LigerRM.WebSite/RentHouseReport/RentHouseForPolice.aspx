<%@ page language="C#" autoeventwireup="true" inherits="RentHouseReport_RentHouseForPolice, App_Web_atbcerl0" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>房源年统计</title>
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
   <ipnut type="hidden" id="MenuNo" value="HouseDate" />
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
            { display: "", name: "statisticmonth", newline: false, labelWidth: 0, width: 0.1, space: 0, type: "hidden", cssClass: "field" },
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
    $("[name=statistictype]").val('0');
    $("[name=统计类型]").val('按年份统计');

    var date = new Date();
    $("[name=statisticyear]").val(date.getFullYear());
    $("[name=年份]").val(date.getFullYear());

     $("#userId").val(userId);

    $("[name=统计类型]").change(function (value) {
        if ($("[name=statistictype]").val() == '1') {
            parent.f_reloadCurrentTab('../RentHouseReport/RentHouseForPoliceMonth.aspx', '房源时段统计');
        }
        if ($("[name=statistictype]").val() == '2') {
            parent.f_reloadCurrentTab('../RentHouseReport/RentHouseForPoliceDay.aspx', '房源时段统计');
        }
    });
    //列表结构
    var columnStr = [
          {
              display: "警局名称", name: "PSName", width: 250, type: "text", align: "left",
              totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;text-align:right>合计:</div>';
                        },
                        align: 'right'
                    }
          },
          { display: "1月", name: "num1", width: 50, minWidth: 50, type: "text", align: "center",
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
       { display: "2月", name: "num2", width: 50, minWidth: 50, type: "text", align: "center",
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
              { display: "3月", name: "num3", width: 50, minWidth: 50, type: "text", align: "center",
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
                     { display: "4月", name: "num4", width: 50, minWidth: 50, type: "text", align: "center",
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
                            { display: "5月", name: "num5", width: 50, minWidth: 50, type: "text", align: "center",
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
                            , { display: "6月", name: "num6", width: 50, minWidth: 50, type: "text", align: "center",
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
                            , { display: "7月", name: "num7", width: 50, minWidth: 50, type: "text", align: "center",
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
               { display: "8月", name: "num8", width: 50, minWidth: 50, type: "text", align: "center",
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
               { display: "9月", name: "num9", width: 50, minWidth: 50, type: "text", align: "center",
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
               { display: "10月", name: "num10", width: 50, minWidth: 50, type: "text", align: "center",
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
               { display: "11月", name: "num11", width: 50, minWidth: 50, type: "text", align: "center",
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
               { display: "12月", name: "num12", width: 50, minWidth: 50, type: "text", align: "center",
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
              { field: 'statisticmonth', value: '', type: 'string' },
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
                var type = $("#as_signet_type").val();
                if (type == "全部")
                    type = "";
                top.f_addTab(null, '年度统计', "../RentHouseReport/RentLineChart.aspx?type=1&category=" + $("#statistictype").val() + "&year=" + $("#statisticyear").val() + "&month=" + $("#statisticmonth").val() + "&day=" + $("#statisticday").val() + "&psname=" + $("#psname").val());
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

