<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Goblin.UserPages.TestPage" %>
<%@ OutputCache Duration="120" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

    <h1>Errors</h1>
    <asp:Label ID="lblError" CssClass ="lblError" runat="server" Text="Errors: "></asp:Label> <br/>
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
    <asp:TextBox ID="txtError" BorderWidth="0" Style="overflow: auto; color: red; font-size:16px;"  TextMode="MultiLine"
       runat="server" rows="20" Columns ="80"></asp:TextBox>
</asp:Content>
