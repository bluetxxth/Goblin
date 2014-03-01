<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Contact.Master" AutoEventWireup="true" CodeBehind="ContactUsConfirm.aspx.cs" Inherits="GoblinV1.UserPages.ContactUsConfirm" %>
<%@ PreviousPageType VirtualPath="~/UserPages/ContactUs.aspx" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <h3> <asp:Label ID="lblName" runat="server" Text=""></asp:Label> </h3> 

    <div id = "contactConfirm">

        <asp:TextBox ID="txtOutput" TextMode="multiline" Columns="50" Rows="5" runat="server"></asp:TextBox>
    </div>
    
    <asp:Button CssClass="btnContactMsgSend"  ID="Button1" runat="server" Text="Back"  PostBackUrl="~/UserPages/ContactUs.aspx" />
</asp:Content>
