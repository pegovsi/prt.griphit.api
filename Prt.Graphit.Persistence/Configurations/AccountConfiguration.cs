using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Account.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.Email)
                .IsRequired(false)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.FirstName)
                .IsRequired(false)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.LastName)
                .IsRequired(false)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.MiddleName)
                .IsRequired(false)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            var navigation = builder
                .Metadata
                .FindNavigation(nameof(Account.AccountMilitaryPositions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasIndex(e => e.Login);
            builder.HasIndex(e => e.Email);
        }
    }
}
