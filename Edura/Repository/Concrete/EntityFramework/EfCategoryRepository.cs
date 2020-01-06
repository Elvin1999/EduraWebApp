using Edura.Entities;
using Edura.Models;
using Edura.Repository.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfRepository<Category>, ICategoryRepository
    {

        public EfCategoryRepository(EduraContext context) : base(context)
        {
        }
        public EduraContext EduraContext
        {
            get
            {
                return context as EduraContext;
            }
        }
        public Category GetByName(string name)
        {
            return EduraContext.Category
                .Where(i => i.CategoryName == name)
                .FirstOrDefault();
        }

        public IEnumerable<CategoryModel> GetCategoryWithCount()
        {
            return GetAll().Select(i => new CategoryModel() {
             CategoryId=i.CategoryId,
              CategoryName=i.CategoryName,
               Count=i.ProductCategories.Count()
            });
        }
    }
}
