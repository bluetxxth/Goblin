<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="UsersToRoles.aspx.cs" Inherits="Goblin.Secure._Roles.AssignUsersToRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
      <!--right side-->
    <div id="rightSide">
        <!--parent fieldset-->
        <fieldset class="adminParentFieldset">
            <legend class="legend">Admin options</legend>

            <!--left area-->
            <div class="leftAdminArea">
                <fieldset class="adminFieldset">
                    <legend class="legend">RoleManager</legend>
                    <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>

                    <p>
                    <!--Dropdown user list-->
                    <asp:DropDownList ID="drpUserList" runat="server" AutoPostBack="true" DataTextField="UserName" OnSelectedIndexChanged="drpUserList_SelectedIndexChanged">
                    </asp:DropDownList>
                    </p>

                    <asp:Repeater ID="rptUsersRoleList" runat="server">
                        <ItemTemplate>

                            <asp:CheckBox runat="server" ID="chkboxRoleCheckBox" AutoPostBack="true" Text='<%# Container.DataItem %>' OnCheckedChanged="chkboxRoleCheckBox_CheckedChanged" />
                            <br />

                        </ItemTemplate>
                    </asp:Repeater>
                </fieldset>
                <!--end roleManager-->
                </div>
             

        </fieldset>
        <!--end parent fieldset-->

    </div>
    <!--end right side-->
</asp:Content>
