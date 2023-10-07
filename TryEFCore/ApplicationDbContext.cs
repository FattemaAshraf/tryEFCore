

namespace TryEFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCore;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add entity to model (3)
            modelBuilder.Entity<AuditEntry>();
            //new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
            //for not mapped posts
            modelBuilder.Ignore<Post>();

            //to name the table
            modelBuilder.Entity<Post>().ToTable("Posts");
            //exclude table after creating, dont listen on it again
            //modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations());

        }
        //add entity to model (3)
        public DbSet<Employee> Employees { get; set; }
        //add entity to model navigate on post list and make table (2)
        public DbSet<Blog> Blogs { get; set; }

    }
}
