namespace MedicalEquipmentDonationSystem.DTOs.Product.Request
{
    public class UpdateProductDTO
    {
        public int Id { get; set; } 
        public string? NameOfProudct { get; set; }
        public string? NameOfProudctAr { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public string? ImagePath { get; set; }
    }
}
