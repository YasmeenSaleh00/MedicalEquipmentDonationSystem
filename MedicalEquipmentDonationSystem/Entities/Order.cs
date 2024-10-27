namespace MedicalEquipmentDonationSystem.Entities
{
    public class Order:MainEntity
    {
        public int UserId { get; set; }
        public string RequsterName { get; set; }    
        public string Phone {  get; set; }
        public string Adress { get; set; }
        public int StatusOrderId { get; set; }
        public int ProductId { get; set; }
        

    }
}
