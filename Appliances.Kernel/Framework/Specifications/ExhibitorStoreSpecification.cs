using Appliances.Kernel.Framework.Modules.StoreManagement;
using Appliances.Kernel.Framework.Repository;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Specifications
{
    public class ExhibitorStoreSpecification : ISpecification<ExhibitorAddress>
    {
        private ExhibitorStoreCriteria _criteria;

        public ExhibitorStoreSpecification(ExhibitorStoreCriteria criteria)
        {
            _criteria = criteria;
        }

        public Expression<Func<ExhibitorAddress, bool>> Expression
        {
            get
            {
                var builder = PredicateBuilder.True<ExhibitorAddress>();

                if (_criteria.location != null)
                    builder = builder.And(x => x.Location.Equals(_criteria.location));

                return builder;
            }
        }

        
    }
}
