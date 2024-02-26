using System.ComponentModel.DataAnnotations;

namespace MicroBlog.API.Models
{
    public class Image : BaseModel
    {
        [MaxLength(250)]
        public string Path { get; set; }

    }
}