namespace MedicalEquipmentDonationSystem.DTOs.Category.Response
{
    public class CategoryDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public string CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string ModificationDate { get; set; }
    }
}
