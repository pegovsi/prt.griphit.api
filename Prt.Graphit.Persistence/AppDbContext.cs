using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Domain.AggregatesModel.Sku.Entities;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;

namespace Prt.Graphit.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Sku> Skus { get; set; }
        public DbSet<SkuGroup> SkuGroups { get; set; }
        public DbSet<SkuType> SkuTypes { get; set; }
        public DbSet<Unit> Units { get; set; }


        public DbSet<Brigade> Brigades { get; set; }
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Garrison> Garrisons { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        public DbContext SkuContext => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
