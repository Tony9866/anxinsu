<%@ page language="C#" autoeventwireup="true" inherits="BaseManage_ICCardManagement, App_Web_g12zdq4s" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/js/LG.js" type="text/javascript"></script> 
    <script src="../lib/ligerUI/js/ligerui.all.js" type="text/javascript"></script>   
    <script src="../lib/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>  
    
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
<body style="padding:2px;height:100%; text-align:center;">
  <form id="mainform">
    <div id="maingrid"  style="margin:2px;"></div> 
    </form> 
    <script>
        var lockID = '<%= System.Web.HttpContext.Current.Request["DeviceID"] %>';
        //          锁类型  传过来的
        var lockType = '<%= System.Web.HttpContext.Current.Request["DeviceType"] %>';
        
    </script>
  <script type="text/javascript">
      function wopen(pageURL, title, w, h) {
          var left = (screen.width / 2) - (w / 2);
          var top = (screen.height / 2) - (h / 2) - 20;
          var random = Math.floor(Math.random() * (1000 + 1));
          var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
      }

      //验证
      var maingform = $("#mainform");
      $.metadata.setType("attr", "validate");
      LG.validate(maingform, { debig: true });
      //这里覆盖了本页面grid的loading效果
      $.extend($.ligerDefaults.Grid, {
          onloading: function () {
              LG.showLoading('正在加载表格数据中...');
          },
          onloaded: function () {
              LG.hideLoading();
          }
      });

      function itemclick(item) {
          var editingrow = grid.getEditingRow();
          var id = item.id || item.text;
          switch (id) {
              case "add":
                  addNewRow();
                  break;
              case "modify":
                  modifyRow();
                  break;
              case "cancel":
                  cancelEdit();
                  break;
              case "save":
                  saveRow();
                  break;
              case "delete":
                  jQuery.ligerDialog.confirm('您确定要删除此记录吗?', function (confirm) {
                      if (confirm)
                          f_delete();
                  });
                  break;
              case "freeze":
                  f_freeze();
                  break;
              case "unfreeze":
                  f_unfreeze();
                  break;
          }
      }

      function f_freeze() {
          var selected = grid.getSelected();
          if (selected) {
              LG.ajax({
                  type: 'AjaxBaseManage',
                  method: 'FreezeICCard',
                  loading: '正在禁用中...',
                  data: { id: selected.ID, locktype: lockType },
                  success: function () {
                      LG.showSuccess('禁用成功');
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

      function f_unfreeze() {
          var selected = grid.getSelected();
          if (selected) {
              LG.ajax({
                  type: 'AjaxBaseManage',
                  method: 'UnFreezeICCard',
                  loading: '正在禁用中...',
                  data: { id: selected.ID, locktype: lockType },
                  success: function () {
                      LG.showSuccess('激活成功');
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

      function f_reload() {
          grid.loadData();
      }

      function f_delete() {
          var selected = grid.getSelected();
          if (selected) {
              if (!selected.ID) {
                  grid.deleteRow(selected);
                  return;
              }
              LG.ajax({
                  type: 'AjaxBaseManage',
                  method: 'DeleteICCard',
                  loading: '正在删除中...',
                  data: { id: selected.ID, locktype: lockType },
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
      var toolbarOptions = {
          items: [
            { id: 'add', text: '添加', click: itemclick, img: "../lib/icons/silkicons/add.png" },
            { id: 'modify', text: '修改', click: itemclick, img: "../lib/icons/silkicons/application_edit.png" },
            { id: 'cancel', text: '取消', click: itemclick, img: "../lib/icons/silkicons/cancel.png" },
            { id: 'save', text: '保存', click: itemclick, img: "../lib/icons/silkicons/disk.png" },
            { id: 'freeze', text: '禁用', click: itemclick, img: "../lib/icons/silkicons/book_delete.png" },
            { id: 'unfreeze', text: '启用', click: itemclick, img: "../lib/icons/silkicons/book_go.png" },
            { line: true },
            { id: 'delete', text: '删除', click: itemclick, img: "../lib/icons/miniicons/page_delete.gif" }
            
        ]
      };

      var grid = $("#maingrid").ligerGrid({
          columns: [
          { display: 'ID', name: 'ID', align: 'left', width: 50, minWidth: 60,
               type:'hidden' },
                { display: '智能锁编号', name: 'LockID', align: 'left', width: 120, minWidth: 60
                },
                { display: 'IC卡编号', name: 'ICCard', align: 'left', width: 120, minWidth: 60,
                    editor: { type: "text" }, validate: { required: true }
                },
               { display: '开始日期', name: 'StartDate', align: 'left', width: 120, minWidth: 60,type:'date', format: 'yyyy-MM-dd',
                   editor: { type: 'date' }, validate: { required: true }
               },
                { display: '结束日期', name: 'EndDate', align: 'left', width: 120, minWidth: 60, type: 'date', format: 'yyyy-MM-dd',
                    editor: { type: 'date' }, validate: { required: true }
                },
               { display: '状态', name: 'statusdesc', align: 'left', width: 120, minWidth: 60, type: 'text'
               },
               { display: "ICCard类型", name: "", width: 100, type: "text", align: "left",
                   render: function (rowData) {
                       if (rowData.StartDate == rowData.EndDate) {
                           return "永久卡片";
                       } else {
                           return "临时卡片";
                       }
                   }
               }
                ], toolbar: toolbarOptions, sortName: 'ID',
          width: '98%', height: '100%', heightDiff: -5, checkbox: false,
          usePager: false, clickToEdit: false, rownumbers: true, enabledEdit: true,
          fixedCellHeight: true, rowHeight: 25,
          url: '../handler/grid.ashx?view=Rent_Locks_ICCards_view',
          parms: { where: JSON2.stringify({
              op: 'and',
              rules: [{ field: 'IsValid', value: '1', op: 'equal' },
              { field: 'LockID', value: lockID, op: 'equal'}]
          })
          }
      });
  function addNewRow() {
      grid.addEditRow();
  }

  function modifyRow() {
      var row = grid.getSelectedRow();
      if (!row) { alert('请选择行'); return; }
      grid.beginEdit(row);
  }

  function saveRow() {
      var editingrow = grid.getEditingRow();
      if (editingrow != null) {
          grid.endEdit(editingrow);
      } else {
          LG.tip('现在不在编辑状态!');
      }
  }

  function cancelEdit() {
      grid.cancelEdit();
  }

  grid.bind('beforeSubmitEdit', function (e) {
      if (!LG.validator.form()) {
          LG.showInvalid();
          return false;
      }
      return true;
  });
  grid.bind('afterSubmitEdit', function (e) {
      var isAddNew = e.record['__status'] == "add";
      var data = e.newdata;
      if (!isAddNew)
          data.ID = e.record.ID;
      LG.ajax({
          loading: '正在保存数据中...',
          type: 'AjaxBaseManage',
          method: isAddNew ? "AddICCard" : "UpdateICCard",
          data: { ID: data.ID, deviceId: lockID, icCard: data.ICCard, startdate: data.StartDate, enddate: data.EndDate, locktype: lockType },
          success: function () {
              grid.loadData();
              LG.tip('保存成功!');
          },
          error: function (message) {
              LG.tip(message);
          }
      });
  }); 

  </script> 
</body>
</html> 
