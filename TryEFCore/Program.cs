
using Castle.Components.DictionaryAdapter;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            //Console.WriteLine($"ID: {stock.id} Name : {stock.first_name}");

            //single(); for identity data but make exception if //sequence sql no elements
            //didn't found data so we use SingleOrDefault(); default make null value
            var stockSingle = _context.MockData.SingleOrDefault(m => m.id == 10);
            Console.WriteLine(stockSingle == null ? "not found" : $"ID: {stockSingle.id} Name : {stockSingle.first_name}");

            //first(); //first item //sequence sql no elements
            //FirstOrDefault();  //using default if didn't need exception need null value
            //var stockFirst = _context.MockData.First(m => m.id > 10);
            //Console.WriteLine($"ID: {stockFirst.id} Name : {stockFirst.first_name}");

            //last(); //last item must using orderby //sequence sql no elements
            // exception using lastOrDefault();
            //var stocksOdrdered = _context.MockData.OrderBy(m => m.first_name).Last(m => m.id > 20);
            //Console.WriteLine(stocksOdrdered == null ? "not found" : $"ID: {stocksOdrdered.id} Name : {stocksOdrdered.first_name}");
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

            #region |Select();|
            var selectedStocks = _context.MockData.Select(m=> new {stockId = m.id, stockName = m.first_name}).ToList();
            var selectedStocks1 = _context.MockData.Select(m => new { m.id, m.first_name }).ToList();
            var selectedStocks2 = _context.MockData.Select(m => new Blog { BlogId = m.id, Url = m.first_name }).ToList();

            foreach (var slected in selectedStocks)
                Console.WriteLine($"{slected.stockId} - Name {slected.stockName}");    //selected and changed the name columns     

            //distinct();  
            var selectedStocks3 = _context.MockData.Distinct().ToList(); // all data
            //to prevent the duplicatation >> must with select(); based on selected columns
            var selectedStocks4 = _context.MockData.Select(m => new { m.id, m.first_name })
                                                   .Distinct()
                                                   .ToList(); 
            foreach (var slected4 in selectedStocks4) 
                Console.WriteLine($"{slected4.id} - Name {slected4.first_name}");


            #endregion

            #region |Take or Skip|
            //Pagination
            var skipedStocks = _context.MockData.Skip(10).Take(10).ToList();
            //using in pageNumber and page size
            //make method in IRepository
            //public static List<MockData> GetData(int PaperNumber, int PaperSize)
            //{
            //    var _context = new ApplicationDbContext { };

            //    return _context.MockData
            //           .Skip((PaperNumber - 1) * PaperSize)
            //           .Take(PaperSize)
            //           .ToList();
            //}
            int PaperNumber = 2;
            int PaperSize = 5;
            var paginationStocks = GetData(PaperNumber, PaperSize);
            foreach (var page in paginationStocks)
                Console.WriteLine($"Number Page: {PaperNumber} id: {page.id} name: {page.first_name}");
            #endregion

            #region |Group By|
            //grouping column merging all same value in one
            var groupingStock = _context.MockData.GroupBy(m => m.gender)
                                                 .Select(m => new { Name = m.Key, count = m.Count() });
            //after merging we don't have just key (name) and method to count 
            // if data integer you can use avg(criteria); and sum(criteria); //if you wnna put critera in sum and avg based on some columns

            foreach (var g in groupingStock)
                Console.WriteLine($"Name {g.Name} count {g.count}");
            #endregion

            #region |Join|
            //left join - right join - inner join - full join
            var Books = _context.Books.Join(_context.Authors, //table who join with
                                            book => book.AuthorId, //column 1
                                            author => author.Id,  //column 2 to join //navigation on author table
                                            (book, author) => new  //all data the books variable contain
                                            {
                                                BookId = book.BookKey,
                                                BookName = book.Name,
                                                AuthorName = author.Name
                                            });

            foreach (var Book in Books)
                Console.WriteLine($"Id: {Book.BookId} - Name: {Book.BookName} - Author: {Book.AuthorName}");



            var BooksAuthNation = _context.Books.Join(_context.Authors, //table who join with
                                          book => book.AuthorId, //column 1
                                          author => author.Id,  //column 2 to join //navigation on author table
                                          (book, author) => new  //all data the books variable contain
                                          {
                                              BookId = book.BookKey,
                                              BookName = book.Name,
                                              AuthorName = author.Name,
                                              AuthorNationalityId = author.NationalityId
                                          }).Join(
                                                  _context.Nationalities,
                                                  book => book.AuthorNationalityId,
                                                  nationality => nationality.Id,
                                                  (book, nationality) => new
                                                  {
                                                      book.BookId,
                                                      book.AuthorName,
                                                      book.BookName,
                                                      AuthorNationality = nationality.Country
                                                  }
                                                 );

            foreach (var B in BooksAuthNation)
                Console.WriteLine($"Id: {B.BookId} - Name: {B.BookName} - Author: {B.AuthorName} - Nationality: {B.AuthorNationality}");

            //if you want table with null values in right table ''left join''

            var BooksAuthNationGroupJoin = _context.Books.Join(_context.Authors, //table who join with
                                          book => book.AuthorId, //column 1
                                          author => author.Id,  //column 2 to join //navigation on author table
                                          (book, author) => new  //all data the books variable contain
                                          {
                                              BookId = book.BookKey,
                                              BookName = book.Name,
                                              AuthorName = author.Name,
                                              AuthorNationalityId = author.NationalityId
                                          }).GroupJoin(
                                                  _context.Nationalities,
                                                  book => book.AuthorNationalityId,
                                                  nationality => nationality.Id,
                                                  (book, nationality) => new
                                                  {
                                                      Book= book,
                                                      Nationality = nationality
                                                  }
                                                 )
                                          .SelectMany(
                                                  b => b.Nationality.DefaultIfEmpty(), // if it null - intialize the default value
                                                  (b,n) => new { b.Book , Nationality = n} // b.Book = Book in the first join method
                                                  );

            foreach (var Bo in BooksAuthNationGroupJoin)
                //full join if have null value so you put null saftey ?
                Console.WriteLine($"Id: {Bo.Book.BookId} - Name: {Bo.Book.BookName} - Author: {Bo.Book.AuthorName} - Nationality: {Bo.Nationality?.Country}");

            #endregion
            #region |join using linq|
            var booksLinq = (from b in _context.Books
                             join a in _context.Authors
                             on b.AuthorId equals a.Id  //using System.Linq; to navigate on properties
                             select new {a,b }).ToList();

            var booksLinq1 = (from b in _context.Books
                             join a in _context.Authors
                             on b.AuthorId equals a.Id //using System.Linq; to navigate on properties
                             join n in _context.Nationalities
                             on a.NationalityId equals n.Id into authorNationality
                             from an in authorNationality.DefaultIfEmpty() //to take the null value like groupjoin //leftjoin
                              select new { 
                                              BookId = b.BookKey,
                                              bookName = b.Name,
                                              authorName = a.Name
                             
                                         }).ToList();
            #endregion

            #region |Tracking vs. NoTracking|
            //ef core tracking on you changes on data base - 
            //the price don't change and not save value in database
            //var NoTrackBook = _context.Books.AsNoTracking().SingleOrDefault(b => b.BookKey ==1);
            //NoTrackBook.Price = 110;
            //_context.SaveChanges();

            ////if you wanna change the behaviour of database
            ////_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            ////if you don't put .AsNoTracking();
            //var trackers = _context.ChangeTracker.Entries(); 
            //foreach (var tracker in trackers)
            //{
            //    Console.WriteLine($"{tracker.Entity.ToString()}-{tracker.State}"); //state of modified state in database and entity model 
            //    //if put asnotracking the value no result
            //}
            #endregion

            #region |Eager Loading - include();|
            //to intern in navigation property of object in model
            //*****make loading on application ******
            //based on join in sql provider query 
            var BooksL = _context.Books.SingleOrDefault(b => b.BookKey ==1);
            //Console.WriteLine($"{BooksL.Author.Name}"); //exception

            
            var BooksL1 = _context.Books.Include(b => b.Author)
                                        .ThenInclude(a => a.Nationality) //if wanna navigate on nationality in author table
                                        .SingleOrDefault(b => b.BookKey == 2);
            Console.WriteLine($"{BooksL1.Author.Name}");

            #endregion

            #region |Explicit Loading| 
            var explicitBook = _context.Books.SingleOrDefault(b => b.BookKey ==3);
            _context.Entry(explicitBook).Reference(b => b.Author).Load();

            Console.WriteLine($"used explicit loading :{explicitBook.Author.Name}");

            //if navigation property is collection/list
            var explicitBlog = _context.Blogs.SingleOrDefault(b => b.BlogId == 1);
            _context.Entry(explicitBlog).Collection(b => b.Posts).Load();


            //you can make query 
            var explicitBlogQuery = _context.Blogs.SingleOrDefault(b => b.BlogId == 1);
            _context.Entry(explicitBlogQuery)
                    .Collection(b => b.Posts)
                    .Query()  // adding query() function before condition
                    .Where(p => p.Id < 1)
                    .ToList();

            var explicitBlogQuery1 = _context.Blogs.SingleOrDefault(b => b.BlogId == 1);
            _context.Entry(explicitBlogQuery)
                    .Collection(b => b.Posts)
                    .Query()  // adding query() function before condition
                    .Count();


            foreach (var post in explicitBlogQuery1.Posts)
            {
                Console.WriteLine($"used explicit loading :{post.Title}");

            }


            #endregion

            #region |Lazy Loading|
            //must installing proxies
            var BooksLazy = _context.Books.SingleOrDefault(b => b.BookKey == 2);
            //************  To Lazy Work  ***************
            //step one 
            //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    optionsBuilder.UseLazyLoadingProxies().UseSqlServer("");
            //    base.OnConfiguring(optionsBuilder);
            //}
            //step two
            //step two add virtual before navigate property
            /*Lazy loading means delaying the loading of related data,
             * until you specifically request for it. When using POCO
             * entity types, lazy loading is achieved by creating instances
             * of derived proxy types and then overriding virtual 
             * properties to add the loading hook.*/


            //difference between Eager and Lazy
            //Eager loading all data and related data //inner join based  //will be loaded at single database call.
            //Lazy loading only related data  //where in table of navigation property //It simply delays the loading of the related data, until you ask for it.

            //Virtual proxy – when accessing an object, call a virtual object
            //with same interface as the real object. When the virtual object
            //is called, load the real object, then delegate to it.

            Console.WriteLine($"lazy Loading :{BooksLazy.Author.Name}");

            #endregion

            #region |Split Queries|

            var BooksL2 = _context.Books.Include(b => b.Author)
                                        .AsSplitQuery()
                                       .SingleOrDefault(b => b.BookKey == 2);
            /*to split the query on two querys or more make fast performance*/
            //if you wana behavior of context
            /*  optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCore;Integrated Security=True"
                , o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)); */
            //.AsSingleQuery() if you wana single without change behaviour
            Console.WriteLine($"{BooksL2.Author.Name}");
            #endregion

            #region |SQL Statement or Stored Procedure |
            var cookIdForStoredProcParameter = new SqlParameter("Id",1);
            var bookSql = _context.Books.FromSqlRaw("sql statement/ stored procedure name", cookIdForStoredProcParameter).ToList();

            //data transorm class without visible on database for stored procedure, navigate on two or more tables and have complex statement
            //BookDto class for properties of stored statement ms sql
            //var bookSql1 = _context.BookDto.FromSqlRaw("sql statement/ stored procedure name", cookIdForStoredProcParameter).ToList();
            //on model creating .entity<BookDto>(e => {e.HasNoKey().ToView(null);}); //migration is empaty/null



            #endregion

            #region |Global Query Filters|
            //Global Query Filter
            //modelBuilder.Entity<Blog>().HasQueryFilter(b => b.Posts.Count > 0);

            var blogs = _context.Blogs.ToList();
            foreach (var item in blogs)
                Console.WriteLine($"{item.BlogId}"); //to select the blog of havve posts only

            var blogs1 = _context.Blogs.IgnoreQueryFilters().ToList(); //to ignore query filter
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
        //pagination Method
        public static List<MockData> GetData(int PaperNumber, int PaperSize)
{
var _context = new ApplicationDbContext { };

return _context.MockData
      .Skip((PaperNumber - 1) * PaperSize)
      .Take(PaperSize)
      .ToList();
}
}
}