using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using app0.App_Logic;

namespace app0
{
    public partial class app0 : System.Web.UI.MasterPage
    {
        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (!IsPostBack) ShowNavigationPath();

            if (null != Session["searchQuery"]) tbSearch.Text = Server.HtmlDecode(Session["searchQuery"].ToString());
            lbLogin.Text = HttpContext.Current.Request.IsAuthenticated ? ("Log off (" + Server.HtmlEncode(HttpContext.Current.User.Identity.Name)) + ")" : "Log in/register";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        private void ShowNavigationPath()
        {
            string mainPageSwitch = Session["mainPage"].ToString();
            string subPageSwitch = Session["subPage"].ToString();

            string cssClassName = "selectedNavBarItem";
            string location = "Home";
            string url = "Default.aspx";

            switch (mainPageSwitch)
            {
                case "home":
                    hlDefault.CssClass = cssClassName;
                    break;

                case "products":
                    location = "Product Search";
                    hlProducts.CssClass = cssClassName;
                    url = "Search.aspx";
                    break;

                case "cart":
                    location = "Shopping Cart";
                    hlCheckOut.CssClass = cssClassName;
                    url = "ViewCart.aspx";
                    break;

                case "login":
                    location = "User administration";
                    lbLogin.CssClass = cssClassName;
                    url = "Login.aspx";
                    break;

                case "contact":
                    location = "Contact information";
                    hlContact.CssClass = cssClassName;
                    url = "Contact.aspx";
                    break;

                case "orderInfo":
                    location = "Ordering &amp; Privacy";
                    hlOrderInfo.CssClass = cssClassName;
                    url = "Policies.aspx";
                    break;
            }

            ltTitle.Text += location;
            string breadcrumbLocation = "<a href=\"../../app2/" + url + "\">" + location + "</a>" + " > ";

            if (subPageSwitch == "homeHome") breadcrumbLocation += "Home";
            else if (subPageSwitch == "productsHome") breadcrumbLocation += "Product overview";
            else if (subPageSwitch == "productDetail") breadcrumbLocation += "Product detail";
            else if (subPageSwitch == "cartViewContents") breadcrumbLocation += "Contents";
            else if (subPageSwitch == "registerComplete") breadcrumbLocation += "Registration completed successfully";
            else if (subPageSwitch == "registerHome") breadcrumbLocation += "Register";
            else if (subPageSwitch == "loginHome") breadcrumbLocation += "Log in";
            else if (subPageSwitch == "loginOut") breadcrumbLocation += "Successfully logged off";
            else if (subPageSwitch == "contactHome") breadcrumbLocation += "Home";
            else if (subPageSwitch == "orderInfoHome") breadcrumbLocation += "Home";
            else if (subPageSwitch == "cartCheckOut") breadcrumbLocation += "Check Out";
            else if (subPageSwitch == "loginIn") breadcrumbLocation += "Successfully logged on";
            else if (subPageSwitch == "loginWantToLogOut") breadcrumbLocation += "Logging off";
            else if (subPageSwitch == "errMessage") breadcrumbLocation += "Error";

            ltBreadcrumb.Text += breadcrumbLocation;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbSearch.Text))
            {
                Session.Remove("idQuery");
                Session["searchQuery"] = Server.HtmlEncode(tbSearch.Text);
                Response.Redirect("~/Search.aspx");
            }
            else Session["searchQuery"] = String.Empty;
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated) Response.Redirect("~/WantsToLogOut.aspx");
            else Response.Redirect("~/Login.aspx");
        }

        protected void hlProducts_Click(object sender, EventArgs e)
        {
            Session["searchQuery"] = String.Empty;
            Response.Redirect("~/Search.aspx");
        }
    }
}