namespace MedicalEquipmentDonationSystem.Entities
{
    public class LookupItem:MainEntity
    {
        public string Value { get; set; }
        public string ValueAr { get; set; }

        //Foreign key with items
        public int LookupTypeId { get; set; }


    }
}
