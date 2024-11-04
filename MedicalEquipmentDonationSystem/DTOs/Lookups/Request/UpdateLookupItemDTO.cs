namespace MedicalEquipmentDonationSystem.DTOs.Lookups.Request
{
    public class UpdateLookupItemDTO
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public string? ValueAr { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
