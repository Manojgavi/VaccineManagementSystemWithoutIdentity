using System;
using System.ComponentModel.DataAnnotations;

namespace VaccineManagementSystemApi.Repository.Entity
{
    public class Customer
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is Mandatory")]
        [Display(Name = "Name")]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "Enter your first name and last name Ex:(Virat Kohli)")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Date of birth is Mandatory")]
        
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Please Enter a Vaild Date")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Gender is Mandatory")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Address is Mandatory")]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"[0-9-,/]+[A-za-z ,]+[0-9]{6}", ErrorMessage = "Door Number,street,City,Pincode Ex:(1-11,street,City,100000)")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Email is Mandatory")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone Number is Mandatory")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Please enter valid 10 digit phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Aadhar Number is Mandatory")]
        [Display(Name = "Aadhar Number")]
        [RegularExpression(@"[0-9]{12}", ErrorMessage = "Please Enter Valid Aadhar Number")]
        public string AadharNumber { get; set; }


        [Required(ErrorMessage = "Please choose a Hospital")]
        [Display(Name = "Nearby Hospital")]
        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
        


        [Required(ErrorMessage = "Please Choose a Vaccine Type")]
        [Display(Name = "Vaccine Type")]
        public int VaccineTypeId { get; set; }
        public VaccineType VaccineType { get; set; }
        public string Status { get; set; }
    }
}