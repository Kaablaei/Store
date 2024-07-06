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
    public class VariationConfiguration : IEntityTypeConfiguration<Variation>
    {
        public void Configure(EntityTypeBuilder<Variation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p=>p.Color).HasMaxLength(255);
            builder.Property(p=>p.Size).HasMaxLength(255);
            builder.Property(p=>p.Price).IsRequired().HasMaxLength(255);
            builder.Property(p=>p.SalePrice).IsRequired().HasMaxLength(255);

            //relation

            
            builder.HasOne(p => p.product)
              .WithMany()
              .HasForeignKey(p => p.ProductId)
              .OnDelete(DeleteBehavior.NoAction);
            
            
            

        }
    }
}
