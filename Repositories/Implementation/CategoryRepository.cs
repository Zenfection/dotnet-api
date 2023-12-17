using API.Data;
using API.Models.Domain;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation;

public class CategoryRepository(ApplicationDbContext dbcontext) : ICategoryRepository
{

  private readonly ApplicationDbContext _dbcontext = dbcontext;

  public async Task<Category> CreateCategoryAsync(Category category)
  {
    await _dbcontext.Categories.AddAsync(category);
    await _dbcontext.SaveChangesAsync();
    return category;
  }

  public async Task<Category?> DeleteCategoryAsync(Category category)
  {
    var categoryToDelete = await _dbcontext.Categories.FirstOrDefaultAsync(
      category => category.Id == category.Id
    );

    if (categoryToDelete != null)
    {
      _dbcontext.Categories.Remove(categoryToDelete);
      await _dbcontext.SaveChangesAsync();
      return categoryToDelete;
    }
    return null;
  }

  public async Task<IEnumerable<Category>> GetCategoriesAsync()
  {
    return await _dbcontext.Categories.ToListAsync();
  }

  public async Task<Category?> GetCategoryAsync(Guid id)
  {
    return await _dbcontext.Categories.FirstOrDefaultAsync(
      category => category.Id == id
    );
  }

  public async Task<Category?> UpdateCategoryAsync(Category category)
  {
    var categoryToUpdate = await _dbcontext.Categories.FirstOrDefaultAsync(
      category => category.Id == category.Id
    );

    if (categoryToUpdate != null)
    {
      _dbcontext.Entry(categoryToUpdate).CurrentValues.SetValues(category);
      await _dbcontext.SaveChangesAsync();
      return categoryToUpdate;
    }
    return null;
  }
}
