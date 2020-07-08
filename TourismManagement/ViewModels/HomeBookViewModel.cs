using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TourismManagement.ViewModels
{
    public class HomeBookViewModel
    {
        [Required(ErrorMessage = "Please enter your full name !!!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your phone number !!!")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter you identity card !!!")]
        //[RegularExpression(@"^\d{5}-\d{7}-\d$",ErrorMessage = "Invalid ID")]
        public string IdentityCard { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string Departure { get; set; }
        public List<int> Tours { get; set; }
    }
}
