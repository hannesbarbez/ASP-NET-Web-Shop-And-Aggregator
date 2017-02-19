<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app0._Default" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="topFullLength">
        <h3>Under The Hood Online</h3>
        <p>Welcome to Under The Hood, the best Belgian online shop when it comes to upgrade parts for your pc!</p>
        <p>
            Check out our <a href="Search.aspx">products</a> assortiment, where you'll get an overview of the products we currently have to offer.
            You can perform a <a href="Search.aspx">search</a> for specific products, and can buy directly via your very own <a href="ViewCart.aspx">shopping cart</a>.
        </p>
        <p>
            In order to shop, you must be <a href="Register.aspx">registered</a> and <a href="Login.aspx">logged in</a>. 
            <a href="Policies.aspx">Shipping &amp; handling</a> of your order commences virtually right after checkout.
        </p>
    </div>
    <div class="containsThreeColumns">
        <div class="leftColumn">
            <asp:ListView ID="lvBargain" runat="server" ItemPlaceholderID="phBargain" onitemdatabound="lvBargain_ItemDataBound">
            
                <LayoutTemplate>
                    <h3>Bargain Corner</h3>
                    <asp:PlaceHolder ID="phBargain" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="seperateItem">
                        <h4>
                            <asp:HyperLink ID="prod_link1B" runat="server">
                            <asp:Literal ID="prod_manB" runat="server"></asp:Literal>&nbsp;
                            <asp:Literal ID="prod_nameB" runat="server"></asp:Literal>
                            </asp:HyperLink>
                        </h4>
                        <div class="productThumb">
                            <asp:HyperLink ID="prod_link2B" runat="server">
                                <asp:Image ID="prod_imgB" AlternateText="Product Image" runat="server" />
                            </asp:HyperLink>
                        </div>

                        
                        <p>
                            <asp:Literal ID="prod_modelB" runat="server">Model: </asp:Literal>
                        </p>
                        <p>
                            <asp:Literal ID="prod_priceB" runat="server">Price: &euro; </asp:Literal>
                        </p>
                        <p>
                            <asp:HyperLink ID="addToCartB" CssClass="addToCart" runat="server">Add to cart</asp:HyperLink>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <div class="midColumn">
            <asp:ListView ID="lvTop" runat="server" 
                ItemPlaceholderID="phTop" onitemdatabound="lvTop_ItemDataBound">
                <LayoutTemplate>
                    <h3>Our Top Sellers</h3>
                    <asp:PlaceHolder ID="phTop" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>

                    <h4>
                        <asp:HyperLink ID="prod_link1T" runat="server">
                            <asp:Literal ID="prod_manT" runat="server"></asp:Literal>&nbsp;
                            <asp:Literal ID="prod_nameT" runat="server"></asp:Literal>
                        </asp:HyperLink>
                    </h4>

                    <div class="productThumb">
                        <asp:HyperLink ID="prod_link2T" runat="server">
                            <asp:Image ID="prod_imgT" AlternateText="Product Image" runat="server" />
                        </asp:HyperLink>
                    </div>

                    
                    <p>
                        <asp:Literal ID="prod_modelT" runat="server">Model: </asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="prod_priceT" runat="server">Price: &euro; </asp:Literal>
                    </p>
                    <p>
                        <asp:HyperLink ID="addToCartT"  CssClass="addToCart" runat="server">Add to cart</asp:HyperLink>
                    </p>

                </ItemTemplate>

            </asp:ListView>   
        </div>

        <div class="rightColumn">
            <asp:ListView ID="lvLatest" runat="server" 
                ItemPlaceholderID="phLatest" onitemdatabound="lvLatest_ItemDataBound">

                <LayoutTemplate>
                    <h3>Latest Products</h3>
                    <asp:PlaceHolder ID="phLatest" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>

                <ItemTemplate>
                    <h4>
                        <asp:HyperLink ID="prod_link1L" runat="server">
                            <asp:Literal ID="prod_manL" runat="server"></asp:Literal>&nbsp;
                            <asp:Literal ID="prod_nameL" runat="server"></asp:Literal>
                        </asp:HyperLink>
                    </h4>
                    <div class="productThumb">
                        <asp:HyperLink ID="prod_link2L" runat="server">
                            <asp:Image ID="prod_imgL" AlternateText="Product Image" runat="server" />
                        </asp:HyperLink>
                    </div>

                    <p>
                        <asp:Literal ID="prod_modelL" runat="server">Model: </asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="prod_priceL" runat="server">Price: &euro; </asp:Literal>
                    </p>
                    <p>
                        <asp:HyperLink ID="addToCartL" CssClass="addToCart" runat="server">Add to cart</asp:HyperLink>
                    </p>
                </ItemTemplate>

            </asp:ListView>   
        </div>
    </div>
</asp:Content>