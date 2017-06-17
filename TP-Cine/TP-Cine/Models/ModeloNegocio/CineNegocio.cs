using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TP_Cine.Models.ModeloNegocio
{
    public class CineNegocio
    {
        public List<Sedes> listaSedes = new List<Sedes>();


        //Trar datos de la BD para que los utilice el Controller
       
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
        

            
    }
}