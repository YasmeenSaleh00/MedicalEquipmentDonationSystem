using MedicalEquipmentDonationSystem.DTOs.Authantication.Request;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface IAuthanticationService
    {

        Task<string> LogIn(LogInDTO logIn);
    }
}
