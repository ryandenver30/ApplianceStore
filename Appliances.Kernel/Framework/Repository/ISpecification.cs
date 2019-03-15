using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Repository
{
    public interface ISpecification<T> where T : Entity
    {
        Expression<Func<T, bool>> Expression { get; }
    }
}
