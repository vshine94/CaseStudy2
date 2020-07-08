using System;
using System.Collections.Generic;
using TourismManagement.Models;

namespace TourismManagement.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Tour> tours { get; set; }
        public string TitleName { get; set; }
    }
}
