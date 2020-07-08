using System;
namespace TourismManagement.Models
{
    public class CustomerTour
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
