using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    internal abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre}, {Id}";
        }
    }
}
