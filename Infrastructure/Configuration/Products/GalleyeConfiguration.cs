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
    public class GalleyeConfiguration : IEntityTypeConfiguration<Gallary>
    {
        public void Configure(EntityTypeBuilder<Gallary> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(p => p.product).WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
