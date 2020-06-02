using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Domain.AggregatesModel.Account.Entities;
using Prt.Graphit.Domain.AggregatesModel.EKPC.Entities;
using Prt.Graphit.Domain.AggregatesModel.KVTMO.Entities;
using Prt.Graphit.Domain.AggregatesModel.LeveManagement.Entities;
using Prt.Graphit.Domain.AggregatesModel.MilitaryFormation.Entities;
using Prt.Graphit.Domain.AggregatesModel.MilitaryPosition.Entities;
using Prt.Graphit.Domain.AggregatesModel.MilitaryRank.Entities;
using Prt.Graphit.Domain.AggregatesModel.Sku.Entities;
using Prt.Graphit.Domain.AggregatesModel.TypesMilitaryOrder.Entities;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;
using Prt.Graphit.Domain.Enumerations;

namespace Prt.Graphit.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

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

        public DbSet<ActiveStatus> ActiveStatus { get; set; }
        public DbSet<TypeStateServiceStatus> TypeStateServiceStatus { get; set; }


        public DbSet<MilitaryRank> MilitaryRanks { get; set; }
        public DbSet<MilitaryPosition> MilitaryPositions { get; set; }
        public DbSet<EKPC> EKPCs { get; set; }
        public DbSet<KVTMO> KVTMOs { get; set; }
        public DbSet<LevelManagement> LevelManagements { get; set; }
        public DbSet<TypesMilitaryOrder> TypesMilitaryOrders { get; set; }
        public DbSet<MilitaryFormation> MilitaryFormations { get; set; }
        public DbSet<AccountMilitaryPosition> AccountMilitaryPositions { get; set; }

        public DbContext DbContext => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
