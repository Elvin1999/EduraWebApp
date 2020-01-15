using Edura.Infrastructe;
using Edura.Models;
using Edura.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Controllers
{
    public class CardController:Controller
    {
        private IProductRepository productRepository;

        public CardController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(GetCard());
        }
        public IActionResult AddToCard(int productId,int quantity=1)
        {
            var item = productRepository.GetById(productId);
            if (item != null)
            {
                var card = GetCard();
                card.Add(item, quantity);
                SaveCard(card);
            }

            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCard(int productId)
        {
            var product = productRepository.GetById(productId);
            if (product != null)
            {
                var card = GetCard();
                card.Remove(product);
                SaveCard(card);
            }
            return RedirectToAction("Index");
        }
        private void SaveCard(Card card)
        {
            HttpContext.Session.SetJson("Card", card);
        }

        private Card GetCard()
        {
            return HttpContext.Session.GetJson<Card>("Card") ?? new Card();
        }
    }
}
