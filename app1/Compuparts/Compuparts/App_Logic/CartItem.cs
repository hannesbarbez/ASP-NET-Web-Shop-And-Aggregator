using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app0.App_Data;

namespace app0.App_Logic
{
    public class CartItem : IEquatable<CartItem>
    {
        #region Properties

        // A place to store the quantity in the cart
        // This property has an implicit getter and setter.
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        private CpProduct  product = null;
        public CpProduct Prod
        {
            get
            {
                // Lazy initialization - the object won't be created until it is needed
                if (product == null)
                {
                    CpDataContext db = new CpDataContext();
                    product = db.CpProducts.Single(p => p.prod_id == ProductId);
                }
                return product;
            }
        }

        public string Description
        {
            get { return Prod.prod_desc; }
        }

        public int ImageId
        {
            get { return Prod.img_id; }
        }

        public double UnitPrice
        {
            get { return Prod.prod_price; }
        }

        public double TotalPrice
        {
            get { return UnitPrice * Quantity; }
        }

        public string Manufacter
        {
            get { return Prod.CpManufacter.man_name; }
        }
        
        public string Name
        {
            get { return Prod.prod_name; }
        }

        public string Model
        {
            get { return Prod.prod_model; }
        }

        public int Stock
        {
            get { return Prod.prod_stock; }
        }

        #endregion

        // CartItem constructor just needs a productId
        public CartItem(int productId)
        {
            this.ProductId = productId;
        }

        //This method is called by the Contains() method in the List class. Contains() method is used in the ShoppingCart AddItem() method
        public bool Equals(CartItem item)
         {
            return item.ProductId == this.ProductId;
        }
    }
}
