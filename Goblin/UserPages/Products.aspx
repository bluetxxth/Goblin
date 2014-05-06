<%@ Page Title="Products" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Goblin.UserPages.Products" %>
<%@ OutputCache Duration="120" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <hgroup>
        <h1><%:Page.Title %>
        </h1>
    </hgroup>

    <!--Display Products -->
    <asp:ListView ID="categoryList"
        ItemType="Goblin.Model.Category"
        runat="server"
        SelectMethod="GetCategories">
        <ItemTemplate>
            <b style="font-size: large; font-style: normal"><a href="ProductList.aspx?id=<%#:Item.CategoryID %>">
                <%#:Item.CategoryName %></a></b>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            |
        </ItemSeparatorTemplate>
    </asp:ListView>

</asp:Content>
