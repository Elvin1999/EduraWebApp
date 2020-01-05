using Edura.Entities;
using Edura.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : IProductRepository
    {
        private EduraContext context;

        public EfProductRepository(EduraContext context)
        {
            this.context = context;
        }

        public void Add(Product entity)
        {
            context.Products.Add(entity);
        }

        public void Delete(Product entity)
        {
            context.Products.Remove(entity);
        }

        public void Edit(Product entity)
        {
            context.Entry<Product>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IQueryable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return context.Products.Where(predicate);
        }

        public IQueryable<Product> GetAll()
        {
            return context.Products;
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(i => i.ProductId == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
