using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Crew.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class CrewHistoryConfiguration : IEntityTypeConfiguration<CrewHistory>
    {
        public void Configure(EntityTypeBuilder<CrewHistory> builder)
        {
            builder.ToTable(nameof(CrewHistory));

            builder.HasKey(e => e.Id);

            builder
                .Property<string>("_content")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnType("jsonb")
                .HasColumnName("Content")
                .IsRequired();

            //var navigation = builder
            //    .Metadata
            //    .FindNavigation(nameof(CrewHistory.Content));
            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
