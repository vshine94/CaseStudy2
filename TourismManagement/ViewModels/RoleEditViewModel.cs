using System;
using System.ComponentModel.DataAnnotations;

namespace TourismManagement.ViewModels
{
    public class RoleEditViewModel
    {
        public string RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
