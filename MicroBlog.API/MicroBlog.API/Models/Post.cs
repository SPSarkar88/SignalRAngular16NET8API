using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace MicroBlog.API.Models
{
    public class Post : BaseModel
    {
        [Required]
        [MaxLength(250)]
        public string PostContent { get; set; }

        public Image Image { get; set; }

        public Guid ImageId { get; set; }
    }
}