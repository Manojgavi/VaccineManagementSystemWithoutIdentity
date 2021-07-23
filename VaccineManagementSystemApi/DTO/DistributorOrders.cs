using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineManagementSystemApi.DTO
{
    public class DistributorOrders
    {
        public int Id { get; set; }
        public int Orders { get; set; }
        public int ManufacturerId { get; set; }
        public string Status { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }
    }
}
