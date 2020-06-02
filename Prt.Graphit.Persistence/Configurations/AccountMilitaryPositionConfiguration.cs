using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prt.Graphit.Domain.AggregatesModel.Account.Entities;

namespace Prt.Graphit.Persistence.Configurations
{
    public class AccountMilitaryPositionConfiguration : IEntityTypeConfiguration<AccountMilitaryPosition>
    {
        public void Configure(EntityTypeBuilder<AccountMilitaryPosition> builder)
        {
            builder.ToTable(nameof(AccountMilitaryPosition));

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.MilitaryPositionId, e.AccountId });
        }
    }
}
