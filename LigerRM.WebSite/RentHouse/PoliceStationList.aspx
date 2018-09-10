<%@ Page Language="C#" Inherits="LigerRM.Common.ViewPageBase" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>警局管理</title> 
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
   <ipnut type="hidden" id="MenuNo" value="PoliceStationManagement" /> 

      <form id="mainform">
    <div id="maingrid"  style="margin:2px;"></div> 
    </form> 

      <script type="text/javascript">
          //相对路径
          var rootPath = "../";
          //列表结构
          var grid = $("#maingrid").ligerGrid({
              columns: [
              {
                  display: "区域编号", name: "PSID", width: "10%", type: "text", align: "left", editor: { type: 'text' }
              },
              { display: "警局名称", name: "PSName", width: "20%", type: "text", align: "left"
                    , validate: { required: true }
                    , editor: { type: 'linkbtn' }
              },
               {
                   display: "上级单位", name: "ParentName", width: "10%", type: "text", align: "left", editor: { type: 'text' }
               },
              {
                  display: "描述", name: "PSDescription", width: "15%", type: "text", align: "left", editor: { type: 'text' }
              },
               {
                   display: "联系人", name: "PSContactPerson", width: "8%", type: "text", align: "left", editor: { type: 'text' }
               },
                {
                    display: "联系电话", name: "PSContactTel", width: "8%", type: "text", align: "left", editor: { type: 'text' }
                },
                 {
                     display: "具体地址", name: "PSAddress", width: "10%", type: "text", align: "left", editor: { type: 'text' }
                 },
                 
                  {
                      display: "创建时间", name: "PSCreatedDate", width: "8%", type: "date", align: "left", editor: { type: 'checkbox' }
                  },
                  {
                      display: "修改时间", name: "PSModifiedDate", width: "8%", type: "date", align: "left", editor: { type: 'checkbox' }
                  }
               //   ,
               //   {
               //       display: "是否重点警局", name: "PSIsImport", width: "8%", type: "checkbox", align: "left", editor: { type: 'text' }
               //   },
               //{
               //    display: "简写", name: "PSShortName", width: "5%", type: "text", align: "left", editor: { type: 'text' }
               //},
               // {
               //     display: "警局状态", name: "PSStatus", width: "5%", type: "checkbox", align: "left", editor: { type: 'text' }
               // },
               //  {
               //      display: "地图信息", name: "PSMapID", width: "5%", type: "text", align: "left", editor: { type: 'checkbox' }
               //  }
              ], dataAction: 'server', pageSize: 20, toolbar: {},
              url: rootPath + 'handler/grid.ashx?procedure=up_Rent_PoliceStationSelectAll', sortName: 'PSID',
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
                  top.f_addTab(null, '增加区域信息', 'RentHouse/PoliceStationDetail.aspx');
                  break;
              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  top.f_addTab(null, '查看区域信息', 'RentHouse/PoliceStationDetail.aspx?IsView=1&ID=' + selected.PSID);
                  break;
              case "modify":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  top.f_addTab(null, '修改区域信息', 'RentHouse/PoliceStationDetail.aspx?ID=' + selected.PSID);
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
                  method: 'RemovePoliceStation',
                  loading: '正在删除中...',
                  data: { ID: selected.PSID },
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
              data.PSID = e.record.PSID;
          LG.ajax({
              loading: '正在保存数据中...',
              type: 'AjaxBaseManage',
              method: isAddNew ? "AddPoliceStation" : "UpdatePoliceStation",
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
