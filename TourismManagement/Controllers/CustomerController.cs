using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourismManagement.Models;
using TourismManagement.ViewModels;

namespace TourismManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ITourRepository tourRepository;

        public CustomerController(ICustomerRepository customerRepository,ITourRepository tourRepository)
        {
            this.customerRepository = customerRepository;
            this.tourRepository = tourRepository;
        }
        public IActionResult Index()
        {
            var indexViewModel = new CustomerIndexViewModel()
            {
                customers = customerRepository.Gets(),
                TitleName = "CustomerManager"
            };
            return View(indexViewModel);
        }
        [HttpPost]
        public IActionResult Create(HomeBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new CreateCustomerViewModel()
                {
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    IdentityCard = model.IdentityCard,
                    Departure = model.Departure,
                    Tours = model.Tours
                };
                customerRepository.Create(customer);
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = customerRepository.Get(id);
            if (customer == null)
            {
                return View("~/Views/Error/PageNotFound.cshtml", id);
            }
            var editCustomer = new CustomerEditViewModel()
            {
                FullName = customer.FullName,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                IdentityCard = customer.IdentityCard,
                Departure = customer.Departure
            };
            ViewBag.Tours = GetTours();
            return View(editCustomer);
        }
        [HttpPost]
        public IActionResult Edit(CustomerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    IdentityCard = model.IdentityCard,
                    Departure = model.Departure,
                    CustomerId = model.Id
                };               
                var editCus = customerRepository.Edit(customer);
                if (editCus != null)
                {
                    return RedirectToAction("Index", "Customer");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var customer = customerRepository.Get(id);
            if(customer != null)
            {
                customerRepository.Delete(id);
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }
        private List<Tour> GetTours()
        {
            return tourRepository.Gets().ToList();
        }
    }
}
