<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/app0.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app0._Default" %>

<asp:Content ID="contMid" ContentPlaceHolderID="cphMid" runat="Server">
    <div class="topFullLength">
        <h3>Compare prices and delivery</h3>
        <p>
            Welcome to Aggregato! Plug a keyword, manufacter or product name in the search field below. Or, browse through the categories and find your favorite product and start comparing!
        </p>
        <p>
            The shop that can deliver the cheapest product in the shortest possible timespan (having it in stock or not) gets selected as our best buy.
            As a result, it is not always goin to be the cheapest product that gets selected. We choose the one you'll have delivered the fastest at the lowest cost.
        </p>
    </div>
    <h3>Product Search</h3>
    <div class="search">
        <asp:Label ID="lblSearchD" AssociatedControlID="tbSearchD" runat="server" Text="Label">New search:</asp:Label>
        <asp:TextBox MaxLength="90" ID="tbSearchD" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearchD" runat="server" Text="Search" CausesValidation="false" onclick="btnSearch_Click" />
    </div>

    <div class="mainPageCategories">
        <h3>Browse categories</h3>
        <div class="categoryItem">
            <h4>
                <a href="Search.aspx?ucid=-1">All categories</a>
            </h4>

            <div class="CategoryThumb">
                <a href="Search.aspx?ucid=-1">
                    <img src="Images/allcats.jpg" class="noborder" alt="Category Image" />
                </a>
            </div>
        </div>

        <asp:ListView ID="lvMainPageCategories" runat="server" ItemPlaceholderID="phMainPageCategories" 
            onitemdatabound="lvMainPageCategories_ItemDataBound" >
            
            <LayoutTemplate>
                <asp:PlaceHolder ID="phMainPageCategories" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="categoryItem">
                    <h4>
                        <asp:HyperLink ID="cat_link1" runat="server">
                        <asp:Literal ID="cat_name" runat="server"></asp:Literal>
                        </asp:HyperLink>
                    </h4>

                    <div class="CategoryThumb">
                        <asp:HyperLink ID="cat_link2" runat="server">
                            <asp:Image ID="cat_img" CssClass="noborder" AlternateText="Category Image" runat="server" />
                        </asp:HyperLink>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>