using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Play_investe.Entity;
using Play_investe.Entity;

namespace Play_investe.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(u => u.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.CPF).HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(u => u.DateOfBirth).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.RG).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(u => u.DateOfIssue).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.PhoneNumber).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(u => u.Password).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.Permitions).HasConversion<int>().IsRequired();
            builder.Property(u => u.IsActived).HasColumnType("BIT").IsRequired();
            builder.HasOne(u => u.Account)
           .WithOne(a => a.User)
           .HasForeignKey<Account>(a => a.IdUser);
            builder.HasOne(u => u.Address).WithOne(ad => ad.User).HasForeignKey<Address>(ad => ad.IdUser);
           
            builder.Property(u => u.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.DesactivedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnType("DATETIME").IsRequired();
        }
    }
}
