using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Domain.AggregatesModel.Sku.Entities;

namespace Prt.Graphit.Persistence
{
    public class SkuDbContext : DbContext, ISkuDbContext
    {
        public SkuDbContext(DbContextOptions<SkuDbContext> options)
            : base(options)
        {
        }


        public DbSet<Sku> Skus { get; set; }
        public DbSet<SkuGroup> SkuGroups { get; set; }
        public DbSet<SkuType> SkuTypes { get; set; }
        public DbSet<Unit> Units { get; set; }

        public DbContext SkuContext => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkuDbContext).Assembly);
        }
    }
}
