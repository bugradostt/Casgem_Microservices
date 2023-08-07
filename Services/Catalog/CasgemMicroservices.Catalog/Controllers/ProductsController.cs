
using CasgemMicroservices.Catalog.Dtos.ProductDtos;
using CasgemMicroservices.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservices.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productService.GetProductListWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto p)
        {
            await _productService.CreateProductAsync(p);
            return Ok("Ürün eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto p)
        {
            await _productService.UpdateProductAsync(p);
            return Ok("Ürün güncellendi");
        }
    }
}
