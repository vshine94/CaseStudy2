using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TourismManagement.Models;
using TourismManagement.ViewModels;

namespace TourismManagement.Controllers
{
    [Authorize(Roles = "System Admin,Admin")]
    public class TourManagerController : Controller
    {
        private readonly ITourRepository tourRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ITypeRepository typeRepository;

        public TourManagerController(ITourRepository tourRepository,IWebHostEnvironment webHostEnvironment,
            ITypeRepository typeRepository)
        {
            this.tourRepository = tourRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.typeRepository = typeRepository;
        }
        public IActionResult Index()
        {
            var indexViewModel = new HomeIndexViewModel()
            {
                tours = tourRepository.Gets(),
                TitleName = "Tour management"
            };
            return View(indexViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Types = GetTypes();
            return View();
        }
        [HttpPost]
        public IActionResult Create(TMCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tour = new Tour()
                {
                    TourName = model.TourName,
                    Description = model.Desciption,
                    Price = model.Price,
                    TypeId = model.TypeId
                };
                var fileName = string.Empty;
                if (model.Img != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{model.Img.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Img.CopyTo(fs);
                    }
                }
                tour.TourImage = fileName;
                var newTour = tourRepository.Create(tour);
                return RedirectToAction("Index","TourManager");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tour = tourRepository.Get(id);
            ViewBag.Types = GetTypes();
            if (tour == null)
            {
                return View("~/Views/Error/TourNotFound.cshtml", id);
            }
            var editTour = new TMEditViewModel()
            {
                AvatarPath = tour.TourImage,
                TourName = tour.TourName,
                Desciption = tour.Description,
                Price = tour.Price,
                ID = tour.TourId,
                TypeId = tour.TypeId
            };
            return View(editTour);
        }
        [HttpPost]
        public IActionResult Edit(TMEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tour = new Tour()
                {
                    TourName = model.TourName,
                    TourId = model.ID,
                    Description = model.Desciption,
                    Price = model.Price,
                    TourImage = model.AvatarPath,
                    TypeId = model.TypeId
                };
                var fileName = string.Empty;
                if (model.AvatarPath != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{model.Img.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Img.CopyTo(fs);
                    }
                    tour.TourImage = fileName;
                    if (!string.IsNullOrEmpty(model.AvatarPath))
                    {
                        string delFile = Path.Combine(webHostEnvironment.WebRootPath, "images", model.AvatarPath);
                        System.IO.File.Delete(delFile);
                    }
                }

                var editTour = tourRepository.Edit(tour);
                if (editTour != null)
                {
                    return RedirectToAction("Index", "TourManager");
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var tour = tourRepository.Get(id);
            string delFile = Path.Combine(webHostEnvironment.WebRootPath, "images", tour.TourImage);
            System.IO.File.Delete(delFile);
            if (tourRepository.Delete(id))
            {
                return RedirectToAction("Index", "TourManager");
            }
            return View();
        }
        private List<Models.Type> GetTypes()
        {
            return typeRepository.Gets().ToList();
        }
    }
}
