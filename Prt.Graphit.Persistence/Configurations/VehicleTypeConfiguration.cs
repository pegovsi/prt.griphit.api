using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.ToTable(nameof(VehicleType));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.IconLink)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.PictureLink)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.HasIndex(e => e.Name);
        }
    }
}
