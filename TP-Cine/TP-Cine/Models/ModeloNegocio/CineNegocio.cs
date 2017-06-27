using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TP_Cine.Models.ModeloNegocio
{
    public class CineNegocio
    {
        Entities ctx = new Entities();

        public List<Sedes> listaSedes = new List<Sedes>();
        public List<ReservasNegocio> listaReservasNegocio = new List<ReservasNegocio>(); //Para Reporte de Reservas
        public List<PeliculasNegocio> listaPeliculasNegocio = new List<PeliculasNegocio>(); //Para mostrar en Inicio


        //Gestion de Sedes

        public void agregarSede(string nombre, string direccion, decimal precio)
        {
            Sedes sede = new Sedes();

            sede.Nombre = nombre;
            sede.Direccion = direccion;
            sede.PrecioGeneral = precio;

            ctx.Sedes.Add(sede);
            ctx.SaveChanges();

        }

        public void listarSedes()
        {

            var listaSedes = (from sedes in ctx.Sedes
                              select sedes).ToList();

            this.listaSedes = (List<Sedes>)listaSedes;

        }

        public Sedes obtenerSede(int id)
        {
            Sedes sede = new Sedes();

            var editar = (from sedes in ctx.Sedes
                          where sedes.IdSede == id
                          select sedes).ToList();

            sede = editar.First();

            return sede;
        }

        public void modificarSede(int id, string nombre, string direccion, decimal precio)
        {
            Sedes sede = (from sedes in ctx.Sedes
                          where sedes.IdSede == id
                          select sedes).First();

            sede.Nombre = nombre;
            sede.Direccion = direccion;
            sede.PrecioGeneral = precio;

            ctx.SaveChanges();
        }

        //Gestión de Reservas
        public void listarReservas()
        {
            List<ReservasNegocio> listaReservas = (from Reservas r in ctx.Reservas
                                                   join Sedes s in ctx.Sedes on r.IdSede equals s.IdSede
                                                   join Versiones v in ctx.Versiones on r.IdVersion equals v.IdVersion
                                                   join Peliculas p in ctx.Peliculas on r.IdPelicula equals p.IdPelicula
                                                   join TiposDocumentos d in ctx.TiposDocumentos on r.IdTipoDocumento equals d.IdTipoDocumento
                                                   select new ReservasNegocio()
                                                   {
                                                       Reserva = r.IdReserva,
                                                       Sede = s.Nombre,
                                                       Version = v.Nombre,
                                                       Pelicula = p.Nombre,
                                                       Precio = s.PrecioGeneral,
                                                       ReservadoPor = d.Descripcion +": " + r.NumeroDocumento,
                                                       Fecha = r.FechaHoraInicio
                                                   }).ToList();

            this.listaReservasNegocio = listaReservas;
        }

        public void listarReservas(string fechaInicio, string fechaFin)
        {
            DateTime fInicio = Convert.ToDateTime(fechaInicio);
            DateTime fFin = Convert.ToDateTime(fechaFin);

            List<ReservasNegocio> listaReservas = (from Reservas r in ctx.Reservas
                                                   join Sedes s in ctx.Sedes on r.IdSede equals s.IdSede
                                                   join Versiones v in ctx.Versiones on r.IdVersion equals v.IdVersion
                                                   join Peliculas p in ctx.Peliculas on r.IdPelicula equals p.IdPelicula
                                                   join TiposDocumentos d in ctx.TiposDocumentos on r.IdTipoDocumento equals d.IdTipoDocumento
                                                   where fInicio <= r.FechaHoraInicio && r.FechaHoraInicio <= fFin
                                                   select new ReservasNegocio()
                                                   {
                                                       Reserva = r.IdReserva,
                                                       Sede = s.Nombre,
                                                       Version = v.Nombre,
                                                       Pelicula = p.Nombre,
                                                       Precio = s.PrecioGeneral,
                                                       ReservadoPor = d.Descripcion + ": " + r.NumeroDocumento,
                                                       Fecha = r.FechaHoraInicio
                                                   }).ToList();

            this.listaReservasNegocio = listaReservas;
        }


        //Películas Negocio
        public void listarPeliculasNegocio()
        {
            List<PeliculasNegocio> listaPeliculas = (from Peliculas p in ctx.Peliculas
                                                     join Calificaciones c in ctx.Calificaciones on p.IdCalificacion equals c.IdCalificacion
                                                     join Generos g in ctx.Generos on p.IdGenero equals g.IdGenero
                                                     select new PeliculasNegocio()
                                                     {
                                                         Id = p.IdPelicula,
                                                         Nombre = p.Nombre,
                                                         Sinopsis = p.Descripcion,
                                                         Calificacion = c.Nombre,
                                                         Genero = g.Nombre,
                                                         Duracion = p.Duracion,
                                                         Imagen = p.Imagen
                                                     }).ToList();

            this.listaPeliculasNegocio = listaPeliculas;
        }

        public PeliculasNegocio obtenerPeliculaNegocio(int id)
        {
            PeliculasNegocio pelicula = (from Peliculas p in ctx.Peliculas
                                         join Calificaciones c in ctx.Calificaciones on p.IdCalificacion equals c.IdCalificacion
                                         join Generos g in ctx.Generos on p.IdGenero equals g.IdGenero
                                         where p.IdPelicula == id
                                         select new PeliculasNegocio()
                                         {
                                             Id = p.IdPelicula,
                                             Nombre = p.Nombre,
                                             Sinopsis = p.Descripcion,
                                             Calificacion = c.Nombre,
                                             Genero = g.Nombre,
                                             Duracion = p.Duracion,
                                             Imagen = p.Imagen
                                         }).First();

            return pelicula;
        }


        public List<Versiones> listarVersiones()
        {
            List<Versiones> listaVersiones = (from Versiones in ctx.Versiones
                                              select Versiones).ToList();

            return listaVersiones;
        }

        public List<TiposDocumentos> listarTipoDocumentos()
        {
            List<TiposDocumentos> listaTipos = (from TiposDocumentos in ctx.TiposDocumentos
                                                select TiposDocumentos).ToList();

            return listaTipos;
        }

        public Peliculas obtenerPelicula(int id)
        {
            Peliculas pelicula = (from Peliculas in ctx.Peliculas
                                  where Peliculas.IdPelicula == id
                                  select Peliculas).First();

            return pelicula;
        }


        //Reservar Película

        public void reservar(int sede, int version, int pelicula, string fhInicio, string email, int tipoDoc, string nroDoc, int cantEntradas, string fchCarga)
        {
            Reservas reserva = new Reservas();

            reserva.IdSede = sede;
            reserva.IdVersion = version;
            reserva.IdPelicula = pelicula;
            reserva.FechaHoraInicio = Convert.ToDateTime(fhInicio);
            reserva.Email = email;
            reserva.IdTipoDocumento = tipoDoc;
            reserva.NumeroDocumento = nroDoc;
            reserva.CantidadEntradas = cantEntradas;
            reserva.FechaCarga = DateTime.Now;

            ctx.Reservas.Add(reserva);
            ctx.SaveChanges();
        }




        public List<Versiones> listarVersionesProyectaPelicula(int idPelicula)
        {
            List<Versiones> versiones = ((from Versiones v in ctx.Versiones
                                          join Carteleras c in ctx.Carteleras on v.IdVersion equals c.IdVersion
                                          where c.IdPelicula == idPelicula
                                          select v).Distinct()).ToList();

            return versiones;
        }


        public List<Sedes> listarSedesProyectaPelicula(int pelicula, int version)
        {
            List<Sedes> listaSedes = ((from Sedes s in ctx.Sedes
                                       join Carteleras c in ctx.Carteleras on s.IdSede equals c.IdSede
                                       join Versiones v in ctx.Versiones on c.IdVersion equals v.IdVersion
                                       where c.IdPelicula == pelicula && c.IdVersion == version
                                       select s).Distinct()).ToList();

            return listaSedes;
        }
    }
}


