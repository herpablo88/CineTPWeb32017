using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TP_Cine
{
    public class PeliculaMetadata
    {
        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre puede tener hasta 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripción es requerida.")]
        [StringLength(750, ErrorMessage = "La descripción puede tener hasta 750 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Imagen es requerida.")]
        [StringLength(300, ErrorMessage = "El nombre la imagen es muy largo.")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "La duración es requerida.")]
        [Range(1, 90, ErrorMessage = "La pelicula puede durar desde 1 hasta 90 minutos.")]
        public int Duracion { get; set; }

        [Required]
        public System.DateTime FechaCarga { get; set; }

        [Required(ErrorMessage = "La calificación es requerida.")]
        public int IdCalificacion { get; set; }

        [Required(ErrorMessage = "El Genero es requerido.")]
        public int IdGenero { get; set; }
    }
}