using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Curso : ObjetoEscuelaBase
    {
        public TipoJornada Jornada { get; set;}

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

    }
}
