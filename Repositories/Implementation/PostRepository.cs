using API.Data;
using API.Models.Domain;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation;

public class PostRepository(ApplicationDbContext dbcontext) : IPostRepository
{
    private readonly ApplicationDbContext _dbcontext = dbcontext;

    public async Task<Post> CreatePostAsync(Post post)
    {
        await _dbcontext.Posts.AddAsync(post);
        await _dbcontext.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> DeletePostAsync(Post post)
    {
        var postToDelete = await _dbcontext.Posts.FirstOrDefaultAsync(
            post => post.Id == post.Id
        );

        if (postToDelete != null)
        {
            _dbcontext.Posts.Remove(postToDelete);
            await _dbcontext.SaveChangesAsync();
            return postToDelete;
        }
        return null;
    }

    public Task<Post?> GetPostAsync(Guid id)
    {
        return _dbcontext.Posts.Include(post => post.Categories).FirstOrDefaultAsync(post => post.Id == id);
    }

    public async Task<IEnumerable<Post>> GetPostsAsync()
    {
        return await _dbcontext.Posts.Include(post => post.Categories).ToListAsync();
    }

    public async Task<Post?> UpdatePostAsync(Post post)
    {
        var postToUpdate = await _dbcontext.Posts.FirstOrDefaultAsync(
            post => post.Id == post.Id
        );

        if (postToUpdate != null)
        {
            _dbcontext.Entry(postToUpdate).CurrentValues.SetValues(post);
            await _dbcontext.SaveChangesAsync();
            return postToUpdate;
        }
        return null;
    }
}
