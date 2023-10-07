
namespace TryEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDbContext { };
            var emp = new Employee { Name = "emp1" };

            _context.Add(emp);
            _context.SaveChanges();

            #region EF Descussion
            //Entity Framework Core 
            //is more and more faster than ef6 legacy




            //When install ef6 -> you install ALL Libraries
            //that related to ef
            //ef to oracle
            //ef to mysql
            //ef to SqlServer
            //ef to postgrad
            //ef migration tools


            //ef core is component based
            //Microsoft.EntityFrameworkCore.SqlServer;
            //Microsoft.EntityFrameworkCore.Tools;    //EF CLI with migration
            //Microsoft.EntityFrameworkCore.Design; 
            #endregion

            #region EF Declare
            //CompanyModel db = new();
            //ef6 will run
            //Ef6 run with default starategy for create DB called
            ///Create Database If Not Exists
            //Db.Database.DropCreateDatabaseAlways();
            //db.Database.CreateDatabaseIfNotExists();

            ////Ef Core will cause Error
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();


            //Employee e1 = new Employee {Name="Abdelrahman",Email="a",Address="Ism",Age=22,DeptId=null,Salary=12345 };

            ////db.Employees.Add(e1);
            ////db.Entry(e1).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            ////with EF Core SaveChanges ()Will no fire error with validation
            ////If you want to fire error , override it
            //db.Add(e1);
            //db.SaveChanges();

            #endregion

            #region First,FirstOrDefault,Single,SingleOrDefault,Last,LastOrDefault
            //CompanyModel db = new();

            //var e1 = db.Employees.SingleOrDefault(ww=>ww.DeptId==22);

            //Console.WriteLine(e1);

            #endregion

            #region Local Storage , Find() => return Single object
            ////Local Storage: temprarily place in memory 
            /////save data for last trasactions from DB

            //CompanyModel db = new CompanyModel();

            //var emps = db.Employees.Where(ww => ww.DeptId == 1).ToList();

            //Console.WriteLine(db.Employees.Local.Count); //2

            //var emps2 = db.Employees.Where(ww => ww.DeptId == 2).ToList();
            //Console.WriteLine(db.Employees.Local.Count); //2

            //var q1 = db.Employees.Local.Where(ww => ww.DeptId == 2).ToList(); //


            //var q2 = db.Employees.Find(33);
            ////Search in local storage , if exists Done
            ////if not, will connect and search in Db if exists done
            ////if not , return null and will not fire error



            #endregion

            #region Insert ,update,Delete
            //CompanyModel db = new();
            
            //var e1 = new Employee { Name = "Ziad", Address = "Aswan", Age = 22, DeptId = 2, Email = "Z@z.z" ,Salary=1234};
            //db.Add(e1);

            //var e2 = db.Employees.Find(2);
            //e2.Email = "Fatma@Gmail.com";
            //db.Update(e2);

            //var e3= db.Employees.Find(3);
            //db.Remove(e3);

            //db.SaveChanges();

            #endregion
        }
    }
}