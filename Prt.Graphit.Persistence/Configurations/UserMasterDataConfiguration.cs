using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class UserMasterDataConfiguration : IEntityTypeConfiguration<UserMasterData>
    {
        public void Configure(EntityTypeBuilder<UserMasterData> builder)
        {
            builder.ToTable("UserMasterData");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            var navigation = builder
                  .Metadata
                  .FindNavigation(nameof(UserMasterData.UserMasterDataFields));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(e => e.UserMasterDataFields)
                .WithOne();

            builder.HasIndex(x => x.VehicleModelId);
        }
    }
}
