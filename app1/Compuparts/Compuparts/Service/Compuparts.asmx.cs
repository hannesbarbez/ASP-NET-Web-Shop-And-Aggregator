using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using app0.App_Logic;

namespace app0.Service
{
    /// <summary>
    /// Summary description for Compuparts
    /// </summary>
    [WebService(Namespace = "http://compuparts.notld/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Compuparts : System.Web.Services.WebService
    {
        [WebMethod]
        public ServiceResponse GetAllInformation(int prod_id)
        {
            ServiceResponse response = new ServiceResponse();

            //Returns a date in the past if prod_id does not exist
            response.DeliveryDate = ServiceHelper.GetDeliveryDate(prod_id);

            //Returns -1 if prod_id does not exist
            response.Price = ServiceHelper.GetPrice(prod_id);

            //Returns -1 if prod_id does not exist
            response.QuantityInStock = ServiceHelper.GetStock(prod_id);

            return response;
        }

        /// <summary>
        /// Returns -1 if prod_id does not exist
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        [WebMethod]
        public int GetStock(int prod_id)
        {
            return ServiceHelper.GetStock(prod_id);
        }

        /// <summary>
        /// Returns -1 if prod_id does not exist
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        [WebMethod]
        public double GetPrice(int prod_id)
        {
            return ServiceHelper.GetPrice(prod_id);
        }

        /// <summary>
        /// Returns a date in the past if prod_id does not exist
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        [WebMethod]
        public DateTime GetDeliveryDate(int prod_id)
        {
            return ServiceHelper.GetDeliveryDate(prod_id);
        }
    }
}
