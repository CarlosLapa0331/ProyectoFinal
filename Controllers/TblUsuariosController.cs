using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Turicentro_Estructura_de_datos.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Controllers
{
    public class TblUsuariosController : Controller
    {
        private readonly DbTuricentroContext _context;

        public TblUsuariosController(DbTuricentroContext context)
        {
            _context = context;
        }

        // GET: TblUsuarios/Login
        public IActionResult Login()
        {
            return View(); // Muestra la vista Login.cshtml
        }

        // POST: TblUsuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(TblUsuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Correo) || string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                ViewBag.Error = "Correo y contraseña son requeridos.";
                return View();
            }

            // Verifica las credenciales del usuario en la base de datos
            var usuarioEncontrado = await _context.TblUsuarios
                .FirstOrDefaultAsync(u => u.Correo == usuario.Correo && u.Contraseña == usuario.Contraseña);

            if (usuarioEncontrado != null)
            {
                // Establece la sesión
                HttpContext.Session.SetInt32("UsuarioID", usuarioEncontrado.UsuarioId);
                HttpContext.Session.SetString("Rol", usuarioEncontrado.Rol);

                // Redirige según el rol
                if (usuarioEncontrado.Rol == "Administrador")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else if (usuarioEncontrado.Rol == "Cliente")
                {
                    return RedirectToAction("Index", "Cliente");
                }
            }
            else
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
            }

            return View();
        }

        // Acción para cerrar sesión
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpia la sesión
            return RedirectToAction("Login");
        }

        private bool TblUsuarioExists(int id)
        {
            return _context.TblUsuarios.Any(e => e.UsuarioId == id);
        }
    }
}