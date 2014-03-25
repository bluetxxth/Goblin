<%@ Page Title="User Admin" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="GoblinV1.Secure.AdminPages.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="server">
    <h1><%#:Page.Title %></h1>


    <!--left side menu-->
    <div id="leftSide">
        <asp:SiteMapDataSource ID="AdminPages" runat="server" ShowStartingNode="false" />
        <ul>
            <li>
                <asp:HyperLink runat="server" ID="lnkHome" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
            </li>
            <asp:Repeater runat="server" ID="menu" DataSourceID="AdminPages">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="lnkMenuItem" runat="server" NavigateUrl='<%# Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink>
                        <asp:Repeater ID="submenu" runat="server" DataSource="<%# ((SiteMapNode) Container.DataItem).ChildNodes %>">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <asp:HyperLink ID="lnkMenuItem" runat="server" NavigateUrl='<%#                                         Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate></ul>                          </FooterTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        
    </div><!--End left side-->

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
