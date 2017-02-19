using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app0
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "home";
            Session["subPage"] = "errMessage";
        }
    }
}