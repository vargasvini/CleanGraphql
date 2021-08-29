using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RendaSolidaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using RendaSolidaria.Infra.Data.Repository;

namespace RendaSolidaria.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPooledDbContextFactory<MainContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("PostgresConnStrD"),
                x => x.MigrationsAssembly(typeof(MainContext).Assembly.FullName))
            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<MainContext>();

            return services;
        }
    }
}
