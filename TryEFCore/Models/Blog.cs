﻿

namespace TryEFCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
