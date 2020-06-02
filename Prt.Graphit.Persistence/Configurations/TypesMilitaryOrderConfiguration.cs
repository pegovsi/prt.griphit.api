using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.TypesMilitaryOrder.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class TypesMilitaryOrderConfiguration : IEntityTypeConfiguration<TypesMilitaryOrder>
    {
        public void Configure(EntityTypeBuilder<TypesMilitaryOrder> builder)
        {
            builder.ToTable(nameof(TypesMilitaryOrder));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.HasIndex(e => e.Name);
        }
    }
}
