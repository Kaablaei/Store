using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Products.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Products.Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Products");
            builder.Property(p => p.SKU).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Picter).IsRequired().HasMaxLength(255);


            builder.HasOne(p => p.Category).WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
