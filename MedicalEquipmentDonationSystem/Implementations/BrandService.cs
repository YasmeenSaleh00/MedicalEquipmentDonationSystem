using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.DTOs.Brand;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentDonationSystem.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly MEDSDbContext _dbcontext;
        public BrandService(MEDSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<List<BrandDTO>> GetAllBrand()
        {
            var res = from li in _dbcontext.Brands
                      select new BrandDTO
                      {
                          Id = li.Id,
                          Name = li.Name,
                          CreationDate = li.CreationDate.ToShortDateString(),
                          IsDeleted = li.IsDeleted,

                      };
            return await res.ToListAsync();
        }
    }
}
