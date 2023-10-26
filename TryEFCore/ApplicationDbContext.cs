

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
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCore;Integrated Security=True"
                , o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////add entity to model (3)
            //modelBuilder.Entity<AuditEntry>();
            ////new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
            ////for not mapped posts
            ////modelBuilder.Ignore<Post>();

            ////to name the table
            ////modelBuilder.Entity<Post>().ToTable("Posts");

            ////to add schema 
            ////modelBuilder.Entity<Post>().ToTable("Posts", schema: "blogging");

            ////to add schema for any entity
            //modelBuilder.HasDefaultSchema("blogging");

            ////mapping on view
            //modelBuilder.Entity<Post>().ToView("selectedPosts", schema: "blogging");

            ////not mapping on property
            //modelBuilder.Entity<Post>().Ignore(b => b.Content);

            ////name column in database
            //modelBuilder.Entity<Blog>()
            //            .Property(b => b.Url)
            //            .HasColumnName("BlogUrl");

            ////change typedata of property
            ///* modelBuilder.Entity<Blog>(e =>
            //{
            //    e.Property(e => e.Url).HasColumnType("varchar(200)");
            //    e.Property(e => e.Rating).HasColumnType("decimal(5,2)");

            //}); */

            ////adding maxlength
            //modelBuilder.Entity<Post>()
            //           .Property(b => b.Title)
            //           .HasMaxLength(200);

            ////adding comment to column
            //modelBuilder.Entity<Post>()
            //          .Property(b => b.Title)
            //          .HasComment("Hello from Fluent API ");

            ////add composite key to not repeat data in name or in authr
            //modelBuilder.Entity<Book>()
            //            .HasKey(b => new { b.Name, b.Author });


            ////add primary key for book table
            //modelBuilder.Entity<Book>()
            //            .HasKey(b => b.BookKey)
            //            .HasName("PK_bookKey");

            ////add default value
            //modelBuilder.Entity<Blog>()
            //            .Property(b => b.Rating)
            //            .HasDefaultValue(2);

            ////add default value sql
            //modelBuilder.Entity<Blog>()
            //            .Property(b => b.Date)
            //            .HasDefaultValueSql("GETDATE()");

            ////add computed column 
            //modelBuilder.Entity<Employee>()
            //            .Property(b => b.DisplayName)
            //            .HasComputedColumnSql("[LastName] + ',' + [FirstName]");

            ////exclude table after creating, dont listen on it again
            ////modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations());

            ////to add identity values (1,1)
            ////must delete column of id if it created 
            ////modelBuilder.Entity<Department>()
            ////            .Property(b => b.Id)
            ////            .ValueGeneratedOnAdd();

            ////relation one to one
            //modelBuilder.Entity<Blog>()
            //           .HasOne(b => b.BlogImage)
            //           .WithOne(l => l.Blog)
            //           .HasForeignKey<BlogImage>(i => i.BlogForeginKey);

            ////relation one to many 
            //modelBuilder.Entity<Blog>()
            //            .HasMany(b => b.Posts)
            //            .WithOne();

            ////reation many to one
            //modelBuilder.Entity<Post>()
            //    .HasOne(p => p.Blog)
            //    .WithMany(b => b.Posts);

            ////add navigation if dont write it --
            ////deleted navigation property blog/lists<post> posts
            //modelBuilder.Entity<Post>()
            //    .HasOne<Blog>()
            //    .WithMany()
            //    .HasForeignKey(p => p.BlogId);
            ////.HasConstraintName("FK_Posts_Blog"); //if you wana name the name of constrain (not recommended)

            ////if wanna change the foregn key not id ==> uniqueConstraint
            //modelBuilder.Entity<Post>()
            //   .HasOne(p => p.Blog)
            //   .WithMany(b => b.Posts)
            //   .HasForeignKey(p => p.BlogUrl)
            //   .HasPrincipalKey(b => b.Url);

            ////or composite principles keys
            //modelBuilder.Entity<Post>()
            //  .HasOne(p => p.Blog)
            //  .WithMany(b => b.Posts)
            //  .HasForeignKey(p => new { p.BlogUrl, p.Blogcomment })
            //  .HasPrincipalKey(b => new { b.Url, b.comment });

            ////Many to Many Relations
            ////generating New table with many to many - not have PostTags Class
            //modelBuilder.Entity<Post>()
            //            .HasMany(p => p.Tags)
            //            .WithMany(t => t.Posts)
            //            .UsingEntity(j => j.ToTable("PostTags")); // adding new table with postid and tagid
            //                                                      // (if dont created class)

            ////After Adding manyToManyClass - have PostTags Class
            //modelBuilder.Entity<Post>()
            //           .HasMany(p => p.Tags)
            //           .WithMany(t => t.Posts)
            //           .UsingEntity<PostTags>(
            //                      j => j
            //                      .HasOne(pt => pt.Tag)
            //                      .WithMany(t => t.PostTags)
            //                      .HasForeignKey(pt => pt.TagId),
            //                      j => j
            //                      .HasOne(pt => pt.Post)
            //                      .WithMany(t => t.PostTags)
            //                      .HasForeignKey(pt => pt.PostId),
            //                      j => j
            //                      .HasKey(t => new { t.PostId, t.TagId })
            //                      );

            ////Indirect Many To Many Relationship
            //modelBuilder.Entity<PostTags>()
            //          .HasKey(t => new { t.PostId, t.TagId });

            //modelBuilder.Entity<PostTags>()
            //                      .HasOne(pt => pt.Tag)
            //                      .WithMany(t => t.PostTags)
            //                      .HasForeignKey(pt => pt.TagId);

            //modelBuilder.Entity<PostTags>()
            //                    .HasOne(pt => pt.Post)
            //                    .WithMany(t => t.PostTags)
            //                    .HasForeignKey(pt => pt.PostId);

            ////adding index -- interview Question -- bookIndex
            //modelBuilder.Entity<Blog>()
            //    .HasIndex(b => b.Url)
            //    .IsUnique()
            //    .HasDatabaseName("Index_Url") // naming index 
            //    .HasFilter("[Ur] is not null "); // "null"  filteriation for allow null or not

            ////adding composite index -- interview Question -- bookIndex
            //modelBuilder.Entity<Blog>()
            //    .HasIndex(b => new { b.Url, b.BlogId });

            ////adding sequence shared on all classes, inserted automatically
            //modelBuilder.HasSequence<int>("ActionNumber", schema:"shared" )
            //            .StartsAt(1000)
            //            .IncrementsBy(5);

            //modelBuilder.Entity<AuditEntry>()
            //    .Property(b => b.Action)
            //    .HasDefaultValueSql("NEXT VALUE FOR shared.ActionNumber ");

            ////data seeding in modelbuider//to insert data in table // must write ID
            //modelBuilder.Entity<Blog>()
            //    .HasData(new Blog { BlogId=1, Rating ="2"},
            //             new Blog { BlogId=2, Rating ="4"});

            //scaffold-dbcontext 'connection string' microsoft.entityframeworkcore.sqlserver -tables blogs (if you just wanna this table only)
            //scaffold-dbcontext 'connection string' microsoft.entityframeworkcore.sqlserver -OutputDir Models (if you wanna put them in models folder)
            //scaffold-dbcontext 'connection string' microsoft.entityframeworkcore.sqlserver -OutputDir Models -contextDir Data(if you wanna put them in models folder/data folder)
            //-contect nameDataClass
            //-DataAnnotation (if you )

            modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations());
            modelBuilder.Entity<Post>().ToTable("Posts", b => b.ExcludeFromMigrations());
            modelBuilder.Entity<MockData>().ToTable("MockData", b => b.ExcludeFromMigrations());

        }
        //add entity to model (3)
        public DbSet<Employee> Employees { get; set; }
        ////add entity to model navigate on post list and make table (2)
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<MockData> MockData { get; set; }






    }
}
