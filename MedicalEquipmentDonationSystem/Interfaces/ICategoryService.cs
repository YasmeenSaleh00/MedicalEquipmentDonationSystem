using MedicalEquipmentDonationSystem.DTOs.Category.Request;
using MedicalEquipmentDonationSystem.DTOs.Category.Response;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(CreateCategoryDTO input);
        Task UpdateCategory(UpdateCategoryDTO input);
        Task<List<CategoryDTO>> GetAllCategory();
    }
}
