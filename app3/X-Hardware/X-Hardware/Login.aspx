<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="app0.Login" %>

<%@ Register Assembly="app0" Namespace="app0.App_Logic" TagPrefix="cc1" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">

    <div class="topFullLength">
        <h3>1. Register</h3>
        <p>
            You must be <a href="Register.aspx">registered</a> (first-time only) in order to log in. Read <a href="Register.aspx">why</a>. 
        </p>
        <p>
            If you already registered here in the past, you can go straight to the following step.
        </p>
        <h3>2. Log In</h3>
        <p> 
            Once registered, you must log-in to be able to order. <strong>All fields are mandatory.</strong>            
        </p>

        <asp:Login ID="lLogin" DestinationPageUrl="~/LoggedIn.aspx" runat="server" onauthenticate="lLogin_Authenticate">
            <LayoutTemplate>
                <div class="login">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">E-mail address: </asp:Label>
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                        ControlToValidate="UserName" ErrorMessage="The e-mailaddress field is a required field." 
                        ToolTip="The e-mailaddress field is a required field." ValidationGroup="lLogin">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password: </asp:Label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                        ControlToValidate="Password" ErrorMessage="The password field is a required field." 
                        ToolTip="The password field is a required field." ValidationGroup="lLogin">*</asp:RequiredFieldValidator>
                    <br />
                    
                    <p>
                        <strong><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></strong>
                    </p>
                </div>
                <asp:CheckBox CssClass="left" ID="RememberMe" runat="server" />
                <asp:Label ID="lbRemember" AssociatedControlID="RememberMe" runat="server">Remember me</asp:Label><br />
                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="lLogin" />
            </LayoutTemplate>
        </asp:Login>
    </div>

</asp:Content>
