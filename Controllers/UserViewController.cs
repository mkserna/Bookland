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
    public class UserViewController : Controller
    {
        private readonly ILogger<UserViewController> _logger;

        public UserViewController(ILogger<UserViewController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult User()
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