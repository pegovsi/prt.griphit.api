using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.EKPC.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class EKPCConfiguration : IEntityTypeConfiguration<EKPC>
    {
        public void Configure(EntityTypeBuilder<EKPC> builder)
        {
            builder.ToTable(nameof(EKPC));

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder
               .Property(e => e.CodeEKPC)
               .IsRequired()
               .HasMaxLength(4)
               .HasColumnType("varchar(4)");


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
