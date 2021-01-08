using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoksaProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoksaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        
        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage =
                        "Sorry, the resource you requested could not be found";
                    break;
                case 400:
                    ViewBag.ErrorMessage =
                        "Please check you input and try again";
                    break;
                case 401:
                    ViewBag.ErrorMessage =
                        "Sorry, you are not authorized to view this page";
                    break;
                case 403:
                    ViewBag.ErrorMessage =
                        "Sorry, you are not allowed to view this page";
                    break;
            }
            return View("Error");

        }
    }
}
