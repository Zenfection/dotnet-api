using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.Models.Domain;
using dotnet_api.Models.DTO;
using dotnet_api.Repositories.Interface;

namespace dotnet_api.Controllers

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
      return Ok(categories);
    }
  }
}
