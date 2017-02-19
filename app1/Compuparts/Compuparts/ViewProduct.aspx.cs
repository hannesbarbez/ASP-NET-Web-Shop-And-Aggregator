using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using app0.App_Data;
using app0.App_Logic;

namespace app0
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        private const short ITEMSTOSHOW = 999;

        protected void Page_Prerender(object sender, EventArgs e)
        {
            bool ValidId = false;

            Session.Remove("idQuery");
            Session.Remove("searchQuery");

            int prodId = GetId();
            if (prodId > 0) ValidId = true;

            if (ValidId)
            {
                lvProdDetail.DataSource = LoadProdDetail(prodId);
                lvProdDetail.DataBind();

                lvAlsoBought.DataSource = LoadAssociatedProducts(prodId);
                lvAlsoBought.DataBind();
            }
            else Response.Redirect("~/Default.aspx");
        }

        private IQueryable<CpProduct> LoadAssociatedProducts(int prodId)
        {
            CpDataContext db = new CpDataContext();

            //Make j.Key (by selecting t) representing customers who have bought this product,
            //join them with every order ever placed,
            //select all products that have been bought by these customers
            IQueryable<int> v = from o in db.CpOrders
                                join j in
                                    (from o in db.CpOrders
                                     where o.prod_id == prodId
                                     group o by o.cust_id into t
                                     select t)
                                on o.cust_id equals j.Key
                                select o.prod_id;

            int[] i = v.ToArray();

            //return all products the customers bought except, of course, the product that's being detailed right now and here
            return SearchEngine.SearchProductsByIdWithoutOne(i, prodId, 3);
        }

        private IQueryable<CpProduct> LoadProdDetail(int prodId)
        {
            CpDataContext db = new CpDataContext();

            return from p in db.CpProducts
                   where p.prod_id == prodId
                   select p;
        }


        /// <summary>
        /// Checks if given id (Product ID) is a valid integer, selected through URL
        /// It also removes its source.
        /// </summary>
        /// <returns>0 for invalid category, otherwise positive int representing the category id</returns>
        private int GetId()
        {
            int id = 0;

            if (null != Session["id"])
            {
                string u = Session["id"].ToString();
                Int32.TryParse(u, out id);
            }
            return id;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Session["mainPage"] = "products";
            Session["subPage"] = "productDetail";
            Session.Remove("id");

            if (null != Request.QueryString["id"])
            {
                int i;
                string s = Server.HtmlDecode(Request.QueryString["id"].ToString());
                Int32.TryParse(s, out i);
                Session["id"] = i;
            }
        }

        protected void lvProdDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            CpProduct p = (CpProduct)dataItem.DataItem;

            string img_medium = "m.jpg";
            string img_large = "l.jpg";

            Literal ltProdMan = (Literal)e.Item.FindControl("ltProdMan");
            ltProdMan.Text += p.CpManufacter.man_name;

            Literal ltProdName = (Literal)e.Item.FindControl("ltProdName");
            ltProdName.Text += p.prod_name;

            HyperLink hlEnlargeImage = (HyperLink)e.Item.FindControl("hlEnlargeImage");
            hlEnlargeImage.NavigateUrl = "~/ViewImage.aspx?img=" + p.img_id.ToString() + img_large;
            hlEnlargeImage.Attributes.Add("rel", "lightbox");
            hlEnlargeImage.Attributes.Add("title", p.CpManufacter.man_name + " " + p.prod_name);
            
            Image imgProductMedium = (Image)e.Item.FindControl("imgProductMedium");
            imgProductMedium.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id.ToString() + img_medium;

            Literal ltModel = (Literal)e.Item.FindControl("ltModel");
            ltModel.Text += p.prod_model;

            Literal ltPrice = (Literal)e.Item.FindControl("ltPrice");
            ltPrice.Text += p.prod_price.ToString();

            HyperLink hlCategory = (HyperLink)e.Item.FindControl("hlCategory");
            hlCategory.NavigateUrl = "~/Search.aspx?ucid=" + p.cat_id.ToString();

            Literal ltStock = (Literal)e.Item.FindControl("ltStock");
            ltStock.Text += p.prod_stock.ToString();

            Literal ltProdDesc = (Literal)e.Item.FindControl("ltProdDesc");
            ltProdDesc.Text += p.prod_desc;

            HyperLink hlAddToCart1 = (HyperLink)e.Item.FindControl("hlAddToCart1");
            hlAddToCart1.NavigateUrl = "~/AddToCart.aspx?id=" + p.prod_id;
            hlAddToCart1.Attributes.Add("title", "Add this product to your cart");

            HyperLink hlAddToCart2 = (HyperLink)e.Item.FindControl("hlAddToCart2");
            hlAddToCart2.NavigateUrl = "~/AddToCart.aspx?id=" + p.prod_id;
        }

        protected void lvAlsoBought_ItemDataBound(object sender, ListViewItemEventArgs e)
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

            Literal prod_man = (Literal)e.Item.FindControl("prod_man");
            prod_man.Text = p.CpManufacter.man_name.ToString();

            Literal prod_name = (Literal)e.Item.FindControl("prod_name");
            prod_name.Text = p.prod_name;

            Literal prod_price = (Literal)e.Item.FindControl("prod_price");
            prod_price.Text += p.prod_price.ToString();

            Literal prod_model = (Literal)e.Item.FindControl("prod_model");
            prod_model.Text += p.prod_model;

            Image prod_img = (Image)e.Item.FindControl("prod_img");
            prod_img.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id + img_format;
        }
    }
}