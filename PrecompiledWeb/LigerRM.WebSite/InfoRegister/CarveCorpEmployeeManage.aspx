<%@ page language="C#" autoeventwireup="true" inherits="InfoRegister_CarveCorpEmployeeManage, App_Web_0tvrujba" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>从业人员信息</title> 
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
   <input type="hidden" id="MenuNo" value="CarveCorpEmployeeManage" />
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
  <div id="maingrid"></div> 
  <script type="text/javascript">
      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "从业人员编号", name: "ce_empl_id", width: 150, type: "text", align: "left" },
          { display: "姓名", name: "ce_name", width: 150, type: "text", align: "left" },
          { display: "性别", name: "Gender", width: 100, type: "text", align: "left" },
          { display: "身份证号", name: "ce_IDCard", width: 150, type: "text", align: "left" },
          { display: "岗位", name: "Position", width: 100, type: "date", align: "left" },
          { display: "联系电话", name: "ce_phone", width: 150, type: "text", align: "left"}],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=t_CarveCorpEmployee_View', sortName: 'ce_empl_id',
          width: '98%', height: '100%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true//,
//          parms: {
//              where: JSON2.stringify({
//                  op: 'and',
//                  rules: [{ field: 'cas_corp_id', value: '1', op: 'isnull' }
//                  ]
//              })
//          }
      });

      //双击事件
      LG.setGridDoubleClick(grid, 'modify');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "从业人员编号", name: "ce_empl_id", newline: false, labelWidth: 100, width: 100, space: 20, type: "text", cssClass: "field" },
          { display: "制章单位名称", name: "cac_corp_name", newline: false, labelWidth: 100, width: 120, space: 30, type: "text", cssClass: "field" }
          ],
          toJSON: JSON2.stringify
      });

      //增加搜索按钮,并创建事件
      LG.appendSearchButtons("#formsearch", grid);

      //加载toolbar
      LG.loadToolbar(grid, toolbarBtnItemClick);

      //工具条事件
      function toolbarBtnItemClick(item) {
          switch (item.id) {
              case "add":
                  wopen('CarveEmployeeDetail.aspx?CorpId=&type=E', '从业人员详细信息', '590', '420');
                  break;
              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  LG.ajax({
                      type: 'AjaxPage',
                      method: 'GetEncryptString',
                      loading: '正在获取中...',
                      data: { sourceStr: selected.ce_empl_id },
                      success: function (data) {
                          wopen('../inforegister/CarveEmployeeDetail.aspx?EmpId=' + data + '&type=V', '从业人员详细信息', '590', '420');
                      },
                      error: function (message) {
                      }
                  });
                  break;
              case "modify":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  LG.ajax({
                      type: 'AjaxPage',
                      method: 'GetEncryptString',
                      loading: '正在获取中...',
                      data: { sourceStr: selected.ce_empl_id },
                      success: function (data) {
                          wopen('../inforegister/CarveEmployeeDetail.aspx?EmpId=' + data + '&type=E', '从业人员详细信息', '590', '420');
                      },
                      error: function (message) {
                      }
                  });
                  break;
              case "delete":
                  jQuery.ligerDialog.confirm('确定删除吗?', function (confirm) {
                      if (confirm)
                          f_delete();
                  });
                  break;
          }
      }
      function f_reload() {
          grid.loadData();
      }

      function wopen(pageURL, title, w, h) {
          var left = (screen.width / 2) - (w / 2);
          var top = (screen.height / 2) - (h / 2) - 20;
          var random = Math.floor(Math.random() * (1000 + 1));
          var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
      }

      function f_delete() {
          var selected = grid.getSelected();
          if (selected) {
              LG.ajax({
                  type: 'AjaxCarveCorpManage',
                  method: 'RemoveEmployee',
                  loading: '正在删除中...',
                  data: { ID: selected.ce_empl_id },
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

  </script> 
</body>
</html>

