<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_UserCommunityRefManage, App_Web_0r5pok1k" %>
=======
<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_UserCommunityRefManage, App_Web_5ncvhhwe" %>
=======
﻿<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_UserCommunityRefManage, App_Web_bslrsuh2" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户区域管理</title>
        <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script> 
        <script language="javascript" type="text/javascript">
            function wopen(pageURL, title, w, h) {
                var left = (screen.width / 2) - (w / 2);
                var top = (screen.height / 2) - (h / 2);
                var targetWin = window.open(pageURL, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
            }

            function CloseWindow() {
                alert('保存信息成功！权限区域改动需重新启动系统后生效！');
                window.opener.f_reload();
                window.close();
            }
</script>
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <input type="hidden" id="MenuNo" value="UserCommunityManage" />
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
  <script  type="text/javascript">

      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "登录ID", name: "UserID", width: 100, type: "text", align: "left" },
          { display: "真实姓名", name: "RealName", width: 150, type: "text", align: "left" },
          { display: "社区编号", name: "LSID", width: 100, type: "text", align: "left" },
          { display: "社区名称", name: "LRName", width: 350, type: "text", align: "left" },
          { display: "备注", name: "t_fun_demo", width: 100, type: "date", align: "left"}],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=v_UserCommunity_View', sortName: 'UserID',
          width: '98%', height: '100%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true, rownumbers: true
      });

      //双击事件
      LG.setGridDoubleClick(grid, 'modify');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "登录用户", name: "登录用户", newline: false, labelWidth: 100, width: 150, space: 30, type: "select", cssClass: "field",
              options: {
                  url: '../handler/select.ashx?view=CF_User&idfield=LoginName&textfield=RealName&distinct=true&needAll=1&where={"op":"and","rules":[{"op":"equal","field":"DeptID","value":"7","type":"string"}]}', initValue: '全部',
                  valueFieldID: 'LoginName'
              }
          }
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
                  $.ligerDialog.open({ height: 420, width: 610, url: 'UserCommunityDetail.aspx', title: '用户物业维护' });
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

          var rows = grid.getCheckedRows();
          var data = [];
          for (var i = 0, l = rows.length; i < l; i++) {
              var o = $.extend({}, rows[i]);
              data.push(o);
          }

          if (selected) {
              LG.ajax({
                  type: 'AjaxBaseManage',
                  method: 'RemoveUserCommunity',
                  loading: '正在删除中...',
                  data: { DataJSON: JSON2.stringify(data) },
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

