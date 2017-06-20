using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Cine.Models.ModeloNegocio;

namespace TP_Cine.Controllers
{
    public class PeliculasController : Controller
    {
        CineNegocio CN = new CineNegocio();

        //
        // GET: /Peliculas/

        public ActionResult PeliculaDetalles(int id)
        {
            PeliculasNegocio pelicula = CN.obtenerPeliculaNegocio(id);

            return View(pelicula);
        }
        
        public ActionResult Reserva(int id)
        {
            CN.prepararParaReserva();

            ViewBag.Pelicula = CN.obtenerPelicula(id);
            ViewBag.Sedes = CN.listaSedes;
            ViewBag.Versiones = CN.listaVersiones;
            ViewBag.TiposDoc = CN.listaTiposDoc;

            return View();
        }

        [HttpPost]
        public ActionResult Reservar(FormCollection form)
        {
            CN.reservar(int.Parse(form["IdSede"]), int.Parse(form["IdVersion"]), int.Parse(form["IdPelicula"]),
                form["FechaHoraInicio"], form["Email"], int.Parse(form["IdTipoDocumento"]), 
                    form["NumeroDocumento"], int.Parse(form["CantidadEntradas"]), form["FechaCarga"]);

            PeliculasNegocio pelicula = CN.obtenerPeliculaNegocio(int.Parse(form["IdPelicula"]));
            ViewBag.info = form;

            return View(pelicula);
        }

       
      
    }
}
