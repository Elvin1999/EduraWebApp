using Edura.Entities;
using Edura.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : EfRepository<Product>,IProductRepository
    {
        public EfProductRepository(EduraContext context) : base(context)
        {
        }
        public EduraContext EduraContext
        {
            get
            {
                return context as EduraContext;
            }
        }
        public List<Product> GetTop5Products()
        {
            return EduraContext.Products.OrderByDescending(i => i.ProductId)
                .Take(5)
                .ToList();
        }
    }
}
