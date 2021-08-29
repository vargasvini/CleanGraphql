using Microsoft.EntityFrameworkCore;
using RendaSolidaria.Core.Domain.Schemas;

namespace RendaSolidaria.Infra.Data.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
        }

        public DbSet<User> Users { get; set; }
    }
}
