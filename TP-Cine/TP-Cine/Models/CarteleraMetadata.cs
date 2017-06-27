using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TP_Cine.Models
{
    class CarteleraMetadata
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int IdCartelera { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int IdSede { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int IdPelicula { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Range(15, 23, ErrorMessage = "La hora de inicio permitida desde las 15 hasta las 23")]
        public int HoraInicio { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int NumeroSala { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int IdVersion { get; set; }

        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaCarga { get; set; }

        public virtual Peliculas Peliculas { get; set; }
        public virtual Sedes Sedes { get; set; }
        public virtual Versiones Versiones { get; set; }
    }
}
