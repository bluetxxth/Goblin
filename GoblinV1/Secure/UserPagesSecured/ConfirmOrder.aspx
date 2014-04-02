<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ConfirmOrder.aspx.cs" Inherits="GoblinV1.UserPages.ConfirmOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

    <h1>Order Confirmation </h1>

    <asp:Repeater ID="rptConfirmOrder"  runat="server">
        <ItemTemplate>
            <tr>
                <td align="left" width="10%" runat="server" id="Td1">
                    <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name: ">
                        <%# Eval("CustomerName" ,"{0:c}" )  %>
                    </asp:Label>
                    <br />
                </td>
                <td align="left" width="60%" runat="server" id="Td2">

                    <asp:Label ID="lblCustomerMiddle" runat="server" Text="Customer Middle: ">
                        <%# Eval("CustomerMiddle" ,"{0:c}" )  %>
                    </asp:Label>
                    <br />

                    <asp:Label ID="lblCustomerLast" runat="server" Text="Customer Last Name: ">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br />

                    <asp:Label ID="Label1" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label2" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label3" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label4" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label5" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label6" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label7" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label8" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label9" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label10" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label11" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label12" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label13" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label14" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label15" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label16" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>

                    <asp:Label ID="Label17" runat="server" Text="Label">
                        <%# Eval("Customerlast" ,"{0:c}" )  %>
                    </asp:Label>
                    <br/>




                </td>
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
