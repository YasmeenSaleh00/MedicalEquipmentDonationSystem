namespace MedicalEquipmentDonationSystem.DTOs.Category.Request
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
