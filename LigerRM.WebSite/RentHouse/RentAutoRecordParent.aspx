<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Detail.master" AutoEventWireup="true" CodeFile="RentAutoRecordParent.aspx.cs" Inherits="RentHouse_RentAutoRecordParent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="font-size:x-large; padding:5px;">请放入身份证验证身份入住......<span id="lbMessage" style="color:Red;"></span></div>
<div style="display:none;">
<iframe src="RentAutoRecord.aspx" frameborder="0" height="50" width="100%"></iframe></div>
</asp:Content>

