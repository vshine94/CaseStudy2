using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourismManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{StatusCode}")]
        public ViewResult PageNotFound(int StatusCode)
        {
            ViewBag.ErrorMessage = $"Error {StatusCode}: Sorry your requested could'nt be found!!!";
            return View();
        }
    }
}
