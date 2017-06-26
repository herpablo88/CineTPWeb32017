using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TP_Cine
{
    [MetadataType(typeof(SedesMetadata))]
    public partial class Sedes
    {
        public class SedesMetadata
        {
            [StringLength(100, ErrorMessage = "{0} excede el límite de caracteres")]
            [Required(ErrorMessage = "Debe ingresar {0}")]
            public string Nombre { get; set; }
            [StringLength(300, ErrorMessage = "{0} excede el límite de caracteres")]
            [Required(ErrorMessage = "Debe ingresar {0}")]
            public string Direccion { get; set; }
            [Range(0, 1000, ErrorMessage = "El valor ingresado no es válido")]
            [Required(ErrorMessage = "Debe ingresar {0}")]
            public decimal PrecioGeneral { get; set; }
        }
    }
}