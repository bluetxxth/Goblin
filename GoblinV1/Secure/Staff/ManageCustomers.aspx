<%@ Page Title="Manage Customers" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="GoblinV1.Secure.Staff.ManageCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
        <h1><%:Page.Title %></h1>
    <fieldset>
        <legend><b>Mange Customers</b></legend>

        <asp:GridView ID="CustomerGridView" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="CustomerId"
            ItemType=" GoblinV1.Models.Customer"
            OnRowDeleting="CustomerGridView_RowDeleting"
            OnSelectedIndexChanged="CustomerGridView_SelectedIndexChanged">
            <Columns>

                <asp:CommandField ShowDeleteButton="true" ShowSelectButton="true" />

                <asp:BoundField DataField="CustomerId" HeaderText="Id" SortExpression="ProductId" />
                <asp:BoundField DataField="FirstName" HeaderText="Name"  />
                <asp:BoundField DataField="MiddleName" HeaderText="Middle" />
                <asp:BoundField DataField="LastName" HeaderText="Last" />
                <asp:BoundField DataField="Email" HeaderText="Email"  />


            </Columns>

        </asp:GridView>

        <asp:FormView ID="CustomerFormView" runat="server"
            ItemType="GoblinV1.Models.Customer"
            DefaultMode="Insert"
            DataKeyNames="CustomerId"
            RenderOuterTable="false"
            InsertMethod="InsertCustomer"
            UpdateMethod="UpdateCustomer"
            SelectMethod="SelectCustomer">

            <InsertItemTemplate>

                <label>
                    <span class="lefty">First</span>
                    <asp:DynamicControl runat="server" DataField="FirstName" Mode="Insert" />
                </label>

                <br />

                <label>
                    <span class="lefty">Middle</span>
                    <asp:DynamicControl runat="server" DataField="MiddleName" Mode="Insert" />
                </label>
                <br />

                <label>
                    <span class="lefty">Last</span>
                    <asp:DynamicControl runat="server" DataField="LastName" Mode="Insert" />
                </label>
                <br />

                <label>
                    <span class="lefty">Email</span>
                    <asp:DynamicControl runat="server" DataField="Email" Mode="Insert" />
                </label>
                <br />

                <label>
                    <span class="lefty">Phone</span>
                    <asp:DynamicControl runat="server" DataField="Phone" Mode="Insert" />
                </label>
                <br />


                <p>
                    <asp:Button runat="server" Text="Insert" CommandName="Insert" />
                </p>

            </InsertItemTemplate>

            <EditItemTemplate>
                <label>
                    <span class="lefty">Name</span>
                    <asp:DynamicControl runat="server" DataField="FirstName" Mode="Edit" />
                </label>

                <br />

                <label>
                    <span class="lefty">Middle</span>
                    <asp:DynamicControl runat="server" DataField="MiddleName" Mode="Edit" />
                </label>
                <br />

                <label>
                    <span class="lefty">Last</span>
                    <asp:DynamicControl runat="server" DataField="LastName" Mode="Edit" />
                </label>
                <br />

                <label>
                    <span class="lefty">Email</span>
                    <asp:DynamicControl runat="server" DataField="Email" Mode="Edit" />
                </label>
                <br />

                <label>
                    <span class="lefty">Phone</span>
                    <asp:DynamicControl runat="server" DataField="Phone" Mode="Edit" />
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
