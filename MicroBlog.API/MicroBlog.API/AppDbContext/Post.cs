using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace MicroBlog.API.AppDbContext
{
    public class Post : BaseModel
    {
        [Required]
        [MaxLength(250)]
        public string PostContent { get; set; }

        public Image Image { get; set; }

        public Guid ImageId { get; set; }
    }

    public class Image : BaseModel
    {
        [MaxLength(250)]
        public string Path { get; set; }
        
        public Guid PostId { get; set; }

        public Post Post { get; set; }
    }

    public class BaseModel
    {
        public Guid Id { get; set; }
        public string Uid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt = DateTime.Now;

        [NotMapped]
        public string GetUid => DateTime.Now.Ticks.ToString();
    }
}