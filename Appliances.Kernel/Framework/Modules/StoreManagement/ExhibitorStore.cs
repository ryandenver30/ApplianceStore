using Appliances.Kernel.Framework.Modules.ProductManagement;
using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Modules.StoreManagement
{
    public class ExhibitorStore : MasterEntity
    {
        public string Name { get; set; }
        public string WebsiteURL { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
