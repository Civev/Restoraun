using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restoraun.IServices;
using Restoraun.Models;

namespace Restoraun.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            var response = await _services.GetAllProductsAsync<ResponseDTO>();
            if(response != null && response.IsSuccess) 
                products =  JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();  
        }
        [HttpPost]
       
        public async Task<IActionResult> ProductCreate(ProductDTO productDTO)
        {

            var response = await _services.CreateProductAsync<ResponseDTO>(productDTO);
            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(ProductIndex));
            return View(productDTO);
        }
      
        public async Task<IActionResult> ProductEdit(int productId)
        {
            ProductDTO products = null;
            var response = await _services.GetProductByIdAsync<ResponseDTO>(productId);
            if (response != null && response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(products);

            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDTO productDTO)
        {

            var response = await _services.UpdateProductAsync<ResponseDTO>(productDTO);
            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(ProductIndex));
            return View(productDTO);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            ProductDTO products = null;
            var response = await _services.GetProductByIdAsync<ResponseDTO>(productId);
            if (response != null && response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(products);

            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDTO productDTO)
        {

            var response = await _services.DeleteProductAsync<ResponseDTO>(productDTO.ProductId);
            if (response.IsSuccess)
                return RedirectToAction(nameof(ProductIndex));
            return View(productDTO);
        }
    }
}
