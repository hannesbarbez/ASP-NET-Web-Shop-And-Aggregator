<%@ Page Language="C#" ValidateRequest="false" MasterPageFile= "~/app0.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="app0.Private.Checkout" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="shopCart">
        <h3>Check out</h3>

        <h4>Overview</h4>
        <p>
            Thank you for placing your order with us. Please review our following offer. Are you sure these are the items and quantities you wish to order?
        </p>

        <h4>Offer</h4>

        <asp:GridView runat="server" ID="gvShoppingCart" AutoGenerateColumns="false" DataKeyNames="ProductId">
			<Columns>
                <asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="Quantity" HeaderText="Quantity" />
				<asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="Manufacter" HeaderText="Manufacter" />
				<asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="Name" HeaderText="Name" />
                <asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="Model" HeaderText="Model" />
                <asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="Stock" HeaderText="Items in stock" />
                <asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" HeaderText="Subtotal price">
                    <ItemTemplate>
                        &euro; <%# Convert.ToDouble(Eval("Quantity")) * Convert.ToDouble(Eval("UnitPrice")) %>
                    </ItemTemplate>
                </asp:TemplateField>
			</Columns>
		</asp:GridView>
        <p>
            <strong><asp:Literal runat="server" ID="ltTotalPrice" OnPreRender="ltTotalPrice_Prerender"></asp:Literal></strong>
        </p>
    </div>
    
    <div class="topFullLength">
        <div class="whatdoyouwanttodo">
            <p>
                <strong>What do you want to do?</strong>
            </p>
            <ul> 
                <li><a href="Order.aspx">Check out</a></li>
                <li><a href="../ViewCart.aspx">Edit shopping cart</a></li>
                <li><a href="../Search.aspx">Continue shopping</a></li>
            </ul>
        </div>
    </div>   
     
    <div class="topFullLength">
        <h4>Delivery</h4>
        <p>
            All stock products ship within 7 days, products we no longer have in stock might take up to 10 days.
        </p>

        <h4>Payment</h4>
        <p>
            The following methods of payment are accepted:
        </p>
        <ul>
            <li>By cash payment on delivery;</li>
            <li>By bank transfer no more than 5 days after delivery;</li>
        </ul>
    </div>


</asp:Content>