using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Cine.Models.ModeloNegocio;

namespace TP_Cine.Models
{
    public class VerEditarCrearPeliculaModelo
    {
        public Peliculas pelicula = new Peliculas();
        public List<Generos> lista_generos;
        public List<Calificaciones> lista_calificaciones;
        public string accion;

        public VerEditarCrearPeliculaModelo(){
            GenerosNegocio listado_generos = new GenerosNegocio();
            CalificacionesNegocio listado_calificaciones = new CalificacionesNegocio();
            this.lista_generos = listado_generos.ObtenerTodos();
            this.lista_calificaciones = listado_calificaciones.ObtenerTodas();
        }
    }
}