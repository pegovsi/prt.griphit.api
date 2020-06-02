using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.LeveManagement.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class LevelManagementConfiguration : IEntityTypeConfiguration<LevelManagement>
    {
        public void Configure(EntityTypeBuilder<LevelManagement> builder)
        {
            builder.ToTable(nameof(LevelManagement));

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder
                .Property(e => e.Code)
               .IsRequired()
               .HasMaxLength(160)
               .HasColumnType("varchar(160)");

            builder
                .Property<int>("_activeStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ActiveStatusId")
                .IsRequired();

            builder
                .HasOne(o => o.ActiveStatus)
                .WithMany()
                .HasForeignKey("_activeStatusId");

            builder.HasIndex(e => e.Name);
        }
    }
}
