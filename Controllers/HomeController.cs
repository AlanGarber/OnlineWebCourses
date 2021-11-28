using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP11_Blaser_Garber.Models;

namespace TP11_Blaser_Garber.Controllers
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
            ViewBag.Cursos = BD.ListarCursos(-1);
            ViewBag.ListaEspecialidades=BD.ListarEspecialidades();
            return View();
        }

        public IActionResult MostrarCursosxEspecialidad(int IdEspecialidad)
        {
            ViewBag.Cursos=BD.ListarCursos(IdEspecialidad);
            ViewBag.ListaEspecialidades=BD.ListarEspecialidades();
            return View("Index");
        }
        public IActionResult VerCurso(int IdCurso)
        {
            ViewBag.InfoCurso=BD.ConsultaCurso(IdCurso);
            return View("DetalleCurso");
        }

        public IActionResult Calificar(int IdCurso, bool LeGusta)
        {
            BD.CalificarCurso(IdCurso,LeGusta);
            ViewBag.InfoCurso=BD.ConsultaCurso(IdCurso);
            return View("DetalleCurso");
        }
         public IActionResult AgregarCurso()
        {
            ViewBag.Especialidades=BD.ListarEspecialidades();
            return View("AgregarCurso");
        }
        [HttpPost]
        public IActionResult GuardarCurso(string Nombre, string Descripcion, string Imagen, string UrlCurso,int IdEspecialidad)
        {
            Curso MiCurso=new Curso(0,Nombre,IdEspecialidad,Descripcion,Imagen,UrlCurso,0,0);
            BD.AgregarCurso(MiCurso);
            return Redirect("Index/Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
    }
}
