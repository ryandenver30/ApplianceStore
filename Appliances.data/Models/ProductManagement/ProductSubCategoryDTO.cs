using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appliances.data.Models.ProductManagement
{
    public class ProductSubCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string OperatingSystem { get; set; }
        public string Description { get; set; }
    }
}