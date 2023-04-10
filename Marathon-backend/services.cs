using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal static class Services
{
    internal static void UserDbContext<UserDbContext>(this IServiceCollection services,
        Action<DbContextOptionsBuilder> optionsAction, MySqlServerVersion mySqlServerVersion)
        where UserDbContext : DbContext
    {
        // Register the DbContext with the specified options and version
        services.AddDbContext<UserDbContext>(options =>
        {
            // Invoke the optionsAction to configure the DbContext options
            optionsAction.Invoke(options);

            // Set the MySQL server version
            options.UseMySql("ConnectionString", mySqlServerVersion);
        });
    }
}
