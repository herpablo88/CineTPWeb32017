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
            Entities ctx = new Entities();
            var generos = (from Generos in ctx.Generos
                           select Generos);
            if (generos.Count() == 0)
            {
                Generos g1 = new Generos();
                Generos g2 = new Generos();
                Generos g3 = new Generos();

                g1.Nombre = "Terror";
                g2.Nombre = "Thriller";
                g3.Nombre = "Acción";

                ctx.Generos.Add(g1);
                ctx.Generos.Add(g2);
                ctx.Generos.Add(g3);
            }

            var calificaciones = (from Calificaciones in ctx.Calificaciones
                                  select Calificaciones);
            if (calificaciones.Count() == 0)
            {
                Calificaciones c1 = new Calificaciones();
                Calificaciones c2 = new Calificaciones();
                Calificaciones c3 = new Calificaciones();

                c1.Nombre = "ATP";
                c2.Nombre = "mayores de 13";
                c3.Nombre = "mayores de 13 con reservas";

                ctx.Calificaciones.Add(c1);
                ctx.Calificaciones.Add(c2);
                ctx.Calificaciones.Add(c3);
            }

            ctx.SaveChanges();

            return View();
        }

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

        public ActionResult Sedes()
        {
            List<Sedes> todasSedes = new List<Sedes>();

            Entities ctx = new Entities();

            var listaSedes = (from sedes in ctx.Sedes
                              select sedes).ToList();

            todasSedes = (List<Sedes>)listaSedes;

            return View(todasSedes);
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
            Calificaciones calif = new Calificaciones();
            Generos gen = new Generos();

            peli.Nombre = form["nombre"];
            peli.Descripcion = form["descripcion"];
            var c = form["calificacion"];
            peli.Calificaciones = ctx.Calificaciones.Find(Convert.ToInt32(c)); 
            var g = form["genero"];
            peli.Generos = ctx.Generos.Find(Convert.ToInt32(g));
            peli.Imagen = form["imagen"];//cambiar por img_64 para base64
            peli.Duracion = Convert.ToInt16(form["duracion"]);
            peli.FechaCarga = DateTime.Now;

            ctx.Peliculas.Add(peli);
            ctx.SaveChanges();

            return View("Peliculas");
        }

        //Obtener datos de una pelicula
        public ActionResult VerPelicula(int IdPelicula)
        {
            Entities ctx = new Entities();
            Peliculas pelicula = ctx.Peliculas.Find(IdPelicula);

            return View(pelicula);
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

            //return View("Sedes");
            return RedirectToAction("Sedes");
        }

        //Agregar cartelera nueva
        public ActionResult AgregarCartelera()
        {
            return View();
        }

       
    }
}
