using System.ComponentModel.DataAnnotations;

namespace CustomerRegistrationPortal.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}


