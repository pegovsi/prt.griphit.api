using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Crew.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class CrewConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable(nameof(Crew));

            builder.HasKey(e => e.Id);

            builder.Property(x => x.OrderNumber)
                .HasMaxLength(16);

            builder
                .HasMany(e => e.CrewPositions)
                .WithOne();

            var navigation = builder
                .Metadata
                .FindNavigation(nameof(Crew.CrewPositions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);


        }
    }
}
