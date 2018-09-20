<%@ page language="C#" autoeventwireup="true" inherits="Activity_RedPackageList, App_Web_vxnmcg2w" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>房源管理</title> 
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
   <input type="hidden" id="MenuNo" value="Rent" />
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
  <div id="maingrid"></div> 
  <script type="text/javascript">
      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "红包编号", name: "RedPackageID", width: 100, type: "text", align: "left" },
                { display: "关联对象", name: "RedPackageObject", width: 200, type: "textarea", align: "left" },
                { display: "红包金额", name: "RedPackageValue", width: 50, type: "decimal", align: "left" },
                { display: "有效开始日期", name: "RedPackageStartDate", width: 150, type: "date", align: "left" },
                { display: "有效结束日期", name: "RedPackageEndDate", width: 150, type: "date", align: "left" },
                { display: "红包类型", name: "RedPackageType", width: 150, type: "text", align: "left" },
                { display: "红包状态", name: "RedPackageStatus", width: 150, type: "text", align: "left" }],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=v_RedPackage_view', sortName: 'RedPackageStartDate',
          width: '98%', height: '100%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true
      });

      //双击事件
      LG.setGridDoubleClick(grid, 'modify');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [
                { display: "关联对象", name: "RedPackageObject", newline: false, labelWidth: 100, width: 100, space: 20, type: "text", cssClass: "field" }
                
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
                  //top.f_addTab(null, '增加客户信息', 'CustomerManage/CustomersDetail.aspx');
                  wopen('RentDetail.aspx?RentNo=&type=E', '新增房源', '700', '570');
                  break;
              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  LG.ajax({
                      type: 'AjaxPage',
                      method: 'GetEncryptString',
                      loading: '正在获取中...',
                      data: { sourceStr: selected.RentNO },
                      success: function (data) {
                          wopen('RentDetail.aspx?RentNo=' + data, '查看房源信息', '700', '570');
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
                      data: { sourceStr: selected.RentNO },
                      success: function (data) {
                          wopen('RentDetail.aspx?RentNo=' + data + '&type=E', '修改房源信息', '700', '570');
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
              //case "viewRentPerson": 
              //    var selected = grid.getSelected(); 
              //    if (!selected) { LG.tip('请选择行!'); return } 
              //    $.ligerDialog.open({ height: 450, width: 750, url: 'RentAttribute.aspx?RID=' + selected.RentNO, title: '承租人信息' }); 
              //    break; 
              case "viewHistory":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  $.ligerDialog.open({ height: 450, width: 850, url: 'RentInfoHistory.aspx?RentNo=' + selected.RentNO + '&type=V', title: '租赁历史信息' });
                  break;
              case "export":
                  $.ligerDialog.open({ url: "../print.aspx?exporttype=xls" }); return;
                  break;
              case "image":
                  var rows = grid.getCheckedRows();
                  var signetIds = '';
                  for (var i = 0, l = rows.length; i < l; i++) {
                      signetIds += ",'" + rows[i].se_signet_id + "'";

                  }
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return; }

                  top.f_addTab(null, selected.RentNO + '-房源照片', '../RentHouse/RentImageList.aspx?RentNO=' + selected.RentNO);
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
          var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left + ',scrollbars=yes');
      }
      function f_delete() {
          var selected = grid.getSelected();
          if (selected) {
              LG.ajax({
                  type: 'AjaxBaseManage',
                  method: 'RemoveRent',
                  loading: '正在删除中...',
                  data: { ID: selected.RentNO },
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
