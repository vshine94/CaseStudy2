﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TourismManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Confirm Password not match")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
