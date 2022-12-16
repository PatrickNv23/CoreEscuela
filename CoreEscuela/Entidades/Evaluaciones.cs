using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Evaluaciones
    {
        public String Id { get; set; }
        public String Nombre { get; set; }

        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }
        public Evaluaciones()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
