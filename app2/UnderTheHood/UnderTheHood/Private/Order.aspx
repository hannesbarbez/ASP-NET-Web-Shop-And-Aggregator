<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" MasterPageFile= "~/app0.Master" CodeBehind="Order.aspx.cs" Inherits="app0.Private.Order" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="topFullLength">
        <h3>Thank you!</h3>
        <p>
            Your order has been registered. 
        </p>
        <p> 
            Please check your e-mail inbox for payment and delivery information.
        </p>
        <p>
            If you have any questions concerning your order, you can reply to that e-mail after having read our <a href="../Policies.aspx">policy information</a>.
        </p>
    </div>
</asp:Content>