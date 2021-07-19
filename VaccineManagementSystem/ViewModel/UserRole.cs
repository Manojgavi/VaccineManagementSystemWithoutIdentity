using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VaccineManagementSystem.ViewModel
{
    public class UserRole
    {
        public int Id { get; set; }
        
        [Required]
        public string Role { get; set; }
    }
}
