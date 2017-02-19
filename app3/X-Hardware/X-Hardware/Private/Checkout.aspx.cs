using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using app0.App_Logic;

namespace app0.Private
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void ltTotalPrice_Prerender(object sender, EventArgs e)
        {
            ShoppingCart cart = ShoppingCart.GetShoppingCart();
            ltTotalPrice.Text = "Total Price: " + cart.GetSubTotal().ToString("C");
        }

        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "cart";
            Session["subPage"] = "cartCheckOut";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShoppingCart cart = ShoppingCart.GetShoppingCart();
                if (cart.Items.Count > 0) BindData();
                else Response.Redirect("~/ViewCart.aspx");
            }
        }

        protected void BindData()
        {
            ShoppingCart cart = ShoppingCart.GetShoppingCart();
            gvShoppingCart.DataSource = cart.Items;
            gvShoppingCart.DataBind();
        }
    }
}