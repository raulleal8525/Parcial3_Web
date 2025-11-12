using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial3_Web.Data;
using Parcial3_Web.Models;
using Parcial3_Web.Models;
using System.Diagnostics;

namespace Parcial3_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Si ya está autenticado, redirigir al directorio
            if (HttpContext.Session.GetString("UsuarioAutenticado") == "true")
            {
                return RedirectToAction("Index", "Directorio");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usuario, string password)
        {
            // Validar credenciales en la base de datos
            var usuariobd = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == usuario &&
                                         u.Password == password &&
                                         u.Activo);

            if (usuariobd != null)
            {
                // Guardar en sesión que el usuario está autenticado
                HttpContext.Session.SetString("UsuarioAutenticado", "true");
                HttpContext.Session.SetString("NombreUsuario", usuariobd.NombreUsuario);
                HttpContext.Session.SetInt32("UsuarioId", usuariobd.Id);

                return RedirectToAction("Index", "Directorio");
            }

            // Si las credenciales son incorrectas
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View("Index");
        }

        public IActionResult Logout()
        {
            // Limpiar la sesión
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}