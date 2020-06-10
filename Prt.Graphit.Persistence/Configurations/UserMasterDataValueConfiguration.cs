using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Persistence.Configurations
{
    public class UserMasterDataValueConfiguration : IEntityTypeConfiguration<UserMasterDataValue>
    {
        public void Configure(EntityTypeBuilder<UserMasterDataValue> builder)
        {
            builder.ToTable("UserMasterDataValue");

            builder.HasKey(e => e.Id);

            builder.Property<string>("_content")
                .UsePropertyAccessMode(PropertyAccessMode.Field)                
                .HasColumnName("Content")
                .HasColumnType("jsonb");

            //var navigation = builder
            //      .Metadata
            //      .FindNavigation(nameof(UserMasterDataValue.Content));
            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasIndex(x => x.UserMasterDataId);
            builder.HasIndex(x => x.UserMasterDataFieldId);
            builder.HasIndex(x => x.VehicleId);
        }
    }
}
