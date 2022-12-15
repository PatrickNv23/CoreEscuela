// See https://aka.ms/new-console-template for more information
using CoreEscuela.Entidades;

namespace CoreEscuela{
    class Program
    {
        static void Main(String[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";
            escuela.TipoEscuela = TipoEscuela.Primaria;
            Console.WriteLine(escuela);
            var escuela2 = new Escuela("Escuela 2", 2013, TipoEscuela.Secundaria, pais:"Mexico");
            Console.WriteLine(escuela2);
        }
    }
}
