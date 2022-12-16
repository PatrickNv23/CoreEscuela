using CoreEscuela.Interfaces;
using CoreEscuela.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Curso : ObjetoEscuelaBase, ILugar
    {
        public TipoJornada Jornada { get; set;}

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public string Direccion { get; set; }

        public void limpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando establecimiento");
            Console.WriteLine($"Curso {Nombre} limpio");
        }
    }
}
