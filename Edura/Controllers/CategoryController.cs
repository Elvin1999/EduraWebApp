using Edura.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Edura.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(categoryRepository.GetByName("Electronics"));
        }
    }
}
