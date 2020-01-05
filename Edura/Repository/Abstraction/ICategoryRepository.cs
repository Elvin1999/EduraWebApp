using Edura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Repository.Abstraction
{
   public interface ICategoryRepository:IRepository<Category>
    {
        Category GetByName(string name);
    }
}
