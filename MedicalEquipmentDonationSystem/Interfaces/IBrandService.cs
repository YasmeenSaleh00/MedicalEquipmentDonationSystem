using MedicalEquipmentDonationSystem.DTOs.Brand;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDTO>> GetAllBrand();
    }
}
