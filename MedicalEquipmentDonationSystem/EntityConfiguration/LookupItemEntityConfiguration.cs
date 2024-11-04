using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class LookupItemEntityConfiguration : IEntityTypeConfiguration<LookupItem>
    {
        public void Configure(EntityTypeBuilder<LookupItem> builder)
        {
            builder.ToTable("LookupItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");

            builder.Property(x => x.Value).IsUnicode(false);
            builder.Property(x => x.ValueAr).IsUnicode(true);

          
            builder.ToTable(x => x.HasCheckConstraint("CH_ValueAr_Length", "Len(ValueAr) >= 3"));
            //relation with user
            builder.HasMany<Users>().WithOne().HasForeignKey(x => x.NationalityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Users>().WithOne().HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Users>().WithOne().HasForeignKey(x => x.UserTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Product>().WithOne().HasForeignKey(x => x.StatusProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Testimonial>().WithOne().HasForeignKey(x=>x.TestimonialTypeId).OnDelete(DeleteBehavior.NoAction);   
            builder.HasMany<Order>().WithOne().HasForeignKey(x=>x.StatusOrderId).OnDelete(DeleteBehavior.NoAction); 


        }
    }
}
