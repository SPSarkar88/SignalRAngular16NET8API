using System.ComponentModel.DataAnnotations;

namespace MicroBlog.Common.Models
{
    public class Image : BaseModel
    {
        [MaxLength(250)]
        public string Path { get; set; }

    }
}