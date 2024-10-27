using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            
            builder.HasKey(x => x.Id);
           
            builder.Property(x => x.Id).UseIdentityColumn();
           
            builder.Property(x => x.NameAr).IsRequired(false);
            
             
            builder.Property(x => x.NameAr).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);
            //Nvarchar Mapluation
            builder.Property(x => x.Name).IsUnicode(false);
        
            //default
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
          
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            //unique 
            builder.HasIndex(x => x.NameAr).IsUnique(true);
            builder.HasIndex(x => x.Name).IsUnique(true);

            builder.HasMany<Product>().WithOne().HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.NoAction);   
         
        }
    }
}
