using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace TP_Cine.Models.ModeloNegocio
{
    public class CarteleraNegocio
    {
        //valido crear cartelera
        public string validarCartelera(Carteleras cartelera)
        {   

            Entities ctx = new Entities();
            DateTime finicio = Convert.ToDateTime(cartelera.FechaInicio.ToShortDateString());
            DateTime ffin = Convert.ToDateTime(cartelera.FechaFin.ToShortDateString());
        
            // por cada sala se permiten max 7 funciones
            if (ctx.Carteleras.Where(X => X.NumeroSala == cartelera.NumeroSala).Count() > 7)
           {
              return "Error!,No puede existir mas de 7 funciones por sala";
           }

           //verifico hora de inicio no sea anterior a las 15:00hs.
            int horaInicio;
            horaInicio = int.Parse(cartelera.HoraInicio.ToString().Substring(0, 2)); 
           if (horaInicio < 15) {
               return "La hora de inicio debe ser posterior o igual a las 15:00hs";
           } 

          //verifico si se ingresan datos duplicados
           if (ctx.Carteleras.Where(d => d.IdPelicula == cartelera.IdPelicula && d.IdSede == cartelera.IdSede && d.IdVersion == cartelera.IdVersion).Count() > 0)
           {
               return "Error!, Ya existe un registro con misma pelicula,version,sede";
           }

           // no podrá haber más de una cartelera cargada para la misma fecha
           if (ctx.Carteleras.Where(f => f.FechaInicio >= finicio && f.FechaFin >= ffin && f.FechaInicio <= ffin).Count() > 0)
           {   
              
               return "Error!,Fecha de fin utilizada por otra cartelera";
           }

           if (ctx.Carteleras.Where(f => f.FechaInicio <= finicio && f.FechaFin >= ffin).Count() > 0)
           {
               return "Error!,Fechas utilizada por otra cartelera";
           }

           if (ctx.Carteleras.Where(f => f.FechaInicio <= finicio && f.FechaFin <= ffin && f.FechaFin >= finicio).Count() > 0)
           {
               return "Error!,Fecha de inicio utilizada por otra cartelera";
           }

           return null;

        }

        
        //valido modificacion de cartelera
        public string validarCateleraEdit(Carteleras cartelera)
        {
            Entities ctx = new Entities();
            DateTime finicio = Convert.ToDateTime(cartelera.FechaInicio.ToShortDateString());
            DateTime ffin = Convert.ToDateTime(cartelera.FechaFin.ToShortDateString());


            // por cada sala se permiten max 7 funciones
            if (ctx.Carteleras.Where(X => X.NumeroSala == cartelera.NumeroSala).Count() > 7)
            {
                return "Error!,No puede existir mas de 7 funciones por sala";
            }

            //verifico hora de inicio no sea anterior a las 15:00hs.
            int horaInicio;
            horaInicio = int.Parse(cartelera.HoraInicio.ToString().Substring(0, 2));
            if (horaInicio < 15)
            {
                return "La hora de inicio debe ser posterior o igual a las 15:00hs";
            }

            //verifico si se ingresan datos duplicados
            if (ctx.Carteleras.Where(d => d.Peliculas == cartelera.Peliculas && d.IdSede == cartelera.IdSede && d.IdVersion == cartelera.IdVersion &&  d.IdVersion == cartelera.IdVersion).Count() > 0)
            {
                return "Error!, Ya existe un registro con misma pelicula,version,sede";
            }

            // no podrá haber más de una cartelera cargada para la misma fecha
            if (ctx.Carteleras.Where(f => f.FechaInicio >= finicio && f.FechaFin >= ffin && f.FechaInicio <= ffin && f.IdPelicula != cartelera.IdPelicula).Count() > 0)
            {

                return "Error!,Fecha de fin utilizada por otra cartelera";
            }

            if (ctx.Carteleras.Where(f => f.FechaInicio <= finicio && f.FechaFin >= ffin && f.IdPelicula != cartelera.IdPelicula).Count() > 0)
            {
                return "Error!,Fechas utilizada por otra cartelera";
            }

            if (ctx.Carteleras.Where(f => f.FechaInicio <= finicio && f.FechaFin <= ffin && f.FechaFin >= finicio && f.IdPelicula != cartelera.IdPelicula).Count() > 0)
            {
                return "Error!,Fecha de inicio utilizada por otra cartelera";
            }

            return null;
        }

        //valido dias
        public string validoDias(Carteleras cartelera) {

            if (cartelera.Lunes == false && cartelera.Martes == false && cartelera.Miercoles == false && cartelera.Jueves == false
                && cartelera.Viernes == false && cartelera.Sabado == false && cartelera.Domingo == false)
            {
                return "Seleccione dia para cartelera";
            }
            return null;
        
        }

        public void agregarCartelera(Carteleras cartelera) {

            Entities db = new Entities();
            db.Carteleras.Add(cartelera);
            db.SaveChanges();
        } 

        public void modificarCartelera(Carteleras cartelera){
            Entities db = new Entities();
            db.Entry(cartelera).State = EntityState.Modified;
            db.SaveChanges();
         
        }

        public void eliminarCartelera(int id) {
            Entities db = new Entities();
            Carteleras carteleras = db.Carteleras.Find(id);
            db.Carteleras.Remove(carteleras);
            db.SaveChanges();
        }
        
    }
}


