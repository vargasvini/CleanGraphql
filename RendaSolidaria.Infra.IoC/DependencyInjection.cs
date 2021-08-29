using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RendaSolidaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using RendaSolidaria.Infra.Data.Repository;
using RendaSolidaria.Infra.Data;

namespace RendaSolidaria.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPooledDbContextFactory<MainContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("PostgresConnStrD"))
            );
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}