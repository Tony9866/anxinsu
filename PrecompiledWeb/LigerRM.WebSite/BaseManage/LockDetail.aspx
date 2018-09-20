<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="BaseManage_LockDetail, App_Web_gnmc3w40" %>
=======
<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="BaseManage_LockDetail, App_Web_cc24bspp" %>
=======
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="BaseManage_LockDetail, App_Web_idpc1t1v" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        function SaveDialog() {
            var manager = $.ligerDialog.alert('智能锁信息保存成功！', '提示', 'success', function (item, Dialog, index) {
                parent.f_reload();
                parent.$.ligerDialog.close();
                parent.$(".l-dialog,.l-window-mask").css("display", "none");
            });
        }

        function CloseDialog() {
            parent.f_reload();
            parent.$.ligerDialog.close();
            parent.$(".l-dialog,.l-window-mask").css("display", "none");
        }


        function ValidateForm() {


        }

        function SelectCorporation() {
            var signetId;
            var random = Math.floor(Math.random() * (1000 + 1));
            var obj = window.showModalDialog('../RentHouse/HouseQuickLookUp.aspx?date=' + random, '选择房源', 'dialogHeight:500px;dialogWidth:780px');

            if (obj) {
                document.getElementById("<%=hdRentNO.ClientID %>").value = obj[0];
                document.getElementById("<%=txtRentNO.ClientID %>").value = obj[1];
            }
        }
</script>
    <table border="0" cellpadding="1" cellspacing="1" width="580px" 
                            style="vertical-align:bottom; background-color: #cccccc; margin:5px;" 
                            >
        <tr __designer:mapid="18">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22" __designer:mapid="19">
                设备编号：<span style="color: #FF0000" 
                                            __designer:mapid="28">*</span></td>
            <td width="200px" 
                                        valign="bottom" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="1a">
                <asp:TextBox ID="txtDeviceID" runat="server" CssClass="txt" 
                                            Width="160px" MaxLength="30"></asp:TextBox>
                </td>
            <td width="100px" valign="bottom" 
                            style="padding: 2px; height: 25px; background-color: #FFFFFF" __designer:mapid="1c">
                设备类型：</td>
            <td width="200px" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="1d">
                    <asp:DropDownList ID="ddlDeviceType" runat="server" 
                onselectedindexchanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr id="trOrg" runat="server" visible="true" __designer:mapid="46">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="170px" height="22" __designer:mapid="47">
                <asp:Label ID="Label1" runat="server" Text="使用房屋："></asp:Label>
                <span style="color: #FF0000" __designer:mapid="4d">*</span></td>
            <td valign="bottom" height="22" 
                                        colspan="3" style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="49">
                <asp:TextBox ID="txtRentNO" runat="server" CssClass="txt" MaxLength="160" 
                                            Width="87%"></asp:TextBox>
                <img alt="" src="../Images/gtk-zoom-in.png" 
                    onclick="javascript:SelectCorporation();" width="20" /><input 
                    id="Hidden1" type="hidden" /><asp:HiddenField ID="hdRentNO" 
                    runat="server" />
            </td>
        </tr>
        <tr __designer:mapid="50">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22" __designer:mapid="51">
                硬件版本：</td>
            <td valign="bottom" 
                                        height="22" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="52">
                <asp:TextBox ID="txtVersion" runat="server" CssClass="txt" 
                                            Width="160px" MaxLength="30"></asp:TextBox>
            </td>
            <td style="padding: 2px; height:25px; background-color:#FFFFFF;" 
                                        valign="bottom" id="tdAreaTitle" runat="server"
                                        width="100px" __designer:mapid="54">
                                        生产批次：</td>
            <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="55">
                <asp:TextBox ID="txtBatch" runat="server" CssClass="txt" 
                                            Width="160px" MaxLength="30"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="50">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22" __designer:mapid="51">
                生产日期：</td>
            <td valign="bottom" 
                                        height="22" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="52">
                <asp:TextBox ID="txtDate" runat="server" CssClass="txt" 
                                            Width="160px" MaxLength="30"></asp:TextBox>
            </td>
            <td style="padding: 2px; height:25px; background-color:#FFFFFF;" 
                                        valign="bottom" runat="server"
                                        width="100px" __designer:mapid="54">
                                        状态：</td>
            <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="55">
                    <asp:DropDownList ID="ddlStatus" runat="server" 
                onselectedindexchanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr __designer:mapid="50">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22" __designer:mapid="51">
                实时状态：</td>
            <td valign="bottom" 
                                        height="22" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="52">
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </td>
            <td style="padding: 2px; height:25px; background-color:#FFFFFF;" 
                                        valign="bottom" runat="server"
                                        width="100px" __designer:mapid="54">
                                        &nbsp;</td>
            <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="55">
                &nbsp;</td>
        </tr>
        <tr __designer:mapid="57">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="middle" 
                                        width="100px" height="22" align="left" __designer:mapid="58">
                备注：</td>
            <td valign="bottom" colspan="3" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="59">
                <asp:TextBox ID="txtMemo" runat="server" Height="46px" MaxLength="100" 
                                            TextMode="MultiLine" Width="95%"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="5b">
            <td height="30" style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="100px" __designer:mapid="5c">
                                        &nbsp;</td>
            <td colspan="3" height="30" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="5d">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" 
                                            Text="保存信息" CssClass="buttonDefault" 
                                            
                    OnClientClick="javascript:return ValidateForm();" />
                &nbsp;<input onclick="javascript:CloseDialog();" type="button" 
                                            value="关闭窗口" class="buttonDefault" __designer:mapid="60" />
                <div style="display:none;" __designer:mapid="61">
                    <asp:TextBox ID="txtLinker" 
                                                runat="server" CssClass="txt" MaxLength="10" 
                                            Width="50px"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

