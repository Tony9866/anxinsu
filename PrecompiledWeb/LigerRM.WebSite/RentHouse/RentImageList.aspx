<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_RentImageList, App_Web_5ncvhhwe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/js/LG.js" type="text/javascript"></script> 
    <script src="../lib/ligerUI/js/ligerui.all.js" type="text/javascript"></script>   
    <script src="../lib/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>  
    
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
  <form id="mainform">
    <div id="maingrid"  style="margin:2px;"></div> 
    </form> 
    <script>
        var rentNo = '<%= System.Web.HttpContext.Current.Request["RentNO"] %>';
        
    </script>
  <script type="text/javascript">
      function wopen(pageURL, title, w, h) {
          var left = (screen.width / 2) - (w / 2);
          var top = (screen.height / 2) - (h / 2) - 20;
          var random = Math.floor(Math.random() * (1000 + 1));
          var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
      }

      //验证
      var maingform = $("#mainform");
      $.metadata.setType("attr", "validate");
      LG.validate(maingform, { debig: true });
      //这里覆盖了本页面grid的loading效果
      $.extend($.ligerDefaults.Grid, {
          onloading: function () {
              LG.showLoading('正在加载表格数据中...');
          },
          onloaded: function () {
              LG.hideLoading();
          }
      });

      function itemclick(item) {
          var editingrow = grid.getEditingRow();
          var id = item.id || item.text;
          switch (id) {
              case "add":
                  $.ligerDialog.open({ height: 230, width: 600, url: 'RentImageDetail.aspx?RentNO=' + rentNo, title: '添加房屋照片' });
                  break;
              case "delete":
                  jQuery.ligerDialog.confirm('您确定要删除此记录吗?', function (confirm) {
                      if (confirm)
                          f_delete();
                  });
                  break;
          }
      }

      function f_reload() {
          grid.loadData();
      }

      function viewImage(id, signetId) {
          $.ligerDialog.open({ height: 530, width: 880, url: 'ImageViewer.aspx?id=' + id + "&RentNO=" + signetId, title: '查看房源照片' });
      }

      function f_delete() {
          var selected = grid.getSelected();
          if (selected) {
              if (!selected.id) {
                  grid.deleteRow(selected);
                  return;
              }
              LG.ajax({
                  type: 'AjaxSignetManage',
                  method: 'RemoveSignetFile',
                  loading: '正在删除中...',
                  data: { id: selected.id },
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
      var toolbarOptions = {
          items: [
            { id: 'add', text: '文件添加', click: itemclick, img: "../lib/icons/silkicons/add.png" },
            { line: true },
            { id: 'delete', text: '删除', click: itemclick, img: "../lib/icons/miniicons/page_delete.gif" }
        ]
      };

      var grid = $("#maingrid").ligerGrid({
          columns: [
                { display: '房源编号', name: 'RentNO', align: 'left', width: 120, minWidth: 60
                },
                { display: '文件名称', name: 'ImageName', align: 'left', width: 300, minWidth: 60,
                    render: function (rowdata, rowindex, value) {
                        //return "<a href='ImageViewer.aspx?id=" + rowdata.id + "&signetId=" + rowdata.sf_signet_id + "' target='_blank'>" + rowdata.sf_file_name + "</a>";
                        return "<a href='#' onclick='javascript:viewImage(" + rowdata.ImageID + " ," + rowdata.RentNO + ");'>" + rowdata.ImageName + "</a>";
                    }
                },
                { display: '备注', name: 'Memo', align: 'left', width: 300, minWidth: 60 }
                ], toolbar: toolbarOptions, sortName: 'ImageID',
          width: '98%', height: '100%', heightDiff: -5, checkbox: false,
          usePager: false, clickToEdit: false, rownumbers: true,
          fixedCellHeight: true, rowHeight: 25,
          url: '../handler/grid.ashx?view=Rent_Image',
          parms: { where: JSON2.stringify({
              op: 'and',
              rules: [{ field: 'RentNO', value: rentNo, op: 'equal'}]
          })
          }
      });


  </script> 
</body>
</html> 
