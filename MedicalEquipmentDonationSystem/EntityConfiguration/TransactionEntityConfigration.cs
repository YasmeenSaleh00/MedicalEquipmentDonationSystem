using MedicalEquipmentDonationSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Transactions;

namespace MedicalEquipmentDonationSystem.EntityConfiguration
{
    public class TransactionEntityConfigration : IEntityTypeConfiguration<TransactionOrder>
    {
        public void Configure(EntityTypeBuilder<TransactionOrder> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasOne<Order>()
             .WithOne()
             .HasForeignKey<TransactionOrder>(x => x.OrderId);


        }
    }
}
