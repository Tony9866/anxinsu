<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage/Detail.master" inherits="InfoRegister_CorporationDetail, App_Web_5mmmekmn" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function ValidateForm() {

        var corp = document.getElementById("<%=txtCorpname.ClientID %>");
        if (corp.value == '') {
            $.ligerDialog.error('请先填写使用单位名称！');
            return false;
        }
        var boss = document.getElementById("<%=txtBoss.ClientID %>");
        if (boss.value == '') {
            $.ligerDialog.error('请先填写企业法人！');
            return false;
        }

        var idcard = document.getElementById("<%=txtIDCard.ClientID %>");
        if (idcard.value == '') {
            $.ligerDialog.error('请先填写企业法人身份证号！');
            return false;
        }

//        var linker = document.getElementById("<%=txtLinker.ClientID %>");
//        if (linker.value == '') {
//            $.ligerDialog.error('请先填写企业联系人！');
//            return false;
//        }
  
        var linkway = document.getElementById("<%=txtLinkWay.ClientID %>");
        if (linkway.value == '') {
            $.ligerDialog.error('请先填写法人电话！');
            return false;
        }

        var taxNo = document.getElementById("<%=txtTaxNo.ClientID %>");
        if (taxNo.value == '') {
            $.ligerDialog.error('请先填写企业证件号码！');
            return false;
        }

        var address = document.getElementById("<%=txtAddress.ClientID %>");
        if (address.value == '') {
            $.ligerDialog.error('请先填写企业地址！');
            return false;
        }

//        var area = document.getElementById("<%=ddlArea.ClientID %>");
//        if (area.value == '') {
//            $.ligerDialog.error('请先维护所属区域信息！');
//            return false;
//        }

        var chk = document.getElementById("<%=chkForeign.ClientID %>");
        if (!chk.checked) {
            var returnValue = getIdCardInfo(idcard.value);
            if (!returnValue.isTrue) {
                $.ligerDialog.error('法人身份证号码不符合规范，请重新填写！');
                return false;
            } 
        }

        if (!isTelOrMobile(linkway.value)) {
            $.ligerDialog.error('取章人联系方式不符合规范，请重新填写！电话号码格式为11位手机号码或者格式为7或8位座机号码！');
            return false;
        }

    }

    function ReadCard() {
        var name = document.getElementById("<%=txtBoss.ClientID %>");
        var id = document.getElementById("<%=txtIDCard.ClientID %>");
        ReadIDCard(name, id);
    }

    function SubmitDialog() {
        var manager = $.ligerDialog.alert('企业信息保存成功！', '提示', 'success', function (item, Dialog, index) {
            window.close();
            window.opener.f_reload();
        });

    }

    function AddSignetDialog(corpId) {
        //var corp = document.getElementById("<%=lblCorpId.ClientID %>").innerText;
        //alert(corpId);
        var manager = $.ligerDialog.alert('企业信息保存成功！', '提示', 'success', function (item, Dialog, index) {

            var num = Math.floor(Math.random() * (1000 + 1));
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: corpId },
                success: function (data) {
                    window.opener.top.f_addTab(null, '添加印章信息', '../InfoRegister/SignetRegisterStep2.aspx?corpId=' + data + '&num=' + num + "&register=" + corpId.substring(0, 6));
                    window.close();
                },
                error: function (message) {
                }
            });

        });
    }
