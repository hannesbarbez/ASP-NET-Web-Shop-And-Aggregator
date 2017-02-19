using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using app0.App_Data;
using app0.App_Logic;
using System.Web.Security;

namespace app0
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {
            Session["mainPage"] = "login";
            Session["subPage"] = "registerHome";

            XmlDataSource db = new XmlDataSource();
            db.DataFile = "Countries.xml";
            ddlCountry.DataSource = db;
            ddlCountry.DataBind();
            ddlCountry.SelectedValue = "56"; //set 'Belgium' as default

            if (HttpContext.Current.Request.IsAuthenticated) Response.Redirect("Default.aspx");
        }
        
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                UthDataContext db = new UthDataContext();
                var v = db.UthCustomers.Where(cust => cust.cust_mail.Equals(tbEmail.Text));

                if (v.Count() == 0)
                {
                    UthCustomer c = new UthCustomer();

                    //c.cust_country =tbCountry.Text;
                    c.cust_country_code = int.Parse(ddlCountry.SelectedItem.Value);
                    c.cust_mail = tbEmail.Text;
                    c.cust_name = tbName.Text;
                    c.cust_password = tbPassword.Text;
                    c.cust_phone = tbPhone.Text;
                    c.cust_postalcode = int.Parse(tbPostal.Text);
                    c.cust_streetname = tbStreet.Text;
                    c.cust_streetnumber = int.Parse(tbHouse.Text);
                    c.cust_city = tbCity.Text;

                    db.UthCustomers.InsertOnSubmit(c);
                    db.SubmitChanges();

                    bool authenticated = Customer.AuthenticateCustomer(c.cust_mail, c.cust_password);
                    if (authenticated) FormsAuthentication.RedirectFromLoginPage(c.cust_mail, false);
                    Response.Redirect("~/ThankYou.aspx");
                }

                pError.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}