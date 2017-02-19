using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using app0.App_Logic;
using System.Web.Security;

namespace app0
{
    public partial class WantsToLogOut : System.Web.UI.Page
    {
        protected void LogOut_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                ShoppingCart cart = ShoppingCart.GetShoppingCart();
                cart.RemoveAll();

                FormsAuthentication.SignOut();
                Response.Redirect("~/LoggedOut.aspx");
            }
            else Response.Redirect("~/Login.aspx");
        }

        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "login";
            Session["subPage"] = "loginWantToLogOut";
        }
        
    }
}