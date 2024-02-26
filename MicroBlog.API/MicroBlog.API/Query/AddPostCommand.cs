using System.ComponentModel.DataAnnotations;

namespace MicroBlog.API.Query
{
    public class AddPostCommand
    {
        [Required]
        [MaxLength(250)]
        public string PostContent { get; set; }
    }
}
