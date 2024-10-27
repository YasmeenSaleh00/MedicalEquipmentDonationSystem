using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.DTOs.Testimonial.Request;
using MedicalEquipmentDonationSystem.DTOs.Testimonial.Response;
using MedicalEquipmentDonationSystem.Entities;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentDonationSystem.Implementations
{
    public class TestimonialService : ITestimonialService
    {
        private readonly MEDSDbContext _context;
        public TestimonialService(MEDSDbContext context)
        {
            _context = context;

        }

        public async Task CreateTestimonial(CreateTestimonialDTO input)
        {
            if (input != null)
            {
                Testimonial testimonial = new Testimonial()
                {
                    Description = input.Description,
                    DescriptionAr  = input.DescriptionAr,
                    TestimonialTypeId = input.TestimonialTypeId,
                    UserId = input.UserId,
                };
                _context.Add(testimonial);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Must Add Data");
            }


        }

        public async Task<List<TestimonialViaTypeDTO>> GetTestimonailByType(int TestimonialTypeId)
        {
            var result = from li in _context.Testimonials
                         join p in _context.LookupItems
                         on li.TestimonialTypeId equals p.Id
                         where li.TestimonialTypeId == TestimonialTypeId
                         select new TestimonialViaTypeDTO
                         {
                             Id = li.Id,
                             TestimonialType = p.Value,
                             TestimonialTypeAr = p.Value,   
                             Description = li.Description,
                             DescriptionAr = li.DescriptionAr,
                             CreationDate =li.CreationDate.ToShortDateString(), 

                         };
            return await result.ToListAsync();
           
        }

        public async Task ManageActivationStatus(int Id, bool IsDeleted)
        {
            var test = await _context.Testimonials.FirstOrDefaultAsync(t => t.Id == Id);
            if (test != null)
            {
                test.IsDeleted = IsDeleted;
                test.ModificationDate = DateTime.Now;
                
                _context.Update(test);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"There is no Testimonials With the Given Id : {Id}");
            }
        }
    }
}
