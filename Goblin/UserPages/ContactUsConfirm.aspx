<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ContactUsConfirm.aspx.cs" Inherits="Goblin.UserPages.ContactUsConfirm" %>
<%@ OutputCache Duration="120" VaryByParam="None" %>
<%@ PreviousPageType VirtualPath="~/UserPages/ContactUs.aspx" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

      <%--required to include ajax components--%>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit " TagPrefix="ajaxToolkit" %>

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

     <asp:Label ID="Label1" runat="server" Text="NoBot Response State:" Font-Bold="true"
            Font-Size="14px"></asp:Label>



    <asp:Label ID="Label2" runat="server" Font-Size="16px"></asp:Label>
      <br/>
    
    <asp:Label ID="Label3" runat="server" Text="Client IP Address:" Font-Bold="true"
            Font-Size="14px"></asp:Label>

      <br/>
    <asp:Label ID="Label4" runat="server" Font-Size="16px"></asp:Label>
        <br />


    <ajaxToolkit:NoBot
        ID="NoBot1"
        runat="server"
       
        ResponseMinimumDelaySeconds="2"
        CutoffWindowSeconds="60"
        CutoffMaximumInstances="5" />


    <h3> <asp:Label ID="lblName" runat="server" Text=""></asp:Label> </h3> 

    <div id = "contactConfirm">

        <asp:TextBox ID="txtOutput" TextMode="multiline" Columns="50" Rows="5" runat="server"></asp:TextBox>
    </div>
    
    <asp:Button CssClass="btn"  ID="Button1" runat="server" Text="Back"  PostBackUrl="~/UserPages/ContactUs.aspx" />

    <asp:Button CssClass="btn"  ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click"/>



</asp:Content>
