using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using app0.App_Data;
using app0.App_Logic;

namespace app0
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "login";
            Session["subPage"] = "loginHome";
        }
        
        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated) Response.Redirect("Default.aspx");
        }

        protected void lLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = Customer.AuthenticateCustomer(lLogin.UserName, lLogin.Password);
            if (e.Authenticated)
            {
                FormsAuthentication.RedirectFromLoginPage(lLogin.UserName, lLogin.RememberMeSet);
            }
        }
    }
}