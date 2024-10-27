namespace MedicalEquipmentDonationSystem.DTOs.Lookups.Response
{
    public class LookupTypeDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
