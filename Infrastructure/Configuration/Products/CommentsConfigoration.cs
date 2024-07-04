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
    public class CommentsConfigoration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            //relation

            builder.HasOne(p => p.Product)
               .WithMany()
               .HasForeignKey(p => p.ProductId)
               .OnDelete(DeleteBehavior.NoAction);


            builder.Property(p => p.Content).IsRequired().HasMaxLength(255);

            builder.HasKey(p => p.Id);



        }
    }
}
