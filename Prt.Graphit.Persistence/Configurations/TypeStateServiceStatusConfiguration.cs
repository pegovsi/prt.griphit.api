using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.Enumerations;

namespace Prt.Graphit.Persistence.Configurations
{
    public class TypeStateServiceStatusConfiguration : IEntityTypeConfiguration<TypeStateServiceStatus>
    {
        public void Configure(EntityTypeBuilder<TypeStateServiceStatus> builder)
        {
            builder
                .ToTable(nameof(TypeStateServiceStatus));

            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
