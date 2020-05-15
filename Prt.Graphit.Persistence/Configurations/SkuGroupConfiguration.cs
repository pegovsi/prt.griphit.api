using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Sku.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Persistence.Configurations
{
    public class SkuGroupConfiguration : IEntityTypeConfiguration<SkuGroup>
    {
        public void Configure(EntityTypeBuilder<SkuGroup> builder)
        {
            builder.ToTable(nameof(SkuGroup));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");
           
            builder.HasIndex(e => e.Name);
        }
    }
}
