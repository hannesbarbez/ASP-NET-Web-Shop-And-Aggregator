using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app0
{
    public partial class LoggedOut : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "login";
            Session["subPage"] = "loginOut";
        }
        
        protected void Page_Prerender(object sender, EventArgs e)
        {
            
        }
    }
}