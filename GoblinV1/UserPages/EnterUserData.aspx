<%@ Page Title="User Data" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="EnterUserData.aspx.cs" Inherits="GoblinV1.UserPages.EnterUserData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="server">
    <h1><%:Page.Title %></h1>

    <asp:ValidationSummary runat="server" CssClass="text-danger" />

    <!-- user Personal data-->
    <fieldset class="enterUserFieldset">
        <legend class="UserDataLegend">User data</legend>

        <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID ="FirstName" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                CssClass="text-danger" ErrorMessage="The user first name field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="MiddleName" CssClass="col-md-2 control-label">Middle Name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="MiddleName" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="MiddleName"
                CssClass="text-danger" ErrorMessage="The user first name field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                CssClass="text-danger" ErrorMessage="The user last name name field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Email" CssClass="form-control"  />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                CssClass="text-danger" ErrorMessage="The user first name field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="Telephone" CssClass="col-md-2 control-label">Telephone</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Telephone" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Telephone"
                CssClass="text-danger" ErrorMessage="The user last name name field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="CellPhone" CssClass="col-md-2 control-label">Cellphone</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="CellPhone" CssClass="form-control" />
            <%--           <asp:RequiredFieldValidator runat="server" ControlToValidate="CellPhone"
                CssClass="text-danger" ErrorMessage="The user last name name field is required." />--%>
        </div>


    </fieldset>
    <!--end user personal data-->

    <!--Credit Card data-->
    <fieldset class="enterUserFieldset">
        <legend class="UserDataLegend">Credit Card info</legend>

        <!--CC data-->
        <asp:Label runat="server" AssociatedControlID="CardName" CssClass="col-md-2 control-label">CardName</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="CardName" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="CardName"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="CardNumber" CssClass="col-md-2 control-label">Card No.</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="CardNumber" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="CardNumber"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="CardExpiryDate" CssClass="col-md-2 control-label">Expiry Date.</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="CardExpiryDate" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="CardExpiryDate"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="CardSecurityCode" CssClass="col-md-2 control-label">Security Code</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="CardSecurityCode" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="CardSecurityCode"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />
        </div>
    </fieldset>
    <!--End Credit card info-->


    <%--      <!--User Bank data-->
         <fieldset class="enterUserFieldset">
        <legend class="UserDataLegend">Bank Data</legend>

        <!--Bank data-->
     <asp:Label runat="server" AssociatedControlID="BankName" CssClass="col-md-2 control-label">Bank Name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BankName" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BankName"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />
        </div>


        <asp:Label runat="server" AssociatedControlID="BankAccNumber" CssClass="col-md-2 control-label">Bank Account Number</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BankAccNumber" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BankAccNumber"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="BankBicNo" CssClass="col-md-2 control-label">Bank Bic No.</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BankBicNo" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BankBicNo"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="BankSwift" CssClass="col-md-2 control-label">Swift</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BankSwift" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BankSwift"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />
        </div>

    </fieldset><!--End Bank Data-->--%>

    <!--User billing address data-->
    <fieldset class="enterUserFieldset">
        <legend class="UserDataLegend">Billing address</legend>

        <asp:Label runat="server" AssociatedControlID="BillingAddressName" CssClass="col-md-2 control-label">Billing Address name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BillingAddressName" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BillingAddressName"
                CssClass="text-danger" ErrorMessage="The user address name field is required." />
        </div>

        <asp:Label runat="server" AssociatedControlID="BillingAddressNumber" CssClass="col-md-2 control-label">Billing Address No. </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BillingAddressNumber" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BillingAddressNumber"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />
        </div>


        <asp:Label runat="server" AssociatedControlID="BillingStair" CssClass="col-md-2 control-label">Stair </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BillingStair" CssClass="form-control" />
            <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="BillingStair"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>


        <asp:Label runat="server" AssociatedControlID="BillingApartment" CssClass="col-md-2 control-label">Apartment </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BillingApartment" CssClass="form-control" />
            <%--   <asp:RequiredFieldValidator runat="server" ControlToValidate="BillingApartment"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>



        <asp:Label runat="server" AssociatedControlID="BillingCity" CssClass="col-md-2 control-label">City</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BillingCity" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BillingCity"
                CssClass="text-danger" ErrorMessage="The user City field is required." />
        </div>


        <asp:Label runat="server" AssociatedControlID="BillingCountry" CssClass="col-md-2 control-label">Country</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BillingCountry" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BillingCountry"
                CssClass="text-danger" ErrorMessage="The user Country field is required." />
        </div>



        <asp:Label runat="server" AssociatedControlID="BillingZipcode" CssClass="col-md-2 control-label">Zipcode</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="BillingZipcode" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="BillingZipcode"
                CssClass="text-danger" ErrorMessage="The address zipcode field is required." />
        </div>


    </fieldset>
    <!--End user shipping address data-->

    <!--User Shipping address data-->
    <fieldset class="enterUserFieldset">
        <legend class="UserDataLegend">Shipping  address</legend>
        <asp:Label runat="server" AssociatedControlID="ShippingAddressName" CssClass="col-md-2 control-label">Shipping address name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ShippingAddressName" CssClass="form-control" />
            <%--  <asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressName"
                CssClass="text-danger" ErrorMessage="The user address name field is required." />--%>
        </div>


        <asp:Label runat="server" AssociatedControlID="ShippingAddressNumber" CssClass="col-md-2 control-label">Shipping address No. </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ShippingAddressNumber" CssClass="form-control" />
            <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressNumber"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>



        <asp:Label runat="server" AssociatedControlID="ShippingAddressStair" CssClass="col-md-2 control-label">Stair </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ShippingAddressStair" CssClass="form-control" />
            <%--        <asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressStair"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>


        <asp:Label runat="server" AssociatedControlID="ShippingAddressApartment" CssClass="col-md-2 control-label">Apartment </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ShippingAddressApartment" CssClass="form-control" />
            <%--            <asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressApartment"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>



        <asp:Label runat="server" AssociatedControlID="ShippingAddressCity" CssClass="col-md-2 control-label">City</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ShippingAddressCity" CssClass="form-control" />
            <%--            <asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressCity"
                CssClass="text-danger" ErrorMessage="The user City field is required." />--%>
        </div>




        <asp:Label runat="server" AssociatedControlID="ShippingAddressCountry" CssClass="col-md-2 control-label">Country</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ShippingAddressCountry" CssClass="form-control" />
            <%--           <asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressCountry"
                CssClass="text-danger" ErrorMessage="The user Country field is required." />--%>
        </div>



        <asp:Label runat="server" AssociatedControlID="ShippingAddressZipcode" CssClass="col-md-2 control-label">Zipcode</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ShippingAddressZipcode" CssClass="form-control" />
            <%--        <asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressZipcode"
                CssClass="text-danger" ErrorMessage="The user zipcode field is required." />--%>
        </div>

    </fieldset>
    <!--End user shipping address data-->


    <div class="col-md-offset-2 col-md-10">
        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
    </div>


</asp:Content>
