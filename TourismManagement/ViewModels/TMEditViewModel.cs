using System;
namespace TourismManagement.ViewModels
{
    public class TMEditViewModel : TMCreateViewModel
    {
        public int ID { get; set; }
        public string AvatarPath { get; set; }
    }
}
