using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP_Cine.Models.ModeloNegocio;


namespace TP_Cine.Controllers
{
    public class AdministracionController : Controller
    {
        CineNegocio CN = new CineNegocio(); //Si lo creamos aca no es necesario agregarlo en todas las acciones
       
        //
        // GET: /Administracion/

        public ActionResult Inicio()
        {
            
            return View();
        }

        //Gestión de Sedes
        public ActionResult Sedes()
        {
            CN.listarSedes();

            return View(CN.listaSedes);
        }

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

        public ActionResult Sedes_Modificar(int id)
        {
            Sedes sede = new Sedes();

            sede = CN.obtenerSede(id);

            return View(sede);
        }

        public ActionResult ModificaSede(FormCollection form)
        {
            CN.modificarSede(int.Parse(form["IdSede"]), form["Nombre"], form["Direccion"], Convert.ToDecimal(form["PrecioGeneral"]));

            return RedirectToAction("Sedes");

        }

        //
        public ActionResult Peliculas()
        {
            return View();
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

        
        //Agregar cartelera nueva
        public ActionResult AgregarCartelera()
        {
            return View();
        }

       
    }
}
