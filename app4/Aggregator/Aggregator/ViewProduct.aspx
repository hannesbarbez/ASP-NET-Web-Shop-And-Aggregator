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
                    <asp:Literal ID="prod_man" runat="server"></asp:Literal>&nbsp;
                    <asp:Literal ID="prod_name" runat="server"></asp:Literal>
                </h3>

                
                <asp:HyperLink ID="hlEnlargeImage" runat="server">
                    <asp:Image ID="imgProductMedium" AlternateText="Product Image" runat="server" />
                </asp:HyperLink>
                
                <ul>
                    <asp:PlaceHolder ID="pShop1" runat="server">
                        <li>
                            <strong>
                                Buy for  
                                <asp:Literal ID="priceShop1" runat="server" /> at 
                                <asp:HyperLink ID="hlShop1" runat="server" Text="compuparts.notld"/>
                                <asp:Literal ID="ltShop1BestBuy" runat="server" Visible="false"> as it is our Best Buy!</asp:Literal>
                            </strong>
                            <br />
                            <asp:Literal ID="ltInfoShop1" runat="server">Compuparts.notld has </asp:Literal>
                        </li>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="pShop2" runat="server">  
                        <li>     
                            <strong>
                                Buy for        
                                <asp:Literal ID="priceShop2" runat="server" /> at 
                                <asp:HyperLink ID="hlShop2" runat="server" Text="underthehood.notld"/>
                                <asp:Literal ID="ltShop2BestBuy" runat="server" Visible="false"> as it is our Best Buy!</asp:Literal>
                            </strong>
                            <br />
                            <asp:Literal ID="ltInfoShop2" runat="server">Underthehood.notld has </asp:Literal>
                        </li>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="pShop3" runat="server">
                        <li>
                            <strong>
                                Buy for  
                                <asp:Literal ID="priceShop3" runat="server" /> at 
                                <asp:HyperLink ID="hlShop3" runat="server" Text="x-hardware.notld"/>
                                <asp:Literal ID="ltShop3BestBuy" runat="server" Visible="false"> as it is our Best Buy!</asp:Literal>
                            </strong>
                            <br />
                            <asp:Literal ID="ltInfoShop3" runat="server">X-hardware.notld has </asp:Literal>
                        </li>
                    </asp:PlaceHolder>
                </ul>

                <div class="whatdoyouwanttodo">
                <p> 
                    <strong>What do you want to do?</strong>
                </p>
                <ul>
                    <li><a href="Search.aspx">Browse for more products</a></li>
                    <li><a href="javascript:history.go(-1)">Go back to the previous page</a></li>
                </ul>
            </div>
            </ItemTemplate>

        </asp:ListView>
    </div>
</asp:Content>