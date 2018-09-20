<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="RentHouse_RentIconAdd, App_Web_0r5pok1k" %>
=======
<<<<<<< HEAD
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="RentHouse_RentIconAdd, App_Web_5ncvhhwe" %>
=======
﻿<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="RentHouse_RentIconAdd, App_Web_bslrsuh2" %>
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
>>>>>>> 9b5c39abd73644358e066733e3ff19b4c03313fe

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .panel
        {
            text-align: center;
            vertical-align: center;
            position: absolute;
            float: left;
        }
    </style>
    <script type="text/javascript">
        function ValidateForm() {
            var contactName = document.getElementById("<%=txtContactName.ClientID %>");
            if (contactName.value == '') {
                $.ligerDialog.error('请输入承租人姓名！');
                return false;
            }

            var idCard = document.getElementById("<%=txtIDCard.ClientID %>");
            if (idCard.value == '') {
                $.ligerDialog.error('请输入承租人身份证号！');
                return false;
            }

            var returnValue = getIdCardInfo(idCard.value);
            if (!returnValue.isTrue) {
                $.ligerDialog.error('房主身份证号码不符合规范，请重新填写！');
                return false;
            }


            var contactTel = document.getElementById("<%=txtContactTel.ClientID %>");
            if (contactTel.value == '') {
                $.ligerDialog.error('请输入承租人电话！');
                return false;
            }

            var rentPrice = document.getElementById("<%=txtRentPrice.ClientID %>");
            if (rentPrice.value == '') {
                $.ligerDialog.error('请输入租赁价格！');
                return false;
            }

            if (!isNumeric(rentPrice.value)) {
                $.ligerDialog.error('价格请输入数字！');
                return false;
            }


            //if (isNaN(rentPrice.value)) {
            //    $.ligerDialog.error('价格请输入数字！');
            //    return false;
            //}

            var startDate = document.getElementById("<%=txtStartDate.ClientID %>");
            if (startDate.value == '') {
                $.ligerDialog.error('请选择租赁起始时间！');
                return false;
            }
            var endDate = document.getElementById("<%=txtEndDate.ClientID %>");
            if (endDate.value == '') {
                $.ligerDialog.error('请选择租赁结束时间！');
                return false;
            }
        }

        function isNumeric(n) {
            return !isNaN(parseFloat(n)) && isFinite(n);
        }

        function ReadCard() {
            var name = document.getElementById("<%=txtContactName.ClientID %>");
            var id = document.getElementById("<%=txtIDCard.ClientID %>");
            ReadIDCard(name, id);
        }

        function CloseWindow() {
            parent.$.ligerDialog.close();
            parent.$(".l-dialog,.l-window-mask").css("display", "none");
        }

        function ReadCardByDesc(username, useridcard) {

            var name = document.getElementById(username);
            var id = document.getElementById(useridcard);
            ReadIDCard(name, id);
        }

        function SubmitDialog() {
            var manager = $.ligerDialog.alert('租赁信息保存成功！', '提示', 'success', function (item, Dialog, index) {
                parent.$.ligerDialog.close();
                parent.$(".l-dialog,.l-window-mask").css("display", "none");
                parent.Search();
            });

        }

        function DeleteDialog() {
            var manager = $.ligerDialog.alert('退房成功！', '提示', 'success', function (item, Dialog, index) {
                parent.$.ligerDialog.close();
                parent.$(".l-dialog,.l-window-mask").css("display", "none");
                parent.Search();
            });

        }

        function AddSignetDialog(RentNo) {

            var manager = $.ligerDialog.alert('租赁信息保存成功！', '提示', 'success', function (item, Dialog, index) {
            });
        }
    </script>
    <div style="text-align: center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="700px">
                    <tr>
                        <td align="left">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" />
                            <table border="0" cellpadding="1" cellspacing="1" width="700px" style="vertical-align: bottom;
                                background-color: #cccccc; margin: 5px;">
                                <tr runat="server" id="trRentNo" visible="false">
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        height="22" width="150px">
                                        房源编号：
                                    </td>
                                    <td width="550px" valign="bottom" colspan="3" height="22" style="background-color: #FFFFFF;
                                        padding: 2px; height: 25px;">
                                        <asp:Label ID="lblRentNo" runat="server" MaxLength="50" Width="150"></asp:Label>
                                        <asp:Label ID="lblRentStatus" runat="server" MaxLength="50" Width="150px" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 2px; height: 22px; background-color: #FFFFFF;" valign="middle"
                                        width="150px">
                                        房间信息：</td>
                                    <td valign="middle" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 22px; width: 400px;" 
                                        colspan="3">
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 2px; height: 22px; background-color: #FFFFFF;" 
                                        valign="middle" width="150px">
                                        承租人姓名：<span style="color: #FF0000">*</span>
                                    </td>
                                    <td style="background-color: #FFFFFF; padding: 2px; height: 22px;" 
                                        valign="middle" width="200px">
                                        <asp:TextBox ID="txtContactName" runat="server" CssClass="txt" MaxLength="50" 
                                            Width="150px"></asp:TextBox>
                                        &nbsp;<img
                                            title="点击读取身份信息！" style="cursor: pointer;" src="../lib/icons/32X32/my_account.gif"
                                            width="20" onclick="javascript:ReadCard();" align="bottom" runat="server" id="imgCard" />
                                    </td>
                                    <td style="padding: 2px; background-color: #FFFFFF;" valign="bottom" 
                                        width="150px">
                                        身份证号：<span style="color: #FF0000">*</span>
                                    </td>
                                    <td style="background-color: #FFFFFF; padding: 2px;" valign="bottom" 
                                        width="200px">
                                        <asp:TextBox ID="txtIDCard" runat="server" CssClass="txt" MaxLength="18" 
                                            Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        height="22" width="150px">
                                        承租人联系电话：<span style="color: #FF0000">*</span>
                                    </td>
                                    <td width="200px" valign="bottom" colspan="1" height="22" style="background-color: #FFFFFF;
                                        padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtContactTel" runat="server" CssClass="txt" MaxLength="50" Width="150"></asp:TextBox>
                                    </td>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        height="22" width="150px">
                                        租赁价格：<span style="color: #FF0000">*</span>
                                    </td>
                                    <td valign="bottom" colspan="1" height="22" style="background-color: #FFFFFF; padding: 2px;
                                        height: 25px;" width="200px">
                                        <asp:TextBox ID="txtRentPrice" runat="server" CssClass="txt" MaxLength="8" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        height="22" width="150px">
                                        电子锁密码：
                                    </td>
                                    <td colspan="1" valign="bottom" width="200px" height="22" style="background-color: #FFFFFF;
                                        padding: 2px; height: 25px;">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="txt" MaxLength="50" 
                                            Width="150"></asp:TextBox>
                                    </td>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        height="22" width="150px">
                                        &nbsp;</td>
                                    <td colspan="1" valign="bottom" width="200px" height="22" style="background-color: #FFFFFF;
                                        padding: 2px; height: 25px;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        width="150px">
                                        租赁起始时间：<span style="color: #FF0000">*</span>
                                    </td>
                                    <td colspan="1" height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px;"
                                        valign="bottom" width="200px">
                                        <asp:TextBox ID="txtStartDate" runat="server" Width="150px"></asp:TextBox>
                                        <asp:ImageButton ID="btnStart" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Images/calendar.gif" />
                                    </td>
                                    <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        width="150px">
                                        租赁结束时间：<span style="color: #FF0000">*</span>
                                    </td>
                                    <td colspan="1" height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px;"
                                        valign="bottom" width="200px">
                                        <asp:TextBox ID="txtEndDate" runat="server" Width="150px"></asp:TextBox>
                                        <asp:ImageButton ID="btnEnd" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Images/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="middle"
                                        width="150px">
                                        随行人员：<asp:ImageButton ID="imgAdd" runat="server" 
                                            ImageUrl="~/lib/icons/silkicons/add.png" onclick="imgAdd_Click" ToolTip="点击添加随行人员信息！" />
                                    </td>
                                    <td height="22" style="background-color: #FFFFFF; padding: 2px; padding-left:0px;  height: 25px" valign="bottom"
                                        colspan="3" width="550px">
                                        <cc1:CalendarExtender ID="CalendarExtender1"
                                                runat="server" Format="yyyy-MM-dd" TargetControlID="txtStartDate" PopupButtonID="btnStart">
                                            </cc1:CalendarExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEndDate"
                                            PopupButtonID="btnEnd">
                                        </cc1:CalendarExtender>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="dlRenties" runat="server" 
                                                    onitemdatabound="dlRenties_ItemDataBound" 
                                                    onitemcommand="dlRenties_ItemCommand">
                                                    <ItemTemplate>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border:1px solid #dddddd;">
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton ID="imgDel" runat="server" 
                                                                        ImageUrl="~/lib/icons/silkicons/delete.png" CommandName = "delete" ToolTip="点击删除随行人员信息！" />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtName" runat="server" Width="70px" Text='<%# Eval("Name") %>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtIdCard" runat="server" Width="200px" Text='<%# Eval("IDCard") %>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="imgRead" runat="server" ImageUrl="~/lib/icons/32X32/my_account.gif" Width="20px" />
                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                </tr>
                                <tr runat="server" visible = "false">
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        height="22" width="150px">
                                        创建人：
                                    </td>
                                    <td colspan="1" valign="bottom" height="22" style="background-color: #FFFFFF; padding: 2px;
                                        height: 25px;">
                                        <asp:Label ID="lblCreatedByName" runat="server" MaxLength="20" Width="150px"></asp:Label>
                                        <asp:Label ID="lblCreatedBy" runat="server" MaxLength="20" Visible="False" Width="150px"></asp:Label>
                                    </td>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        height="22">
                                        创建时间：
                                    </td>
                                    <td colspan="1" valign="bottom" height="22" style="background-color: #FFFFFF; padding: 2px;
                                        height: 25px;">
                                        <asp:Label ID="lblCreatedDate" runat="server" CssClass="date" MaxLength="10" Width="150px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF;" valign="bottom"
                                        width="150px">
                                        &nbsp;
                                    </td>
                                    <td colspan="3" height="22" valign="bottom" style="background-color: #FFFFFF; padding: 2px;
                                        height: 25px">
                                        <asp:Button ID="btnSave" runat="server" Text="保存信息" CssClass="buttonDefault" OnClientClick="javascript:return ValidateForm();"
                                            OnClick="btnSave_Click" />
                                        <asp:Button ID="btnDelete" runat="server" Text="我要退房" CssClass="buttonDefault" Visible="false"
                                            OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('您确定要退租吗？');" />
                                        <input onclick="javascript:CloseWindow();" type="button" value="关闭窗口" class="buttonDefault" />
                                        <div style="display: none;">
                                            <asp:TextBox ID="txtLinker" runat="server" CssClass="txt" MaxLength="10" Width="50px"></asp:TextBox></div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

