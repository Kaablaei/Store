using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Fixture
{
    public class DbContextFixture : EfDatabaseFixture<ApplicationDbContext>
    {
        protected override ApplicationDbContext BuildDbContext(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}
