using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.KVTMO.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class KVTMOConfiguration : IEntityTypeConfiguration<KVTMO>
    {
        public void Configure(EntityTypeBuilder<KVTMO> builder)
        {
            builder.ToTable(nameof(KVTMO));

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder
               .Property(e => e.CodeKVTMO)
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

            builder.HasIndex(e => e.Name);
        }
    }
}
