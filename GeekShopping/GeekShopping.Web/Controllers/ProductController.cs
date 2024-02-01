using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            if (token == null)
                return Unauthorized();

            var products = await _productService.FindAllProducts(token);
            return View(products);
        }

        public Task<IActionResult> Create()
        {
            return Task.FromResult<IActionResult>(View());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                if (token == null)
                    return Unauthorized();

                var response = await _productService.CreateProduct(model, token);

                if (response != null) 
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            if (token == null)
                return Unauthorized();

            var model = await _productService.FindProductById(id, token);

            if (model != null) 
                return View(model);

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                if (token == null)
                    return Unauthorized();

                var response = await _productService.UpdateProduct(model, token);

                if (response != null) 
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            if (token == null)
                return Unauthorized();

            var model = await _productService.FindProductById(id, token);

            if (model != null) 
                return View(model);

            return NotFound();
        }

        
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(ProductModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            if (token == null)
                return Unauthorized();

            var response = await _productService.DeleteProductById(model.Id, token);

            if (response) 
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}