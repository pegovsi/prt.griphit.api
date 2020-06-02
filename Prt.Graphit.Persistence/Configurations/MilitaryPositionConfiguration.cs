using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.MilitaryPosition.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class MilitaryPositionConfiguration : IEntityTypeConfiguration<MilitaryPosition>
    {
        public void Configure(EntityTypeBuilder<MilitaryPosition> builder)
        {
            builder.ToTable(nameof(MilitaryPosition));

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder
                .Property(e => e.ShortName)
               .IsRequired()
               .HasMaxLength(16)
               .HasColumnType("varchar(16)");

            builder
                .Property<int>("_activeStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ActiveStatusId")
                .IsRequired();

            builder
                .HasOne(o => o.ActiveStatus)
                .WithMany()
                .HasForeignKey("_activeStatusId");

            builder
                .Property<int>("_typeStateServiceStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("TypeStateServiceStatusId")
                .IsRequired();

            builder
                .HasOne(o => o.TypeStateServiceStatus)
                .WithMany()
                .HasForeignKey("_typeStateServiceStatusId");

            builder.HasIndex(e => e.Name);
        }
    }
}
