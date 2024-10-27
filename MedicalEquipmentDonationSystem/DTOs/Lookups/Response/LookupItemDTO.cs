namespace MedicalEquipmentDonationSystem.DTOs.Lookups.Response
{
    public class LookupItemDTO
    {
        public int Id {  get; set; }
        public string TypeName {  get; set; }
        public string TypeNameAr { get; set; }
        public string Value { get; set; }
        public string ValueAr { get; set; }
        public string CreationDate { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
