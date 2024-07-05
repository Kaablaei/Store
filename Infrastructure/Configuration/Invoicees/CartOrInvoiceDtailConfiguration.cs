
using Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Invoicees
{
    public class CartOrInvoiceDtailConfiguration : IEntityTypeConfiguration<CartOrInvoiceDtail>
    {
        public void Configure(EntityTypeBuilder<CartOrInvoiceDtail> builder)
        {
          builder.HasKey(x=>x.Id);

            builder.Property(p => p.Price);
            builder.Property(p => p.SalePrice);

            builder.HasOne(p => p.User).WithMany()
                .HasForeignKey(p => p.UserId).
                OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(p => p.variation).WithMany()
                .HasForeignKey(p => p.VaridationId).
                OnDelete(DeleteBehavior.NoAction);



        }
    }
}
