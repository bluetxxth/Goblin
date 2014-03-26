<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="GoblinV1.Secure.AdminPages.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
     <div id="rightSide">
        <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>

        <!--Dropdown user list-->
        <asp:DropDownList ID="drpUserList" runat="server" AutoPostBack="true" DataTextField="UserName" OnSelectedIndexChanged="drpUserList_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:Repeater ID="rptUsersRoleList" runat="server">
            <ItemTemplate>

                <asp:CheckBox runat="server" ID="chkboxRoleCheckBox" AutoPostBack="true" Text='<%# Container.DataItem %>' OnCheckedChanged="chkboxRoleCheckBox_CheckedChanged" />
                <br />

            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!--end right side-->

</asp:Content>
