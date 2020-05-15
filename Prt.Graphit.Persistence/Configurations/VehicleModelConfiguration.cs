using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable(nameof(VehicleModel));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.IconLink)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.ShortName)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.HasIndex(e => e.Name);
        }
    }
}
