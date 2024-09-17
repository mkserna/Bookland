using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookland.Models.Users;
using Bookland.Database;

namespace Bookland.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AppDbContext _context;

        public AuthController(ILogger<AuthController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Auth/Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            // Busca en la base de datos un usuario con el correo y la contraseña proporcionados
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Redirige al usuario basado en el rol que tenga
                if (user.Role.RoleName == "Administrator")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }

            // Si no se encuentra el usuario, añade un error al estado del modelo y vuelve a mostrar el formulario
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        // GET: Auth/Register
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Auth/Register
        [HttpPost("Register")]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Asignar el rol "User" automáticamente
                var userRole = _context.Roles.FirstOrDefault(r => r.RoleName == "User");
                if (userRole != null)
                {
                    model.Role = userRole;
                }
                else
                {
                    // Manejo de caso en que el rol "User" no se encuentra en la base de datos
                    ModelState.AddModelError(string.Empty, "Role 'User' not found.");
                    return View(model);
                }

                // Añade el nuevo usuario a la base de datos y guarda los cambios
                _context.Users.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            // Si el modelo no es valido, vuelve a mostrar el formulario de registro con los errores
            return View(model);
        }
    }
}
