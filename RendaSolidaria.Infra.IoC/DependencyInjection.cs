using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RendaSolidaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using RendaSolidaria.Infra.Data.Repository;
using RendaSolidaria.Infra.Data;
using RendaSolidaria.Core.Domain;
using RendaSolidaria.Infra.Data.GraphQL;
using RendaSolidaria.Infra.Data.GraphQL.UserExtensions;

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
            services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddTypeExtension<UserQueries>()
            .AddTypeExtension<UserMutations>()
            .AddFiltering()
            .AddSorting();

            return services;
        }
    }
}
