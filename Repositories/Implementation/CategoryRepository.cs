using dotnet_api.Data;
using dotnet_api.Models.Domain;
using dotnet_api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Repositories.Implementation;

public class CategoryRepository(ApplicationDbContext dbcontext) : ICategoryRepository
{

  private readonly ApplicationDbContext _dbcontext = dbcontext;

  public async Task<Category> CreateCategoryAsync(Category category)
  {
    await _dbcontext.Categories.AddAsync(category);
    await _dbcontext.SaveChangesAsync();
    return category;
  }

  public async Task<IEnumerable<Category>> GetCategoriesAsync()
  {
    return await _dbcontext.Categories.ToListAsync();
  }
}
