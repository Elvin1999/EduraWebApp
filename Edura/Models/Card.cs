using Edura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Models
{
    public class Card
    {
        private List<CardLine> products = new List<CardLine>();
        public List<CardLine> Products => products;
        public void Add(Product prd,int quantity)
        {
            var item = products
                .Where(i => i.Product.ProductId == prd.ProductId)
                .FirstOrDefault();
            if (item == null)
            {
                products.Add(
                    new CardLine() {
                     Product=prd,
                      Quantity=quantity
                    }
                    );
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public void Remove(Product prd)
        {
            products.RemoveAll(i=>i.Product.ProductId==prd.ProductId);
        }
        public double TotalPrice()
        {
            return products.Sum(i => i.Product.Price * i.Quantity);
        }
        public void ClearAll()
        {
            products.Clear();
        }
    }
}
