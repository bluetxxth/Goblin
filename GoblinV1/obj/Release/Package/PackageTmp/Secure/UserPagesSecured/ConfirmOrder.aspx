<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ConfirmOrder.aspx.cs" Inherits="GoblinV1.UserPages.ConfirmOrder" %>
<%@ OutputCache Duration="15" VaryByParam="None" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

    <h1>Order Confirmation </h1>

    <asp:Repeater ID="rptConfirmOrder" runat="server">
        <ItemTemplate>
            <tr>
                <!--Customer Data-->
                <fieldset class="OrderConfirmationFieldset">
                    <legend class="OrderDataLegend">Customer Data</legend>
                    <td align="left" width="10%" runat="server" id="Td1">
                        <asp:Label ID="lblCustomerName" runat="server" Text="Name: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CustomerName" ,"{0:c}" )  %>
                        <br />
                    </td>

                    <td align="left" width="60%" runat="server" id="Td2">

                        <asp:Label ID="lblCustomerMiddle" runat="server" Text="Middle: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CustomerMiddle" ,"{0:c}" )  %>
                        <br />
                    </td>

                    <td align="left" width="60%" runat="server" id="Td3">
                        <asp:Label ID="lblCustomerLast" runat="server" Text="Last Name: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                        <br />
                    </td>

                    <td align="left" width="60%" runat="server" id="Td4">
                        <asp:Label ID="lblCustomerPhone" runat="server" Text="Phone: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CustomerPhone" ,"{0:c}" )  %>
                        <br />
                    </td>

                    <td align="left" width="60%" runat="server" id="Td5">
                        <asp:Label ID="lblCustomerCell" runat="server" Text="Cell Phone: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CustomerCell" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td6">
                        <asp:Label ID="lblCustomerEmail" runat="server" Text="Email: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CustomerEmail" ,"{0:c}" )  %>
                        <br />
                    </td>
                </fieldset>
                <!--End customer data-->

                <!--Address-->
                <fieldset class="OrderConfirmationFieldset">
                    <legend class="OrderDataLegend">Billing Address</legend>
                    <td align="left" width="60%" runat="server" id="Td7">
                        <asp:Label ID="lblBillAddrName" runat="server" Text="Street name: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("BillingAddressName" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td8">
                        <asp:Label ID="lblBillAddrNo" runat="server" Text="Street No.: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("BillingAddressNo" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td9">
                        <asp:Label ID="lblBillAddrApt" runat="server" Text="Apartment.: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("BillingApartment" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td10">
                        <asp:Label ID="lblBillAddrStair" runat="server" Text="Stair: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("BillingStair" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td11">
                        <asp:Label ID="BillAddrZip" runat="server" Text="Zip code: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("BillingZipCode" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td12">
                        <asp:Label ID="lblBillAddrCountry" runat="server" Text="Country: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("BillingCountry" ,"{0:c}" )  %>
                        <br />

                    </td>
                    <td align="left" width="60%" runat="server" id="Td13">
                        <asp:Label ID="lblBillAddrCity" runat="server" Text="Billing address city: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("BillingCity" ,"{0:c}" )  %>
                        <br />
                    </td>
                </fieldset>
                <!--End Billind address-->

                <fieldset class="OrderConfirmationFieldset">
                    <legend class="OrderDataLegend">Shipping Address</legend>
                    <td align="left" width="60%" runat="server" id="Td14">
                        <asp:Label ID="lblShippAdddrName" runat="server" Text="Street Name: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("ShippingAddressName" ,"{0:c}" )  %>
                        <br />

                    </td>
                    <td align="left" width="60%" runat="server" id="Td15">
                        <asp:Label ID="lblShippAddrsNo" runat="server" Text="Street No.: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("ShippingAddressNo" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td16">
                        <asp:Label ID="lblShppAddrApt" runat="server" Text="Apartment: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("ShippingApartment" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td17">
                        <asp:Label ID="lblShippAddrStair" runat="server" Text="Stair:" CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("ShippingStair" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td18">
                        <asp:Label ID="lblShippAddrZip" runat="server" Text="Zipcode: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("ShippingZipCode" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td19">
                        <asp:Label ID="lblShipAddrCountry" runat="server" Text="Country: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("ShippingCountry" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td20">
                        <asp:Label ID="lblShippAddrCity" runat="server" Text="City: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("ShippingCity" ,"{0:c}" )  %>
                        <br />
                    </td>
                </fieldset>
                <!--End shipping address-->

                <fieldset class="OrderConfirmationFieldset">
                    <legend class="OrderDataLegend">Credit Card info</legend>
                    <td align="left" width="60%" runat="server" id="Td21">
                        <asp:Label ID="lblCCardName" runat="server" Text="Credit card name: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CCardName" ,"{0:c}" )  %>
                        <br />
                    </td>

                    <td align="left" width="60%" runat="server" id="Td22">
                        <asp:Label ID="lblCCardNo" runat="server" Text="Credit card No.: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CCardNo" ,"{0:c}" )  %>
                        <br />
                    </td>

                    <td align="left" width="60%" runat="server" id="Td23">
                        <asp:Label ID="lblCCardExpiryDate" runat="server" Text="Credit card exppiry date: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CCardExpiryDate" ,"{0:c}" )  %>
                        <br />
                    </td>

                    <td align="left" width="60%" runat="server" id="Td24">
                        <asp:Label ID="lblCCArdSecCode" runat="server" Text="Credit card security code: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("CCardSecurityCode" ,"{0:c}" )  %>
                        <br />
                    </td>

                </fieldset>
                <!--End credit card data-->

                <fieldset class="OrderConfirmationFieldset">
                    <legend class="OrderDataLegend">Order Summary</legend>

                    <td align="left" width="60%" runat="server" id="Td25">
                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("Quantity")  %>
                        <br />

                    </td>

                    <td align="left" width="60%" runat="server" id="Td26">
                        <asp:Label ID="lblProductName" runat="server" Text="Product Name: " CssClass="lblOrderConfirmation">
                        </asp:Label><%# Eval("ProductName" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td27">
                        <asp:Label ID="lblProductPrice" runat="server" Text="Product price: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("ProductPrice" ,"{0:c}" )  %>
                        <br />
                    </td>
                    <td align="left" width="60%" runat="server" id="Td28">
                        <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("Subtotal" ,"{0:c}" )  %>
                        <br />
                    </td>

                    <td align="left" width="60%" runat="server" id="Td29">
                        <asp:Label ID="lblTotal" runat="server" Text="Total: " CssClass="lblOrderConfirmation">
                        </asp:Label>
                        <%# Eval("Total" ,"{0:c}" )  %>
                        <br />
                    </td>


                </fieldset>
                <!--End summary-->
            </tr>
        </ItemTemplate>
        <SeparatorTemplate>
            <tr>
                <td colspan="5">
                    <hr noshade="true" runat="server" id="Hr1" />
                </td>
            </tr>
        </SeparatorTemplate>
    </asp:Repeater>

    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>
