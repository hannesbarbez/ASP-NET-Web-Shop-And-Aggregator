<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="app0.ThankYou" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    
    <div class="topFullLength">
        <h3>Thank You!</h3>

        <p>
            You have been successfully registered. And for convenience purposes, we have already logged you in with your new account!
        </p>

        <div class="whatdoyouwanttodo">
            <p>
                <strong>What do you want to do now?</strong>
            </p>
            <ul>
                <li><a href="Search.aspx">Continue shopping</a></li>
                <li><a href="ViewCart.aspx">View or modify the contents of your shopping cart</a></li>
            </ul>
        </div>
    </div>

</asp:Content>
