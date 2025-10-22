using Microsoft.EntityFrameworkCore;

namespace RaktarAppBackend.Context
{
    public class AppSqliteDbContext : DbContext
    {
        public AppSqliteDbContext(DbContextOptions<AppSqliteDbContext> options)
            : base(options)
        {
        }
    }
}
