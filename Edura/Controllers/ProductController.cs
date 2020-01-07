using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.Models;
using Edura.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edura.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        public int PageSize = 2;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(string category,int page=1)
        {
            var products = productRepository.GetAll();
            if (!string.IsNullOrEmpty(category))
            {
                products = products
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category.CategoryName == category));
            }
            products.Skip((page-1)*PageSize).Take(PageSize);
            return View(products);
        }
        public IActionResult Details(int id)
        {

            return View(
                productRepository
                .GetAll()
                .Where(i=>i.ProductId==id)
                .Include(i=>i.Images)
                .Include(i=>i.ProductAttributes)
                .Include(i=>i.ProductCategories)
                .ThenInclude(i=>i.Category)
                .Select(
                    i => new ProductDetailsModel() {
                    Product=i,
                     ProductAttributes=i.ProductAttributes,
                      ProductImages=i.Images,
                      Categories=i.ProductCategories.Select(a=>a.Category).ToList()
                    }).FirstOrDefault()
                );
        }
    }
}