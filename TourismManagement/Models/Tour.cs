using System;
using System.Collections.Generic;

namespace TourismManagement.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string TourImage { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public ICollection<CustomerTour> CustomerTours { get; set; }
    }
}
