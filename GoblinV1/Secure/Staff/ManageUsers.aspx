<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="GoblinV1.UserPages.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">


    <h1>Create Customer</h1>

    <asp:Label ID="lblFirstName" runat="server" Text="First Name" ></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server" ></asp:TextBox>
        <br/>
    <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
    <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
        <br/>
    <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br/>
    <asp:Label ID="lblStreetName" runat="server" Text="Street Name"></asp:Label>
    <asp:TextBox ID="txtStreetName" runat="server"></asp:TextBox>
        <br/>
    <asp:Label ID="lblStreetNo" runat="server" Text="Street Number"></asp:Label>
    <asp:TextBox ID="txtStreetNo" runat="server"></asp:TextBox>
        <br/>
    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <br/>
    <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
        <br/>
    <asp:Label ID="lblZipCode" runat="server" Text="Zipcode"></asp:Label>
    <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        <br/>
    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br/>
    <asp:Label ID="lblTelephone" runat="server" Text="Telephone"></asp:Label>
    <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
        <br/>
         <br/>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />


</asp:Content>
