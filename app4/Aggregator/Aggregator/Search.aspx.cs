using System;
using System.Linq;
using System.Web.UI.WebControls;
using app0.App_Data;
using app0.App_Logic;
using System.Collections.Generic;

namespace app0
{
    public partial class Search : System.Web.UI.Page
    {
        private int howManyResults = 0;

        #region Initializers
        
        protected void Page_Init(object sender, EventArgs e)
        {
            Session["mainPage"] = "products";
            Session["subPage"] = "productsHome";
            Session.Remove("ucid");

            InitBlCatNavBar();
            InitDdlFilterCategory();
            InitDdlFilterManufacter();
            InitLvFeatProd();

            if (null != Request.QueryString["ucid"])
            {
                int i;
                string s = Server.HtmlDecode(Request.QueryString["ucid"].ToString());
                Int32.TryParse(s, out i);
                Session["ucid"] = i;
            }
        }

        private void InitBlCatNavBar()
        {
            AggDataContext db = new AggDataContext();

            var v = db.AggCategories.OrderBy(c => c.cat_name);

            blCatNavBar.DataSource = LoadCategoriesForLinks();
            blCatNavBar.DataBind();
            blCatNavBar.Items.Insert(0, new ListItem("All Categories", "Search.aspx?ucid=-1"));
        }

        protected void lbNoFilters_Click(object sender, EventArgs e)
        {
            int i = GetUcid();
            if (i > 0) Response.Redirect("Search.aspx?ucid=" + i);
            else Response.Redirect("Search.aspx");
        }

        private void InitDdlFilterCategory()
        {
            AggDataContext db = new AggDataContext();

            ddlFilterCategory.DataSource = db.AggCategories.Select(c => c).OrderBy(c => c.cat_name);
            ddlFilterCategory.DataBind();
            ddlFilterCategory.Items.Insert(0, new ListItem("All Categories", "0"));
        }

        private void InitDdlFilterManufacter()
        {
            AggDataContext db = new AggDataContext();

            ddlFilterManufacter.DataSource = db.AggManufacters.Select(m => m).OrderBy(m => m.man_name);
            ddlFilterManufacter.DataBind();
            ddlFilterManufacter.Items.Insert(0, new ListItem("All Manufacters", "0"));
        }

        private void InitLvFeatProd()
        {
            AggDataContext db = new AggDataContext();
            lvFeatProd.DataSource = (from p in db.AggProducts
                                    orderby db.Random()
                                    select p).Take(4);
            lvFeatProd.DataBind();
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            ShowSearchResults();
        }

        #endregion

        #region Helper Methods

        private void ShowOrHideControls()
        {
            phTitleSearchResults.Visible = true;

            if (howManyResults == 0)
            {
                phNoSearchResults.Visible = true;
            }
            else
            {
                if (howManyResults < 11)
                {
                    
                }
                phNoSearchResults.Visible = false;
                pSearchFilters.Visible = true;
            }
        }

        private object LoadCategoriesForLinks()
        {
            AggDataContext db = new AggDataContext();
            return from c in db.AggCategories
                   orderby c.cat_name
                   select new { cat_url = "Search.aspx?ucid=" + c.cat_id, cat_name = c.cat_name };
        }

        /// <summary>
        /// Checks if given ucid (Unsorting Category ID) is a valid integer, selected through URL
        /// It also removes its source.
        /// </summary>
        /// <returns>0 for invalid category, otherwise positive int representing the category id</returns>
        private int GetUcid()
        {
            int ucid = 0;

            if (null != Session["ucid"])
            {
                string u = Session["ucid"].ToString();
                Int32.TryParse(u, out ucid);
            }
            return ucid;
        }

        /// <summary>
        /// Gets Sorting Category ID, selected as part of the search filter
        /// </summary>
        /// <returns>0 for all categories, otherwise positive int representing the category id</returns>
        private int GetCid()
        {
            return Int32.Parse(ddlFilterCategory.SelectedItem.Value);
        }

        private int GetMid()
        {
            return Int32.Parse(ddlFilterManufacter.SelectedItem.Value);
        }

