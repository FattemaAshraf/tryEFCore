﻿using System;
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
        public int Price { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

    }
}
