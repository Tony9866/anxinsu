<%@ page language="C#" autoeventwireup="true" inherits="InfoRegister_CorporationQuickLookUp, App_Web_hukugsuc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>使用单位信息查询</title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script> 
    <script src="../lib/js/jquery.jqprint-0.3.js" type="text/javascript"></script> 
    <base target="_self">
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <input type="hidden" id="MenuNo" value="CorporationQuery" />
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
  <div id="maingrid">
    
  </div> 
 <div style="text-align:left; padding-top:5px;"><input type="button" class="buttonDefault" value="确定" onclick="javascript:SelectCorporation();" /> <input type="button" class="buttonDefault" value="关闭" onclick="javascript:window.close();" /></div> 
  <script type="text/javascript">
      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "使用单位编号", name: "co_corp_id", width: 100, type: "text", align: "left" },
          { display: "使用单位名称", name: "co_corp_name", width: 350, type: "text", align: "left" },
          { display: "企业类型", name: "corptypename", width: 150, type: "text", align: "left" },
          { display: "企业法人", name: "co_boss", width: 100, type: "date", align: "left" }],
          dataAction: 'server', pageSize: 10, //toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=t_corporation_view', sortName: 'co_corp_id',
          width: '98%', height: '95%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26, rownumbers: true,
          selectRowButtonOnly: true
      });

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "使用单位编号", name: "co_corp_id", newline: false, labelWidth: 100, width: 100, space: 20, type: "text", cssClass: "field" },
          { display: "使用单位名称", name: "co_corp_name", newline: false, labelWidth: 100, width: 120, space: 20, type: "text", cssClass: "field" },
                    { display: "所属区域", name: "所属区域", newline: false, labelWidth: 80, width: 100, space: 20, type: "select", cssClass: "field",
                        options: {
                            url: '../handler/select.ashx?view=t_area&idfield=ar_area_id&textfield=ar_area_name&distinct=true&needAll=1',
                            initValue: '全部', valueFieldID: 'co_area_id'
                        }
                    }
          ],
          toJSON: JSON2.stringify
      });

      //增加搜索按钮,并创建事件
      LG.appendSearchButtons("#formsearch", grid);

      //加载toolbar
      //LG.loadToolbar(grid, toolbarBtnItemClick);

      //工具条事件
      function toolbarBtnItemClick(item) {
          switch (item.id) {
              case "print":
                  $("#maingrid").jqprint();
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
          var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
      }

      function SelectCorporation() {
          var rt = new Array(2);
          var selected = grid.getSelected();
          if (!selected) { LG.tip('请选择行!'); return }
          rt[0] = selected.co_corp_id;
          rt[1] = selected.co_corp_name;
          window.returnValue = rt; 
          window.close();
      }

  </script>
</body>
</html>
