

using System.ComponentModel.DataAnnotations.Schema;

namespace TryEFCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        //name fore url for column in database
        [Column("BlogUrl")]
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
}
