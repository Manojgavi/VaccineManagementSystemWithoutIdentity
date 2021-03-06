using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineManagementSystemApi.DTO
{
    public class HospitalVaccines
    {
        public int Id { get; set; }
        public int AvailableVaccines { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public int VaccineTypeId { get; set; }
        public VaccineType VaccineType { get; set; }
    }
}
