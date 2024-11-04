using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.DTOs.Category.Request;
using MedicalEquipmentDonationSystem.DTOs.Category.Response;
using MedicalEquipmentDonationSystem.Entities;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentDonationSystem.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly MEDSDbContext _dbcontext;
        public CategoryService(MEDSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task CreateCategory(CreateCategoryDTO input)
        {
            if (input != null)
            {
                if (input.Name != null && input.NameAr != null)
                {
                    Category category = new Category()
                    {
                        Name = input.Name,
                        NameAr = input.NameAr,
                        Description = input.Description,
                        DescriptionAr = input.DescriptionAr,    
                    };

                    _dbcontext.Add(category);
                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Must pass names of Category in both Languages : (Arabic && English");
                }
            }
            else
            {
                throw new Exception("Must Add Data");
            }
            
        }

        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            var  res = from c in _dbcontext.Categories 
                       select new CategoryDTO
                       {
                           Id = c.Id,
                           Name = c.Name,
                           NameAr = c.NameAr,
                           Description =c.Description,
                           DescriptionAr = c.DescriptionAr,
                           CreationDate = c.CreationDate.ToShortDateString(),
                           ModificationDate = c.ModificationDate.ToString(),
                           IsDeleted = c.IsDeleted, 
                       };
            return await res.ToListAsync();
        }

        public async Task UpdateCategory(UpdateCategoryDTO input)
        {
            if (input != null)
            {
                var result = await _dbcontext.Categories.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(input.Name))
                    {
                        result.Name = input.Name;
                        result.ModificationDate = DateTime.Now;

                    }
                    if (!string.IsNullOrEmpty(input.NameAr))
                    {
                        result.NameAr = input.NameAr;
                        result.ModificationDate = DateTime.Now;

                    }
                    if (!string.IsNullOrEmpty(input.Description))
                    {
                        result.Description = input.Description;
                        result.ModificationDate = DateTime.Now;

                    }
                    if (!string.IsNullOrEmpty(input.DescriptionAr))
                    {
                        result.DescriptionAr = input.DescriptionAr;
                        result.ModificationDate = DateTime.Now;

                    }
                    if (input.IsDeleted != null)
                    {
                        result.IsDeleted =(bool) input.IsDeleted;
                        result.ModificationDate = DateTime.Now;

                    }
                    _dbcontext.Update(result);
                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"No Id  like the given Id : {input.Id}");
                }
            }
            else { throw new Exception("At Least Must Pass The Id Value"); }

        }
    }
}
