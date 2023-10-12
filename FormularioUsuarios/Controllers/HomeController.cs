using FormularioUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FormularioUsuarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly PruebaContext _DBContext;

        public HomeController(PruebaContext DBContext)
        {
            _DBContext = DBContext;
        }

        public IActionResult Index()
        {
            List<Usuario> list = _DBContext.Usuarios.ToList();
            return View(list);
        }

        

    }
}