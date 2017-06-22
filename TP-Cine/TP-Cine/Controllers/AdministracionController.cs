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
            CN.agregarSede(form["nombre"],form["direccion"],Convert.ToDecimal(form["precioGeneral"]));
            
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

        //Reporte de Reservas
        public ActionResult Reportes()
        {
            CN.listarReservas();

            return View(CN.listaReservasNegocio);
        }

        [HttpPost]
        public ActionResult FiltrarReportes(FormCollection form)
        {
            CN.listarReservas(form["fechaInicio"], form["fechaFin"]);

            return View("Reportes", CN.listaReservasNegocio);
        }

        //
        public ActionResult Peliculas()
        {
            //Se cargan las categorias y generos
            Entities ctx = new Entities();
            List<Generos> generos_form = ctx.Generos.ToList();
            List<Calificaciones> calificaciones_form = ctx.Calificaciones.ToList();
            List<Peliculas> peliculas_form = ctx.Peliculas.ToList();
            ViewBag.generos = generos_form;
            ViewBag.calificaciones = calificaciones_form;
            ViewBag.peliculas = peliculas_form;

            return View();
        }


        public ActionResult Carteleras()
        {  
            Entities db = new Entities();
            var carteleras = db.Carteleras.Include(c => c.Peliculas).Include(c => c.Sedes).Include(c => c.Versiones);
            return View(carteleras.ToList());
        }
        

 //Agregar pelicula nueva
        [HttpPost]
        public ActionResult AgregarEditarPelicula(FormCollection form)
        {
            Entities ctx = new Entities();
            Peliculas peli = new Peliculas();
            Calificaciones calif = new Calificaciones();
            Generos gen = new Generos();

            if (form.AllKeys.Contains("id")) {
                peli = ctx.Peliculas.Find(Convert.ToInt32(form["id"]));
            }

            peli.Nombre = form["nombre"];
            peli.Descripcion = form["descripcion"];
            var c = form["calificacion"];
            peli.Calificaciones = ctx.Calificaciones.Find(Convert.ToInt32(c)); 
            var g = form["genero"];
            peli.Generos = ctx.Generos.Find(Convert.ToInt32(g));
            peli.Imagen = form["imagen"];//cambiar por img_64 para base64
            peli.Duracion = Convert.ToInt16(form["duracion"]);

            if (!form.AllKeys.Contains("id"))
            {
                peli.FechaCarga = DateTime.Now;
                ctx.Peliculas.Add(peli);
            }
            
            ctx.SaveChanges();

            return RedirectToAction("Peliculas");
        }

        //Obtener datos de una pelicula
        public ActionResult VerEditarPelicula(String id, String accion)
        {
            Entities ctx = new Entities();
            Peliculas peli = ctx.Peliculas.Find(Convert.ToInt32(id));
            List<Generos> generos_form = ctx.Generos.ToList();
            List<Calificaciones> calificaciones_form = ctx.Calificaciones.ToList();

            ViewBag.pelicula = peli;
            ViewBag.modo = accion;
            ViewBag.generos = generos_form;
            ViewBag.calificaciones = calificaciones_form;

            return View();
		}

        
        //Agregar cartelera nueva
        public ActionResult AgregarCartelera()
        {
            return View();
        }

       
    }
}