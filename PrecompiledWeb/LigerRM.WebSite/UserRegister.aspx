<%@ page language="C#" autoeventwireup="true" inherits="UserRegister, App_Web_4wfgth4k" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../lib/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/dialog.css" rel="stylesheet" type="text/css" />
    <script src="../lib/ligerUI/js/core/base.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <script src="lib/js/common.js" type="text/javascript"></script>
    <script src="lib/js/LG.js" type="text/javascript"></script>
    <script src="lib/CheckCode.js" type="text/javascript"></script>
    <script src="../lib/layer/layer.js" type="text/javascript"></script>
    <style type="text/css">
        *
        {
            padding: 0;
            margin: 0 0 18 0;
        }
        body
        {
            text-align: center;
            background: #4974A4;
        }
        #login
        {
            width: 740px;
            margin: 0 auto;
            font-size: 12px;
        }
        #loginlogo
        {
            width: 700px;
            height: 100px;
            overflow: hidden;
            background: url('images/JH.png') no-repeat;
            margin-top: 50px;
        }
        #loginpanel
        {
            width: 729px;
            position: relative;
            height: 468px;
            top: 0px;
            left: 0px;
        }
        .panel-h
        {
            width: 729px;
            height: 20px;
            background: url('lib/images/login/panel-h.gif') no-repeat;
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 3;
        }
        .panel-f
        {
            width: 729px;
            height: 13px;
            background: url('lib/images/login/panel-f.gif') no-repeat;
            position: absolute;
            bottom: 0px;
            left: 0px;
            z-index: 3;
        }
        .panel-c
        {
            z-index: 2;
            background: url('lib/images/login/panel-c.gif') repeat-y;
            width: 729px;
            height: 460px;
        }
        .panel-c-l
        {
            position: absolute;
            left: 60px;
            top: 20px;
        }
        .panel-c-r
        {
            position: absolute;
            right: 20px;
            top: 50px;
            width: 222px;
            line-height: 200%;
            text-align: left;
        }
        .panel-c-l h3
        {
            color: #556A85;
            margin-bottom: 10px;
        }
        .panel-c-l td
        {
            padding: 7px;
        }
        
        
        .login-text
        {
            height: 24px;
            left: 24px;
            border: 1px solid #e9e9e9;
            background: #f9f9f9;
            width: 191px;
        }
        .login-text-focus
        {
            border: 1px solid #E6BF73;
        }
        .login-btn
        {
            width: 114px;
            height: 29px;
            line-height: 29px;
            background: url('lib/images/login/login-btn.gif') no-repeat;
            border: none;
            overflow: hidden;
            cursor: pointer;
        }
        #txtUsername, #txtPassword
        {
            width: 191px;
        }
        #logincopyright
        {
            text-align: center;
            color: White;
            margin-top: 50px;
        }
        .code
        {
            background-color: #eeeeee;
            font-family: Arial;
            font-style: italic;
            color: blue;
            font-size: 14px;
            border: 0;
            padding: 2px 2px;
            letter-spacing: 3px;
            font-weight: bolder;
            float: left;
            cursor: pointer;
            width: 50px;
            height: 22px;
            line-height: 22px;
            text-align: center;
            vertical-align: middle;
        }
        .style1
        {
            color: #FF0000;
        }
        .style2
        {
            height: 31px;
        }
        .style3
        {
            height: 17px;
        }
    </style>
    <script type="text/javascript">

        //iframe层 - 父子操作
        function agree() {
            layer.open({
                type: 2,
                title: '用户使用及服务协议',
                maxmin: true,
                shadeClose: true, //点击遮罩关闭层
                area: ['800px', '520px'],
                content: 'agreement.html'
            });

        };

        function ReadIDCard() {
            var iResut = 0;
            var strVal = "";
            iResut = IdCtrl.hxgc_OpenReader(1001);
            if (iResut != 0) {
                alert("二代证设备打开失败！");
            }
            else {
                iResut = IdCtrl.hxgc_ReadIDCard(1001);
                strVal = IdCtrl.hxgc_GetName();
                document.getElementById("<%=txtName.ClientID %>").value = strVal;
                strVal = IdCtrl.hxgc_GetIDCode();
                document.getElementById("<%=txtIdCard.ClientID %>").value = strVal;
                iResut = IdCtrl.hxgc_CloseReader(1001);
            }
        }




        function dologin() {
            var username = document.getElementById("<%=txtUserId.ClientID %>").value;
            var password = document.getElementById("<%=txtPassword.ClientID %>").value;
            var confirm = document.getElementById("<%=txtConfirmPass.ClientID %>").value;
            var name = document.getElementById("<%=txtName.ClientID %>").value;
            var idcard = document.getElementById("<%=txtIdCard.ClientID %>").value;
            var phone = document.getElementById("<%=txtPhone.ClientID %>").value;
            //            var check = document.getElementById("<%=checkbox.ClientID %>").checked;
            if (username == "") {
                $.ligerDialog.warn('账号不能为空!');
                return false;
            }
            if (password == "") {
                $.ligerDialog.warn('密码不能为空!');
                return false;
            }
            if (confirm == "") {
                $.ligerDialog.warn('请确认密码!');
                return false;
            }

            if (password != confirm) {
                $.ligerDialog.error('两次密码输入不一致!');
                return false;
            }

            if (name == "") {
                $.ligerDialog.warn('请输入真是姓名!');
                return false;
            }
            if (idcard == "") {
                $.ligerDialog.warn('请输入身份证号码!');
                return false;
            }
            if (phone == "") {
                $.ligerDialog.warn('请输入电话号码!');
                return false;
            }

            //            if (check == false) {
            //                $.ligerDialog.warn('请阅读相关服务协议并勾选')
            //                return false;
            //            }

            return true;
        }

    </script>
