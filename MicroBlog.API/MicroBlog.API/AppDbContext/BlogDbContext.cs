using MicroBlog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroBlog.API.AppDbContext
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            //modelBuilder.Entity<Post>()
            //    .HasOne(p => p.Image)
            //    .WithOne(i => i.Post)
            //    .HasForeignKey<Image>(i => i.PostId);

            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<Image>().HasKey(p => p.Id);
            //modelBuilder.Entity<Image>()
            //    .HasOne(p => p.Post)
            //    .WithOne(i => i.Image)
            //    .HasForeignKey<Post>(i => i.ImageId);

        }
    }
}
