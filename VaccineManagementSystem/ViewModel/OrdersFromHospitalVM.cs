using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineManagementSystem.ViewModel
{
    public class OrdersFromHospitalVM
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public int HospitalId { get; set; }
        public string VaccineName { get; set; }
        public int VaccineTypeId { get; set; }
        public int Orders { get; set; }
    }
}