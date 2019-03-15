using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appliances.data.Models.ProductManagement
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ModelNo { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
    }
}