</script>
<div style="text-align:center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="600px">
            <tr>
                <td align="left">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" />
                            <table border="0" cellpadding="1" cellspacing="1" width="580" 
                            style="vertical-align:bottom; background-color: #cccccc; margin:5px;"><tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="120px" height="22">企业编号：</td><td colspan="3" valign="bottom" 
                                        width="660px" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px"><asp:DropDownList 
                                    ID="ddlRegion" runat="server" 
                                onselectedindexchanged="ddlRegion_SelectedIndexChanged" 
                                AutoPostBack="True" DataTextField="rd_reg_dept_name" 
                                    DataValueField="rd_reg_dept_id"></asp:DropDownList><asp:Label ID="lblCorpId" runat="server"></asp:Label></td></tr><tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22">单位名称：<span style="color: #FF0000">*</span></td><td width="600px" valign="bottom" colspan="3" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtCorpname" runat="server" CssClass="txt" MaxLength="120" 
                                Width="100%"></asp:TextBox></td></tr><tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                            width="100px" height="22">民族文字：</td><td valign="bottom" width="200px" colspan="3" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtAliasName" runat="server" CssClass="txt" MaxLength="120" 
                                Width="100%"></asp:TextBox></td></tr><tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22">英文名称：</td><td colspan="3" valign="bottom" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtEnglishName" runat="server" CssClass="txt" Width="100%" 
                                MaxLength="200"></asp:TextBox></td></tr><tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22">单位分类：</td><td width="200px" valign="bottom" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px"><asp:DropDownList ID="ddlType" runat="server" DataTextField="cc_description" 
                                DataValueField="cc_corp_class"></asp:DropDownList></td>
                                    <td width="100px" valign="bottom" 
                            style="padding: 2px; height: 25px; background-color: #FFFFFF">单位类型：</td>
                                    <td width="200px" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px"><asp:DropDownList ID="ddlCategory" runat="server" DataTextField="gc_name" 
                                DataValueField="gc_id"></asp:DropDownList></td></tr><tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22">查询码：</td><td width="200px" valign="bottom" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="lblQueryCode" runat="server" CssClass="txt" Enabled="False" 
                                            Width="190px"></asp:TextBox></td>
                                    <td width="120px" valign="bottom" 
                            style="padding: 2px; height: 25px; background-color: #FFFFFF">用户码：</td>
                                    <td width="200px" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="lblUserCode" runat="server" CssClass="txt" Enabled="False" 
                                            Width="100%"></asp:TextBox></td></tr><tr>
                                    <td style="padding: 2px; height: 22px; background-color: #FFFFFF" valign="middle" 
                                        width="100px">企业法人：<span style="color: #FF0000">*</span></td>
                                    <td valign="middle" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 22px">
                                        <asp:TextBox ID="txtBoss" runat="server" CssClass="txt" 
                                            Width="160px" MaxLength="30"></asp:TextBox>&nbsp;<img title="点击读取身份信息！" style="cursor:pointer;" src="../lib/icons/32X32/my_account.gif" width="20" onclick="javascript:ReadCard();" align="bottom" runat="server" id="imgCard"/></td>
                                    <td style="padding: 2px; background-color: #FFFFFF" valign="bottom" 
                                        width="100px">身份证号：<span style="color: #FF0000">*</span></td>
                                    <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; ">
                                        <asp:TextBox ID="txtIDCard" runat="server" CssClass="txt" 
                                            Width="100%" MaxLength="18"></asp:TextBox></td></tr>
                                <tr>
                                    <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF" 
                                        valign="bottom" width="100px">
                                        法人电话：<span style="color: #FF0000">*</span></td>
                                    <td height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px" 
                                        valign="bottom" width="200px">
                                        <asp:TextBox ID="txtLinkWay" runat="server" CssClass="txt" MaxLength="20" 
                                            Width="100%"></asp:TextBox>
                                    </td>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 300px;" 
                                        valign="bottom" width="100px" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="chkForeign" runat="server" Text="非身份证" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="200px" 
                            valign="bottom" height="22"><asp:Label ID="Label2" runat="server" Text="企业证件类型：" 
                                            Width="88px"></asp:Label>
                                    </td><td valign="bottom" height="22" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:DropDownList ID="ddlCerType" runat="server">
                                            <asp:ListItem Value="01">营业执照号</asp:ListItem>
                                            <asp:ListItem Value="02">企业税号</asp:ListItem>
                                            <asp:ListItem Value="03">机构代码号</asp:ListItem>
                                            <asp:ListItem Value="04">联审统一编号</asp:ListItem>
                                            <asp:ListItem Value="06">统一社会信用代码</asp:ListItem>
                                            <asp:ListItem Value="05">其他批文文号</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="100px">
                                        证件号：<span style="color: #FF0000">*</span></td>
                                    <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtTaxNo" runat="server" CssClass="txt" MaxLength="20" 
                                            Width="100%"></asp:TextBox>
                                    </td>
                                </tr><tr id="trOrg" runat="server" visible="false">
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="170px" height="22">
                                        <asp:Label ID="Label1" runat="server" Text="组织机构代码："></asp:Label>
                                    </td>
                                    <td valign="bottom" height="22" 
                                        colspan="3" style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtOrgnization" runat="server" CssClass="txt" MaxLength="20" 
                                            Width="100%"></asp:TextBox>
                                    </td></tr>
                                <tr>
                                    <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF" 
                                        valign="bottom" width="100px">
                                        单位地址：<span style="color: #FF0000">*</span></td>
                                    <td colspan="3" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px" valign="bottom">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" MaxLength="160" 
                                            Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" width="100px" 
                            valign="bottom" height="22">邮政编码：</td><td valign="bottom" height="22" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtPostCode" runat="server" CssClass="txt" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 2px; height:25px; background-color:#FFFFFF;" valign="bottom" id="tdAreaTitle" runat="server"
                                        width="100px">
                                        所属区域：</td>
                                    <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:DropDownList ID="ddlArea" runat="server" DataTextField="ar_area_name" 
                                            DataValueField="ar_area_id">
                                        </asp:DropDownList>
                                    </td>
                                </tr><tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="middle" 
                                        width="100px" height="22" align="left">备注：</td><td valign="bottom" colspan="3" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtMemo" runat="server" Height="46px" MaxLength="100" 
                                            TextMode="MultiLine" Width="100%"></asp:TextBox>
                                    </td></tr>
                                <tr>
                                    <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF" valign="bottom" 
                                        width="100px">
                                        &nbsp;</td>
                                    <td colspan="3" height="22" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" 
                                            Text="保存信息" CssClass="buttonDefault" OnClientClick="javascript:return ValidateForm();" />&nbsp;<asp:Button
                                                ID="btnSignet" runat="server" Text="保存并添加印章" CssClass="buttonDefault" 
                                            Width="100px" onclick="btnSignet_Click" />
                                        <input onclick="javascript:window.close();" type="button" 
                                            value="关闭窗口" class="buttonDefault" />
                                        <div style="display:none;"><asp:TextBox ID="txtLinker" runat="server" CssClass="txt" MaxLength="10" 
                                            Width="50px"></asp:TextBox></div>
                                    </td>
                                </tr>
                                </table>
                        </cc1:TabContainer>
                               
                </td>
                </tr>
            </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>