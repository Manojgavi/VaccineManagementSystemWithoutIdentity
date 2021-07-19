using System.ComponentModel.DataAnnotations;

namespace VaccineManagementSystemApi.Repository.Entity
{ 
    public class Hospital
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Hospital Name is Mandatory")]
        [Display(Name = "Hospital Name")]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "Enter your first name and last name Ex:(Virat Kohli)")]
        public string HospitalName { get; set; }

        [Required(ErrorMessage = "Manager Name is Mandatory")]
        [Display(Name = "Manager Name")]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "Enter your first name and last name Ex:(Virat Kohli)")]
        public string ManagerName { get; set; }

        [Required(ErrorMessage = "Address is Mandatory")]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"[0-9-,/]+[A-za-z ,]+[0-9]{6}", ErrorMessage = "Door Number,street,City,Pincode Ex:(1-11,street,City,100000)")]
        public string Address { get; set; }



        [Required(ErrorMessage = "City is Mandatory")]
        [Display(Name = "City")]
        [RegularExpression(@"[A-Z]{1}[a-z]*", ErrorMessage = "Please Enter First letter Capital and all other letters small ")]
        public string Location { get; set; }


        [Required(ErrorMessage = "Phone Number is Mandatory")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Please enter valid 10 digit phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is Mandatory")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Mandatory")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Start Time is Mandatory")]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "End Time is Mandatory")]
        public string EndTime { get; set; }

    }
}