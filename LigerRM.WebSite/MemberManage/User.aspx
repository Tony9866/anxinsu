<%@ Page Language="C#" Inherits="LigerRM.Common.ViewPageBase" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户</title> 
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
   <ipnut type="hidden" id="MenuNo" value="MemberManageUser" />
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
       var config = <%= SystemService.GetListPageConfig("CF_User") %>;
       //禁止的字段
       var forbidFields = <%= SystemService.GetForbidFields("CF_User") %>;
       //根据字段权限 调整
       LG.adujestConfig(config,forbidFields);

      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: config.Grid.columns, dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=CF_User', sortName: 'UserID', 
          width: '98%', height: '100%',heightDiff:-10, checkbox: false
      });

        //双击事件
      LG.setGridDoubleClick(grid, 'modify');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "登录ID", name: "LoginName", newline: false, labelWidth: 80, width: 100, space: 10, type: "text", cssClass: "field"
          },{ display: "用户姓名", name: "RealName", newline: false, labelWidth: 80, width: 100, space: 10, type: "text", cssClass: "field"
          },{ display: "用户级别", name: "用户级别", newline: false, labelWidth: 80, width: 100, space: 10, type: "select", cssClass: "field",
              options: {
                  url: '../handler/select.ashx?view=CF_Department&idfield=DeptID&textfield=DeptName&distinct=true&needAll=0',
                  initValue: '全部', valueFieldID: 'DeptID'
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
          switch (item.id) {
              case "add":
                  top.f_addTab(null, '增加用户信息', 'MemberManage/UserDetail.aspx');
                  break;
              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  top.f_addTab(null, '查看用户信息', 'MemberManage/UserDetail.aspx?IsView=1&ID=' + selected.UserID);
                  break;
              case "modify":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  if (selected.UserID==1)
                  {
                    LG.tip('不能修改系统管理员账号！');
                    return;
                  }
                  top.f_addTab(null, '修改用户信息', 'MemberManage/UserDetail.aspx?ID=' + selected.UserID);
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
          if (selected.UserID==1)
          {
            LG.tip('不能删除系统管理员账号！');
            return;
          }
         
              LG.ajax({
                  type: 'AjaxMemberManage',
                  method: 'RemoveUser',
                  loading: '正在删除中...',
                  data: { ID: selected.UserID },
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
