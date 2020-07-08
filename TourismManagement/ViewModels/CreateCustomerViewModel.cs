using System;
using System.Collections.Generic;
using TourismManagement.Models;

namespace TourismManagement.ViewModels
{
    public class CreateCustomerViewModel
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        //[RegularExpression(@"^\d{5}-\d{7}-\d$", ErrorMessage = "Invalid ID")]
        public string IdentityCard { get; set; }
        public string Departure { get; set; }
        public List<int> Tours { get; set; }
    }
}
