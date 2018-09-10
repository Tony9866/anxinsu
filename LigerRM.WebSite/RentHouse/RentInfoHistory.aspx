<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Detail.master" CodeFile="RentInfoHistory.aspx.cs" Inherits="RentHouse_RentInfoHistory" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div style="text-align:center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RRAID" 
                DataSourceID="RentAttributeHistory" EnableModelValidation="True" CssClass="l-grid table"
                 AllowPaging="True" AllowSorting="True" CellPadding="4" BackColor="White" BorderColor="#CCCCCC"
                 BorderStyle="None" BorderWidth="1px" CellSpacing="2" EmptyDataText="没有数据" 
                HorizontalAlign="Left" Font-Size="14px" ForeColor="Black" 
                GridLines="Horizontal" Width="100%">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle CssClass="l-grid table" BackColor="#333333" Font-Bold="True" 
                    ForeColor="White"  />
                <PagerStyle  HorizontalAlign="Right" BackColor="White" ForeColor="Black" />
                <RowStyle CssClass="l-grid-row"  />
                <Columns>
                    <asp:BoundField DataField="RRAID" HeaderText="序号"  Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="RRAID" />
                    <asp:BoundField DataField="RentNo" HeaderText="房源编号" SortExpression="RentNo" />
                    <asp:BoundField DataField="RRAContactName" HeaderText="租赁人姓名" SortExpression="RRAContactName" />
                    <asp:BoundField DataField="RRAContactTel" HeaderText="租赁人电话" SortExpression="RRAContactTel" />
                    <asp:BoundField DataField="RRAIDCard" HeaderText="身份证号" SortExpression="RRAIDCard" />
                    <asp:BoundField DataField="RRentPrice" HeaderText="租赁价格" SortExpression="RRentPrice" />
                    <asp:BoundField DataField="RRAStartDate" HeaderText="起始时间" 
                        SortExpression="RRAStartDate" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="RRAEndDate" HeaderText="结束时间" 
                        SortExpression="RRAEndDate" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="RRADescription" Visible="false" HeaderText="备注" SortExpression="RRADescription" />
                    <asp:BoundField DataField="RRAIsActive" HeaderText="是否过期" ReadOnly="True" SortExpression="RRAIsActive" />
                </Columns>
                <SelectedRowStyle CssClass="l-selected" BackColor="#CC3333" Font-Bold="True" 
                    ForeColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="RentAttributeHistory" runat="server" ConnectionString="<%$ ConnectionStrings:LigerUIConnectionString %>" SelectCommand="up_Rent_RentAttributeSelectByRentNo" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="rentNo" QueryStringField="RentNo" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>