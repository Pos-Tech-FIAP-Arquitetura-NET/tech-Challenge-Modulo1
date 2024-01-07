using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Play_investe.Entity;

namespace Play_investe.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(a => a.Number).HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(a => a.ZipCode).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(a => a.City).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(a => a.State).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(a => a.Country).HasColumnType("VARCHAR(50)").IsRequired();


            builder.HasOne(a => a.User)
                .WithOne(u => u.Address)
                .HasForeignKey<Address>(a => a.IdUser);

            builder.Property(u => u.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.DesactivedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnType("DATETIME").IsRequired();
        }
    }
}
