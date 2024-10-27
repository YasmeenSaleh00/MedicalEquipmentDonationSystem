using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class OrderEntityConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            


            builder.Property(x => x.Adress).HasMaxLength(100);
           
          
            builder.Property(x => x.Adress).IsUnicode(false);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
           


        }
    }
}
