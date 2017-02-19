<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" MasterPageFile="~/app0.Master" CodeBehind="WantsToLogOut.aspx.cs" Inherits="app0.WantsToLogOut" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">

    <div class="topFullLength">
        <h3>Logging off</h3>
        <p>
            By doing so, any unordered items you may have in your shopping cart will be erased.
        </p>
        <div class="whatdoyouwanttodo">
            <p>
                <strong>Are you sure you want to log off?</strong>
            </p>
            <ul>
                <li><asp:LinkButton CausesValidation="false" ID="lbLogOut" runat="server" onclick="LogOut_Click">Log off</asp:LinkButton></li>
                <li><a href="javascript:history.go(-1)">Go back to the previous page</a></li>
            </ul>
        </div>
    </div>

</asp:Content>
