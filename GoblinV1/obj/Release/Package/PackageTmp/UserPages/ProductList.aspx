<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="GoblinV1.UserPages.ProductList" %>
<%@ OutputCache Duration="120" VaryByParam="None" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

        <%--required to include ajax components--%>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit " TagPrefix="ajaxToolkit" %>

    <!--script manager for ajax-->
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>


    <asp:ListView ID="productList1" runat="server"
        DataKeyNames="ProductID" GroupItemCount="4"
        ItemType="GoblinV1.Models.Product" SelectMethod="GetProducts">
        <EmptyDataTemplate>
            <table>
                <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>
                <asp:BulletedList ID="BulletedList2" runat="server"></asp:BulletedList>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList><asp:RadioButtonList ID="RadioButtonList2" runat="server"></asp:RadioButtonList><asp:RadioButtonList ID="RadioButtonList3" runat="server"></asp:RadioButtonList><asp:RadioButtonList ID="RadioButtonList4" runat="server"></asp:RadioButtonList><asp:RadioButtonList ID="RadioButtonList5" runat="server"></asp:RadioButtonList><asp:Substitution ID="Substitution1" runat="server" />
                <asp:Substitution ID="Substitution2" runat="server" />
                <asp:Substitution ID="Substitution3" runat="server" />
                <asp:Substitution ID="Substitution4" runat="server" />
                <asp:Substitution ID="Substitution5" runat="server" />
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

                            <!--Update panel for partial rendering-->
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <!--Rating ajax control-->
                                    <ajaxToolkit:Rating
                                        ID="Rating1" runat="server"
                                        CurrentRating="2"
                                        MaxRating="5"
                                        StarCssClass="rating_star"
                                        FilledStarCssClass="rating_filled"
                                        EmptyStarCssClass="rating_empty"
                                        WaitingStarCssClass="rating_empty">
                                    </ajaxToolkit:Rating>
                                </ContentTemplate>

                            </asp:UpdatePanel>

                            <asp:Label ID="lblRatingStatus" runat="server" Text=""></asp:Label>


                            <a href="ProductDetails.aspx?productID=<%#:Item.ProductID%>">
                                <img src="../Catalog/Images/Thumbs/<%#:Item.ProductImagePath%>"
                                    width="250" height="200" style="border: solid" /></a>
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
