using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RaktarAppBackend.Context;

namespace RaktarAppBackend.Extensions
{
    public static class BackendExtension
    {

        private static readonly string[] DefaultCorsOrigins =
        {
            "https://localhost:7020",
            "http://localhost:5020",
            "http://localhost:5173"
        };
        public static readonly string CorsPolicyName = "RaktarAppCors";

        private static void ConfigureCors(CorsOptions options)
        {
            string[] origins = DefaultCorsOrigins
               .Select(o => o.Trim().TrimEnd('/'))
               .Distinct()
               .ToArray();


            options.AddPolicy(CorsPolicyName, policy =>
                policy.WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod());
        }

        private static void ConfigureSqliteDb(IServiceCollection services)
        {
            // A fájl neve és elérési útja szabadon módosítható.
            var dbPath = Path.Combine(Environment.CurrentDirectory, "MyApp.db");
            services.AddDbContext<AppSqliteDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));
        }
       

        public static IServiceCollection AddBackend(this IServiceCollection services)
        {

            services.AddCors(options => ConfigureCors(options));
            ConfigureSqliteDb(services);
            return services;
        }
    }
}
