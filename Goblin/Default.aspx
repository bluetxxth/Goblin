<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Goblin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">

    <h1><%:Page.Title %>  </h1>


    <%--required to include ajax components--%>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit " TagPrefix="ajaxToolkit" %>

    <!--script manager for ajax-->
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

   <!--timer-->
    <div id="timer">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>

                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="500">
                </asp:Timer>

                <asp:Label ID="lblCurrentTime" runat="server" Text=" "></asp:Label>

            </ContentTemplate>

        </asp:UpdatePanel>
    </div>

   
    <br/>
    <article class="justify border" style="width: 90%">
        Pellentesque dapibus turpis non tortor ullamcorper ornare sed sit amet sem. Mauris enim turpis, semper sed accumsan eu, pellentesque eget lacus. Ut tincidunt lacinia urna, eget sollicitudin ante mollis eu. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis non justo ac est rutrum vestibulum mollis ac enim. Maecenas ut justo mi, non bibendum risus. Phasellus magna metus, feugiat id dignissim ac, ultricies id lectus. Sed viverra consectetur magna, in dignissim neque convallis vitae. Nunc id ante nec dolor luctus luctus. Phasellus lacinia euismod dolor, nec posuere leo eleifend non. Mauris lectus felis, vestibulum sit amet condimentum sit amet, aliquam non nibh. 


        Pellentesque dapibus turpis non tortor ullamcorper ornare sed sit amet sem. Mauris enim turpis, semper sed accumsan eu, pellentesque eget lacus. Ut tincidunt lacinia urna, eget sollicitudin ante mollis eu. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis non justo ac est rutrum vestibulum mollis ac enim. Maecenas ut justo mi, non bibendum risus. Phasellus magna metus, feugiat id dignissim ac, ultricies id lectus. Sed viverra consectetur magna, in dignissim neque convallis vitae. Nunc id ante nec dolor luctus luctus. Phasellus lacinia euismod dolor, nec posuere leo eleifend non. Mauris lectus felis, vestibulum sit amet condimentum sit amet, aliquam non nibh. 


        Pellentesque dapibus turpis non tortor ullamcorper ornare sed sit amet sem. Mauris enim turpis, semper sed accumsan eu, pellentesque eget lacus. Ut tincidunt lacinia urna, eget sollicitudin ante mollis eu. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis non justo ac est rutrum vestibulum mollis ac enim. Maecenas ut justo mi, non bibendum risus. Phasellus magna metus, feugiat id dignissim ac, ultricies id lectus. Sed viverra consectetur magna, in dignissim neque convallis vitae. Nunc id ante nec dolor luctus luctus. Phasellus lacinia euismod dolor, nec posuere leo eleifend non. Mauris lectus felis, vestibulum sit amet condimentum sit amet, aliquam non nibh. 

    </article>

</asp:Content>
