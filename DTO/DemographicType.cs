namespace HRCRS_BACKEND.DTO
{
    public class DemographicType
    {
        public string ForeName { get; set; }
        public string SurName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string IdentificationName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Region { get; set; }
        public int Pincode { get; set; }
        public int AddressType { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LegalCopyStatus { get; set; }
        public bool IsActive { get; set; }
        public int AddedBy   { get; set; }
        public int ModifiedBy { get; set; }

    }
}
