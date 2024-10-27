using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");

            builder.HasIndex(x => x.Name).IsUnique(true);

            builder.Property(x => x.Name).IsUnicode(false);
            builder.Property(x => x.Name).HasMaxLength(60);

            builder.ToTable(x => x.HasCheckConstraint("CH_Name_Length", "Len(Name) >= 3"));
            builder.HasMany<Product>().WithOne().HasForeignKey(x=>x.BrandId).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
