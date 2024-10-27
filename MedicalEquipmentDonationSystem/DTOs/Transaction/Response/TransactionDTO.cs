namespace MedicalEquipmentDonationSystem.DTOs.Transaction.Response
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string DeliveryInfo { get; set; }
        public string DeliveryDate { get; set; }
        public string CreationDate { get; set; }    
        public bool isDeleted { get; set; } 
    }
}
