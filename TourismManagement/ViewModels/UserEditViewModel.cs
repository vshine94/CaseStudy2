using System;
using System.ComponentModel.DataAnnotations;

namespace TourismManagement.ViewModels
{
    public class UserEditViewModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}
