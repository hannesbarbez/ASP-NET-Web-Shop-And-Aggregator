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
            }
            else Response.Redirect("~/Default.aspx");
        }

        private IQueryable<AggProduct> LoadProdDetail(int prodId)
        {
            AggDataContext db = new AggDataContext();

            return from p in db.AggProducts
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
            AggProduct p = (AggProduct)dataItem.DataItem;
            StoreComparer comparer = new StoreComparer(p);

            string img_medium = "m.jpg";
            string img_large = "l.jpg";

            Literal prod_man = (Literal)e.Item.FindControl("prod_man");
            prod_man.Text += p.AggManufacter.man_name;

            Literal prod_name = (Literal)e.Item.FindControl("prod_name");
            prod_name.Text += p.prod_name;

            HyperLink hlEnlargeImage = (HyperLink)e.Item.FindControl("hlEnlargeImage");
            hlEnlargeImage.NavigateUrl = "~/ViewImage.aspx?img=" + p.img_id.ToString() + img_large;
            hlEnlargeImage.Attributes.Add("rel", "lightbox");
            hlEnlargeImage.Attributes.Add("title", p.AggManufacter.man_name + " " + p.prod_name);
            
            Image imgProductMedium = (Image)e.Item.FindControl("imgProductMedium");
            imgProductMedium.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id.ToString() + img_medium;

            HyperLink prod_link1 = (HyperLink)e.Item.FindControl("prod_link1");
            HyperLink prod_link2 = (HyperLink)e.Item.FindControl("prod_link2");
            Literal priceShop1 = (Literal)e.Item.FindControl("priceShop1");
            Literal priceShop2 = (Literal)e.Item.FindControl("priceShop2");
            Literal priceShop3 = (Literal)e.Item.FindControl("priceShop3");
            Literal ltShop1BestBuy = (Literal)e.Item.FindControl("ltShop1BestBuy");
            Literal ltShop2BestBuy = (Literal)e.Item.FindControl("ltShop2BestBuy");
            Literal ltShop3BestBuy = (Literal)e.Item.FindControl("ltShop3BestBuy");
            Literal ltInfoShop1 = (Literal)e.Item.FindControl("ltInfoShop1");
            Literal ltInfoShop2 = (Literal)e.Item.FindControl("ltInfoShop2");
            Literal ltInfoShop3 = (Literal)e.Item.FindControl("ltInfoShop3");
            HyperLink hlShop1 = (HyperLink)e.Item.FindControl("hlShop1");
            HyperLink hlShop2 = (HyperLink)e.Item.FindControl("hlShop2");
            HyperLink hlShop3 = (HyperLink)e.Item.FindControl("hlShop3");
            Image prod_img = (Image)e.Item.FindControl("prod_img");
            PlaceHolder pShop1 = (PlaceHolder)e.Item.FindControl("pShop1");
            PlaceHolder pShop2 = (PlaceHolder)e.Item.FindControl("pShop2");
            PlaceHolder pShop3 = (PlaceHolder)e.Item.FindControl("pShop3");

            prod_man.Text = p.AggManufacter.man_name;
            prod_name.Text = p.prod_name;

            priceShop1.Text += "&euro; " + comparer.CpPrice;
            priceShop2.Text += "&euro; " + comparer.UthPrice;
            priceShop3.Text += "&euro; " + comparer.XhPrice;

            hlShop1.NavigateUrl = "localhost/app1/ViewProduct.aspx?id=" + p.cp_id;
            hlShop2.NavigateUrl = "localhost/app2/ViewProduct.aspx?id=" + p.uth_id;
            hlShop3.NavigateUrl = "localhost/app3/ViewProduct.aspx?id=" + p.xh_id;

            ltInfoShop1.Text += comparer.CpStock + " unit(s) in stock and can deliver on " + comparer.CpDate.ToShortDateString() + ".";
            ltInfoShop2.Text += comparer.UthStock + " unit(s) in stock and can deliver on " + comparer.UthDate.ToShortDateString() + ".";
            ltInfoShop3.Text += comparer.XhStock + " unit(s) in stock and can deliver on " + comparer.XhDate.ToShortDateString() + ".";

            if (comparer.CpPrice < 0) pShop1.Visible = false;
            if (comparer.UthPrice < 0) pShop2.Visible = false;
            if (comparer.XhPrice < 0) pShop3.Visible = false;

            ltShop1BestBuy.Visible = comparer.CpIsBestBuy;
            ltShop2BestBuy.Visible = comparer.UthIsBestBuy;
            ltShop3BestBuy.Visible = comparer.XhIsBestBuy;
        }
    }
}