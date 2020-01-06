using Edura.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Edura.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        private IUnitOfWork unitOfWork;
        public HomeController(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(unitOfWork.ProductRepository.GetAll());
        }

    }
}
