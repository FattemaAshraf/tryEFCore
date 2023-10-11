

using System.ComponentModel.DataAnnotations.Schema;

namespace TryEFCore.Models
{
    //[Index(nameof(Url), IsUnique =true)] is true means its not repeateed
    //[Index(nameof(Url),nameof(BlogId))] //composite index


    public class Blog //parent or principles table
    {
        public int BlogId { get; set; } //principle keeyy
        [Required]
        //name fore url for column in database and change datatype
        [Column("BlogUrl", TypeName = "varchar(200)")]
        public string Url { get; set; }
        public string comment { get; set; }

        public DateTime Date { get; set; }
        public string Rating { get; set; }
        public List<Post> Posts { get; set; } // collection navigation property
        public BlogImage BlogImage { get; set; } //navigation property
    }
}
