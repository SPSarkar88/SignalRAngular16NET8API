using MicroBlog.API.Models;

namespace MicroBlog.API.Repository
{
    public interface IPostRepository
    {
        Task<Post> AddPost(Post post);
        Task<bool> DeletePost(Guid id, string uid);
        Task<Post?> GetPost(Guid id, string uid);
        Task<IEnumerable<Post>> GetPosts();
        Task<bool> UpdatePost(Post post, Guid id, string uid);
    }
}