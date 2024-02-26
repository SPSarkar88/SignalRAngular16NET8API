using System.ComponentModel.DataAnnotations;

namespace MicroBlog.API.Query
{
    public class UpdatePostCommand
    {
        public string Id { get; set; }
        public string Uid { get; set; }

        [Required]
        [MaxLength(250)]
        public string PostContent { get; set; }
    }
}
