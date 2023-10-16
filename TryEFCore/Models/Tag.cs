
namespace TryEFCore.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public ICollection<Post> Posts { get; set; }
        //public List<PostTags> PostTags { get; set; }

    }
}
