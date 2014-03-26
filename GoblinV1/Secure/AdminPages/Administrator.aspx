﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrator.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="GoblinV1.Secure.AdminPages.Administrator" %>

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
                    <!--Dropdown user list-->
                    <asp:DropDownList ID="drpUserList" runat="server" AutoPostBack="true" DataTextField="UserName" OnSelectedIndexChanged="drpUserList_SelectedIndexChanged">
                    </asp:DropDownList>

                    <asp:Repeater ID="rptUsersRoleList" runat="server">
                        <ItemTemplate>

                            <asp:CheckBox runat="server" ID="chkboxRoleCheckBox" AutoPostBack="true" Text='<%# Container.DataItem %>' OnCheckedChanged="chkboxRoleCheckBox_CheckedChanged" />
                            <br />

                        </ItemTemplate>
                    </asp:Repeater>
                </fieldset>
                <!--end roleManager-->

                <!--View Roles-->
                <fieldset class="adminFieldset">
                    <legend class="legend">view roles</legend>

                </fieldset>

                <!--Add Roles-->
                <fieldset class="adminFieldset">
                    <legend class="legend">Add Roles</legend>

                </fieldset>

            </div>
            
            <!--right area-->
            <div class="rightAdminArea">

                <!--Remove Roles-->
                <fieldset class="adminFieldset">
                    <legend class="legend">Remove roles</legend>

                </fieldset>

                <!--change Roles-->
                <fieldset class="adminFieldset">
                    <legend class="legend">Change roles</legend>

                </fieldset>
            </div>

        </fieldset>
        <!--end parent fieldset-->

    </div>
    <!--end right side-->
</asp:Content>
