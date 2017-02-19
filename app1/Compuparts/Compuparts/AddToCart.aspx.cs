using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using app0.App_Logic;
using app0.App_Data;

namespace app0
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Session.Remove("id");

            if (null != Request.QueryString["id"])
            {
                int i;
                string s = Server.HtmlDecode(Request.QueryString["id"].ToString());
                Int32.TryParse(s, out i);
                Session["id"] = i;
            }
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

        protected void Page_Prerender(object sender, EventArgs e)
        {
            bool ValidId = false;

            Session.Remove("idQuery");
            Session.Remove("searchQuery");

            int prodId = GetId();
            if (prodId > 0) ValidId = true;

            if (ValidId)
            {
                ShoppingCart cart = ShoppingCart.GetShoppingCart();
                cart.AddItem(prodId);
                Response.Redirect("ViewCart.aspx");
            }
            
            Response.Redirect("~/Default.aspx");
        }
    }
}