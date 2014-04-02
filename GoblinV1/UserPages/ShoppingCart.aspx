<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GoblinV1.UserPages.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead">
        <h1>Shopping Cart</h1>
    </div>
    <asp:GridView ID="CartList" runat="server"
        AutoGenerateColumns="False"
        ShowFooter="True"
        GridLines="Vertical"
        CellPadding="4"
        ItemType="GoblinV1.Models.CartItem" 
        SelectMethod="GetShoppingCartItems"
        CssClass="table table-striped table-bordered" OnSelectedIndexChanged="CartList_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />
            <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />
            <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Item Total">
                <ItemTemplate>

                    <%# String.Format("{0:c}", ((Convert.ToInt32(Item.Quantity))) * (Convert.ToDouble(Item.Product.UnitPrice))) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remove Item">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>

        </strong>
    </div>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnCheckOut" runat="server" Text="Checkout" OnClick="btnCheckOut_Click" />
    <asp:Button ID="btnContinueShopping" runat="server" Text="Continue Shopping" OnClick="btnContinueShopping_Click" />

</asp:Content>
