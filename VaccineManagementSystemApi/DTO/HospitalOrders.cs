using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineManagementSystemApi.DTO
{
    public class HospitalOrders
    {
        public int Id { get; set; }
        public int Orders { get; set; }
        public int HospitalId { get; set; }
        public string Status { get; set; }
        public Hospital Hospital { get; set; }
        public int VaccineTypeId { get; set; }
        public VaccineType VaccineType { get; set; }
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }

    }
}
