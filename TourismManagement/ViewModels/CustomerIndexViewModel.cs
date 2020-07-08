using System;
using System.Collections.Generic;
using TourismManagement.Models;

namespace TourismManagement.ViewModels
{
    public class CustomerIndexViewModel
    {
        public IEnumerable<Customer> customers { get; set; }
        public string TitleName { get; set; }
    }
}
