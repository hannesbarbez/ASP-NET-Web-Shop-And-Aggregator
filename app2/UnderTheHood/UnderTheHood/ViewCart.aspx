<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="app0.ViewCart" %>
<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">

    <div class="shopCart">
        <h3>Shopping Cart</h3>

        <asp:GridView runat="server" ID="gvShoppingCart" AutoGenerateColumns="false" DataKeyNames="ProductId" OnRowCommand="gvShoppingCart_RowCommand">
			<Columns>
				<asp:TemplateField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" HeaderText="Quantity">
					<ItemTemplate>
						<asp:TextBox runat="server" ID="txtQuantity" Columns="5" Text='<%# Eval("Quantity") %>'></asp:TextBox><br />
					</ItemTemplate>
				</asp:TemplateField>
                
                <asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="Manufacter" HeaderText="Manufacter" />
                <asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" HeaderText="Model">
                    <ItemTemplate>
                        <a href="ViewProduct.aspx?id=<%# Eval("ProductId") %>"><%# Eval("Model") %></a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="Stock" HeaderText="Items in stock" />
                <asp:BoundField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" HeaderText="Subtotal price">
                    <ItemTemplate>
                        &euro; <%# Convert.ToDouble(Eval("Quantity")) * Convert.ToDouble(Eval("UnitPrice")) %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-CssClass="tbHeader" ItemStyle-CssClass="tbItem" HeaderText="Options">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="removeButton" runat="server" ID="lbRemove" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("ProductId") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

			</Columns>
		</asp:GridView>
        <p id="totalPrice">
            <strong><asp:Literal runat="server" ID="ltTotalPrice" OnPreRender="ltTotalPrice_Prerender"></asp:Literal></strong><br />
            <asp:PlaceHolder ID="pNoProducts" runat="server">There are currently no products in your shopping cart.</asp:PlaceHolder>
        </p>
		<asp:Button runat="server" ID="btnUpdateCart" Text="Update Cart" OnClick="btnUpdateCart_Click" />

        <div class="whatdoyouwanttodo">
            <p>
                <strong>What do you want to do?</strong>
            </p>
            <ul>                
                <asp:Literal ID="ltCheckOut" runat="server"><li><a href="Private/Checkout.aspx">Continue to check out</a></li></asp:Literal>
                <li><a href="Search.aspx">Continue shopping</a></li>
                <li><a href="javascript:history.go(-1)">Go back to the previous page</a></li>
            </ul>
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
    </div>

</asp:Content>
