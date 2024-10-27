namespace MedicalEquipmentDonationSystem.Entities
{
    public class Product:MainEntity
    {
      public  string NameOfProudct { get; set; }
      public string NameOfProudctAr { get; set; }
      public string Description {  get; set; }
      public string DescriptionAr { get; set; }
      public string ImagePath { get; set; }
      public string CountryOfOrigin { get; set; }
      public DateOnly ManufactureDate { get; set; }
      public int UserId { get; set; }
      public int CategoryId { get; set; }
      public int StatusProductId { get; set; }
      public int BrandId { get; set; }
       

    }
}
