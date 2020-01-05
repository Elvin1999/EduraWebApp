using Edura.Entities;
using Edura.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        
        public EfCategoryRepository(EduraContext context):base(context)
        {
        }
        public EduraContext EduraContext { get {
                return context as EduraContext;
            } }
        public Category GetByName(string name)
        {
            return EduraContext.Category
                .Where(i => i.CategoryName == name)
                .FirstOrDefault();
        }
    }
}
