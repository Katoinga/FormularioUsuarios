using FormularioUsuarios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormularioUsuarios.Models.ViewModels;

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

        [HttpGet] 
        public IActionResult DetalleUsuario()
        {
            UsuarioVM oUsuario = new UsuarioVM();
            return View(oUsuario);
        }
        [HttpPost]
        public IActionResult GuardarUsuario(UsuarioVM oUsuarioVM)
        {
            if (ModelState.IsValid)
            {
                Usuario nuevo = new Usuario();
                nuevo.Nombres = oUsuarioVM.Nombres;
                nuevo.Apellidos = oUsuarioVM.Apellidos;
                nuevo.FechaNacimiento = oUsuarioVM.FechaNacimiento;
                nuevo.NroDocumento = oUsuarioVM.NroDocumento;
                nuevo.Departamento = oUsuarioVM.Departamento;
                nuevo.Provincia = oUsuarioVM.Provincia;
                nuevo.Direccion = oUsuarioVM.Direccion;
                nuevo.Estado = oUsuarioVM.Estado;
                _DBContext.Usuarios.Add(nuevo);
                _DBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("DetalleUsuario", oUsuarioVM);
        }




    }
}