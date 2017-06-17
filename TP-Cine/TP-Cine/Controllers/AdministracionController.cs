using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            List<Sedes> todasSedes = new List<Sedes>();

            Entities ctx = new Entities();

            var listaSedes = (from sedes in ctx.Sedes
                              select sedes).ToList();

            todasSedes = (List<Sedes>)listaSedes;

            return View(todasSedes);
           
        }

        public ActionResult Carteleras()
        {  
            Entities db = new Entities();
            var carteleras = db.Carteleras.Include(c => c.Peliculas).Include(c => c.Sedes).Include(c => c.Versiones);
            return View(carteleras.ToList());
        }
        

        public ActionResult Reportes()
        {
            return View();
        }

        //Agregar pelicula nueva
        [HttpPost]
        public ActionResult AgregarPelicula(FormCollection form)
        {
            Entities ctx = new Entities();
            Peliculas peli = new Peliculas();

            peli.Nombre = form["nombre"];
            peli.Descripcion = form["descripcion"];
            //peli.Calificaciones = form["calificacion"];
            //peli.Generos = form["genero"];
            peli.Imagen = form["imagen"];
            peli.Duracion = Convert.ToInt16(form["duracion"]);

            return View("Peliculas");
        }

        //Agregar sede nueva
        [HttpPost]
        public ActionResult AgregarSede(FormCollection form)
        {
            Entities ctx = new Entities();
            Sedes sede = new Sedes();

            sede.Nombre = form["nombre"];
            sede.Direccion = form["direccion"];
            sede.PrecioGeneral = Convert.ToDecimal(form["precioGeneral"]);

            ctx.Sedes.Add(sede);
            ctx.SaveChanges();

            return RedirectToAction("Sedes");
        }

        //Agregar cartelera nueva
        public ActionResult AgregarCartelera()
        {
            return View();
        }

        //Modificar sede

        public PartialViewResult ModificarSede(int id)
        {
            Entities ctx = new Entities();
            Sedes sede = new Sedes();

            var editar = (from sedes in ctx.Sedes
                          where sedes.IdSede == id
                          select sedes).ToList();

            sede = editar.First();


            ViewBag.sede = editar;

            return PartialView("_ModifSede", sede);
        }

        public ActionResult ModificaSede(FormCollection form)
        {
            Entities ctx = new Entities();
            
            int id = int.Parse(form["IdSede"]);

            Sedes sede = (from sedes in ctx.Sedes
                          where sedes.IdSede == id
                          select sedes).First();

            sede.Nombre = form["Nombre"];
            sede.Direccion = form["Direccion"];
            sede.PrecioGeneral = Convert.ToDecimal(form["PrecioGeneral"]);

            ctx.SaveChanges();

            return RedirectToAction("Sedes");

        }
    }
}
