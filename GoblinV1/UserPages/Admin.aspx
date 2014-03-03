<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="GoblinV1.UserPages.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <h1>Administration</h1>
    <fieldset><legend>Add Products</legend>
 
        <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label>
        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblProductSpecs" runat="server" Text="Specs"></asp:Label>
        <asp:TextBox ID="txtProductSpecs" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblProductOptions" runat="server" Text="Options"></asp:Label>
        <asp:TextBox ID="txtProductOptions" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblProductPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblProductStock" runat="server" Text="Stock"></asp:Label>
        <asp:TextBox ID="txtProductStock" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblProductImagePath" runat="server" Text="Image path"></asp:Label>
        <asp:TextBox ID="txtProductImagePath" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblCategory" runat="server" Text="Category ID"></asp:Label>
        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
       
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />

       <asp:GridView  runat="server" ID="ProductGridView" AutoGenerateSelectButton ="true" DataKeyNames ="ProductId" OnSelectedIndexChanged="ProductGridView_SelectedIndexChanged"></asp:GridView>

    </fieldset>
</asp:Content>
