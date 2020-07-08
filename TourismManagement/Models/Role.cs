using System;
using System.ComponentModel.DataAnnotations;

namespace TourismManagement.Models
{
    public class Role
    {
        public string RoleId { get; set; }
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
