using System;
using System.ComponentModel.DataAnnotations;

namespace TourismManagement.ViewModels
{
    public class RoleCreateViewModel
    {
        [Required]
        public string RoleName { get; set; }

    }
}
