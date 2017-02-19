<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="LoggedIn.aspx.cs" Inherits="app0.LoggedIn" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="topFullLength">
        <h3>Logged in</h3>

        <p>
            You have been successfully logged in.
        </p>

        <div class="whatdoyouwanttodo">
            <p>
                <strong>What do you want to do now?</strong>
            </p>
            <ul>
                <li><a href="Search.aspx">Continue browsing for products</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
