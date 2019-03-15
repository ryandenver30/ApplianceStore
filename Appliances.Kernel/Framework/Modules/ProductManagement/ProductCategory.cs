using Appliances.Kernel.Framework.Modules.StoreManagement;
using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Modules.ProductManagement
{
    [Table("ProductCategory")]
    public class ProductCategory : MasterEntity
    {
        public string CategoryName { get; set; }
        public virtual ICollection<ExhibitorStore> ExhibitorStores { get; set; }

        public ProductCategory()
        {

        }
        private ProductCategory(string name)
        {
            this.CategoryName = name;
        }
        public ProductCategory Create(string name)
        {
            return new ProductCategory(name);
        }
        public void Update(string name)
        {
            this.CategoryName = name;
        }
    }
}
