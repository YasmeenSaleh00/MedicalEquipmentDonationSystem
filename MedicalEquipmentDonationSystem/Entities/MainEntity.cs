namespace MedicalEquipmentDonationSystem.Entities
{
    public class MainEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
