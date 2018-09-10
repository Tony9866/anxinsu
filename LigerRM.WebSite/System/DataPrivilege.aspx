<%@ Page Language="C#" Inherits="LigerRM.Common.ViewPageBase" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>数据权限</title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script>
    <script src="DataPrivilageSysParm.js" type="text/javascript"></script> 
    <style type="text/css">
    .filterpanle{ margin:10px;}
    .l-panel td.l-filter-column,.l-panel td.l-filter-value,.l-panel td.l-filter-op{ padding:2px;}
    
    .l-selected .l-grid-row-cell, .l-selected {background: #F5F5F5;}
    .l-panel td .l-filter-rowlast{ padding-top:1px;}
    
    .l-panel td .l-filter-rowlast {padding:3px;}
        .l-panel td .groupopsel{ margin:1px;}
        .l-panel td .l-filter-cellgroup{ padding:2px;}  
         .l-panel td .l-filter-rowlastcell{ padding:2px;}
    </style>
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <ipnut type="hidden" id="MenuNo" value="sysDataPrivilege" />
  <div id="mainsearch" style=" width:98%"> 
  <div id="maingrid"></div> 
  <script type="text/javascript">
      var DbViews = <%=LigerRM.Service.Setting.DbSettingHelper.GetSettingsJSON() %>;  


      //相对路径
      var rootPath = "../";
      //列表结构
      var toolbarOptions = {
          items: [
            { text: '增加', id: 'add', click: toolbarBtnItemClick, img: "../lib/icons/silkicons/add.png" },
            { line: true },
            { text: '修改', id: 'modify', click: toolbarBtnItemClick, img: "../lib/icons/miniicons/page_edit.gif" },
            { line: true },
            { text: '删除', id: 'delete', click: toolbarBtnItemClick, img: "../lib/icons/miniicons/page_delete.gif" }
        ]
      };
      var grid = $("#maingrid").ligerGrid({
          columns: [
          { display: "资源", name: "DataPrivilegeView", width: 120, type: "text", align: "left" },
          { display: "条件规则", name: "DataPrivilegeRule", width: 680, type: "textarea", align: "left", render: ruleRender }
          ], dataAction: 'server', pageSize: 20, toolbar: toolbarOptions,
          url: rootPath + 'handler/grid.ashx?view=CF_DataPrivilege', sortName: 'DataPrivilegeID', 
          width: '98%', height: '100%',heightDiff:-10, checkbox: false,usePager:false
          ,mouseoverRowCssClass : null,alternatingRow :false
      }); 

      var filterCounter = 0;
      var AllfilterData = {};
      function ruleRender(rowdata)
      {
          var rule = rowdata.DataPrivilegeRule;
          var master = rowdata.DataPrivilegeView;
          if (!rule || rule == "{}") return "";
          var ruleData = JSON2.parse(rule);
          AllfilterData['filter' + ++filterCounter] = ruleData;
          return "<div id='filter" + filterCounter + "' master='"+master+"' class='filterpanle'></div>";
      }
      grid.bind('afterShowData', function ()
      {
          $("div.filterpanle", maingrid).each(function ()
          {
              var ruleData = AllfilterData[this.id];
              var master=  $(this).attr("master");
              var filter =  $(this).ligerFilter({fields:getFields(master)});  
              filter.setData(ruleData);
          });
          $(":button,.deleterole",maingrid).remove();
          $("select,input",maingrid).attr("disabled","disabled");
      });


      //工具条事件
      function toolbarBtnItemClick(item) {
          switch (item.id) {
              case "add":
                  top.f_addTab(null, '增加数据权限信息', 'System/DataPrivilegeDetail.aspx');
                  break;
              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  top.f_addTab(null, '查看数据权限信息', 'System/DataPrivilegeDetail.aspx?IsView=1&ID=' + selected.DataPrivilegeID);
                  break;
              case "modify":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  top.f_addTab(null, '修改数据权限信息', 'System/DataPrivilegeDetail.aspx?ID=' + selected.DataPrivilegeID);
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
      function f_delete() {
          var selected = grid.getSelected();
          if (selected) {
              LG.ajax({
                  type: 'AjaxSystem',
                  method: 'RemoveDataPrivilege',
                  loading: '正在删除中...',
                  data: { ID: selected.DataPrivilegeID },
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
