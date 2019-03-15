using Appliances.Kernel.Framework.Repository;
using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Specifications
{
    public class GetAllSpecification<T> : ISpecification<T> where T : Entity
    {
        public Expression<Func<T, bool>> Expression
        {
            get
            {
                return x => true;
            }
        }
    }
}
