<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_RentOwner, App_Web_5ncvhhwe" %>
=======
﻿<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_RentOwner, App_Web_bslrsuh2" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
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
   <input type="hidden" id="MenuNo" value="RentOwner" />
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
  <script  type="text/javascript">
      //相对路径
      var rootPath = "../";
      var idCard = "<%=m_IdCard %>";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "房源编号", name: "RentNO", width: 100, type: "text", align: "left" },
                { display: "具体地址", name: "RAddress", width: 200, type: "textarea", align: "left" },
                { display: "是否租赁", name: "IsAvailable", width: 50, type: "text", align: "left" },
                { display: "所属警局", name: "RPSParentName", width: 150, type: "text", align: "left" },
                { display: "所属派出所", name: "RPSName", width: 150, type: "text", align: "left" },
                { display: "社区名称", name: "RRName", width: 150, type: "text", align: "left" },
                { display: "出租费用", name: "RLocationDescription", width: 150, type: "text", align: "left" },
                { display: "门牌号", name: "RDoor", width: 100, type: "text", align: "left" },
                { display: "房主姓名", name: "ROwner", width: 100, type: "text", align: "left" },
                { display: "房主电话", name: "ROwnerTel", width: 80, type: "text", align: "left" },
                { display: "楼层", name: "RFloor", width: 100, type: "text", align: "left"}],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=v_RentDetailOwner_view', sortName: 'RentNO',
          width: '98%', height: '100%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true,
          parms: {
              where: JSON2.stringify({
                  op: 'and',
                  rules: [{ field: 'RIDCard', value: idCard, op: 'equal'}]
              })
          }
      });

      //双击事件
      LG.setGridDoubleClick(grid, 'modify');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [
                { display: "具体地址", name: "RAddress", newline: false, labelWidth: 100, width: 160, space: 20, type: "text", cssClass: "field" },
           
                { display: "创建开始日期", name: "RCreatedDate", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "greaterorequal"
                    }
                },
                {
                    display: "创建结束日期", name: "RCreatedDate1", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "lessorequal"
                    }
                },
                {
                    display: "", name: "RIDCard", newline: false, labelWidth: 100, width: 160, space: 20, type: "hidden", cssClass: "field"
                }
            ],
          toJSON: JSON2.stringify
      });

      //增加搜索按钮,并创建事件
      LG.appendSearchButtons("#formsearch", grid);
      $("#RIDCard").val(idCard);

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
