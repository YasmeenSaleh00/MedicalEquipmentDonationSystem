namespace MedicalEquipmentDonationSystem.DTOs.Order.Request
{
    public class CreateOrderDTO
    {
      public int UserId { get; set; }
    public string RequsterName { get; set; }    
    public string phone { get; set; }
     public int  ProductId { get; set; }
    
    public string Adress { get; set; }
    }
}
