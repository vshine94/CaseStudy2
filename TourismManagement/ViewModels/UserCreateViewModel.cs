using System;
using System.ComponentModel.DataAnnotations;

namespace TourismManagement.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm password not match!")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Display(Name = "Role")]
        public string RolesId { get; set; }
    }
}
