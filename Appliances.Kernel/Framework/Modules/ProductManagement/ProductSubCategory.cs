using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Modules.ProductManagement
{
    [Table("ProductSubCategory")]
    public class ProductSubCategory : MasterEntity
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string OperatingSystem { get; set; }
        public string Description { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public ProductSubCategory()
        {

        }
        private ProductSubCategory(string name,string brandName,string operatingSystem,string description)
        {
            this.Name = name;
            this.BrandName = brandName;
            this.OperatingSystem = operatingSystem;
            this.Description = description;
        }
        public static ProductSubCategory Create(string name, string brandName, string operatingSystem, string description)
        {
            return new ProductSubCategory(name, brandName, operatingSystem, description);
        }
        public void Update(string name, string brandName, string operatingSystem, string description)
        {
            this.Name = name;
            this.BrandName = brandName;
            this.OperatingSystem = operatingSystem;
            this.Description = description;
        }
    }
}
