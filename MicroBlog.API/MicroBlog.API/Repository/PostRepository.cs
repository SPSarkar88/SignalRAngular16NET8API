using MicroBlog.API.AppDbContext;
using MicroBlog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroBlog.API.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;
        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<Post> AddPost(Post post)
        {
            post.Id = Guid.NewGuid();
            post.UpdatedAt = DateTime.Now;
            post.CreatedAt = DateTime.Now;
            post.Uid = post.GetUid;
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        private async Task<Post?> GetPostWithTracking(Guid id, string uid)
        {
            return await _context.Posts
                .Where(x => x.Id == id)
                .Where(x => x.Uid == uid)
                .FirstOrDefaultAsync();
        }

        public async Task<Post?> GetPost(Guid id, string uid)
        {
            return await _context.Posts
                .AsNoTracking()
                //.Include(p => p.ImageId)
                .Where(x => x.Id == id)
                .Where(x => x.Uid == uid)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _context.Posts
                .AsNoTracking()
                //.Include(p => p.ImageId)
                .ToListAsync();
        }

        public async Task<bool> UpdatePost(Post post, Guid id, string uid)
        {
            post.UpdatedAt = DateTime.Now;
            _context.Posts.Update(post);
            var isUpdateSucess = await _context.SaveChangesAsync();
            return isUpdateSucess > 0;
        }

        public async Task<bool> DeletePost(Guid id, string uid)
        {
            var postToDelete = await GetPostWithTracking(id, uid);
            if (postToDelete == null)
                return false;
            _context.Posts.Remove(postToDelete);
            var isDeleteSucess = await _context.SaveChangesAsync();
            return isDeleteSucess > 0;
        }
    }
}