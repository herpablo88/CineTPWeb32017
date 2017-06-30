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
            ViewBag.Pelicula = CN.obtenerPelicula(id);
            ViewBag.Versiones = CN.listarVersionesProyectaPelicula(id);
            ViewBag.TiposDoc = CN.listarTipoDocumentos();
            Session["PeliculaElegida"] = id;

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
            ViewBag.precio = CN.precioTotal(int.Parse(form["IdSede"]), int.Parse(form["CantidadEntradas"]));

            return View(pelicula);
        }

        //Metodo para filtrar las sedes
        public JsonResult obtenerSedeReserva(string id)
        {
            int version = int.Parse(id);
            int pelicula = int.Parse(Session["PeliculaElegida"].ToString());

            List<Sedes> sedesPorVersion = CN.listarSedesProyectaPelicula(pelicula, version);
            List<SelectListItem> sedes = new List<SelectListItem>();
            foreach (Sedes s in sedesPorVersion)
            {
                sedes.Add(new SelectListItem { Text = @s.Nombre, Value = @s.IdSede.ToString() });
            }

            Session["VersionElegida"] = id;

            return Json(new SelectList(sedes, "Value", "Text"));
        }

        //Metodo para filtrar fechas
        public JsonResult obtenerFechaHoraReserva(string id)
        {
            int pelicula = int.Parse(Session["PeliculaElegida"].ToString());
            int version = int.Parse(Session["VersionElegida"].ToString());
            int sede = int.Parse(id);
            
            Funciones f = new Funciones();

            List<string> funciones = f.obtenerFunciones(pelicula, version, sede); 

            List<SelectListItem> fechas = new List<SelectListItem>();

            foreach(string fch in funciones)
            {
                fechas.Add(new SelectListItem { Text = fch, Value = fch });
            }

            return Json(new SelectList(fechas, "Value", "Text"));
        }
    }
}
