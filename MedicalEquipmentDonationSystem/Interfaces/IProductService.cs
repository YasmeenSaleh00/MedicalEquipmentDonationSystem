using MedicalEquipmentDonationSystem.DTOs.Product.Request;
using MedicalEquipmentDonationSystem.DTOs.Product.Response;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductDTO input);
        Task<List<ProductDTO>> GetProducByCategory(int categoryId);
        Task<List<PrpductByBrandDTO>> GetProductViaBrand(int brandId);
        Task ManageStatus (int productId , bool IsDeleted);
        Task UpdateProductInformation(UpdateProductDTO input);
        
    }
}
