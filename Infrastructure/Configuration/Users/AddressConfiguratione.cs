using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Users
{
    public class AddressConfiguratione : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.PostalCode ).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.City ).IsRequired().HasMaxLength(250);
            builder.Property(p=>p.State ).IsRequired().HasMaxLength(250);
            

        }
    }
}
