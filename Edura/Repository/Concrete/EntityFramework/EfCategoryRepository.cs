using Edura.Entities;
using Edura.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private EduraContext context;

        public EfCategoryRepository(EduraContext context)
        {
            this.context = context;
        }
        public void Add(Category entity)
        {
            context.Category.Add(entity);
        }

        public void Delete(Category entity)
        {
            context.Category.Remove(entity);
        }

        public void Edit(Category entity)
        {
            context.Entry<Category>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IQueryable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return context.Category.Where(predicate);
        }

        public IQueryable<Category> GetAll()
        {
            return context.Category;
        }

        public Category GetById(int id)
        {
            return context.Category.FirstOrDefault(i => i.CategoryId == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