</head>
<body style="padding: 10px" onload="javascript:createCode(4);">
    <div style="display: none;">
        <object id="IdCtrl" classid="clsid:A66F5373-0A8A-4C42-814B-38A87B331D40">
        </object>
    </div>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="login">
        <div id="" style="display: block; margin-top: 70px; height: 70px; color: White; font-size: 24px;
            line-height: 70px; vertical-align: middle;" align="left">
            <img src="Images/JH.png" width="70" align="middle" />戈德泰视出租屋（日租房）管理信息系统 V1.0</div>
        <div id="loginpanel">
            <div class="panel-h">
            </div>
            <div class="panel-c">
                <div class="panel-c-l">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <h3>
                                                用户注册</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            登录账号：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUserId" runat="server" CssClass="login-text" MaxLength="16" Enabled="False"></asp:TextBox>
                                            <span class="style1">&nbsp;*</span>&nbsp;<asp:CheckBox ID="chkPhone" runat="server"
                                                Text="使用电话号码" AutoPostBack="True" Checked="True" OnCheckedChanged="chkPhone_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            登录密码：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="login-text" MaxLength="16"
                                                TextMode="Password"></asp:TextBox>
                                            <span class="style1">&nbsp;*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            确认密码:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtConfirmPass" runat="server" CssClass="login-text" MaxLength="16"
                                                TextMode="Password"></asp:TextBox>
                                            <span class="style1">&nbsp;*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            姓名：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="login-text" MaxLength="18"></asp:TextBox>
                                            <span class="style1">
                                                <img title="点击读取身份信息！" style="cursor: pointer;" src="lib/icons/32X32/my_account.gif"
                                                    width="20" onclick="javascript:ReadIDCard();" align="bottom" runat="server" id="imgCard" />
                                                &nbsp;*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            身份证号码：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtIdCard" runat="server" CssClass="login-text" MaxLength="18"></asp:TextBox>
                                            <span class="style1">&nbsp;*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            电话号码：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="login-text" MaxLength="18" AutoPostBack="True"
                                                OnTextChanged="txtPhone_TextChanged"></asp:TextBox>
                                            <span class="style1">&nbsp;*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style2">
                                            性别：
                                        </td>
                                        <td align="left" class="style2">
                                            <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="male">男</asp:ListItem>
                                                <asp:ListItem Value="female">女</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:CheckBox ID="checkbox" Checked="True" runat="server" AutoPostBack="True" OnCheckedChanged="checkbox_CheckedChanged" />
                                        </td>
                                        <td align="left">
                                            <a href="#" onclick="agree()">请仔细阅读并接受此服务协议</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnRegister" runat="server" CssClass="login-btn" Text="注&nbsp;&nbsp;&nbsp;&nbsp;册"
                                                OnClientClick="return dologin();" OnClick="btnRegister_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="panel-c-r">
                    <p>
                        请在左侧输入用户注册信息，为避免影响</p>
                    <p>
                        功能的使用，请填写真实信息。</p>
                    <p>
                        如果有问题，请联系网站管理员。
                    </p>
                </div>
            </div>
            <div class="panel-f">
            </div>
        </div>
        <div id="logincopyright">
            版权所有© 兴唐通信科技有限公司 | 地址：北京市海淀区学院路40号 邮编：300000</br>Copyright © XingTang Co.,LTD. All
            Rights Reserved.</div>
    </div>
    </form>
</body>
</html>
