using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class UserMasterDataFieldConfiguration : IEntityTypeConfiguration<UserMasterDataField>
    {
        public void Configure(EntityTypeBuilder<UserMasterDataField> builder)
        {
            builder.ToTable("UserMasterDataField");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.NameField)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.HasIndex(x => x.TypeUserMasterDataId);
        }
    }
}
