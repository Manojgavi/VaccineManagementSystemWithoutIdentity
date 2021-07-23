using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineManagementSystemApi.Repository.Entity
{
    public class DistributorVaccines
    {
        public int Id { get; set; }
        public int AvailableVaccines { get; set; }
        public int HospitalId { get; set; }
        public Distributor Distributor { get; set; }
        public int VaccineTypeId { get; set; }
        public VaccineType VaccineType { get; set; }
    }
}
