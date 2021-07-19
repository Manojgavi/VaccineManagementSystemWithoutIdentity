using System;


namespace VaccineManagementSystemApi.DTO
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string AadharNumber { get; set; }

        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
        public int VaccineTypeId { get; set; }
        public VaccineType VaccineType { get; set; }
    }
}
