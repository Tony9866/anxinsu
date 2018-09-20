<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_MotorMonitorList, App_Web_bslrsuh2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>区域管理</title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.all.js" type="text/javascript"></script>   
    <script src="../lib/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script>  
    <script src="../lib/json2.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerTextBox.js" type="text/javascript"></script> 
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script>
    
    <script src="../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script> 
    <script src="../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script src="../lib/jquery.form.js" type="text/javascript"></script>

    <script src="../lib/js/iconselector.js" type="text/javascript"></script> 
    <style type="text/css">
    .l-panel td.l-grid-row-cell-editing { padding-bottom: 2px;padding-top: 2px;}
    </style>
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <ipnut type="hidden" id="MenuNo" value="MotorManagement" /> 

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
    <div id="maingrid"  style="margin:2px;"></div> 


      <script type="text/javascript">
          //相对路径
          var rootPath = "../";

          //验证

          //列表结构
          var grid = $("#maingrid").ligerGrid({
              columns: [
              { display: "车牌号码", name: "MotorNO", width: "100", type: "text", align: "left"
              },
              
                              {
                                  display: "布控类型", name: "gc_name", width: "15%", type: "textarea", align: "left", editor: { type: 'text' }
                              },
                {
                    display: "开始日期", name: "StartDate", width: "15%", type: "date", align: "left", editor: { type: 'text' }
                }
                ,
                {
                    display: "结束日期", name: "EndDate", width: "15%", type: "date", align: "left", editor: { type: 'text' }
                }
              ], dataAction: 'server', pageSize: 20, toolbar: {},
                url: rootPath + 'handler/grid.ashx?view=Rent_MotorMonitor_View', sortName: 'CreatedOn',
              width: '98%', height: '100%', heightDiff: -10, checkbox: false, enabledEdit: true, clickToEdit: false, rownumbers: true
          });
          //搜索表单应用ligerui样式
          $("#formsearch").ligerForm({
              fields: [
                { display: "车牌号码", name: "MotorNO", newline: false, labelWidth: 100, width: 160, space: 20, type: "text", cssClass: "field" },

                { display: "开始日期", name: "StartDate", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "greaterorequal"
                    }
                },
                {
                    display: "结束日期", name: "EndDate", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "lessorequal"
                    }
                }
            ],
              toJSON: JSON2.stringify
          });

          //增加搜索按钮,并创建事件
          LG.appendSearchButtons("#formsearch", grid);



          //双击事件
          LG.setGridDoubleClick(grid, 'modify');



          //加载toolbar
          LG.loadToolbar(grid, toolbarBtnItemClick);

          //工具条事件
          function toolbarBtnItemClick(item) {
              switch (item.id) {
                  case "add":
                      $.ligerDialog.open({ height: 400, width: 550, url: '../RentHouse/MotorMonitorDetail.aspx', title: '布控车辆信息' });
                      break;
                  case "view":
                      var selected = grid.getSelected();
                      if (!selected) { LG.tip('请选择行!'); return }
                      top.f_addTab(null, '查看区域信息', 'RentHouse/MotorMonitorDetail.aspx?IsView=1&ID=' + selected.LDID);
                      break;
                  case "modify":
                      var selected = grid.getSelected();
                      if (!selected) { LG.tip('请选择行!'); return }
                      $.ligerDialog.open({ height: 400, width: 550, url: '../RentHouse/MotorMonitorDetail.aspx?ID=' + selected.ID, title: '布控车辆信息' });
                      break;
                  case "delete":
                      var selected = grid.getSelected();
                      if (!selected) { LG.tip('请选择行!'); return }
                      jQuery.ligerDialog.confirm('确定删除吗?', function (confirm) {
                          if (confirm)
                              f_delete();
                      });
                      break
              }
          }

          function f_reload() {
              grid.loadData();
          }
          function f_delete() {
              var selected = grid.getSelected();
              if (selected) {
                  LG.ajax({
                      type: 'AjaxBaseManage',
                      method: 'RemoveMonitorMotor',
                      loading: '正在删除中...',
                      data: { ID: selected.ID },
                      success: function () {
                          LG.showSuccess('删除成功');
                          f_reload();
                      },
                      error: function (message) {
                          LG.showError(message);
                      }
                  });
              }
              else {
                  LG.tip('请选择行!');
              }
          }


          function beginEdit() {
              var row = grid.getSelectedRow();
              if (!row) { LG.tip('请选择行'); return; }
              grid.beginEdit(row);
          }
          function addNewRow() {
              grid.addEditRow();
          } 
  </script>
</body>
</html>
