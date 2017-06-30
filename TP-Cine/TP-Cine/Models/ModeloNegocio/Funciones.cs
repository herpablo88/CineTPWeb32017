using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Cine.Models.ModeloNegocio
{
    public class Funciones
    {
        string FechaHora { get; set; }


        public List<string> obtenerFunciones(int pelicula, int version, int sede)
        {
            Entities ctx = new Entities();

            Carteleras cartelera = (from Carteleras c in ctx.Carteleras
                                    join Sedes s in ctx.Sedes on c.IdSede equals s.IdSede
                                    join Versiones v in ctx.Versiones on c.IdVersion equals v.IdVersion
                                    where c.IdPelicula == pelicula && c.IdVersion == version && c.IdSede == sede
                                    select c).First();

            int duracion = (from Peliculas p in ctx.Peliculas
                            where p.IdPelicula == pelicula
                            select p.Duracion).First();

            int hora = cartelera.HoraInicio; //Va ser el horario de la primer funcion

            DateTime fecha = cartelera.FechaInicio; 
            DateTime hoy = DateTime.Today;

            List<string> funciones = new List<string>(); //Acá voy a agregar todas las fechas y horarios disponibles

            TimeSpan difDias = cartelera.FechaFin - cartelera.FechaInicio; //Para saber cuantas fechas consultar
            int cantDias = difDias.Days;

            for (int dia = 1; dia <= cantDias; dia++)
            {
                if (fecha > hoy) //No voy a mostrar fechas anteriores al dia actual
                {
                    switch (fecha.DayOfWeek)
                    {
                        case DayOfWeek.Monday: if (cartelera.Lunes) { agregarFunciones(funciones, fecha, hora, duracion); }
                            break;

                        case DayOfWeek.Tuesday: if (cartelera.Martes) { agregarFunciones(funciones, fecha, hora, duracion); }
                            break;

                        case DayOfWeek.Wednesday: if (cartelera.Miercoles) { agregarFunciones(funciones, fecha, hora, duracion); }
                            break;

                        case DayOfWeek.Thursday: if (cartelera.Jueves) { agregarFunciones(funciones, fecha, hora, duracion); }
                            break;

                        case DayOfWeek.Friday: if (cartelera.Viernes) { agregarFunciones(funciones, fecha, hora, duracion); }
                            break;

                        case DayOfWeek.Saturday: if (cartelera.Sabado) { agregarFunciones(funciones, fecha, hora, duracion); }
                            break;

                        case DayOfWeek.Sunday: if (cartelera.Domingo) { agregarFunciones(funciones, fecha, hora, duracion); }
                            break;
                    }
                }

                fecha = fecha.AddDays(1);
            }

            return funciones;
        }

        public void agregarFunciones(List<string> f, DateTime fecha, int hora, int duracion)
        {
            fecha = fecha.Date;

            DateTime horario = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora, 00, 00);

            for (int i = 1; i <= 7; i++)
            {
                f.Add(horario.Year.ToString()+'/'+horario.Month.ToString()+'/'+horario.Day.ToString()+' '+horario.TimeOfDay.ToString());
               
                //Despues de agregar la primer funcion indico que para el horario de la proxima sume duracion y media hora
                horario = horario.AddMinutes(duracion + 30);
            }
        }

    }

}
