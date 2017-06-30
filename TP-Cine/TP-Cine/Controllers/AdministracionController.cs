using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP_Cine.Models.ModeloNegocio;
using TP_Cine.Utilities;
using TP_Cine.Models;

namespace TP_Cine.Controllers
{
    public class AdministracionController : Controller
    {
        CineNegocio CN = new CineNegocio(); //Si lo creamos aca no es necesario agregarlo en todas las acciones
        Entities ctx = new Entities();
       
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

        //[HttpPost]
        //public ActionResult AgregarSede(FormCollection form)
        //{
        //    CN.agregarSede(form["nombre"], form["direccion"], Convert.ToDecimal(form["precioGeneral"]));

        //    return RedirectToAction("Sedes");
        //}

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
            TimeSpan periodo = Convert.ToDateTime(form["fechaFin"]) - Convert.ToDateTime(form["fechaInicio"]);

            if(periodo.Days <= 30)
            {
                CN.listarReservas(form["fechaInicio"], form["fechaFin"]);
            }
            else
            {
                ViewBag.Mensaje = "El periodo consultado no puede superar los 30 días";
                CN.listarReservas();
            }

            return View("Reportes", CN.listaReservasNegocio);
        }

        //
        public ActionResult Peliculas()
        {
            PeliculasNegocio listado_peliculas = new PeliculasNegocio();
            List<Peliculas> TodasLasPeliculas = new List<TP_Cine.Peliculas>();
            TodasLasPeliculas = listado_peliculas.ObtenerTodas();

            return View(TodasLasPeliculas);
        }


        public ActionResult Carteleras()
        {  
            Entities db = new Entities();
            var carteleras = db.Carteleras.Include(c => c.Peliculas).Include(c => c.Sedes).Include(c => c.Versiones);
            return View(carteleras.ToList());
        }
        

        //Agregar pelicula nueva
        [HttpPost]
        public ActionResult AgregarEditarPelicula(Peliculas pelicula,FormCollection form)
        {
            Entities ctx = new Entities();
            PeliculasNegocio trabajar_pelicula = new PeliculasNegocio();

            pelicula.Calificaciones = ctx.Calificaciones.Find(Convert.ToInt32(form["Calificaciones"]));
            pelicula.Generos = ctx.Generos.Find(Convert.ToInt32(form["Generos"]));

            //Agregar imagen
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                string nombreSignificativo = pelicula.Nombre;
                //Guardar Imagen
                string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                pelicula.Imagen= pathRelativoImagen;
            }

            if (form["accion"] == "agregar")
            {
                //Agregar pelicula
                trabajar_pelicula.AgregarPelicula(pelicula, ctx);
            }
            else
            {
                //Editar pelicula
                trabajar_pelicula.ModificarPelicula(pelicula, ctx);
            }
        
            return RedirectToAction("Peliculas");
        }

        //Obtener datos de una pelicula
        public ActionResult ABMPelicula(String id, String accion)
        {
            VerEditarCrearPeliculaModelo modelo_vereditar = new VerEditarCrearPeliculaModelo();
            modelo_vereditar.accion = accion;

            if (accion == "agregar")
            {
                modelo_vereditar.pelicula.Descripcion = "";
                modelo_vereditar.pelicula.IdGenero = 0;
                modelo_vereditar.pelicula.IdCalificacion = 0;
                modelo_vereditar.pelicula.Duracion = 0;
            }else {
                Entities ctx = new Entities();
                modelo_vereditar.pelicula = ctx.Peliculas.Find(Convert.ToInt32(id)); 
            }
            return View(modelo_vereditar);
		}

        
        //Agregar cartelera nueva
        public ActionResult AgregarCartelera()
        {
            return View();
        }

        //Estos dos ActionResult son de prueba
        public ActionResult AgregarSede()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarSede(FormCollection form)
        {
            //if (!ModelState.IsValid)
            //{
                CN.agregarSede(form["Nombre"], form["Direccion"], Convert.ToDecimal(form["PrecioGeneral"]));
                return RedirectToAction("Sedes");
            //}
            //return RedirectToAction("AgregarSede");
        }
    }
}