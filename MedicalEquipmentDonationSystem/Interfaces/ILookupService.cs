using MedicalEquipmentDonationSystem.DTOs.Lookups.Request;
using MedicalEquipmentDonationSystem.DTOs.Lookups.Response;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface ILookupService
    {
        Task<List<LookupTypeDTO>> GetLookupType();
        Task UpdateLookupTypeStatus(int Id, bool IsDeleted);
        Task<List<LookupItemDTO>> GetLookupItemValueByType(int LookupTypeId);
        Task UpdateLookupItem(UpdateLookupItemDTO input);


    }
}
