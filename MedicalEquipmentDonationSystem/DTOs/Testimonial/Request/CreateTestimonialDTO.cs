namespace MedicalEquipmentDonationSystem.DTOs.Testimonial.Request
{
    public class CreateTestimonialDTO
    {
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public int TestimonialTypeId { get; set; }
        public int UserId { get; set; }
    }
}
