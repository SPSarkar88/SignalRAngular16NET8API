using System.ComponentModel.DataAnnotations.Schema;

namespace MicroBlog.API.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string Uid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [NotMapped]
        public string GetUid => DateTime.Now.Ticks.ToString();
    }
}