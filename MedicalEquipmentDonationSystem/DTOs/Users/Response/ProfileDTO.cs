namespace MedicalEquipmentDonationSystem.DTOs.Users.Response
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Phone { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public string Adress { get; set; }
        public int UserTypeId { get; set; }
        public bool isDeleted { get; set; }
    }
}
