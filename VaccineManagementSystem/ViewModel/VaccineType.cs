using System;
using System.ComponentModel.DataAnnotations;

namespace VaccineManagementSystem.ViewModel
{
    public class VaccineType
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}