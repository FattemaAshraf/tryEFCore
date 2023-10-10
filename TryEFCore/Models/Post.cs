using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace TryEFCore.Models
{
    [Table("Posts", Schema = "blogging")]
    public class Post //dependent entity
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        public string BlogUrl { get; set; }
        public string Blogcomment { get; set; }
        public int BlogId { get; set; } //foreign key  //if you delete it,
                                        //you will create constrain also ==> called shadow reference
        public Blog Blog { get; set; } //reference navigation property //if you delete it, can't create constrain-navigation
    }
}
