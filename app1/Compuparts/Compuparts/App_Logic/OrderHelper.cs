using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app0.App_Data;
using System.Net.Mail;

namespace app0.App_Logic
{
    internal static class OrderHelper
    {
        /// <summary>
        /// Returns the next available orderId
        /// </summary>
        /// <returns>the next available orderId</returns>
        internal static int GetNextOrderId()
        {
            CpDataContext db = new CpDataContext();

            int[] i = (from o in db.CpOrders
                       orderby o.ord_code descending
                       select o.ord_code).Take(1).ToArray();
            return i[0] + 1;
        }

        internal static void MailOrderDetails(string emailaddress)
        {
            CpOrder order = new CpOrder();
            ShoppingCart cart = ShoppingCart.GetShoppingCart();

            string subj = "Order Confirmation";
            string body = "Compuparts.notld order confirmation" + Environment.NewLine + Environment.NewLine + "Thank you for purchasing with us!" + Environment.NewLine
                + "This e-mail confirms your order with us. Please keep this mail for further reference." + Environment.NewLine
                + Environment.NewLine + "Orders:" + Environment.NewLine + Environment.NewLine;

            double total = 0;
            foreach (CartItem ci in cart.Items)
            {
                //Make changes to mailbody
                double subtotal = ci.Quantity * ci.UnitPrice;
                body += "+ " + ci.Quantity + " x \"" + ci.Manufacter + " " + ci.Name + " " + ci.Model + "\" @ " + ci.UnitPrice + " EUR/item = " + subtotal + " EUR subtotal." + Environment.NewLine + Environment.NewLine;
                total += subtotal;
            }

            body += "Total Price: " + total + " EUR" + Environment.NewLine + Environment.NewLine
                + "The following methods of payment are accepted:" + Environment.NewLine
                + "* By cash payment on delivery" + Environment.NewLine + "* By bank transfer no more than 5 days after delivery." + Environment.NewLine + Environment.NewLine
                + "If you choose to work by bank transfer, please use the following information:" + Environment.NewLine
                + "* International Bank Account Number: IBEN XX98 7654 3210 0123" + Environment.NewLine
                + "* Comment: Payment for Order Number " + (GetNextOrderId() - 1).ToString();

            SendMail(emailaddress, "inqueries@compuparts.notld", subj, body);
        }

        internal static void SendMail(string to, string from, string subject, string body)
        {
            MailAddress maTo = new MailAddress(to);
            MailAddress maFrom = new MailAddress(from);

            MailMessage objEmail = new MailMessage();
            objEmail.From = (maFrom);
            objEmail.To.Add(maTo);
            objEmail.Subject = subject;
            objEmail.Body = body;

            SmtpClient client = new SmtpClient();

            // Dit moet uitstaan, anders ga je de mailserver anoniem benaderen
            client.UseDefaultCredentials = false;   
            System.Net.NetworkCredential credential = new System.Net.NetworkCredential("emailadres@server.com", " aFantasticPassword");
            client.Credentials = credential;

            //mag je aan of uit zetten, maakt niet uit
            client.EnableSsl = true;
            client.Send(objEmail);
        }
    }
}