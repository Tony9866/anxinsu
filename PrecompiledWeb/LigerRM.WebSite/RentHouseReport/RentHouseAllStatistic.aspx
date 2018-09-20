<%@ page language="C#" autoeventwireup="true" inherits="RentHouseReport_RentHouseAllStatistic, App_Web_zdvowk53" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>使用单位分类统计</title>
     <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script> 
    <script src="../lib/js/jquery.jqprint-0.3.js" type="text/javascript"></script> 
    <script src="../lib/commonvalidate.js" type="text/javascript"></script>
        
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <ipnut type="hidden" id="MenuNo" value="AllPoliceHouse" />
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
          { display: "登记日期", name: "adt_from_date", newline: false, labelWidth: 80, width: 100, space: 20, type: "date", cssClass: "field" },
          { display: "至", name: "adt_to_date", newline: false, labelWidth: 20, width: 100, space: 30, type: "date", cssClass: "field" },
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
    var dtNow = new Date();
    var dtNew = new Date(dtNow.getTime() + 1 * 24 * 60 * 60 * 1000);
    var dtStart = new Date(dtNow.getTime() + -30 * 24 * 60 * 60 * 1000);
    var date = new Date();

    $("#adt_to_date").ligerDateEditor().setValue(dtNew.toFomatorString("YYYY-MM-DD"));
    $("#adt_from_date").ligerDateEditor().setValue(dtStart.toFomatorString("YYYY-MM-DD"));
    $("#userId").val(userId);
    //列表结构
    var grid = $("#maingrid").ligerGrid({
        columns: [

          {
              display: "所属警局", name: "PSName", width: 350, type: "text", align: "left",
              totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;>合计:</div>';
                        },
                        align: 'right'
                    }
          },
          {
              display: "房屋登记住量", name: "RentRecordCount", width: 180, minWidth: 80, type: "text", align: "left",
              totalSummary:
                    {
                        type: 'sum',
                        render: function (suminf, column, cell) {
                            return '<div style=color:red;>' + suminf.sum + '</div>';
                        }
                    },
              render: function (item) {
                  if (item.RentRecordCount != null && item.RentRecordCount > 0)
                      return item.RentRecordCount;
                  else
                      return "-";
              }
          }
          ],
        dataAction: 'server', pageSize: 20, toolbar: {},
        url: rootPath + 'handler/grid.ashx?procedure=up_RentReport_RentInfoStatisticAllByPoliceHouseStation',
        parms: { where: JSON2.stringify({
            op: 'and',
            rules: [{ field: 'adt_from_date', value: $("#adt_from_date").val(), type: 'string' },
              { field: 'adt_to_date', value: $("#adt_to_date").val(), type: 'string' },
              { field: 'psname', value: $("#psname").val(), type: 'string'},
              { field: 'userId', value:userId, type: 'string'}]
        }
          )
        },
        sortName: 'PSName',
        width: '100%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26,
        selectRowButtonOnly: true, clickToEdit: false, rownumbers: true, usePager: false, isScroll: false
    });

    //加载toolbar
    LG.loadToolbar(grid, toolbarBtnItemClick);
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
                top.f_addTab(null, '房源全量统计', "../RentHouseReport/RentColumnChart.aspx?category=AllPoliceHouse&sDate=" + $("#adt_from_date").val() + "&eDate=" + $("#adt_to_date").val() + "&psname=" + $("#psname").val());
                //$.ligerDialog.open({ url: "../chartdrill.aspx?category=CorClass&sDate=" + $("#adt_from_date").val() + "&eDate=" + $("#adt_to_date").val() + "&type=" + type, width: 900, height: 450 }); return;
                break;
            case "pie":
                var type = $("#as_signet_type").val();
                if (type == "全部")
                    type = "";
                top.f_addTab(null, '房源全量统计', "../RentHouseReport/RentPieChart.aspx?category=AllPoliceHouse&sDate=" + $("#adt_from_date").val() + "&eDate=" + $("#adt_to_date").val() + "&psname=" + $("#psname").val());
                //$.ligerDialog.open({ url: "../chartdrill.aspx?category=CorClass&sDate=" + $("#adt_from_date").val() + "&eDate=" + $("#adt_to_date").val() + "&type=" + type, width: 900, height: 450 }); return;
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

