using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Api.Controllers.CategoryController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoryService.CreateCategoryAsync(dto);
            return StatusCode(201, "Category created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryCreateDTO dto)
        {
            var existing = await _categoryService.GetCategoryByIdAsync(id);
            if (existing == null)
                return NotFound($"Category with ID {id} not found.");

            await _categoryService.UpdateCategoryAsync(id, dto);
            return Ok("Category updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var existing = await _categoryService.GetCategoryByIdAsync(id);
            if (existing == null)
                return NotFound($"Category with ID {id} not found.");

            await _categoryService.SoftDeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
