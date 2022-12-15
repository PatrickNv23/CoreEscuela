using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal class Curso
    {
        public String Id { get; private set; }
        public String Nombre { get; set; }
        public TiposJornada Jornada { get; set;}

        public Curso()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
