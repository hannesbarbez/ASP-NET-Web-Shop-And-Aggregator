<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="Policies.aspx.cs" Inherits="app0.OrderInfo" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="topFullLength">

        <h3>Payment policy and ordering</h3>
        <p>
            You need to be a <a href="Register.aspx">registered</a> customer before you can place any orders, so we know where and how to deliver.
        </p>
        <p>
            All stock products ship within 5 days, products we no longer have in stock might take up to 10 days.
        </p>
        <p>
            All listed product prices are incl. VAT and other taxes. You only pay what is advertised.
        </p>
        <p>
            The following methods of payment are accepted:
        </p>
        <ul>
            <li>By cash payment on delivery;</li>
            <li>By bank transfer no more than 5 days after delivery;</li>
        </ul>
        
        <h3>Privacy policy</h3>
        <p>
            Our privacy policy is really simple: we only use your data for shipping and ordering purposes, 
            we do not lend, sell or give your information to any third party.
        </p>
        <p>
            Feel free to <a href="Contact.aspx">contact</a> us should you have any further questions about these policies.
        </p>

     </div>
</asp:Content>