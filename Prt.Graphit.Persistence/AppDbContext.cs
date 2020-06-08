using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Domain.AggregatesModel.Account.Entities;
using Prt.Graphit.Domain.AggregatesModel.Crew.Entities;
using Prt.Graphit.Domain.AggregatesModel.EKPC.Entities;
using Prt.Graphit.Domain.AggregatesModel.KVTMO.Entities;
using Prt.Graphit.Domain.AggregatesModel.LeveManagement.Entities;
using Prt.Graphit.Domain.AggregatesModel.MilitaryFormation.Entities;
using Prt.Graphit.Domain.AggregatesModel.MilitaryPosition.Entities;
using Prt.Graphit.Domain.AggregatesModel.MilitaryRank.Entities;
using Prt.Graphit.Domain.AggregatesModel.Sku.Entities;
using Prt.Graphit.Domain.AggregatesModel.TypesMilitaryOrder.Entities;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;
using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Enumerations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unit = Prt.Graphit.Domain.AggregatesModel.Sku.Entities.Unit;
using Prt.Graphit.Application.Common.Extensions;

namespace Prt.Graphit.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IMediator _mediator;
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options,
            IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
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
        public DbSet<VehiclePicture> VehiclePictures { get; set; }
        public DbSet<VehicleModelPosition> VehicleModelPositions { get; set; }

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
        public DbSet<Crew> Crews { get; set; }
        public DbSet<CrewPosition> CrewPositions { get; set; }
        public DbSet<CrewHistory> CrewHistorys { get; set; }

        public DbContext DbContext => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //var currentUser = _currentUserService.GetCurrentUser();
            var dateTime = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                UpdateState(entry);

                switch (entry.State)
                {
                    case EntityState.Added:
                       // entry.Entity.CreatedBy = currentUser.Id.ToString();
                        entry.Entity.Created = dateTime;
                        break;
                    case EntityState.Modified:
                       // entry.Entity.ModifiedBy = currentUser.Id.ToString();
                        entry.Entity.Modified = dateTime;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            // Не посылаем события во время тестов
            if (Database.IsNpgsql())
            {
                await DispatchDomainEventsAsync();
            }

            return result;
        }

        private static void UpdateState(EntityEntry<Entity> entry)
        {
            if (entry.Entity.IsNew)
            {
                entry.State = EntityState.Added;
            }
        }

        private async Task DispatchDomainEventsAsync()
        {
            var domainEntities = ChangeTracker
               .Entries<Entity>()
               .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
            await _mediator.DispatchDomainEventsAsync(domainEntities);
        }
    }
}
