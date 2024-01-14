using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
 
using Play_investe.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Play_investe.Configurations
{
    [ExcludeFromCodeCoverage]
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionsBank>
    {
        public void Configure(EntityTypeBuilder<Entity.TransactionsBank> builder)
        {
            builder.ToTable("TransactionsBank");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnType("INT").UseIdentityColumn();          

            builder.Property(t => t.Date).HasColumnType("DATETIME").IsRequired();
            builder.Property(t => t.Amount).HasColumnType("FLOAT").IsRequired();
            builder.Property(t => t.Type).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(t => t.SourceAccountId).HasColumnType("INT").IsRequired();
            builder.Property(t => t.DestinationAccountId).HasColumnType("INT").IsRequired();
            builder.Property(t => t.IdAccount).HasColumnType("INT").IsRequired();

        
            builder.HasOne(t => t.Account)
                .WithMany(a => a.TransactionsBank)
                .HasForeignKey(t => t.IdAccount)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(u => u.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.DesactivedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnType("DATETIME").IsRequired();
        }
    }
}