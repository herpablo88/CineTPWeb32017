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
    public class CartelerasController : Controller
    {
        private Entities db = new Entities();
        TP_Cine.Models.ModeloNegocio.CarteleraNegocio validar = new Models.ModeloNegocio.CarteleraNegocio();
        public ActionResult Index()
        {
            var carteleras = db.Carteleras.Include(c => c.Peliculas).Include(c => c.Sedes).Include(c => c.Versiones);
            return PartialView(carteleras.ToList());
        }

     
        public ActionResult Crear()
        {
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre");
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre");
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Crear([Bind(Include = "IdCartelera,IdSede,IdPelicula,HoraInicio,FechaInicio,FechaFin,NumeroSala,IdVersion,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo")] Carteleras carteleras)
        {

            carteleras.FechaCarga = DateTime.Now;

            if (ModelState.IsValid)
            {  
                 
               string mensaje = validar.validarCartelera(carteleras);
               string mensajeDias = validar.validoDias(carteleras);
               if (mensaje != null)
               {
                   ModelState.AddModelError("validacion", mensaje);

                }
                else { 
                       if(mensajeDias != null){
                            ModelState.AddModelError("validacionDias", mensajeDias);
                       }
                       else
                       {
                           validar.agregarCartelera(carteleras);
                           validar.validoDias(carteleras);
                           return RedirectToAction("Carteleras", "Administracion");
                       }
                }
            }

            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre", carteleras.IdPelicula);
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre", carteleras.IdSede);
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre", carteleras.IdVersion);
            return View(carteleras);
        }

      
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carteleras carteleras = db.Carteleras.Find(id);
            if (carteleras == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre", carteleras.IdPelicula);
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre", carteleras.IdSede);
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre", carteleras.IdVersion);
            return View(carteleras);
        }

   
        [HttpPost]
      
        public ActionResult Editar([Bind(Include = "IdCartelera,IdSede,IdPelicula,HoraInicio,FechaInicio,FechaFin,NumeroSala,IdVersion,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaCarga")] Carteleras carteleras)
        {
            if (ModelState.IsValid)
            {
                string mensaje = validar.validarCateleraEdit(carteleras);
                string mensajeDias = validar.validoDias(carteleras);
                if (mensaje != null)
                {
                    ModelState.AddModelError("validacion", mensaje);
                }
                if (mensajeDias != null)
                {
                    ModelState.AddModelError("validacionDias", mensajeDias);
                }
                else
                {
                    validar.modificarCartelera(carteleras);
                  
                    return RedirectToAction("Carteleras", "Administracion");;
                } 
            }
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "IdPelicula", "Nombre", carteleras.IdPelicula);
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre", carteleras.IdSede);
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre", carteleras.IdVersion);
            return View(carteleras);
        }

     
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carteleras carteleras = db.Carteleras.Find(id);
            if (carteleras == null)
            {
                return HttpNotFound();
            }
            return View(carteleras);
        }

      
        [HttpPost, ActionName("Eliminar")]
    
        public ActionResult ConfirmarEliminar(int id)
        {   
            validar.eliminarCartelera(id);
            return RedirectToAction("Carteleras", "Administracion");
        }


    }
}
