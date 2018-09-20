<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="RentHouse_PersonMonitorDetail, App_Web_h3mtpn1q" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
.ajax__calendar_container {
  padding:4px;position:absolute;
  cursor:default;
  width:170px;
  font-size:11px;
  text-align:center;
  font-family:tahoma,verdana,helvetica;
  z-index:9999;
}
</style>
<script type="text/javascript">
    function SubmitDialog() {
        var manager = $.ligerDialog.alert('布控信息保存成功！', '提示', 'success', function (item, Dialog, index) {
            parent.$.ligerDialog.close();
            parent.$(".l-dialog,.l-window-mask").css("display", "none");
            parent.f_reload();
        });

    }

    function ValidateForm() {

        var district = document.getElementById("<%=txtName.ClientID %>");
        if (district.value == '') {
            $.ligerDialog.error('请填写布控人员姓名！');
            return false;
        }

        var street = document.getElementById("<%=txtIdCard.ClientID %>");
        if (street.value == '') {
            $.ligerDialog.error('请填写布控人员身份证号码！');
            return false;
        }

        var road = document.getElementById("<%=txtStart.ClientID %>");
        if (road.value == '') {
            $.ligerDialog.error('请选择布控开始日期！');
            return false;
        }
    }
</script>
    <table border="0" cellpadding="1" cellspacing="1" width="500" 
                            style="vertical-align:bottom; background-color: #cccccc; margin:5px;" 
                            __designer:mapid="5">
        <tr __designer:mapid="1f">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 120px;" 
                                    valign="bottom" height="22" __designer:mapid="20">
                人员姓名：<span style="color: #FF0000" 
                                             __designer:mapid="21">*</span>
            </td>
            <td valign="bottom" colspan="1" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 400px;" 
                                         __designer:mapid="22">
                <asp:TextBox ID="txtName" runat="server" CssClass="txt" MaxLength="50" 
                                              Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="2a">
            <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 120px;" 
                                          valign="bottom" __designer:mapid="2b">
                身份证号码：<span style="color: #FF0000" __designer:mapid="2c">*</span>
            </td>
            <td colspan="1" height="22" 
                                          
                style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 400px;" 
                valign="bottom" __designer:mapid="2d">
                <asp:TextBox ID="txtIdCard" runat="server" CssClass="txt" MaxLength="18" 
                                              Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="32">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 120px;" 
                                         valign="bottom" __designer:mapid="33">
                手机号码：</td>
            <td colspan="1" valign="bottom" 
                                        
                                         style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 400px;" 
                                         __designer:mapid="35">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" MaxLength="13" 
                                              Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="32">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 120px;" 
                                         valign="bottom" height="22" __designer:mapid="33">
                布控类型：<span 
                                             style="color: #FF0000" __designer:mapid="34">*</span></td>
            <td colspan="1" valign="bottom" height="22" 
                                        
                                         style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 400px;" 
                                         __designer:mapid="35">
                <asp:DropDownList ID="ddlType" runat="server" Width="195px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr __designer:mapid="32">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 120px;" 
                                         valign="bottom" height="22" __designer:mapid="33">
                布控开始时间：<span 
                                             style="color: #FF0000" __designer:mapid="34">*</span></td>
            <td colspan="1" valign="bottom" height="22" 
                                        
                                         style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 400px;" 
                                         __designer:mapid="35">
                <asp:TextBox ID="txtStart" runat="server" CssClass="txt" MaxLength="3" 
                                              Width="195px"></asp:TextBox>
                                        <asp:ImageButton ID="btnStart" runat="server" ImageAlign="AbsBottom" 
                                            ImageUrl="~/Images/calendar.gif" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" 
                    runat="server" Format="yyyy-MM-dd" TargetControlID="txtStart"
                                            PopupButtonID="btnStart">
                                        </cc1:CalendarExtender>

            </td>
        </tr>
        <tr __designer:mapid="32">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 120px;" 
                                         valign="bottom" height="22" __designer:mapid="33">
                布控结束时间：</td>
            <td colspan="1" valign="bottom" height="22" 
                                        
                                         style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 400px;" 
                                         __designer:mapid="35">
                <asp:TextBox ID="txtEnd" runat="server" CssClass="txt" MaxLength="3" 
                                              Width="195px"></asp:TextBox>
                                        <asp:ImageButton ID="btnEnd" runat="server" ImageAlign="AbsBottom" 
   
                                            ImageUrl="~/Images/calendar.gif" />
                                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEnd"
                                            PopupButtonID="btnEnd">
                                        </cc1:CalendarExtender>
            </td>
        </tr>
        <tr __designer:mapid="a1">
            <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 120px;" 
                                          valign="bottom" __designer:mapid="a2">
                                          &nbsp;</td>
            <td height="22" 
                                          style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 400px;" 
                                          valign="bottom" __designer:mapid="a3">
                <asp:Button ID="btnSave" runat="server" CssClass="buttonDefault" 
                                              OnClick="btnSave_Click" OnClientClick="javascript:return ValidateForm();" 
                                              Text="保存信息" />
                <input onclick="javascript:window.close();" type="button" 
                                            value="关闭窗口" class="buttonDefault" __designer:mapid="a5" />
            </td>
        </tr>
    </table>

</asp:Content>

