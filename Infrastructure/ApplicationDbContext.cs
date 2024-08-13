using Domain.Invoices;
using Domain.Products;

using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
  

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Users



        public DbSet<Address> Address { get; set; }
        //public DbSet<UseAddress> UserAddress { get; set; }


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
            base.OnModelCreating(modelBuilder);

           
        }


    }
}
