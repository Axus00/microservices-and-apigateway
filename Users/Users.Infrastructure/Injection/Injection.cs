using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Infrastructure.Database;

namespace Users.Infrastructure.Injection;
public static class Injection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("La cadena de conexión no puede estar vacía", nameof(configuration));

            options.UseNpgsql(connectionString);
        });

        return services;
    }
}
