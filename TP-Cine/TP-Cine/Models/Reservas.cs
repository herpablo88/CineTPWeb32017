using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TP_Cine
{
    [MetadataType(typeof(ReservasMetadata))]
    public partial class Reservas
    {
        public class ReservasMetadata
        {
            [Required(ErrorMessage = "Debe seleccionar una sede")]
            public int IdSede { get; set; }

            [Required(ErrorMessage = "Debe seleccionar una versión")]
            public int IdVersion { get; set; }

            [Required(ErrorMessage = "Debe seleccionar la fecha")]
            public System.DateTime FechaHoraInicio { get; set; }

            [RegularExpression(@"\b[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)\b", ErrorMessage = "Ingrese un email válido")]
            [Required(ErrorMessage = "Debe ingresar {0}")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Seleccione el tipo de documento")]
            public int IdTipoDocumento { get; set; }

            [Required(ErrorMessage = "Debe ingresar su número de documento")]
            public string NumeroDocumento { get; set; }

            [Range (1, 100, ErrorMessage = "La cantidad ingresada es incorrecta")]
            [Required(ErrorMessage = "Indique la cantidad de entradas")]
            public int CantidadEntradas { get; set; }
        }
    }
}