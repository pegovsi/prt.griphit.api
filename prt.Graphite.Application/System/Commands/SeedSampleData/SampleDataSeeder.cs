﻿using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.System.Commands.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly IAppDbContext _context;

        public SampleDataSeeder(IAppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken token)
        {
            await SeedActiveStatusAsync(token);
            await SeedTypeStateServiceStatusAsync(token);
            await SeedConditionsAsync(token);
            await SeedLevelManagementAsync(token);
            await SeedTypesMilitaryOrderAsync(token);
            await SeedTypeUserMasterData(token);

            await SeedUserMasterDataWithFieldsView(token);
        }

        private async Task SeedTypesMilitaryOrderAsync(CancellationToken token)
        {
            var typesMilitaryOrders = await _context
               .DbContext
               .Set<Domain.AggregatesModel.TypesMilitaryOrder.Entities.TypesMilitaryOrder>()
               .ToListAsync(token);

            if (!typesMilitaryOrders.Any())
            {
                var list = new[] 
                {
                    new Domain.AggregatesModel.TypesMilitaryOrder.Entities.TypesMilitaryOrder
                    (
                        name: "Формирование экипажа"
                    ),
                    new Domain.AggregatesModel.TypesMilitaryOrder.Entities.TypesMilitaryOrder
                    (
                        name: "Расформирование экипажа"
                    ),
                    new Domain.AggregatesModel.TypesMilitaryOrder.Entities.TypesMilitaryOrder
                    (
                        name: "Временное расформирование экипажа"
                    )
                };

                await _context
               .Set<Domain.AggregatesModel.TypesMilitaryOrder.Entities.TypesMilitaryOrder>()
               .AddRangeAsync(list, token);
                await _context.SaveChangesAsync(token);
            }
        }

        private async Task SeedActiveStatusAsync(CancellationToken token)
        {
            var statuses = await _context
               .DbContext
               .Set<Domain.Enumerations.ActiveStatus>()
               .ToListAsync(token);

            if (!statuses.Any())
            {
                statuses = new List<Domain.Enumerations.ActiveStatus>
                {
                    Domain.Enumerations.ActiveStatus.Active,
                    Domain.Enumerations.ActiveStatus.Draft,
                    Domain.Enumerations.ActiveStatus.Inactive
                };

                await _context
                .DbContext
                .Set<Domain.Enumerations.ActiveStatus>()
                .AddRangeAsync(statuses);

                await _context.SaveChangesAsync(token);
            }
        }
        private async Task SeedTypeStateServiceStatusAsync(CancellationToken token)
        {
            var typeStateService = await _context
               .DbContext
               .Set<Domain.Enumerations.TypeStateServiceStatus>()
               .ToListAsync(token);

            if (!typeStateService.Any())
            {
                typeStateService = new List<Domain.Enumerations.TypeStateServiceStatus>
                {
                    Domain.Enumerations.TypeStateServiceStatus.Civil,
                    Domain.Enumerations.TypeStateServiceStatus.Military
                };

                await _context
                .DbContext
                .Set<Domain.Enumerations.TypeStateServiceStatus>()
                .AddRangeAsync(typeStateService);

                await _context.SaveChangesAsync(token);
            }
        }
        private async Task SeedConditionsAsync(CancellationToken token)
        {
            var conditions = await _context
                .DbContext
                .Set<Domain.AggregatesModel.Vehicle.Entities.Condition>()
                .ToListAsync(token);

            if (!conditions.Any())
            {
                conditions = new List<Domain.AggregatesModel.Vehicle.Entities.Condition> 
                {
                    new Domain.AggregatesModel.Vehicle.Entities.Condition("Исправен", null, true),
                    new Domain.AggregatesModel.Vehicle.Entities.Condition("Неисправен", null, false),
                    new Domain.AggregatesModel.Vehicle.Entities.Condition("НеОбслуживался", null, false),
                };

                await _context
                .DbContext
                .Set<Domain.AggregatesModel.Vehicle.Entities.Condition>()
                .AddRangeAsync(conditions);

                await _context.SaveChangesAsync(token);
            }
        }
        private async Task SeedLevelManagementAsync(CancellationToken token)
        {
            var listLevelManagement = new List<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>
            {
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Вооружённые силы",
                    code: "9",
                    isVch: false,
                    independent: true
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Военный округ",
                    code: "8",
                    isVch: false,
                    independent: true
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Армия",
                    code: "7",
                    isVch: false,
                    independent: true
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Дивизия",
                    code: "6",
                    isVch: false,
                    independent: true
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Отдельная дивизия",
                    code: "6",
                    isVch: false,
                    independent: true
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Полк",
                    code: "5",
                    isVch: false,
                    independent: false
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Отдельный полк",
                    code: "5",
                    isVch: false,
                    independent: false
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Бригада",
                    code: "5",
                    isVch: false,
                    independent: true
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Отдельная бригада",
                    code: "5",
                    isVch: true,
                    independent: true
                ),
                new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Батальон",
                    code: "4",
                    isVch: true,
                    independent: false
                ),
                 new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Отдельный батальон",
                    code: "4",
                    isVch: false,
                    independent: false
                ),
                 new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Рота",
                    code: "3",
                    isVch: false,
                    independent: false
                ),
                 new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Взвод",
                    code: "2",
                    isVch: false,
                    independent: false
                ),
                 new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Отделение",
                    code: "1",
                    isVch: false,
                    independent: false
                ),
                 new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Первый уровень",
                    code: "1",
                    isVch: false,
                    independent: false
                ),
                 new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Поисковая группа",
                    code: "1",
                    isVch: false,
                    independent: false
                ),
                 new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
                (
                    name: "Дежурное подразделение",
                    code: "1",
                    isVch: false,
                    independent: false
                )
            };
            var models = await _context
                .Set<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>()
                .ToArrayAsync(token);

            var listNewEntities = new List<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>();
            foreach (var item in listLevelManagement)
            {
                if (models.FirstOrDefault(x => x.Name == item.Name) is null)
                {
                    listNewEntities.Add(item);
                }
            }

            if (listNewEntities.Any())
            {
                await _context.Set<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>()
                    .AddRangeAsync(listNewEntities);

                await _context.SaveChangesAsync(token);
            }
        }
        private async Task SeedTypeUserMasterData(CancellationToken token)
        {
            var types = await _context
              .DbContext
              .Set<Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData>()
              .ToListAsync(token);

            if (!types.Any())
            {
                types = new List<Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData>
                {
                    new Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData("String", "Строка"),
                    new Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData("Int", "Целое число"),
                    new Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData("Decimal", "Дробное число"),
                    new Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData("Date", "Дата"),
                    new Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData("SkuRef", "Ссылка на номенклатуру")
                };

                await _context
                .DbContext
                .Set<Domain.AggregatesModel.UserMasterData.Entities.TypeUserMasterData>()
                .AddRangeAsync(types);

                await _context.SaveChangesAsync(token);
            }
        }
        
        private async Task SeedUserMasterDataWithFieldsView(CancellationToken token)
        {
            var script = $@"CREATE VIEW {UserMasterDataFieldView.View} AS select 
                            usmd.'Id' as 'Id',
                            usmd.'Name' as 'Name',
                            usmd.'VehicleModelId' as 'VehicleModelId',
                            usmdf.'NameField' as 'NameField',
                            tusmd.'Id' as 'TypeDataId',
                            tusmd.'TypeData' as 'TypeData',
                            tusmd.'Description' as 'Description'
                            from public.'UserMasterData' as usmd
                            left join public.'UserMasterDataField' as usmdf ON usmdf.'UserMasterDataId' = usmd.'Id'
                            left join public.'TypeUserMasterData' as tusmd on tusmd.'Id' = usmdf.'TypeUserMasterDataId'"
                            .Replace("'", "\"");
            await ExecuteSqlCommands(UserMasterDataFieldView.View, script, token);
        }
        private async Task ExecuteSqlCommands(string viewName, string scriptCreateForNewView, CancellationToken token)
        {
            var script = $"SELECT * FROM INFORMATION_SCHEMA.views WHERE table_name='{viewName}'";

            bool hasView;

            
            using (var command = _context.DbConnection.CreateCommand())
            {
                command.CommandText = script;
                await _context.DbConnection.OpenAsync(token);
                using (var result = command.ExecuteReader())
                    hasView = result.HasRows;
                if (!hasView)
                    await _context.ExecuteSqlRawAsync(scriptCreateForNewView, token);
            }
        }
    }
}
