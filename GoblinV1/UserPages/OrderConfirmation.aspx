<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="GoblinV1.UserPages.OrderConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <h1>Order Confirmation </h1>
    <asp:TextBox ID="txtOrderConfirmation" runat="server" TextMode ="MultiLine" Rows = "10" Columns = "100"></asp:TextBox>
    <br/>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>
