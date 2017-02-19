<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="LoggedOut.aspx.cs" Inherits="app0.LoggedOut" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">

    <div class="topFullLength">
        <h3>Logged off</h3>
        <p>
            You have been successfully logged off.
        </p>

        <p>
            Any unordered items that you may have had in your shopping cart have been cleared.
        </p>

        <div class="whatdoyouwanttodo">
            <p>
                <strong>What do you want to do now?</strong>
            </p>
            <ul>
                <li><a href="Login.aspx">Log In</a></li>
                <li><a href="Search.aspx">Browse our products</a></li>
            </ul>
        </div>
    </div>

</asp:Content>
