using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");

           

            builder.Property(x => x.NameOfProudctAr).IsUnicode(true);
            builder.Property(x => x.DescriptionAr).IsUnicode(true);
            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);







        }
    }
}
