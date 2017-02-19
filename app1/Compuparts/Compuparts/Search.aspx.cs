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

            rbFilterPrice.Items.FindByValue("a").Selected = true;
        }

        private void InitBlCatNavBar()
        {
            CpDataContext db = new CpDataContext();

            var v = db.CpCategories.OrderBy(c => c.cat_name);

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
            CpDataContext db = new CpDataContext();

            ddlFilterCategory.DataSource = db.CpCategories.Select(c => c).OrderBy(c => c.cat_name);
            ddlFilterCategory.DataBind();
            ddlFilterCategory.Items.Insert(0, new ListItem("All Categories", "0"));
        }

        private void InitDdlFilterManufacter()
        {
            CpDataContext db = new CpDataContext();

            ddlFilterManufacter.DataSource = db.CpManufacters.Select(m => m).OrderBy(m => m.man_name);
            ddlFilterManufacter.DataBind();
            ddlFilterManufacter.Items.Insert(0, new ListItem("All Manufacters", "0"));
        }

        private void InitLvFeatProd()
        {
            CpDataContext db = new CpDataContext();
            lvFeatProd.DataSource = (from p in db.CpProducts
                                    orderby db.Random()
                                    select p).Take(6);
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

            if (lvProducts.Items.Count == 0)
            {
                phNoSearchResults.Visible = true;
            }
            else
            {
                phNoSearchResults.Visible = false;
                pSearchFilters.Visible = true;
            }
        }

        private object LoadCategoriesForLinks()
        {
            CpDataContext db = new CpDataContext();
            return from c in db.CpCategories
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
            CpProduct p = (CpProduct)dataItem.DataItem;
            string img_format = "s.jpg";

            HyperLink prod_link1 = (HyperLink)e.Item.FindControl("prod_link1");
            prod_link1.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            HyperLink prod_link2 = (HyperLink)e.Item.FindControl("prod_link2");
            prod_link2.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            HyperLink addToCart = (HyperLink)e.Item.FindControl("addToCart");
            addToCart.NavigateUrl = "~/AddToCart.aspx?id=" + p.prod_id;
            addToCart.Attributes.Add("title", "Add this product to your cart");

            Literal prod_man = (Literal)e.Item.FindControl("prod_man");
            prod_man.Text = p.CpManufacter.man_name;

            Literal prod_name = (Literal)e.Item.FindControl("prod_name");
            prod_name.Text = p.prod_name;

            Literal prod_price = (Literal)e.Item.FindControl("prod_price");
            prod_price.Text += p.prod_price.ToString();

            Literal prod_model = (Literal)e.Item.FindControl("prod_model");
            prod_model.Text += p.prod_model;

            Image prod_img = (Image)e.Item.FindControl("prod_img");
            prod_img.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id + img_format;

            DataPager dpProducts = (DataPager)lvProducts.FindControl("dpProducts");
            dpProducts.Visible = (howManyResults > dpProducts.PageSize);
        }

        protected void lvFeatProd_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            CpProduct p = (CpProduct)dataItem.DataItem;
            string img_format = "s.jpg";

            HyperLink featProd_link1 = (HyperLink)e.Item.FindControl("featProd_link1");
            featProd_link1.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            HyperLink featProd_link2 = (HyperLink)e.Item.FindControl("featProd_link2");
            featProd_link2.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            HyperLink addToCart = (HyperLink)e.Item.FindControl("addToCart");
            addToCart.NavigateUrl = "~/AddToCart.aspx?id=" + p.prod_id;
            addToCart.Attributes.Add("title", "Add this product to your cart");

            Literal featProd_man = (Literal)e.Item.FindControl("featProd_man");
            featProd_man.Text = p.CpManufacter.man_name;

            Literal featProd_name = (Literal)e.Item.FindControl("featProd_name");
            featProd_name.Text = p.prod_name;

            Literal featProd_price = (Literal)e.Item.FindControl("featProd_price");
            featProd_price.Text += p.prod_price.ToString();

            Literal featProd_model = (Literal)e.Item.FindControl("featProd_model");
            featProd_model.Text += p.prod_model;

            Image featProd_img = (Image)e.Item.FindControl("featProd_img");
            featProd_img.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id + img_format;
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
            CpDataContext db = new CpDataContext();

            ltStats.Text = "Found " + howManyResults + " product(s)";
            if (validString) ltStats.Text += " for &quot;" + Server.HtmlEncode(searchString) + "&quot;";
            if (howManyResults > 0)
            {
                if (rbFilterPrice.SelectedItem.Value == "a") ltStats.Text += ", shown by ascending prices";
                else if (rbFilterPrice.SelectedItem.Value == "d") ltStats.Text += ", shown by descending prices";
                                
                if (validMid) ltStats.Text += ", by " + db.CpManufacters.Single(m => m.man_id == mid).man_name;
                if (validUcid)
                {
                    if (ucid == -1) ltStats.Text += " in all categories";
                    else ltStats.Text += " in category &quot;" + db.CpCategories.Single(c => c.cat_id == ucid).cat_name.ToLower() + "&quot;";
                }
                else if (validCid) ltStats.Text += " in category &quot;" + db.CpCategories.Single(c => c.cat_id == cid).cat_name.ToLower() + "&quot;";
            }
            ltStats.Text += ".";
        }

        private void ShowAllProducts()
        {
            CpDataContext db = new CpDataContext();

            var v = db.CpProducts.Select(p => p).OrderBy(p => p.prod_price);
            lvProducts.DataSource = v;

            if (rbFilterPrice.SelectedItem.Value == "d") lvProducts.DataSource = v.OrderByDescending(p => p.prod_price);
            lvProducts.DataBind();

        }
        private void FilterResultBasedOnManufacter(string searchString, int mid)
        {
            string[] keywords = searchString.Split(' ');
            var v = SearchEngine.FilterProductsByManufacter(keywords, mid);

            lvProducts.DataSource = v;
            if (rbFilterPrice.SelectedItem.Value == "d") lvProducts.DataSource = v.OrderByDescending(p => p.prod_price);

            ShowOnlyRelevantCategories(v);

            this.howManyResults = v.Count();
        }

        private void ShowResultBasedOnUnsortingCategoryAndManufacter(int ucid, int mid)
        {
            CpDataContext db = new CpDataContext();
            var v = db.CpProducts.Where(p => p.cat_id == ucid && p.man_id == mid);
            if (ucid == -1) v = db.CpProducts.Where(p => p.man_id == mid);
            
            lvProducts.DataSource = v.OrderBy(p => p.prod_price);
            if (rbFilterPrice.SelectedItem.Value == "d") lvProducts.DataSource = v.OrderByDescending(p => p.prod_price);

            lvProducts.DataBind();
            
            this.howManyResults = v.Count();
        }

        private void ShowResultBasedOn(int ucid)
        {
            CpDataContext db = new CpDataContext(); 
            var v = db.CpProducts.Where(p => p.cat_id == ucid);
            if (ucid == -1) v = db.CpProducts.Select(p => p);

            lvProducts.DataSource = v.OrderBy(p => p.prod_price);
            if (rbFilterPrice.SelectedItem.Value == "d") lvProducts.DataSource = v.OrderByDescending(p => p.prod_price);

            ShowOnlyRelevantManufacters(v);

            this.howManyResults = v.Count();
        }

        private void ShowOnlyRelevantManufacters(IQueryable<CpProduct> searchResults)
        {
            int[] i = new int[searchResults.Count()];
            int j = 0;

            foreach (CpProduct x in searchResults)
            {
                i[j] = (int)x.man_id;
                j++;
            }

            ddlFilterManufacter.DataSource = SearchEngine.SearchManufacters(i);
            ddlFilterManufacter.DataBind();
            ddlFilterManufacter.Items.Insert(0, new ListItem("All", "0"));
        }

        private void ShowOnlyRelevantCategories(IQueryable<CpProduct> searchResults)
        {
            int[] i = new int[searchResults.Count()];
            int j = 0;

            foreach (CpProduct x in searchResults)
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
            if (rbFilterPrice.SelectedItem.Value == "d") lvProducts.DataSource = v.OrderByDescending(p => p.prod_price);

            this.howManyResults = v.Count();
        }

        private void ShowResultBasedOnCategory(string searchString, int cid)
        {
            string[] keywords = searchString.Split(' ');
            var v = SearchEngine.FilterProductsByCategory(keywords, cid);

            lvProducts.DataSource = v;
            if (rbFilterPrice.SelectedItem.Value == "d") lvProducts.DataSource = v.OrderByDescending(p => p.prod_price);

            ShowOnlyRelevantManufacters(v);

            this.howManyResults = v.Count();
        }

        private void ShowResultBasedOn(string searchString)
        {
            string[] keywords = searchString.Split(' ');
            var v = SearchEngine.SearchProducts(keywords);

            lvProducts.DataSource = v;
            if (rbFilterPrice.SelectedItem.Value == "d") lvProducts.DataSource = v.OrderByDescending(p => p.prod_price);

            ShowOnlyRelevantManufacters(v);
            ShowOnlyRelevantCategories(v);

            this.howManyResults = v.Count();
        }

        #endregion
    }
}