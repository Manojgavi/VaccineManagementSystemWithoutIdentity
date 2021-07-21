using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineManagementSystem.ViewModel
{
    public class HospitalOrdersViewModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int VaccineTypeId { get; set; }
        public IList<Models.VaccineType> VaccineTypes { get; set; }
        public int DistributorId { get; set; }
        public IList<Models.Distributor> Distributors { get; set; }
    }
}