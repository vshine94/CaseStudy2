using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TourismManagement.ViewModels
{
    public class TMCreateViewModel
    {
        [Required(ErrorMessage = "Please enter your full name !!!")]
        [Display(Name = "Full Name")]
        public string TourName { get; set; }
        public IFormFile Img { get; set; }
        public string Desciption { get; set; }
        [Required]
        public long Price { get; set; }
        public int TypeId { get; set; }
    }
}
