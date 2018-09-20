<<<<<<< HEAD
﻿<%@ page language="C#" autoeventwireup="true" inherits="BaseManage_CarveCorpSelect, App_Web_cc24bspp" %>
=======
﻿<%@ page language="C#" autoeventwireup="true" inherits="BaseManage_CarveCorpSelect, App_Web_idpc1t1v" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户区域管理</title>
        <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
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

            function isExitsFunction(funcName) {
                try {
                    if (typeof (eval(funcName)) == "function") {
                        return true;
                    }
                } catch (e) { }
                return false;
            }
</script>
</head>
<body style="padding:10px;height:100%; text-align:center;">
<form id="Form1"  runat="server">

   <input type="hidden" id="MenuNo" value="UserCarveCorp" />

</form>
  <div id="maingrid"></div> 
  <div style="margin-top:10px;"><input name="btnOK" type=button 
          onclick="f_getChecked();" class="buttonDefault" value="确定" />&nbsp;<input name="btnClose" type=button onclick="CloseDialog();" class="buttonDefault" value="关闭" /></div>
  <script type="text/javascript">
  </script>
  <script type="text/javascript">
      //相对路径
      var rootPath = "../";
      //列表结构
      var carvecorps = "0";
      var grid = $("#maingrid").ligerGrid({
          columns: [
          { display: "区域名称", name: "PSName", width: 200, type: "text", align: "left" },
          { display: "负责人", name: "PSContactPerson", width: 100, type: "date", align: "left" },
          { display: "地址", name: "PSAddress", width: 150, type: "date", align: "left"}],
          dataAction: 'server', pageSize: 20,
          url: rootPath + 'handler/treegrid.ashx?view=Rent_PoliceStation&idfield=PSID&pidfield=ParentID', sortName: 'PSID',
          tree: { columnName: 'PSName' },
          width: '98%', height: '90%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true, rownumbers: true, usePager: false, isChecked: f_isChecked, onCheckRow: f_onCheckRow, onCheckAllRow: f_onCheckAllRow

      });

      function f_onCheckAllRow(checked) {
          for (var rowid in this.records) {
              if (checked)
                  addCheckedCustomer(this.records[rowid]['PSID']);
              else
                  removeCheckedCustomer(this.records[rowid]['PSID']);
          }
      }

      /*
      该例子实现 表单分页多选
      即利用onCheckRow将选中的行记忆下来，并利用isChecked将记忆下来的行初始化选中
      */
      var checkedCustomer = [];

      function findCheckedCustomer(cac_corp_id) {
          for (var i = 0; i < checkedCustomer.length; i++) {
              if (checkedCustomer[i] == cac_corp_id) return i;
          }
          return -1;
      }

      function addCheckedCustomer(cac_corp_id) {
          if (findCheckedCustomer(cac_corp_id) == -1)
              checkedCustomer.push(cac_corp_id);
      }

      function removeCheckedCustomer(cac_corp_id) {
          var i = findCheckedCustomer(cac_corp_id);
          if (i == -1) return;
          checkedCustomer.splice(i, 1);
      }

      function f_isChecked(rowdata) {
          if (findCheckedCustomer(rowdata.PSID) == -1)
              return false;
          return true;
      }

      function f_onCheckRow(checked, data) {
          if (checked) addCheckedCustomer(data.PSID);
          else removeCheckedCustomer(data.PSID);
      }

      function f_getChecked() {
          $(window.parent.document).find("input[id='txtCarve']").val(checkedCustomer.join(','));
          parent.$.ligerDialog.close();
          parent.$(".l-dialog,.l-window-mask").css("display", "none");
      }

      function CloseDialog() {
          parent.$.ligerDialog.close();
          parent.$(".l-dialog,.l-window-mask").css("display", "none");
      }

      function f_reload() {
          grid.loadData();
      }

  </script> 
</body>
</html>

