<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="RoleManager.aspx.cs" Inherits="Goblin.Secure._Roles.RoleManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

    <!--Left area-->
    <div class="leftAdminArea">

                <!--Add Roles-->
                <fieldset class="adminFieldset">
                    <legend class="legend">Add / Remove Roles</legend>
                    <p>
                     <asp:Button ID="btnCreateRole" runat="server" Text="Create" OnClick="CreateRoleButton_Click" />
                    <asp:TextBox ID="txtRoleToAdd" runat="server"></asp:TextBox>
                    </p>
                     <asp:Button ID="btnRemoveRoles" runat="server" Text="Remove" OnClick="RemoveRoleButton_Click" />
                    <asp:TextBox ID="txtRoleToRemove" runat="server"></asp:TextBox>
                   
                </fieldset>

                <!--View Roles-->
                <fieldset class="adminFieldset">
                    <legend class="legend">View roles</legend>

                    <asp:GridView ID="RoleList" runat="server" AutoGenerateColumns="false"> <Columns> <asp:TemplateField HeaderText="Role"> <ItemTemplate> <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>' /> </ItemTemplate> </asp:TemplateField> </Columns> </asp:GridView>

                </fieldset>
        </div>

      <!--right area-->
            <div class="rightAdminArea">
              
            </div>

</asp:Content>
