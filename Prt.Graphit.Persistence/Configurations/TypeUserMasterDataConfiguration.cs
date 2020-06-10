using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class TypeUserMasterDataConfiguration : IEntityTypeConfiguration<TypeUserMasterData>
    {
        public void Configure(EntityTypeBuilder<TypeUserMasterData> builder)
        {
            builder.ToTable("TypeUserMasterData");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.TypeData)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.Description)
               .IsRequired(false)
               .HasMaxLength(255)
               .HasColumnType("varchar(255)");
        }
    }
}
