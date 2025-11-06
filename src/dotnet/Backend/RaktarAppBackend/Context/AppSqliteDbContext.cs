using Microsoft.EntityFrameworkCore;
using RaktarAppShared.Models;
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


       public DbSet<Warehouse> Warehouses { get; set; }
       public DbSet<WarehouseItem> WarehouseItems { get; set; }
    }
}
