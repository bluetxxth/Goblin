<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ProductManager.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Goblin.Secure.Staff.AddProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentCartCounter" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="server">

    <%--required to include ajax components--%>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit " TagPrefix="ajaxToolkit" %>

    <!--script manager for ajax-->
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>


    <ajaxToolkit:DropDownExtender ID="DropDownExtender1" runat="server" TargetControlID="DropDownAddCategory"></ajaxToolkit:DropDownExtender>


    <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" EnableSanitization="false" TargetControlID="AddProductDescription">
        <Toolbar>
            <ajaxToolkit:Undo />
            <ajaxToolkit:Redo />
            <ajaxToolkit:Bold />
            <ajaxToolkit:Italic />
            <ajaxToolkit:Underline />
            <ajaxToolkit:StrikeThrough />
            <ajaxToolkit:Subscript />
            <ajaxToolkit:Superscript />
            <ajaxToolkit:JustifyLeft />
            <ajaxToolkit:JustifyCenter />
            <ajaxToolkit:JustifyRight />
            <ajaxToolkit:JustifyFull />
            <ajaxToolkit:InsertOrderedList />
            <ajaxToolkit:InsertUnorderedList />
            <ajaxToolkit:CreateLink />
            <ajaxToolkit:UnLink />
            <ajaxToolkit:RemoveFormat />
            <ajaxToolkit:SelectAll />
            <ajaxToolkit:UnSelect />
            <ajaxToolkit:Delete />
            <ajaxToolkit:Cut />
            <ajaxToolkit:Copy />
            <ajaxToolkit:Paste />
            <ajaxToolkit:BackgroundColorSelector />
            <ajaxToolkit:ForeColorSelector />
            <ajaxToolkit:FontNameSelector />
            <ajaxToolkit:FontSizeSelector />
            <ajaxToolkit:Indent />
            <ajaxToolkit:Outdent />
            <ajaxToolkit:InsertHorizontalRule />
            <ajaxToolkit:HorizontalSeparator />
            <ajaxToolkit:InsertImage />
        </Toolbar>
    </ajaxToolkit:HtmlEditorExtender>

    <fieldset>
        <legend>Add Product</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblAddCategory" runat="server">Category:</asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownAddCategory" runat="server"
                        ItemType="Goblin.Model.Category"
                        SelectMethod="GetCategories" DataTextField="CategoryName"
                        DataValueField="CategoryID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddName" runat="server">Name:</asp:Label></td>
                <td>
                    <asp:TextBox ID="AddProductName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Product name required." ControlToValidate="AddProductName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddDescription" runat="server" Style="vertical-align: initial;">Description:</asp:Label></td>
                <td>
                    <p>
                        <asp:TextBox ID="AddProductDescription" runat="server" TextMode="MultiLine" Columns="100" Rows="20"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Description required." ControlToValidate="AddProductDescription" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                    </p>
                </td>
            </tr>
            <tr>

                <td>
                    <asp:Label ID="lblAddPrice" runat="server">Price:</asp:Label></td>
                <td>
                    <asp:TextBox ID="AddProductPrice" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Price required." ControlToValidate="AddProductPrice" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Must be a valid price without $." ControlToValidate="AddProductPrice" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddImageFile" runat="server">Image File:</asp:Label></td>
                <td>
                    <asp:FileUpload ID="ProductImage" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Image path required." ControlToValidate="ProductImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <p></p>
        <p></p>
        <asp:Button ID="AddProductButton" runat="server" Text="Add Product" OnClick="AddProductButton_Click" CausesValidation="true" />
        <asp:Label ID="lblAddStatus" runat="server" Text=""></asp:Label>
        <p></p>
        <h3>Remove Product:</h3>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblRemoveProduct" runat="server">Product:</asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownRemoveProduct" runat="server" ItemType="Goblin.Model.Product"
                        SelectMethod="GetProducts" AppendDataBoundItems="true"
                        DataTextField="ProductName" DataValueField="ProductID">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <p></p>
        <asp:Button ID="RemoveProductButton" runat="server" Text="Remove Product" OnClick="RemoveProductButton_Click" CausesValidation="false" />
        <asp:Label ID="lblRemoveStatus" runat="server" Text=""></asp:Label>

    </fieldset>


</asp:Content>
