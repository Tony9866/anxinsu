<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="InfoRegister_CarveEmployeeDetail, App_Web_5mmmekmn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
    function SaveDialog() {
        var manager = $.ligerDialog.alert('从业人员信息保存成功！', '提示', 'success', function (item, Dialog, index) {
            window.close();
            window.opener.f_reload();
        });
    }


    function ReadCard() {
        var name = document.getElementById("<%=txtName.ClientID %>");
        var id = document.getElementById("<%=txtIDCard.ClientID %>");
        ReadIDCard(name, id);
    }

    function ValidateForm() {

        var corp = document.getElementById("<%=txtName.ClientID %>");
        if (corp.value == '') {
            $.ligerDialog.error('请先填写人员姓名！');
            return false;
        }

        var idcard = document.getElementById("<%=txtIDCard.ClientID %>");
        if (idcard.value == '') {
            $.ligerDialog.error('请先填写人员身份证号！');
            return false;
        }

        var linkway = document.getElementById("<%=txtPhone.ClientID %>");
        if (linkway.value == '') {
            $.ligerDialog.error('请先填写联系电话！');
            return false;
        }

        var taxNo = document.getElementById("<%=txtAddress.ClientID %>");
        if (taxNo.value == '') {
            $.ligerDialog.error('请先填写户籍地址！');
            return false;
        }

        var address = document.getElementById("<%=txtTempAddress.ClientID %>");
        if (address.value == '') {
            $.ligerDialog.error('请先填写居住地址！');
            return false;
        }

 
            var returnValue = getIdCardInfo(idcard.value);
            if (!returnValue.isTrue) {
                $.ligerDialog.error('身份证号码不符合规范，请重新填写！');
                return false;
            }

        if (!isTelOrMobile(linkway.value)) {
            $.ligerDialog.error('取章人联系方式不符合规范，请重新填写！电话号码格式为11位手机号码或者格式为7或8位座机号码！');
            return false;
        }

    }
</script>
    <table border="0" cellpadding="1" cellspacing="1" width="580px" 
                            style="vertical-align:bottom; background-color: #cccccc; margin:5px;" 
                            >
        <tr id="trRegion" runat="server"  visible="false">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="120px" height="22" __designer:mapid="7">
                所属区域：</td>
            <td colspan="3" valign="bottom" 
                                        width="660px" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        >
                    <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr >
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="120px" height="22" __designer:mapid="7">
                所属企业：</td>
            <td colspan="3" valign="bottom" 
                                        width="660px" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="8">
                <asp:DropDownList 
                                    ID="ddlCarve" runat="server" 
                                onselectedindexchanged="ddlCarve_SelectedIndexChanged" 
                                AutoPostBack="True" DataTextField="cac_corp_name" 
                                    DataValueField="cac_corp_id">
                </asp:DropDownList>
                <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr __designer:mapid="18">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22" __designer:mapid="19">
                人员姓名：<span style="color: #FF0000" 
                                            __designer:mapid="28">*</span></td>
            <td width="200px" 
                                        valign="bottom" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="1a">
                <asp:TextBox ID="txtName" runat="server" CssClass="txt" 
                                            Width="160px" MaxLength="30"></asp:TextBox>
                <img title="点击读取身份信息！" style="cursor:pointer;" src="../lib/icons/32X32/my_account.gif" width="20" onclick="javascript:ReadCard();" align="bottom" runat="server" id="imgCard" __designer:mapid="2b"/></td>
            <td width="100px" valign="bottom" 
                            style="padding: 2px; height: 25px; background-color: #FFFFFF" __designer:mapid="1c">
                性别：</td>
            <td width="200px" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="1d">
                <asp:RadioButtonList ID="rblGender" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                    <asp:ListItem Value="0">女</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr __designer:mapid="1f">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22" __designer:mapid="20">
                身份证号：<span style="color: #FF0000" 
                                            __designer:mapid="28">*</span></td>
            <td width="200px" 
                                        valign="bottom" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="21">
                <asp:TextBox ID="txtIDCard" runat="server" CssClass="txt" 
                                            Width="100%" MaxLength="18"></asp:TextBox>
            </td>
            <td width="120px" valign="bottom" 
                            style="padding: 2px; height: 25px; background-color: #FFFFFF" __designer:mapid="23">
                职务：</td>
            <td width="200px" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="24">
                    <asp:DropDownList ID="ddlPosition" runat="server" 
                onselectedindexchanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr __designer:mapid="26">
            <td style="padding: 2px; height: 22px; background-color: #FFFFFF" valign="middle" 
                                        width="100px" __designer:mapid="27">
                国籍：</td>
            <td valign="middle" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 22px" 
                                        __designer:mapid="29">
                    <asp:DropDownList ID="ddlNational" runat="server" 
                onselectedindexchanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td style="padding: 2px; background-color: #FFFFFF" valign="bottom" 
                                        width="100px" __designer:mapid="2c">
                联系电话：<span style="color: #FF0000" 
                                            __designer:mapid="28">*</span></td>
            <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; " __designer:mapid="2e">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" 
                                            Width="160px" MaxLength="30"></asp:TextBox>
                </td>
        </tr>
        <tr id="trOrg" runat="server" visible="true" __designer:mapid="46">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="170px" height="22" __designer:mapid="47">
                <asp:Label ID="Label1" runat="server" Text="户籍地址："></asp:Label>
                <span style="color: #FF0000" __designer:mapid="4d">*</span></td>
            <td valign="bottom" height="22" 
                                        colspan="3" style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="49">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" MaxLength="160" 
                                            Width="95%"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="4b">
            <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF" 
                                        valign="bottom" width="100px" __designer:mapid="4c">
                                        居住地址：<span style="color: #FF0000" __designer:mapid="4d">*</span></td>
            <td colspan="3" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        valign="bottom" __designer:mapid="4e">
                <asp:TextBox ID="txtTempAddress" runat="server" CssClass="txt" MaxLength="20" 
                                            Width="95%"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="50">
            <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22" __designer:mapid="51">
                联系人：</td>
            <td valign="bottom" 
                                        height="22" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="52">
                <asp:TextBox ID="txtLink" runat="server" CssClass="txt" Width="190px"></asp:TextBox>
            </td>
            <td style="padding: 2px; height:25px; background-color:#FFFFFF;" 
                                        valign="bottom" id="tdAreaTitle" runat="server"
                                        width="100px" __designer:mapid="54">
                                        联系人电话：</td>
            <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="55">
                <asp:TextBox ID="txtLinkWay" runat="server" CssClass="txt" 
                                            Width="160px" MaxLength="30"></asp:TextBox>
            </td>
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
            <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="100px" __designer:mapid="5c">
                                        &nbsp;</td>
            <td colspan="3" height="22" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        __designer:mapid="5d">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" 
                                            Text="保存信息" CssClass="buttonDefault" 
                                            
                    OnClientClick="javascript:return ValidateForm();" />
                &nbsp;<input onclick="javascript:window.close();" type="button" 
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

