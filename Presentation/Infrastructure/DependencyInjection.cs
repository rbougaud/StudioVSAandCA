using Domain.Abstraction;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<WriterContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure")));

        services.AddScoped<IMovieRepository, MovieRepository>();

        return services;
    }
}
