using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class LookupTypeEntityConfiguration : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.ToTable("LookupTypes");
         
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");

            //Allow Arabic 
            builder.Property(x => x.NameAr).IsUnicode(true);

            //Check 
            builder.ToTable(x => x.HasCheckConstraint("CH_NameAr_Length", "Len(Name) >= 3"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Name_Length", "Len(NameAr) >= 3"));

            builder.HasMany<LookupItem>().WithOne().HasForeignKey(x => x.LookupTypeId);
        }
    }
}
