using Microsoft.Identity.Client;

namespace MedicalEquipmentDonationSystem.DTOs.Users.Request
{
    public class UpdatePasswordDTO
    {
        public int Id { get; set; }
        public string NewPassword { get; set; }
        


    }
}
