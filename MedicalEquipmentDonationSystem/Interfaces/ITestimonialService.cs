using MedicalEquipmentDonationSystem.DTOs.Testimonial.Request;
using MedicalEquipmentDonationSystem.DTOs.Testimonial.Response;

namespace MedicalEquipmentDonationSystem.Interfaces
{
    public interface ITestimonialService
    {
        Task CreateTestimonial(CreateTestimonialDTO input , string token);
        Task<List<TestimonialViaTypeDTO>> GetTestimonailByType(int TestimonialTypeId);
        Task ManageActivationStatus(int Id ,bool IsDeleted);


    }
}
