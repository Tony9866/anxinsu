<%@ Page Language="C#" Inherits="LigerRM.Common.ViewPageBase" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>部门</title> 
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
   <ipnut type="hidden" id="MenuNo" value="MemberManageDepartment" />
   <div id="detail" style="display:none;"><form id="mainform" method="post"></form> </div>
  <div id="maingrid"></div> 
  <script type="text/javascript">
      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({ 
          columns: [{display:"部门名称",name:"DeptName",width:280,type:"text",align:"left"},{display:"部门描述",name:"DeptDesc",width:480,type:"textarea",align:"left"}], dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/treegrid.ashx?view=CF_Department&idfield=DeptID&pidfield=DeptParentID',                  sortName: 'DeptID',
          tree: { columnName: 'DeptName' },
          width: '98%', height: '100%',heightDiff:-10, checkbox: false
      });
       

      //加载toolbar
      LG.loadToolbar(grid, toolbarBtnItemClick);

      //工具条事件
      function toolbarBtnItemClick(item) {
          switch (item.id) {
              case "add":
                  //top.f_addTab(null, '增加部门信息', 'MemberManage/DepartmentDetail.aspx');
                  var selected = grid.getSelected();
                  showDetail({
                      DeptParentName: selected ? selected.DeptName : '',
                      DeptParentID: selected ? selected.DeptID : 0
                  }, true);
                  break;
              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  top.f_addTab(null, '查看部门信息', 'MemberManage/DepartmentDetail.aspx?IsView=1&ID=' + selected.DeptID);
                  break;
              case "modify":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  var parent = grid.getParent(selected);
                  showDetail({
                      DeptParentName: parent ? parent.DeptName : '',
                      DeptParentID: selected.DeptParentID ? selected.DeptParentID : 0,
                      DeptName: selected.DeptName,
                      DeptDesc: selected.DeptDesc,
                      DeptID: selected.DeptID
                  }, false);
                  //top.f_addTab(null, '修改部门信息', 'MemberManage/DepartmentDetail.aspx?ID=' + selected.DeptID);
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
                  type: 'AjaxMemberManage',
                  method: 'RemoveDepartment',
                  loading: '正在删除中...',
                  data: { ID: selected.DeptID },
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

      var detailWin = null, curentData = null, currentIsAddNew;
      function showDetail(data, isAddNew)
      {
          curentData = data;
          currentIsAddNew = isAddNew;
          if (detailWin)
          {
              detailWin.show(); 
          }
          else
          {
              //创建表单结构
              var mainform = $("#mainform");
              mainform.ligerForm({
                  inputWidth: 280,
                  fields: [
         { name: "DeptID", type: "hidden" },
         { display: "部门名称", name: "DeptName", newline: true, labelWidth: 100, width: 220, space: 30, type: "text", validate: { required: true, maxlength: 50} },
         { display: "部门描述", name: "DeptDesc", newline: true, labelWidth: 100, width: 220, space: 30, type: "text" },
         { display: "上级部门", name: "DeptParentName", newline: true, labelWidth: 100, width: 220, space: 30, type: "text"}],
                  toJSON: JSON2.stringify
              });
              $("#DeptParentName").attr("readonly", "readonly");

              detailWin = $.ligerDialog.open({
                  target: $("#detail"),
                  width: 450, height: 150,top:90,
                  buttons: [
                  { text: '确定', onclick: function () { save(); } },
                  { text: '取消', onclick: function () { detailWin.hide(); } }
                  ]
              });
          }
          if (curentData)
          {
              $("#DeptParentName").val(curentData.DeptParentName);
              $("#DeptName").val(curentData.DeptName);
              $("#DeptDesc").val(curentData.DeptDesc);
          }

          function save()
          {
              curentData = curentData || {};
              curentData.DeptName = $("#DeptName").val();
              curentData.DeptDesc = $("#DeptDesc").val();
              LG.ajax({
                  loading: '正在保存数据中...',
                  type: 'AjaxMemberManage',
                  method: currentIsAddNew ? "AddDepartment" : "UpdateDepartment",
                  data: curentData,
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
          }
      }



  </script>
</body>
</html>
