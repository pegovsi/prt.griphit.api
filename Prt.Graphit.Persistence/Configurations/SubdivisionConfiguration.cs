using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class SubdivisionConfiguration : IEntityTypeConfiguration<Subdivision>
    {
        public void Configure(EntityTypeBuilder<Subdivision> builder)
        {
            builder.ToTable(nameof(Subdivision));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.HasIndex(e => e.Name);
        }
    }
}
