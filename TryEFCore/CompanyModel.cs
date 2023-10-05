using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity; //Legacy ef 6
using Microsoft.EntityFrameworkCore;
namespace TryEFCore
{
    public class CompanyModel:DbContext
    {
        public CompanyModel()
        {
            
        }

        public CompanyModel(DbContextOptions options):base(options)
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data source=.,initial catalog=FullStackDotNetMiniaD07;integrated security=true");
            optionsBuilder.UseSqlServer("Server=.;Database=FullStackDotNetMiniaD07;Trusted_connection=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

    }
}
