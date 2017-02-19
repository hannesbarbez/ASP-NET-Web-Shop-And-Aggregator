using System;
using System.Linq;
using System.Web.UI.WebControls;
using app0.App_Data;
using app0.App_Logic;
using System.Collections.Generic;

namespace app0
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbSearchD.Text))
            {
                Session.Remove("idQuery");
                Session["searchQuery"] = Server.HtmlEncode(tbSearchD.Text);
                Response.Redirect("~/Search.aspx");
            }
            else Session["searchQuery"] = String.Empty;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Session["mainPage"] = "home";
            Session["subPage"] = "homeHome";
            AggDataContext db = new AggDataContext();

            lvMainPageCategories.DataSource = db.AggCategories.OrderBy(c => c.cat_name);
            lvMainPageCategories.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("idQuery");
            Session.Remove("searchQuery");
        }

        protected void lvMainPageCategories_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            AggCategory c = (AggCategory)dataItem.DataItem;
            AggDataContext db = new AggDataContext();

            string img_format = "s.jpg";
            string navigateUrl = "~/Search.aspx?ucid=" + c.cat_id;
            string imageUrl = "~/ViewImage.aspx?img=";

            HyperLink cat_link1 = (HyperLink)e.Item.FindControl("cat_link1");
            cat_link1.NavigateUrl = navigateUrl;

            HyperLink cat_link2 = (HyperLink)e.Item.FindControl("cat_link2");
            cat_link2.NavigateUrl = navigateUrl;

            Literal cat_name = (Literal)e.Item.FindControl("cat_name");
            cat_name.Text = c.cat_name;

            Image cat_img = (Image)e.Item.FindControl("cat_img");
            cat_img.ImageUrl = imageUrl + db.AggProducts.Where(p => p.cat_id == c.cat_id).First().img_id + img_format;
        }
    }
}