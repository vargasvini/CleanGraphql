using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RendaSolidaria.API.GraphQL;
using RendaSolidaria.API.GraphQL.UserExtensions;
using RendaSolidaria.Infra.IoC;

namespace RendaSolidaria.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureAPI(Configuration);
            services.AddInfrastructureHealthChecks(Configuration);
            services.AddInfrastructureJWT(Configuration);
            services.AddInfrastructureSwagger();

            services.AddGraphQLServer()
            .AddAuthorization()
            .AddErrorFilter<GraphQLErrorFilter>()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddTypeExtension<UserQueries>()
            .AddTypeExtension<UserMutations>()
            .AddFiltering()
            .AddSorting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RendaSolidaria.API v1"));

            app.UseHealthChecks("/healthchecks", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(opt =>
            {
                opt.UIPath = "/healthchecks-ui";
                opt.ApiPath = "/healthchecks-ui-api";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
        }
    }
}
