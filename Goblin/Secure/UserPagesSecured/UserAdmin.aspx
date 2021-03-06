﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="UserAdmin.aspx.cs" Inherits="Goblin.UserPages.UserPanel" %>
<%@ OutputCache Duration="120" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

            <asp:GridView ID="OrderGridView" runat="server" 
            AutoGenerateSelectButton="true" 
            AutoGenerateColumns ="true"
            ItemType="Goblin.Model.Order" 
            >

             <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="OrderNo" SortExpression="OrderId" />
            <asp:BoundField DataField="Created" HeaderText="Created" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="OrderItems" HeaderText="Items" />
            <asp:BoundField DataField="Customers" HeaderText="Customer" />
            <asp:BoundField DataField="IsProcessed" HeaderText="Processed" />
            
          
            <asp:TemplateField HeaderText="Remove Item">
                <ItemTemplate>
                    <asp:CheckBox ID="IsProcessed" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        </asp:GridView>
</asp:Content>
