namespace VaccineManagementSystem.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }



        public string Name { get; set; }


        public string ManagerName { get; set; }


        public string Address { get; set; }



        public string PhoneNumber { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }

        public int VaccineTypeId { get; set; }
        public VaccineType VaccineType { get; set; }
    }
}