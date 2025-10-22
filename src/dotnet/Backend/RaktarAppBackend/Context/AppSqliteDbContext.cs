using Microsoft.EntityFrameworkCore;

namespace RaktarAppBackend.Context
{
    public class AppSqliteDbContext : DbContext
    {
        public AppSqliteDbContext()
            :base(
                 new DbContextOptionsBuilder<AppSqliteDbContext>()
                    .UseSqlite("Data Source=RaktarApp.db")
                    .Options
                 )
        {
            Database.EnsureCreated();
        }

        public AppSqliteDbContext(DbContextOptions<AppSqliteDbContext> options)
            : base(options)
        {
        }
    }
}
