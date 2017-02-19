<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="app0.Register" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">

    <div class="topFullLength">

        <h3>Register</h3>
        <p>
            Registered users benefit from faster service, as it is no longer mandatory for them to re-enter shipping information.
        </p>
        <p>
            Be sure to read our payment and privacy <a href="Policies.aspx">policies</a>.
        </p>
        <p>
            <strong>All fields are mandatory. </strong>Please don't use brackets or dashes etc., only digits are accepted when completing numeric (e.g. phone number) fields.
        </p>
    </div>

    <div class="topFullLength">
        <asp:Panel visible="false" ID="pError" runat="server">
            <h4>Error!</h4>
            <p>
                Someone else is already using this e-mailaddress. Please use a different e-mailaddress.
            </p>
        </asp:Panel>
    </div>

    <div class="formFields">
        <p>
            <asp:Label AssociatedControlID="tbName" ID="lName" runat="server">Name: </asp:Label>
            <asp:TextBox MaxLength="90" ID="tbName" Columns="30" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvName" runat="server" ControlToValidate="tbName" ErrorMessage="Your name is required."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Text="*" ID="revName" ControlToValidate="tbName" runat="server" ValidationExpression="[\w\s\-']+" ErrorMessage="Only letters, dashes and apostrophes can be used for your name."></asp:RegularExpressionValidator>
        </p>

        <p>
            <asp:Label AssociatedControlID="tbStreet" ID="lStreet" runat="server">Street name: </asp:Label>
            <asp:TextBox MaxLength="90" ID="tbStreet" Columns="30" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvStreet" runat="server" ControlToValidate="tbStreet" ErrorMessage="A street name is required."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Text="*" ID="revStreet" ControlToValidate="tbStreet" runat="server" ValidationExpression="[\w\s\-']+" ErrorMessage="Only letters, dashes and apostrophes can be used for a street name."></asp:RegularExpressionValidator>
        </p>

        <p>
            <asp:Label AssociatedControlID="tbHouse" ID="lHouse" runat="server">House number: </asp:Label>
            <asp:TextBox ID="tbHouse" MaxLength="6" Columns="30" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvHouse" runat="server" ControlToValidate="tbHouse" ErrorMessage="A house number is required."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Text="*" ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbHouse" ValidationExpression="[\d]+"  ErrorMessage="The house number may only contain numbers."></asp:RegularExpressionValidator>
        </p>

        <p>
            <asp:Label AssociatedControlID="tbPostal" ID="lPostal" runat="server">Postal code: </asp:Label>
            <asp:TextBox MaxLength="7" ID="tbPostal" Columns="30" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvPostal" runat="server" ControlToValidate="tbPostal" ErrorMessage="A postal code is required."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Text="*" ID="revPostal" runat="server" ControlToValidate="tbPostal" ValidationExpression="[\d]+"  ErrorMessage="The postal code may only contain numbers."></asp:RegularExpressionValidator>
        </p>

        <p>
            <asp:Label AssociatedControlID="tbCity" ID="lCity" runat="server">City: </asp:Label>
            <asp:TextBox MaxLength="30" ID="tbCity" Columns="30" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvCity" runat="server" ControlToValidate="tbCity" ErrorMessage="A city is required."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCity" ControlToValidate="tbCity"  Text="*" runat="server" ValidationExpression="[\w\s\-']+" ErrorMessage="Only letters, dashes and apostrophes can be used for a city name."></asp:RegularExpressionValidator>
        </p>
        <p>
            <asp:Label AssociatedControlID="ddlCountry" runat="server">Country: </asp:Label>
            <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="country" DataValueField="iso" />
        </p>
        <p id="phone">
            <asp:Label AssociatedControlID="tbPhone" ID="lPhone" runat="server">Phone number: </asp:Label>
            <asp:TextBox MaxLength="16" ID="tbPhone" Columns="30" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvPhone" runat="server" ControlToValidate="tbPhone" ErrorMessage="A phone number is required."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="tbPhone" ValidationExpression="[\d]+" Text="*" runat="server" ErrorMessage="The phone number field may only contain digits. Brackets, plusses or spaces are not allowed."></asp:RegularExpressionValidator>
        </p>

        <p>
            <asp:Label AssociatedControlID="tbEmail" ID="lEmail" runat="server">E-mail: </asp:Label>
            <asp:TextBox MaxLength="90" ID="tbEmail" Columns="30" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="An e-mail address is required."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Text="*" ID="revEmail" ControlToValidate="tbEmail" ValidationExpression="([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})" runat="server" ErrorMessage="Please enter a valid e-mail address."></asp:RegularExpressionValidator>
        </p>

        <p>
            <asp:Label AssociatedControlID="tbPassword" ID="lPassword" runat="server">Desired password: </asp:Label>
            <asp:TextBox ID="tbPassword" MaxLength="20" Columns="30" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="A password is required."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPassword" runat="server" Text="*" ValidationExpression="[\d\w\-\;\,\@\$\€\#\!\?\,\.]{6,}" ControlToValidate="tbPassword" ErrorMessage="Your desired password must be a minimum 6 characters in length and may only contain alphanumeric characters and -;,@$€#!?."></asp:RegularExpressionValidator>
        </p>

        <p>
            <asp:Label AssociatedControlID="tbReEnterPwd" ID="lbReEnterPwd" runat="server">Re-enter desired password: </asp:Label>
            <asp:TextBox ID="tbReEnterPwd" MaxLength="20" Columns="30" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator Text="*" ID="rfvReEnterPwd" runat="server" ControlToValidate="tbReEnterPwd" ErrorMessage="It is required to type in your desired password twice."></asp:RequiredFieldValidator>
            <asp:CompareValidator ControlToValidate="tbReEnterPwd" ControlToCompare="tbPassword" Text="*" Operator="Equal" ID="cvPassword" runat="server" ErrorMessage="The passwords do not match. They must be the same."></asp:CompareValidator>
        </p>
        
        <div id="buttons">
            <asp:Button ID="btnRegister" runat="server" Text="Register" onclick="btnRegister_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" CausesValidation="false" />
        </div>
    </div>
    
    <asp:ValidationSummary CssClass="validationErrors" ID="vsSummary" runat="server" />
    
</asp:Content>
