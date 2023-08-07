using CasgemMicroservices.Catalog.Dtos.CategoryDtos;
using CasgemMicroservices.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservices.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _categoryService.GetCategoryListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var values = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto p)
        {
             await _categoryService.CreateCategoryAsync(p);
            return Ok("Kategori eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto p)
        {
            await _categoryService.UpdateCategoryAsync(p);
            return Ok("Kategori güncellendi");
        }
    }
}
