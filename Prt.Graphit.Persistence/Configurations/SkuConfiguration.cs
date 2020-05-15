using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Sku.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Persistence.Configurations
{
    public class SkuConfiguration : IEntityTypeConfiguration<Sku>
    {
        public void Configure(EntityTypeBuilder<Sku> builder)
        {
            builder.ToTable(nameof(Sku));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            var navigationResponseVariants =
             builder.Metadata.FindNavigation(nameof(Sku.Units));
            navigationResponseVariants.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasIndex(e => e.Name);
        }
    }
}
