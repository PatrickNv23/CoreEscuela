using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Evaluacion : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota} - {Alumno.Nombre} - {Asignatura.Nombre}";
        }
    }
}