        /// <summary>
        /// Looks if there was a search query and returns it if so
        /// </summary>
        /// <returns>Searched string if any, otherwise empty string</returns>
        private string GetSearchString()
        {
            string itemToSearch = "";
            if (null != Session.Contents["searchQuery"]) itemToSearch = Server.HtmlDecode(Session["searchQuery"].ToString());
            else Session["searchQuery"] = String.Empty;
            bool ValidStringQuery = !String.IsNullOrEmpty(itemToSearch);
            return itemToSearch;
        }

        #endregion

        #region After Databinding

        protected void lvProducts_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            AggProduct p = (AggProduct)dataItem.DataItem;
            StoreComparer comparer = new StoreComparer(p);
            string img_format = "s.jpg";

            HyperLink prod_link1 = (HyperLink)e.Item.FindControl("prod_link1");
            HyperLink prod_link2 = (HyperLink)e.Item.FindControl("prod_link2");
            Literal prod_man = (Literal)e.Item.FindControl("prod_man");
            Literal prod_name = (Literal)e.Item.FindControl("prod_name");
            Literal priceShop1 = (Literal)e.Item.FindControl("priceShop1");
            Literal priceShop2 = (Literal)e.Item.FindControl("priceShop2");
            Literal priceShop3 = (Literal)e.Item.FindControl("priceShop3");
            Literal ltShop1BestBuy = (Literal)e.Item.FindControl("ltShop1BestBuy");
            Literal ltShop2BestBuy = (Literal)e.Item.FindControl("ltShop2BestBuy");
            Literal ltShop3BestBuy = (Literal)e.Item.FindControl("ltShop3BestBuy");
            HyperLink hlShop1 = (HyperLink)e.Item.FindControl("hlShop1");
            HyperLink hlShop2 = (HyperLink)e.Item.FindControl("hlShop2");
            HyperLink hlShop3 = (HyperLink)e.Item.FindControl("hlShop3");
            Image prod_img = (Image)e.Item.FindControl("prod_img");
            DataPager dpProducts = (DataPager)lvProducts.FindControl("dpProducts");
            Panel pShop1 = (Panel)e.Item.FindControl("pShop1");
            Panel pShop2 = (Panel)e.Item.FindControl("pShop2");
            Panel pShop3 = (Panel)e.Item.FindControl("pShop3");

            prod_link1.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;
            prod_link2.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            prod_man.Text = p.AggManufacter.man_name;
            prod_name.Text = p.prod_name;

            priceShop1.Text += "&euro; " + comparer.CpPrice;
            priceShop2.Text += "&euro; " + comparer.UthPrice;
            priceShop3.Text += "&euro; " + comparer.XhPrice;

            hlShop1.NavigateUrl = "localhost/app1/ViewProduct.aspx?id=" + p.cp_id;
            hlShop2.NavigateUrl = "localhost/app2/ViewProduct.aspx?id=" + p.uth_id;
            hlShop3.NavigateUrl = "localhost/app3/ViewProduct.aspx?id=" + p.xh_id;

            prod_img.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id + img_format;
            dpProducts.Visible = (howManyResults > dpProducts.PageSize);

            if (comparer.CpPrice < 0) pShop1.Visible = false;
            if (comparer.UthPrice < 0) pShop2.Visible = false;
            if (comparer.XhPrice < 0) pShop3.Visible = false;

            ltShop1BestBuy.Visible = comparer.CpIsBestBuy;
            ltShop2BestBuy.Visible = comparer.UthIsBestBuy;
            ltShop3BestBuy.Visible = comparer.XhIsBestBuy;

            if (comparer.CpIsBestBuy) pShop1.CssClass = "bestbuy";
            else if (comparer.UthIsBestBuy) pShop2.CssClass = "bestbuy";
            else if (comparer.XhIsBestBuy) pShop3.CssClass = "bestbuy";
        }

        protected void lvFeatProd_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            AggProduct p = (AggProduct)dataItem.DataItem;
            StoreComparer comparer = new StoreComparer(p);
            string img_format = "s.jpg";

