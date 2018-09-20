<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_RentHousePersonalHistory, App_Web_bslrsuh2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>房源查询</title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script>
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <input type="hidden" id="MenuNo" value="RentPersonalQuery" />
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
      var useridcard = '<%=UserIDCard %>';
      //{ Submitted=0,NeedPay=1,Complete=2,Rejected=9,Cancelled=8,Expired=7,NeedConfirmCheckOut=6,CheckedOut=5,Evaluated=11}
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "房源编号", name: "RentNO", width: 150, type: "text", align: "left" },
                { display: "租赁开始日期", name: "RRAStartDate", width: 120, type: "date", align: "left" },
                { display: "租赁结束日期", name: "RRAEndDate", width: 120, type: "date", align: "left" },
                { display: "承租人", name: "RRAContactName", width: 100, type: "text", align: "left" },
                { display: "承租人身份证号码", name: "RRAIDCard", width: 200, type: "text", align: "left"},
                { display: "房源地址", name: "RAddress", width: 300, type: "text", align: "left" },
                { display: "订单状态", name: "RRAStatus", width: 50, type: "text", align: "left",
                render: function (item) {
                if (item.RRAStatus == "5")
                    return "<span style='color:red;'>已退房</span>";
                if (item.RRAStatus == "0")
                    return "<span '>已提交</span>";
                if (item.RRAStatus == "1")
                    return "<span style='color:red;'>待付费</span>";
                if (item.RRAStatus == "2")
                    return "<span style=''>已完成</span>";
                if (item.RRAStatus == "9")
                    return "<span style='color:red;'>已拒绝</span>";
                if (item.RRAStatus == "8")
                    return "<span style='color:red;'>已取消</span>";
                if (item.RRAStatus == "7")
                    return "<span style='color:red;'>已过期</span>";
                if (item.RRAStatus == "6")
                    return "<span style=''>退房确认</span>";
                if (item.RRAStatus == "11")
                    return "<span style=''>已评价</span>";
            } }],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=v_RentHistoryInternet_view', sortName: 'RRAStartdate', rownumbers: true,
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true,sortOrder: 'desc',
           parms: {
        where: JSON2.stringify({
            op: 'or',
            rules: [{ field: 'RIDCard', value: useridcard, op: 'equal' }]
        })
    }
      });

      //双击事件
      LG.setGridDoubleClick(grid, 'view');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [
                { display: "租赁开始日期", name: "RRAStartdate", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "greaterorequal"
                    }
                },
                {
                    display: "租赁结束日期", name: "RRAEndDate", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
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

      $("#RIDCard").val(useridcard);

      //增加搜索按钮,并创建事件
      LG.appendSearchButtons("#formsearch", grid);

      //加载toolbar
      LG.loadToolbar(grid, toolbarBtnItemClick);

      //工具条事件
      function toolbarBtnItemClick(item) {
          switch (item.id) {
              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  LG.ajax({
                      type: 'AjaxPage',
                      method: 'GetEncryptString',
                      loading: '正在获取中...',
                      data: { sourceStr: selected.RRAID },
                      success: function (data) {
                          $.ligerDialog.open({ height: 480, width: 800, url: '../RentHouse/RentInfoAdd.aspx?RentNo=' + data + '&type=D', title: '查看租赁信息' });
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
                      data: { sourceStr: selected.RRAID },
                      success: function (data) {
                          $.ligerDialog.open({ height: 480, width: 800, url: '../RentHouse/RentInfoAdd.aspx?RentNo=' + data + '&type=E', title: '修改租赁信息' });
                      },
                      error: function (message) {
                      }
                  });
                  break;
              case "cancel":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }

                  jQuery.ligerDialog.confirm('您确定要退房吗?', function (confirm) {
                        if (confirm)
                        {
                              LG.ajax({
                                  type: 'AjaxBaseManage',
                                  method: 'CancelOrder',
                                  loading: '正在取消中...',
                                  data: { rraId: selected.RRAID },
                                  success: function (data) {
                                      LG.showSuccess('取消订单成功！');
                                      f_reload();
                                  },
                                  error: function (message) {
                                  }
                              });
                        }
                  });

                  break;
              case "export":
                  $.ligerDialog.open({ url: "../print.aspx?exporttype=xls" }); return;
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

  </script> 
</body>
</html>
