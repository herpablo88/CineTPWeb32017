using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Cine.Models.ModeloNegocio
{
    public class ReservasNegocio
    {
        public int Reserva { get; set; }
        public string Sede { get; set; }
        public string Version { get; set; }
        public string Pelicula { get; set; }
        public decimal Precio { get; set; }
        public string ReservadoPor { get; set; }
        public DateTime Fecha { get; set; }
    }
}