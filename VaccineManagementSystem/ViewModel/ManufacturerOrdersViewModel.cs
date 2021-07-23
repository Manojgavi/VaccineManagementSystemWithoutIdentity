using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineManagementSystem.ViewModel
{
    public class ManufacturerOrdersViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        //public int DistributorId { get; set; }
        public string DistributorName { get; set; }
    }
}