using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Specifications
{
    public class ExhibitorStoreCriteria
    {
        public DbGeography location { get; set; }
    }
}
