using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using StockApp.Models;
using System.Diagnostics;

namespace StockApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductServices _productService;

        public HomeController(ApplicationContext dbContext)
        {
            _productService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllViewModel());
        }

    }
}
