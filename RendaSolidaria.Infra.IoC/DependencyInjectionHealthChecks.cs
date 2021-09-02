using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RendaSolidaria.Infra.IoC
{
    public static class DependencyInjectionHealthChecks
    {
        public static IServiceCollection AddInfrastructureHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("PostgresConnStrD"),
                    name: "postgresdb",
                    tags: new string[] { "db", "data" }
                )
                .AddApplicationInsightsPublisher();

            services.AddHealthChecksUI()
                .AddInMemoryStorage();

            return services;
        }
    }
}
