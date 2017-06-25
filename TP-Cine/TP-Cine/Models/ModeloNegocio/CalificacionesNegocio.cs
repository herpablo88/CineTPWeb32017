using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Cine.Models.ModeloNegocio
{
    public class CalificacionesNegocio
    {
        public List<Calificaciones> ObtenerTodas()
        {
            Entities ctx = new Entities();
            List<Calificaciones> calificaciones = ctx.Calificaciones.ToList();
            return calificaciones;
        }
    }
}