using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryEFCore.Models
{
    public class Department
    {
        //to add identity values (1,1)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<Employee> Posts { get; set; }
    }
}
