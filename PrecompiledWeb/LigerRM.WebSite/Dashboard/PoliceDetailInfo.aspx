<%@ page language="C#" autoeventwireup="true" inherits="Dashboard_PoliceDetailInfo, App_Web_beoost5v" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>警情信息</title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script>
</head>
<body style="padding:10px;height:100%; text-align:center;">

   <input type="hidden" id="MenuNo" value="Rent" />
  <div id="mainsearch" style="width:98%;">
    <div class="searchtitle">
        <span>搜索</span><img src="../lib/icons/32X32/searchtool.gif" />
        <div class="togglebtn"></div> 
    </div>
    <div class="navline" style="margin-bottom:4px; margin-top:4px;"></div>
    <div class="searchbox">
        <form id="formsearch" class="l-form"></form>
    </div>
  </div>
  <div id="maingrid"></div> 
  <script type="text/javascript">
      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [

          { display: "接警单号", name: "AlertNO", width: 180, type: "text", align: "left" },
                { display: "报警时间", name: "AlertTime", width: 150, type: "textarea", align: "left" },
                { display: "报警类型", name: "AlertType", width: 120, type: "text", align: "left" },
                { display: "事发地点", name: "AlertAddress", width: 200, type: "text", align: "left"  },
                { display: "报案内容", name: "AlertContent", width: 400, type: "text", align: "left"},
                { display: "警情状态", name: "AlertStatus", width: 100, type: "text", align: "left"}],
          dataAction: 'server', pageSize: 20, toolbar: null,
          url: rootPath + 'handler/grid.ashx?view=v_Police_AlertInfo', sortName: 'AlertTime', sortOrder: 'desc',
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26, rownumbers: true,
          selectRowButtonOnly: true
      });


      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [
                { display: "报警类型", name: "报警类型", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
                    options: {
                        url: '../handler/select.ashx?view=v_Police_AlertInfo&idfield=AlertType&textfield=AlertType&distinct=true&needAll=1',
                        initValue: '全部', valueFieldID: 'AlertType'
                    }
                },
                { display: "报警时间", name: "AlertTime", newline: false, labelWidth: 100, width: 120, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "greaterorequal"
                    }
                },
                {
                    display: "报警时间", name: "AlertTime1", newline: false, labelWidth: 100, width: 120, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "lessorequal"
                    }
                }
            ],
          toJSON: JSON2.stringify
      });

      //增加搜索按钮,并创建事件
      LG.appendSearchButtons("#formsearch", grid);


      function f_reload() {
          grid.loadData();
      }

  </script> 
</body>
</html>

