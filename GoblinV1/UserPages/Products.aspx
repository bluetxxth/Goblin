<%@ Page Title="Products" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="GoblinV1.UserPages.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <hgroup>
        <h1><%: Page.Title %>
        </h1>
    </hgroup>

    <!--Display Products -->
    <asp:ListView ID="categoryList"
        ItemType="GoblinV1.Models.Category"
        runat="server"
        SelectMethod="GetCategories">
        <ItemTemplate>
            <b style="font-size: large; font-style: normal"><a href="/UserPages/ProductList.aspx?id=<%#: Item.CategoryID %>"><%#: Item.CategoryName %></a></b>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            |
        </ItemSeparatorTemplate>
    </asp:ListView>

</asp:Content>
