using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app0.App_Data;

namespace app0.App_Logic
{
    internal static class Customer
    {
        /// <summary>
        /// Checks if a given user exists in database
        /// </summary>
        /// <returns></returns>
        internal static bool AuthenticateCustomer(string mail, string password)
        {
            UthDataContext db = new UthDataContext();

            var v = db.UthCustomers.Where(s => s.cust_mail.Equals(mail) && s.cust_password.Equals(password));
            if (v.Count() == 1) return true;
            return false;
        }
    }
}