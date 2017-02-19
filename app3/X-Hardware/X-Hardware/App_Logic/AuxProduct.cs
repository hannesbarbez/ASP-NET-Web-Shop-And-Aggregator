using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app0.App_Data;

namespace app0.App_Logic
{
    internal class AuxProduct
    {
        internal int ImageId { get; set; }
        internal string Name { get; set; }
        internal double Price { get; set; }
        internal string Manufacter { get; set; }
        internal int Id { get; set; }
        internal int Stock { get; set; }
        internal string Model { get; set; }
        internal string Category { get; set; }
        internal int CategoryId { get; set; }
        internal string Description { get; set; }
    }
}