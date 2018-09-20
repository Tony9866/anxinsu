<%@ page language="C#" autoeventwireup="true" inherits="MotorManage_PersonList, App_Web_c2ddno5f" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>人员信息</title> 
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
          { display: "预警信息", name: "", newline: false, labelWidth: 100, width: 60, space: 20, type: "text", cssClass: "field",
              render: function (item) {
                  if (item.strStatus == '1') {
                    if (item.strType.substring(1,1)=='1')
                        return "<div style='width:100%;height:100%;text-align:center;'><img src='../images/red.png' title='管控' /></div>";
                    else
                        return "<div style='width:100%;height:100%;text-align:center;'><img src='../images/yellow.png' title='关注' /></div>";
                  }
                  else
                      return "<div style='width:100%;height:100%;text-align:center;'><img src='../images/green.png' title='正常' /></div>";
              }
          },
          { display: "人员姓名", name: "RRAContactName", width: 80, type: "text", align: "left" },
                { display: "身份证号", name: "RRAIDCard", width: 150, type: "textarea", align: "left" },
                { display: "租住房屋", name: "RAddress", width: 300, type: "text", align: "left" },
                { display: "入住时间", name: "RRAStartDate", width: 150, type: "date", align: "left", format: "yyyy-MM-dd hh:mm:ss" },
                { display: "入住时间", name: "RRAEndDate", width: 150, type: "date", align: "left", format: "yyyy-MM-dd hh:mm:ss"}],
          dataAction: 'server', pageSize: 20, toolbar: null,
          url: rootPath + 'handler/grid.ashx?view=v_RentHistory_AlertView', sortName: 'RRACreatedDate', sortOrder: 'desc',
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26, rownumbers: true,
          selectRowButtonOnly: true
      });


      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [
                { display: "人员姓名", name: "RRAContactName", newline: false, labelWidth: 100, width: 100, space: 20, type: "text", cssClass: "field" },
                { display: "身份证号", name: "RRAIDCard", newline: false, labelWidth: 100, width: 160, space: 20, type: "text", cssClass: "field"   }
            ],
          toJSON: JSON2.stringify
      });

      //增加搜索按钮,并创建事件
      LG.appendSearchButtons("#formsearch", grid);


      function f_reload() {
          grid.loadData();
      }
      var t2 = window.setInterval(f_reload, 10000); 

  </script> 
</body>
</html>
