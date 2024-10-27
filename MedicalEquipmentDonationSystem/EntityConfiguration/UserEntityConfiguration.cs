using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
           
            builder.Property(x => x.FirstName).IsUnicode(false);
            builder.Property(x => x.LastName).IsUnicode(false);
            builder.Property(x => x.Email).IsUnicode(false);
            builder.Property(x => x.Phone).IsUnicode(false);



            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()"); 

            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.Phone).IsUnique(true);

            builder.HasMany<Product>().WithOne().HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
           
        }
    }
}
