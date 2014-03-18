<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="GoblinV1.UserPages.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <asp:ListView ID="productList1" runat="server"
        DataKeyNames="ProductID" GroupItemCount="4"
        ItemType="GoblinV1.Models.Product" SelectMethod="GetProducts">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td runat="server">
                <table>
                    <tr>
                        <td>
                            <a href="ProductDetails.aspx?productID=<%#:Item.ProductID%>">
                                <img src="../Catalog/Images/Thumbs/<%#:Item.ProductImagePath%>"
                                    width="200" height="100" style="border: solid" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="ProductDetails.aspx?productID=<%#:Item.ProductID%>">
                                <span>
                                    <%#:Item.ProductName%>
                                </span>
                            </a>
                            <br />
                            <span>
                                <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                            </span>
                            <br />
                            <a href="AddToCart.aspx?productID=<%#:Item.ProductID%>">
                                <span class="ProductListItem">
                                    <b>Add To Cart<b>
                                </span>
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </p>
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table style="width: 100%;">
                <tbody>
                    <tr>
                        <td>
                            <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                <tr id="groupPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr></tr>
                </tbody>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
