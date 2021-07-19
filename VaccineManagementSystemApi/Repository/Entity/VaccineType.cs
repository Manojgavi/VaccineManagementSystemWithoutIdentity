using System;
using System.ComponentModel.DataAnnotations;

namespace VaccineManagementSystemApi.Repository.Entity
{
    public class VaccineType
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}