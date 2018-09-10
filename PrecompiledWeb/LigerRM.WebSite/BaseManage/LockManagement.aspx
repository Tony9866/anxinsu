<%@ page language="C#" autoeventwireup="true" inherits="BaseManage_LockManagement, App_Web_cxwaqcgw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登记点管理</title>
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

</head>
<body style="padding:10px;height:100%; text-align:center;">
   <ipnut type="hidden" id="MenuNo" value="Lock" />
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
  <div id="maingrid"></div> 
  </form>
  <script  type="text/javascript">

      var maingform = $("#mainform");
      $.metadata.setType("attr", "validate");
      LG.validate(maingform, { debug: false });
      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "智能锁编号", name: "DeviceID", width: 150, type: "text", align: "left",
              editor: { type: "text" }, validate: { required: true }
          },
          { display: "所属房屋", name: "RAddress", width: 300, type: "text", align: "left",
              editor: { type: "text" }, validate: { required: true }
          },
          { display: "生产日期", name: "ProductDate", width: 150, type: "date", align: "left",
              editor: { type: "text" }
          },
          { display: "智能锁状态", name: "StatusDesc", width: 100, type: "text", align: "left",
              editor: { type: "text" }
          },
          { display: "电池状态", name: "BatteryDesc", width: 100, type: "text", align: "left",
              editor: { type: "text" }
          },
          { display: "锁的类型", name: "DeviceType", width: 100, type: "text", align: "left",
              editor: { type: "text" },
              render: function (rowData) {
                  if (rowData.DeviceType == "1") {
                      return "新锁";
                  } else {
                      return "旧锁";
                  }
              }
          }],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=v_Rent_Locks_view', sortName: 'DeviceID',
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true, enabledEdit: true, clickToEdit: false, rownumbers: true
      });

      //双击事件
      //LG.setGridDoubleClick(grid, 'modify');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "智能锁编号", name: "DeviceID", newline: false, labelWidth: 100, width: 150, space: 30, type: "text", cssClass: "field"
          }, { display: "房屋地址", name: "Raddress", newline: false, labelWidth: 100, width: 250, space: 30, type: "text", cssClass: "field"
          }, { display: "生产日期", name: "ProductDate", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
              attr: {
                  op: "greaterorequal"
              }
          }],
          toJSON: JSON2.stringify
      });

      //增加搜索按钮,并创建事件
      LG.appendSearchButtons("#formsearch", grid);

      //加载toolbar
      LG.loadToolbar(grid, toolbarBtnItemClick);


      //工具条事件
      function toolbarBtnItemClick(item) {
          var selected = grid.getSelected();
          switch (item.id) {
              case "add":
                  $.ligerDialog.open({ height: 430, width: 650, url: 'LockDetail.aspx?deviceID=', title: '添加智能锁信息' });
                  break;
              case "modify":
                  f_modify();
                  break;
              case "delete":
                  f_delete();
                  break;
              case "unlock":
                  f_unlock();
                  break;
              case "freeze":
                  f_freeze();
                  break;
              case "unfreeze":
                  f_unfreeze();
                  break;
              case "password":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return; }
                  top.f_addTab(null, selected.DeviceID + '-密码管理', '../BaseManage/PasswordManagement.aspx?DeviceID=' + selected.DeviceID + '&DeviceType=' + selected.DeviceType);
                  break;
              case "delete":
                  jQuery.ligerDialog.confirm('确定删除吗?', function (confirm) {
                      if (confirm)
                          f_delete();
                  });
                  break;
              case "IC":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return; }
                  top.f_addTab(null, selected.DeviceID + '-IC卡管理', '../BaseManage/ICCardManagement.aspx?DeviceID=' + selected.DeviceID + '&DeviceType=' + selected.DeviceType);
                  break;
              case "idcard":
                  f_idcard();
                  break;
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
                  method: 'DeleteDevice',
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

      function f_modify() {
          var selected = grid.getSelected();
          if (selected) {
              $.ligerDialog.open({ height: 430, width: 650, url: 'LockDetail.aspx?deviceID='+selected.ID, title: '修改智能锁信息' });
          }
          else {
              LG.tip('请选择行!');
          }
      }
//      开锁
      function f_unlock() {
          var selected = grid.getSelected();
          if (selected) {

              LG.ajax({
                  type: 'AjaxBaseManage',
                  method: 'UnLockDevice',
                  loading: '正在开锁中...',
                  data: { ID: selected.DeviceID, LockType: selected.DeviceType },
                  success: function () {
                      LG.showSuccess('开锁成功');
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

      function f_idcard() {
          var selected = grid.getSelected();
          if (selected) {

              LG.ajax({
                  type: 'AjaxBaseManage',
                  method: 'AddIDCard',
                  loading: '正在开锁中...',
                  data: { ID: selected.DeviceID, LockType: selected.DeviceType },
                  success: function () {
                      LG.showSuccess('请贴近身份证进行操作！');
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

      function f_freeze() {
          var selected = grid.getSelected();
          if (selected) {
              jQuery.ligerDialog.confirm('确定要冻结此智能锁吗？一旦锁定所有的电子开锁方式都将失效，是否继续？', function (confirm) {
                  if (confirm) {
                      LG.ajax({
                          type: 'AjaxBaseManage',
                          method: 'FreezeLock',
                          loading: '正在冻结中...',
                          data: { ID: selected.DeviceID, LockType: selected.DeviceType },
                          success: function () {
                              LG.showSuccess('冻结成功');
                              f_reload();
                          },
                          error: function (message) {
                              LG.showError(message);
                          }
                      });
                  }
              });
              
          }
          else {
              LG.tip('请选择行!');
          }
      }

      function f_unfreeze() {
          var selected = grid.getSelected();
          if (selected) {
              jQuery.ligerDialog.confirm('确定要解冻此智能锁吗？一旦锁定所有的电子开锁方式都将有效，是否继续？', function (confirm) {
                  if (confirm) {
                      LG.ajax({
                          type: 'AjaxBaseManage',
                          method: 'UnFreezeLock',
                          loading: '正在冻结中...',
                          data: { ID: selected.DeviceID, LockType: selected.DeviceType },
                          success: function () {
                              LG.showSuccess('解冻成功');
                              f_reload();
                          },
                          error: function (message) {
                              LG.showError(message);
                          }
                      });
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