using MedicalEquipmentDonationSystem.DTOs.Users.Request;
using MedicalEquipmentDonationSystem.DTOs.Users.Response;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface IUserService
    {
        Task SignUp(SignUpDTO sign);
        Task UpdateUserProfile(UpdateInfoDTO input);
        Task<List<ProfileDTO>> GetProfile(int  userId);
        Task<List<ProfileDTO>> GetAllUsersProfile();
        Task ResetPassword(UpdatePasswordDTO input);
        Task ManageActivationUserAccount(int Id, bool IsDeleted);

    }
}
