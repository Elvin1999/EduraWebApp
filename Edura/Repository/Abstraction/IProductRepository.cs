using Edura.Entities;
using System.Collections.Generic;

namespace Edura.Repository.Abstraction
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetTop5Products();
    }
}
