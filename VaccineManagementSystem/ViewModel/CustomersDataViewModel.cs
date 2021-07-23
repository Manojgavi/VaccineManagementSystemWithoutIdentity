using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineManagementSystem.ViewModel
{
    public class CustomersDataViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }
 
        public string PhoneNumber { get; set; }

        public string AadharNumber { get; set; }
      
        public int VaccineTypeId { get; set; }
        public string VaccineName { get; set; }

    }
}