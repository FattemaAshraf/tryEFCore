using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//.net 7
//normal behavior for reference type >  Not Carry null
namespace TryEFCore
{

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }  //not null
        public int? Age { get; set; }
        [EmailAddress]
        public string Email { get; set; } //New
        public decimal? Salary { get; set; }
        public string Address { get; set; } //not null
        public DateTime TimeStamp { get;}=DateTime.Now;
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        public virtual Department Department { get; set; }

        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}:{DeptId}";
        }
    }
}
