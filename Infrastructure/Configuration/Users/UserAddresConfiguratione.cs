
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration.Users
{
    public class UserAddresConfiguratione : IEntityTypeConfiguration<UseAddress>
    {
        public void Configure(EntityTypeBuilder<UseAddress> builder)
        {
            builder.ToTable("UserAdresses");
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasKey()
        }
    }
}
