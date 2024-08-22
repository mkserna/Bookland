using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookland.Controllers
{
    [Route("[controller]")]
    public class AdminViewController : Controller
    {
        private readonly ILogger<AdminViewController> _logger;

        public AdminViewController(ILogger<AdminViewController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}