<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="app0.Search" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="topFullLength">
        <h3>Product overview</h3>
        <p>
            Select a category of products which you are interested in. Use the search functionality on the top to look for a specific product.
            Manufacturer and category filters will be available to further narrow down the result (if needed).
        </p>
        <p>
            The shop that can deliver the cheapest product in the shortest possible timespan (having it in stock or not) gets selected as our best buy.
            As a result, it is not always goin to be the cheapest product that gets selected. We choose the one you'll have delivered the fastest at the lowest cost.
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
                <h3>Product Filters</h3>
                <p>
                    <asp:LinkButton runat="server" onclick="lbNoFilters_Click" ID="lbRemoveAllFilters">(Reset filters)</asp:LinkButton>
                </p>
                
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

                    <asp:panel ID="pShop1" runat="server">
                        <p>
                            <asp:Literal ID="priceShop1" runat="server" /> (at 
                            <asp:HyperLink ID="hlShop1" runat="server" Text="compuparts.notld"/>) 
                            <asp:Literal ID="ltShop1BestBuy" runat="server" Visible="false">Best Buy!</asp:Literal>
                        </p>
                    </asp:panel>

                    <asp:panel ID="pShop2" runat="server">  
                        <p>           
                            <asp:Literal ID="priceShop2" runat="server" /> (at 
                            <asp:HyperLink ID="hlShop2" runat="server" Text="underthehood.notld"/>) 
                            <asp:Literal ID="ltShop2BestBuy" runat="server" Visible="false">Best Buy!</asp:Literal>
                        </p>
                    </asp:panel>

                    <asp:panel ID="pShop3" runat="server">
                        <p>
                            <asp:Literal ID="priceShop3" runat="server" /> (at 
                            <asp:HyperLink ID="hlShop3" runat="server" Text="x-hardware.notld"/>) 
                            <asp:Literal ID="ltShop3BestBuy" runat="server" Visible="false">Best Buy!</asp:Literal>
                        </p>
                    </asp:panel>
                  
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
                        <asp:HyperLink ID="prod_link1F" runat="server">
                        <asp:Literal ID="prod_manF" runat="server"></asp:Literal>&nbsp;
                        <asp:Literal ID="prod_nameF" runat="server"></asp:Literal>
                        </asp:HyperLink>
                    </h4>

                    <div class="productThumb">
                        <asp:HyperLink ID="prod_link2F" runat="server">
                            <asp:Image ID="prod_imgF" AlternateText="Product Image" runat="server" />
                        </asp:HyperLink>
                    </div>

                    <asp:panel ID="pShop1F" runat="server">
                        <p>
                            <asp:Literal ID="priceShop1F" runat="server" /> (at 
                            <asp:HyperLink ID="hlShop1F" runat="server" Text="compuparts.notld"/>) 
                            <asp:Literal ID="ltShop1BestBuyF" runat="server" Visible="false">Best Buy!</asp:Literal>
                        </p>
                    </asp:panel>

                    <asp:panel ID="pShop2F" runat="server">  
                        <p>           
                            <asp:Literal ID="priceShop2F" runat="server" /> (at 
                            <asp:HyperLink ID="hlShop2F" runat="server" Text="underthehood.notld"/>) 
                            <asp:Literal ID="ltShop2BestBuyF" runat="server" Visible="false">Best Buy!</asp:Literal>
                        </p>
                    </asp:panel>

                    <asp:panel ID="pShop3F" runat="server">
                        <p>
                            <asp:Literal ID="priceShop3F" runat="server" /> (at 
                            <asp:HyperLink ID="hlShop3F" runat="server" Text="x-hardware.notld"/>) 
                            <asp:Literal ID="ltShop3BestBuyF" runat="server" Visible="false">Best Buy!</asp:Literal>
                        </p>
                    </asp:panel>
                  
                </div>
            </ItemTemplate>   
        </asp:ListView>
    </div>
</asp:Content>