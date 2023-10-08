

using System.ComponentModel.DataAnnotations.Schema;

namespace TryEFCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        //name fore url for column in database and change datatype
        [Column("BlogUrl", TypeName = "varchar(200)")]
        public string Url { get; set; }

        public DateTime Date { get; set; }
        public string Rating { get; set; }
        public List<Post> Posts { get; set; }
        public BlogImage BlogImage { get; set; }
    }
}
