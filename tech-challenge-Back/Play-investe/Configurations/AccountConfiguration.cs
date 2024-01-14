using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Play_investe.Entity;
using Play_investe.Entity;
using System.Reflection.Emit;
using System.Diagnostics.CodeAnalysis;

namespace Play_investe.Configurations
{
    [ExcludeFromCodeCoverage]
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(a => a.Balance).HasColumnType("FLOAT").IsRequired().HasDefaultValue(0);
            builder.Property(a => a.Agency).HasColumnType("VARCHAR(10)").IsRequired().HasDefaultValue("0024");
            builder.Property(a => a.AccountNumber).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(a => a.AccountType).HasColumnType("VARCHAR(50)").IsRequired().HasDefaultValue("Conta Corrente");
            builder.Property(a => a.WithdrawalAvailabilityDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(a => a.IsWithdrawalAvailableForAll).HasColumnType("BIT").IsRequired();
            builder.Property(a => a.WithdrawalAvailableAmount).HasColumnType("FLOAT").IsRequired();
            builder.Property(a => a.TotalInvestimentValue).HasColumnType("FLOAT").IsRequired();

            builder.HasOne(a => a.User)
             .WithOne(u => u.Account)
             .HasForeignKey<Account>(a => a.IdUser);

            builder.HasMany(a => a.Investments).WithOne().HasForeignKey(i => i.IdAccount);
            builder.HasMany(a => a.TransactionsBank).WithOne().HasForeignKey(t => t.IdAccount);

            builder.Property(u => u.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.DesactivedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnType("DATETIME").IsRequired();


        }
    }
}