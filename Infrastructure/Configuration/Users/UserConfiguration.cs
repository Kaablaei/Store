
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Users.User>
    {     
        public void Configure(EntityTypeBuilder<Domain.Users.User> builder)
        {
            builder.ToTable("");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p=>p.Family).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(60);
            
            


        }
    }
}
