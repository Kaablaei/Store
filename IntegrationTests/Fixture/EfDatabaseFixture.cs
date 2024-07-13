using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Fixture
{
    public abstract class EfDatabaseFixture<T> : IDisposable where T : DbContext
    {

        public T BuildDbContext(string dbName)
        {
            try
            {
                var option = new DbContextOptionsBuilder<T>()
                    .UseInMemoryDatabase(dbName)
                    .EnableSensitiveDataLogging()
                    .Options;

                var db = BuildDbContext(option);
                return BuildDbContext(option);
            }
            catch (Exception ex)
            {

                throw ;
            }
        }

        protected abstract T BuildDbContext(DbContextOptions<T> options);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
