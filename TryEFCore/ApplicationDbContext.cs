

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
            //modelBuilder.Ignore<Post>();

            //to name the table
            //modelBuilder.Entity<Post>().ToTable("Posts");

            //to add schema 
            //modelBuilder.Entity<Post>().ToTable("Posts", schema: "blogging");

            //to add schema for any entity
            modelBuilder.HasDefaultSchema("blogging");

            //mapping on view
            modelBuilder.Entity<Post>().ToView("selectedPosts", schema: "blogging");

            //not mapping on property
            modelBuilder.Entity<Post>().Ignore(b => b.Content);

            //name column in database
            modelBuilder.Entity<Blog>()
                        .Property(b => b.Url)
                        .HasColumnName("BlogUrl");

            //change typedata of property
            modelBuilder.Entity<Blog>(e =>
            {
                e.Property(e => e.Url).HasColumnType("varchar(200)");
                e.Property(e => e.Rating).HasColumnType("decimal(5,2)");

            });

            //adding maxlength
            modelBuilder.Entity<Post>()
                       .Property(b => b.Title)
                       .HasMaxLength("200");

            //exclude table after creating, dont listen on it again
            //modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations());

        }
        //add entity to model (3)
        public DbSet<Employee> Employees { get; set; }
        //add entity to model navigate on post list and make table (2)
        public DbSet<Blog> Blogs { get; set; }

    }
}
