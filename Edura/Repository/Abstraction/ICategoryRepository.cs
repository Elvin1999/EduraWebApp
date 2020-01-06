using Edura.Entities;
using Edura.Models;
using System.Collections;
using System.Collections.Generic;

namespace Edura.Repository.Abstraction
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string name);
        IEnumerable<CategoryModel> GetCategoryWithCount();
    }
}
