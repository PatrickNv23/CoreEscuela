// See https://aka.ms/new-console-template for more information
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Interfaces;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela{
    internal class Program
    {
        static void Main(String[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => Printer.pitar(2000, 1000, 1);

            var EscuelaEngine = new EscuelaEngine();
            EscuelaEngine.Inicializar();
            Printer.DibujarLinea();
            Printer.DibujarLinea(20);
            imprimirCursosEscuela(EscuelaEngine.Escuela);

            Printer.DibujarLinea();
            var diccionarioTotal = EscuelaEngine.obtenerDiccionarObjetosEscuela();
            EscuelaEngine.imprimirDiccionario(diccionarioTotal);
        }


        private static void AccionDelEvento(object? sender, EventArgs e)
        {
            Printer.DibujarTitulo("SALIENDO");
            Printer.pitar(3000, 1000, 3);
            Printer.DibujarTitulo("SALIÓ!!!");
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
