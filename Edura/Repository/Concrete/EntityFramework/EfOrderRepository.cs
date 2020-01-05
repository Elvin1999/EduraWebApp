using Edura.Entities;
using Edura.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EfOrderRepository : EfRepository<Order>,IOrderRepository
    {
        public EfOrderRepository(EduraContext context) : base(context)
        {

        }
    }
}
