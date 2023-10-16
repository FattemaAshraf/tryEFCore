using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryEFCore.Models
{
    public class MockData
    {
        public int id { get; set; }
        [MaxLength(50)]
        public string first_name { get; set; }
        [MaxLength(50)]
        public string last_name { get; set; }
        [MaxLength(50)]

        public string email { get; set; }
        [MaxLength(50)]
        public string gender { get; set; }

        [MaxLength(20)]
        public string ip_address { get; set; }


    }
}
