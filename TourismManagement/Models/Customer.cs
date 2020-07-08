using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourismManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter your full name !!!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your phone number !!!")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter you identity card !!!")]
        //[RegularExpression(@"^\d{5}-\d{7}-\d$", ErrorMessage = "Invalid ID")]
        public string IdentityCard { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string Departure { get; set; }
        public ICollection<CustomerTour> CustomerTours {get;set;}
        public string Tours { get; set; }
    }
}
