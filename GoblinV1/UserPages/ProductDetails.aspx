﻿<%@ Page Title="Product details" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="GoblinV1.UserPages.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
        <asp:FormView ID="productDetail" runat="server" ItemType="GoblinV1.Models.Product" SelectMethod ="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProductName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                       <img src="../Catalog/Images/<%#:Item.ProductImagePath %>" style="border:solid; height:150px"; width: "200px" alt="<%#:Item.ProductName %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Description:</b><br /><%#:Item.Specifications%><br /><span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span><br /><span><b>Product Number:</b>&nbsp;<%#:Item.ProductID %></span><br /></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
