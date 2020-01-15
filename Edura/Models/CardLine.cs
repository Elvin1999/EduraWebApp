using Edura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Models
{
    public class CardLine
    {
        public int CardLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
