using System.ComponentModel.DataAnnotations;

namespace MicroBlog.Common.Query
{
    public class AddPostCommand
    {
        [Required]
        [MaxLength(250)]
        public string PostContent { get; set; }
    }
}
