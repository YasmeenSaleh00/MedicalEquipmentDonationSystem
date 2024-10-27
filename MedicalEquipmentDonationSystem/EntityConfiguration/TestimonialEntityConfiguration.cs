using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class TestimonialEntityConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.Property(x=>x.DescriptionAr ).IsUnicode(true);

            builder.HasIndex(x => x.UserId).IsUnique(true);//Ensure to add one testimonial by one user
            builder.HasOne<Users>()
              .WithOne()
              .HasForeignKey<Testimonial>(x => x.UserId);
        }
    }
}
