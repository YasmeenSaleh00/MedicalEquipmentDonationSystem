namespace MedicalEquipmentDonationSystem.DTOs.Product.Response
{
    public class ProductDTO
    {
        public int UserId { get; set; }
        public string NameOfProudct { get; set; }
        public string Category {  get; set; }
        public string CategoryAr { get; set; }
        public string NameOfProudctAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int StatusProductId { get; set; }
        public int BrandId { get; set; }

    }
}
