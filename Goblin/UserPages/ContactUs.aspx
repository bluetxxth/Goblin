<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Goblin.UserPages.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

  
    <asp:Panel ID="Panel1" runat="server">

        <h2>Contact form</h2>
        <p>
            In order to contact us please fill the form and send.&nbsp; At the end of the form
        there is a text area where you can povide the details of your inquiry. Please be
        concise and clear. We will try to contact you as soon as posible.
        </p>
        <fieldset id="contactForm">
            <legend>Contact form</legend>

            <div id="headings">
                <p>Name:</p>
                <p>Email Address:</p>
                <p>Subject:</p>
                <p>Message:</p>
            </div>


            <div id="inputFields">
                <p>
                    <asp:TextBox ID="txtName" runat="server" Width="190px"></asp:TextBox></p>
                <p>
                    <asp:TextBox ID="txtEmailAddress" runat="server" Width="193px"></asp:TextBox></p>
                <p>
                    <asp:TextBox ID="txtSubject" runat="server" Width="194px"></asp:TextBox></p>

            </div>


            <div id="textMessage">
                
                <asp:TextBox ID="txtMssgBody" TextMode="multiline" Columns="50" Rows="10" runat="server" CssClass ="textArea" />
                
            </div>
            

            <div id="buttonHolder">

                <asp:Button CssClass="btnContactMsgSend" ID="btnContactMsgSend" runat="server" Text="Send" OnClick="btnContactMsgSend_Click" />
                <asp:Button CssClass="btnContactMsgClear" ID="btnContactMsgClear" runat="server" Text="Clear" OnClick="btnContactMsgClear_Click" />
            </div>

        </fieldset>

    </asp:Panel>
</asp:Content>
