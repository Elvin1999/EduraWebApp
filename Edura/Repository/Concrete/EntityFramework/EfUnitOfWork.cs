using Edura.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EduraContext context;

        public EfUnitOfWork(EduraContext context)
        {
            this.context = context;
        }
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                return productRepository ?? (productRepository = new EfProductRepository(context));
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                return categoryRepository ?? (categoryRepository = new EfCategoryRepository(context));
            }

        }

        public void Dispose()
        {
            context.Dispose();
        }

        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
