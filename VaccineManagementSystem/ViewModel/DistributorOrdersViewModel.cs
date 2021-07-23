using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineManagementSystem.ViewModel
{
    public class DistributorOrdersViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int ManufacturerId { get; set; }
        public List<Models.Manufacturer> Manufacturer { get; set; }
    }
}