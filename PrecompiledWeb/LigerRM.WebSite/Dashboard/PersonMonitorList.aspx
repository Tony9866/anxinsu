<%@ page language="C#" autoeventwireup="true" inherits="Dashboard_PersonMonitorList, App_Web_2xeekwpm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>人员检测信息</title> 
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

          { display: "手机MAC", name: "m_mac", width: 110, type: "text", align: "left" },
                { display: "设备MAC", name: "ap_mac", width: 150, type: "textarea", align: "left" },
                { display: "探知时间", name: "add_time", width: 150, type: "date", align: "left", format: "yyyy-MM-dd hh:mm:ss" },
                { display: "离开时间", name: "leave_time", width: 150, type: "date", align: "left", format: "yyyy-MM-dd hh:mm:ss"},
                { display: "手机号码", name: "name", width: 150, type: "text", align: "left" },
                { display: "是否在线", name: "is_online", width: 100, type: "text", align: "left"}],
          dataAction: 'server', pageSize: 20, toolbar: null,
          url: rootPath + 'handler/grid.ashx?view=v_Personal_Monitor_view', sortName: 'add_time', sortOrder: 'desc',
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26, rownumbers: true,
          selectRowButtonOnly: true
      });


      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [
                { display: "手机MAC", name: "m_mac", newline: false, labelWidth: 100, width: 120, space: 20, type: "text", cssClass: "field" },
                { display: "设备MAC", name: "ap_mac", newline: false, labelWidth: 100, width: 120, space: 20, type: "text", cssClass: "field" },
                { display: "手机号码", name: "name", newline: false, labelWidth: 100, width: 120, space: 20, type: "text", cssClass: "field" },
                { display: "探知时间", name: "add_time", newline: true, labelWidth: 100, width: 120, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "greaterorequal"
                    }
                },
                {
                    display: "探知时间", name: "add_time1", newline: false, labelWidth: 100, width: 120, space: 20, type: "date", cssClass: "field",
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
