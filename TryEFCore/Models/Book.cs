using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryEFCore.Models
{
    public class Book
    {
        [Key]
        public int BookKey { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

    }
}
