using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app0
{
    public partial class ThankYou : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "register";
            Session["subPage"] = "registerComplete";
        }
        
        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.IsAuthenticated) Response.Redirect("Default.aspx");
        }
    }
}