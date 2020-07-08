using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TourismManagement.Models
{
    public class Type
    {
        public int TypeId { get; set; }
        [MaxLength(100)]
        public string TypeName { get; set; }
        public ICollection<Tour> Tours{ get; set; }
    }
}
