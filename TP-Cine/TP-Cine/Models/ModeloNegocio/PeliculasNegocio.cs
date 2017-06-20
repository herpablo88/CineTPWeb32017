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

    }
}