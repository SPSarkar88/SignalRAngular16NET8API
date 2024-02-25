using MicroBlog.API.AppDbContext;
using MicroBlog.API.Models;

namespace MicroBlog.API.Repository
{
    public class ImageRepository
    {
        private readonly BlogDbContext _context;
        public ImageRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddImageToPost(string id)
        {
            var post = await _context.Posts.FindAsync(id);
            if(post == null)
            {
                throw new Exception("Post not found.");
            }
            var image = new Image
            {
                Id = Guid.NewGuid(),
                PostId = Guid.Parse(id.ToString())
            };
            post.Image = image;
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

    }
}
