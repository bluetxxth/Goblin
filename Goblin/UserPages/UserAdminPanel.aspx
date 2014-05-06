<%@ Page Title="User Panel" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="UserAdminPanel.aspx.cs" Inherits="Goblin.Secure.UserPagesSecured.UserAdminPanel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentCartCounter" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="server">

    <h1><%:Page.Title %></h1>

    <fieldset>
        <legend>User dersonal data</legend>

        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:GridView
            ID="gridUser"
            runat="server"
            AutoGenerateColumns="false"
            ShowFooter="true"
            CssClass="grid"
            OnRowCommand="gridUser_RowCommand"
            DataKeyNames=" Id"
            CellPadding="4"
            ForeColor="#000000"
            GridLines="None"
            OnRowCancelingEdit="gridUser_RowCancelingEdit"
            OnRowEditing="gridUser_RowEditing"
            OnRowDataBound="gridUser_RowDataBound"
            OnRowUpdating="gridUser_RowUpdating"
            Width ="900px">


            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField HeaderText="">

                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                            CommandArgument=''><img src="../Catalog/Images/GridView/edit.png" /></asp:LinkButton>

      
                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                            CommandArgument=''><img src="../Catalog/Images/GridView/edit.png" /></asp:LinkButton>


                        <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                            CommandArgument=''><img src="../Catalog/Images/GridView/cancel.png" /></asp:LinkButton>
                    </EditItemTemplate>
               
                    <FooterTemplate>
                     
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="First Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Bind("FirstName") %>' CssClass="" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valFirstName" runat="server" ControlToValidate="txtFirstName"
                            Display="Dynamic" ErrorMessage="First Name is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegFirstName" runat="server" ErrorMessage="Invalid first name" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtFirstName" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Middle Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMiddleName" runat="server" Text='<%# Bind("MiddleName") %>' CssClass="" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valMiddleName" runat="server" ControlToValidate="txtMiddleName"
                            Display="Dynamic" ErrorMessage="Middle Name is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegMiddleName" runat="server" ErrorMessage="Invalid middle name" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtMiddleName" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMiddleName" runat="server" Text='<%# Bind("MiddleName") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Last Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("LastName") %>' CssClass="" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valLastName" runat="server" ControlToValidate="txtLastName"
                            Display="Dynamic" ErrorMessage="Last Name is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegLastName" runat="server" ErrorMessage="Invalid last name" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtLastName" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="" MaxLength="30" Width ="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="Email is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valRegEmail" runat="server" ErrorMessage="Invalid Email" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtEmail" ForeColor="Red"
                            ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Telephone">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTelephone" runat="server" Text='<%# Bind("Telephone") %>' CssClass="" MaxLength="30" Width ="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valTelephone" runat="server" ControlToValidate="txtTelephone"
                            Display="Dynamic" ErrorMessage="Telephone is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valRegTelephone" runat="server" ErrorMessage="Invalid Telephone" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtTelephone" ForeColor="Red"
                            ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTelephone" runat="server" Text='<%# Bind("Telephone") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Cellphone">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCellphone" runat="server" Text='<%# Bind("CellPhone") %>' CssClass="" MaxLength="30" Width ="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valCell" runat="server" ControlToValidate="txtCellphone"
                            Display="Dynamic" ErrorMessage="Cell phone is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valRegCellphone" runat="server" ErrorMessage="Invalid Cell" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCellphone" ForeColor="Red"
                            ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCellphone" runat="server" Text='<%# Bind("CellPhone") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>

                <%--            <!--category-->
            <asp:TemplateField HeaderText="Category">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valCategory" runat="server" ControlToValidate="ddlCategory"
                        Display="Dynamic" ErrorMessage="Category is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category.Name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlCategoryNew" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valCategoryNew" runat="server" ControlToValidate="ddlCategoryNew"
                        Display="Dynamic" ErrorMessage="Category is required." ForeColor="Red" SetFocusOnError="True"
                        ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>--%>
            </Columns>
            <EditRowStyle BackColor="white" />
            <FooterStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />

        </asp:GridView>
    </fieldset>


    <fieldset>



         <!--CC data-->

        <!--Regex for cards-->

            <%-- ¨ ^(?:4[0-9]{12}(?:[0-9]{3})?  # Visa
             |  5[1-5][0-9]{14}                  # MasterCard
             |  3[47][0-9]{13}                   # American Express
             |  3(?:0[0-5]|[68][0-9])[0-9]{11}   # Diners Club
             |  6(?:011|5[0-9]{2})[0-9]{12}      # Discover
             |  (?:2131|1800|35\d{3})\d{11}      # JCB
            )$--%>

        <legend>User Credit card info</legend>

        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:GridView
            ID="gridCreditCard"
            runat="server"
            AutoGenerateColumns="false"
            ShowFooter="true"
            CssClass="grid"
            OnRowCommand="gridCreditCard_RowCommand"
            DataKeyNames=" Id"
            CellPadding="4"
            ForeColor="#000000"
            GridLines="None"
            OnRowCancelingEdit="gridCreditCard_RowCancelingEdit"
            OnRowEditing="gridCreditCard_RowEditing"
            OnRowDataBound="gridCreditCard_RowDataBound"
            OnRowUpdating="gridCreditCard_RowUpdating"
            Width ="900px">


            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField HeaderText="">

                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                            CommandArgument=''><img src="../Catalog/Images/GridView/edit.png" /></asp:LinkButton>

                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                            CommandArgument=''><img src="../Catalog/Images/GridView/edit.png" /></asp:LinkButton>


                        <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                            CommandArgument=''><img src="../Catalog/Images/GridView/cancel.png" /></asp:LinkButton>
                    </EditItemTemplate>

                    <FooterTemplate>
                 
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Card Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCardName" runat="server" Text='<%# Bind("CardName") %>' CssClass="" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valCardName" runat="server" ControlToValidate="txtCardName"
                            Display="Dynamic" ErrorMessage="Card Name is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegCardName" runat="server" ErrorMessage="Invalid card name" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCardName" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z'.\s]{1,40}$">*</asp:RegularExpressionValidator>


                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCardName" runat="server" Text='<%# Bind("CardName") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="CardNumber">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCardNumber" runat="server" Text='<%# Bind("CardNumber") %>' CssClass="" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valCardNumber" runat="server" ControlToValidate="txtCardNumber"
                            Display="Dynamic" ErrorMessage="Card number Name is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegCardNumber" runat="server" ErrorMessage="Invalid card number" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCardNumber" ForeColor="Red"
                            ValidationExpression="^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|6(?:011|5[0-9]{2})[0-9]{12}|(?:2131|1800|35\d{3})\d{11}#JCB)$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCardNumber" runat="server" Text='<%# Bind("CardNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="CardExpiryDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCardExpiryDate" runat="server" Text='<%# Bind("CardExpiryDate") %>' CssClass="" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valCardExpiryDate" runat="server" ControlToValidate="txtCardExpiryDate"
                            Display="Dynamic" ErrorMessage="Card expiry date is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="valRegCardExpiryDate" runat="server" ErrorMessage="Invalid card expiry date" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCardExpiryDate" ForeColor="Red"
                            ValidationExpression="(0[1-9]|1[0-2])\/[0-9]{2}">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCardExpiryDate" runat="server" Text='<%# Bind("CardExpiryDate") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="CardSecurityCode">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCardSecurityCode" runat="server" Text='<%# Bind("CardSecurityCode") %>' CssClass="" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valCardSecurityCode" runat="server" ControlToValidate="txtCardSecurityCode"
                            Display="Dynamic" ErrorMessage="Card security code is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valRegCardSecurityCode" runat="server" ErrorMessage="Invalid card security code" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCardSecurityCode" ForeColor="Red"
                            ValidationExpression="^[0-9]{3,4}$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCardSecurityCode" runat="server" Text='<%# Bind("CardSecurityCode") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>



            </Columns>
            <EditRowStyle BackColor="white" />
            <FooterStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />

        </asp:GridView>

    </fieldset>
    <!--End credit card info-->

    <!--Billing address info-->
    <fieldset>
        <legend>User's Billing Address</legend>
        <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:GridView
            ID="gridBillingAddress"
            runat="server"
            AutoGenerateColumns="false"
            ShowFooter="true"
            CssClass="grid"
            OnRowCommand="gridBillingAddress_RowCommand"
            DataKeyNames=" Id"
            CellPadding="4"
            ForeColor="#000000"
            GridLines="None"
            OnRowCancelingEdit="gridBillingAddress_RowCancelingEdit"
            OnRowEditing="gridBillingAddress_RowEditing"
            OnRowDataBound="gridBillingAddress_RowDataBound"
            OnRowUpdating="gridBillingAddress_RowUpdating"
            Width ="900px">


            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField HeaderText="">

                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                            CommandArgument=''><img src="../Catalog/Images/GridView/edit.png" /></asp:LinkButton>


                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                            CommandArgument=''><img src="../Catalog/Images/GridView/edit.png" /></asp:LinkButton>

                        <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                            CommandArgument=''><img src="../Catalog/Images/GridView/cancel.png" /></asp:LinkButton>

                    </EditItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBillingAddressName" runat="server" Text='<%# Bind("AddressName") %>' CssClass="" MaxLength="30" Width="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valBillingAddressName" runat="server" ControlToValidate="txtBillingAddressName"
                            Display="Dynamic" ErrorMessage="Billing address name is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="valRegBillingAddressName" runat="server" ErrorMessage="Invalid address name" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtBillingAddressName" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillingAddressName" runat="server" Text='<%# Bind("AddressName") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="No.">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBillingAddressNumber" runat="server" Text='<%# Bind("AddressNumber") %>' CssClass="" MaxLength="30" Width="20px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valBillingAddressNumber" runat="server" ControlToValidate="txtBillingAddressNumber"
                            Display="Dynamic" ErrorMessage="Billing address number Name is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                           <asp:RegularExpressionValidator ID="valRegBillingAddressNumber" runat="server" ErrorMessage="Invalid billing address number" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtBillingAddressNumber" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z0-9]{1,10}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillingAddressNumber" runat="server" Text='<%# Bind("AddressNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Stair">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBillingStair" runat="server" Text='<%# Bind("Stair") %>' CssClass="" MaxLength="30" Width="20px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valStair" runat="server" ControlToValidate="txtBillingStair"
                            Display="Dynamic" ErrorMessage="Stair is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegBillingStair" runat="server" ErrorMessage="Invalid Stair" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtBillingStair" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z0-9]{1,10}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillingStair" runat="server" Text='<%# Bind("Stair") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Apt">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBillingApartment" runat="server" Text='<%# Bind("Apartment") %>' CssClass="" MaxLength="30" Width ="20px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="valBillingApartment" runat="server" ControlToValidate="txtBillingApartment"
                            Display="Dynamic" ErrorMessage="Apartment required" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegBillingApartment" runat="server" ErrorMessage="Invalid Apartment" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtBillingApartment" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z0-9]{1,10}$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillingApartment" runat="server" Text='<%# Bind("Apartment") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="City">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBillingCity" runat="server" Text='<%# Bind("City") %>' CssClass="" MaxLength="30" Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valBillingCity" runat="server" ControlToValidate="txtBillingCity"
                            Display="Dynamic" ErrorMessage="City  is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegBillingCity" runat="server" ErrorMessage="Invalid billing city" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtBillingCity" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillingCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Country">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBillingCountry" runat="server" Text='<%# Bind("Country") %>' CssClass="" MaxLength="30" Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valBillingCountry" runat="server" ControlToValidate="txtBillingCountry"
                            Display="Dynamic" ErrorMessage="Billing country is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegBillingCountry" runat="server" ErrorMessage="Invalid Country" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtBillingCountry" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillingCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Zipcode">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBillingZipcode" runat="server" Text='<%# Bind("Apartment") %>' CssClass="" MaxLength="30" Width="60"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valBillingZipcode" runat="server" ControlToValidate="txtBillingZipcode"
                            Display="Dynamic" ErrorMessage="Billing zipcode is required." ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valRegBillingZipcode" runat="server" ErrorMessage="Invalid billing zipcode" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtBillingZipcode" ForeColor="Red"
                            ValidationExpression="^[0-9]{5}(?:-[0-9]{4})?$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillingZipcode" runat="server" Text='<%# Bind("Zipcode") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>



            </Columns>
            <EditRowStyle BackColor="white" />
            <FooterStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />

        </asp:GridView>

    </fieldset>


    <fieldset>
        <legend>User's Shipping Address</legend>
        <asp:GridView
            ID="gridShippingAddress"
            runat="server"
            AutoGenerateColumns="false"
            ShowFooter="true"
            CssClass="grid"
            OnRowCommand="gridShippingAddress_RowCommand"
            DataKeyNames=" Id"
            CellPadding="4"
            ForeColor="#000000"
            GridLines="None"
            OnRowCancelingEdit="gridShippingAddress_RowCancelingEdit"
            OnRowEditing="gridShippingAddress_RowEditing"
            OnRowDataBound="gridShippingAddress_RowDataBound"
            OnRowUpdating="gridShippingAddress_RowUpdating"
            Width ="900px">


            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField HeaderText="">

                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                            CommandArgument=''><img src="../Catalog/Images/GridView/edit.png" /></asp:LinkButton>

                        <%--  <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                        ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                        CommandArgument=''><img src="../Catalog/Images/GridView/delete.png" /></asp:LinkButton>--%>
                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                            CommandArgument=''><img src="../Catalog/Images/GridView/edit.png" /></asp:LinkButton>


                        <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                            CommandArgument=''><img src="../Catalog/Images/GridView/cancel.png" /></asp:LinkButton>
                    </EditItemTemplate>


                    <FooterTemplate>
                        <%--      <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Add New Entry"
                        CommandArgument=''><img src="../Catalog/Images/GridView/new.png" /></asp:LinkButton>--%>

                        <%--                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ToolTip="Cancel"
                        CommandArgument=''><img src="../Catalog/Images/GridView//cancel.png" /></asp:LinkButton>--%>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtShippingAddressName" runat="server" Text='<%# Bind("AddressName") %>' CssClass="" MaxLength="30" Width="100px"></asp:TextBox>


                        <asp:RegularExpressionValidator ID="valRegShippingAddressName" runat="server" ErrorMessage="Invalid shipping address" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtShippingAddressName" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingAddressName" runat="server" Text='<%# Bind("AddressName") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="No.">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtShippingAddressNo" runat="server" Text='<%# Bind("AddressNumber") %>' CssClass="" MaxLength="30" Width ="20px"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="valRegCardSecurityCode" runat="server" ErrorMessage="Invalid address No." ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtShippingAddressNo" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z0-9]{1,10}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingAddressNo" runat="server" Text='<%# Bind("AddressNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Stair">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtShippingStair" runat="server" Text='<%# Bind("Stair") %>' CssClass="" MaxLength="30" Width ="20px"></asp:TextBox>
      

                        <asp:RegularExpressionValidator ID="valRegShippingStair" runat="server" ErrorMessage="Invalid stair" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtShippingStair" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z0-9]{1,10}$">*</asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingStair" runat="server" Text='<%# Bind("Stair") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Apt">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtShippingApartment" runat="server" Text='<%# Bind("Apartment") %>' CssClass="" MaxLength="30" Width ="20px"></asp:TextBox>
     
                        <asp:RegularExpressionValidator ID="valRegShippingApartment" runat="server" ErrorMessage="Invalid apartment" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtShippingApartment" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z0-9]{1,10}$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingApartment" runat="server" Text='<%# Bind("Apartment") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="City">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtShippingCity" runat="server" Text='<%# Bind("City") %>' CssClass="" MaxLength="30" Width="60px"></asp:TextBox>
     
                        <asp:RegularExpressionValidator ID="valRegShippingCity" runat="server" ErrorMessage="Invalid city" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtShippingCity" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Country">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtShippingCountry" runat="server" Text='<%# Bind("Country") %>' CssClass="" MaxLength="30" Width="60px"></asp:TextBox>
     
                        <asp:RegularExpressionValidator ID="valRegShippingCountry" runat="server" ErrorMessage="Invalid country" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtShippingCountry" ForeColor="Red"
                            ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Zipcode">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtShippingZipcode" runat="server" Text='<%# Bind("Zipcode") %>' CssClass="" MaxLength="30" Width="60px"></asp:TextBox>
     
                        <asp:RegularExpressionValidator ID="valRegShippingZipcode" runat="server" ErrorMessage="Invalid zipcode" ValidationGroup="editGrp"
                            SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtShippingZipcode" ForeColor="Red"
                            ValidationExpression="^[0-9]{5}(?:-[0-9]{4})?$">*</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingZipcode" runat="server" Text='<%# Bind("Zipcode") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>



            </Columns>
            <EditRowStyle BackColor="white" />
            <FooterStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />

        </asp:GridView>

    </fieldset>

</asp:Content>
