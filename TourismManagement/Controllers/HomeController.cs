using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TourismManagement.Models;
using TourismManagement.ViewModels;

namespace TourismManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITourRepository tourRepository;

        public HomeController(ILogger<HomeController> logger, ITourRepository tourRepository)
        {
            _logger = logger;
            this.tourRepository = tourRepository;
        }

        public IActionResult Index()
        {
            var indexViewModel = new HomeIndexViewModel()
            {
                tours = tourRepository.Gets(),
                TitleName = "Index"
            };
            return View(indexViewModel);
        }

        public IActionResult Infor(int? id)
        {
            var inforViewModel = new HomeInforViewModel()
            {
                tour = tourRepository.Get(id ?? 1),
                TitleName = "Infor"
            };
            return View(inforViewModel);
        }

        [HttpGet]
        public IActionResult Book()
        {
            ViewBag.Tours = GetTours();
            return View();
        }

        private List<Tour> GetTours()
        {
            return tourRepository.Gets().ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
