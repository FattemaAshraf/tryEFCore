
namespace TryEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDbContext { };
            /*var emp = new Employee { FirstName = "Fatma" , LastName="Ashraf"};

            _context.Add(emp);
            _context.SaveChanges();*/

            #region | Select- find first last single |
            //select all
            /*var stocks = _context.MockData.ToList();
            foreach(var stock in stocks)
                Console.WriteLine(stock.first_name);*/

            //using find(); //if the data more than one
            var stock = _context.MockData.Find(10);
            Console.WriteLine($"ID: {stock.id} Name : {stock.first_name}");

            //single(); for identity data but make exception if //sequence sql no elements
            //didn't found data so we use SingleOrDefault(); default make null value
            var stockSingle = _context.MockData.SingleOrDefault(m => m.id == 10);
            Console.WriteLine(stockSingle == null ? "not found" : $"ID: {stockSingle.id} Name : {stockSingle.first_name}");

            //first(); //first item //sequence sql no elements
            //FirstOrDefault();  //using default if didn't need exception need null value
            var stockFirst = _context.MockData.First(m => m.id > 10);
            Console.WriteLine($"ID: {stockFirst.id} Name : {stockFirst.first_name}");

            //last(); //last item must using orderby //sequence sql no elements
            // exception using lastOrDefault();
            var stocksOdrdered = _context.MockData.OrderBy(m => m.first_name).Last(m => m.id > 20);
            Console.WriteLine(stocksOdrdered == null ? "not found" : $"ID: {stocksOdrdered.id} Name : {stocksOdrdered.first_name}");
            #endregion

            #region |filteration by where|
            //where().tolist();
            var stocksFilteration = _context.MockData.Where(m => m.id >10 && m.first_name.StartsWith("A")).ToList();
            //fiteration in database before come to front app
            //goes to server profider
            foreach (var stockF in stocksFilteration)
                Console.WriteLine($"id:{stockF.id} name {stockF.first_name}");
            #endregion

            #region Any vs All
            //Any(); //boolean value true if table have rows, false if don't have
            //Any(criteria) // if you wanna check ciriteria is existed or not

            //All(criteria); must cirteria -- must all rows match creiteria
            #endregion

            #region |Append vs Prepend|  happened in client side not in data
            //append in last
            //prepend in first
            var stocksAppended = _context.MockData
                .Where(m => m.id > 10 && m.first_name.StartsWith("A"))
                .ToList()
                .Append(new MockData { id = 234 , first_name="Fatma Ashraf"});

            foreach (var st in stocksAppended)
                Console.WriteLine($"id:{st.id} name {st.first_name}");

            #endregion

            #region |Average vs count vs sum| |Min vs Max|
            //average(creitera on int only) using where before it to fiter data 
            //count(filteration criteria) pust citeria on it easy
            //LongCount() int 64
            //sum(); sum of rows used only on int column, where before it for filteraion


            //max(); , Min(); using in int and string columns 
            #endregion

            #region |Data Sorting by order by|
            var stocksOrderedAsc = _context.MockData.OrderBy(m => m.first_name).ToList();
            var stocksOrderedDes = _context.MockData.OrderByDescending(m => m.first_name).ToList();
            var stocksOrderedAscThenBy = _context.MockData
                .OrderBy(m => m.first_name) // ordering names as group
                .ThenBy(m => m.gender) // sorting gender in nestingGroupname  thenByDescinding
                .ToList();
            foreach (var ascStock in stocksOrderedAsc)
                Console.WriteLine($"id: {ascStock.id} name: {ascStock.first_name}");
            #endregion

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