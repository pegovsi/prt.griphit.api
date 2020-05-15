using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Sku.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class SkuTypeConfiguration : IEntityTypeConfiguration<SkuType>
    {
        public void Configure(EntityTypeBuilder<SkuType> builder)
        {
            builder.ToTable(nameof(SkuType));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.HasIndex(e => e.Name);
        }
    }
}
