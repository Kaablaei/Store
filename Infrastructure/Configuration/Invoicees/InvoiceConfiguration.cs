using Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Invoicees
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Statuse).IsRequired().HasMaxLength(255);
            builder.Property(p=>p.TrackingCode).IsRequired().HasMaxLength(255);
            builder.Property(p=>p.TrackingCode).IsRequired().HasMaxLength(255);
            builder.Property(p=>p.TotalPrice).IsRequired().HasMaxLength(255);
            builder.Property(p=>p.Discount).IsRequired().HasMaxLength(255);
            builder.Property(p=>p.PayableAmount).IsRequired().HasMaxLength(255);

            builder.HasOne(p => p.User).WithMany()
                .HasForeignKey(p => p.UserId).
                OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Address).WithMany()
                .HasForeignKey(p => p.AdressId).
                OnDelete(DeleteBehavior.NoAction);
        }
    }
}
