using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using app0.App_Logic;
using app0.App_Data;
using System.Web.Security;
using System.Net.Mail;

namespace app0.Private
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShoppingCart cart = ShoppingCart.GetShoppingCart();

                //get next available order code
                int order_code = OrderHelper.GetNextOrderId();

                //Make changes to db (add order, remove stock)
                if (cart.Items.Count > 0) foreach (CartItem ci in cart.Items) AddOrderToDB(ci, order_code);

                //Send a mail outlining details of this order
                OrderHelper.MailOrderDetails(User.Identity.Name);

                //Clear shopping cart
                cart.Items.Clear();
            }
        }

        protected void AddOrderToDB(CartItem ci, int order_code)
        {
            XhDataContext db = new XhDataContext();
            XhOrder order = new XhOrder();

            //get current user
            order.cust_id = db.XhCustomers.Single(c => c.cust_mail.Equals(User.Identity.Name)).cust_id;
            order.ord_code = order_code;
            order.ord_date = DateTime.Now;
            order.ord_delivered = false;
            order.ord_quantity = ci.Quantity;
            order.prod_id = ci.ProductId;

            db.XhOrders.InsertOnSubmit(order);

            XhProduct product = db.XhProducts.Single(p => p.prod_id == ci.ProductId);

            //substract <quantity> units from stock for this product
            //we can't have negative values in stock!
            int tempstock = product.prod_stock - order.ord_quantity;
            if (product.prod_stock > 0 && tempstock > 0) product.prod_stock = tempstock;

            //write changes
            db.SubmitChanges();
        }
    }
}