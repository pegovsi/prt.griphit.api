using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.MilitaryRank.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Persistence.Configurations
{
    public class MilitaryRankConfiguration : IEntityTypeConfiguration<MilitaryRank>
    {
        public void Configure(EntityTypeBuilder<MilitaryRank> builder)
        {
            builder.ToTable(nameof(MilitaryRank));

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

            builder.HasIndex(e => e.Name);
        }
    }
}
