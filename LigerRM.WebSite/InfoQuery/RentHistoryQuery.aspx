<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RentHistoryQuery.aspx.cs" Inherits="InfoQuery_RentHistoryQuery" %>

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
   <input type="hidden" id="MenuNo" value="RentHistoryQuery" />
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
          columns: [{ display: "房源编号", name: "RentNO", width: 100, type: "text", align: "left" },
                { display: "具体地址", name: "RAddress", width: 250, type: "textarea", align: "left" },
                { display: "租赁开始日期", name: "RRAStartDate", width: 120, type: "date", align: "left" },
                { display: "租赁结束日期", name: "RRAEndDate", width: 120, type: "date", align: "left" },
                { display: "承租人", name: "RRAContactName", width: 100, type: "text", align: "left" },
                { display: "承租人电话", name: "RRAContactTel", width: 120, type: "text", align: "left" },
                { display: "房主姓名", name: "ROwner", width: 100, type: "text", align: "left" },
                { display: "房主电话", name: "ROwnerTel", width: 80, type: "text", align: "left" },

                { display: "所属警局", name: "RPSParentName", width: 150, type: "text", align: "left" },
                { display: "所属派出所", name: "RPSName", width: 150, type: "text", align: "left" },
                
                { display: "社区名称", name: "RRName", width: 150, type: "text", align: "left" },
                { display: "街道名称", name: "RSName", width: 150, type: "text", align: "left" },
                { display: "区域名称", name: "RDName", width: 150, type: "text", align: "left" },
                { display: "门牌号", name: "RDoor", width: 100, type: "text", align: "left" },

                { display: "楼层", name: "RFloor", width: 100, type: "text", align: "left" },
                { display: "朝向", name: "RDirection", width: 100, type: "text", align: "left"}],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=v_RentHistory_view', sortName: 'RentNO', rownumbers: true,
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true
      });

      //双击事件
      LG.setGridDoubleClick(grid, 'view');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [
                { display: "房源编号", name: "RentNO", newline: false, labelWidth: 100, width: 100, space: 20, type: "text", cssClass: "field" },
                { display: "具体地址", name: "RAddress", newline: false, labelWidth: 100, width: 160, space: 20, type: "text", cssClass: "field" },
                {
                    display: "所属警局", name: "所属警局", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
                    options: {
                        url: '../handler/select.ashx?view=Rent_PoliceStation&idfield=PSName&textfield=PSName&distinct=true&needAll=1&&where={"op":"and","rules":[{"op":"equal","field":"ParentID","value":"0","type":"string"}]}',
                        initValue: '全部', valueFieldID: 'RPSParentName', selectBoxWidth: '160'
                    }
                },
                 {
                     display: "所属派出所", name: "所属派出所", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
                     options: {
                         url: '../handler/select.ashx?view=Rent_PoliceStation&idfield=PSName&textfield=PSName&distinct=true&needAll=1&&where={"op":"and","rules":[{"op":"notequal","field":"ParentID","value":"0","type":"string"}]}',
                         initValue: '全部', valueFieldID: 'RPSName', selectBoxWidth: '180'
                     }
                 },
                { display: "所属区域", name: "所属区域", newline: true, labelWidth: 100, width: 100, space: 20, type: "select", cssClass: "field",
                    options: {
                        url: '../handler/select.ashx?view=Rent_District&idfield=LDName&textfield=LDName&distinct=true&needAll=1',
                        initValue: '全部', valueFieldID: 'RDName', selectBoxWidth: '100'
                    }
                },
                { display: "社区名称", name: "社区名称", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
                    options: {
                        url: '../handler/select.ashx?view=Rent_Road&idfield=LRName&textfield=LRName&distinct=true&needAll=1',
                        initValue: '全部', valueFieldID: 'RRName'
                    }
                },
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
              case "rent":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  $.ligerDialog.open({ height: 450, width: 850, url: '../RentHouse/RentInfoHistory.aspx?RentNo=' + selected.RentNO + '&type=V', title: '租赁历史信息' });
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
                          $.ligerDialog.open({ height: 480, width: 800, url: '../RentHouse/RentInfoAdd.aspx?RentNo=' + data + '&type=V', title: '查看租赁信息' });
                      },
                      error: function (message) {
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
