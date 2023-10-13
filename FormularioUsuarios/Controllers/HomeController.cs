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
        public IActionResult DetalleUsuario(int idUsuario)
        {
            UsuarioVM oUsuario = new UsuarioVM();
            oUsuario.FechaNacimiento = DateTime.Now;

            if (idUsuario != 0)
            {
                Usuario usuario = _DBContext.Usuarios.Find(idUsuario);
                if (usuario != null)
                {
                    oUsuario.Id = usuario.Id;
                    oUsuario.Nombres = usuario.Nombres;
                    oUsuario.Apellidos = usuario.Apellidos;
                    oUsuario.FechaNacimiento = usuario.FechaNacimiento;
                    oUsuario.NroDocumento = usuario.NroDocumento;
                    oUsuario.Departamento = usuario.Departamento;
                    oUsuario.Provincia = usuario.Provincia;
                    oUsuario.Direccion = usuario.Direccion;
                    oUsuario.Estado = usuario.Estado;
                }
            }
            return View(oUsuario);
        }
        [HttpPost]
        public IActionResult GuardarUsuario(UsuarioVM oUsuarioVM)
        {
            if (ModelState.IsValid)
            {
                if (oUsuarioVM.Id == 0)
                {
                    Usuario nuevo = new Usuario();
                    int ultimoId = _DBContext.Usuarios.OrderByDescending(u => u.Id).Select(u => u.Id).FirstOrDefault();
                    nuevo.Id = ultimoId + 1;
                    nuevo.Nombres = oUsuarioVM.Nombres;
                    nuevo.Apellidos = oUsuarioVM.Apellidos;
                    nuevo.FechaNacimiento = oUsuarioVM.FechaNacimiento;
                    nuevo.NroDocumento = oUsuarioVM.NroDocumento;
                    nuevo.Departamento = oUsuarioVM.Departamento;
                    nuevo.Provincia = oUsuarioVM.Provincia;
                    nuevo.Direccion = oUsuarioVM.Direccion;
                    nuevo.Estado = oUsuarioVM.Estado;
                    _DBContext.Usuarios.Add(nuevo);

                }
                else
                {
                    _DBContext.Usuarios.Update(new Usuario
                    {
                        Id = oUsuarioVM.Id,
                        Nombres = oUsuarioVM.Nombres,
                        Apellidos = oUsuarioVM.Apellidos,
                        FechaNacimiento = oUsuarioVM.FechaNacimiento,
                        NroDocumento = oUsuarioVM.NroDocumento,
                        Departamento = oUsuarioVM.Departamento,
                        Provincia = oUsuarioVM.Provincia,
                        Direccion = oUsuarioVM.Direccion,
                        Estado = oUsuarioVM.Estado
                    });
                }

                _DBContext.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("DetalleUsuario", oUsuarioVM);
        }

        [HttpGet]
        public IActionResult EliminarUsuario(int idUsuario)
        {
            Usuario usuario = _DBContext.Usuarios.Find(idUsuario);
            if (usuario != null)
            {
                usuario.Estado = false;
                _DBContext.Usuarios.Update(usuario);
                _DBContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }   
        





    }
}