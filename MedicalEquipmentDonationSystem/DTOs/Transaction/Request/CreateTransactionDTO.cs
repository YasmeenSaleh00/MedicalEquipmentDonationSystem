namespace MedicalEquipmentDonationSystem.DTOs.Transaction.Request
{
    public class CreateTransactionDTO
    {
        public int OrderId { get; set; }
        public string DeliveryInfo { get; set; }
        public DateOnly DeliveryDate { get; set; }
    }
}
