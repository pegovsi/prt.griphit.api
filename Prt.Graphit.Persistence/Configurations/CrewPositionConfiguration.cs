using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Crew.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class CrewPositionConfiguration : IEntityTypeConfiguration<CrewPosition>
    {
        public void Configure(EntityTypeBuilder<CrewPosition> builder)
        {
            builder.ToTable(nameof(CrewPosition));
            
            builder.HasKey(e => e.Id);
        }
    }
}
