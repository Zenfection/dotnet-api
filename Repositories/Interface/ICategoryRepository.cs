using dotnet_api.Models.Domain;

namespace dotnet_api.Repositories.Interface;

public interface ICategoryRepository
{
  Task<Category> CreateCategoryAsync(Category category);
  Task<IEnumerable<Category>> GetCategoriesAsync();
}
