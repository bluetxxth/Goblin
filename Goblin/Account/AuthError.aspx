<%@ Page Title="Authentication Error" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="AuthError.aspx.cs" Inherits="Goblin.Account.AuthError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentCartCounter" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="server">
    <h1><%:Page.Title %></h1>
    The page you are trying to view requires special authentication. Review your credentials and try to login again.
</asp:Content>
