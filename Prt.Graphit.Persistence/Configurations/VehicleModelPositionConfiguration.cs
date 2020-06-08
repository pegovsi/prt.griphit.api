using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class VehicleModelPositionConfiguration : IEntityTypeConfiguration<VehicleModelPosition>
    {
        public void Configure(EntityTypeBuilder<VehicleModelPosition> builder)
        {
            builder.ToTable(nameof(VehicleModelPosition));

            builder.HasKey(e => e.Id);
        }
    }
}
