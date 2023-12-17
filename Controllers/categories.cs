using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories.Interface;

namespace API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryRepository categoryRepository) : ControllerBase
    {


        private readonly ICategoryRepository _categoryRepository = categoryRepository;


        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await _categoryRepository.CreateCategoryAsync(category);

            var response = new Category
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            var response = new List<Category>();
            foreach (var category in categories)
            {
                response.Add(new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var response = new Category
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(Guid id, UpdateCategoryDto request)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = request.Name;
            category.UrlHandle = request.UrlHandle;

            await _categoryRepository.UpdateCategoryAsync(category);

            var response = new Category
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteCategoryAsync(category);

            return NoContent();
        }
    }
}
