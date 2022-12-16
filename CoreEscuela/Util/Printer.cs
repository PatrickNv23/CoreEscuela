using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CoreEscuela.Util
{
    internal static class Printer
    {

        public static void DibujarLinea(int tamaño = 10)
        {
            String linea = "".PadLeft(tamaño, '=');
            WriteLine(linea);
        }

        public static void DibujarTitulo(String titulo)
        {
            DibujarLinea(titulo.Length);
            WriteLine(titulo);
            DibujarLinea(titulo.Length);
        }

        public static void pitar(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while(cantidad-- > 0)
            {
                Beep(hz, tiempo);
            }
        }
    }
}
