using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace TryEFCore.Models
{
    [Table("Posts", Schema = "blogging")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Blog Blog { get; set; }
    }
}
