using AutoMapper;
using Prt.Graphit.Application.Brigade.Queries.Models;
using Prt.Graphit.Application.Chassis.Queries.Models;
using Prt.Graphit.Application.City.Queries.Models;
using Prt.Graphit.Application.Condition.Queries.Models;
using Prt.Graphit.Application.Division.Queries.Models;
using Prt.Graphit.Application.Garrison.Queries.Models;
using Prt.Graphit.Application.Manufacturer.Queries.Models;
using Prt.Graphit.Application.Sku.Models;
using Prt.Graphit.Application.Subdivision.Queries.Models;
using Prt.Graphit.Application.Users.Queries.Models;
using Prt.Graphit.Application.Vehicle.Queries.Models;
using Prt.Graphit.Application.VehicleModel.Queries.Models;
using Prt.Graphit.Application.VehicleType.Queries.Models;

namespace Prt.Graphit.Application.Common.MapperProfiles
{
    public class MiscProfile : Profile
    {
        public MiscProfile()
        {
            CreateMap<Domain.AggregatesModel.Account.Entities.Account, UserDto>();
            
            CreateMap<Domain.AggregatesModel.Sku.Entities.Sku, SkuDto>();
            CreateMap<Domain.AggregatesModel.Sku.Entities.SkuGroup, SkuGroupDto>();
            CreateMap<Domain.AggregatesModel.Sku.Entities.SkuType, SkuTypeDto>();
            CreateMap<Domain.AggregatesModel.Sku.Entities.Unit, UnitDto>();

            CreateMap<Domain.AggregatesModel.Vehicle.Entities.VehicleType, VehicleTypeDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.Vehicle, VehicleDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.Chassis, ChassisDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.VehicleModel, VehicleModelDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.Manufacturer, ManufacturerDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.Garrison, GarrisonDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.City, CityDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.Division, DivisionDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.Subdivision, SubdivisionDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.Brigade, BrigadeDto>();
            CreateMap<Domain.AggregatesModel.Vehicle.Entities.Condition, ConditionDto>();
        }
    }
}