using Edura.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Edura.Components
{
    public class FeaturedProducts:ViewComponent
    {
        private IProductRepository productRepository;

        public FeaturedProducts(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(productRepository
                .GetAll()
                .Where(i=>i.IsApproved && i.IsFeatured)
                .ToList());
        }
    }
}
