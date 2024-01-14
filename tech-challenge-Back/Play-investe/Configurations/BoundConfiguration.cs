using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Play_investe.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Play_investe.Configurations
{
    [ExcludeFromCodeCoverage]
    public class BoundConfiguration : IEntityTypeConfiguration<Bound>
    {
        public void Configure(EntityTypeBuilder<Bound> builder)
        {
            builder.ToTable("Bound");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.LiquidityType).IsRequired();
            builder.Property(b => b.AvailableForWithdrawal).HasColumnType("BIT").IsRequired();
            builder.Property(b => b.Type).HasColumnType("VARCHAR(50)").IsRequired();           
            builder.Property(b => b.Index).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(b => b.Percent).HasColumnType("FLOAT").IsRequired();


            builder.HasMany(b => b.Investments)
                .WithOne(i => i.Bound)
                .HasForeignKey(i => i.IdBound)
                .IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.DesactivedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnType("DATETIME").IsRequired();
        }
    }
}