<%@ Page Title="User Data" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="EnterUserData.aspx.cs" Inherits="GoblinV1.UserPages.EnterUserData" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="server">


    <h1><%:Page.Title %></h1>


    <%--required to include ajax components--%>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit " TagPrefix="ajaxToolkit" %>

    <!--script manager for ajax-->
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

    <!--TextBoxWatermarkExtender-->
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID = "txtCardNumber" WatermarkText="enter valid card no." WatermarkCssClass ="watermarked"></ajaxToolkit:TextBoxWatermarkExtender>

    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID ="txtCardExpiryDate" WatermarkText ="xx/xx" WatermarkCssClass="watermarked"></ajaxToolkit:TextBoxWatermarkExtender>
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID ="txtCardSecurityCode" WatermarkText ="xxxx" WatermarkCssClass="watermarked"></ajaxToolkit:TextBoxWatermarkExtender>


    <asp:ValidationSummary runat="server" CssClass="text-danger" />

    <!-- user Personal data-->
    <fieldset class="enterUserFieldset">
        <legend class="UserDataLegend">User data</legend>

        <!--first name-->
        <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                CssClass="text-danger" ErrorMessage="First name field required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtFirstName" Display="Dynamic"></asp:RegularExpressionValidator>

        </div>

        <!--middle name-->
        <asp:Label runat="server" AssociatedControlID="txtMiddleName" CssClass="col-md-2 control-label">Middle Name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control" />

            <%--               <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMiddleName"
                CssClass="text-danger" ErrorMessage="Middle name field required." />--%>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtMiddleName"></asp:RegularExpressionValidator>


        </div>

        <!--last name-->
        <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label">Last name</asp:Label>
        <div class="col-md-10">

            <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                CssClass="text-danger" ErrorMessage="Last named field required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid input" ValidationExpression="^^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtLastName"></asp:RegularExpressionValidator>

        </div>

        <!--email-->
        <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                CssClass="text-danger" ErrorMessage="Email field required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid input" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>

        </div>

        <!--telephone-->
        <asp:Label runat="server" AssociatedControlID="txtTelephone" CssClass="col-md-2 control-label">Telephone</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtTelephone" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTelephone"
                CssClass="text-danger" ErrorMessage="Telephone field required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid input" ValidationExpression="^(1?(-?\d{3})-?)?(\d{3})(-?\d{4})$" ControlToValidate="txtTelephone"></asp:RegularExpressionValidator>

        </div>

        <asp:Label runat="server" AssociatedControlID="txtCellPhone" CssClass="col-md-2 control-label">Cellphone</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtCellPhone" CssClass="form-control" />


            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid input" ValidationExpression="^(1?(-?\d{3})-?)?(\d{3})(-?\d{4})$" ControlToValidate="txtCellPhone"></asp:RegularExpressionValidator>


            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="CellPhone"
                CssClass="text-danger" ErrorMessage="The user last name name field is required." />--%>
        </div>


    </fieldset>
    <!--end user personal data-->

    <!--Credit Card data-->
    <fieldset class="enterUserFieldset">
        <legend class="UserDataLegend">Credit Card info</legend>

        <!--CC data-->

        <!--Regex for cards-->

            <%-- ¨ ^(?:4[0-9]{12}(?:[0-9]{3})?  # Visa
             |  5[1-5][0-9]{14}                  # MasterCard
             |  3[47][0-9]{13}                   # American Express
             |  3(?:0[0-5]|[68][0-9])[0-9]{11}   # Diners Club
             |  6(?:011|5[0-9]{2})[0-9]{12}      # Discover
             |  (?:2131|1800|35\d{3})\d{11}      # JCB
            )$--%>

        <asp:Label runat="server" AssociatedControlID="txtCardName" CssClass="col-md-2 control-label">CardName</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtCardName" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCardName"
                CssClass="text-danger" ErrorMessage="Card name field required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ControlToValidate="txtCardName"></asp:RegularExpressionValidator>
        </div>

        <asp:Label runat="server" AssociatedControlID="txtCardNumber" CssClass="col-md-2 control-label">Card No.</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtCardNumber" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCardNumber"
                CssClass="text-danger" ErrorMessage="Card number field required." />

            <!--for visa-->
            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Invalid credit card number input" 
                ValidationExpression="^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|6(?:011|5[0-9]{2})[0-9]{12}|(?:2131|1800|35\d{3})\d{11}#JCB)$" 
    ControlToValidate="txtCardNumber"></asp:RegularExpressionValidator>

        </div>

        <asp:Label runat="server" AssociatedControlID="txtCardExpiryDate" CssClass="col-md-2 control-label">Expiry Date.</asp:Label>
        <div class="col-md-10">

            <asp:TextBox runat="server" ID="txtCardExpiryDate" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCardExpiryDate"
                CssClass="text-danger" ErrorMessage="Card Expiry date field required." />

            <!--"date" is MM/YY where YY is the year without century and MM is the month (from 01 to 12)-->
            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Invalid input MM/YY" ValidationExpression="(0[1-9]|1[0-2])\/[0-9]{2}" ControlToValidate="txtCardExpiryDate"></asp:RegularExpressionValidator>

        </div>

        <asp:Label runat="server" AssociatedControlID="txtCardSecurityCode" CssClass="col-md-2 control-label">Security Code</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtCardSecurityCode" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCardSecurityCode"
                CssClass="text-danger" ErrorMessage="Security code field  required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[0-9]{3,4}$" ControlToValidate="txtCardSecurityCode"></asp:RegularExpressionValidator>



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

        <!--Billing address name-->
        <asp:Label runat="server" AssociatedControlID="txtBillingAddressName" CssClass="col-md-2 control-label">Billing Address name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtBillingAddressName" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBillingAddressName"
                CssClass="text-danger" ErrorMessage="Address name field required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtBillingAddressName"></asp:RegularExpressionValidator>


        </div>

        <!--Billing address number-->
        <asp:Label runat="server" AssociatedControlID="txtBillingAddressNumber" CssClass="col-md-2 control-label">Billing Address No. </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtBillingAddressNumber" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBillingAddressNumber"
                CssClass="text-danger" ErrorMessage="Billing address number field  required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zA-Z0-9]{1,10}$" ControlToValidate="txtBillingAddressNumber"></asp:RegularExpressionValidator>

        </div>

        <!--stair-->
        <asp:Label runat="server" AssociatedControlID="txtBillingStair" CssClass="col-md-2 control-label">Stair </asp:Label>
        <div class="col-md-10">

            <asp:TextBox runat="server" ID="txtBillingStair" CssClass="form-control" />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zA-Z0-9]{1,10}$" ControlToValidate="txtBillingStair"></asp:RegularExpressionValidator>


            <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="BillingStair"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>

        <!--apartment-->
        <asp:Label runat="server" AssociatedControlID="txtBillingApartment" CssClass="col-md-2 control-label">Apartment </asp:Label>
        <div class="col-md-10">

            <asp:TextBox runat="server" ID="txtBillingApartment" CssClass="form-control" />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zA-Z0-9]{1,10}$" ControlToValidate="txtBillingApartment"></asp:RegularExpressionValidator>

            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="BillingApartment"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>

        <!--city-->
        <asp:Label runat="server" AssociatedControlID="txtBillingCity" CssClass="col-md-2 control-label">City</asp:Label>

        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtBillingCity" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBillingCity"
                CssClass="text-danger" ErrorMessage="The user City field is required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtBillingCity"></asp:RegularExpressionValidator>

        </div>

        <!--billing country-->
        <asp:Label runat="server" AssociatedControlID="txtBillingCountry" CssClass="col-md-2 control-label">Country</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtBillingCountry" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBillingCountry"
                CssClass="text-danger" ErrorMessage="The user Country field is required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtBillingCountry"></asp:RegularExpressionValidator>

        </div>

        <!--billing zipcode-->
        <asp:Label runat="server" AssociatedControlID="txtBillingZipcode" CssClass="col-md-2 control-label">Zipcode</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtBillingZipcode" CssClass="form-control" />

            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBillingZipcode"
                CssClass="text-danger" ErrorMessage="Zipcode field required." />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[0-9]{5}(?:-[0-9]{4})?$" ControlToValidate="txtBillingZipcode"></asp:RegularExpressionValidator>

        </div>


    </fieldset>
    <!--End user billing address data-->

    <!--User Shipping address data-->
    <fieldset class="enterUserFieldset">
        <legend class="UserDataLegend">Billing address</legend>

        <!--Shipping address name-->
        <asp:Label runat="server" AssociatedControlID="txtShippingAddressName" CssClass="col-md-2 control-label">Billing Address name</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtShippingAddressName" CssClass="form-control" />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtShippingAddressName"></asp:RegularExpressionValidator>

            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressName"
                CssClass="text-danger" ErrorMessage="Address name field required." />--%>
        </div>

        <!--Shipping address number-->
        <asp:Label runat="server" AssociatedControlID="txtShippingAddressNumber" CssClass="col-md-2 control-label">Billing Address No. </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtShippingAddressNumber" CssClass="form-control" />


            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zA-Z0-9]{1,10}$" ControlToValidate="txtShippingAddressNumber"></asp:RegularExpressionValidator>

            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingAddressNumber"
                CssClass="text-danger" ErrorMessage="Billing address number field  required." />--%>
        </div>

        <!--Shipping stair-->
        <asp:Label runat="server" AssociatedControlID="txtShippingAddressStair" CssClass="col-md-2 control-label">Stair </asp:Label>
        <div class="col-md-10">

            <asp:TextBox runat="server" ID="txtShippingAddressStair" CssClass="form-control" />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zA-Z0-9]{1,10}$" ControlToValidate="txtShippingAddressStair"></asp:RegularExpressionValidator>


            <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingStair"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>

        <!--Shipping apartment-->
        <asp:Label runat="server" AssociatedControlID="txtShippingAddressApartment" CssClass="col-md-2 control-label">Apartment </asp:Label>
        <div class="col-md-10">

            <asp:TextBox runat="server" ID="txtShippingAddressApartment" CssClass="form-control" />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zA-Z0-9]{1,10}$" ControlToValidate="txtShippingAddressApartment"></asp:RegularExpressionValidator>

            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingApartment"
                CssClass="text-danger" ErrorMessage="The user address No. field is required." />--%>
        </div>

        <!--Shipping city-->
        <asp:Label runat="server" AssociatedControlID="txtShippingAddressCity" CssClass="col-md-2 control-label">City</asp:Label>

        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtShippingAddressCity" CssClass="form-control" />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtShippingAddressCity"></asp:RegularExpressionValidator>

            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingCity"
                CssClass="text-danger" ErrorMessage="The user City field is required." />--%>
        </div>

        <!--Shippingcountry-->
        <asp:Label runat="server" AssociatedControlID="txtShippingAddressCountry" CssClass="col-md-2 control-label">Country</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtShippingAddressCountry" CssClass="form-control" />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$" ControlToValidate="txtShippingAddressCountry"></asp:RegularExpressionValidator>

            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="BillingCountry"
                CssClass="text-danger" ErrorMessage="The user Country field is required." />--%>
        </div>

        <!--Shipping zipcode-->
        <asp:Label runat="server" AssociatedControlID="txtShippingAddressZipcode" CssClass="col-md-2 control-label">Zipcode</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtShippingAddressZipcode" CssClass="form-control" />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ErrorMessage="Invalid input" ValidationExpression="^[0-9]{5}(?:-[0-9]{4})?$" ControlToValidate="txtShippingAddressZipcode"></asp:RegularExpressionValidator>

            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ShippingZipcode"
                CssClass="text-danger" ErrorMessage="Zipcode field required." />--%>
        </div>


    </fieldset>
    <!--End user shipping address data-->



    <div class="col-md-offset-2 col-md-10">
        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
    </div>


</asp:Content>
