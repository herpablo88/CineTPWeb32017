using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TP_Cine.Models.ModeloNegocio
{
    public class CineNegocio
    {
        public List<Sedes> listaSedes = new List<Sedes>();
        public List<ReservasNegocio> listaReservasNegocio = new List<ReservasNegocio>(); //Para Reporte de Reservas
        public List<PeliculasNegocio> listaPeliculasNegocio = new List<PeliculasNegocio>(); //Para mostrar en Inicio
        public List<Versiones> listaVersiones = new List<Versiones>();
        public List<TiposDocumentos> listaTiposDoc = new List<TiposDocumentos>();

               
        //Gestion de Sedes
        
        public void agregarSede(string nombre, string direccion, decimal precio)
        {
            Entities ctx = new Entities();
            Sedes sede = new Sedes();

            sede.Nombre = nombre;
            sede.Direccion = direccion;
            sede.PrecioGeneral = precio;

            ctx.Sedes.Add(sede);
            ctx.SaveChanges();

        }

        public void listarSedes()
        {
            Entities ctx = new Entities();

            var listaSedes = (from sedes in ctx.Sedes
                              select sedes).ToList();

            this.listaSedes = (List<Sedes>)listaSedes;

        }

        public Sedes obtenerSede(int id)
        {
            Entities ctx = new Entities();
            Sedes sede = new Sedes();

            var editar = (from sedes in ctx.Sedes
                          where sedes.IdSede == id
                          select sedes).ToList();

            sede = editar.First();

            return sede;
        }

        public void modificarSede(int id, string nombre, string direccion, decimal precio)
        {
            Entities ctx = new Entities();

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
            Entities ctx = new Entities();

            List<ReservasNegocio> listaReservas = (from Reservas r in ctx.Reservas join Sedes s in ctx.Sedes on r.IdSede equals s.IdSede 
                                   join Versiones v in ctx.Versiones on r.IdVersion equals v.IdVersion 
                                    join Peliculas p in ctx.Peliculas on r.IdPelicula equals p.IdPelicula 
                              select  new ReservasNegocio()
                              {   Reserva = r.IdReserva,
                                  Sede = s.Nombre,
                                  Version = v.Nombre,
                                  Pelicula = p.Nombre,
                                  Precio = s.PrecioGeneral
                              }).ToList();
             
            this.listaReservasNegocio = listaReservas;
        }

        public void listarReservas(string fechaInicio, string fechaFin)
        {
            Entities ctx = new Entities();

            DateTime fInicio = Convert.ToDateTime(fechaInicio);
            DateTime fFin = Convert.ToDateTime(fechaFin);
            
            List<ReservasNegocio> listaReservas = (from Reservas r in ctx.Reservas
                                                   join Sedes s in ctx.Sedes on r.IdSede equals s.IdSede
                                                   join Versiones v in ctx.Versiones on r.IdVersion equals v.IdVersion
                                                   join Peliculas p in ctx.Peliculas on r.IdPelicula equals p.IdPelicula
                                                   where fInicio <= r.FechaHoraInicio && r.FechaHoraInicio <= fFin
                                                   select new ReservasNegocio()
                                                   {
                                                       Reserva = r.IdReserva,
                                                       Sede = s.Nombre,
                                                       Version = v.Nombre,
                                                       Pelicula = p.Nombre,
                                                       Precio = s.PrecioGeneral
                                                   }).ToList();

            this.listaReservasNegocio = listaReservas;
        }
            

        //Películas Negocio
        public void listarPeliculasNegocio()
        {
            Entities ctx = new Entities();

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
            Entities ctx = new Entities();

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

       
        public void listarVersiones()
        {
            Entities ctx = new Entities();

            var listaVersiones = (from Versiones in ctx.Versiones
                              select Versiones).ToList();

            this.listaVersiones = (List<Versiones>)listaVersiones;
        }

        public void listarTipoDocumentos()
        {
            Entities ctx = new Entities();

            var listaTipos = (from TiposDocumentos in ctx.TiposDocumentos
                                  select TiposDocumentos).ToList();

            this.listaTiposDoc = (List<TiposDocumentos>)listaTipos;
        }

        public Peliculas obtenerPelicula (int id)
        {
            Entities ctx = new Entities();

            Peliculas pelicula = (from Peliculas in ctx.Peliculas
                                  where Peliculas.IdPelicula == id
                                  select Peliculas).First();

            return pelicula;
        }
        

        //Reservar Película
      
        public void reservar(int sede, int version, int pelicula, string fhInicio, string email, int tipoDoc, string nroDoc, int cantEntradas, string fchCarga)
        {
            Entities ctx = new Entities();
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

        
        public void prepararParaReserva(int id)
        {
            this.listarSedesProyectaPelicula(id);
            this.listarVersiones();
            this.listarTipoDocumentos();
        }

        public List<Sedes> listarSedesProyectaPelicula(int id)
        {
            Entities ctx = new Entities();

            List<Sedes> listaSedes = ((from Sedes s in ctx.Sedes
                                       join Carteleras c in ctx.Carteleras on s.IdSede equals c.IdSede
                                       where c.IdPelicula == id
                                       select s).Distinct()).ToList();

            return listaSedes;
        }

        public List<Versiones> listarVersionesProyectaPelicula(int idPelicula, int idSede)
        {
            Entities ctx = new Entities();

            List<Versiones> versiones = (from Versiones v in ctx.Versiones 
                                         join Carteleras c in ctx.Carteleras on v.IdVersion equals c.IdVersion
                                          join Sedes s in ctx.Sedes on c.IdSede equals s.IdSede
                                         where c.IdPelicula == idPelicula && c.IdSede == idSede
                                         select v).ToList();

            return versiones;
        }
    }
}


