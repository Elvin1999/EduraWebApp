using Edura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Models
{
    public class ProductListModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PageInfo { get; set; }
    }
}
