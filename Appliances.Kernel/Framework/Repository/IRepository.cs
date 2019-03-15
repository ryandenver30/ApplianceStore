using Appliances.Kernel.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Repository
{
    public interface IRepository<T> where T : Entity
    {
        Guid Add(T entity);
        void Update(T entity);
        void Delete(Guid entityId);

        IList<T> Get();
        T GetById(Guid entityId);
        IList<T> Find(ISpecification<T> specification);
        int Count(ISpecification<T> specifivation);
    }
}
