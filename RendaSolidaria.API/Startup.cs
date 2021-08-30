using Microsoft.AspNetCore.Builder;
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

            services.AddControllers();
            //services.AddControllersWithViews()
            //    .AddNewtonsoftJson(options =>
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);
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
