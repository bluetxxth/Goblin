<%@ Page Title="Manage Products" Language="C#" MasterPageFile="~/MasterPages/ProductManager.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="GoblinV1.UserPages.CreateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <h1><%:Page.Title %></h1>
    <fieldset>
        <legend><b>Add Products</b></legend>

        <asp:GridView ID="ProductGridView" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="ProductId"
            ItemType=" GoblinV1.Models.Product"
            OnRowDeleting="ProductGridView_RowDeleting"
            OnSelectedIndexChanged="ProductGridView_SelectedIndexChanged">
            <Columns>

                <asp:CommandField ShowDeleteButton="true" ShowSelectButton="true" />

                <asp:BoundField DataField="ProductId" HeaderText="Id" SortExpression="ProductId" />
                <asp:BoundField DataField="ProductName" HeaderText="Name" SortExpression="ProductNameId" />
                <asp:BoundField DataField="Specifications" HeaderText="Specifications" />
                <asp:BoundField DataField="ProductImagePath" HeaderText="ImagePath" />
                <asp:BoundField DataField="Options" HeaderText="Options" SortExpression="ProductId" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" SortExpression="ProductId" />
                <asp:BoundField DataField="CategoryId" HeaderText="Category" SortExpression="ProductId" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="ProductId" />

            
            </Columns>

        </asp:GridView>

        <asp:FormView ID="ProductFormView" runat="server"
            ItemType="GoblinV1.Models.Product"
            DefaultMode="Insert"
            DataKeyNames="ProductId"
            RenderOuterTable="false"
            InsertMethod="InsertProduct"
            UpdateMethod="UpdateProduct"
            SelectMethod="SelectProduct">

            <InsertItemTemplate>

                <label>
                    <span class="lefty">Product Name</span>
                    <asp:DynamicControl runat="server" DataField="ProductName" Mode="Insert" />
                </label>

                <br />

                <label>
                    <span class="lefty">Img path</span>
                    <asp:DynamicControl runat="server" DataField="ProductImagePath" Mode="Insert" />
                </label>
                <br />

                <label>
                    <span class="lefty">Specs</span>
                    <asp:DynamicControl runat="server" DataField="Specifications" Mode="Insert" />
                </label>
                <br />

                <label>
                    <span class="lefty">Options</span>
                    <asp:DynamicControl runat="server" DataField="Options" Mode="Insert" />
                </label>
                <br />

                <label>
                    <span class="lefty">Price</span>
                    <asp:DynamicControl runat="server" DataField="UnitPrice" Mode="Insert" />
                </label>
                <br />

                <label>
                    <span class="lefty">Category</span>
                    <asp:DynamicControl runat="server" DataField="CategoryId" Mode="Insert" />
                </label>
                <br />

                <label>
                    <span class="lefty">Stock</span>
                    <asp:DynamicControl runat="server" DataField="Stock" Mode="Insert" />
                </label>
                <br />
                <p>
                    <asp:Button runat="server" Text="Insert" CommandName="Insert" />
                </p>

            </InsertItemTemplate>

            <EditItemTemplate>
                <label>
                    <span class="lefty">Product Name</span>
                    <asp:DynamicControl runat="server" DataField="ProductName" Mode="Edit" />
                </label>

                <br />

                <label>
                    <span class="lefty">Img path</span>
                    <asp:DynamicControl runat="server" DataField="ProductImagePath" Mode="Edit" />
                </label>
                <br />

                <label>
                    <span class="lefty">Specs</span>
                    <asp:DynamicControl runat="server" DataField="Specifications" Mode="Edit" />
                </label>
                <br />

                <label>
                    <span class="lefty">Options</span>
                    <asp:DynamicControl runat="server" DataField="Options" Mode="Edit" />
                </label>
                <br />

                <label>
                    <span class="lefty">Price</span>
                    <asp:DynamicControl runat="server" DataField="UnitPrice" Mode="Edit" />
                </label>
                <br />

                <label>
                    <span class="lefty">Category</span>
                    <asp:DynamicControl runat="server" DataField="CategoryId" Mode="Edit" />
                </label>
                <br />

                <label>
                    <span class="lefty">Stock</span>
                    <asp:DynamicControl runat="server" DataField="Stock" Mode="Edit" />
                </label>
                <br />

                <p>
                    <asp:Button runat="server" Text="Cancel" CommandName="false" />
                    <asp:Button runat="server" Text="Update" CommandName="Update" />
                </p>

            </EditItemTemplate>
        </asp:FormView>
    </fieldset>

   
</asp:Content>