            HyperLink prod_link1F = (HyperLink)e.Item.FindControl("prod_link1F");
            HyperLink prod_link2F = (HyperLink)e.Item.FindControl("prod_link2F");
            Literal prod_manF = (Literal)e.Item.FindControl("prod_manF");
            Literal prod_nameF = (Literal)e.Item.FindControl("prod_nameF");
            Literal priceShop1F = (Literal)e.Item.FindControl("priceShop1F");
            Literal priceShop2F = (Literal)e.Item.FindControl("priceShop2F");
            Literal priceShop3F = (Literal)e.Item.FindControl("priceShop3F");
            Literal ltShop1BestBuyF = (Literal)e.Item.FindControl("ltShop1BestBuyF");
            Literal ltShop2BestBuyF = (Literal)e.Item.FindControl("ltShop2BestBuyF");
            Literal ltShop3BestBuyF = (Literal)e.Item.FindControl("ltShop3BestBuyF");
            HyperLink hlShop1F = (HyperLink)e.Item.FindControl("hlShop1F");
            HyperLink hlShop2F = (HyperLink)e.Item.FindControl("hlShop2F");
            HyperLink hlShop3F = (HyperLink)e.Item.FindControl("hlShop3F");
            Image prod_imgF = (Image)e.Item.FindControl("prod_imgF");
            
            Panel pShop1F = (Panel)e.Item.FindControl("pShop1F");
            Panel pShop2F = (Panel)e.Item.FindControl("pShop2F");
            Panel pShop3F = (Panel)e.Item.FindControl("pShop3F");

            prod_link1F.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;
            prod_link2F.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            prod_manF.Text = p.AggManufacter.man_name;
            prod_nameF.Text = p.prod_name;

            priceShop1F.Text += "&euro; " + comparer.CpPrice;
            priceShop2F.Text += "&euro; " + comparer.UthPrice;
            priceShop3F.Text += "&euro; " + comparer.XhPrice;

            hlShop1F.NavigateUrl = "localhost/app1/ViewProduct.aspx?id=" + p.cp_id;
            hlShop2F.NavigateUrl = "localhost/app2/ViewProduct.aspx?id=" + p.uth_id;
            hlShop3F.NavigateUrl = "localhost/app3/ViewProduct.aspx?id=" + p.xh_id;

            prod_imgF.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id + img_format;

            if (comparer.CpPrice < 0) pShop1F.Visible = false;
            if (comparer.UthPrice < 0) pShop2F.Visible = false;
            if (comparer.XhPrice < 0) pShop3F.Visible = false;

            ltShop1BestBuyF.Visible = comparer.CpIsBestBuy;
            ltShop2BestBuyF.Visible = comparer.UthIsBestBuy;
            ltShop3BestBuyF.Visible = comparer.XhIsBestBuy;

