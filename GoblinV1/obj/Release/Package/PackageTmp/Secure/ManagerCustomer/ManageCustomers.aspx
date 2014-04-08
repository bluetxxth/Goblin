<%@ Page Title="Manage Customers" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="GoblinV1.Secure.Staff.ManageCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
        <h1><%:Page.Title %></h1>
    <fieldset>
        <legend><b>Mange Customers</b></legend>
    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

    <asp:GridView 
        ID="gridUser" 
        runat="server"
        AutoGenerateColumns ="false"
        ShowFooter ="true"
        CssClass ="grid"
        OnRowCommand ="gridUser_RowCommand"
        DataKeyNames = "Id"
        CellPadding ="4"
        ForeColor = "#333333"
        GridLines = "None"
        OnRowCancelingEdit ="gridUser_RowCancelingEdit"
        OnRowEditing="gridUser_RowEditing"
        OnRowDataBound ="gridUser_RowDataBound"
        OnRowDeleting="gridUser_RowDeleting"
        OnRowUpdating="gridUser_RowUpdating">
        

        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit" 
                                        CommandArgument=''><img src="../../Catalog/Images/GridView/show.png" /></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                                        ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                                        CommandArgument=''><img src="../../Catalog/Images/GridView/delete.png" /></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="editGrp" CommandName="Update" ToolTip="Save"
                                        CommandArgument=''><img src="../../Catalog/Images/GridView/save.png" /></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                        CommandArgument=''><img src="../../Catalog/Images/GridView/refresh.png" /></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Add New Entry"
                                        CommandArgument=''><img src="../../Catalog/Images/GridView/new.png" /></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ToolTip="Cancel"
                                        CommandArgument=''><img src="../../Catalog/Images/GridView/refresh.png" /></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="First Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Bind("FirstName") %>' CssClass="" MaxLength="30"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="valFirstName" runat="server" ControlToValidate="txtFirstName"
                                    Display="Dynamic" ErrorMessage="First name is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="valRegFirstName" runat="server" ErrorMessage="Invalid First name"   ValidationGroup="editGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtFirstName" ForeColor="Red"
                                    ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtFirstNameNew" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="valFirstNameNew" runat="server" ControlToValidate="txtFirstNameNew"
                                    Display="Dynamic" ErrorMessage="First Name is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="valRegFirstNameNew" runat="server" ErrorMessage="Invalid First name"   ValidationGroup="newGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtFirstNameNew" ForeColor="Red"
                                    ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>



                              <asp:TemplateField HeaderText="Middle Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMiddleName" runat="server" Text='<%# Bind("MiddleName") %>' CssClass="" MaxLength="30"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="valMiddleName" runat="server" ControlToValidate="txtMiddleName"
                                    Display="Dynamic" ErrorMessage="Middle Name is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="valRegMiddleName" runat="server" ErrorMessage="Invalid middle name"   ValidationGroup="editGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtMiddleName" ForeColor="Red"
                                    ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$*">*</asp:RegularExpressionValidator>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMiddleName" runat="server" Text='<%# Bind("MiddleName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtMiddleNameNew" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="valMiddleNameNew" runat="server" ControlToValidate="txtMiddleNameNew"
                                    Display="Dynamic" ErrorMessage="Middle name is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="valRegMiddleNameNew" runat="server" ErrorMessage="Invalid middle name"   ValidationGroup="newGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtMiddleNameNew" ForeColor="Red"
                                    ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>      


                            <asp:TemplateField HeaderText="Last Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("LastName") %>' CssClass="" MaxLength="30"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="valLastName" runat="server" ControlToValidate="txtLastName"
                                    Display="Dynamic" ErrorMessage="Email is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="valRegLastName" runat="server" ErrorMessage="Invalid Last name"   ValidationGroup="editGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtLastName" ForeColor="Red"
                                    ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtLastNameNew" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="valLastNameNew" runat="server" ControlToValidate="txtLastNameNew"
                                    Display="Dynamic" ErrorMessage="Email is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="valRegLastNameNew" runat="server" ErrorMessage="Invalid last name"   ValidationGroup="newGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtLastNameNew" ForeColor="Red"
                                    ValidationExpression="^[a-zåäö A-ZÅÄÖ' .\s]{1,40}$">*</asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="" MaxLength="30"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="Email is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="valRegEmail" runat="server" ErrorMessage="Invalid Email"   ValidationGroup="editGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtEmail" ForeColor="Red"
                                    ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?">*</asp:RegularExpressionValidator>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtEmailNew" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="valEmailNew" runat="server" ControlToValidate="txtEmailNew"
                                    Display="Dynamic" ErrorMessage="Email is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="valRegEmailNew" runat="server" ErrorMessage="Invalid Email"   ValidationGroup="newGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtEmailNew" ForeColor="Red"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>



                              <asp:TemplateField HeaderText="Telephone">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTelephone" runat="server" Text='<%# Bind("Telephone") %>' CssClass="" MaxLength="30"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="valTelephone" runat="server" ControlToValidate="txtTelephone"
                                    Display="Dynamic" ErrorMessage="Email is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="valRegTelephone" runat="server" ErrorMessage="Invalid Telephone"   ValidationGroup="editGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtTelephone" ForeColor="Red"
                                    ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$">*</asp:RegularExpressionValidator>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTelephone" runat="server" Text='<%# Bind("Telephone") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtTelephoneNew" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="valTelephoneNew" runat="server" ControlToValidate="txtEmailNew"
                                    Display="Dynamic" ErrorMessage="Telephone is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="valRegTelephoneNew" runat="server" ErrorMessage="Invalid Telephone"   ValidationGroup="newGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtTelephoneNew" ForeColor="Red"
                                    ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$">*</asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>


                               <asp:TemplateField HeaderText="CellPhone">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCellPhone" runat="server" Text='<%# Bind("CellPhone") %>' CssClass="" MaxLength="30"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="valCellPhone" runat="server" ControlToValidate="txtCellPhone"
                                    Display="Dynamic" ErrorMessage="Cell phone is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="editGrp">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="valRegCellPhone" runat="server" ErrorMessage="Invalid Cell phone"   ValidationGroup="editGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCellPhone" ForeColor="Red"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCellPhone" runat="server" Text='<%# Bind("CellPhone") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtCellPhoneNew" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="valCellPhoneNew" runat="server" ControlToValidate="txtCellPhoneNew"
                                    Display="Dynamic" ErrorMessage="Cell phone is required." ForeColor="Red" SetFocusOnError="True"
                                   ValidationGroup="newGrp">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="valRegCellPhoneNew" runat="server" ErrorMessage="Invalid Cell phone"   ValidationGroup="newGrp"
                                    SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtCellPhoneNew" ForeColor="Red"
                                    ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$">*</asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>

 
                          <%--   <asp:TemplateField HeaderText="Category">
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
                            </asp:TemplateField> --%>                        
                        </Columns>

        <EditRowStyle BackColor="#ffffff" />
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
