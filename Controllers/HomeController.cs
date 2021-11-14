using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InTheBag.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace InTheBag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WishIndex()
        {
            Wishes myWishes = new Wishes { ID = 1, wish1 = "Wisdom", wish2 = "Health", wish3 = "Happiness" };
            string jsonWishes = JsonConvert.SerializeObject(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View();
        }
        public IActionResult NewWishIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewWishIndex(Wishes model)
        {
            Wishes myWishes = new Wishes { ID = 1, wish1 = Request.Form["wish1"], wish2 = Request.Form["wish2"], wish3 = Request.Form["wish3"] };
            string jsonWishes = JsonConvert.SerializeObject(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View("WishIndex");
        }
        public IActionResult IndexViewBag()
        {
            IList<string> Wishlist = new List<string>();
            Wishlist.Add("Peace");
            Wishlist.Add("Health");
            Wishlist.Add("Happiness");
            ViewBag.Wishlist = Wishlist;
            return View();
        }
        public IActionResult IndexViewData()
        {
            IList<string> Wishlist = new List<string>();
            Wishlist.Add("Quies");
            Wishlist.Add("Salutem");
            Wishlist.Add("Beatitudinem");
            ViewData["Wishlist"] = Wishlist;
            return View();
        }
        public IActionResult IndexTempData()
        {
            IList<string> Wishlist = new List<string>();
            Wishlist.Add("La Paz");
            Wishlist.Add("La Salud");
            Wishlist.Add("La Felicidad");
            TempData["Wishlist"] = Wishlist;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
