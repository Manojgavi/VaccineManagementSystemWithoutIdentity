using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace VaccineManagementSystem.ViewModel
{
    public class RegisterViewModel
    {
        
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }
        [Required]
        
        public string Password { get; set; }
        [Required]
        public int UserRoleId { get; set; }
        public IList<UserRole> UserRole { get; set; }
    }
}