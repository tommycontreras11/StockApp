using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace StockApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServices _productService;

        public ProductController(ApplicationContext dbContext)
        {
            _productService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllViewModel());
        }

        public IActionResult Create() {
            return View("SaveProduct", new SaveProductView());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveProductView vm)
        {
            await _productService.Add(vm);
            return RedirectToRoute(new {controller = "Product", Action="Index" } );
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveProduct", await _productService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductView vm)
        {
            await _productService.Update(vm);
            return RedirectToRoute(new { controller = "Product", Action = "Index" });

        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _productService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _productService.Delete(id);
            return RedirectToRoute(new { controller = "Product", Action = "Index" });
        }
    }
}
