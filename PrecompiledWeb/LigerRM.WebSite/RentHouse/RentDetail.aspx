<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage/Detail.master" inherits="RentHouse_RentDetail, App_Web_h3mtpn1q" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
    <script type="text/javascript">
    function ValidateForm() {

        var district = document.getElementById("<%=ddlDistrict.ClientID %>");
        if (district.value == '0') {
            $.ligerDialog.error('请选择区域名称！');
            return false;
        }

        var street = document.getElementById("<%=ddlStreet.ClientID %>");
        if (street.value == '0') {
            $.ligerDialog.error('请选择街道名称！');
            return false;
        }

        var road = document.getElementById("<%=ddlRoad.ClientID %>");
        if (road.value == '0') {
            $.ligerDialog.error('请选择社区名称！');
            return false;
        }

        var address = document.getElementById("<%=txtAddress.ClientID %>");
        if (address.value == '') {
            $.ligerDialog.error('请输入具体地址！');
            return false;
        }

        var lan = document.getElementById("<%=txtLangitude.ClientID %>").value;
        var lat = document.getElementById("<%=txtLatitude.ClientID %>").value;
        if (!lan || !lat) {
            alert('请先获取经纬度!');
            return false;
        }

        var door = document.getElementById("<%=txtDoor.ClientID %>");
        if (door.value == '') {
            $.ligerDialog.error('请输入门牌号！');
            return false;
        }

        var totalDoor = document.getElementById("<%=txtTotalDoor.ClientID %>");
        if (isNaN(totalDoor.value)) {
            $.ligerDialog.error('总共几户楼层请输入数字！');
            return false;
        }

        var policeStationParent = document.getElementById("<%=ddlPoliceStationParent.ClientID %>");
        if (policeStationParent.value == '0') {
            $.ligerDialog.error('请选择警局！');
            return false;
        }
          var policeStation = document.getElementById("<%=ddlPoliceStation.ClientID %>");
        if (policeStation.value == '0') {
            $.ligerDialog.error('请选择派出所！');
            return false;
        }

        var floor = document.getElementById("<%=txtFloor.ClientID %>");
        if (floor.value == '') {
            $.ligerDialog.error('请输入楼层！');
            return false;
        }
        if (isNaN(floor.value)) {
            $.ligerDialog.error('楼层请输入数字！');
            return false;
        }

        var totalFloor = document.getElementById("<%=txtTotalFloor.ClientID %>");
        if (isNaN(totalFloor.value)) {
            $.ligerDialog.error('总共楼层请输入数字！');
            return false;
        }

        var houseAge = document.getElementById("<%=txtHouseAge.ClientID %>");
        if (houseAge.value == '') {
            $.ligerDialog.error('请输入房龄！');
            return false;
        }
        if (isNaN(houseAge.value)) {
            $.ligerDialog.error('房龄请输入数字！');
            return false;
        }

        var buildRentArea = document.getElementById("<%=txtBuildRentArea.ClientID %>");
        if (buildRentArea.value == '') {
            $.ligerDialog.error('请输入房屋面积！');
            return false;
        }

        if (!isNumeric(buildRentArea.value)) {
            $.ligerDialog.error('房屋面积请输入数字！');
            return false;
        }

        //if (isNaN(buildRentArea.value)) {
        //    $.ligerDialog.error('房屋面积请输入数字！');
        //    return false;
        //}

        var owner = document.getElementById("<%=txtOwner.ClientID %>");
        if (owner.value == '') {
            $.ligerDialog.error('请输入房主姓名！');
            return false;
        }

         var idCard = document.getElementById("<%=txtIDCard.ClientID %>");
        if (idCard.value == '') {
            $.ligerDialog.error('请输入房主身份证号！');
            return false;
        }

        var ownerTel = document.getElementById("<%=txtOwnerTel.ClientID %>");
        if (ownerTel.value == '') {
            $.ligerDialog.error('请输入房主电话号码！');
            return false;
        }

        var chk = document.getElementById("<%=chkForeign.ClientID %>");
        if (!chk.checked) {
            var returnValue = getIdCardInfo(idCard.value);
            if (!returnValue.isTrue) {
                $.ligerDialog.error('房主身份证号码不符合规范，请重新填写！');
                return false;
            } 
        }
    }

    function isNumeric(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    function ReadCard() {
        var name = document.getElementById("<%=txtOwner.ClientID %>");
        var id = document.getElementById("<%=txtIDCard.ClientID %>");
        ReadIDCard(name, id);
    }

    function SubmitDialog() {
        var manager = $.ligerDialog.alert('房源信息保存成功！', '提示', 'success', function (item, Dialog, index) {
            window.close();
            window.opener.f_reload();
        });
    }

    function AddSignetDialog(RentNo) {

        var manager = $.ligerDialog.alert('房源信息保存成功！', '提示', 'success', function (item, Dialog, index) {

            //var num = Math.floor(Math.random() * (1000 + 1));
            //LG.ajax({
            //    type: 'AjaxPage',
            //    method: 'GetEncryptString',
            //    loading: '正在获取中...',
            //    data: { sourceStr: RentNo },
            //    success: function (data) {
            //        window.opener.top.f_addTab(null, '添加租赁信息', '../RentHouse/RentAttribute.aspx?RentNo=' + data);
            //        window.close();
            //    },
            //    error: function (message) {
            //    }
            //});

        });
    }
</script>
<div style="text-align:center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="700px">
            <tr>
                <td align="left">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" />
                            <table border="0" cellpadding="1" cellspacing="1" width="695" 
                            style="vertical-align:bottom; background-color: #cccccc; margin:5px;">
                                  <tr runat="server" id="trRentNo">
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" valign="bottom">房源编号：
                                    </td>
                                    <td width="600px" valign="bottom" colspan="3" 
                                          style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 261px;">
                                        <asp:Label ID="lblRentNo" runat="server" MaxLength="50" Width="150"></asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false"><td></td><td  colspan="3">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" 
                                        Height="20px" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" 
                                        Width="180px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="RentDistrict" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" 
                                        SelectCommand="up_Rent_DistrictSelectAll" SelectCommandType="StoredProcedure">
                                    </asp:SqlDataSource>
                                    <asp:DropDownList ID="ddlStreet" runat="server" AutoPostBack="True" 
                                        Height="20px" OnSelectedIndexChanged="ddlStreet_SelectedIndexChanged" 
                                        Width="180px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="RentStreet" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" 
                                        SelectCommand="up_Rent_StreetSelectByLDID" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlDistrict" DefaultValue="0" Name="ldID" 
                                                PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="RentRoad" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" 
                                        SelectCommand="up_Rent_RoadSelectByLDIDLSID" 
                                        SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlPoliceStation" DefaultValue="120020437" 
                                                Name="ldID" PropertyName="SelectedValue" Type="String" />
                                            <asp:ControlParameter ControlID="ddlStreet" DefaultValue="0" Name="lsID" 
                                                PropertyName="SelectedValue" Type="Int32" />
                                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="PoliceStationParent" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" 
                                        SelectCommand="up_Rent_PoliceStationSelectParent" 
                                        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    <asp:SqlDataSource ID="PoliceStation" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" 
                                        SelectCommand="up_Rent_PoliceStationSelectByParentID" 
                                        SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlPoliceStationParent" DefaultValue="0" 
                                                Name="psParentID" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    </td></tr>
                                <tr runat="server" id="trRegion" visible="true">
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" valign="bottom" height="22">区域名称：<span style="color: #FF0000">*</span></td>
                                     <td colspan="3" valign="bottom"  width="660px" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 504px;">
                                          
                                          <asp:DropDownList ID="ddlPoliceStationParent" runat="server" 
                                              AutoPostBack="True" 
                                              OnSelectedIndexChanged="ddlPoliceStationParent_SelectedIndexChanged" 
                                              Width="180px">
                                          </asp:DropDownList>
                                          <asp:DropDownList ID="ddlPoliceStation" runat="server" AutoPostBack="True" 
                                              onselectedindexchanged="ddlPoliceStation_SelectedIndexChanged" Width="180px">
                                          </asp:DropDownList>
                                          
                                          <asp:DropDownList ID="ddlRoad" runat="server" 
                                                AutoPostBack="True"  Height="20px" Width="180px" 
                                              onselectedindexchanged="ddlRoad_SelectedIndexChanged"></asp:DropDownList>
                                            
                                     </td>
                                  </tr>
                                <tr>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" 
                            valign="bottom" height="22">具体地址：<span style="color: #FF0000">*</span>
                                    </td>
                                    <td valign="bottom" colspan="3" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 509px;">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" MaxLength="50" 
                                Width="492px"></asp:TextBox>&nbsp;<a href="#" onclick="javascript:showPosition();">地图位置</a>
                                    </td>
                                    
                                </tr>
                                 <tr>
                                     <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 480px;" 
                                    valign="bottom" height="22">所处经度：<span style="color: #FF0000">*</span>
                                    </td>
                                    <td width="600px" valign="bottom" colspan="1" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtLangitude" runat="server" CssClass="txt" MaxLength="50" 
                                            Width="175px"></asp:TextBox>
                                        <img src="../lib/icons/32X32/world.gif" width="20" onclick="javascript:searchByStationName();"/>
                                    </td>
                                    <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" valign="bottom" height="22">
                                        所处纬度：<span style="color: #FF0000">*</span> </td>
                                    <td valign="bottom" colspan="1" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 480px;">
                                        <asp:TextBox ID="txtLatitude" runat="server" CssClass="txt" MaxLength="50" 
                                            Width="175px"></asp:TextBox>
                                        <img src="../lib/icons/32X32/world.gif" width="20" 
                                            onclick="javascript:searchByStationName();"/>
                                     </td>
                                  </tr>
                                  <tr>
                                      <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 480px;" 
                                          valign="bottom">
                                          房屋价格：<span style="color: #FF0000">*</span>
                                      </td>
                                      <td colspan="1" height="22" 
                                          style="background-color: #FFFFFF; padding: 2px; height: 25px" valign="bottom" 
                                          width="600px">
                                          <asp:TextBox ID="txtFee" runat="server" CssClass="txt" MaxLength="50" 
                                              Width="195px"></asp:TextBox>
                                      </td>
                                      <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" 
                                          valign="bottom">
                                          手续费率：</td>
                                      <td colspan="1" height="22" 
                                          style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 480px;" 
                                          valign="bottom">
                                          0.00%</td>
                                  </tr>
                                  <tr>
                                      <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 480px;" 
                                          valign="bottom">
                                          门牌号码：<span style="color: #FF0000">*</span>
                                      </td>
                                      <td colspan="1" height="22" 
                                          style="background-color: #FFFFFF; padding: 2px; height: 25px" valign="bottom" 
                                          width="600px">
                                          <asp:TextBox ID="txtDoor" runat="server" CssClass="txt" MaxLength="50" 
                                              Width="195px"></asp:TextBox>
                                      </td>
                                      <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" 
                                          valign="bottom">
                                          总共几户：</td>
                                      <td colspan="1" height="22" 
                                          style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 480px;" 
                                          valign="bottom">
                                          <asp:TextBox ID="txtTotalDoor" runat="server" CssClass="txt" MaxLength="3" 
                                              Width="195px"></asp:TextBox>
                                      </td>
                                  </tr>
                                     <tr>
                                     <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 480px;" valign="bottom" height="22">
                                         房屋类型：</td>
                                    <td valign="bottom" width="150px" colspan="1" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:DropDownList ID="ddlRoomType" runat="server" 
                                                AutoPostBack="false" Width="200px">
                                  
                                        </asp:DropDownList>
                                       <asp:SqlDataSource ID="RentRoomType" runat="server" ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>"
                                            SelectCommand="up_Rent_RentSystemOptionSelectByParentID" SelectCommandType="StoredProcedure">
                                             <SelectParameters>
                                                 <asp:ControlParameter ControlID="lblRoomType" DefaultValue="0" Name="rsParentNo" PropertyName="Text" Type="Int32" />
                                             </SelectParameters>
                                         </asp:SqlDataSource>
                                        <asp:Label ID="lblRoomType" runat="server" Visible="false">0</asp:Label>
                                    </td>
                                          <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" valign="bottom" height="22">
                                              房屋朝向：</td>
                                    <td valign="bottom" colspan="1" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 509px;">
                                        <asp:DropDownList ID="ddlDirection" runat="server" 
                                                AutoPostBack="false" Width="200px"  ></asp:DropDownList>
                                        <asp:SqlDataSource ID="RentDirection" runat="server" ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" SelectCommand="up_Rent_RentSystemOptionSelectByParentID" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblDirection" DefaultValue="0" Name="rsParentNo" PropertyName="Text" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:Label ID="lblDirection" runat="server" Visible="false">0</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    
                                     <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 480px;" valign="bottom" height="22">
                                         房屋结构：</td>
                                    <td valign="bottom" width="200px" colspan="1" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                         <asp:DropDownList ID="ddlStructure" runat="server" 
                                                AutoPostBack="false" Width="200px"  ></asp:DropDownList>
                                         <asp:SqlDataSource ID="RentStructure" runat="server" ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" SelectCommand="up_Rent_RentSystemOptionSelectByParentID" SelectCommandType="StoredProcedure">
                                             <SelectParameters>
                                                 <asp:ControlParameter ControlID="lblStructure" DefaultValue="0" Name="rsParentNo" PropertyName="Text" Type="Int32" />
                                             </SelectParameters>
                                         </asp:SqlDataSource>
                                        <asp:Label ID="lblStructure" runat="server" Visible="false">0</asp:Label>
                                    </td>
                                     <td style="padding: 2px; height: 25px; background-color: #FFFFFF; " 
                                         valign="bottom" height="22">建筑类型：</td>
                                    <td valign="bottom" colspan="1" 
                                        height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 509px;">
                                        <asp:DropDownList ID="ddlBuildingType" runat="server" 
                                                AutoPostBack="false" Width="200px" ></asp:DropDownList>
                                        <asp:SqlDataSource ID="RentBuildingType" runat="server" ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" SelectCommand="up_Rent_RentSystemOptionSelectByParentID" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblBuildingType" DefaultValue="0" Name="rsParentNo" PropertyName="Text" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:Label ID="lblBuildingType" runat="server" Visible="false">0</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    
                                     <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 480px;" valign="bottom" height="22">房屋性质：</td>
                                    <td valign="bottom" width="200px" 
                                        height="22" 
                                         style="background-color: #FFFFFF; padding: 2px; height: 25px;">
                                         <asp:DropDownList ID="ddlProperty" runat="server" 
                                                AutoPostBack="false" Width="200px"></asp:DropDownList>
                                         <asp:SqlDataSource ID="RentProperty" runat="server" ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" SelectCommand="up_Rent_RentSystemOptionSelectByParentID" SelectCommandType="StoredProcedure">
                                             <SelectParameters>
                                                 <asp:ControlParameter ControlID="lblProperty" DefaultValue="0" Name="rsParentNo" PropertyName="Text" Type="Int32" />
                                             </SelectParameters>
                                         </asp:SqlDataSource>
                                        <asp:Label ID="lblProperty" runat="server" Visible="false">0</asp:Label>
                                    </td>
                                   
                                   
                                     <td height="22" 
                                         style="background-color: #FFFFFF; padding: 2px; height: 25px; " 
                                         valign="bottom">
                                         出租类型：</td>
                                     <td height="22" 
                                         style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 66px;" 
                                         valign="bottom" width="200px">
                                         <asp:DropDownList ID="ddlRentType" runat="server" AutoPostBack="false" 
                                             Width="200px" >
                                         </asp:DropDownList>
                                         <asp:SqlDataSource ID="RentType" runat="server" 
                                             ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" 
                                             SelectCommand="up_Rent_RentSystemOptionSelectByParentID" 
                                             SelectCommandType="StoredProcedure">
                                             <SelectParameters>
                                                 <asp:ControlParameter ControlID="lblRentType" DefaultValue="0" 
                                                     Name="rsParentNo" PropertyName="Text" Type="Int32" />
                                             </SelectParameters>
                                         </asp:SqlDataSource>
                                         <asp:Label ID="lblRentType" runat="server" Visible="False">0</asp:Label>
                                     </td>
                                   
                                   
                                </tr>
                                <tr>
                                     <td style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" 
                            valign="bottom" height="22">所属楼层：<span style="color: #FF0000">*</span></td>
                                    <td valign="bottom" height="22" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 509px;">
                                        <asp:TextBox ID="txtFloor" runat="server" CssClass="txt"  
                                            Width="195px" MaxLength="3"></asp:TextBox></td>
                                     <td valign="bottom" 
                            style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 480px;">总共楼层：</td>
                                    <td width="200px" valign="bottom" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 25px">
                                        <asp:TextBox ID="txtTotalFloor" runat="server" CssClass="txt"  
                                            Width="195px" MaxLength="3"></asp:TextBox></td>
                                </tr><tr>
                                    <td style="padding: 2px; height: 22px; background-color: #FFFFFF; width: 400px;" valign="middle">房龄：<span style="color: #FF0000">*</span></td>
                                    <td valign="middle" style="background-color: #FFFFFF; padding: 2px; height: 22px; width: 509px;">
                                        <asp:TextBox ID="txtHouseAge" runat="server" CssClass="txt" 
                                            Width="195px" MaxLength="3"></asp:TextBox>
                                    </td>
                                    <td style="padding: 2px; background-color: #FFFFFF; width: 480px;" valign="bottom">
                                        建筑面积：<span style="color: #FF0000">*</span></td>
                                    <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; ">
                                        <asp:TextBox ID="txtBuildRentArea" runat="server" CssClass="txt" 
                                            Width="195px" MaxLength="8"></asp:TextBox></td></tr>
                                <tr>
                                   <td style="padding: 2px; height: 22px; background-color: #FFFFFF; width: 400px;" valign="middle">房主姓名：<span style="color: #FF0000">*</span></td>
                                    <td valign="middle" 
                                        style="background-color: #FFFFFF; padding: 2px; height: 22px; width: 509px;">
                                        <asp:TextBox ID="txtOwner" runat="server" CssClass="txt" 
                                            Width="170px" MaxLength="50"></asp:TextBox>&nbsp;<img title="点击读取身份信息！" style="cursor:pointer;" src="../lib/icons/32X32/my_account.gif" width="20" onclick="javascript:ReadCard();" align="bottom" runat="server" id="imgCard"/></td>
                                    <td style="padding: 2px; background-color: #FFFFFF; width: 480px;" valign="bottom">身份证号：<span style="color: #FF0000">*</span></td>
                                    <td valign="bottom" width="200px" 
                                        style="background-color: #FFFFFF; padding: 2px; ">
                                        <asp:TextBox ID="txtIDCard" runat="server" CssClass="txt" 
                                            Width="130px" MaxLength="18"></asp:TextBox>
                                        <asp:CheckBox ID="chkForeign" runat="server" Text="非身份证" />
                                    </td>

                                </tr>
                                <tr>
                                    <td height="22" style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" 
                                        valign="bottom">
                                        房主电话：<span style="color: #FF0000">*</span></td>
                                    <td height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; width: -200;" 
                                        valign="bottom">
                                        <asp:TextBox ID="txtOwnerTel" runat="server" CssClass="txt" MaxLength="20" 
                                            Width="195px"></asp:TextBox>
                                    
                                </td> 
                                  <td height="22" 
                                      style="background-color: #FFFFFF; padding: 2px; height: 25px; " 
                                      valign="bottom">
                                      所有类型：</td>
                                  <td height="22" 
                                      style="background-color: #FFFFFF; padding: 2px; height: 25px; width: 66px;" 
                                      valign="bottom" width="200px">
                                      <asp:DropDownList ID="ddlOwnType" runat="server" AutoPostBack="false" 
                                          Width="200px" >
                                      </asp:DropDownList>
                                      <asp:SqlDataSource ID="OwnType" runat="server" 
                                          ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" 
                                          SelectCommand="up_Rent_RentSystemOptionSelectByParentID" 
                                          SelectCommandType="StoredProcedure">
                                          <SelectParameters>
                                              <asp:ControlParameter ControlID="lblOwnType" DefaultValue="0" 
                                                  Name="rsParentNo" PropertyName="Text" Type="Int32" />
                                          </SelectParameters>
                                      </asp:SqlDataSource>
                                      <asp:Label ID="lblOwnType" runat="server" Visible="False">0</asp:Label>
                                  </td>
                                  <tr>
                                      <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 150px;" 
                                          valign="middle" width="150">
                                          房屋描述：<asp:Label ID="lblCreatedBy0" runat="server" MaxLength="20" Width="80px"></asp:Label>
                                      </td>
                                      <td colspan="3" height="22" 
                                          style="background-color: #FFFFFF; padding: 2px; height: 40px; " valign="middle">
                                          <asp:TextBox ID="txtLocationDescription" runat="server" CssClass="txt" 
                                              Height="50" MaxLength="200" TextMode="MultiLine" Width="546px"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" 
                                          valign="bottom">
                                          创建人：</td>
                                      <td height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; " 
                                          valign="bottom">
                                          <asp:Label ID="lblCreatedByName" runat="server" MaxLength="20"></asp:Label>
                                          <asp:Label ID="lblCreatedBy" runat="server" MaxLength="20" Visible="false"></asp:Label>
                                      </td>
                                      <td height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; " 
                                          valign="bottom">
                                          创建时间：</td>
                                      <td height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; " 
                                          valign="bottom">
                                          <asp:Label ID="lblCreatedDate" runat="server" CssClass="date" MaxLength="10" 
                    Width="150px"></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td height="22" 
                                          style="padding: 2px; height: 25px; background-color: #FFFFFF; width: 400px;" 
                                          valign="bottom">
                                          &nbsp;</td>
                                      <td colspan="3" height="22" 
                                          style="background-color: #FFFFFF; padding: 2px; height: 25px; " valign="bottom">
                                          <asp:Button ID="btnSave" runat="server" CssClass="buttonDefault" 
                                              OnClick="btnSave_Click" OnClientClick="javascript:return ValidateForm();" 
                                              Text="保存信息" />
                                          <input onclick="javascript:window.close();" type="button" 
                                            value="关闭窗口" class="buttonDefault" />
                                      </td>
                                  </tr>
                                </table>
                      
                </td>
                </tr>
                </td height="22" style="background-color: #FFFFFF; padding: 2px; height: 25px; " valign="bottom">
                
                </tr>
                </td>
                </td>
            </table>
            </td>
            </tr>
            </td>
            </table>
            </td>
            </tr>
            </table>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div id="allmap" style="width:730px;margin:auto;display:none;">
         <script type="text/javascript">
             // 百度地图API功能
             var map = new BMap.Map("allmap");
             map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
             //map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用
             map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件
             map.addControl(new BMap.OverviewMapControl()); //添加默认缩略地图控件
             map.addControl(new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_RIGHT }));   //右下角，打开
             map.centerAndZoom("天津", 12);
             // 创建地址解析器实例

             // 将地址解析结果显示在地图上,并调整地图视野
             function searchByStationName() {
                 var myGeo = new BMap.Geocoder();
                 var keyword = document.getElementById("<%=txtAddress.ClientID %>").value;
                 myGeo.getPoint(keyword, function (point) {
                     if (point) {
                         document.getElementById("<%=txtLangitude.ClientID %>").value = point.lng; //获取经度和纬度，将结果显示在文本框中
                         document.getElementById("<%=txtLatitude.ClientID %>").value = point.lat; //获取经度和纬度，将结果显示在文本框中
                         map.centerAndZoom(point, 16);
                         map.addOverlay(new BMap.Marker(point));
                     } else {
                         alert("您选择地址没有解析到结果!");
                     }
                 }, "天津市");
             }

             function showPosition() {
                 var lan = document.getElementById("<%=txtLangitude.ClientID %>").value;
                 var lat = document.getElementById("<%=txtLatitude.ClientID %>").value;
                 if (!lan || !lat) {
                     alert('请先获取经纬度后进行查看!');
                     return false;
                 }

                 $.ligerDialog.open({
                     url:"MapLocation.aspx?Lan=" + lan + "&Lat=" + lat + "&num=" + Math.random(),
                     //target:$("#allmap"),
                     width: 550, height: 480,
                     buttons: [{ text: '关闭', onclick: function (i, d) { d.hide(); } }
                                             ]
                 });
             }


</script>
    </div>
</asp:Content>