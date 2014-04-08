<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="GoblinV1.Secure.AdminPages.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
     <asp:ListView ID="adminListView" runat="server"
        
        DataKeyNames="DepartmentId" GroupItemCount="3"
        ItemType="GoblinV1.Models.Department" SelectMethod="GetDepartments">


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
                            <!--admin department-->
                            <a href="../<%#:Item.DepartmentUrl%>">

                                <img src="../../Catalog/Images/Thumbs/<%#:Item.DepartmentIcon%>"
                                    width="150" height="150" style="border: solid; border-color:black;"/></a>

               <%--             <asp:Image ID="Image1" runat="server" ImageUrl="~/Catalog/Images/Thumbs/Department.jpg" width="150" height="150" style="border: solid; border-color:black;" />--%>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="Administration.aspx?DepartmentId=<%#:Item.DepartmentId%>">
                                <span>
                                    <%#:Item.DepartmentName%>
                                </span>
                            </a>
                            <br />
                <%--            <span>
                                <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                            </span>--%>
                            <br />
         <%--                   <a href="AddToCart.aspx?productID=<%#:Item.ProductID%>">
                                <span class="ProductListItem">
                                    <b>Add To Cart<b>
                                </span>
                            </a>--%>
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
