using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app0
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "contact";
            Session["subPage"] = "contactHome";
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}