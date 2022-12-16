// See https://aka.ms/new-console-template for more information
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela{
    internal class Program
    {
        static void Main(String[] args)
        {
            var EscuelaEngine = new EscuelaEngine();
            EscuelaEngine.Inicializar();
            Printer.DibujarLinea();
            Printer.DibujarLinea(20);
            //Printer.pitar(cantidad: 10);
            imprimirCursosEscuela(EscuelaEngine.Escuela);
            var listaObjetos = EscuelaEngine.obtenerObjetosEscuelaBase();

            foreach (var objeto in listaObjetos)
            {
                WriteLine(objeto);
            }

        }

            private static void imprimirCursosEscuela(Escuela escuela)
        {
            WriteLine(escuela);
            Printer.DibujarTitulo($"Curso de Escuela {escuela.Nombre}");

            if (escuela?.Cursos != null)
            {
                foreach (Curso curso in escuela.Cursos)
                {
                    WriteLine($"{curso.Nombre} - Id: {curso.Id}");
                }
            }
        }

    }
}
