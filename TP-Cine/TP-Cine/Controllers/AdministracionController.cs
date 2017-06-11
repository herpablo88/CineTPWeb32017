using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_Cine.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Peliculas()
        {
            return View();
        }

        public ActionResult Sedes()
        {
            return View();
        }

        public ActionResult Carteleras()
        {
            return View();
        }

        public ActionResult Reportes()
        {
            return View();
        }

        //Agregar pelicula nueva
        public ActionResult AgregarPelicula()
        {
            return View();
        }

        //Agregar sede nueva
        [HttpPost]
        public ActionResult AgregarSede(FormCollection form)
        {
            CineEntities ctx = new CineEntities();
            Sedes sede = new Sedes();

            sede.Nombre = form["nombre"];
            sede.Direccion = form["direccion"];
            sede.PrecioGeneral = Convert.ToDecimal(form["precioGeneral"]);

            ctx.Sedess.Add(sede);
            ctx.SaveChanges();

            return View("Sedes");
        }

        //Agregar cartelera nueva
        public ActionResult AgregarCartelera()
        {
            return View();
        }

       
    }
}
