using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.DTOs.Lookups.Request;
using MedicalEquipmentDonationSystem.DTOs.Lookups.Response;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentDonationSystem.Implementations
{
    public class LookupService : ILookupService
    {
        private readonly MEDSDbContext _dbContext;
        public LookupService(MEDSDbContext dbContext) {
            _dbContext = dbContext; 
        }

        public async Task<List<LookupItemDTO>> GetLookupItemValueByType(int LookupTypeId)
        {
            var result= from li in _dbContext.LookupItems
                        join lt in _dbContext.LookupTypes 
                        on li.LookupTypeId equals lt.Id
                        where li.LookupTypeId == LookupTypeId
                        select new LookupItemDTO
                        {
                            Id = li.Id,
                            Value = li.Value,
                            ValueAr = li.ValueAr,
                            CreationDate = li.CreationDate.ToShortDateString(),
                            IsDeleted = li.IsDeleted,
                            TypeName=lt.Name,
                            TypeNameAr = lt.NameAr
                        };
            return await result.ToListAsync();
            
        }

        public async Task<List<LookupTypeDTO>> GetLookupType()
        {
            var result = from li in _dbContext.LookupTypes
                         select new LookupTypeDTO
                         {
                             Id = li.Id,
                             Name = li.Name,
                             NameAr = li.NameAr,
                             CreationDate = li.CreationDate.ToString(),
                             IsDeleted = li.IsDeleted,
                         };
            return await result.ToListAsync();
            
        }

        public async Task UpdateLookupItem(UpdateLookupItemDTO input)
        {
            if (input != null)
            {
                var result = await _dbContext.LookupItems.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(input.Value))
                    {
                        result.Value = input.Value;
                        result.ModificationDate = DateTime.Now;

                    }
                    if (!string.IsNullOrEmpty(input.ValueAr))
                    {
                        result.ValueAr = input.ValueAr;
                        result.ModificationDate = DateTime.Now;

                    }if(input.IsDeleted != null)
                    {
                        result.IsDeleted = input.IsDeleted;
                        result.ModificationDate= DateTime.Now;  
                    }
                    _dbContext.Update(result);
                  await  _dbContext.SaveChangesAsync();

                }
                else
                {
                    throw new Exception($"No Lookup with the Given Id {input.Id}");

                }
            }
            else
            {
                throw new Exception("At Least give Id");
            }


        }

        public async Task UpdateLookupTypeStatus(int Id, bool IsDeleted)
        {
            var result =await  _dbContext.LookupTypes.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                result.IsDeleted = IsDeleted;
                result.ModificationDate = DateTime.Now;
                _dbContext.Update(result);
                await _dbContext.SaveChangesAsync();
            }
            else {
                throw new Exception($"No Lookup with the Given Id {Id}");
            }
        }
    }
}
