﻿using System;
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
            //return View();
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
