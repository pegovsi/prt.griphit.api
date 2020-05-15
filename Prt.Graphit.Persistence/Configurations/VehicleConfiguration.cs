using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.ShotsAmount)
               .HasMaxLength(255)
               .HasColumnType("varchar(255)");

            builder.Property(e => e.VehicleNomberFactory)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.VehicleNomberRegister)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.VehicleNomberChassis)
               .HasMaxLength(255)
               .HasColumnType("varchar(255)");

            builder.Property(e => e.Responsible)
               .HasMaxLength(255)
               .HasColumnType("varchar(255)");

            builder.HasIndex(e => e.Name);
        }
    }
}
