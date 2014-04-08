<%@ Page Title="Log in" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GoblinV1.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

    <%--required to include ajax components--%>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit " TagPrefix="ajaxToolkit" %>

    <!--script manager for ajax-->
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

    <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="Password" MinimumLowerCaseCharacters="3" MinimumNumericCharacters="2" MinimumUpperCaseCharacters="3"></ajaxToolkit:PasswordStrength>


    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />

                    <!--show the login status added by Gabriel Nieva-->
                    <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
                        <p>
                            <asp:Literal runat="server" ID="StatusText" />
                        </p>
                    </asp:PlaceHolder>

                    <!--Display error message-->
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">

                        <!--Form group for user name field-->
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">User name</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="text-danger" ErrorMessage="The user name field is required." />
                            </div>
                        </div>

                        <!--Form group for password field  -->
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            </div>
                        </div>

                        <!--Form group for remember me section-->
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                </div>
                            </div>
                        </div>

                        <!--Form group for login button-->
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                            </div>
                        </div>

                    </asp:PlaceHolder>

                    <!--Logout button added by Gabriel Nieva-->
                    <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
                        <div>
                            <div>
                                <asp:Button runat="server" OnClick="SignOut" Text="Log out" />
                            </div>
                        </div>
                    </asp:PlaceHolder>

                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have a local account.
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>


