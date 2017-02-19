<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="app0.ViewProduct" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="topFullLength">
        <asp:ListView ID="lvProdDetail" runat="server" ItemPlaceholderID="phProdDetail" onitemdatabound="lvProdDetail_ItemDataBound">

            <LayoutTemplate>
                <div class="bigLeftOfTwoColumns">
                    <asp:PlaceHolder ID="phProdDetail" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>

            <ItemTemplate>
                <h3>
                    <asp:Literal ID="ltProdMan" runat="server"></asp:Literal>&nbsp;
                    <asp:Literal ID="ltProdName" runat="server"></asp:Literal>
                </h3>

                <asp:HyperLink ID="hlEnlargeImage" runat="server">
                    <asp:Image ID="imgProductMedium" AlternateText="Product Image" runat="server" />
                </asp:HyperLink>
                <p>
                    <asp:HyperLink ID="hlAddToCart1" CssClass="addToCart" runat="server">Add to cart!</asp:HyperLink>
                </p>
                <p>
                    <strong>Type: </strong>
                    <asp:Literal ID="ltModel" runat="server"></asp:Literal>
                </p>
                <p>
                    <strong>Price: &euro; </strong>
                    <asp:Literal ID="ltPrice" runat="server"></asp:Literal>
                </p>
                <p>
                    <asp:HyperLink ID="hlCategory" runat="server"></asp:HyperLink>
                </p>
                <p>
                    <strong>Items left in stock: </strong>
                    <asp:Literal ID="ltStock" runat="server"></asp:Literal>
                </p>
                <p>
                    <strong>Product description: </strong>
                    <asp:Literal ID="ltProdDesc" runat="server"></asp:Literal>
                </p>
                <p>
                    All stock products ship within 5 days, products we no longer have in stock might take up to 14 days.
                </p>

                <div class="whatdoyouwanttodo">
                    <p> 
                        <strong>What do you want to do?</strong>
                    </p>
                    <ul>
                        <li><asp:HyperLink ID="hlAddToCart2" runat="server">Add this product to cart</asp:HyperLink></li>
                        <li><a href="Search.aspx">Browse for more products</a></li>
                        <li><a href="javascript:history.go(-1)">Go back to the previous page</a></li>
                    </ul>
                </div>
            </ItemTemplate>

        </asp:ListView>
    </div>

    <div class="topFullLength">
        <asp:ListView ID="lvAlsoBought" runat="server" ItemPlaceholderID="phAlsoBought" onitemdatabound="lvAlsoBought_ItemDataBound">

            <LayoutTemplate>
                <div class="smallRightOfTwoColumns">
                    <h3>People who bought this also bought:</h3>
                    <asp:PlaceHolder ID="phAlsoBought" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="seperateItem">
                    <h4>
                        <asp:HyperLink ID="prod_link1" runat="server">
                        <asp:Literal ID="prod_man" runat="server"></asp:Literal>&nbsp;
                        <asp:Literal ID="prod_name" runat="server"></asp:Literal>
                        </asp:HyperLink>
                    </h4>
                    <div class="productThumb">
                        <asp:HyperLink ID="prod_link2" runat="server">
                            <asp:Image ID="prod_img" AlternateText="Product Image" runat="server" />
                        </asp:HyperLink>
                    </div>
                    <p>
                        <asp:Literal ID="prod_model" runat="server">Model: </asp:Literal><br />
                        <asp:Literal ID="prod_price" runat="server">Price: &euro; </asp:Literal><br />
                        <asp:HyperLink ID="addToCart" CssClass="addToCart" runat="server">Add to cart</asp:HyperLink>
                    </p>
                </div>  
            </ItemTemplate>

        </asp:ListView>
    </div>
</asp:Content>