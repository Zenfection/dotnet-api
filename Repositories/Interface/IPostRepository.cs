
using API.Models.Domain;

namespace API.Repositories.Interface;

public interface IPostRepository
{
    Task<Post> CreatePostAsync(Post post);
    Task<Post?> DeletePostAsync(Post post);
    Task<IEnumerable<Post>> GetPostsAsync();
    Task<Post?> GetPostAsync(Guid id);
    Task<Post?> UpdatePostAsync(Post post);
}
