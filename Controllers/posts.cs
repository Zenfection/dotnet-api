using API.Models.Domain;
using API.Models.DTO;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(IPostRepository postRepository, ICategoryRepository categoryRepository) : ControllerBase
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(CreatePostDto request)
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
                IsVisible = request.IsVisible,
                CreatedAt = request.CreatedAt,
                UpdatedAt = request.UpdatedAt,
                Categories = new List<Category>(),
            };

            foreach (var categoryId in request.CategoriesId)
            {
                var category = await _categoryRepository.GetCategoryAsync(categoryId);
                if (category != null)
                {
                    post.Categories.Add(category);
                }
            }

            var blogpost = await _postRepository.CreatePostAsync(post);

            var response = new Post
            {
                Id = blogpost.Id,
                Title = blogpost.Title,
                Content = blogpost.Content,
                ShortDescription = blogpost.ShortDescription,
                UrlHandle = blogpost.UrlHandle,
                IsVisible = blogpost.IsVisible,
                CreatedAt = blogpost.CreatedAt,
                UpdatedAt = blogpost.UpdatedAt,
                Categories = blogpost.Categories.Select(category => new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                }).ToList()
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _postRepository.GetPostsAsync();
            var response = new List<Post>();
            foreach (var post in posts)
            {
                response.Add(new Post
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    ShortDescription = post.ShortDescription,
                    UrlHandle = post.UrlHandle,
                    IsVisible = post.IsVisible,
                    CreatedAt = post.CreatedAt,
                    UpdatedAt = post.UpdatedAt,
                    Categories = post.Categories.Select(category => new Category
                    {
                        Id = category.Id,
                        Name = category.Name,
                        UrlHandle = category.UrlHandle
                    }).ToList()
                });
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            var post = await _postRepository.GetPostAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            var response = new Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                ShortDescription = post.ShortDescription,
                UrlHandle = post.UrlHandle,
                IsVisible = post.IsVisible,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                Categories = post.Categories.Select(category => new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(Guid id, UpdatePostDto request)
        {
            var post = await _postRepository.GetPostAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            post.Title = request.Title;
            post.Content = request.Content;
            post.ShortDescription = request.ShortDescription;
            post.UrlHandle = request.UrlHandle;
            post.IsVisible = request.IsVisible;
            post.UpdatedAt = request.UpdatedAt;

            await _postRepository.UpdatePostAsync(post);

            var response = new Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                ShortDescription = post.ShortDescription,
                UrlHandle = post.UrlHandle,
                IsVisible = post.IsVisible,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                Categories = post.Categories.Select(category => new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(Guid id)
        {
            var post = await _postRepository.GetPostAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            await _postRepository.DeletePostAsync(post);

            return NoContent();
        }
    }
}
