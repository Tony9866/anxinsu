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
    
    <script src="../lib/ligerUI/js/plugins/ligerFilter.js" type="text/javascript"></script>
    <style type="text/css">
    .filterpanle{ margin:10px;}
    .l-panel td.l-filter-column,.l-panel td.l-filter-value,.l-panel td.l-filter-op{ padding:2px;}
    
    .l-selected .l-grid-row-cell, .l-selected {background: #F5F5F5;}
    .l-panel td .l-filter-rowlast{ padding-top:1px;}
    </style>
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <ipnut type="hidden" id="MenuNo" value="sysDataPrivilege" />
  <div id="mainsearch" style=" width:98%"> 
  <div id="maingrid"></div> 
  <script type="text/javascript">
      var AllMethods = <%=JSONHelper.ToJson(AjaxRequestHelper.GetActionNameList()) %>;
      var AdminMethods;
      //相对路径
      var rootPath = "../";
      //列表结构
      var toolbarOptions = {
          items: [
            { text: '保存', id: 'save', click: toolbarBtnItemClick, img: "../lib/icons/silkicons/page_save.png" }
        ]
      };
      var grid = $("#maingrid").ligerGrid({
          columns: [
          { display: "管理员专属", name: "AdminOnly", width: 68,   align: "left",render:checkboxRender },
          { display: "条件规则", name: "FullName", width: 680,   align: "left"  }
          ], dataAction: 'server', pageSize: 20, toolbar: toolbarOptions, 
          width: '98%', height: '100%',heightDiff:-10, checkbox: false,usePager:false
          ,mouseoverRowCssClass : null,alternatingRow :false
      });

      f_reload();

      function getGridData()
      {
            var rows = [];
            $(AllMethods).each(function(){
                var row = {FullName:this.toString()}; 
                row.AdminOnly = existMethod(row.FullName);
                rows.push(row);
            });
            return {Rows:rows};
      } 

      function existMethod(fullname)
      { 
           for(var i=0,l=AdminMethods.length;i<l;i++)
           {
                var m = AdminMethods[i];
                var cuurentFullName = m.type + "." + m.name;
                if(cuurentFullName == fullname) return true;
           }
           return false;
      }

      function f_reload() { 
          LG.ajax({
            type: 'AjaxSystem',
            method: 'GetAdminMethodSetting',
            loading:'正在加载中...', 
            success: function (data) { 
                    AdminMethods = data;
                    grid.options.data = getGridData();
                    grid.loadData(grid.options.data);
            },
            error: function (message)
            {
                LG.showError(message);
            }
        }); 
      }
 

      //工具条事件
      function toolbarBtnItemClick(item) {
          switch (item.id) {
              case "save":
                  f_save();
                  break; 
          }
      }
      
      function f_save() {
          var data = [];
          for(var i =0,l=grid.rows.length;i<l;i++)
          {
               var o = grid.rows[i];
               if(o.AdminOnly) data.push(o.FullName);
          }

          LG.ajax({
                type: 'AjaxSystem',
                method: 'SaveAdminMethodSetting',
                loading:'正在保存中...',
                data: { data: JSON2.stringify(data) },
                success: function () { 
                    LG.showSuccess('保存成功'); 
                },
                error: function (message)
                {
                    LG.showError(message);
                }
            });
      }


    //表字段配置信息 是否类型的模拟复选框的渲染函数
    function checkboxRender(rowdata, rowindex, value, column)
    {
        var iconHtml = '<div class="chk-icon';
        if (value) iconHtml += " chk-icon-selected";
        iconHtml += '"';
        iconHtml += ' rowid = "' + rowdata['__id'] + '"';
        iconHtml += ' gridid = "' + this.id + '"';
        iconHtml += ' columnname = "' + column.name + '"';
        iconHtml += '></div>';
        return iconHtml;
    }
    //表字段配置信息 是否类型的模拟复选框的点击事件
    $("div.chk-icon").live('click', function ()
    {
        var grid = $.ligerui.get($(this).attr("gridid"));
        var rowdata = grid.getRow($(this).attr("rowid"));
        var columnname = $(this).attr("columnname");
        var checked = rowdata[columnname];

        grid.updateCell(columnname, !checked, rowdata);
    });
  </script>
</body>
</html>
