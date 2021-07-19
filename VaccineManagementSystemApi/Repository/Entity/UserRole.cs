using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VaccineManagementSystemApi.Repository.Entity
{
    public class UserRole
    {
        public int Id { get; set; }
        
        [Required]
        public string Role { get; set; }
    }
}
