<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Detail.master" AutoEventWireup="true" CodeFile="UserCommunityDetail.aspx.cs" Inherits="RentHouse_UserCommunityDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div id="mainsearch" style=" width:98%">
<table style="width:580px; background-color:#cccccc; margin:5px;" border="0" cellpadding="1" cellspacing="1">
                <tr>
                    <td style="padding: 5px; background-color: #FFFFFF;" width="120">
                        分局：</td>
                    <td style="padding: 5px; background-color: #FFFFFF;" width="250">
                        <asp:DropDownList ID="ddlStation" runat="server" DataTextField="PSName" 
                            DataValueField="PSID" 
                            onselectedindexchanged="ddlStation_SelectedIndexChanged" 
                            onchange="javascript:f_changeRegions();" AutoPostBack="True">
                        </asp:DropDownList>
                        </td>
                    <td style="padding: 5px; background-color: #FFFFFF;" width="80">
                        派出所：</td>
                    <td style="padding: 5px; background-color: #FFFFFF;" width="250">
                        <asp:DropDownList ID="ddlPolice" runat="server" DataTextField="PSName" 
                            DataValueField="PSID" AutoPostBack="True" 
                            onchange="javascript:f_changeRegions();" 
                            onselectedindexchanged="ddlPolice_SelectedIndexChanged">
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td style="padding: 5px; background-color: #FFFFFF;" width="80">
                        登录用户：</td>
                    <td style="padding: 5px; background-color: #FFFFFF;" width="250">
                        <asp:DropDownList ID="ddlUsers" runat="server" DataTextField="RealName" 
                            DataValueField="UserID" 
                            onselectedindexchanged="ddlUsers_SelectedIndexChanged" 
                            onchange="javascript:f_changeRegions();">
                        </asp:DropDownList>
                        </td>
                    <td style="padding: 5px; background-color: #FFFFFF;" width="80">
                        &nbsp;</td>
                    <td style="padding: 5px; background-color: #FFFFFF;" width="250">
                        &nbsp;</td>
                </tr>
                </table>
  </div>
  <div id="maingrid"></div> 
  <div style="padding-top:5px;">
  <input ID="btnSave" type="button"
                            value="保存信息" class="buttonDefault" onclick="javascript:SaveRef();" />
                        &nbsp;<input ID="btnClose" onclick="javascript:CloseDialog();" type="button" 
                            value="关闭窗口" class="buttonDefault" /></div>
                            <script type="text/javascript">
                                
                            </script>
  <script type="text/javascript">

      //相对路径
      var rootPath = "../";
      var regions = "0";
      function CloseDialog() {
          parent.$.ligerDialog.close();
          parent.$(".l-dialog,.l-window-mask").css("display", "none");
      }

      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [
          { display: "区域名称", name: "LRName", width: 200, type: "text", align: "left" },
          { display: "描述", name: "PSContactPerson", width: 100, type: "date", align: "left" },
          { display: "派出所", name: "PSName", width: 150, type: "date", align: "left"}],
          dataAction: 'server', pageSize: 20,
          url: rootPath + 'handler/grid.ashx?view=Rent_Road&where={"op":"and","rules":[{"op":"equal","field":"LDID","value":"' + document.getElementById("<%=ddlPolice.ClientID %>").value + '","type":"string"}]}', sortName: 'PSID',
          width: '98%', height: '90%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true, rownumbers: true, usePager: false, isChecked: f_isChecked

      });

      function f_isChecked(rowdata) {
          if (regions.indexOf(rowdata.PSID) != -1)
              return true;
          return false;
      }
      function f_changeRegions() {
          var user = document.getElementById("ctl00_ContentPlaceHolder1_ddlUsers").value;
          LG.ajax({
              type: 'AjaxUserInfoManage',
              method: 'GetUserAreaRef',
              loading: '正在获取...',
              data: { userId: user },
              success: function (data, message) {
                  regions = message;
                  f_reload();
              },
              error: function (message) {
                  LG.showError(message);
                  return;
              }
          });
      }


      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "登录用户", name: "登录用户", newline: false, labelWidth: 100, width: 150, space: 30, type: "select", cssClass: "field",
              options: {
                  url: '../handler/select.ashx?view=CF_User&idfield=LoginName&textfield=RealName&distinct=true&needAll=1', initValue: '全部',
                  valueFieldID: 'LoginName'
              }
          }],
          toJSON: JSON2.stringify
      });

      function f_reload() {
          grid.loadData();
      }

      function SaveRef() {
          var rows = grid.getCheckedRows();
          var a = rows.length;
          var b = 0;
          var user = document.getElementById("ctl00_ContentPlaceHolder1_ddlUsers").value;
          if (grid.getSelected()) {
              var manager = $.ligerDialog.waitting('正在保存,请稍候...');

              //delete the record
              LG.ajax({
                  type: 'AjaxUserInfoManage',
                  method: 'DeleteUserCommunityRef',
                  loading: '正在删除...',
                  data: { User: user },
                  success: function () {
                  },
                  error: function (message) {
                      LG.showError(message);
                      return;
                  }
              });

              var rows = grid.getCheckedRows();

              var data = [];
              for (var i = 0, l = rows.length; i < l; i++) {
                  var o = $.extend({}, rows[i]);
                  data.push(o);
              }

              //add new record
              //              $(rows).each(function () {
              LG.ajax({
                  type: 'AjaxUserInfoManage',
                  method: 'UpdateUserCommunityRef',
                  loading: '正在保存...',
                  data: { User: user, DataJSON: JSON2.stringify(data) },
                  success: function () {
                      $.ligerDialog.alert('用户区域设置成功！', '提示', 'success', function (item, Dialog, index) {
                          parent.$.ligerDialog.close();
                          parent.window.f_reload();
                          parent.$(".l-dialog,.l-window-mask").css("display", "none");
                      });
                  },
                  error: function (message) {
                      manager.close();
                      LG.showError(message);
                  }
              });
              //              });
          }
          else {
              LG.tip('请选择行!');
          }
      }

  </script> 
</asp:Content>
