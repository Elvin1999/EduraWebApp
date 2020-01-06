using Edura.Entities;
using Edura.Repository.Abstraction;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EfOrderRepository : EfRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(EduraContext context) : base(context)
        {

        }
    }
}
