using Domain.Invoices;
using Domain.Products;

using Domain.Users;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Users
        public DbSet<UseAddress> UserAddress { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        #endregion

        #region Product

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Gallary> Gallary { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Variation> Variation { get; set; }


        #endregion


        #region Invoice

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<CartOrInvoiceDtail> CartOrInvoiceDtails { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(IAssemblyMarker).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);


            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Name = "Ali",
            //    Email = "ali@a.com",
            //    Phone = "09033958337",
            //    Family = " aliii",
            //    CratetdAgent = "ali",
            //    CreatedById = 1,
            //    CreatedIP = "192.168.1.1",
            //    CreateOn = DateTime.UtcNow,
            //    ModifiedById = 1,
            //    ModifiedOn = DateTime.UtcNow,
            //    Version = 1,
            //    ModifyAgent = "mohsen",
            //    ModifyIP = "192.1681.1"

            //});

            // base.OnModelCreating(modelBuilder);
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StoreDb;Trusted_Connection=StoreDB;Integrated Security=true;TrustServerCertificate=True;");

            //mycoection string : "Data Source=.;Initial Catalog=StoreDb;Trusted_Connection=Name;Integrated Security=true;TrustServerCertificate=True;"
        }
    }
}
