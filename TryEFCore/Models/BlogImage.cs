using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryEFCore.Models
{
    public class BlogImage //independant table for Blog table
    {
        public int Id { get; set; }

        public int BlogForeginKey { get; set; }

        public byte[] Image { get; set; }

        //[ForeignKey("BlogForeginKey")] if the name not BlogId you dont need foreginKey dataanotation
        public Blog Blog { get; set; } // navigation property
    }
}