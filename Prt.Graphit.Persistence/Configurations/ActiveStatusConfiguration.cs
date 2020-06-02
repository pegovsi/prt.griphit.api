using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.Enumerations;

namespace Prt.Graphit.Persistence.Configurations
{
    public class ActiveStatusConfiguration : IEntityTypeConfiguration<ActiveStatus>
    {
        public void Configure(EntityTypeBuilder<ActiveStatus> builder)
        {
            builder
                .ToTable(nameof(ActiveStatus));

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
