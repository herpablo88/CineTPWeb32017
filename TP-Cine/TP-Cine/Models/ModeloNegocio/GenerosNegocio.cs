using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Cine.Models.ModeloNegocio
{
    public class GenerosNegocio
    {
        public List<Generos> ObtenerTodos()
        {
            Entities ctx = new Entities();
            List<Generos> generos = ctx.Generos.ToList();
            return generos;
        }
    }
}