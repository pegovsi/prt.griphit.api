using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class VehiclePicturesConfiguration : IEntityTypeConfiguration<VehiclePicture>
    {
        public void Configure(EntityTypeBuilder<VehiclePicture> builder)
        {
            builder.ToTable(nameof(VehiclePicture));

            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Uri)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.UriPreview)
                .IsRequired(false)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.HasIndex(e => e.VehicleId);
        }
    }
}
