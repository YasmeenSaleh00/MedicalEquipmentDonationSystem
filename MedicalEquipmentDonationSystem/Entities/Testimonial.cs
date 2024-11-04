namespace MedicalEquipmentDonationSystem.Entities
{
    public class Testimonial:MainEntity
    {

        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public int UserId { get; set; }
        public int TestimonialTypeId { get; set; }
    }
}
