using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Cine.Models.ModeloNegocio
{
    public class PeliculasNegocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public string Calificacion { get; set; }
        public string Genero { get; set; }
        public int Duracion { get; set; }
        public string Imagen { get; set; }

        public List<Peliculas> ObtenerTodas()
        {
            Entities ctx = new Entities();
            List<Peliculas> peliculas = ctx.Peliculas.ToList();
            return peliculas;
        }

        public void AgregarPelicula(Peliculas nueva_pelicula, Entities ctx)
        {
            nueva_pelicula.FechaCarga = DateTime.Now;
            ctx.Peliculas.Add(nueva_pelicula);
            ctx.SaveChanges();
        }

        public void ModificarPelicula(Peliculas modificar_pelicula, Entities ctx)
        {
            Peliculas peli = new Peliculas(); 
            peli = ctx.Peliculas.Find(modificar_pelicula.IdPelicula);
            peli.Nombre = modificar_pelicula.Nombre;
            peli.Descripcion = modificar_pelicula.Descripcion;
            peli.Calificaciones = modificar_pelicula.Calificaciones;
            peli.Generos = modificar_pelicula.Generos;
            if(modificar_pelicula.Imagen != null) { 
                peli.Imagen = modificar_pelicula.Imagen;
            }
            peli.Duracion = modificar_pelicula.Duracion;

            ctx.SaveChanges();
        }
    }
}