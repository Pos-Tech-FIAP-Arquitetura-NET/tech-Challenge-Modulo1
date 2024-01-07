using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Play_investe.Entity;

namespace Play_investe.Configurations
{
    public class InvestimentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("Investment");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Value).HasColumnType("DECIMAL(18,2)").IsRequired();
            builder.Property(i => i.Amount).HasColumnType("DECIMAL(18,2)").IsRequired();
            builder.Property(i => i.DueDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(i => i.AquisitionDate).HasColumnType("DATETIME").IsRequired();

             
            builder.HasOne(i => i.Account)
                .WithMany(a => a.Investments)
                .HasForeignKey(i => i.IdAccount);



            builder.HasOne(i => i.Bound)
                .WithMany(b => b.Investments)
                .HasForeignKey(i => i.IdBound)
                .IsRequired();

            builder.Property(u => u.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.DesactivedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnType("DATETIME").IsRequired();
        }
    }
}