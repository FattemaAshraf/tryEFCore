using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryEFCore.Models
{
    public class BlogImage
    {
        public int Id { get; set; }

        public int BlogForeginKey { get; set; }

        //[ForeignKey("BlogForeginKey")]
        public Blog Blog { get; set; }
    }
}