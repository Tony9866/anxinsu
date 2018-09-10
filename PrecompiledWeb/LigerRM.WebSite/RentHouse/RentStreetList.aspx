<%@ Page Language="C#" Inherits="LigerRM.Common.ViewPageBase" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>街道管理</title> 
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
   <ipnut type="hidden" id="MenuNo" value="StreetManagement" /> 
      <form id="mainform">
    <div id="maingrid"  style="margin:2px;"></div> 
    </form> 

      <script type="text/javascript">
 
          //相对路径
          var rootPath = "../";
          //列表结构
          var grid = $("#maingrid").ligerGrid({
              columns: [
              { display: "街道名称", name: "LSName", width: "15%", type: "text", align: "left"
                    , validate: { required: true }
                    , editor: { type: 'text' }
              },
              {
                    display: "区域名称", name: "LDName", width: "15%", type: "text", align: "left"
                    , validate: { required: true }
                    , editor: { type: 'text' }
              },
              {
                  display: "描述", name: "LDDescription", width: "15%", type: "textarea", align: "left", editor: { type: 'text' }
              },
               //{
               //    display: "地图信息", name: "LDMap", width: "15%", type: "textarea", align: "left", editor: { type: 'text' }
               //}
               //,
                //{
                //    display: "区域简写", name: "LDShortName", width: "5%", type: "textarea", align: "left", editor: { type: 'text' }
                //}
                //,
                // {
                //     display: "区域状态", name: "LDStatus", width: "5%", type: "checkbox", align: "left", editor: { type: 'checkbox' }
                // },
                //  {
                //      display: "重点区域", name: "LDIsImport", width: "5%", type: "checkbox", align: "left", editor: { type: 'checkbox' }
                //  }
              ], dataAction: 'server', pageSize: 20, toolbar: {},
              url: rootPath + 'handler/grid.ashx?procedure=up_Rent_StreetSelectAll', sortName: 'LSID',
              width: '98%', height: '100%',heightDiff:-10, checkbox: false,enabledEdit: true, clickToEdit: false
          });

           //双击事件
      LG.setGridDoubleClick(grid, 'modify');

      //验证
      var maingform = $("#mainform");
      $.metadata.setType("attr", "validate");
      LG.validate(maingform, { debug: true }); 

      //加载toolbar
      LG.loadToolbar(grid, toolbarBtnItemClick);

      //工具条事件
      function toolbarBtnItemClick(item) {
          switch (item.id) {
              case "add":
                  top.f_addTab(null, '增加街道信息', 'RentHouse/RentStreetDetail.aspx');
                  break;
                  //if (editingrow == null) {
                  //    addNewRow();
                  //} else {
                  //    LG.tip('请先提交或取消修改');
                  //}
                  //break;
              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  top.f_addTab(null, '查看区域信息', 'RentHouse/RentStreetDetail.aspx?IsView=1&ID=' + selected.LSID);
                  break;
              case "modify":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  top.f_addTab(null, '修改区域信息', 'RentHouse/RentStreetDetail.aspx?ID=' + selected.LSID);
                  break;
              case "delete":
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
                  method: 'RemoveStreet',
                  loading: '正在删除中...',
                  data: { ID: selected.LSID },
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


      grid.bind('beforeSubmitEdit', function (e)
      {
          if (!LG.validator.form())
          {
              LG.showInvalid();
              return false;
          }
          return true;
      });
      grid.bind('afterSubmitEdit', function (e)
      {
          var isAddNew = e.record['__status'] == "add";
          var data = $.extend(true, {}, e.newdata);
          if (!isAddNew)
              data.LSID = e.record.LSID;
          LG.ajax({
              loading: '正在保存数据中...',
              type: 'AjaxBaseManage',
              method: isAddNew ? "AddStreet" : "UpdateStreet",
              data: data,
              success: function ()
              { 
                  grid.loadData();
                  LG.tip('保存成功!');
              },
              error: function (message)
              {
                  LG.tip(message);
              }
          });
          return false;
      }); 

      function beginEdit()
      {
          var row = grid.getSelectedRow();
          if (!row) { LG.tip('请选择行'); return; }
          grid.beginEdit(row);
      }
      function addNewRow()
      {
          grid.addEditRow();
      } 
  </script>
</body>
</html>
