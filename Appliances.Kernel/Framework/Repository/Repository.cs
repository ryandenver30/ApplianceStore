using Appliances.Kernel.Modules.Entities;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public Guid Add(T entity)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                unitOfWork.DbContext.Set<T>().Add(entity);
                unitOfWork.SaveChanges();
                return entity.Id;
            }
        }

        public int Count(ISpecification<T> specification)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                return unitOfWork.DbContext.Set<T>().AsExpandable().Where(specification.Expression).Count();
            }
        }

        public void Delete(Guid entityId)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                unitOfWork.DbContext.Set<T>().Remove(GetById(entityId));

                unitOfWork.SaveChanges();
            }
        }

        public IList<T> Find(ISpecification<T> specification)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                var queryable = unitOfWork.DbContext.Set<T>().AsExpandable().Where(specification.Expression);
                return queryable.ToList();
            }
        }

        public IList<T> Get()
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Writing))
            {
                return unitOfWork.DbContext.Set<T>().ToList();
            }
        }

        public T GetById(Guid entityId)
        {
            using (var unitOfWork = new UnitOfWorkScope<AppliancesContext>(UnitOfWorkScopePurpose.Reading))
            {
                return unitOfWork.DbContext.Set<T>().SingleOrDefault(x => x.Id == entityId);
            }
        }

        public void Update(T entity)
        {
            //Nothing to do here. Entity framework will automatically save changed entities
        }
    }
}
