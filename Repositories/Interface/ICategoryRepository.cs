using API.Models.Domain;

namespace API.Repositories.Interface;

public interface ICategoryRepository
{
  Task<Category> CreateCategoryAsync(Category category);
  Task<Category?> DeleteCategoryAsync(Category category);
  Task<IEnumerable<Category>> GetCategoriesAsync();
  Task<Category?> GetCategoryAsync(Guid id);
  Task<Category?> UpdateCategoryAsync(Category category);
}
