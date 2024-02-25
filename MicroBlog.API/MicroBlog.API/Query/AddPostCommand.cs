using System.ComponentModel.DataAnnotations;

namespace MicroBlog.API.Query
{
    public class AddPostCommand
    {
        public string Uid { get; set; }
        [Required]
        [MaxLength(250)]
        public string PostContent { get; set; }
        public string ImageId { get; set; }
    }
}