            if (comparer.CpIsBestBuy) pShop1F.CssClass = "bestbuy";
            else if (comparer.UthIsBestBuy) pShop2F.CssClass = "bestbuy";
            else if (comparer.XhIsBestBuy) pShop3F.CssClass = "bestbuy";
        }

        #endregion

        #region Search Results
        private void ShowSearchResults()
        {
            string searchString = GetSearchString();
            bool validString = false;
            bool validUcid = false;
            bool validCid = false;
            bool validMid = false;

            int ucid = GetUcid();
            int cid = GetCid();
            int mid = GetMid();

            if (ucid > 0 | ucid == -1) validUcid = true;
            if (cid > 0) validCid = true;
            if (mid > 0) validMid = true;

            //Ucid is more powerful than cid
            if ((validUcid) && validMid) ShowResultBasedOnUnsortingCategoryAndManufacter(ucid, mid);
            else if (validUcid) ShowResultBasedOn(ucid);
            else
            {
                //Obviously, there must have been as search(string) in order for the category filter to be displayed and to work
                if (searchString.Length > 0) validString = true;
                if (validString && validCid && validMid) ShowResultBasedOnCategoryAndManufacter(searchString, cid, mid);
                else if (validString && validMid) FilterResultBasedOnManufacter(searchString, mid);
                else if (validString && validCid) ShowResultBasedOnCategory(searchString, cid);
                else if (validString) ShowResultBasedOn(searchString);
            }

            lvProducts.DataBind();

            //Change what options are available to the page if certain conditions have been met
            if (validUcid) pFilterCategory.Visible = false;
            if (validUcid | validCid | validString | ucid == -1)
            {
                ShowOrHideControls();
                ShowStats(validString, validUcid, validCid, validMid, searchString, ucid, cid, mid);
            }
        }

        private void ShowStats(bool validString, bool validUcid, bool validCid, bool validMid, string searchString, int ucid, int cid, int mid)
        {
            AggDataContext db = new AggDataContext();

            ltStats.Text = "Found " + howManyResults + " product(s)";
            if (validString) ltStats.Text += " for &quot;" + Server.HtmlEncode(searchString) + "&quot;";
            if (howManyResults > 0)
            {
                if (validMid) ltStats.Text += ", by " + db.AggManufacters.Single(m => m.man_id == mid).man_name;
                if (validUcid)
                {
                    if (ucid == -1) ltStats.Text += " in all categories";
                    else ltStats.Text += " in category &quot;" + db.AggCategories.Single(c => c.cat_id == ucid).cat_name.ToLower() + "&quot;";
                }
                else if (validCid) ltStats.Text += " in category &quot;" + db.AggCategories.Single(c => c.cat_id == cid).cat_name.ToLower() + "&quot;";
            }
            ltStats.Text += ".";
        }

        private void ShowAllProducts()
        {
            AggDataContext db = new AggDataContext();

            var v = db.AggProducts.Select(p => p);
            lvProducts.DataSource = v;

            lvProducts.DataBind();
        }

        private void FilterResultBasedOnManufacter(string searchString, int mid)
        {
            string[] keywords = searchString.Split(' ');
            var v = SearchEngine.FilterProductsByManufacter(keywords, mid);

            lvProducts.DataSource = v;

            ShowOnlyRelevantCategories(v);

            this.howManyResults = v.Count();
        }

        private void ShowResultBasedOnUnsortingCategoryAndManufacter(int ucid, int mid)
        {
            AggDataContext db = new AggDataContext();
            var v = db.AggProducts.Where(p => p.cat_id == ucid && p.man_id == mid);
            if (ucid == -1) v = db.AggProducts.Where(p => p.man_id == mid);
            
            lvProducts.DataSource = v;
            lvProducts.DataBind();
            
            this.howManyResults = v.Count();
        }

        private void ShowResultBasedOn(int ucid)
        {
            AggDataContext db = new AggDataContext(); 
            var v = db.AggProducts.Where(p => p.cat_id == ucid);
            if (ucid == -1) v = db.AggProducts.Select(p => p);

            lvProducts.DataSource = v;

            ShowOnlyRelevantManufacters(v);

            this.howManyResults = v.Count();
        }

        private void ShowOnlyRelevantManufacters(IQueryable<AggProduct> searchResults)
        {
            int[] i = new int[searchResults.Count()];
            int j = 0;

            foreach (AggProduct x in searchResults)
            {
                i[j] = (int)x.man_id;
                j++;
            }

            ddlFilterManufacter.DataSource = SearchEngine.SearchManufacters(i);
            ddlFilterManufacter.DataBind();
            ddlFilterManufacter.Items.Insert(0, new ListItem("All", "0"));
        }

        private void ShowOnlyRelevantCategories(IQueryable<AggProduct> searchResults)
        {
            int[] i = new int[searchResults.Count()];
            int j = 0;

            foreach (AggProduct x in searchResults)
            {
                i[j] = (int)x.cat_id;
                j++;
            }
            
            ddlFilterCategory.DataSource = SearchEngine.SearchCategories(i);
            ddlFilterCategory.DataBind();
            ddlFilterCategory.Items.Insert(0, new ListItem("All", "0"));
        }

        private void ShowResultBasedOnCategoryAndManufacter(string searchString, int cid, int mid)
        {
            string[] keywords = searchString.Split(' ');
            var v = SearchEngine.FilterProductsByCategoryAndManufacter(keywords, cid, mid);

            lvProducts.DataSource = v;

            this.howManyResults = v.Count();
        }

        private void ShowResultBasedOnCategory(string searchString, int cid)
        {
            string[] keywords = searchString.Split(' ');
            var v = SearchEngine.FilterProductsByCategory(keywords, cid);

            lvProducts.DataSource = v;

            ShowOnlyRelevantManufacters(v);

            this.howManyResults = v.Count();
        }

        private void ShowResultBasedOn(string searchString)
        {
            string[] keywords = searchString.Split(' ');
            var v = SearchEngine.SearchProducts(keywords);

            lvProducts.DataSource = v;

            ShowOnlyRelevantManufacters(v);
            ShowOnlyRelevantCategories(v);

            this.howManyResults = v.Count();
        }

        #endregion
    }
}