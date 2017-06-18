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
        public List<Reservas> listaReservas = new List<Reservas>();


               
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
            
    }
}