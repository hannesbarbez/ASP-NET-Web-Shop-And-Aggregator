using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app0.App_Data;

namespace app0.App_Logic
{
    public class ServiceResponse
    {
        public int QuantityInStock;
        public double Price;
        public DateTime DeliveryDate;
    }

    internal static class ServiceHelper
    {
        /// <summary>
        /// Returns -1 if prod_id does not exist
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        internal static int GetStock(int prod_id)
        {
            XhDataContext db = new XhDataContext();
            try
            {
                var v = db.XhProducts.Single(p => p.prod_id == prod_id);
                return v.prod_stock;
            }
            catch
            {
                return -1;
            }

        }

        /// <summary>
        /// Returns -1 if prod_id does not exist
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        internal static double GetPrice(int prod_id)
        {
            XhDataContext db = new XhDataContext();
            try
            {
                var v = db.XhProducts.Single(p => p.prod_id == prod_id);
                return v.prod_price;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns a date in the past if prod_id does not exist
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        internal static DateTime GetDeliveryDate(int prod_id)
        {
            int stock = GetStock(prod_id);

            //All stock products ship within 5 days, products we no longer have in stock might take up to 10 days.
            if (stock == 0) return DateTime.Now.AddDays(10);
            else if (stock > 0) return DateTime.Now.AddDays(5);

            //if prod_id does not exist
            else return new DateTime(1980, 1, 1);
        }
    }
}