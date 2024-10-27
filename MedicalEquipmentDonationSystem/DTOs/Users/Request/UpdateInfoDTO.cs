namespace MedicalEquipmentDonationSystem.DTOs.Users.Request
{
    public class UpdateInfoDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? NationalityId { get; set; }
        public string? Adress { get; set; }
      
    }
}
