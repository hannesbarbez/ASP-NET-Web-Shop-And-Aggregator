using System;
using System.Linq;
using System.Web.UI.WebControls;
using app0.App_Data;
using app0.App_Logic;

namespace app0
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Session["mainPage"] = "home";
            Session["subPage"] = "homeHome";
            CpDataContext db = new CpDataContext();

            lvBargain.DataSource = db.CpProducts.Where(p => p.prod_stock > 0).OrderBy(p => p.prod_price).Take(3);
            lvBargain.DataBind();

            lvLatest.DataSource = db.CpProducts.OrderByDescending(p => p.prod_id).Take(3);
            lvLatest.DataBind();

            lvTop.DataSource= LoadTopSellers(3);
            lvTop.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("idQuery");
            Session.Remove("searchQuery");
        }

        private object LoadTopSellers(int howMany)
        {
            CpDataContext db = new CpDataContext();

            //select all prod_ids into new table x, 
            //join x with p in t (a key),
            //join t with m in order to create 
            //the top 3 of products most bought by ALL clients (not PER)
            return (from p in db.CpProducts
                    join x in
                        (from o in db.CpOrders
                         join p in db.CpProducts on o.prod_id equals p.prod_id
                         group o by o.prod_id into t
                         select t)
                    on p.prod_id equals x.Key
                    join m in db.CpManufacters on p.man_id equals m.man_id
                    orderby x.Count() descending
                    select new AuxProduct
                    {
                        ImageId = p.img_id,
                        Name = p.prod_name,
                        Price = p.prod_price,
                        Manufacter = m.man_name,
                        Model = p.prod_model,
                        Id = p.prod_id

                    }).Take(howMany);
        }

        protected void lvBargain_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            CpProduct p = (CpProduct)dataItem.DataItem;
            string img_format = "s.jpg";

            HyperLink prod_link1B = (HyperLink)e.Item.FindControl("prod_link1B");
            prod_link1B.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            HyperLink prod_link2B = (HyperLink)e.Item.FindControl("prod_link2B");
            prod_link2B.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            HyperLink addToCartB = (HyperLink)e.Item.FindControl("addToCartB");
            addToCartB.NavigateUrl = "~/AddToCart.aspx?id=" + p.prod_id;
            addToCartB.Attributes.Add("title", "Add this product to your cart");
          
            Literal prod_manB = (Literal)e.Item.FindControl("prod_manB");
            prod_manB.Text = p.CpManufacter.man_name.ToString();

            Literal prod_nameB = (Literal)e.Item.FindControl("prod_nameB");
            prod_nameB.Text = p.prod_name;

            Literal prod_priceB = (Literal)e.Item.FindControl("prod_priceB");
            prod_priceB.Text += p.prod_price.ToString();

            Literal prod_modelB = (Literal)e.Item.FindControl("prod_modelB");
            prod_modelB.Text += p.prod_model;

            Image prod_imgB = (Image)e.Item.FindControl("prod_imgB");
            prod_imgB.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id + img_format;

        }

        protected void lvLatest_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            CpProduct p = (CpProduct)dataItem.DataItem;
            string img_format = "s.jpg";

            HyperLink prod_link1L = (HyperLink)e.Item.FindControl("prod_link1L");
            prod_link1L.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            HyperLink prod_link2L = (HyperLink)e.Item.FindControl("prod_link2L");
            prod_link2L.NavigateUrl = "~/ViewProduct.aspx?id=" + p.prod_id;

            HyperLink addToCartL = (HyperLink)e.Item.FindControl("addToCartL");
            addToCartL.NavigateUrl = "~/AddToCart.aspx?id=" + p.prod_id;
            addToCartL.Attributes.Add("title", "Add this product to your cart");
            
            Literal prod_manL = (Literal)e.Item.FindControl("prod_manL");
            prod_manL.Text = p.CpManufacter.man_name.ToString();

            Literal prod_nameL = (Literal)e.Item.FindControl("prod_nameL");
            prod_nameL.Text = p.prod_name;

            Literal prod_priceL = (Literal)e.Item.FindControl("prod_priceL");
            prod_priceL.Text += p.prod_price.ToString();

            Literal prod_modelL = (Literal)e.Item.FindControl("prod_modelL");
            prod_modelL.Text += p.prod_model;

            Image prod_imgL = (Image)e.Item.FindControl("prod_imgL");
            prod_imgL.ImageUrl = "~/ViewImage.aspx?img=" + p.img_id + img_format;

        }

        protected void lvTop_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            AuxProduct p = (AuxProduct)dataItem.DataItem;
            string img_format = "s.jpg";

            HyperLink prod_link1T = (HyperLink)e.Item.FindControl("prod_link1T");
            prod_link1T.NavigateUrl = "~/ViewProduct.aspx?id=" + p.Id;

            HyperLink prod_link2T = (HyperLink)e.Item.FindControl("prod_link2T");
            prod_link2T.NavigateUrl = "~/ViewProduct.aspx?id=" + p.Id;

            HyperLink addToCartT = (HyperLink)e.Item.FindControl("addToCartT");
            addToCartT.NavigateUrl = "~/AddToCart.aspx?id=" + p.Id;
            addToCartT.Attributes.Add("title", "Add this product to your cart");

            Literal prod_manT = (Literal)e.Item.FindControl("prod_manT");
            prod_manT.Text = p.Manufacter.ToString();

            Literal prod_nameT = (Literal)e.Item.FindControl("prod_nameT");
            prod_nameT.Text = p.Name;

            Literal prod_priceT = (Literal)e.Item.FindControl("prod_priceT");
            prod_priceT.Text += p.Price.ToString();

            Literal prod_modelT = (Literal)e.Item.FindControl("prod_modelT");
            prod_modelT.Text += p.Model;

            Image prod_imgT = (Image)e.Item.FindControl("prod_imgT");
            prod_imgT.ImageUrl = "~/ViewImage.aspx?img=" + p.ImageId + img_format;
        }
    }
}