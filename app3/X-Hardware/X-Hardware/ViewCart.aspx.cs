using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using app0.App_Logic;

namespace app0
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "cart";
            Session["subPage"] = "cartViewContents";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Because of ASP.NET keeping track of the state of all server controls, we don't need to supply the GridView with
            // the data every time the page loads.
            if (!IsPostBack) BindData();
        }

        protected void BindData()
        {
            ShoppingCart cart = ShoppingCart.GetShoppingCart();
            gvShoppingCart.DataSource = cart.Items;
            gvShoppingCart.DataBind();
            ShowOrHideControls(cart);
        }

        private void ShowOrHideControls(ShoppingCart cart)
        {
            pNoProducts.Visible = false;
            ltCheckOut.Visible = true;
            ltTotalPrice.Visible = true;
            btnUpdateCart.Visible = true;

            if (cart.Items.Count == 0)
            {
                pNoProducts.Visible = true;
                ltCheckOut.Visible = false;
                ltTotalPrice.Visible = false;
                btnUpdateCart.Visible = false;
            }
        }

        protected void gvShoppingCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                ShoppingCart cart = ShoppingCart.GetShoppingCart();
                cart.RemoveItem(productId);
            }

            // We now have to re-setup the data so that the GridView doesn't keep
            // displaying the old data
            BindData();
        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvShoppingCart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    // We'll use a try catch block in case something other than a number is typed in
                    // If so, we'll just ignore it.
                    try
                    {
                        // Get the productId from the GridView's datakeys
                        int productId = Convert.ToInt32(gvShoppingCart.DataKeys[row.RowIndex].Value);
                        // Find the quantity TextBox and retrieve the value
                        int quantity = int.Parse(((TextBox)row.Cells[1].FindControl("txtQuantity")).Text);
                        
                        ShoppingCart cart = ShoppingCart.GetShoppingCart();
                        cart.SetItemQuantity(productId, quantity);
                    }
                    catch (FormatException) { }
                }
            }
            BindData();
        }

        protected void ltTotalPrice_Prerender(object sender, EventArgs e)
        {
            ShoppingCart cart = ShoppingCart.GetShoppingCart();
            ltTotalPrice.Text = "Total Price: " + cart.GetSubTotal().ToString("C");
        }

        protected void btnEmptyCart_Click(object sender, EventArgs e)
        {
            ShoppingCart cart = ShoppingCart.GetShoppingCart();
            cart.RemoveAll();
            Response.Redirect("ViewCart.aspx");
        }
    }
}