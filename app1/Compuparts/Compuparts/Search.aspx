<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="app0.Search" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="topFullLength">
        <h3>Product overview</h3>
        <p>
            Select a category of products which you are interested in. Use the search functionality at the top to look for a specific product.
            Price, manufacturer and category filters will be available to further narrow down the results if needed.
        </p>
    </div>

    <div class="leftOfTwoColumns">
        <div id="catNavBar">
            <h3>Product Categories</h3>
            <p>
                Show products in these categories:
            </p>
            <asp:BulletedList ID="blCatNavBar" runat="server" DataTextField="cat_name" DataValueField="cat_url" DisplayMode="HyperLink" />
        </div>
    
        <div class="topRow">
            <asp:Panel ID="pSearchFilters" Visible="false" runat="server">
                <h3>Search filters</h3>
                <div id="pricefilter">
                    <p>
                        <asp:LinkButton runat="server" onclick="lbNoFilters_Click" ID="lbRemoveAllFilters">(Reset all filters)</asp:LinkButton>
                    </p>
                    <strong><asp:label ID="lblFilterPrice" AssociatedControlID="rbFilterPrice" runat="server">Filter price: </asp:label></strong><br />
                    <asp:RadioButtonList ID="rbFilterPrice" runat="server" AutoPostBack="true" RepeatLayout="Flow">
                        <asp:ListItem Value="a" Text="Ascending" />
                        <asp:ListItem Value="d" Text="Descending" />
                    </asp:RadioButtonList>
                </div>
                
                <div id="manufacterfilter">
                    <strong><asp:label ID="lblMFilterMan" AssociatedControlID="ddlFilterManufacter" runat="server">Filter manufacter: </asp:label></strong>
                    <asp:DropDownList ID="ddlFilterManufacter" runat="server" DataTextField="man_name" DataValueField="man_id" AutoPostBack="true" />
                </div>
    
                <asp:Panel id="pFilterCategory" runat="server">
                    <strong><asp:label ID="lblFilterCat" AssociatedControlID="ddlFilterCategory" runat="server">Filter category: </asp:label></strong>
                    <asp:DropDownList ID="ddlFilterCategory" runat="server" DataTextField="cat_name" DataValueField="cat_id" AutoPostBack="true" />
                </asp:Panel>
            </asp:Panel>
        </div>
    </div>

    <div class="rightOfTwoColumns">
        <asp:PlaceHolder ID="phTitleSearchResults" Visible="false" runat="server">
            <h3>Search results</h3>
        </asp:PlaceHolder>
        <p>
            <strong><asp:Literal ID="ltStats" runat="server"></asp:Literal></strong>
        </p>
        <asp:PlaceHolder ID="phNoSearchResults" Visible="false" runat="server">
            <p>
                <strong>Please try again, using less or different keywords. Are there any spelling mistakes?</strong>
            </p>
        </asp:PlaceHolder>

        <asp:ListView ID="lvProducts" runat="server" ItemPlaceholderID="phProducts" onitemdatabound="lvProducts_ItemDataBound">
            <LayoutTemplate>
                <p>
                    A maximum of 10 results are displayed per page.
                </p>
                <asp:DataPager ID="dpProducts" visible="false" runat="server" PageSize="10">
                    <Fields>
                        <asp:NumericPagerField ButtonType="Link" NextPageText="Show more results..." />
                    </Fields>
                </asp:DataPager>
                <div id="searchResults">
                    <asp:PlaceHolder  ID="phProducts" runat="server"></asp:PlaceHolder>
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
        
    <div class="rightOfTwoColumns">
        <h3>Featured Products</h3>
        <asp:ListView ID="lvFeatProd" runat="server" ItemPlaceholderID="phFeatProd" onitemdatabound="lvFeatProd_ItemDataBound">
            <LayoutTemplate>
                <div id="featuredProducts">
                    <asp:PlaceHolder ID="phFeatProd" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="seperateItem">
                    <h4>
                        <asp:HyperLink ID="featProd_link1" runat="server">
                            <asp:Literal ID="featProd_man" runat="server"></asp:Literal>&nbsp;
                            <asp:Literal ID="featProd_name" runat="server"></asp:Literal>
                        </asp:HyperLink>
                    </h4>
                    <div class="productThumb">
                        <asp:HyperLink ID="featProd_link2" runat="server">
                            <asp:Image ID="featProd_img" AlternateText="Product Image" runat="server" />
                        </asp:HyperLink>
                    </div>

                    <p>
                        <asp:Literal ID="featProd_model" runat="server">Model: </asp:Literal><br />
                        <asp:Literal ID="featProd_price" runat="server">Price: &euro; </asp:Literal><br />
                        <asp:HyperLink ID="addToCart"  CssClass="addToCart" runat="server">Add to cart</asp:HyperLink>
                    </p>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>