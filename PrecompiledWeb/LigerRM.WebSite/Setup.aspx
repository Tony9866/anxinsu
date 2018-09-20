<%@ page title="" language="C#" masterpagefile="~/MasterPage/Detail.master" autoeventwireup="true" inherits="Setup, App_Web_gl2v1pkx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnConn" runat="server">
                <table border="0" cellpadding="1" cellspacing="1" 
                    style="background-color:Gray;" width="800px">
                    <tr>
                        <td bgcolor="White" style="font-size:16px; height: 23px; ">
                            系统配置 - 数据库配置</td>
                    </tr>
                    <asp:DataList ID="dlConnSettings" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td bgcolor="White" style="padding-left:20px;">
                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("AppName") %>'></asp:Label>
                        
                                </td>
                                <td align="left" bgcolor="White" style="">
                                    <asp:TextBox ID="txtValue" runat="server" Text='<%# Eval("AppValue") %>' 
                                        Width="800px" Height="22"></asp:TextBox>
                                </td>
                                <td><asp:Button ID="btnConn" runat="server" Text="测试连接" OnClick="btnConn_Click" CssClass="buttonDefault" /></td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:DataList>
                    
                </table>
            </asp:Panel><asp:Panel ID="pnApp" runat="server" Visible="false">
                        <table border="0" cellpadding="1" cellspacing="1" 
                            style="background-color:Gray;" width="800px">
                            <tr>
                                <td bgcolor="White" style="font-size:16px; height: 23px; ">
                                    系统配置 - 系统参数配置</td>
                            </tr>
                            <asp:DataList ID="dlAppSettings" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td bgcolor="White" style="padding-left:20px;">
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("AppName") %>'></asp:Label>
                                        </td>
                                        <td align="left" bgcolor="White" style="">
                                            <asp:TextBox ID="txtValue" runat="server" Text='<%# Eval("AppValue") %>' 
                                                Width="400px" Height="22"></asp:TextBox>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:DataList>
                        </table>
                    </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
<table border="0" cellpadding="1" cellspacing="1" width="800px" style="background-color:Gray;">
            <tr><td bgcolor="White"  align="left" style="padding-left:20px;">
            <asp:Button ID="btnPrevious" runat="server" CssClass="buttonDefault" Text="上一步" onclick="btnPrevious_Click" 
                Visible="false"  />&nbsp;&nbsp;
            <asp:Button ID="btnNext" runat="server" CssClass="buttonDefault" Text="下一步" 
                onclick="btnNext_Click" />
            </td></tr>
        </table>
</asp:Content>


