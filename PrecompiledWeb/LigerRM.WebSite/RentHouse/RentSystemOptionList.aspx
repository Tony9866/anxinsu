<%@ Page Language="C#" Inherits="LigerRM.Common.ViewPageBase" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.all.js" type="text/javascript"></script>   
    <script src="../lib/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script>  
    <script src="../lib/json2.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerTextBox.js" type="text/javascript"></script> 
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script>
    
    <script src="../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script> 
    <script src="../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script src="../lib/jquery.form.js" type="text/javascript"></script>

    <script src="../lib/js/iconselector.js" type="text/javascript"></script> 
    <style type="text/css">
    .l-panel td.l-grid-row-cell-editing { padding-bottom: 2px;padding-top: 2px;}
    </style>
</head>
<body style="padding:2px;height:100%; text-align:center;">
  
  <div id="layout">
    <div position="left" title="基础数据" id="baseInfo">
        <ul id="maintree"></ul>
     </div>
    <div position="center" title="子基础数据"> 
        <form id="mainform">
        <div id="maingrid"  style="margin:2px;"></div> 
        </form>
    </div>
  </div>
  <ul class="iconlist">
  </ul>
  <script type="text/javascript">
    
      //验证
      var maingform = $("#mainform");
      $.metadata.setType("attr", "validate");
      LG.validate(maingform, { debug: true });
      //覆盖本页面grid的loading效果
      LG.overrideGridLoading(); 

      function itemclick(item)
      {
          var editingrow = grid.getEditingRow();
          switch (item.text)
          {
              case "增加":
                  if (editingrow == null)
                  {
                      addNewRow();
                  } else
                  {
                      LG.tip('请先提交或取消修改');
                  }
                  break;
              case "修改":
                  if (editingrow == null)
                  {
                      beginEdit();
                  } else
                  {
                      LG.tip('请先提交或取消修改');
                  }
                  break;
              case "保存":
                  if (editingrow != null)
                  {
                      grid.endEdit(editingrow);
                  } else
                  {
                      LG.tip('现在不在编辑状态!');
                  }
                  break;
              case "取消":
                  if (editingrow != null)
                  {
                      grid.cancelEdit(editingrow); 
                  } else
                  {
                      LG.tip('现在不在编辑状态!');
                  }
                  break;
              case "删除": 
                  $.ligerDialog.confirm('确定删除吗?', function (confirm) {
                      if (confirm)
                          f_delete();
                  });
                  break;
          }
      }
      function f_reload()
      {
          grid.loadData();
      }
      function f_delete()
      { 
          var selected = grid.getSelected();
          if (selected)
          {
              if (!selected.RSOID)
              {
                  grid.deleteRow(selected);
                  return;
              }
              LG.ajax({
                  type: 'AjaxSystem',
                  method: 'RemoveRentSystemOption',
                  loading:'正在删除中...',
                  data: { RSOID: selected.RSOID },
                  success: function () { 
                      LG.showSuccess('删除成功');
                      f_reload();
                  },
                  error: function (message)
                  {
                      LG.showError(message);
                  }
              });
          }
          else
          {
              LG.tip('请选择行!');
          }
      }
      var toolbarOptions = { 
        items: [ 
            { text: '增加', click: itemclick , img:"../lib/icons/silkicons/add.png"}, 
            { line:true },
            { text: '修改', click: itemclick, img: "../lib/icons/miniicons/page_edit.gif" },
            { line: true },
            { text: '保存', click: itemclick, img: "../lib/icons/silkicons/page_save.png" },
            { line: true },
            { text: '取消', click: itemclick, img: "../lib/icons/silkicons/cancel.png" },
            { line: true },
            { text: '删除', click: itemclick, img: "../lib/icons/miniicons/page_delete.gif" },
            { line: true },
        ]
    };

    var currentRSOParentNo;
    var treefilter = {
        op: 'or',
        rules: [
        { field: 'RSOParentNo', value: '', op: 'equal' },
        { field: 'RSOParentNo', op: 'isnull' }
        ]
    };
    var tree = $("#maintree").ligerTree({
        url: '../handler/tree.ashx?' +
    $.param({
        root: '主信息',
        rooticon: '../lib/icons/32X32/category.gif',
        view: 'Rent_RentSystemOption',
        idfield: 'RSOID',
        pidfield: 'RSOParentNo',
        textfield: 'RSOName',
        where: JSON2.stringify(treefilter)
    }),
        checkbox: false,
        onClick: function (node) {
            var where;
            if (!node.data.RSOID) {
                where = {
                    op: 'and',
                    rules: [{ field: 'RSOParentNo', value: '0', op: 'isnull'}]
                };
             }
            else {
                where = {
                    op: 'and',
                    rules: [{ field: 'RSOParentNo', value: node.data.RSOID, op: 'equal' }]
                };
            }
            currentRSOParentNo = node.data.RSOID;
            grid.set('parms', { where: JSON2.stringify(where) });
            grid.set('url', '../handler/grid.ashx?view=Rent_RentSystemOption');
        }
    });

    var layout = $("#layout").ligerLayout({ leftWidth: 140 });
     
    var grid = $("#maingrid").ligerGrid({
        //headerImg:"../lib/icons/silkicons/table.png",title:'表格表头',
        columns: [
                { display: '子基础数据', name: 'RSOName', align: 'left', width: 180, minWidth: 60
                , validate: { required: true }
                , editor: { type: 'text', maxlength: 50 }
                },
                //{
                //display: '基础数据编号', name: 'RSONo', align: 'left', width: 130, minWidth: 60
                //, validate: { required: true }
                //, editor: { type: 'text' }
                //},
                {
                    display: '序号', name: 'RSOOrder', align: 'left', width: 130, minWidth: 60, type: 'number'
                , validate: { required: true  }
                , editor: { type: 'text' }
                }
                //,
                // {
                //     display: '链接地址', name: 'RSOUrl', align: 'left', width: 300, minWidth: 60
                //, validate: { required: true, maxlength: 50 }
                //, editor: { type: 'text' }
                // }
                ], dataAction: 'server', pageSize: 20, toolbar: toolbarOptions, sortName: 'RSOID',
        width: '98%', height: '100%', heightDiff: -5, checkbox: false, usePager: false, enabledEdit: true, clickToEdit: false,
        fixedCellHeight: true, rowHeight: 25
    });


    grid.bind('beforeSubmitEdit', function (e)
    {
        if (!LG.validator.form())
        {
            LG.showInvalid();
            return false;
        }
        return true;
    });
    grid.bind('afterSubmitEdit', function (e)
    {
        var isAddNew = e.record['__status'] == "add";
        var data = $.extend({ RSOParentNo: currentRSOParentNo }, e.newdata);
        if (!isAddNew)
            data.RSOID = e.record.RSOID;
        LG.ajax({
            loading: '正在保存数据中...',
            type: 'AjaxSystem',
            method: isAddNew ? "AddRentSystemOption" : "UpdateRentSystemOption",
            data: data,
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
    }); 

    function beginEdit()
    {
        var row = grid.getSelectedRow();
        if (!row) { LG.tip('请选择行'); return; }
        grid.beginEdit(row); 
    }
    function addNewRow()
    {
        grid.addEditRow();
    }
  </script>
</body>
</html> 
